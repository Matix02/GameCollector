<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAvatarPage.aspx.cs" Inherits="EWebApiTwo.AddAvatarPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Add Avatar</div>
        <p>
            Title:</p>
        <asp:TextBox ID="AvatarTextBox" runat="server"></asp:TextBox>
        <br />
        Avatar Image:<br />
        <asp:TextBox ID="ImageTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" BackColor="DodgerBlue" ForeColor="White" OnClick="Button1_Click" Text="Confirm" />
        <br />
        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </form>
</body>
</html>
