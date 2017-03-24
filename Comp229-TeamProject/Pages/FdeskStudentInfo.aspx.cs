using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamProject.Pages
{
    public partial class FdeskStudentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = "oops";


            if (Request.QueryString["UserName"] == null)
            {
                username = Convert.ToString(Session["Uname"]);

            }
            else
            {
                username = Request.QueryString["UserName"];

            }
          
            string memberid = null;
            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");

            SqlCommand getfname = new SqlCommand("SELECT FName FROM dbo.Students WHERE Username= @user", conn);
            SqlCommand getlname = new SqlCommand("SELECT Lname FROM dbo.Students WHERE Username= @user", conn);

            SqlCommand getid = new SqlCommand("SELECT StudentID FROM dbo.Students WHERE Username= @user", conn);
            profilename.Text = username;
            try
            {

                getfname.Parameters.AddWithValue("@user", username);
                getlname.Parameters.AddWithValue("@user", username);
                getid.Parameters.AddWithValue("@user", username);
                conn.Open();
                fnamelbl.Text = Convert.ToString(getfname.ExecuteScalar());
                lnamelbl.Text = Convert.ToString(getlname.ExecuteScalar());
                memberid = Convert.ToString(getid.ExecuteScalar());

            }

            finally
            {

                conn.Close();
            }
        }

        protected void Updatebx_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)

            {
                SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
                SqlCommand updatefname = new SqlCommand("UPDATE Students SET FName = @FName WHERE Username = @username", conn);
                SqlCommand updatelname = new SqlCommand("UPDATE Students SET LName = @LName WHERE Username = @username", conn);
                SqlCommand updateuname = new SqlCommand("UPDATE Students SET Username = @newuser WHERE Username = @username", conn);
                SqlCommand updatepass = new SqlCommand("UPDATE Students SET Password = @pass WHERE Username = @username", conn);

                string username = Request.QueryString["UserName"];
                string lastName = lnamebx.Text;
                string firstName = fnamebx.Text;
                string newusername = usernamebx.Text;
                string pass = passbx.Text;
                

                try
                {
                    updatefname.Parameters.AddWithValue("@FName", firstName);
                    updatefname.Parameters.AddWithValue("@username", username);
                    updatelname.Parameters.AddWithValue("@LName", lastName);
                    updatelname.Parameters.AddWithValue("@username", username);
                    updateuname.Parameters.AddWithValue("@newuser", newusername);
                    updateuname.Parameters.AddWithValue("@username", username);
                    updatepass.Parameters.AddWithValue("@FName", firstName);
                    updatepass.Parameters.AddWithValue("username", username);

                    conn.Open();
                    if (fnamebx.Text != "")
                    {
                        updatefname.ExecuteNonQuery();
                    }
                    if (lnamebx.Text != "")
                    {
                        updatelname.ExecuteNonQuery();
                    }
                    if (passbx.Text != "")
                    {
                        updatepass.ExecuteNonQuery();
                    }
                    if (usernamebx.Text != "")
                    {
                        updateuname.ExecuteNonQuery();
                    }
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
                    if (usernamebx.Text != "")
                    {
                        username = newusername;
                        
                    }
                  
                   String url = String.Format("FdeskStudentInfo.aspx?UserName={0}", username);
                    Response.Redirect(url);
                }

            }
        }
    }
}