<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameFullListPage.aspx.cs" Inherits="EWebApiTwo.FullListGamePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body{
            padding:50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            Full Game List</div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Expr1" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
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
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="50px" Width="125px">
            <AlternatingRowStyle BackColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:DetailsView>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" SelectCommand="SELECT Game.ID AS Expr1, Game.Title, Game.RelaseDate, Game.Img, Game.BackgroundImg, Platform.PlatformName,Developer.DeveloperName FROM Developer INNER JOIN Game ON Developer.ID = Game.Developer_ID INNER JOIN Platform ON Game.Platform_ID = Platform.ID"></asp:SqlDataSource>
        <br />
        Może dodać grafiki, o ile przy Avatarach się uda.</form>
</body>
</html>
