<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="LecturerSubmit.aspx.vb" Inherits="PART3_POE.LecturerSubmit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lecturer Claim Submission</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Lecturer Claim Submission</h2>

            <!-- Submission Form -->
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br /><br />
            <asp:TextBox ID="txtLecturerName" runat="server" Placeholder="Lecturer Name"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtHoursWorked" runat="server" Placeholder="Hours Worked"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtHourlyRate" runat="server" Placeholder="Hourly Rate"></asp:TextBox>
            <br /><br />
            <asp:FileUpload ID="fuSupportingDocs" runat="server" />
            <br /><br />
            <asp:Button ID="btnSubmitClaim" runat="server" Text="Submit Claim" OnClick="btnSubmitClaim_Click" />

            <!-- Submitted Claims -->
            <h2>My Submitted Claims</h2>
            <asp:GridView ID="gvSubmittedClaims" runat="server" AutoGenerateColumns="False" EmptyDataText="No claims submitted yet.">
                <Columns>
                    <asp:BoundField DataField="ClaimID" HeaderText="Claim ID" />
                    <asp:BoundField DataField="HoursWorked" HeaderText="Hours Worked" />
                    <asp:BoundField DataField="HourlyRate" HeaderText="Hourly Rate" />
                    <asp:BoundField DataField="TotalPayment" HeaderText="Total Payment" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="DateSubmitted" HeaderText="Date Submitted" DataFormatString="{0:yyyy-MM-dd}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>