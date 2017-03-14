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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.Name != null)
            {

            }
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            /*Creates a new user*/
            if (Page.IsValid)

            {
                SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
                SqlCommand addUser = new SqlCommand("INSERT INTO Students(Lname,FName,Username, Password) VALUES(@lastName ,@firstName,@username, @pwd)", conn);

                String lastName = lastNameTB.Text;
                String firstName = firstNameTB.Text;
                String username = regUsernameTB.Text;        
                String pass = regPasswordTB.Text;

                try
                {
                    addUser.Parameters.AddWithValue("@lastName", lastName);
                    addUser.Parameters.AddWithValue("@firstName", firstName);
                    addUser.Parameters.AddWithValue("@username", username);
                    addUser.Parameters.AddWithValue("@pwd", pass);
                    
                    conn.Open();
                    addUser.ExecuteNonQuery();
                    WarningLbl.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                /*  catch (SqlException ex)
                  {

                 }*/
                catch (Exception exception)
                {
                    WarningLbl.Text = exception.Message.ToString();
                }
                finally
                {
                    conn.Close();
                }

           }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            /*Check user credentical and login*/
            SqlConnection connection = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            SqlCommand checkUser = new SqlCommand("Select Username FROM Dorms.[dbo].Students WHERE Username = @username", connection);
            SqlCommand checkPassword = new SqlCommand("Select Password FROM Dorms.[dbo].Students WHERE Username = @username", connection);

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
                        Response.Redirect("~/Pages/Homepage.aspx");
                        
                    }
                }
                else
                {
                    WarningLblLogin.Text = "No username was found";
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