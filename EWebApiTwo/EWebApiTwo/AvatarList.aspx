<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvatarList.aspx.cs" Inherits="EWebApiTwo.AvatarList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        Avatar List<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="AvatarName" HeaderText="AvatarName" SortExpression="AvatarName" />
                <asp:BoundField DataField="Img" HeaderText="Img" SortExpression="Img" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" DeleteCommand="DELETE FROM [Avatar] WHERE [ID] = @original_ID AND [AvatarName] = @original_AvatarName AND [Img] = @original_Img" InsertCommand="INSERT INTO [Avatar] ([AvatarName], [Img]) VALUES (@AvatarName, @Img)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Avatar]" UpdateCommand="UPDATE [Avatar] SET [AvatarName] = @AvatarName, [Img] = @Img WHERE [ID] = @original_ID AND [AvatarName] = @original_AvatarName AND [Img] = @original_Img">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_AvatarName" Type="String" />
                <asp:Parameter Name="original_Img" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="AvatarName" Type="String" />
                <asp:Parameter Name="Img" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="AvatarName" Type="String" />
                <asp:Parameter Name="Img" Type="String" />
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_AvatarName" Type="String" />
                <asp:Parameter Name="original_Img" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        Jak te z labów, gdzie były obrazy do wyświetlenia komputerów</form>
</body>
</html>
