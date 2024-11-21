<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="HRView.aspx.vb" Inherits="ContractMonthlyClaimSystem.HRView" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HR Claim Processing</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>HR Claim Processing</h2>

            <!-- GridView to display HR claims -->
            <asp:GridView ID="HRClaimsGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="HRClaimsGrid_RowCommand" DataKeyNames="ClaimID">
                <Columns>
                    <asp:BoundField DataField="ClaimID" HeaderText="Claim ID" />
                    <asp:BoundField DataField="LecturerName" HeaderText="Lecturer Name" />
                    <asp:BoundField DataField="HoursWorked" HeaderText="Hours Worked" />
                    <asp:BoundField DataField="TotalPayment" HeaderText="Total Payment" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                    <asp:BoundField DataField="DateSubmitted" HeaderText="Date Submitted" />
                    <asp:ButtonField Text="Export to PDF" CommandName="Export" ButtonType="Button" />
                </Columns>
                <EmptyDataTemplate>
                    <p>No claims available for processing.</p>
                </EmptyDataTemplate>
            </asp:GridView>

            <!-- Label to display success/failure messages -->
            <asp:Label ID="StatusLabel" runat="server" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>