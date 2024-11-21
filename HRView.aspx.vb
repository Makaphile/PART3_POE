Imports System
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class HRView
    Inherits System.Web.UI.Page

    ' Handles the GridView command (Export to PDF)
    Protected Sub HRClaimsGrid_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Export" Then
            ' Get the row index
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' Get the ClaimID from the row
            Dim claimID As Integer = Convert.ToInt32(HRClaimsGrid.DataKeys(index).Value)

            ' Get the claim data from database using claimID
            ' For simplicity, let's assume you have a function that retrieves the claim by ID
            Dim claim = GetClaimDetails(claimID)

            ' Export claim to PDF
            ExportClaimToPDF(claim)
        End If
    End Sub

    ' Function to simulate fetching claim details (replace with your actual data retrieval logic)
    Private Function GetClaimDetails(claimID As Integer) As Claim
        ' Simulated claim data - replace with actual database call
        Return New Claim With {
            .ClaimID = claimID,
            .LecturerName = "John Doe",
            .HoursWorked = 20,
            .TotalPayment = 500.0,
            .Status = "Approved",
            .DateSubmitted = DateTime.Now
        }
    End Function

    ' Function to export the claim to PDF
    Private Sub ExportClaimToPDF(claim As Claim)
        ' Create a new PDF document
        Dim doc As New Document()
        Dim filePath As String = Server.MapPath("~/Exports/Claim_" & claim.ClaimID & ".pdf")

        ' Create a PDF writer to write to the file
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(filePath, FileMode.Create))

        ' Open the document for writing
        doc.Open()

        ' Add content to the PDF
        doc.Add(New Paragraph("Claim ID: " & claim.ClaimID))
        doc.Add(New Paragraph("Lecturer Name: " & claim.LecturerName))
        doc.Add(New Paragraph("Hours Worked: " & claim.HoursWorked))
        doc.Add(New Paragraph("Total Payment: " & claim.TotalPayment))
        doc.Add(New Paragraph("Status: " & claim.Status))
        doc.Add(New Paragraph("Date Submitted: " & claim.DateSubmitted.ToString()))

        ' Close the document
        doc.Close()

        ' Provide feedback to the user
        StatusLabel.Text = "Claim details exported to PDF successfully!"
        StatusLabel.ForeColor = System.Drawing.Color.Green
    End Sub


    ' Claim class to hold claim details
    Public Class Claim
    Public Property ClaimID As Integer
    Public Property LecturerName As String
    Public Property HoursWorked As Integer
    Public Property TotalPayment As Decimal
    Public Property Status As String
        Public Property DateSubmitted As DateTime
    End Class