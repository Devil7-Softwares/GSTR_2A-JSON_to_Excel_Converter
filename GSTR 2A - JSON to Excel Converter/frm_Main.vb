'=========================================================================='
'                                                                          '
'                    (C) Copyright 2018 Devil7 Softwares.                  '
'                                                                          '
' Licensed under the Apache License, Version 2.0 (the "License");          '
' you may not use this file except in compliance with the License.         '
' You may obtain a copy of the License at                                  '
'                                                                          '
'                http://www.apache.org/licenses/LICENSE-2.0                '
'                                                                          '
' Unless required by applicable law or agreed to in writing, software      '
' distributed under the License is distributed on an "AS IS" BASIS,        '
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. '
' See the License for the specific language governing permissions and      '
' limitations under the License.                                           '
'                                                                          '
' Contributors :                                                           '
'     Dineshkumar T                                                        '
'=========================================================================='

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
        For Each path As String In Files
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
        Try
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
                                Dim Period As String = "XX-XXXX"
                                Dim Data = ReadData(MS.ToArray, Period)
                                AddData(Data, Period)
                                Exit For
                            End If
                        Next
                    End Using
                Else
                    Dim Period As String = "XX-XXXX"
                    Dim Data = ReadData(My.Computer.FileSystem.ReadAllBytes(filename), Period)
                    AddData(Data, Period)
                End If
            Next
            If Not btn_Combine.Down Then
                SortTabs(tb_Sheets.TabPages)
            End If
            EnableControls()
            MsgBox("Successfully parsed given files.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
        Catch ex As Exception
            ShowError("Error on reading json files", ex)
        End Try
    End Sub
    Private Sub ShowError(ByVal Message As String, ByVal Exception As Exception)
        MsgBox(Message & vbNewLine & vbNewLine & vbNewLine & vbNewLine & _
               "Additional Information:" & vbNewLine & vbNewLine & _
               Exception.Message & Exception.StackTrace, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
    End Sub
    Private Function ReadData(ByVal Data As Byte(), ByRef Period As String) As List(Of GSTR2AEntry)
        Dim R As New List(Of GSTR2AEntry)
        Dim Returns = ReadJson(System.Text.Encoding.ASCII.GetString(Data))
        Period = Returns.Period
        For Each i As B2BEntry In Returns.B2BEntries
            For Each Invoice As Invoice In i.Invoices
                For Each item As Item In Invoice.Items
                    R.Add(New GSTR2AEntry(i.GSTIN, Invoice.InvoiceNumber, Invoice.InvoiceDate, CDbl(Invoice.Value), CDbl(item.ItemDetail.TaxableValue), CDbl(item.ItemDetail.IGST), CDbl(item.ItemDetail.CGST), CDbl(item.ItemDetail.SGST), CDbl(item.ItemDetail.CESS)))
                Next
            Next
        Next
        Return R
    End Function

    Private Sub AddData(ByVal Data As List(Of GSTR2AEntry), ByVal Period As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub()
                          AddData(Data, Period)
                      End Sub)
        Else
            If btn_Combine.Down Then
                If tb_Sheets.TabPages.Count = 0 Then
                    AddSheet("GSTR2A", Data)
                Else
                    AppendSheet(0, Data)
                End If
            Else
                AddSheet(If(Period.Length = 6, Period.Insert(2, "-"), Period), Data)
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
        Try
            Dim Ext = SetupSaveDialog(Format)
            If tb_Sheets.TabPages.Count = 1 Then
                If SaveFileDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim GC As GridControl = GetGridControl(0)
                    SaveFile(GC, Format, SaveFileDlg.FileName)
                    MsgBox("Data Export Completed.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
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
                        MsgBox("Data Export Completed.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
                    End If
                Else
                    ExportMultiSheetExcel(Format)
                End If
            Else
                MsgBox("No data to export. Pleas add json files & process before exporting", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End If
        Catch ex As Exception
            ShowError("Error on exporting data", ex)
        End Try
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
            MsgBox("Data Export Completed.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
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

    Private Sub btn_Clear_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Clear.ItemClick
        lst_Json.Items.Clear()
    End Sub

    Private Sub btn_About_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_About.ItemClick
        frm_About.ShowDialog()
    End Sub

    Private Sub frm_Main_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Skin = GetSkin.Name
        My.Settings.WindowSize = Me.Size
        My.Settings.WindowLocation = Me.Location
        My.Settings.WindowState = Me.WindowState
        My.Settings.Save()
    End Sub

    Private Sub frm_Main_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If My.Settings.FirstRun Then
            My.Settings.FirstRun = False
            My.Settings.Save()
            frm_About.ShowDialog()
        End If
    End Sub

    Private Sub frm_Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If My.Settings.Skin <> "" Then
            Try
                Theme.LookAndFeel.SkinName = My.Settings.Skin
            Catch ex As Exception

            End Try
        End If
        Me.Size = My.Settings.WindowSize
        Me.Location = My.Settings.WindowLocation
        Me.WindowState = My.Settings.WindowState
    End Sub

    Private Sub btn_Feedback_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Feedback.ItemClick
        Dim d As New frm_Feedback
        d.ShowDialog()
        Me.BringToFront()
        Me.Focus()
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