Imports Ionic.Zip

Public Class frm_Main
    Dim Data As String = IO.Path.Combine(Application.StartupPath, "TaxPayers.dat")
    Dim TaxPayersDB As New TaxPayersDatabase(Data)

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

    Private Sub btn_ReadJson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ReadJson.Click
        Reader.RunWorkerAsync()
    End Sub

    Function GetTaxpayerName(ByVal GSTIN As String) As String
        Dim r As String = ""
        Dim TP As TaxPayer = TaxPayersDB.FindTaxPayerByGSTIN(GSTIN)
        If TP Is Nothing Then
            TP = TaxPayersDB.SearchTaxpayer(GSTIN)
            If TP IsNot Nothing Then
                r = TP.TaxPayerName
                TaxPayersDB.AddTaxpayer(TP)
            End If
        Else
            r = TP.TaxPayerName
        End If
        Return r
    End Function

    Private Sub btn_Export2Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Export2Excel.Click
        If saveExcel.ShowDialog = Windows.Forms.DialogResult.OK Then
            grd_Json.ExportToXlsx(saveExcel.FileName)
        End If
    End Sub

    Private Sub frm_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Reader_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Reader.DoWork
        WaitFormManager.ShowWaitForm()
        Dim Rand As New Random
        Dim DS As New List(Of GSTR2AEntry)
        Dim files2read As New List(Of String)
        For Each json2read As JsonFile In lst_Json.Items
            Dim filename As String = json2read.Path
            If json2read.isZip Then
                Dim tmpdir As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp, "GSTRJSON_" & Rand.Next(1000000, 9999999))
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
                        DS.Add(New GSTR2AEntry(i.GSTIN, GetTaxpayerName(i.GSTIN), Invoice.InvoiceNumber, Invoice.InvoiceDate, CDbl(Invoice.Value), CDbl(item.ItemDetail.TaxableValue), CDbl(item.ItemDetail.IGST), CDbl(item.ItemDetail.CGST), CDbl(item.ItemDetail.SGST), CDbl(item.ItemDetail.CESS)))
                        grd_Json.DataSource = DS
                        grd_Json.RefreshDataSource()
                    Next
                Next
            Next
        Next
        WaitFormManager.CloseWaitForm()
    End Sub

    Private Sub Reader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Reader.RunWorkerCompleted

    End Sub
End Class
