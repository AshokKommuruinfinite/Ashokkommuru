<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MiniProject.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
<h2>Admin Login</h2>
 
<table>
<tr>
<td>Username:</td>
<td>
<asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>Password:</td>
<td>
<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2" align="center">
<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
</td>
</tr>
</table>
 
<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
</div>
    </form>
</body>
</html>
