<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DlcFullList.aspx.cs" Inherits="EWebApiTwo.DlcFullList" %>

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
        Dlc List<asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="DlcTitle" HeaderText="DlcTitle" SortExpression="DlcTitle" />
                <asp:BoundField DataField="Img" HeaderText="Img" SortExpression="Img" />
                <asp:BoundField DataField="Game_ID" HeaderText="Game_ID" SortExpression="Game_ID" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" DeleteCommand="DELETE FROM [Dlc] WHERE [ID] = @original_ID AND [DlcTitle] = @original_DlcTitle AND [Img] = @original_Img AND [Game_ID] = @original_Game_ID" InsertCommand="INSERT INTO [Dlc] ([DlcTitle], [Img], [Game_ID]) VALUES (@DlcTitle, @Img, @Game_ID)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Dlc]" UpdateCommand="UPDATE [Dlc] SET [DlcTitle] = @DlcTitle, [Img] = @Img, [Game_ID] = @Game_ID WHERE [ID] = @original_ID AND [DlcTitle] = @original_DlcTitle AND [Img] = @original_Img AND [Game_ID] = @original_Game_ID">
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
    </form>
</body>
</html>
