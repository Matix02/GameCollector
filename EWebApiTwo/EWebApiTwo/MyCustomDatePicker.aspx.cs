using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EWebApiTwo
{
    public partial class MyCustomDatePicker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CalendarControl_DayRender(object sender, DayRenderEventArgs e)
        {
            string ctrl = Request.QueryString["ctl"];
            HyperLink hpl = new HyperLink();
            hpl.Text = ((LiteralControl)e.Cell.Controls[0]).Text;
            hpl.NavigateUrl = "javascript:SetDate('" + e.Day.Date.ToShortDateString() + "','" + ctrl + "');";
            e.Cell.Controls.Clear();
            e.Cell.Controls.Add(hpl);
        }
    }
}