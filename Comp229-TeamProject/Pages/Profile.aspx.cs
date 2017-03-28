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
            bool isAuthenticated = (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;
            string role = "Student";
            if (Session["Role"] != null)
            {
                role = Session["Role"].ToString();
            }
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
            if (role == "FDESK" || role == "ADMIN")
            {
                Fdeskdiv.Visible = true;
            }
            string memberid = null;
            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            
            SqlCommand getfname = new SqlCommand("SELECT FName FROM dbo.Students WHERE Username= @user", conn);
            SqlCommand getlname = new SqlCommand("SELECT Lname FROM dbo.Students WHERE Username= @user", conn);
            SqlCommand getroom = new SqlCommand("SELECT roomID FROM dbo.roomline WHERE studentID= @sid", conn);
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
                getroom.Parameters.AddWithValue("@sid", memberid);
                roomlbl.Text = Convert.ToString(getroom.ExecuteScalar());

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
                String url = String.Format("Profile.aspx?Username={0}", user);
                Response.Redirect(url);
            }

            finally
            {

                conn.Close();


            }
        }

        protected void paybtn_Click(object sender, EventArgs e)
        {
            string username;
            if (Request.QueryString["UserName"] == null)
            {
                username = Convert.ToString(Session["Uname"]);

            }
            else
            {
                username = Request.QueryString["UserName"];

            }
            String url = String.Format("Payment.aspx?UserName={0}", username);
            Response.Redirect(url);
        }

        protected void leavebtn_Click(object sender, EventArgs e)
        {
            string user = Convert.ToString(Session["Uname"]);
            int SID;
            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            SqlCommand getstudentid = new SqlCommand("SELECT StudentID FROM Students WHERE Username = @username", conn);
            SqlCommand removeroom = new SqlCommand("DELETE FROM dbo.roomline WHERE studentID = @SID  ", conn);

         
                try
                {

                    
                    conn.Open();
                    getstudentid.Parameters.AddWithValue("@username", user);
                    SID = Convert.ToInt32(getstudentid.ExecuteScalar());
                    removeroom.Parameters.AddWithValue("@SID", SID);
                     removeroom.ExecuteNonQuery();
            }

                finally
                {
                    conn.Close();
                String url = String.Format("Profile.aspx?Username={0}", user);
                Response.Redirect(url);
            }
            
        }

        protected void Evictdiv_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            SqlCommand removeroom = new SqlCommand("DELETE FROM dbo.roomline WHERE studentID = @SID  ", conn);
            SqlCommand getstudentid = new SqlCommand("SELECT StudentID FROM Students WHERE Username = @username", conn);
            string user = "";
            int SID;

            if (Request.QueryString["UserName"] != null)
            {
                user = Convert.ToString(Request.QueryString["UserName"]);

            }
            try
            {
                conn.Open();
                getstudentid.Parameters.AddWithValue("@username", user);
                SID = Convert.ToInt32(getstudentid.ExecuteScalar());
                removeroom.Parameters.AddWithValue("@SID", SID);
                removeroom.ExecuteNonQuery();
            }

            finally
            {
                conn.Close();
                String url = String.Format("Profile.aspx?Username={0}", user);
                Response.Redirect(url);
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            SqlCommand removestudent = new SqlCommand("DELETE FROM dbo.Students WHERE studentID = @SID  ", conn);
            SqlCommand getstudentid = new SqlCommand("SELECT StudentID FROM Students WHERE Username = @username", conn);
            string user = "";
            int SID;

            if (Request.QueryString["UserName"] != null)
            {
                user = Convert.ToString(Request.QueryString["UserName"]);

            }
            try
            {
                conn.Open();
                getstudentid.Parameters.AddWithValue("@username", user);
                SID = Convert.ToInt32(getstudentid.ExecuteScalar());
                removestudent.Parameters.AddWithValue("@SID", SID);
                removestudent.ExecuteNonQuery();
            }

            finally
            {
                conn.Close();
                String url = String.Format("FdeskMain.aspx");
                Response.Redirect(url);
            }
            
             
        }
    }
}