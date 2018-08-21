Public Class frm_About
    Dim SourceLink, LicenseLink, IssuesLink, ReleasesLink, WebsiteLink As String

    Private Sub frm_About_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        lbl_ApplicationTitle.Text = My.Application.Info.Title
        lbl_Description.Text = My.Application.Info.Description
        lbl_BuildDate.Text = RetrieveLinkerTimestamp.ToString("dd/MM/yyyy hh:mm:ss")
        lbl_Company.Text = My.Application.Info.CompanyName
        lbl_Version.Text = My.Application.Info.Version.ToString
        lbl_ProjectTitle.Text = My.Application.Info.ProductName
        lbl_Email.Text = "devil7softwares@gmail.com"

        SourceLink = "https://github.com/Devil7-Softwares/GSTR_2A-JSON_to_Excel_Converter"
        LicenseLink = "https://www.gnu.org/licenses/gpl-3.0.en.html"
        IssuesLink = "https://github.com/Devil7-Softwares/GSTR_2A-JSON_to_Excel_Converter/issues"
        ReleasesLink = "https://github.com/Devil7-Softwares/GSTR_2A-JSON_to_Excel_Converter/releases"
        WebsiteLink = "https://devil7softwares.github.io"

    End Sub

    Private Sub lbl_Email_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbl_Email.LinkClicked
        Process.Start(String.Format("mailto:{0}", lbl_Email.Text))
    End Sub

    Private Sub lbl_License_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbl_License.LinkClicked
        Process.Start(LicenseLink)
    End Sub

    Private Sub lbl_Source_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbl_Source.LinkClicked
        Process.Start(SourceLink)
    End Sub

    Private Sub lbl_IssueTracker_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbl_IssueTracker.LinkClicked
        Process.Start(IssuesLink)
    End Sub

    Private Sub lbl_Website_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbl_Website.LinkClicked
        Process.Start(WebsiteLink)
    End Sub

    Private Sub lbl_Downlods_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbl_Downlods.LinkClicked
        Process.Start(ReleasesLink)
    End Sub
End Class