using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EWebApiTwo
{
    public partial class AvatarList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = this.BindMenuData(0);
                DynamicMenuControlPopulation(dt, 0, null);
            }
        }
        protected DataTable BindMenuData(int parentmenuId)
        {
            //declaration of variable used  
            DataSet ds = new DataSet();
            DataTable dt;
            DataRow dr;
            DataColumn menu;
            DataColumn pMenu;
            DataColumn title;
            DataColumn description;
            DataColumn URL;

            //create an object of datatable  
            dt = new DataTable();

            //creating column of datatable with datatype  
            menu = new DataColumn("MenuId", Type.GetType("System.Int32"));
            pMenu = new DataColumn("ParentId", Type.GetType("System.Int32"));
            title = new DataColumn("Title", Type.GetType("System.String"));
            description = new DataColumn("Description", Type.GetType("System.String"));
            URL = new DataColumn("URL", Type.GetType("System.String"));

            //bind data table columns in datatable  
            dt.Columns.Add(menu);//1st column  
            dt.Columns.Add(pMenu);//2nd column  
            dt.Columns.Add(title);//3rd column  
            dt.Columns.Add(description);//4th column  
            dt.Columns.Add(URL);//5th column  

            //creating data row and assiging the value to columns of datatable  
            //1st row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 1;
            dr["ParentId"] = 0;
            dr["Title"] = "Games";
            dr["Description"] = "";
            dr["URL"] = "";
            dt.Rows.Add(dr);

            //2nd row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 2;
            dr["ParentId"] = 0;
            dr["Title"] = "DLCs";
            dr["Description"] = "";
            dr["URL"] = "";
            dt.Rows.Add(dr);

            //3rd row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 3;
            dr["ParentId"] = 0;
            dr["Title"] = "Avatars";
            dr["Description"] = "Avatars";
            dr["URL"] = "";
            dt.Rows.Add(dr);

            //4th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 4;
            dr["ParentId"] = 0;
            dr["Title"] = "Developers";
            dr["Description"] = "Develoeper";
            dr["URL"] = "";
            dt.Rows.Add(dr);

            //5th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 5;
            dr["ParentId"] = 0;
            dr["Title"] = "Users";
            dr["Description"] = "Users";
            dr["URL"] = "";
            dt.Rows.Add(dr);


            //7th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 7;
            dr["ParentId"] = 1;
            dr["Title"] = "Add";
            dr["Description"] = "Outsourcing page";
            dr["URL"] = "~/MainPage.aspx";
            dt.Rows.Add(dr);

            //8th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 8;
            dr["ParentId"] = 1;
            dr["Title"] = "List";
            dr["Description"] = "Domestic outsourcing page";
            dr["URL"] = "~/GameFullListPage.aspx";
            dt.Rows.Add(dr);

            //9th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 9;
            dr["ParentId"] = 2;
            dr["Title"] = "Add";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/AddDlc.aspx";
            dt.Rows.Add(dr);

            //10th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 9;
            dr["ParentId"] = 2;
            dr["Title"] = "List";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/DlcFullList.aspx";
            dt.Rows.Add(dr);

            //11th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 10;
            dr["ParentId"] = 3;
            dr["Title"] = "Add";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/AddAvatarPage.aspx";
            dt.Rows.Add(dr);

            //12th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 11;
            dr["ParentId"] = 3;
            dr["Title"] = "List";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/AvatarList.aspx";
            dt.Rows.Add(dr);

            //12th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 12;
            dr["ParentId"] = 4;
            dr["Title"] = "List";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/DeveloperPage.aspx";
            dt.Rows.Add(dr);

            //13th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 13;
            dr["ParentId"] = 5;
            dr["Title"] = "List";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/UserPage.aspx";
            dt.Rows.Add(dr);


            ds.Tables.Add(dt);
            var dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "ParentId='" + parentmenuId + "'";
            DataSet ds1 = new DataSet();
            var newdt = dv.ToTable();
            return newdt;
        }
        protected void DynamicMenuControlPopulation(DataTable dt, int parentMenuId, MenuItem parentMenuItem)
        {
            string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
            foreach (DataRow row in dt.Rows)
            {
                MenuItem menuItem = new MenuItem
                {
                    Value = row["MenuId"].ToString(),
                    Text = row["Title"].ToString(),
                    NavigateUrl = row["URL"].ToString(),
                    Selected = row["URL"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase)
                };
                if (parentMenuId == 0)
                {
                    Menu1.Items.Add(menuItem);
                    DataTable dtChild = this.BindMenuData(int.Parse(menuItem.Value));
                    DynamicMenuControlPopulation(dtChild, int.Parse(menuItem.Value), menuItem);
                }
                else
                {

                    parentMenuItem.ChildItems.Add(menuItem);
                    DataTable dtChild = this.BindMenuData(int.Parse(menuItem.Value));
                    DynamicMenuControlPopulation(dtChild, int.Parse(menuItem.Value), menuItem);

                }
            }
        }
    }
}