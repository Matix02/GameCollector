<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDlc.aspx.cs" Inherits="EWebApiTwo.AddDlc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
                    <style type="text/css">
          
    .ParentMenu, .ParentMenu:hover {  
        width: 100px;  
        background-color: dodgerblue; 
        color: dodgerblue;  
        text-align: center;  
        height: 30px;  
        line-height: 30px;  
        margin-right: 5px;  
        border-style: double;
    }  
  
        .ParentMenu:hover {  
            background-color: dodgerblue;  
        }

        .ChildMenu, .ChildMenu:hover {
            width: 110px;
            background-color: #fff;
            color: dodgerblue;
            text-align: center;
            height: 30px;
            line-height: 30px;
            margin-top: 5px;
        }  
  
        .ChildMenu:hover {  
            background-color: #ccc;  
        }  
  
    .selected, .selected:hover {  
        background-color: #A6A6A6 !important;  
        color: dodgerblue;  
    }  
  
    .level2 {  
        background-color: dodgerblue;  
    }  
    </style>
</head>
<body>
            <style type="text/css">
        body {
            
            
            color: #444;
            
        }  
        
    .ParentMenu, .ParentMenu:hover {  
        width: 100px;  
        background-color: dodgerblue;  
        color: white;  
        text-align: center;  
        height: 30px;  
        line-height: 30px;  
        margin-right: 5px;  
        
        
    }  
    .ParentMenu:hover {  
            background-color: #ccc;  
    }  
    .ChildMenu, .ChildMenu:hover {  
        width: 110px;  
        background-color: #fff;  
        color: #333;  
        text-align: center;  
        height: 30px;  
        line-height: 30px;  
        margin-top: 5px;  
        border-style: double;
    }  
  
        .ChildMenu:hover {  
            background-color: #ccc;
            
        }  
  
    .selected, .selected:hover {  
        background-color: #A6A6A6 !important;  
        color: #fff;  
    }  
  
    .level2 {  
        background-color: #fff;  
    }  
</style> 
    <form id="form1" runat="server">
        <asp:Label ID="Label5" runat="server" Text="GameCollector Web" Font-Bold="True" Font-Size="XX-Large"
             CssClass="auto-style30"></asp:Label>
                    <br />
        <br />
        <br />
        <br />
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" BackColor="Black" BorderColor="Black" BorderStyle="Groove"
         CssClass="auto-style35">  
        <DynamicHoverStyle BackColor="DodgerBlue" />
        <LevelMenuItemStyles>  
            <asp:MenuItemStyle CssClass="ParentMenu" />  
            <asp:MenuItemStyle CssClass="ChildMenu" />  
            <asp:MenuItemStyle CssClass="ChildMenu" />  
        </LevelMenuItemStyles>  
        <StaticSelectedStyle CssClass="selected" />  
    </asp:Menu>
        <br/>
                            <asp:Label ID="Label6" runat="server" Font-Size="X-Large" Text="Avatar List"></asp:Label>
            <br /><br />
        <asp:Label ID="Label4" runat="server" Text="Game:"></asp:Label>
        <br />
        <asp:DropDownList ID="GameDropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="Title" DataValueField="Title">
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
        <asp:Button ID="Button1" runat="server" BackColor="DodgerBlue" ForeColor="White" Text="Confirm" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT DISTINCT Title FROM Game"></asp:SqlDataSource>
        <br />
    </form>
</body>
</html>
