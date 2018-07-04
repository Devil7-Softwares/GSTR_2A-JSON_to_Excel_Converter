﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btn_Add = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Remove = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Clear = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Excel = New DevExpress.XtraBars.BarButtonItem()
        Me.menu_Excel = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.btn_Excel_XLS = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Excel_XLSX = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Word = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Other = New DevExpress.XtraBars.BarButtonItem()
        Me.menu_Others = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.btn_CSV = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_HTML = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_MHT = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_RTF = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_TXT = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_PDF = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_ReadJSON = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Combine = New DevExpress.XtraBars.BarButtonItem()
        Me.rp_Home = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpg_JSON = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpg_Process = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpg_Export = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lst_Json = New System.Windows.Forms.ListBox()
        Me.SplitterControl1 = New DevExpress.XtraEditors.SplitterControl()
        Me.tb_Sheets = New DevExpress.XtraTab.XtraTabControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ProgressPanel = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.OpenJSONFiles = New System.Windows.Forms.OpenFileDialog()
        Me.JSONReader = New System.ComponentModel.BackgroundWorker()
        Me.SaveFileDlg = New System.Windows.Forms.SaveFileDialog()
        Me.SelectExportFolder = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.menu_Excel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.menu_Others, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.tb_Sheets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.AllowMdiChildButtons = False
        Me.RibbonControl.AllowMinimizeRibbon = False
        Me.RibbonControl.AllowTrimPageText = False
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.btn_Add, Me.btn_Remove, Me.btn_Clear, Me.btn_Excel, Me.btn_Excel_XLS, Me.btn_Excel_XLSX, Me.btn_Word, Me.btn_Other, Me.btn_CSV, Me.btn_HTML, Me.btn_MHT, Me.btn_RTF, Me.btn_TXT, Me.btn_PDF, Me.btn_ReadJSON, Me.btn_Combine})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 17
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rp_Home})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowCategoryInCaption = False
        Me.RibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(671, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'btn_Add
        '
        Me.btn_Add.Caption = "Add"
        Me.btn_Add.Id = 1
        Me.btn_Add.ImageOptions.Image = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.add
        Me.btn_Add.ImageOptions.LargeImage = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.add
        Me.btn_Add.Name = "btn_Add"
        '
        'btn_Remove
        '
        Me.btn_Remove.Caption = "Remove"
        Me.btn_Remove.Id = 2
        Me.btn_Remove.ImageOptions.Image = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.remove
        Me.btn_Remove.ImageOptions.LargeImage = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.remove
        Me.btn_Remove.Name = "btn_Remove"
        '
        'btn_Clear
        '
        Me.btn_Clear.Caption = "Clear"
        Me.btn_Clear.Id = 3
        Me.btn_Clear.ImageOptions.Image = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.clear
        Me.btn_Clear.ImageOptions.LargeImage = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.clear
        Me.btn_Clear.Name = "btn_Clear"
        '
        'btn_Excel
        '
        Me.btn_Excel.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.btn_Excel.Caption = "Excel"
        Me.btn_Excel.DropDownControl = Me.menu_Excel
        Me.btn_Excel.Id = 4
        Me.btn_Excel.ImageOptions.Image = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.export_excel
        Me.btn_Excel.ImageOptions.LargeImage = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.export_excel
        Me.btn_Excel.Name = "btn_Excel"
        '
        'menu_Excel
        '
        Me.menu_Excel.ItemLinks.Add(Me.btn_Excel_XLS)
        Me.menu_Excel.ItemLinks.Add(Me.btn_Excel_XLSX)
        Me.menu_Excel.Name = "menu_Excel"
        Me.menu_Excel.Ribbon = Me.RibbonControl
        '
        'btn_Excel_XLS
        '
        Me.btn_Excel_XLS.Caption = "Excel 97-2003 Format (*.xls)"
        Me.btn_Excel_XLS.Id = 5
        Me.btn_Excel_XLS.Name = "btn_Excel_XLS"
        '
        'btn_Excel_XLSX
        '
        Me.btn_Excel_XLSX.Caption = "Excel 2007 Format (*.xlsx)"
        Me.btn_Excel_XLSX.Id = 6
        Me.btn_Excel_XLSX.Name = "btn_Excel_XLSX"
        '
        'btn_Word
        '
        Me.btn_Word.Caption = "Word"
        Me.btn_Word.Id = 7
        Me.btn_Word.ImageOptions.Image = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.export_word
        Me.btn_Word.ImageOptions.LargeImage = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.export_word
        Me.btn_Word.Name = "btn_Word"
        '
        'btn_Other
        '
        Me.btn_Other.ActAsDropDown = True
        Me.btn_Other.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.btn_Other.Caption = "Other Formats"
        Me.btn_Other.DropDownControl = Me.menu_Others
        Me.btn_Other.Id = 8
        Me.btn_Other.ImageOptions.Image = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.export_others
        Me.btn_Other.ImageOptions.LargeImage = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.export_others
        Me.btn_Other.Name = "btn_Other"
        '
        'menu_Others
        '
        Me.menu_Others.ItemLinks.Add(Me.btn_CSV)
        Me.menu_Others.ItemLinks.Add(Me.btn_HTML)
        Me.menu_Others.ItemLinks.Add(Me.btn_MHT)
        Me.menu_Others.ItemLinks.Add(Me.btn_RTF)
        Me.menu_Others.ItemLinks.Add(Me.btn_TXT)
        Me.menu_Others.Name = "menu_Others"
        Me.menu_Others.Ribbon = Me.RibbonControl
        '
        'btn_CSV
        '
        Me.btn_CSV.Caption = "Comma Separated Text File (*.csv)"
        Me.btn_CSV.Id = 9
        Me.btn_CSV.Name = "btn_CSV"
        '
        'btn_HTML
        '
        Me.btn_HTML.Caption = "Webpage (*.html)"
        Me.btn_HTML.Id = 10
        Me.btn_HTML.Name = "btn_HTML"
        '
        'btn_MHT
        '
        Me.btn_MHT.Caption = "Microsoft HTML File (*.mhtml)"
        Me.btn_MHT.Id = 11
        Me.btn_MHT.Name = "btn_MHT"
        '
        'btn_RTF
        '
        Me.btn_RTF.Caption = "Rich Text Format (*.rtf)"
        Me.btn_RTF.Id = 12
        Me.btn_RTF.Name = "btn_RTF"
        '
        'btn_TXT
        '
        Me.btn_TXT.Caption = "Plain Text (*.txt)"
        Me.btn_TXT.Id = 13
        Me.btn_TXT.Name = "btn_TXT"
        '
        'btn_PDF
        '
        Me.btn_PDF.Caption = "PDF"
        Me.btn_PDF.Id = 14
        Me.btn_PDF.ImageOptions.Image = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.export_pdf
        Me.btn_PDF.ImageOptions.LargeImage = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.export_pdf
        Me.btn_PDF.Name = "btn_PDF"
        '
        'btn_ReadJSON
        '
        Me.btn_ReadJSON.Caption = "Read JSON"
        Me.btn_ReadJSON.Id = 15
        Me.btn_ReadJSON.ImageOptions.Image = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.process
        Me.btn_ReadJSON.ImageOptions.LargeImage = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.process
        Me.btn_ReadJSON.Name = "btn_ReadJSON"
        '
        'btn_Combine
        '
        Me.btn_Combine.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.btn_Combine.Caption = "Combine All"
        Me.btn_Combine.Down = True
        Me.btn_Combine.Id = 16
        Me.btn_Combine.ImageOptions.Image = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.combine
        Me.btn_Combine.ImageOptions.LargeImage = Global.GSTR_2A___JSON_to_Excel_Converter.My.Resources.Resources.combine
        Me.btn_Combine.Name = "btn_Combine"
        '
        'rp_Home
        '
        Me.rp_Home.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpg_JSON, Me.rpg_Process, Me.rpg_Export})
        Me.rp_Home.Name = "rp_Home"
        Me.rp_Home.Text = "Home"
        '
        'rpg_JSON
        '
        Me.rpg_JSON.ItemLinks.Add(Me.btn_Add)
        Me.rpg_JSON.ItemLinks.Add(Me.btn_Remove)
        Me.rpg_JSON.ItemLinks.Add(Me.btn_Clear, True)
        Me.rpg_JSON.Name = "rpg_JSON"
        Me.rpg_JSON.ShowCaptionButton = False
        Me.rpg_JSON.Text = "JSON Files"
        '
        'rpg_Process
        '
        Me.rpg_Process.ItemLinks.Add(Me.btn_ReadJSON)
        Me.rpg_Process.ItemLinks.Add(Me.btn_Combine, True)
        Me.rpg_Process.Name = "rpg_Process"
        Me.rpg_Process.Text = "Process"
        '
        'rpg_Export
        '
        Me.rpg_Export.ItemLinks.Add(Me.btn_Word)
        Me.rpg_Export.ItemLinks.Add(Me.btn_PDF)
        Me.rpg_Export.ItemLinks.Add(Me.btn_Excel)
        Me.rpg_Export.ItemLinks.Add(Me.btn_Other)
        Me.rpg_Export.Name = "rpg_Export"
        Me.rpg_Export.ShowCaptionButton = False
        Me.rpg_Export.Text = "Export"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 418)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(671, 31)
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.lst_Json)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 143)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(671, 119)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "JSON Files (Use 'Add' Button or 'Drag n Drop' Files)"
        '
        'lst_Json
        '
        Me.lst_Json.AllowDrop = True
        Me.lst_Json.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst_Json.FormattingEnabled = True
        Me.lst_Json.Location = New System.Drawing.Point(2, 20)
        Me.lst_Json.Name = "lst_Json"
        Me.lst_Json.Size = New System.Drawing.Size(667, 97)
        Me.lst_Json.TabIndex = 1
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitterControl1.Location = New System.Drawing.Point(0, 262)
        Me.SplitterControl1.Name = "SplitterControl1"
        Me.SplitterControl1.Size = New System.Drawing.Size(671, 5)
        Me.SplitterControl1.TabIndex = 3
        Me.SplitterControl1.TabStop = False
        '
        'tb_Sheets
        '
        Me.tb_Sheets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tb_Sheets.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.tb_Sheets.Location = New System.Drawing.Point(0, 267)
        Me.tb_Sheets.Name = "tb_Sheets"
        Me.tb_Sheets.Size = New System.Drawing.Size(671, 151)
        Me.tb_Sheets.TabIndex = 4
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(67, 53)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.RibbonControl
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(400, 200)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'ProgressPanel
        '
        Me.ProgressPanel.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel.Appearance.Options.UseBackColor = True
        Me.ProgressPanel.BarAnimationElementThickness = 2
        Me.ProgressPanel.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.ProgressPanel.Description = "Parsing JSON Files..."
        Me.ProgressPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressPanel.Location = New System.Drawing.Point(0, 267)
        Me.ProgressPanel.Name = "ProgressPanel"
        Me.ProgressPanel.Size = New System.Drawing.Size(671, 151)
        Me.ProgressPanel.TabIndex = 7
        Me.ProgressPanel.Visible = False
        '
        'OpenJSONFiles
        '
        Me.OpenJSONFiles.Filter = "All Supported Formats|*.json;*.zip|JSON Files|*.json|ZIP Archives|*.zip"
        Me.OpenJSONFiles.Multiselect = True
        Me.OpenJSONFiles.Title = "Select GSTR 2A JSON/ZIP Files"
        '
        'JSONReader
        '
        '
        'SaveFileDlg
        '
        Me.SaveFileDlg.DefaultExt = "docx"
        Me.SaveFileDlg.Filter = "Microsoft Office Word Documents|*.docx"
        '
        'SelectExportFolder
        '
        Me.SelectExportFolder.Description = "Select Folder to Export Files"
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 449)
        Me.Controls.Add(Me.ProgressPanel)
        Me.Controls.Add(Me.tb_Sheets)
        Me.Controls.Add(Me.SplitterControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Main"
        Me.Ribbon = Me.RibbonControl
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "GSTR 2A - JSON to Excel Converter"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.menu_Excel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.menu_Others, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.tb_Sheets, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents rp_Home As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpg_JSON As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SplitterControl1 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents tb_Sheets As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents lst_Json As System.Windows.Forms.ListBox
    Friend WithEvents btn_Add As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Remove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Clear As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpg_Export As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btn_Excel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents menu_Excel As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btn_Excel_XLS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Excel_XLSX As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Word As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Other As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents menu_Others As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btn_CSV As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_HTML As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_MHT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_RTF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_TXT As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_PDF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ProgressPanel As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents OpenJSONFiles As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btn_ReadJSON As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpg_Process As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btn_Combine As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents JSONReader As System.ComponentModel.BackgroundWorker
    Friend WithEvents SaveFileDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SelectExportFolder As System.Windows.Forms.FolderBrowserDialog


End Class
