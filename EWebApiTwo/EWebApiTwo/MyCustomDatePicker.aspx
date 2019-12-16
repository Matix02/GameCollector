<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCustomDatePicker.aspx.cs" Inherits="EWebApiTwo.MyCustomDatePicker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script type="text/javascript">
        function SetDate(dateValue, ctl) {
            thisForm = window.opener.document.forms[0].elements[ctl].value = dateValue;
            self.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Calendar ID="CalendarControl" runat="server" BackColor="#FFFFCC" 
        BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
        Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
        ondayrender="CalendarControl_DayRender" ShowGridLines="True" Width="220px">
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
            ForeColor="#FFFFCC" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
    </asp:Calendar>
        </div>
    </form>
</body>
</html>
