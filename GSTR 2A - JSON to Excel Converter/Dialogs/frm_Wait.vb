Public Class frm_Wait
    Sub New(ByVal Location As Point)
        InitializeComponent()
        Me.progressPanel1.AutoHeight = True
        Me.Location = Location
    End Sub

    Public Overrides Sub SetCaption(ByVal caption As String)
        MyBase.SetCaption(caption)
        Me.progressPanel1.Caption = caption
    End Sub

    Public Overrides Sub SetDescription(ByVal description As String)
        MyBase.SetDescription(description)
        Me.progressPanel1.Description = description
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum WaitFormCommand
        SomeCommandId
    End Enum
End Class
