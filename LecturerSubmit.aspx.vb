Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data.SqlClient

Partial Class LecturerSubmit
    Inherits System.Web.UI.Page

    Private connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("LecturerClaimsDB").ConnectionString

    ' Page Load to Bind GridView
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindSubmittedClaimsGrid()
        End If
    End Sub

    ' Claim Submission Handler
    Protected Sub btnSubmitClaim_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(txtLecturerName.Text) OrElse String.IsNullOrEmpty(txtHoursWorked.Text) OrElse String.IsNullOrEmpty(txtHourlyRate.Text) Then
            lblMessage.Text = "All fields are required."
            Return
        End If

        Dim lecturerName As String = txtLecturerName.Text.Trim()
        Dim hoursWorked As Double
        Dim hourlyRate As Double

        If Not Double.TryParse(txtHoursWorked.Text.Trim(), hoursWorked) OrElse Not Double.TryParse(txtHourlyRate.Text.Trim(), hourlyRate) Then
            lblMessage.Text = "Invalid numeric values for hours worked or hourly rate."
            Return
        End If

        Dim totalPayment As Double = hoursWorked * hourlyRate
        Dim filePath As String = Nothing

        If fuSupportingDocs.HasFile Then
            Dim fileName As String = Path.GetFileName(fuSupportingDocs.PostedFile.FileName)
            filePath = Server.MapPath("~/UploadedFiles/" & fileName)
            fuSupportingDocs.SaveAs(filePath)
        End If

        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "INSERT INTO Claims (LecturerName, HoursWorked, HourlyRate, TotalPayment, Status, SupportingDocument) " &
                                  "VALUES (@LecturerName, @HoursWorked, @HourlyRate, @TotalPayment, @Status, @SupportingDocument)"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@LecturerName", lecturerName)
                cmd.Parameters.AddWithValue("@HoursWorked", hoursWorked)
                cmd.Parameters.AddWithValue("@HourlyRate", hourlyRate)
                cmd.Parameters.AddWithValue("@TotalPayment", totalPayment)
                cmd.Parameters.AddWithValue("@Status", "Pending")
                cmd.Parameters.AddWithValue("@SupportingDocument", If(filePath, DBNull.Value))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    lblMessage.ForeColor = System.Drawing.Color.Green
                    lblMessage.Text = "Claim submitted successfully."
                Catch ex As Exception
                    lblMessage.ForeColor = System.Drawing.Color.Red
                    lblMessage.Text = "Error: " & ex.Message
                End Try
            End Using
        End Using

        ' Refresh the GridView
        BindSubmittedClaimsGrid()
    End Sub

    ' Bind Claims GridView
    Private Sub BindSubmittedClaimsGrid()
        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "SELECT ClaimID, HoursWorked, HourlyRate, TotalPayment, Status, DateSubmitted " &
                                  "FROM Claims WHERE LecturerName = @LecturerName"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@LecturerName", txtLecturerName.Text.Trim())
                Dim dt As New DataTable()

                Try
                    conn.Open()
                    Dim adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)

                    gvSubmittedClaims.DataSource = dt
                    gvSubmittedClaims.DataBind()
                Catch ex As Exception
                    lblMessage.ForeColor = System.Drawing.Color.Red
                    lblMessage.Text = "Error: " & ex.Message
                End Try
            End Using
        End Using
    End Sub
End Class