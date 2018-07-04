Imports DevExpress.XtraGrid
Imports DevExpress.Spreadsheet
Imports Ionic.Zip

Public Class frm_Main

    Private Sub btn_Add_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Add.ItemClick
        If OpenJSONFiles.ShowDialog = Windows.Forms.DialogResult.OK Then
            AddJsonFiles(OpenJSONFiles.FileNames)
        End If
    End Sub

    Private Sub AddJsonFiles(ByVal Files As String())
        For Each path As String In OpenJSONFiles.FileNames
            If path.ToLower.EndsWith(".json") Then
                lst_Json.Items.Add(New JSONFile(path))
            ElseIf path.ToLower.EndsWith(".zip") Then
                If isJsonZIP(path) Then
                    lst_Json.Items.Add(New JSONFile(path))
                Else
                    MsgBox(String.Format("Unable to add zip file. Can't find any JSON files in zip archive : '{0}'", path), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
                End If
            Else
                MsgBox(String.Format("Unknown Format for file : '{0}'", path), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
            End If
        Next
    End Sub

    Private Sub btn_Remove_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Remove.ItemClick
        If lst_Json.SelectedItems.Count > 0 Then
            Dim Items2Remove As New List(Of JSONFile)
            For Each i As JSONFile In lst_Json.Items
                Items2Remove.Add(i)
            Next
            For Each i As JSONFile In Items2Remove
                lst_Json.Items.Remove(i)
            Next
        End If
    End Sub

    Private Sub lst_Json_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lst_Json.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        If files.Count > 0 Then
            AddJsonFiles(files)
        End If
    End Sub

    Private Sub lst_Json_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lst_Json.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub btn_ReadJSON_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_ReadJSON.ItemClick
        If lst_Json.Items.Count = 0 Then
            MsgBox("Please add files to read.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
        Else
            If Not JSONReader.IsBusy Then JSONReader.RunWorkerAsync()
        End If
    End Sub

    Sub DisableControls()
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          DisableControls()
                      End Sub)
        Else
            rpg_Export.Enabled = False
            rpg_JSON.Enabled = False
            rpg_Process.Enabled = False
            lst_Json.Enabled = False

            ProgressPanel.Visible = True
        End If
    End Sub

    Sub EnableControls()
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          EnableControls()
                      End Sub)
        Else
            rpg_Export.Enabled = True
            rpg_JSON.Enabled = True
            rpg_Process.Enabled = True
            lst_Json.Enabled = True

            ProgressPanel.Visible = False
        End If
    End Sub

    Private Sub JSONReader_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles JSONReader.DoWork
        DisableControls()

        Me.Invoke(Sub()
                      tb_Sheets.TabPages.Clear(True)
                  End Sub)
        For Each json2read As JSONFile In lst_Json.Items
            Dim filename As String = json2read.Path
            If json2read.isZip Then
                Using zip = ZipFile.Read(filename)
                    Dim totalEntries As Integer = zip.Entries.Count
                    For Each ent As ZipEntry In zip.Entries
                        If ent.FileName.ToLower.EndsWith(".json") Then
                            Dim MS As New IO.MemoryStream
                            ent.Extract(MS)
                            AddData(ReadData(MS.ToArray))
                            Exit For
                        End If
                    Next
                End Using
            Else
                AddData(ReadData(My.Computer.FileSystem.ReadAllBytes(filename)))
            End If
        Next

        EnableControls()
    End Sub

    Private Function ReadData(ByVal Data As Byte()) As List(Of GSTR2AEntry)
        Dim R As New List(Of GSTR2AEntry)
        Dim Returns = ReadJson(System.Text.Encoding.ASCII.GetString(Data))
        For Each i As B2BEntry In Returns.B2BEntries
            For Each Invoice As Invoice In i.Invoices
                For Each item As Item In Invoice.Items
                    R.Add(New GSTR2AEntry(i.GSTIN, Invoice.InvoiceNumber, Invoice.InvoiceDate, CDbl(Invoice.Value), CDbl(item.ItemDetail.TaxableValue), CDbl(item.ItemDetail.IGST), CDbl(item.ItemDetail.CGST), CDbl(item.ItemDetail.SGST), CDbl(item.ItemDetail.CESS)))
                Next
            Next
        Next
        Return R
    End Function

    Private Sub AddData(ByVal Data As List(Of GSTR2AEntry))
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          AddData(Data)
                      End Sub)
        Else
            If btn_Combine.Down Then
                If tb_Sheets.TabPages.Count = 0 Then
                    AddSheet("GSTR2A", Data)
                Else
                    AppendSheet(0, Data)
                End If
            Else
                Dim SheetName As String = "GSTR2A - Sheet " & tb_Sheets.TabPages.Count + 1
                AddSheet(SheetName, Data)
            End If
        End If
    End Sub

    Private Sub AddSheet(ByVal SheetName As String, ByVal Data As List(Of GSTR2AEntry))
        Dim Page = tb_Sheets.TabPages.Add(SheetName)

        Dim GridView As Views.Grid.GridView = New Views.Grid.GridView
        GridView.OptionsBehavior.ReadOnly = True
        GridView.OptionsBehavior.Editable = False
        GridView.OptionsView.ShowGroupPanel = False

        Dim GridControl As GridControl = New GridControl With {.MainView = GridView, .DataSource = Data, .Dock = DockStyle.Fill, .Tag = SheetName}

        Page.Controls.Add(GridControl)
        Page.Tag = GridControl
    End Sub

    Private Sub AppendSheet(ByVal Index As Integer, ByVal Data As List(Of GSTR2AEntry))
        Dim Page = tb_Sheets.TabPages.Item(Index)

        If TypeOf Page.Tag Is GridControl Then
            Dim GridControl As GridControl = Page.Tag
            CType(GridControl.DataSource, List(Of GSTR2AEntry)).AddRange(Data)
        End If
    End Sub

    Function GetGridControl(ByVal PageIndex As Integer) As GridControl
        Dim Page = tb_Sheets.TabPages.Item(PageIndex)
        If TypeOf Page.Tag Is GridControl Then
            Return Page.Tag
        End If
        Return Nothing
    End Function

    Private Sub btn_Word_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Word.ItemClick
        Export(ExportFormat.Word)
    End Sub

    Sub Export(ByVal Format As ExportFormat)
        Dim Ext = SetupSaveDialog(Format)
        If tb_Sheets.TabPages.Count = 1 Then
            If SaveFileDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim GC As GridControl = GetGridControl(0)
                SaveFile(GC, Format, SaveFileDlg.FileName)
            End If
        ElseIf tb_Sheets.TabPages.Count > 1 Then
            If Format <> ExportFormat.XLS AndAlso Format <> ExportFormat.XLSX Then
                If SelectExportFolder.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For i As Integer = 0 To tb_Sheets.TabPages.Count - 1
                        tb_Sheets.SelectedTabPageIndex = i
                        Application.DoEvents()
                        Dim GC As GridControl = GetGridControl(i)
                        SaveFile(GC, Format, IO.Path.Combine(SelectExportFolder.SelectedPath, GC.Tag.ToString & "." & Ext))
                    Next
                End If
            Else
                ExportMultiSheetExcel(Format)
            End If
        Else
            MsgBox("No data to export. Pleas add json files & process before exporting", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
        End If
    End Sub
    Sub ExportMultiSheetExcel(ByVal Format As ExportFormat)
        If SaveFileDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim FinalWorkBook As New Workbook
            FinalWorkBook.BeginUpdate()
            For i As Integer = 0 To tb_Sheets.TabPages.Count - 1
                tb_Sheets.SelectedTabPageIndex = i
                Application.DoEvents()
                Dim GC As GridControl = GetGridControl(i)
                Using MS As New IO.MemoryStream
                    Select Case Format
                        Case ExportFormat.XLS
                            GC.ExportToXls(MS)
                        Case ExportFormat.XLSX
                            GC.ExportToXlsx(MS)
                    End Select
                    Using TempWorkBook As New Workbook
                        TempWorkBook.LoadDocument(MS)
                        Dim Sheet As Worksheet = FinalWorkBook.Worksheets.Add
                        Sheet.CopyFrom(TempWorkBook.Worksheets(0))
                        Sheet.Name = GC.Tag.ToString
                    End Using
                End Using
            Next
            FinalWorkBook.Worksheets.RemoveAt(0)
            FinalWorkBook.EndUpdate()
            FinalWorkBook.SaveDocument(SaveFileDlg.FileName)
        End If
    End Sub
    Sub SaveFile(ByVal GC As GridControl, ByVal Format As ExportFormat, ByVal Filename As String)
        Select Case Format
            Case ExportFormat.Word
                GC.ExportToDocx(Filename)
            Case ExportFormat.PDF
                GC.ExportToPdf(Filename)
            Case ExportFormat.CSV
                GC.ExportToCsv(Filename)
            Case ExportFormat.HTML
                GC.ExportToHtml(Filename)
            Case ExportFormat.MHTML
                GC.ExportToMht(Filename)
            Case ExportFormat.RTF
                GC.ExportToRtf(Filename)
            Case ExportFormat.TXT
                GC.ExportToText(Filename)
            Case ExportFormat.XLS
                GC.ExportToXls(Filename)
            Case ExportFormat.XLSX
                GC.ExportToXlsx(Filename)
        End Select
    End Sub
    Function SetupSaveDialog(ByVal Format As ExportFormat) As String
        Dim Extenstion As String = ""
        Dim Filter As String = ""
        Select Case Format
            Case ExportFormat.Word
                Extenstion = "docx"
                Filter = "Microsoft Word Document Files (*.docx)|*.docx"
            Case ExportFormat.PDF
                Extenstion = "pdf"
                Filter = "Adobe Portable Document Files (*.pdf)|*.pdf"
            Case ExportFormat.CSV
                Extenstion = "docx"
                Filter = "Comma Separated Values File (*.csv)|*.csv"
            Case ExportFormat.HTML
                Extenstion = "html"
                Filter = "HTML Webpage Files (*.html)|*.html"
            Case ExportFormat.MHTML
                Extenstion = "mhtml"
                Filter = "Microsoft Webpage Files (*.mhtml)|*.mhtml"
            Case ExportFormat.RTF
                Extenstion = "rtf"
                Filter = "Rich Text Format (*.rtf)|*.rtf"
            Case ExportFormat.TXT
                Extenstion = "txt"
                Filter = "Plain Text Files (*.txt)|*.txt"
            Case ExportFormat.XLS
                Extenstion = "xls"
                Filter = "Microsoft Excel 97-2003 Spreadsheet File (*.xls)|*.xls"
            Case ExportFormat.XLSX
                Extenstion = "xlsx"
                Filter = "Microsoft Excel 2007 Spreadsheet File (*.xlsx)|*.xlsx"
        End Select
        SaveFileDlg.DefaultExt = Extenstion
        SaveFileDlg.Filter = Filter
        Return Extenstion
    End Function

    Private Sub btn_PDF_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_PDF.ItemClick
        Export(ExportFormat.PDF)
    End Sub


    Private Sub btn_CSV_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_CSV.ItemClick
        Export(ExportFormat.CSV)
    End Sub

    Private Sub btn_HTML_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_HTML.ItemClick
        Export(ExportFormat.HTML)
    End Sub

    Private Sub btn_MHT_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_MHT.ItemClick
        Export(ExportFormat.MHTML)
    End Sub

    Private Sub btn_RTF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_RTF.ItemClick
        Export(ExportFormat.RTF)
    End Sub

    Private Sub btn_TXT_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_TXT.ItemClick
        Export(ExportFormat.TXT)
    End Sub

    Private Sub btn_Excel_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Excel.ItemClick
        Export(ExportFormat.XLSX)
    End Sub

    Private Sub btn_Excel_XLS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Excel_XLS.ItemClick
        Export(ExportFormat.XLS)
    End Sub

    Private Sub btn_Excel_XLSX_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Excel_XLSX.ItemClick
        Export(ExportFormat.XLSX)
    End Sub
End Class
Public Enum ExportFormat
    Word
    PDF
    CSV
    HTML
    MHTML
    RTF
    TXT
    XLSX
    XLS
End Enum