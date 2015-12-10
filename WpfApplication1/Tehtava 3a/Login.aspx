<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tehtava_3a.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>hiihtoporukka PERSE</p>
        </div>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validator1" runat="server" ControlToValidate="txtName" ErrorMessage="You need to give a username" ForeColor="Red"></asp:RequiredFieldValidator>
        <p>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="You need to give a password" ForeColor="Red"></asp:RequiredFieldValidator>

        </p>
        <p>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </p>

    </form>
</body>
</html>
