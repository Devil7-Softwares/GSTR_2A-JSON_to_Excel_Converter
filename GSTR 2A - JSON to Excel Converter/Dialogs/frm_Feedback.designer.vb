Namespace Dialogs
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frm_Feedback
        Inherits XtraFormTemp

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Feedback))
            Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
            Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
            Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
            Me.txt_Name = New DevExpress.XtraEditors.TextEdit()
            Me.txt_Email = New DevExpress.XtraEditors.TextEdit()
            Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
            Me.txt_Message = New DevExpress.XtraEditors.MemoEdit()
            Me.txt_Rating = New DevExpress.XtraEditors.RatingControl()
            Me.btn_Send = New DevExpress.XtraEditors.SimpleButton()
            Me.FeedbackSender = New System.ComponentModel.BackgroundWorker()
            CType(Me.txt_Name.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txt_Email.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txt_Message.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txt_Rating.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'LabelControl1
            '
            Me.LabelControl1.Location = New System.Drawing.Point(77, 15)
            Me.LabelControl1.Name = "LabelControl1"
            Me.LabelControl1.Size = New System.Drawing.Size(53, 13)
            Me.LabelControl1.TabIndex = 0
            Me.LabelControl1.Text = "Full Name :"
            '
            'LabelControl2
            '
            Me.LabelControl2.Location = New System.Drawing.Point(99, 41)
            Me.LabelControl2.Name = "LabelControl2"
            Me.LabelControl2.Size = New System.Drawing.Size(31, 13)
            Me.LabelControl2.TabIndex = 1
            Me.LabelControl2.Text = "Email :"
            '
            'LabelControl3
            '
            Me.LabelControl3.Appearance.Options.UseTextOptions = True
            Me.LabelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.LabelControl3.Location = New System.Drawing.Point(12, 143)
            Me.LabelControl3.Name = "LabelControl3"
            Me.LabelControl3.Size = New System.Drawing.Size(118, 39)
            Me.LabelControl3.TabIndex = 2
            Me.LabelControl3.Text = "How much stars" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "would you like to " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "give for this application :"
            '
            'txt_Name
            '
            Me.txt_Name.EnterMoveNextControl = True
            Me.txt_Name.Location = New System.Drawing.Point(136, 12)
            Me.txt_Name.Name = "txt_Name"
            Me.txt_Name.Size = New System.Drawing.Size(381, 20)
            Me.txt_Name.TabIndex = 0
            '
            'txt_Email
            '
            Me.txt_Email.EnterMoveNextControl = True
            Me.txt_Email.Location = New System.Drawing.Point(136, 38)
            Me.txt_Email.Name = "txt_Email"
            Me.txt_Email.Size = New System.Drawing.Size(381, 20)
            Me.txt_Email.TabIndex = 1
            '
            'LabelControl4
            '
            Me.LabelControl4.Location = New System.Drawing.Point(56, 66)
            Me.LabelControl4.Name = "LabelControl4"
            Me.LabelControl4.Size = New System.Drawing.Size(74, 13)
            Me.LabelControl4.TabIndex = 5
            Me.LabelControl4.Text = "Your Message :"
            '
            'txt_Message
            '
            Me.txt_Message.EnterMoveNextControl = True
            Me.txt_Message.Location = New System.Drawing.Point(136, 64)
            Me.txt_Message.Name = "txt_Message"
            Me.txt_Message.Size = New System.Drawing.Size(381, 96)
            Me.txt_Message.TabIndex = 2
            '
            'txt_Rating
            '
            Me.txt_Rating.EditValue = New Decimal(New Integer() {5, 0, 0, 0})
            Me.txt_Rating.EnterMoveNextControl = True
            Me.txt_Rating.Location = New System.Drawing.Point(136, 166)
            Me.txt_Rating.Name = "txt_Rating"
            Me.txt_Rating.Rating = New Decimal(New Integer() {5, 0, 0, 0})
            Me.txt_Rating.Size = New System.Drawing.Size(87, 16)
            Me.txt_Rating.TabIndex = 3
            '
            'btn_Send
            '
            Me.btn_Send.Location = New System.Drawing.Point(433, 166)
            Me.btn_Send.Name = "btn_Send"
            Me.btn_Send.Size = New System.Drawing.Size(84, 37)
            Me.btn_Send.TabIndex = 4
            Me.btn_Send.Text = "Send Feedback"
            '
            'FeedbackSender
            '
            '
            'frm_Feedback
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(529, 215)
            Me.Controls.Add(Me.btn_Send)
            Me.Controls.Add(Me.txt_Rating)
            Me.Controls.Add(Me.txt_Message)
            Me.Controls.Add(Me.LabelControl4)
            Me.Controls.Add(Me.txt_Email)
            Me.Controls.Add(Me.txt_Name)
            Me.Controls.Add(Me.LabelControl3)
            Me.Controls.Add(Me.LabelControl2)
            Me.Controls.Add(Me.LabelControl1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frm_Feedback"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Feedback"
            CType(Me.txt_Name.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txt_Email.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txt_Message.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txt_Rating.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txt_Name As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txt_Email As DevExpress.XtraEditors.TextEdit
        Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txt_Message As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents txt_Rating As DevExpress.XtraEditors.RatingControl
        Friend WithEvents btn_Send As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents FeedbackSender As System.ComponentModel.BackgroundWorker
    End Class
End Namespace