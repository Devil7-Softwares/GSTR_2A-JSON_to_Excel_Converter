<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ExcelHelper
    Inherits XtraFormTemp

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ExcelHelper))
        Me.grp_ExcelFiles = New DevExpress.XtraEditors.GroupControl()
        Me.ProgressPanel_Loading = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.lst_Excel = New System.Windows.Forms.ListBox()
        Me.grp_Options = New DevExpress.XtraEditors.GroupControl()
        Me.lbl_Folder2Save = New DevExpress.XtraEditors.LabelControl()
        Me.txt_Folder2Save = New DevExpress.XtraEditors.ButtonEdit()
        Me.option_SaveMode = New DevExpress.XtraEditors.RadioGroup()
        Me.lbl_SafeMode = New DevExpress.XtraEditors.LabelControl()
        Me.btn_RemoveRows = New DevExpress.XtraEditors.SimpleButton()
        Me.browse_Folder = New System.Windows.Forms.FolderBrowserDialog()
        Me.Worker_RemoveRows = New System.ComponentModel.BackgroundWorker()
        CType(Me.grp_ExcelFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_ExcelFiles.SuspendLayout()
        CType(Me.grp_Options, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Options.SuspendLayout()
        CType(Me.txt_Folder2Save.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.option_SaveMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp_ExcelFiles
        '
        Me.grp_ExcelFiles.Controls.Add(Me.ProgressPanel_Loading)
        Me.grp_ExcelFiles.Controls.Add(Me.lst_Excel)
        Me.grp_ExcelFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grp_ExcelFiles.Location = New System.Drawing.Point(0, 0)
        Me.grp_ExcelFiles.Name = "grp_ExcelFiles"
        Me.grp_ExcelFiles.Size = New System.Drawing.Size(554, 361)
        Me.grp_ExcelFiles.TabIndex = 0
        Me.grp_ExcelFiles.Text = "Drag && Drop Excel Files Here"
        '
        'ProgressPanel_Loading
        '
        Me.ProgressPanel_Loading.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel_Loading.Appearance.Options.UseBackColor = True
        Me.ProgressPanel_Loading.BarAnimationElementThickness = 2
        Me.ProgressPanel_Loading.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.ProgressPanel_Loading.Description = "Loading..."
        Me.ProgressPanel_Loading.Location = New System.Drawing.Point(102, 163)
        Me.ProgressPanel_Loading.Name = "ProgressPanel_Loading"
        Me.ProgressPanel_Loading.Size = New System.Drawing.Size(340, 76)
        Me.ProgressPanel_Loading.TabIndex = 3
        Me.ProgressPanel_Loading.Visible = False
        '
        'lst_Excel
        '
        Me.lst_Excel.AllowDrop = True
        Me.lst_Excel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lst_Excel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst_Excel.FormattingEnabled = True
        Me.lst_Excel.Location = New System.Drawing.Point(2, 20)
        Me.lst_Excel.Name = "lst_Excel"
        Me.lst_Excel.Size = New System.Drawing.Size(550, 339)
        Me.lst_Excel.TabIndex = 2
        '
        'grp_Options
        '
        Me.grp_Options.Controls.Add(Me.lbl_Folder2Save)
        Me.grp_Options.Controls.Add(Me.txt_Folder2Save)
        Me.grp_Options.Controls.Add(Me.option_SaveMode)
        Me.grp_Options.Controls.Add(Me.lbl_SafeMode)
        Me.grp_Options.Controls.Add(Me.btn_RemoveRows)
        Me.grp_Options.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grp_Options.Location = New System.Drawing.Point(0, 361)
        Me.grp_Options.Name = "grp_Options"
        Me.grp_Options.Size = New System.Drawing.Size(554, 89)
        Me.grp_Options.TabIndex = 1
        Me.grp_Options.Text = "Options"
        '
        'lbl_Folder2Save
        '
        Me.lbl_Folder2Save.Location = New System.Drawing.Point(225, 47)
        Me.lbl_Folder2Save.Name = "lbl_Folder2Save"
        Me.lbl_Folder2Save.Size = New System.Drawing.Size(77, 13)
        Me.lbl_Folder2Save.TabIndex = 5
        Me.lbl_Folder2Save.Text = "Folder to Save :"
        Me.lbl_Folder2Save.Visible = False
        '
        'txt_Folder2Save
        '
        Me.txt_Folder2Save.Location = New System.Drawing.Point(308, 44)
        Me.txt_Folder2Save.Name = "txt_Folder2Save"
        Me.txt_Folder2Save.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txt_Folder2Save.Properties.ReadOnly = True
        Me.txt_Folder2Save.Size = New System.Drawing.Size(113, 20)
        Me.txt_Folder2Save.TabIndex = 4
        Me.txt_Folder2Save.Visible = False
        '
        'option_SaveMode
        '
        Me.option_SaveMode.EditValue = 0
        Me.option_SaveMode.Location = New System.Drawing.Point(78, 23)
        Me.option_SaveMode.Name = "option_SaveMode"
        Me.option_SaveMode.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Overwrite Original File"), New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Rename New File"), New DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Save to Specific Folder")})
        Me.option_SaveMode.Size = New System.Drawing.Size(141, 61)
        Me.option_SaveMode.TabIndex = 2
        '
        'lbl_SafeMode
        '
        Me.lbl_SafeMode.Location = New System.Drawing.Point(12, 47)
        Me.lbl_SafeMode.Name = "lbl_SafeMode"
        Me.lbl_SafeMode.Size = New System.Drawing.Size(60, 13)
        Me.lbl_SafeMode.TabIndex = 1
        Me.lbl_SafeMode.Text = "Save Mode :"
        '
        'btn_RemoveRows
        '
        Me.btn_RemoveRows.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_RemoveRows.ImageOptions.SvgImage = CType(resources.GetObject("btn_RemoveRows.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btn_RemoveRows.Location = New System.Drawing.Point(427, 20)
        Me.btn_RemoveRows.Name = "btn_RemoveRows"
        Me.btn_RemoveRows.Size = New System.Drawing.Size(125, 67)
        Me.btn_RemoveRows.TabIndex = 0
        Me.btn_RemoveRows.Text = "Remove" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Unwanted Rows"
        '
        'Worker_RemoveRows
        '
        '
        'frm_ExcelHelper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 450)
        Me.Controls.Add(Me.grp_ExcelFiles)
        Me.Controls.Add(Me.grp_Options)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_ExcelHelper"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "GSTR 2A - Excel Helper"
        CType(Me.grp_ExcelFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_ExcelFiles.ResumeLayout(False)
        CType(Me.grp_Options, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Options.ResumeLayout(False)
        Me.grp_Options.PerformLayout()
        CType(Me.txt_Folder2Save.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.option_SaveMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grp_ExcelFiles As DevExpress.XtraEditors.GroupControl
    Friend WithEvents grp_Options As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ProgressPanel_Loading As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents lst_Excel As ListBox
    Friend WithEvents btn_RemoveRows As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txt_Folder2Save As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents option_SaveMode As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents lbl_SafeMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbl_Folder2Save As DevExpress.XtraEditors.LabelControl
    Friend WithEvents browse_Folder As FolderBrowserDialog
    Friend WithEvents Worker_RemoveRows As System.ComponentModel.BackgroundWorker
End Class
