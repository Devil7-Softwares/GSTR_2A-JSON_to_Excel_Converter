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
'                                                                          '
'=========================================================================='

Imports System.Net.Http
Imports System.Net.Http.Headers

Namespace Classes
    Public Module RestAPI
        Dim BaseURL As String = "https://devil7appdata-1719.restdb.io/" ' Your RestDB or Any Other Parse Server URL Here...
        Dim CollectionName As String = "feedbacks" ' Table/Collection Name

        Function PostFeedback(ByVal FeedBack As Classes.FeedBack) As Boolean
            If isNetworkConnected() Then
                Try
                    Dim client As HttpClient = New HttpClient()
                    client.BaseAddress = New Uri(BaseURL)
                    client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
                    client.DefaultRequestHeaders.CacheControl = New CacheControlHeaderValue With {.NoCache = True}
                    client.DefaultRequestHeaders.Add("x-apikey", Keys.GetRestDBAPIKey) '"Keys" Class is where i hold my API keys. Write your own one...
                    Dim response = client.PostAsync("rest/" & CollectionName, New StringContent(FeedBack.ToJSon, System.Text.Encoding.UTF8, "application/json")).Result
                    If response.IsSuccessStatusCode Then
                        MsgBox("Feedback Successfully Submitted.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
                        Return True
                    Else
                        MsgBox("Error Code" & response.StatusCode & " : Message - " + response.ReasonPhrase, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                End Try
            Else
                MsgBox("Unable to connect to network. Check your internet connection...!")
            End If
            Return False
        End Function

    End Module
End Namespace