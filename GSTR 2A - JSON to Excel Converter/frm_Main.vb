Imports DevExpress.XtraGrid
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

        Dim GridControl As GridControl = New GridControl With {.MainView = GridView, .DataSource = Data, .Dock = DockStyle.Fill}

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

End Class