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

Imports Ionic.Zip
Imports Newtonsoft.Json.Linq
Imports Devil7.Automation.Converter.JSON2Excel.Classes.JSON

Namespace Classes
    Module PublicFunctions

        Public Function isNetworkConnected(Optional Host As String = "www.google.com") As Boolean
            If Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable Then
                Return My.Computer.Network.Ping(Host)
            End If
            Return False
        End Function

        Function RetrieveLinkerTimestamp() As DateTime
            Const PeHeaderOffset As Integer = 60
            Const LinkerTimestampOffset As Integer = 8
            Dim b(2047) As Byte
            Dim s As IO.Stream = Nothing
            Try
                s = New IO.FileStream(Application.ExecutablePath, IO.FileMode.Open, IO.FileAccess.Read)
                s.Read(b, 0, 2048)
            Finally
                If Not s Is Nothing Then s.Close()
            End Try
            Dim i As Integer = BitConverter.ToInt32(b, PeHeaderOffset)
            Dim SecondsSince1970 As Integer = BitConverter.ToInt32(b, i + LinkerTimestampOffset)
            Dim dt As New DateTime(1970, 1, 1, 0, 0, 0)
            dt = dt.AddSeconds(SecondsSince1970)
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours)
            Return dt
        End Function

        Public Sub SortTabs(ByVal sourceTabs As DevExpress.XtraTab.XtraTabPageCollection)
            Dim tabs As New List(Of DevExpress.XtraTab.XtraTabPage)()
            For Each page As DevExpress.XtraTab.XtraTabPage In sourceTabs
                tabs.Add(page)
            Next page
            tabs.Sort(New TabComparer)
            For i As Integer = 0 To tabs.Count - 1
                sourceTabs.Move(i, tabs(i))
            Next i
        End Sub

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

#Region "JSON"

        Function ReadJson(ByVal JSON_Data As String) As Returns
            On Error Resume Next
            Dim Returns As New Returns
            Dim json As JObject = JObject.Parse(JSON_Data)
            Returns.GSTIN = json.SelectToken("gstin")
            Returns.Period = json.SelectToken("fp")
            Returns.FileIndex = json.SelectToken("fileIndex")
            Returns.TotalFiles = json.SelectToken("totalFiles")
            Dim B2B_Entries As JArray = json.SelectToken("b2b").Value(Of JArray)()
            Dim B2BA_Entries As JArray = json.SelectToken("b2ba").Value(Of JArray)()
            For Each i As JToken In B2B_Entries
                Dim b2b As New B2BEntry
                b2b.cfs = i.SelectToken("cfs")
                b2b.Name = i.SelectToken("cname")
                b2b.GSTIN = i.SelectToken("ctin")
                ReadInvoices(i, b2b)
                Returns.B2BEntries.Add(b2b)
            Next
            For Each i As JToken In B2BA_Entries
                Dim b2ba As New B2BAEntry
                b2ba.cfs = i.SelectToken("cfs")
                b2ba.GSTIN = i.SelectToken("ctin")
                ReadInvoices(i, b2ba)
                Returns.B2BAEntries.Add(b2ba)
            Next
            Return Returns
        End Function

        Private Sub ReadInvoices(ByVal EntryToken As JToken, ByVal Entry As B2BAEntry)
            Dim Invoices As JArray = EntryToken.SelectToken("inv").Value(Of JArray)()
            For Each inv As JToken In Invoices
                Dim invoice As New Invoice
                invoice.Value = inv.SelectToken("val")
                invoice.InvoiceType = inv.SelectToken("inv_typ")
                invoice.State = inv.SelectToken("pos")
                invoice.InvoiceDate = Date.ParseExact(inv.SelectToken("idt"), {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "d-M-yyyy"}, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None)
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
                Entry.Invoices.Add(invoice)
            Next
        End Sub

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

#End Region

    End Module
End Namespace