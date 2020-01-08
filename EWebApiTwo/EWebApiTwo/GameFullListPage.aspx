<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameFullListPage.aspx.cs" Inherits="EWebApiTwo.FullListGamePage" %>

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
    <form id="form1" runat="server" >
        
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
    </asp:Menu>  <br/>
            
        <asp:Label ID="Label2" runat="server" Text="Full Game List" Font-Size="X-Large"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Expr1" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Expr1" HeaderText="Expr1" InsertVisible="False" ReadOnly="True" SortExpression="Expr1" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="RelaseDate" HeaderText="RelaseDate" SortExpression="RelaseDate" />
                <asp:BoundField DataField="Img" HeaderText="Img" SortExpression="Img" />
                <asp:BoundField DataField="BackgroundImg" HeaderText="BackgroundImg" SortExpression="BackgroundImg" />
                <asp:BoundField DataField="PlatformName" HeaderText="PlatformName" SortExpression="PlatformName" />
                <asp:BoundField DataField="DeveloperName" HeaderText="DeveloperName" SortExpression="DeveloperName" />
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
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" DeleteCommand="DELETE FROM Game WHERE (ID = @original_ID) AND (Title = @original_Title) AND (RelaseDate = @original_RelaseDate) AND (Img = @original_Img) AND (BackgroundImg = @original_BackgroundImg) AND (Platform_ID = @original_Platform_ID) AND (Developer_ID = @original_Developer_ID) AND (Platform_ID IS NULL) AND (Developer_ID = @original_Developer_ID) AND (@original_Platform_ID IS NULL)" InsertCommand="INSERT INTO [Game] ([Title], [RelaseDate], [Img], [BackgroundImg], [Platform_ID], [Developer_ID]) VALUES (@Title, @RelaseDate, @Img, @BackgroundImg, @Platform_ID, @Developer_ID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT Game.ID AS Expr1, Game.Title, Game.RelaseDate, Game.Img, Game.BackgroundImg, Platform.PlatformName, Developer.DeveloperName FROM Developer INNER JOIN Game ON Developer.ID = Game.Developer_ID INNER JOIN Platform ON Game.Platform_ID = Platform.ID" UpdateCommand="UPDATE [Game] SET [Title] = @Title, [RelaseDate] = @RelaseDate, [Img] = @Img, [BackgroundImg] = @BackgroundImg, [Platform_ID] = @Platform_ID, [Developer_ID] = @Developer_ID WHERE [ID] = @original_ID AND [Title] = @original_Title AND [RelaseDate] = @original_RelaseDate AND [Img] = @original_Img AND [BackgroundImg] = @original_BackgroundImg AND (([Platform_ID] = @original_Platform_ID) OR ([Platform_ID] IS NULL AND @original_Platform_ID IS NULL)) AND [Developer_ID] = @original_Developer_ID">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Title" Type="String" />
                <asp:Parameter DbType="Date" Name="original_RelaseDate" />
                <asp:Parameter Name="original_Img" Type="String" />
                <asp:Parameter Name="original_BackgroundImg" Type="String" />
                <asp:Parameter Name="original_Platform_ID" Type="Int32" />
                <asp:Parameter Name="original_Developer_ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter DbType="Date" Name="RelaseDate" />
                <asp:Parameter Name="Img" Type="String" />
                <asp:Parameter Name="BackgroundImg" Type="String" />
                <asp:Parameter Name="Platform_ID" Type="Int32" />
                <asp:Parameter Name="Developer_ID" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter DbType="Date" Name="RelaseDate" />
                <asp:Parameter Name="Img" Type="String" />
                <asp:Parameter Name="BackgroundImg" Type="String" />
                <asp:Parameter Name="Platform_ID" Type="Int32" />
                <asp:Parameter Name="Developer_ID" Type="Int32" />
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Title" Type="String" />
                <asp:Parameter DbType="Date" Name="original_RelaseDate" />
                <asp:Parameter Name="original_Img" Type="String" />
                <asp:Parameter Name="original_BackgroundImg" Type="String" />
                <asp:Parameter Name="original_Platform_ID" Type="Int32" />
                <asp:Parameter Name="original_Developer_ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT [ID], [Title], [RelaseDate], [Img], [BackgroundImg], [Platform_ID], [Developer_ID] FROM [Game] WHERE ([ID] = @ID)" DeleteCommand="DELETE FROM [Game] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Game] ([Title], [RelaseDate], [Img], [BackgroundImg], [Platform_ID], [Developer_ID]) VALUES (@Title, @RelaseDate, @Img, @BackgroundImg, @Platform_ID, @Developer_ID)" UpdateCommand="UPDATE [Game] SET [Title] = @Title, [RelaseDate] = @RelaseDate, [Img] = @Img, [BackgroundImg] = @BackgroundImg, [Platform_ID] = @Platform_ID, [Developer_ID] = @Developer_ID WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter DbType="Date" Name="RelaseDate" />
                <asp:Parameter Name="Img" Type="String" />
                <asp:Parameter Name="BackgroundImg" Type="String" />
                <asp:Parameter Name="Platform_ID" Type="Int32" />
                <asp:Parameter Name="Developer_ID" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="ID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter DbType="Date" Name="RelaseDate" />
                <asp:Parameter Name="Img" Type="String" />
                <asp:Parameter Name="BackgroundImg" Type="String" />
                <asp:Parameter Name="Platform_ID" Type="Int32" />
                <asp:Parameter Name="Developer_ID" Type="Int32" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
                    <asp:Label ID="Label3" runat="server" Text="Dane Szczegółowe:" Visible="False"></asp:Label>
        <asp:FormView ID="FormView1" runat="server" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource2" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" GridLines="Both">
            <EditItemTemplate>
                ID:
                <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                <br />
                Title:
                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                <br />
                RelaseDate:
                <asp:TextBox ID="RelaseDateTextBox" runat="server" Text='<%# Bind("RelaseDate") %>' />
                <br />
                Img:
                <asp:TextBox ID="ImgTextBox" runat="server" Text='<%# Bind("Img") %>' />
                <br />
                BackgroundImg:
                <asp:TextBox ID="BackgroundImgTextBox" runat="server" Text='<%# Bind("BackgroundImg") %>' />
                <br />
                Platform_ID:
                <asp:TextBox ID="Platform_IDTextBox" runat="server" Text='<%# Bind("Platform_ID") %>' />
                <br />
                Developer_ID:
                <asp:TextBox ID="Developer_IDTextBox" runat="server" Text='<%# Bind("Developer_ID") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Aktualizuj" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Anuluj" />
            </EditItemTemplate>
            <EditRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <InsertItemTemplate>
                Title:
                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                <br />
                RelaseDate:
                <asp:TextBox ID="RelaseDateTextBox" runat="server" Text='<%# Bind("RelaseDate") %>' />
                <br />
                Img:
                <asp:TextBox ID="ImgTextBox" runat="server" Text='<%# Bind("Img") %>' />
                <br />
                BackgroundImg:
                <asp:TextBox ID="BackgroundImgTextBox" runat="server" Text='<%# Bind("BackgroundImg") %>' />
                <br />
                Platform_ID:
                <asp:TextBox ID="Platform_IDTextBox" runat="server" Text='<%# Bind("Platform_ID") %>' />
                <br />
                Developer_ID:
                <asp:TextBox ID="Developer_IDTextBox" runat="server" Text='<%# Bind("Developer_ID") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Wstaw" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Anuluj" />
            </InsertItemTemplate>
            <ItemTemplate>
                ID:
                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                <br />
                Title:
                <asp:Label ID="TitleLabel" runat="server" Text='<%# Bind("Title") %>' />
                <br />
                RelaseDate:
                <asp:Label ID="RelaseDateLabel" runat="server" Text='<%# Bind("RelaseDate") %>' />
                <br />
                Img:
                <asp:Label ID="ImgLabel" runat="server" Text='<%# Bind("Img") %>' />
                <br />
                BackgroundImg:
                <asp:Label ID="BackgroundImgLabel" runat="server" Text='<%# Bind("BackgroundImg") %>' />
                <br />
                Platform_ID:
                <asp:Label ID="Platform_IDLabel" runat="server" Text='<%# Bind("Platform_ID") %>' />
                <br />
                Developer_ID:
                <asp:Label ID="Developer_IDLabel" runat="server" Text='<%# Bind("Developer_ID") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edytuj" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Usuń" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Nowy" />
            </ItemTemplate>
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
        </asp:FormView>
    </form>
</body>
</html>
