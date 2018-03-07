Imports Ionic.Zip

Public Class frm_Main

    Private Sub lst_Json_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lst_Json.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path As String In files
            If path.ToLower.EndsWith(".json") Then
                lst_Json.Items.Add(New JsonFile(path))
            ElseIf path.ToLower.EndsWith(".zip") Then
                If isJsonZIP(path) Then
                    lst_Json.Items.Add(New JsonFile(path))
                End If
            End If
        Next
    End Sub
    Private Function isJsonZIP(ByVal Path As String) As Boolean
        Using zip = ZipFile.Read(Path)
            Dim totalEntries As Integer = zip.Entries.Count
            For Each e As ZipEntry In zip.Entries
                If e.FileName.ToLower.EndsWith(".json") Then
                    Return True
                    Exit For
                End If
            Next
        End Using
        Return False
    End Function
    Private Sub lst_Json_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lst_Json.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub lst_Json_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_Json.SelectedIndexChanged

    End Sub

    Private Sub btn_ReadJson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ReadJson.Click
        Dim Rand As New Random
        Dim DS As New List(Of GSTR2AEntry)
        Dim files2read As New List(Of String)
        For Each json2read As JsonFile In lst_Json.Items
            Dim filename As String = json2read.Path
            If json2read.isZip Then
                Dim tmpdir As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp, "GSTRJSON_" & rand.Next(1000000, 9999999))
                My.Computer.FileSystem.CreateDirectory(tmpdir)
                Using zip = ZipFile.Read(filename)
                    Dim totalEntries As Integer = zip.Entries.Count
                    For Each ent As ZipEntry In zip.Entries
                        If ent.FileName.ToLower.EndsWith(".json") Then
                            ent.Extract(tmpdir)
                            Exit For
                        End If
                    Next
                End Using
                For Each i As String In My.Computer.FileSystem.GetFiles(tmpdir, FileIO.SearchOption.SearchTopLevelOnly, "*.json")
                    files2read.Add(i)
                Next
            Else
                files2read.Add(filename)
            End If
        Next
        For Each f As String In files2read
            Dim Returns = JSON.ReadJson(My.Computer.FileSystem.ReadAllText(f))
            For Each i As B2BEntry In Returns.B2BEntries
                For Each Invoice As Invoice In i.Invoices
                    For Each item As Item In Invoice.Items
                        DS.Add(New GSTR2AEntry(i.GSTIN, "", Invoice.InvoiceNumber, Invoice.InvoiceDate, CDbl(Invoice.Value), CDbl(item.ItemDetail.TaxableValue), CDbl(item.ItemDetail.IGST), CDbl(item.ItemDetail.CGST), CDbl(item.ItemDetail.SGST), CDbl(item.ItemDetail.CESS)))
                    Next
                Next
            Next
        Next
        grd_Json.DataSource = DS
        grd_Json.RefreshDataSource()
    End Sub

    Private Sub btn_Export2Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Export2Excel.Click
        If saveExcel.ShowDialog = Windows.Forms.DialogResult.OK Then
            grd_Json.ExportToXlsx(saveExcel.FileName)
        End If
    End Sub

End Class
