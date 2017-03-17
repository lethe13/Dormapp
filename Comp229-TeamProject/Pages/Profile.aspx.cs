using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamProject.Pages
{
    public partial class Profile : System.Web.UI.Page
    {
  
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Work around for not being able to get authentication to work. will send user to registration page if not authenticated. */
            bool isAuthenticated = (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;

            if (!isAuthenticated)
            {
                Response.Redirect("~/Pages/Registration.aspx");
            }
            string username = "oops";
            
        
            if (Request.QueryString["UserName"] == null)
            {
                username = Convert.ToString(Session["Uname"]);
                
            }
            else
                {
               username = Request.QueryString["UserName"];
              
                }
            if (username == Convert.ToString(Session["Uname"]))
            {
                editbtndiv.Visible = true;
            }
            string memberid = null;
            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            
            SqlCommand getfname = new SqlCommand("SELECT FName FROM dbo.Students WHERE Username= @user", conn);
            SqlCommand getlname = new SqlCommand("SELECT Lname FROM dbo.Students WHERE Username= @user", conn);

            SqlCommand getid = new SqlCommand("SELECT StudentID FROM dbo.Students WHERE Username= @user", conn);

            profileName.Text = username;
            try
            {

                getfname.Parameters.AddWithValue("@user", username);
                getlname.Parameters.AddWithValue("@user", username);
                getid.Parameters.AddWithValue("@user", username);
                conn.Open();
                Fnamelbl.Text = Convert.ToString(getfname.ExecuteScalar());
                Lnamelbl.Text = Convert.ToString(getlname.ExecuteScalar());
                memberid = Convert.ToString(getid.ExecuteScalar());
           
            }

            finally
            {

                conn.Close();
            }




        }

        protected void editbtn_Click(object sender, EventArgs e)
        {
            /*  if (editbtndiv.Visible == true)
              {
                  editdiv.Visible = false;
              }
              else
              {
                  editdiv.Visible = true;
              }*/
            editdiv.Visible = true;
        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            //update user
            string user = Request.QueryString["UserName"];
            string fname = Fnamebx.Text;
            string lname = Lnamebx.Text;
            string username;
            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            SqlCommand updateuser = new SqlCommand("UPDATE Students SET FName = @fname, Lname = @fname WHERE Username = @user", conn);

            if (Request.QueryString["UserName"] == null)
            {
                username = Convert.ToString(Session["Uname"]);
            }
            else
            {
                username = Request.QueryString["UserName"];
            }
            try
            {


                updateuser.Parameters.AddWithValue("@fname", fname);
                updateuser.Parameters.AddWithValue("@lname", lname);
                
                updateuser.Parameters.AddWithValue("@user", username);

                conn.Open();
                updateuser.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
            }

            finally
            {

                conn.Close();


            }
        }
    }
}