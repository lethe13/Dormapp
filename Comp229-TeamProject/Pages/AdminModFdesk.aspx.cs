using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dormapp
{
    public partial class AdminModFdesk : System.Web.UI.Page
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

           
            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");

            SqlCommand getfname = new SqlCommand("SELECT FName FROM dbo.Fdesk WHERE FdeskID= @user", conn);
            SqlCommand getlname = new SqlCommand("SELECT Lname FROM dbo.Fdesk WHERE FdeskID= @user", conn);

            profilename.Text = username;
            try
            {

                getfname.Parameters.AddWithValue("@user", username);
                getlname.Parameters.AddWithValue("@user", username);
                conn.Open();
                fnamelbl.Text = Convert.ToString(getfname.ExecuteScalar());
                lnamelbl.Text = Convert.ToString(getlname.ExecuteScalar());
               

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
                SqlCommand updatefname = new SqlCommand("UPDATE Fdesk SET FName = @FName WHERE FdeskID = @username", conn);
                SqlCommand updatelname = new SqlCommand("UPDATE Fdesk SET LName = @LName WHERE FdeskID = @username", conn);
                SqlCommand updatepass = new SqlCommand("UPDATE Fdesk SET Password = @pass WHERE FdeskID = @username", conn);

                string username = Request.QueryString["UserName"];
                string lastName = lnamebx.Text;
                string firstName = fnamebx.Text;
                string pass = passbx.Text;


                try
                {
                    updatefname.Parameters.AddWithValue("@FName", firstName);
                    updatefname.Parameters.AddWithValue("@username", username);
                    updatelname.Parameters.AddWithValue("@LName", lastName);
                    updatelname.Parameters.AddWithValue("@username", username);
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
                    String url = String.Format("AdminModFdesk.aspx?UserName={0}", username);
                    Response.Redirect(url);
                }

            }
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            SqlCommand delete = new SqlCommand("DELETE FROM Fdesk WHERE FdeskID = @username", conn);
            string username = Request.QueryString["UserName"];
            try
            {
                delete.Parameters.AddWithValue("@username", username);


                conn.Open();


                delete.ExecuteNonQuery();

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
                String url = String.Format("AdminMain.aspx");
                Response.Redirect(url);
            }
        }
    }
}