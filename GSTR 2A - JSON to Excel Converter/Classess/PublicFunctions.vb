Imports Ionic.Zip

Module PublicFunctions

    Function isJsonZIP(ByVal Path As String) As Boolean
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

End Module
