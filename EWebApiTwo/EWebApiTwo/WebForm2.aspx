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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="RelaseDate" HeaderText="RelaseDate" SortExpression="RelaseDate" />
                <asp:BoundField DataField="Img" HeaderText="Img" SortExpression="Img" />
                <asp:BoundField DataField="BackgroundImg" HeaderText="BackgroundImg" SortExpression="BackgroundImg" />
                <asp:BoundField DataField="DeveloperName" HeaderText="DeveloperName" SortExpression="DeveloperName" />
                <asp:BoundField DataField="PlatformName" HeaderText="PlatformName" SortExpression="PlatformName" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" DeleteCommand="DELETE FROM Game WHERE (ID = @original_ID)" InsertCommand="INSERT INTO [Game] ([Title], [RelaseDate], [Img], [BackgroundImg], [Platform_ID], [Developer_ID]) VALUES (@Title, @RelaseDate, @Img, @BackgroundImg, @Platform_ID, @Developer_ID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT Game.ID, Game.Title, Game.RelaseDate, Game.Img, Game.BackgroundImg, Developer.DeveloperName, Platform.PlatformName FROM Game INNER JOIN Developer ON Game.Developer_ID = Developer.ID INNER JOIN Platform ON Game.Platform_ID = Platform.ID" UpdateCommand="UPDATE Game SET Title = @Title, RelaseDate = @RelaseDate, Img = @Img, BackgroundImg = @BackgroundImg, Platform_ID = @Platform_ID, Developer_ID = @Developer_ID WHERE (ID = @original_ID) AND (Title = @original_Title) AND (RelaseDate = @original_RelaseDate) AND (Img = @original_Img) AND (BackgroundImg = @original_BackgroundImg)">
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
                <asp:Parameter Name="original_Title" Type="String" />
                <asp:Parameter DbType="Date" Name="original_RelaseDate" />
                <asp:Parameter Name="original_Img" Type="String" />
                <asp:Parameter Name="original_BackgroundImg" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>
