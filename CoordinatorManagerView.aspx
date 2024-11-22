<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="CoordinatorManagerView.aspx.vb" Inherits="ContractMonthlyClaimSystem.CoordinatorManagerView" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Coordinator/Manager View</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Coordinator/Manager Claim Verification</h2>

            <!-- GridView to display claims -->
            <asp:GridView ID="ClaimsGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="ClaimsGrid_RowCommand" DataKeyNames="ClaimID">
                <Columns>
                    <asp:BoundField DataField="ClaimID" HeaderText="Claim ID" SortExpression="ClaimID" />
                    <asp:BoundField DataField="LecturerName" HeaderText="Lecturer Name" SortExpression="LecturerName" />
                    <asp:BoundField DataField="HoursWorked" HeaderText="Hours Worked" SortExpression="HoursWorked" />
                    <asp:BoundField DataField="TotalPayment" HeaderText="Total Payment" SortExpression="TotalPayment" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:ButtonField Text="Approve" CommandName="Approve" ButtonType="Button" />
                    <asp:ButtonField Text="Reject" CommandName="Reject" ButtonType="Button" />
                </Columns>
                <EmptyDataTemplate>
                    <p>No claims available for review.</p>
                </EmptyDataTemplate>
            </asp:GridView>

            <!-- Add a status label for messages -->
            <asp:Label ID="StatusLabel" runat="server" ForeColor="Green" />
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>