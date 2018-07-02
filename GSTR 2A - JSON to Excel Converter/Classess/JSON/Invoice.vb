Public Class Invoice
    Public Property Value As Double
    Public Property Items As New List(Of Item)
    Public Property InvoiceType As String
    Public Property State As String
    Public Property InvoiceDate As Date
    Public Property ReverseCharge As String
    Public Property InvoiceNumber As String
    Public Property GSTChecksum As String
End Class