Public Class B2BEntry
    Public Property GSTIN As String
    Public Property cfs As String
    Public Property Name As String
    Public Property Invoices As New List(Of Invoice)
End Class