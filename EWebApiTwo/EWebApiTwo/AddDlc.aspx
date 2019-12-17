<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDlc.aspx.cs" Inherits="EWebApiTwo.AddDlc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        Add Dlc<br />
        <asp:Label ID="Label4" runat="server" Text="Game:"></asp:Label>
        <br />
        <asp:DropDownList ID="GameDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
        :<br />
        <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Image:"></asp:Label>
        <br />
        <asp:TextBox ID="ImageTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" BackColor="DodgerBlue" ForeColor="White" Text="Confirm" />
        <br />
        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Jak ustawić, by było z danej gry dlc powiązane"></asp:Label>
    </form>
</body>
</html>
