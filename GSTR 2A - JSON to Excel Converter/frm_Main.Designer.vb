<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.WaitFormManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.D7Automation.frm_Wait), True, True)
        Me.grp_Controls = New DevExpress.XtraEditors.GroupControl()
        Me.btn_Export2Excel = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_ReadJson = New DevExpress.XtraEditors.SimpleButton()
        Me.grp_JsonFiles = New DevExpress.XtraEditors.GroupControl()
        Me.lst_Json = New System.Windows.Forms.ListBox()
        Me.saveExcel = New System.Windows.Forms.SaveFileDialog()
        Me.grd_Json = New DevExpress.XtraGrid.GridControl()
        Me.gv_Json = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Reader = New System.ComponentModel.BackgroundWorker()
        CType(Me.grp_Controls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Controls.SuspendLayout()
        CType(Me.grp_JsonFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_JsonFiles.SuspendLayout()
        CType(Me.grd_Json, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv_Json, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WaitFormManager
        '
        Me.WaitFormManager.ClosingDelay = 500
        '
        'grp_Controls
        '
        Me.grp_Controls.Controls.Add(Me.btn_Export2Excel)
        Me.grp_Controls.Controls.Add(Me.btn_ReadJson)
        Me.grp_Controls.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grp_Controls.Location = New System.Drawing.Point(0, 284)
        Me.grp_Controls.Name = "grp_Controls"
        Me.grp_Controls.Size = New System.Drawing.Size(659, 63)
        Me.grp_Controls.TabIndex = 0
        Me.grp_Controls.Text = "Controls"
        '
        'btn_Export2Excel
        '
        Me.btn_Export2Excel.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Export2Excel.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.Excel
        Me.btn_Export2Excel.Location = New System.Drawing.Point(133, 20)
        Me.btn_Export2Excel.Name = "btn_Export2Excel"
        Me.btn_Export2Excel.Size = New System.Drawing.Size(122, 41)
        Me.btn_Export2Excel.TabIndex = 1
        Me.btn_Export2Excel.Text = "Export to Excel"
        '
        'btn_ReadJson
        '
        Me.btn_ReadJson.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_ReadJson.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.JSON
        Me.btn_ReadJson.Location = New System.Drawing.Point(2, 20)
        Me.btn_ReadJson.Name = "btn_ReadJson"
        Me.btn_ReadJson.Size = New System.Drawing.Size(131, 41)
        Me.btn_ReadJson.TabIndex = 0
        Me.btn_ReadJson.Text = "Read Json Files"
        '
        'grp_JsonFiles
        '
        Me.grp_JsonFiles.Controls.Add(Me.lst_Json)
        Me.grp_JsonFiles.Dock = System.Windows.Forms.DockStyle.Top
        Me.grp_JsonFiles.Location = New System.Drawing.Point(0, 0)
        Me.grp_JsonFiles.Name = "grp_JsonFiles"
        Me.grp_JsonFiles.Size = New System.Drawing.Size(659, 123)
        Me.grp_JsonFiles.TabIndex = 1
        Me.grp_JsonFiles.Text = "Json Files to Convert (Drag and Drop)"
        '
        'lst_Json
        '
        Me.lst_Json.AllowDrop = True
        Me.lst_Json.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst_Json.FormattingEnabled = True
        Me.lst_Json.Location = New System.Drawing.Point(2, 20)
        Me.lst_Json.Name = "lst_Json"
        Me.lst_Json.Size = New System.Drawing.Size(655, 101)
        Me.lst_Json.TabIndex = 0
        '
        'saveExcel
        '
        Me.saveExcel.DefaultExt = "xlsx"
        Me.saveExcel.Filter = "Microsoft Office Excel 2007 Files |*.xlsx"
        '
        'grd_Json
        '
        Me.grd_Json.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd_Json.Location = New System.Drawing.Point(0, 123)
        Me.grd_Json.MainView = Me.gv_Json
        Me.grd_Json.Name = "grd_Json"
        Me.grd_Json.Size = New System.Drawing.Size(659, 161)
        Me.grd_Json.TabIndex = 2
        Me.grd_Json.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv_Json})
        '
        'gv_Json
        '
        Me.gv_Json.GridControl = Me.grd_Json
        Me.gv_Json.Name = "gv_Json"
        Me.gv_Json.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gv_Json.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gv_Json.OptionsBehavior.Editable = False
        Me.gv_Json.OptionsSelection.MultiSelect = True
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 347)
        Me.Controls.Add(Me.grd_Json)
        Me.Controls.Add(Me.grp_JsonFiles)
        Me.Controls.Add(Me.grp_Controls)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Main"
        Me.Text = "GSTR 2A - JSON to Excel Converter"
        CType(Me.grp_Controls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Controls.ResumeLayout(False)
        CType(Me.grp_JsonFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_JsonFiles.ResumeLayout(False)
        CType(Me.grd_Json, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv_Json, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp_Controls As DevExpress.XtraEditors.GroupControl
    Friend WithEvents grp_JsonFiles As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lst_Json As System.Windows.Forms.ListBox
    Friend WithEvents btn_ReadJson As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_Export2Excel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents saveExcel As System.Windows.Forms.SaveFileDialog
    Friend WithEvents grd_Json As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv_Json As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents WaitFormManager As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents Reader As System.ComponentModel.BackgroundWorker

End Class
