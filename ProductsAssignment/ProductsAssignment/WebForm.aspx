<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="ProductsAssignment.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <h1>Select The Products</h1>

 
               <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
</asp:DropDownList>
&nbsp;
<br />
<br />
<asp:Image ID="Image1" runat="server" width="200px" Height="200px"/>
<br />
<br />
<br />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Price" />
<br />
<br />
<br />
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<br />

 
        </div>
        
    </form>
</body>
</html>
