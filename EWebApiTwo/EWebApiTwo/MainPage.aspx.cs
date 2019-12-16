using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace EWebApiTwo
{
    public partial class MainPage : System.Web.UI.Page
    {
        SqlConnection sqlMainConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
        String[] platfromsTab = new String[5];
        String developer;
        int count = 0;
        SqlCommand cmd1;
        SqlDataAdapter da = new SqlDataAdapter();


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
            dr["URL"] = "~/Home.aspx";
            dt.Rows.Add(dr);

            //2nd row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 2;
            dr["ParentId"] = 0;
            dr["Title"] = "DLCs";
            dr["Description"] = "";
            dr["URL"] = "~/Customer.aspx";
            dt.Rows.Add(dr);

            //3rd row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 3;
            dr["ParentId"] = 0;
            dr["Title"] = "Avatars";
            dr["Description"] = "Avatars";
            dr["URL"] = "~/AboutUs.aspx";
            dt.Rows.Add(dr);

            //4th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 4;
            dr["ParentId"] = 0;
            dr["Title"] = "Developers";
            dr["Description"] = "Develoeper";
            dr["URL"] = "~/Contact.aspx";
            dt.Rows.Add(dr);

            //5th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 5;
            dr["ParentId"] = 0;
            dr["Title"] = "Users";
            dr["Description"] = "Users";
            dr["URL"] = "~/Testimonial.aspx";
            dt.Rows.Add(dr);


            //7th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 7;
            dr["ParentId"] = 1;
            dr["Title"] = "Add";
            dr["Description"] = "Outsourcing page";
            dr["URL"] = "~/Outsource.aspx";
            dt.Rows.Add(dr);

            //8th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 8;
            dr["ParentId"] = 1;
            dr["Title"] = "List";
            dr["Description"] = "Domestic outsourcing page";
            dr["URL"] = "~/Domestic.aspx";
            dt.Rows.Add(dr);

            //9th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 9;
            dr["ParentId"] = 2;
            dr["Title"] = "Add";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/International.aspx";
            dt.Rows.Add(dr);

            //10th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 9;
            dr["ParentId"] = 2;
            dr["Title"] = "List";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/International.aspx";
            dt.Rows.Add(dr);

            //11th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 10;
            dr["ParentId"] = 3;
            dr["Title"] = "Add";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/International.aspx";
            dt.Rows.Add(dr);

            //12th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 11;
            dr["ParentId"] = 3;
            dr["Title"] = "List";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/International.aspx";
            dt.Rows.Add(dr);

            //12th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 12;
            dr["ParentId"] = 4;
            dr["Title"] = "List";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/International.aspx";
            dt.Rows.Add(dr);

            //13th row of data table  
            dr = dt.NewRow();
            dr["MenuId"] = 13;
            dr["ParentId"] = 5;
            dr["Title"] = "List";
            dr["Description"] = "International outsourcing page";
            dr["URL"] = "~/International.aspx";
            dt.Rows.Add(dr);


            ds.Tables.Add(dt);
            var dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "ParentId='" + parentmenuId + "'";
            DataSet ds1 = new DataSet();
            var newdt = dv.ToTable();
            return newdt;
        }

        /// <summary>  
        /// This is a recursive function to fetchout the data to create a menu from data table  
        /// </summary>  
        /// <param name="dt">datatable</param>  
        /// <param name="parentMenuId">parent menu Id of integer type</param>  
        /// <param name="parentMenuItem"> Menu Item control</param>  
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
            //AddButton
            protected void Button4_Click(object sender, EventArgs e)
        {
            NewDeveloperTextBox.Visible = true;
            DeleteButton.Visible = true;
            DeveloperDropDownList.Enabled = false;
            AddButton.Enabled = false;
        }
        //DeleteButton
        protected void Button1_Click(object sender, EventArgs e)
        {
            DeleteButton.Visible = false;
            NewDeveloperTextBox.Visible = false;
            DeveloperDropDownList.Enabled = true;
            AddButton.Enabled = true;
        }
        //ConfirmButton
        protected void Button3_Click(object sender, EventArgs e)
        {
            ErrorMessage.Visible = false;
            ErrorMessage.ForeColor = System.Drawing.Color.Red;
            try
            {
                if (!string.IsNullOrEmpty(TitleTextBox.Text))
                {

                    if(PlatformCheckBoxList.SelectedValue.Equals(false))
                    {
                        ErrorMessage.Visible = true;
                        ErrorMessage.Text = "The Game has no Platform!";
                    }
                    else
                    {
                        if(!string.IsNullOrEmpty(ImageCoverTextBox.Text) || !string.IsNullOrEmpty(ImageBgTextBox.Text))
                        {
                            if (!string.IsNullOrEmpty(txtDate.Text))
                            {
                                string title = TitleTextBox.Text;
                                string relaseDate = txtDate.Text;
                                string imgCover = ImageCoverTextBox.Text;
                                string imgBg = ImageBgTextBox.Text;

                                if (NewDeveloperTextBox.Visible == true)
                                {
                                    developer = NewDeveloperTextBox.Text;
                                    SqlConnection conn = sqlMainConnection;
                                    conn.Open();
                                    string addDev = "INSERT INTO[dbo].[Developer]([DeveloperName])" +
                                        "VALUES ('"+ developer +"')";
                                    da.InsertCommand = new SqlCommand(addDev, conn);
                                    da.InsertCommand.ExecuteNonQuery();
                                    da.Dispose();
                                    conn.Close();
                                }
                                else
                                    developer = DeveloperDropDownList.Text;

                                int b = CheckDeveloper(developer);

                                for (int i = 0; i < PlatformCheckBoxList.Items.Count; i++)
                                    {
                                        if (PlatformCheckBoxList.Items[i].Selected)
                                        {
                                            platfromsTab[i] = (PlatformCheckBoxList.Items[i].ToString());
                                            count++;
                                        }
                                    }
                                if(count == 0)
                                {
                                    ErrorMessage.Visible = true;
                                    ErrorMessage.Text = "Choose a least one platform!";
                                }
                                else
                                {
                                SqlConnection conn = sqlMainConnection;
                                conn.Open();
                                
                                for (int i=0; i<count; i++)
                                {
                                    string addGameSql = "INSERT INTO[dbo].[Game]([Title],[RelaseDate],[Img],[BackgroundImg],[Platform_ID],[Developer_ID]) VALUES" +
                                        "('"+ title +"'" +
                                        ", '"+ relaseDate + "'" +
                                        ", '" + imgCover+"'" +
                                        ", '" + imgBg +"'" +
                                        ", '" + CheckPlatforms(platfromsTab[i]).ToString()+"'" +
                                        ", '" +b.ToString()+ "' )";


                                    da.InsertCommand = new SqlCommand(addGameSql, conn);
                                    da.InsertCommand.ExecuteNonQuery();
                                    da.Dispose();

                                }
                                conn.Close();
                                ErrorMessage.ForeColor = System.Drawing.Color.DodgerBlue;
                                ErrorMessage.Text = "Your game has been added!";
                                ErrorMessage.Visible = true;
                            }
                            }
                            else
                            {
                                ErrorMessage.Visible = true;
                                ErrorMessage.Text = "Empty Relase Date!";
                            }
                        }
                        else
                        {
                            ErrorMessage.Visible = true;
                            ErrorMessage.Text = "Empty Image Background or Cover!";
                        }
                    }
                }
                else
                {
                    ErrorMessage.Visible = true;
                    ErrorMessage.Text = "Empty Title of Game!";
                }
            }
            catch(Exception ex)
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Something Went Completely Wrong! <br>" + ex.ToString();
            }
        }

        private int CheckPlatforms(String platformaDrop)
        {
            switch (platformaDrop)
            {
                case "Ps4":
                    return 4;

                case "Pc":
                    return 1;

                case "Ps3":
                    return 3;

                case "Xbox360":
                    return 5;

                case "Xbox One":
                    return 2;

                default:
                    return 1;
            }
        }
        private int CheckDeveloper(String developerName)
        {
            int devId = 0;
            SqlConnection conn = sqlMainConnection;
            conn.Open();

            String developerId = "SELECT ID " +
                "FROM     dbo.[Developer]" +
                "WHERE(DeveloperName = '" +developerName+ "')";
            
            SqlCommand cmd = new SqlCommand(developerId, conn) ;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                devId =  Convert.ToInt32(sqlDataReader.GetValue(0));
            }
            cmd.Dispose();
            conn.Close();
            return devId;
        }

        protected void PlatformCheckBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
/**** Zapasowy sqlCommand 
 *                                     string addGameSql = "INSERT INTO[dbo].[Game]([Title],[RelaseDate],[Img],[BackgroundImg],[Platform_ID],[Developer_ID])VALUES" +
                                        "(<Title, varchar(50),> " +
                                        ",<RelaseDate, date,>" +
                                        ",<Img, text,>" +
                                        ",<BackgroundImg, text,>" +
                                        ",<Platform_ID, int,>" +
                                        ",<Developer_ID, int,>)";
*/
/* String developerId = "SELECT ID " +
                         "FROM dbo.Developer" +
                         "WHERE(DeveloperName = '"+ developerName +"') AND EXISTS" +
                             "(SELECT ID, DeveloperName" +
                             "FROM      dbo.Developer" +
                             "WHERE   (DeveloperName = '" + developerName+ "'))";*/
/*  String checkDeveloper = "SELECT COUNT(*) " +
 "FROM dbo.Developer" +
  "WHERE(DeveloperName = 'The Coalition') AND EXISTS" +
     "(SELECT ID, DeveloperName" +
     "FROM      dbo.Developer AS Developer_1" +
     "WHERE   (DeveloperName = '" + DeveloperDropDownList +"'))";
*/
/*string addGameSql = "INSERT INTO[dbo].[Game]([Title],[RelaseDate],[Img],[BackgroundImg],[Platform_ID],[Developer_ID]) VALUES" +
    "('" + title + "'" +
    ", '" + relaseDate + "'" +
    ", '" + imgCover + "'" +
    ", '" + imgBg + "'" +
    ", '" + CheckPlatforms(platfromsTab[i]).ToString() + "'" +
    ", '" + b.ToString() + "' , @@IDENTITY) SELECT SCOPE_IDENTITY()";*/
