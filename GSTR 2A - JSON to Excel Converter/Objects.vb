Public Class JsonFile
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
Public Class GSTR2AEntry
    Property SupplierGSTIN As String
    Property SupplierName As String
    Property InvoiceNo As String
    Property InvoiceDate As Date
    Property TotalInvoiceValue As Double = 0
    Property TotalTaxableValue As Double = 0
    Property IntegratedTax As Double = 0
    Property CentralTax As Double = 0
    Property StateTax As Double = 0
    Property CESS As Double = 0
    Sub New(ByVal SupplierGSTIN As String, ByVal SupplierName As String, ByVal InvoiceNo As String, ByVal InvoiceDate As Date, ByVal TotalInvoiceValue As Double, ByVal TotalTaxableValue As Double, ByVal IntegratedTax As Double, ByVal CentralTax As Double, ByVal StateTax As Double, ByVal CESS As Double)
        Me.SupplierGSTIN = SupplierGSTIN
        Me.SupplierName = SupplierName
        Me.InvoiceNo = InvoiceNo
        Me.InvoiceDate = InvoiceDate
        Me.TotalInvoiceValue = TotalInvoiceValue
        Me.TotalTaxableValue = TotalTaxableValue
        Me.IntegratedTax = IntegratedTax
        Me.CentralTax = CentralTax
        Me.StateTax = StateTax
        Me.CESS = CESS
    End Sub
End Class