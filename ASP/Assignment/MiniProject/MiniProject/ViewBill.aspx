<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBill.aspx.cs" Inherits="MiniProject.ViewBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>View Last N Electricity Bills</h2>
 
<!-- Input for N -->
<asp:Label ID="lblEnterN" runat="server" Text="Enter number of bills to retrieve:"></asp:Label><br />
<asp:TextBox ID="txtN" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtN" ErrorMessage="value must be 1 to 100" ForeColor="Red">*</asp:RequiredFieldValidator>
<br /><br />
 
<asp:Button ID="btnViewBills" runat="server" Text="View Bills" OnClick="btnViewBills_Click" /><br /><br />
 
<!-- Display messages -->
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<br /><br />
 
<!-- GridView to show bill details -->
<asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="false" BorderStyle="Solid" BorderWidth="1px">
<Columns>
<asp:BoundField DataField="ConsumerNumber" HeaderText="Consumer Number" />
<asp:BoundField DataField="ConsumerName" HeaderText="Consumer Name" />
<asp:BoundField DataField="UnitsConsumed" HeaderText="Units Consumed" />
<asp:BoundField DataField="BillAmount" HeaderText="Bill Amount (Rs.)" />
</Columns>
</asp:GridView>
 
        </div>
    </form>
</body>
</html>
