Public Class XtraFormTemp
    Inherits DevExpress.XtraEditors.XtraForm
    Protected Overrides Function GetAllowSkin() As Boolean
        Return True
    End Function
    Sub New()
        Try
            If My.Settings.Skin <> "" Then
                Me.LookAndFeel.SkinName = My.Settings.Skin
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub XtraFormTemp_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        DevExpress.Skins.SkinManager.EnableFormSkins()
    End Sub
End Class