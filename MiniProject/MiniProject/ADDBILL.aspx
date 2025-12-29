<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADDBILL.aspx.cs" Inherits="MiniProject.ADDBILL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Electricity Bill Entry</h2>
 
<!-- General Message -->
<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />
 
<!-- Consumer Number -->
<asp:Label ID="lblConsumerNumber" runat="server" Text="Consumer Number:"></asp:Label><br />
<asp:TextBox ID="txtConsumerNumber" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvConsumerNumber" runat="server"

    ControlToValidate="txtConsumerNumber" ErrorMessage="Consumer Number is required" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtConsumerName" ErrorMessage="Consumer Number Start With EB and Length should be 7 Letters" ForeColor="Red"></asp:RequiredFieldValidator>
<br /><br />
 
<!-- Consumer Name -->
<asp:Label ID="lblConsumerName" runat="server" Text="Consumer Name:"></asp:Label><br />
<asp:TextBox ID="txtConsumerName" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvConsumerName" runat="server"

    ControlToValidate="txtConsumerName" ErrorMessage="Consumer Name is required" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConsumerName" ErrorMessage="Consumer Name Cannot be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
<br /><br />
 
<!-- Units Consumed -->
<asp:Label ID="lblUnitsConsumed" runat="server" Text="Units Consumed:"></asp:Label><br />
<asp:TextBox ID="txtUnitsConsumed" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvUnits" runat="server"

    ControlToValidate="txtUnitsConsumed" ErrorMessage="Units Consumed is required" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUnitsConsumed" ErrorMessage="Should be Greater than 0" ForeColor="Red"></asp:RequiredFieldValidator>
<br /><br />
 
<!-- Submit Button -->
<asp:Button ID="btnAddBill" runat="server" Text="Add Bill" OnClick="btnAddBill_Click" /><br /><br />
 
<!-- Output Message -->
<asp:Label ID="lblBillOutput" runat="server" ForeColor="Green"></asp:Label>
 
        </div>
    </form>
</body>
</html>
