using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamProject.Pages
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.Name != null)
            {

            }
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            /*Check user credentical and login*/
            SqlConnection connection = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            SqlCommand checkUser = new SqlCommand("Select AdminID FROM Dorms.[dbo].Admin WHERE AdminID = @username", connection);
            SqlCommand checkPassword = new SqlCommand("Select Password FROM Dorms.[dbo].Admin WHERE AdminID = @username", connection);

            checkUser.Parameters.Add("@username", SqlDbType.NVarChar);
            checkUser.Parameters["@username"].Value = loginUsernameTB.Text;

            checkPassword.Parameters.Add("@username", SqlDbType.NVarChar);
            checkPassword.Parameters["@username"].Value = loginUsernameTB.Text;

            try
            {
                connection.Open();
                string username = checkUser.ExecuteScalar().ToString();

                if (username != null && String.Equals(username, loginUsernameTB.Text))
                {
                    string password = checkPassword.ExecuteScalar().ToString();

                    if (password != null && String.Equals(password, loginPasswordTB.Text))
                    {
                        FormsAuthentication.SetAuthCookie(username, true);
                        Session["Uname"] = username;
                        Session["Role"] = "ADMIN";
                        Response.Redirect("~/Pages/Adminmain.aspx");

                    }
                }
                else
                {
                    WarningLblLogin.Text = "No ID was found";
                }

            }
            catch (Exception exception)
            {
                WarningLblLogin.Text = exception.Message.ToString();
            }
            finally
            {
                connection.Close();
            }


        }
    }
}
