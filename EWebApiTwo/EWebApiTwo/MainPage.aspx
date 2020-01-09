<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="EWebApiTwo.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>GameCollector</title>

    <script language="javascript" type="text/javascript">
        function PopupDatePicker(ctl) {
            var PopupWindow = null;
            PopupWindow = window.open('MyCustomDatePicker.aspx?ctl=' + ctl, '', 'width=250,height=250');
            PopupWindow.focus();
        }
    </script>
    <style type="text/css">
        .auto-style4 {
            height: 24px;
            width: 198px;
        }
        .auto-style5 {
            width: 198px;
            font-size:large;
        }
        .auto-style6 {
            height: 28px;
            width: 198px;
            text-align:left;
            vertical-align:text-top;
            font-size:large;
        }
        .auto-style7 {
            height: 26px;
            width: 198px;
            font-size: large;
        }
        .auto-style13 {
            height: 24px;
            width: 71px;
        }

        .auto-style14 {
            width: 71px;
        }
        .auto-style15 {
            height: 28px;
            width: 71px;
        }
        .auto-style16 {
            height: 26px;
            width: 71px;
            text-align: center;
        }
        .auto-style18 {
            width: 266px;
        }
        .auto-style19 {
            height: 28px;
            width: 266px;
        }
        .auto-style20 {
            height: 26px;
            width: 266px;
            text-align: center;
        }
        .auto-style21 {
            width: 100%;
            
        }
        .auto-style22 {
            height: 24px;
            width: 183px;

        }
        .auto-style23 {
            width: 183px;
            text-align: center;
        }
        .auto-style24 {
            height: 28px;
            width: 183px;
            
            
        }
        .auto-style25 {
            height: 26px;
            width: 183px;
            text-align: center;
        }
        .auto-style26 {
            cursor: hand;
        }
        .auto-style28 {
            height: 26px;
            width: 183px;
            text-align:  right;
        }
        .auto-style29 {
            height: 24px;
            width: 266px;
            
        }
        .auto-style31 {
            padding:10px;
        } 
  
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
        <div>  
</div> 
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="GameCollector Web" Font-Bold="True" Font-Size="XX-Large"
             CssClass="auto-style30"></asp:Label>
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="PlatformConnetionString" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT [PlatformName] FROM [Platform]"></asp:SqlDataSource>
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
       
            
        &nbsp;<br />
        <asp:SqlDataSource ID="DeveloperConnectionString" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT [DeveloperName] FROM [Developer]"></asp:SqlDataSource>
        
       
        <table class="auto-style21" >
             <table align="left">
            <tr>
                <td class="auto-style4">
                    
                    <asp:Label ID="Label3" runat="server" Font-Italic="False" Font-Size="X-Large" Text="Add New Game"></asp:Label>
                </td>
                <td class="auto-style22">
                    &nbsp;</td>
                <td class="auto-style13"></td>
                <td class="auto-style29"></td>
                
            </tr>
            <tr>
                <td class="auto-style5">Title:</td>
                <td class="auto-style23">
        <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style18">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">Platform:</td>
                <td class="auto-style24" >
        <asp:CheckBoxList ID="PlatformCheckBoxList" runat="server" DataSourceID="PlatformConnetionString" DataTextField="PlatformName" DataValueField="PlatformName" OnSelectedIndexChanged="PlatformCheckBoxList_SelectedIndexChanged">
        </asp:CheckBoxList>
                </td>
                <td class="auto-style15"></td>
                <td class="auto-style19"></td>
            </tr>
            <tr>
                <td class="auto-style7">
        <asp:Label ID="Label2" runat="server" Text="Relase Date:"></asp:Label>
                    </td>
                <td class="auto-style25">
            <asp:textbox ID="txtDate" runat="server"/>
                </td>
                <td class="auto-style16">
    <asp:image runat="server" onclick="PopupDatePicker('txtDate')" 
        ImageUrl="https://www.netclipart.com/pp/m/104-1044961_calendar-icon-png-date-events-icon-white-png.png" Width="18px" ID="image1" CssClass="auto-style26" /></td>
                <td class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style7">Developer:</td>
                <td class="auto-style25">
        <asp:DropDownList ID="DeveloperDropDownList" runat="server" DataSourceID="DeveloperConnectionString" DataTextField="DeveloperName" DataValueField="DeveloperName" Width="178px">
        </asp:DropDownList>
                </td>
                <td class="auto-style16">
        <asp:Button ID="AddButton" runat="server" OnClick="Button4_Click" Text="Add" BackColor="DodgerBlue" ForeColor="White" Height="35px" Width="62px" />
                </td>
                <td class="auto-style20">
        <asp:TextBox ID="NewDeveloperTextBox" runat="server" Visible="False"></asp:TextBox>
        <asp:Button ID="DeleteButton" runat="server" OnClick="Button1_Click" Text="Delete" Visible="False" BackColor="DodgerBlue" ForeColor="White" Height="34px" Width="88px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Image Cover:</td>
                <td class="auto-style25">
        <asp:TextBox ID="ImageCoverTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style16"></td>
                <td class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style7">Image Background:</td>
                <td class="auto-style25">
        <asp:TextBox ID="ImageBgTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style16"></td>
                <td class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style28">
        <asp:Button ID="ConfirmButton" runat="server" OnClick="Button3_Click" Text="Confirm" BackColor="DodgerBlue" ForeColor="White" Height="41px" Width="100px" />
                </td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style25">
        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" Visible="False" Font-Size="Large" 
            ></asp:Label></td>
                <td class="auto-style16"></td>
                <td class="auto-style20"></td>
            </tr>
             <table>
        </table>
        <p>
            <center>
        </center>
                </p>
    </form>
    </body>
</html>
