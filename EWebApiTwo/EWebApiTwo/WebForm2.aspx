<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="EWebApiTwo.WebForm2" %>

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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="RelaseDate" HeaderText="RelaseDate" SortExpression="RelaseDate" />
                <asp:BoundField DataField="Img" HeaderText="Img" SortExpression="Img" />
                <asp:BoundField DataField="BackgroundImg" HeaderText="BackgroundImg" SortExpression="BackgroundImg" />
                <asp:BoundField DataField="DeveloperName" HeaderText="DeveloperName" SortExpression="DeveloperName" />
                <asp:BoundField DataField="PlatformName" HeaderText="PlatformName" SortExpression="PlatformName" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" DeleteCommand="DELETE FROM Game WHERE (ID = @original_ID)" InsertCommand="INSERT INTO [Game] ([Title], [RelaseDate], [Img], [BackgroundImg], [Platform_ID], [Developer_ID]) VALUES (@Title, @RelaseDate, @Img, @BackgroundImg, @Platform_ID, @Developer_ID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT Game.ID, Game.Title, Game.RelaseDate, Game.Img, Game.BackgroundImg, Developer.DeveloperName, Platform.PlatformName FROM Game INNER JOIN Developer ON Game.Developer_ID = Developer.ID INNER JOIN Platform ON Game.Platform_ID = Platform.ID" UpdateCommand="UPDATE Game 
SET Title = @Title, RelaseDate = @RelaseDate, Img = @Img, BackgroundImg = @BackgroundImg, Platform_ID = @Platform_ID, Developer_ID = @Developer_ID 
WHERE (ID = @original_ID) AND (Platform_ID = @original_Platform_ID) AND (Developer_ID = @original_Developer_ID) ">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
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
                <asp:Parameter Name="original_Platform_ID" />
                <asp:Parameter Name="original_Developer_ID" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" DeleteCommand="DELETE FROM [Game] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Game] ([Title], [RelaseDate], [Img], [BackgroundImg], [Platform_ID], [Developer_ID]) VALUES (@Title, @RelaseDate, @Img, @BackgroundImg, @Platform_ID, @Developer_ID)" SelectCommand="SELECT [ID], [Title], [RelaseDate], [Img], [BackgroundImg], [Platform_ID], [Developer_ID] FROM [Game] WHERE ([ID] = @ID)" UpdateCommand="UPDATE [Game] SET [Title] = @Title, [RelaseDate] = @RelaseDate, [Img] = @Img, [BackgroundImg] = @BackgroundImg, [Platform_ID] = @Platform_ID, [Developer_ID] = @Developer_ID WHERE [ID] = @ID">
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT [ID], [PlatformName] FROM [Platform]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT [ID], [DeveloperName] FROM [Developer]"></asp:SqlDataSource>
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataKeyNames="ID" DataSourceID="SqlDataSource2">
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
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3" DataTextField="PlatformName" DataValueField="ID" SelectedValue='<%# Bind("Platform_ID") %>'>
                </asp:DropDownList>
                <br />
                Developer_ID:
                <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource4" DataTextField="DeveloperName" DataValueField="ID" SelectedValue='<%# Bind("Developer_ID") %>'>
                </asp:DropDownList>
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Aktualizuj" />
&nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Anuluj" />
            </EditItemTemplate>
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
        </asp:FormView>
    </form>
</body>
</html>
