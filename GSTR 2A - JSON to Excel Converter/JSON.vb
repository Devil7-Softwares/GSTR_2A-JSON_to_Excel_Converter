Imports Newtonsoft.Json.Linq
Module JSON
    Function ReadJson(ByVal JSON_Data As String) As Returns
        Dim Returns As New Returns
        Dim json As JObject = JObject.Parse(JSON_Data)
        Returns.GSTIN = json.SelectToken("gstin")
        Returns.GSTIN = json.SelectToken("fp")
        Dim B2B_Entries As JArray = json.SelectToken("b2b").Value(Of JArray)()
        For Each i As JToken In B2B_Entries
            Dim b2b As New B2BEntry
            b2b.cfs = i.SelectToken("cfs")
            b2b.Name = i.SelectToken("cname")
            b2b.GSTIN = i.SelectToken("ctin")
            Dim Invoices As JArray = i.SelectToken("inv").Value(Of JArray)()
            For Each inv As JToken In Invoices
                Dim invoice As New Invoice
                invoice.Value = inv.SelectToken("val")
                invoice.InvoiceType = inv.SelectToken("inv_typ")
                invoice.State = inv.SelectToken("pos")
                invoice.InvoiceDate = Date.Parse(inv.SelectToken("idt"))
                invoice.ReverseCharge = inv.SelectToken("rchrg")
                invoice.InvoiceNumber = inv.SelectToken("inum")
                invoice.GSTChecksum = inv.SelectToken("chksum")
                Dim Items As JArray = inv.SelectToken("itms").Value(Of JArray)()
                For Each Itm As JToken In Items
                    Dim item As New Item
                    item.num = Itm.SelectToken("num")
                    item.ItemDetail = New ItemDetails
                    item.ItemDetail.TaxableValue = GetSubTokenValue(Itm.SelectToken("itm_det"), "txval", 0)
                    item.ItemDetail.SGST = GetSubTokenValue(Itm.SelectToken("itm_det"), "samt", 0)
                    item.ItemDetail.CGST = GetSubTokenValue(Itm.SelectToken("itm_det"), "camt", 0)
                    item.ItemDetail.IGST = GetSubTokenValue(Itm.SelectToken("itm_det"), "iamt", 0)
                    item.ItemDetail.CESS = GetSubTokenValue(Itm.SelectToken("itm_det"), "csamt", 0)
                    invoice.Items.Add(item)
                Next
                b2b.Invoices.Add(invoice)
            Next
            Returns.B2BEntries.Add(b2b)
        Next
        Return Returns
    End Function
    Private Function GetSubTokenValue(ByVal Token As JToken, ByVal SubTokenName As String, ByVal NullValue As Object) As Object
        Dim r As Object = Nothing
        Try
            r = Token.SelectToken(SubTokenName)
        Catch ex As Exception

        End Try
        If r Is Nothing Then
            Return NullValue
        Else
            Return r
        End If
    End Function
    Public Class ItemDetails
        Public Property SGST As Double = 0.0
        Public Property CESS As Double = 0.0
        Public Property Rate As Integer = 0
        Public Property TaxableValue As Double = 0.0
        Public Property CGST As Double = 0.0
        Public Property IGST As Double = 0.0
    End Class
    Public Class Item
        Public Property num As Integer
        Public Property ItemDetail As New ItemDetails
    End Class
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
    Public Class B2BEntry
        Public Property GSTIN As String
        Public Property cfs As String
        Public Property Name As String
        Public Property Invoices As New List(Of Invoice)
    End Class
    Public Class Returns
        Public Property GSTIN As String
        Public Property FingerPrint As String
        Public Property B2BEntries As New List(Of B2BEntry)
    End Class
End Module
