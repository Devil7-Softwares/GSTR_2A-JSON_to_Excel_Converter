Public Class JSONFile
    Dim filepath As String = ""
    Sub New(ByVal FilePath As String)
        Me.filepath = FilePath
    End Sub
    ReadOnly Property Filename As String
        Get
            Return IO.Path.GetFileName(filepath)
        End Get
    End Property
    ReadOnly Property Path As String
        Get
            Return filepath
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return Filename
    End Function
    Function isZip() As Boolean
        Return filepath.ToLower.EndsWith(".zip")
    End Function
End Class