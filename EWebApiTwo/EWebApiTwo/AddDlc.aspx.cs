using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EWebApiTwo
{
    public partial class AddDlc : System.Web.UI.Page
    {

        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection sqlMainConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.Visible = false;
            ErrorMessage.ForeColor = System.Drawing.Color.Red;

        }
        private int CheckGame(String gameName)
        {
            int devId = 0;
            SqlConnection conn = sqlMainConnection;
            conn.Open();

            String developerId = "SELECT ID " +
                "FROM     dbo.[Game] " +
                "WHERE(Title = '" + gameName + "')";

            SqlCommand cmd = new SqlCommand(developerId, conn);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
               devId = Convert.ToInt32(sqlDataReader.GetValue(0));
                break;
            }
            cmd.Dispose();
            conn.Close();
            return devId;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(ImageTextBox.Text) & !string.IsNullOrEmpty(TitleTextBox.Text)
                & GameDropDownList.SelectedValue != null)
            {
                string title = TitleTextBox.Text;
                string image = ImageTextBox.Text;
                string developer = GameDropDownList.Text;
                int b = CheckGame(developer);

                SqlConnection conn = sqlMainConnection;
                conn.Open();
                string addAvatar = "INSERT INTO [dbo].[Dlc]([DlcTitle],[Img],[Game_ID])" +
                    "VALUES('" + title + "'," +
                            "'" + image + "'," +
                            "'" + b.ToString() + "')";

                da.InsertCommand = new SqlCommand(addAvatar, conn);
                da.InsertCommand.ExecuteNonQuery();
                da.Dispose();
                conn.Close();

                ErrorMessage.ForeColor = System.Drawing.Color.DodgerBlue;
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Dlc has been added!";
            }
            else
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Something is Empty!";
            }
        }
    }
}