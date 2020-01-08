<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DlcFullList.aspx.cs" Inherits="EWebApiTwo.DlcFullList" %>

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
                            <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Dlc List"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="DlcTitle" HeaderText="DlcTitle" SortExpression="DlcTitle" />
                <asp:BoundField DataField="Img" HeaderText="Img" SortExpression="Img" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" DeleteCommand="DELETE FROM [Dlc] WHERE [ID] = @original_ID AND [DlcTitle] = @original_DlcTitle AND [Img] = @original_Img AND [Game_ID] = @original_Game_ID" InsertCommand="INSERT INTO [Dlc] ([DlcTitle], [Img], [Game_ID]) VALUES (@DlcTitle, @Img, @Game_ID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT Dlc.ID, Dlc.DlcTitle, Dlc.Img, Game.Title FROM Dlc INNER JOIN Game ON Dlc.Game_ID = Game.ID" UpdateCommand="UPDATE [Dlc] SET [DlcTitle] = @DlcTitle, [Img] = @Img, [Game_ID] = @Game_ID WHERE [ID] = @original_ID AND [DlcTitle] = @original_DlcTitle AND [Img] = @original_Img AND [Game_ID] = @original_Game_ID">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_DlcTitle" Type="String" />
                <asp:Parameter Name="original_Img" Type="String" />
                <asp:Parameter Name="original_Game_ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="DlcTitle" Type="String" />
                <asp:Parameter Name="Img" Type="String" />
                <asp:Parameter Name="Game_ID" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="DlcTitle" Type="String" />
                <asp:Parameter Name="Img" Type="String" />
                <asp:Parameter Name="Game_ID" Type="Int32" />
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_DlcTitle" Type="String" />
                <asp:Parameter Name="original_Img" Type="String" />
                <asp:Parameter Name="original_Game_ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" DeleteCommand="DELETE FROM [Dlc] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Dlc] ([DlcTitle], [Img], [Game_ID]) VALUES (@DlcTitle, @Img, @Game_ID)" SelectCommand="SELECT [ID], [DlcTitle], [Img], [Game_ID] FROM [Dlc] WHERE ([ID] = @ID)" UpdateCommand="UPDATE [Dlc] SET [DlcTitle] = @DlcTitle, [Img] = @Img, [Game_ID] = @Game_ID WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="DlcTitle" Type="String" />
                <asp:Parameter Name="Img" Type="String" />
                <asp:Parameter Name="Game_ID" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="ID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="DlcTitle" Type="String" />
                <asp:Parameter Name="Img" Type="String" />
                <asp:Parameter Name="Game_ID" Type="Int32" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataKeyNames="ID" DataSourceID="SqlDataSource2">
            <EditItemTemplate>
                ID:
                <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                <br />
                DlcTitle:
                <asp:TextBox ID="DlcTitleTextBox" runat="server" Text='<%# Bind("DlcTitle") %>' />
                <br />
                Img:
                <asp:TextBox ID="ImgTextBox" runat="server" Text='<%# Bind("Img") %>' />
                <br />
                Game_ID:
                <asp:TextBox ID="Game_IDTextBox" runat="server" Text='<%# Bind("Game_ID") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Aktualizuj" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Anuluj" />
            </EditItemTemplate>
            <InsertItemTemplate>
                DlcTitle:
                <asp:TextBox ID="DlcTitleTextBox" runat="server" Text='<%# Bind("DlcTitle") %>' />
                <br />
                Img:
                <asp:TextBox ID="ImgTextBox" runat="server" Text='<%# Bind("Img") %>' />
                <br />
                Game_ID:
                <asp:TextBox ID="Game_IDTextBox" runat="server" Text='<%# Bind("Game_ID") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Wstaw" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Anuluj" />
            </InsertItemTemplate>
            <ItemTemplate>
                ID:
                <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                <br />
                DlcTitle:
                <asp:Label ID="DlcTitleLabel" runat="server" Text='<%# Bind("DlcTitle") %>' />
                <br />
                Img:
                <asp:Label ID="ImgLabel" runat="server" Text='<%# Bind("Img") %>' />
                <br />
                Game_ID:
                <asp:Label ID="Game_IDLabel" runat="server" Text='<%# Bind("Game_ID") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edytuj" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Usuń" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Nowy" />
            </ItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
