<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="EWebApiTwo.UserPage" %>

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
        <asp:Label ID="Label1" runat="server" Text="GameCollector Web" Font-Bold="True" Font-Size="XX-Large"
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
                            <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Avatar List"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Nickname" HeaderText="Nickname" SortExpression="Nickname" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="Avatar" HeaderText="Avatar" SortExpression="Avatar" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" DeleteCommand="DELETE FROM [User] WHERE [ID] = @original_ID AND [Nickname] = @original_Nickname AND [Email] = @original_Email AND [Password] = @original_Password AND [Type] = @original_Type AND (([Avatar] = @original_Avatar) OR ([Avatar] IS NULL AND @original_Avatar IS NULL))" InsertCommand="INSERT INTO [User] ([Nickname], [Email], [Password], [Type], [Avatar]) VALUES (@Nickname, @Email, @Password, @Type, @Avatar)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [User]" UpdateCommand="UPDATE [User] SET [Nickname] = @Nickname, [Email] = @Email, [Password] = @Password, [Type] = @Type, [Avatar] = @Avatar WHERE [ID] = @original_ID AND [Nickname] = @original_Nickname AND [Email] = @original_Email AND [Password] = @original_Password AND [Type] = @original_Type AND (([Avatar] = @original_Avatar) OR ([Avatar] IS NULL AND @original_Avatar IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Nickname" Type="String" />
                <asp:Parameter Name="original_Email" Type="String" />
                <asp:Parameter Name="original_Password" Type="String" />
                <asp:Parameter Name="original_Type" Type="String" />
                <asp:Parameter Name="original_Avatar" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Nickname" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Type" Type="String" />
                <asp:Parameter Name="Avatar" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nickname" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="Type" Type="String" />
                <asp:Parameter Name="Avatar" Type="String" />
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Nickname" Type="String" />
                <asp:Parameter Name="original_Email" Type="String" />
                <asp:Parameter Name="original_Password" Type="String" />
                <asp:Parameter Name="original_Type" Type="String" />
                <asp:Parameter Name="original_Avatar" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
