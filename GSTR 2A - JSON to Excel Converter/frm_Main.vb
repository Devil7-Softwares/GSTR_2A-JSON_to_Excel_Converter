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

End Class