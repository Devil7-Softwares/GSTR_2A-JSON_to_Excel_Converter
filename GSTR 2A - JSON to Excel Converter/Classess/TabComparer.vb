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
