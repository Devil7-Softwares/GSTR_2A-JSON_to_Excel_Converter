Imports DevExpress.XtraTab

Public Class TabComparer : Implements IComparer(Of DevExpress.XtraTab.XtraTabPage)

    Public Function Compare(Page1 As XtraTabPage, Page2 As XtraTabPage) As Integer Implements IComparer(Of XtraTabPage).Compare
        Dim x As String = Page1.Text
        Dim y As String = Page2.Text
        If x.Length = 6 And y.Length = 6 Then
            Dim Date1 As Date = New Date(CInt(x.Substring(2, 4)), CInt(x.Substring(0, 2)), 1)
            Dim Date2 As Date = New Date(CInt(y.Substring(2, 4)), CInt(y.Substring(0, 2)), 1)
            Return Date1.CompareTo(Date2)
        Else
            Return x.CompareTo(y)
        End If
    End Function

End Class
