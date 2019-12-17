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
    public partial class AddAvatarPage : System.Web.UI.Page
    {
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection sqlMainConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ErrorMessage.Visible = false;
            ErrorMessage.ForeColor = System.Drawing.Color.Red;
            if (!string.IsNullOrEmpty(ImageTextBox.Text) || !string.IsNullOrEmpty(AvatarTextBox.Text))
            {
                string title = AvatarTextBox.Text;
                string image = ImageTextBox.Text;
                SqlConnection conn = sqlMainConnection;
                conn.Open();
                string addAvatar = "INSERT INTO [dbo].[Avatar] ([AvatarName],[Img])" +
                    "VALUES('"+ title +"'," +
                            "'"+image +"')";

                da.InsertCommand = new SqlCommand(addAvatar, conn);
                da.InsertCommand.ExecuteNonQuery();
                da.Dispose();
                conn.Close();
                ErrorMessage.ForeColor = System.Drawing.Color.DodgerBlue;
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Avatar has been added!";
            }
            else
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Something is Empty!";
            }
        }
    }
}