using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EWebApiTwo
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        int temp = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            emptyLabel.Visible = false;
            try
            {
                if (!string.IsNullOrEmpty(emailTextBox.Text) || !string.IsNullOrEmpty(passwordTextBox.Text))
                {
                    string email = emailTextBox.Text.Trim();
                    string password = passwordTextBox.Text.Trim();
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
                    conn.Open();
                    string checkuser = "SELECT count(*) FROM dbo.[User] WHERE EXISTS " +
                                        "(SELECT * FROM dbo.[User]" +
                                            "WHERE (Email = '" + email + "') AND (Password ='" + password + "') AND (Type = 'admin'))";
                    SqlCommand cmd = new SqlCommand(checkuser, conn);
                    temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                    if (temp == 1)//Do poprawy komunikaty
                    {
                        Response.Write("Nice!");

                    }
                    else if (temp == 0)//Do poprawy komunikaty
                    {
                        Response.Write("Wrong Email or Password or You are not an administrator");
                    }
                    cmd.Dispose();
                    conn.Close();
                }
                else
                {
                    emptyLabel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error" + ex.ToString());
            }
        }
            /***** poprawny rekord !!!!, zmienić również przy LoginPage'u 
             * SELECT COUNT(*) AS Expr1
FROM     dbo.Developer
WHERE  (DeveloperName = 'The Coalition') AND EXISTS
                      (SELECT ID, DeveloperName
                       FROM      dbo.Developer AS Developer_1
                       WHERE   (DeveloperName = 'Hangar 13'))*/
             
    }
}
/**** Wyswietlenie rekordów z tabeli 
 *                 SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnectionString"].ConnectionString);
                conn.Open();
                string checkuser = "SELECT Email, Password FROM dbo.[User]";
                SqlCommand cmd = new SqlCommand(checkuser, conn);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
               
                while (sqlDataReader.Read())
                {
                    output = output + sqlDataReader.GetValue(0) + " " + sqlDataReader.GetValue(1) + "</br>";
                }

                Label1.Text = output;
                cmd.Dispose();
                conn.Close();
*/
