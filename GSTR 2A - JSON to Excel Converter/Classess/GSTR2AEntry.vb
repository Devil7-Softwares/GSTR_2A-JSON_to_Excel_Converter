'=========================================================================='
'                                                                          '
'                    (C) Copyright 2018 Devil7 Softwares.                  '
'                                                                          '
' Licensed under the Apache License, Version 2.0 (the "License");          '
' you may not use this file except in compliance with the License.         '
' You may obtain a copy of the License at                                  '
'                                                                          '
'                http://www.apache.org/licenses/LICENSE-2.0                '
'                                                                          '
' Unless required by applicable law or agreed to in writing, software      '
' distributed under the License is distributed on an "AS IS" BASIS,        '
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. '
' See the License for the specific language governing permissions and      '
' limitations under the License.                                           '
'                                                                          '
' Contributors :                                                           '
'     Dineshkumar T                                                        '
'=========================================================================='

Public Class GSTR2AEntry
    Property SupplierGSTIN As String
    Property InvoiceNo As String
    Property InvoiceDate As Date
    Property TotalInvoiceValue As Double = 0
    Property TotalTaxableValue As Double = 0
    Property IntegratedTax As Double = 0
    Property CentralTax As Double = 0
    Property StateTax As Double = 0
    Property CESS As Double = 0
    Sub New(ByVal SupplierGSTIN As String, ByVal InvoiceNo As String, ByVal InvoiceDate As Date, ByVal TotalInvoiceValue As Double, ByVal TotalTaxableValue As Double, ByVal IntegratedTax As Double, ByVal CentralTax As Double, ByVal StateTax As Double, ByVal CESS As Double)
        Me.SupplierGSTIN = SupplierGSTIN
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