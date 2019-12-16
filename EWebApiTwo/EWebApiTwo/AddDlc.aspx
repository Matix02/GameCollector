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
        <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
        :<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="File Upload"></asp:Label>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Jak ustawić, by było z danej gry dlc powiązane"></asp:Label>
    </form>
</body>
</html>
