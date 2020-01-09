<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="EWebApiTwo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>GameCollector</title>
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
        .auto-style6 {
            text-align:center;
        }
        .auto-style7 {
            text-align:right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Login:"></asp:Label>
        </p>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="Email:"></asp:Label>
                </td>
                <td class="auto-style6">
            <asp:TextBox ID="emailTextBox" runat="server" TextMode="Email" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="Password:"></asp:Label>
                </td>
                <td class="auto-style6">
            <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                    <td class="auto-style7">
                                            

                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign in" BackColor="DodgerBlue" ForeColor="White" Height="41px" Width="100px" />
                                            
                        
                        <br />
                                  </td>          

            </tr>
            <tr>
                <td class="auto-style3"></td>
                    <td class="auto-style6">
                                            

                        <asp:Label ID="emptyLabel" runat="server" Text="Empty Email or Password" Visible="False" Font-Underline="False" ForeColor="Red"></asp:Label>
                                            

                        </td>
                        </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT * FROM [User]"></asp:SqlDataSource>
    </form>
</body>
</html>
