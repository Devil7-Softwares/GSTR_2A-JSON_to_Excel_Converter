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

Imports DevExpress.Spreadsheet
Imports DevExpress.XtraEditors.Controls

Public Class frm_ExcelHelper

#Region "Subs"
    Private Sub SetupProgressPanel()
        Dim x As Single = (lst_Excel.Width - ProgressPanel_Loading.Width) / 2
        Dim y As Single = (lst_Excel.Height - ProgressPanel_Loading.Height) / 2
        ProgressPanel_Loading.Location = New Point(x, y)

        Dim Width As Single = lst_Excel.Width - 210
        ProgressPanel_Loading.Width = Width
    End Sub

    Private Sub AddExcelFiles(ByVal Files As String())
        For Each path As String In Files
            If path.ToLower.EndsWith(".xls") Or path.ToLower.EndsWith(".xlsx") Then
                If Not lst_Excel.Items.Contains(path) Then lst_Excel.Items.Add(path)
            Else
                MsgBox(String.Format("Unknown Format for file : '{0}'", path), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Warning")
            End If
        Next
    End Sub

    Private Sub DisableControls()
        ProgressPanel_Loading.Visible = True

        grp_ExcelFiles.Enabled = False
        grp_Options.Enabled = False
        ControlBox = False
    End Sub

    Private Sub EnableControls()
        ProgressPanel_Loading.Visible = False

        grp_ExcelFiles.Enabled = True
        grp_Options.Enabled = True
        ControlBox = True
    End Sub

    Private Sub RemoveRows(ByVal Sheet As Worksheet, ByVal StartRowIndex As Integer, ByVal InvoiceNoIndex As Integer)
        For row_index As Integer = StartRowIndex To Sheet.Rows.LastUsedIndex
            Dim Row As Row = Sheet.Rows.Item(row_index)
            Dim InvoiceNoCell As Cell = Row.Item(InvoiceNoIndex)
            If InvoiceNoCell.Value.IsText AndAlso InvoiceNoCell.Value.TextValue.Contains("-Total") Then
                Dim NextRow As Row = Sheet.Rows.Item(row_index + 1)
                Dim InvoiceNoCell2 As Cell = NextRow.Item(InvoiceNoIndex)
                If InvoiceNoCell2.Value.IsEmpty Then
                    NextRow.Delete()
                End If
                Row.Delete()
            End If
        Next
    End Sub
#End Region

#Region "Form Events"
    Private Sub frm_ExcelHelper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupProgressPanel()
        If My.Settings.ExcelSaveFolder = "" Then
            txt_Folder2Save.Text = My.Computer.FileSystem.SpecialDirectories.Desktop
        Else
            txt_Folder2Save.Text = My.Settings.ExcelSaveFolder
        End If
    End Sub

    Private Sub frm_ExcelHelper_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        SetupProgressPanel()
    End Sub

    Private Sub UpdateProgress(ByVal Text As String)
        If InvokeRequired Then
            Invoke(Sub() UpdateProgress(Text))
        Else
            ProgressPanel_Loading.Description = Text
        End If
    End Sub
#End Region

#Region "Button Events"
    Private Sub btn_RemoveRows_Click(sender As Object, e As EventArgs) Handles btn_RemoveRows.Click
        If Not Worker_RemoveRows.IsBusy Then Worker_RemoveRows.RunWorkerAsync()
    End Sub

    Private Sub txt_Folder2Save_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txt_Folder2Save.ButtonClick
        browse_Folder.SelectedPath = txt_Folder2Save.Text
        If browse_Folder.ShowDialog = DialogResult.OK Then
            txt_Folder2Save.Text = browse_Folder.SelectedPath
        End If
    End Sub
#End Region

#Region "Other Events"
    Private Sub lst_Excel_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lst_Excel.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        If files.Count > 0 Then
            AddExcelFiles(files)
        End If
    End Sub

    Private Sub lst_Excel_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lst_Excel.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub option_SaveMode_EditValueChanged(sender As Object, e As EventArgs) Handles option_SaveMode.EditValueChanged
        If option_SaveMode.EditValue = 2 Then
            lbl_Folder2Save.Visible = True
            txt_Folder2Save.Visible = True
        Else
            lbl_Folder2Save.Visible = False
            txt_Folder2Save.Visible = False
        End If
    End Sub

    Private Sub Worker_RemoveRows_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Worker_RemoveRows.DoWork
        Invoke(Sub()
                   DisableControls()
               End Sub)

        For Each FilePath As String In lst_Excel.Items
            If My.Computer.FileSystem.FileExists(FilePath) Then
                Dim FileDir As String = My.Computer.FileSystem.GetFileInfo(FilePath).Directory.FullName
                Dim FileName As String = IO.Path.GetFileNameWithoutExtension(FilePath)
                Dim FileExtension As String = IO.Path.GetExtension(FilePath)
                Try
                    Using Workbook As New Workbook
                        UpdateProgress(String.Format("Loading Spreadsheet {0}...", FileName))
                        Workbook.LoadDocument(FilePath)

                        Dim StartIndexes As Integer() = {6, 7, 6, 7, 6, 7}
                        Dim InvoiceNoIndexes As Integer() = {2, 5, 3, 7, 6, 7}
                        Dim SheetIndexAdjustment As Integer = 1

                        For Index As Integer = 0 To StartIndexes.Count - 1
                            Dim WorkSheet As Worksheet = Workbook.Worksheets(Index + SheetIndexAdjustment)
                            UpdateProgress(String.Format("Processing Sheet {0} in {1}...", WorkSheet.Name, FileName))
                            RemoveRows(WorkSheet, StartIndexes(Index), InvoiceNoIndexes(Index))
                        Next

                        UpdateProgress(String.Format("Saving Spreadsheet {0}...", FileName))
                        Select Case option_SaveMode.EditValue
                            Case 0
                                Workbook.SaveDocument(FilePath)
                            Case 1
                                Workbook.SaveDocument(IO.Path.Combine(FileDir, String.Format("{0}_CLEANED{1}", FileName, FileExtension)))
                            Case 2
                                Workbook.SaveDocument(IO.Path.Combine(txt_Folder2Save.Text, String.Format("{0}{1}", FileName, FileExtension)))
                        End Select
                    End Using
                Catch ex As Exception
                    MsgBox(String.Format("Error on processing file ""{1}"".{0}{0}More Info:{0}{2}", vbNewLine, FileName, ex.Message), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                End Try
            End If
        Next

        Invoke(Sub()
                   EnableControls()
                   MsgBox("Process Completed.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
               End Sub)
    End Sub
#End Region

End Class