Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class CoordinatorManagerView
    Inherits System.Web.UI.Page

    ' Declare ClaimsGrid and StatusLabel controls
    Protected WithEvents ClaimsGrid As GridView
    Protected WithEvents StatusLabel As Label

    ' This event will trigger when you click on Approve or Reject buttons
    Protected Sub ClaimsGrid_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Approve" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim claimID As Integer = Convert.ToInt32(ClaimsGrid.DataKeys(index).Value)

            ' Approve the claim - Update claim status in database (Implement this logic)
            ' Example: ApproveClaim(claimID)

            ' Show success message
            StatusLabel.Text = "Claim approved successfully!"
            StatusLabel.ForeColor = System.Drawing.Color.Green

        ElseIf e.CommandName = "Reject" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim claimID As Integer = Convert.ToInt32(ClaimsGrid.DataKeys(index).Value)

            ' Reject the claim - Update claim status in database (Implement this logic)
            ' Example: RejectClaim(claimID)

            ' Show failure message
            StatusLabel.Text = "Claim rejected."
            StatusLabel.ForeColor = System.Drawing.Color.Red
        End If
    End Sub

    ' Load the claims into the GridView when the page is loaded
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Populate the ClaimsGrid with data from database
            LoadClaims()
        End If
    End Sub

    ' Example method to load claims into the GridView (implement database logic)
    Private Sub LoadClaims()
        ' TODO: Retrieve claims from the database and bind to the GridView
        ' Example:
        ' Dim claims As DataTable = GetClaimsFromDatabase()
        ' ClaimsGrid.DataSource = claims
        ' ClaimsGrid.DataBind()
    End Sub
End Class