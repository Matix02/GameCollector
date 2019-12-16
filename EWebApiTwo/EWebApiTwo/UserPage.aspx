<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="EWebApiTwo.UserPage" %>

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
        User List<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Nickname" HeaderText="Nickname" SortExpression="Nickname" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="Avatar" HeaderText="Avatar" SortExpression="Avatar" />
            </Columns>
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
