Imports System.Text
Imports System.Xml.Serialization
Imports System.Net
Imports HtmlAgilityPack

Public Class TaxPayersDatabase
    Dim Data As String = ""
    Dim Items As List(Of TaxPayer) = New List(Of TaxPayer)
    Sub New(ByVal Data As String)
        Me.Data = Data
        Load()
    End Sub
    ReadOnly Property TaxPayers As List(Of TaxPayer)
        Get
            Return Items
        End Get
    End Property

    Public Overloads Function AddTaxpayer(ByVal TaxPayer As TaxPayer) As Boolean
        If TaxPayer Is Nothing Then
            Return False
        Else
            Items.Add(TaxPayer)
            Save()
            Return True
        End If
    End Function
    Public Overloads Function AddTaxpayer(ByVal GSTIN As String) As Boolean
        Dim TaxPayer As TaxPayer = SearchTaxpayer(GSTIN)
        If TaxPayer Is Nothing Then
            Return False
        Else
            Items.Add(TaxPayer)
            Save()
            Return True
        End If
    End Function

    Public Overloads Function RemoveTaxpayer(ByVal TaxPayer As TaxPayer) As Boolean
        Dim r = Items.Remove(TaxPayer)
        Save()
        Return r
    End Function

    Public Overloads Function RemoveTaxpayer(ByVal GSTIN As String) As Boolean
        Dim TaxPayer As TaxPayer = FindTaxPayerByGSTIN(GSTIN)
        If TaxPayer Is Nothing Then
            Return False
        Else
            Dim r = Items.Remove(TaxPayer)
            Save()
            Return r
        End If
    End Function
    Public Function SearchTaxpayer(ByVal GSTIN As String) As TaxPayer
        Dim GSTIN_ As String = ""
        Dim TaxPayerName_ As String = ""
        Dim StateJurisdiction_ As String = ""
        Dim CentreJurisdiction_ As String = ""
        Dim Date_of_Registration_ As Date = Nothing
        Dim Constitution_of_Business_ As String = ""
        Dim TaxpayerType_ As String = ""
        Dim GSTN_status As String = ""
        Dim Cancelled_ As Boolean = False
        Dim CancellationDate_ As Date = Nothing

        Dim HTML As String = New WebClient().DownloadString(String.Format("https://www.mastersindia.co/gst-number-search-and-gstin-verification/?keyword={0}", GSTIN))
        Dim HTML_DOM As New HtmlAgilityPack.HtmlDocument
        HTML_DOM.LoadHtml(HTML)

        If HTML_DOM.ParsedText.Contains("The GSTIN passed in the request is invalid.") Then
            Return Nothing
        End If

        Dim Index As Integer = 0
        For Each i As HtmlAgilityPack.HtmlNode In HTML_DOM.DocumentNode.ChildNodes.Descendants("tr")
            If i.InnerText.Contains(GSTIN) Then
                For Each c As HtmlAgilityPack.HtmlNode In i.ChildNodes
                    If c.Name = "td" Then
                        Select Case Index
                            Case 0
                                GSTIN_ = c.InnerText
                            Case 1
                                TaxPayerName_ = c.InnerText
                            Case 2
                                StateJurisdiction_ = c.InnerText
                            Case 3
                                CentreJurisdiction_ = c.InnerText
                            Case 4
                                Date_of_Registration_ = Date.Parse(c.InnerText)
                            Case 5
                                Constitution_of_Business_ = c.InnerText
                            Case 6
                                TaxpayerType_ = c.InnerText
                            Case 7
                                GSTN_status = c.InnerText
                            Case 8
                                If c.InnerText.Trim = "" Then
                                    Cancelled_ = False
                                    CancellationDate_ = Nothing
                                End If
                        End Select
                        Index += 1
                    End If
                Next
            End If
        Next
        Return New TaxPayer(GSTIN_, TaxPayerName_, StateJurisdiction_, CentreJurisdiction_, Date_of_Registration_, Constitution_of_Business_, TaxpayerType_, GSTN_status, Cancelled_, CancellationDate_)
    End Function
    Public Function FindTaxPayerByGSTIN(ByVal GSTIN As String) As TaxPayer
        Dim r As TaxPayer = Nothing
        For Each i As TaxPayer In TaxPayers
            If i.GSTIN.ToLower = GSTIN.ToLower Then
                r = i
                Exit For
            End If
        Next
        Return r
    End Function
    Public Function ContainsTaxpayer(ByVal GSTIN As String) As Boolean
        Dim r As Boolean = False
        For Each i As TaxPayer In TaxPayers
            If i.GSTIN.ToLower = GSTIN.ToLower Then
                r = True
                Exit For
            End If
        Next
        Return r
    End Function
    Private Sub Load()
        Try
            If Data.Trim <> "" AndAlso My.Computer.FileSystem.FileExists(Data) Then
                Dim f As Runtime.Serialization.Formatters.Binary.BinaryFormatter
                Dim s As IO.Stream
                f = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                s = New IO.FileStream(Data, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
                Items = DirectCast(f.Deserialize(s), Object)
                s.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Save()
        If Data.Trim <> "" Then
            Dim F As Runtime.Serialization.Formatters.Binary.BinaryFormatter
            Dim s As IO.Stream
            F = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            s = New IO.FileStream(Data, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)
            F.Serialize(s, Items)
            s.Close()
        End If
    End Sub
End Class
<Serializable()> _
Public Class TaxPayer
    Dim GSTIN_ As String
    Dim TaxPayerName_ As String
    Dim StateJurisdiction_ As String
    Dim CentreJurisdiction_ As String
    Dim Date_of_Registration_ As Date
    Dim Constitution_of_Business_ As String
    Dim TaxpayerType_ As String
    Dim GSTN_status As String
    Dim Cancelled_ As Boolean = False
    Dim CancellationDate_ As Date
    Sub New()
    End Sub
    Sub New(ByVal GSTIN_ As String, ByVal TaxPayerName_ As String, ByVal StateJurisdiction_ As String, ByVal CentreJurisdiction_ As String, ByVal Date_of_Registration_ As Date, ByVal Constitution_of_Business_ As String, ByVal TaxpayerType_ As String, ByVal GSTN_status As String, Optional ByVal Cancelled_ As Boolean = False, Optional ByVal CancellationDate_ As Date = Nothing)
        Me.GSTIN_ = GSTIN_
        Me.TaxPayerName_ = TaxPayerName_
        Me.StateJurisdiction_ = StateJurisdiction_
        Me.CentreJurisdiction_ = CentreJurisdiction_
        Me.Date_of_Registration_ = Date_of_Registration_
        Me.Constitution_of_Business_ = Constitution_of_Business_
        Me.TaxpayerType_ = TaxpayerType_
        Me.GSTN_status = GSTN_status
        Me.Cancelled_ = Cancelled_
        Me.CancellationDate_ = CancellationDate_
    End Sub
    Property GSTIN As String
        Get
            Return GSTIN_
        End Get
        Set(ByVal value As String)
            GSTIN_ = value
        End Set
    End Property
    Property TaxPayerName As String
        Get
            Return TaxPayerName_
        End Get
        Set(ByVal value As String)
            TaxPayerName_ = value
        End Set
    End Property
    Property StateJurisdiction As String
        Get
            Return StateJurisdiction_
        End Get
        Set(ByVal value As String)
            StateJurisdiction_ = value
        End Set
    End Property
    Property CentreJurisdiction As String
        Get
            Return CentreJurisdiction_
        End Get
        Set(ByVal value As String)
            CentreJurisdiction_ = value
        End Set
    End Property
    Property DateOfRegistration As Date
        Get
            Return Date_of_Registration_
        End Get
        Set(ByVal value As Date)
            Date_of_Registration_ = value
        End Set
    End Property
    Property ConstitutionOfBusiness As String
        Get
            Return Constitution_of_Business_
        End Get
        Set(ByVal value As String)
            Constitution_of_Business_ = value
        End Set
    End Property
    Property TaxpayerType As String
        Get
            Return TaxpayerType_
        End Get
        Set(ByVal value As String)
            TaxpayerType_ = value
        End Set
    End Property
    Property Status As String
        Get
            Return GSTN_status
        End Get
        Set(ByVal value As String)
            GSTN_status = value
        End Set
    End Property
    Property Cancelled As Boolean
        Get
            Return Cancelled_
        End Get
        Set(ByVal value As Boolean)
            Cancelled_ = value
        End Set
    End Property
    Property CancellationDate As String
        Get
            Return CancellationDate_
        End Get
        Set(ByVal value As String)
            CancellationDate_ = value
        End Set
    End Property
End Class