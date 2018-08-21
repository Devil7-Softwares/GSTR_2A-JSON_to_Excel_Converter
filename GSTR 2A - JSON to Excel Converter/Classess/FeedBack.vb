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

Imports System.Web.Script.Serialization

Namespace Classes
    Public Class FeedBack

        Property AppName As String
        Property UserName As String
        Property UserEMail As String
        Property Rating As Integer
        Property Message As String
        Property Version As String
        Property BuildDate As String

        Sub New()
            Me.AppName = ""
            Me.UserName = ""
            Me.UserEMail = ""
            Me.Rating = 5
            Me.Message = ""
            Me.Version = ""
            Me.BuildDate = ""
        End Sub

        Sub New(ByVal AppName As String, ByVal Version As String, ByVal BuildDate As String, ByVal UserName As String, ByVal UserEMail As String, ByVal Rating As Integer, ByVal Message As String)
            Me.AppName = AppName
            Me.UserName = UserName
            Me.UserEMail = UserEMail
            Me.Rating = Rating
            Me.Message = Message
            Me.BuildDate = BuildDate
            Me.Version = Version
        End Sub

        Function ToJSon() As String
            Return New JavaScriptSerializer().Serialize(Me)
        End Function

        Public Shared Function ParseJSon(JSON As String) As FeedBack
            Return New JavaScriptSerializer().Deserialize(Of FeedBack)(JSON)
        End Function

    End Class
End Namespace