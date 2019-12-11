<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="WebGameCollector.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 27%;
            height: 71px;
        }
        .auto-style3 {
            width: 109px;
        }
        .auto-style4 {
            width: 109px;
            height: 29px;
        }
        .auto-style5 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <strong>Login</strong></p>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">Email:</td>
                <td>
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Password:</td>
                <td class="auto-style5">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                    <td class="auto-style6">
                                            

                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign in" />
                                            

            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT * FROM [User]"></asp:SqlDataSource>
    </form>
</body>
</html>
