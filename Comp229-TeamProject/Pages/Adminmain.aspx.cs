using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamProject.Pages
{
    public partial class Adminmain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Register_Click(object sender, EventArgs e)
        {
            /*Creates a new user*/
            if (Page.IsValid)

            {
                SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
                SqlCommand addUser = new SqlCommand("INSERT INTO Fdesk(Fname,LName, Password) VALUES(@lastName ,@firstName, @pwd)", conn);

                String lastName = lastNameTB.Text;
                String firstName = firstNameTB.Text;
                String pass = regPasswordTB.Text;

                try
                {
                    addUser.Parameters.AddWithValue("@lastName", lastName);
                    addUser.Parameters.AddWithValue("@firstName", firstName);
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
    }
}