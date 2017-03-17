using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Comp229_TeamProject.Pages
{
    public partial class GamePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Work around for not being able to get authentication to work. will send user to registration page if not authenticated. */
            bool isAuthenticated = (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;

            if (!isAuthenticated)
            {
                Response.Redirect("~/Pages/Registration.aspx");
            }

            /*When page Loads, create page dynamically with game name.*/
            string roomid = Request.QueryString["RoomID"];
            roomnameLbl.Text = roomid;


            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            SqlCommand getdesc = new SqlCommand("SELECT Description FROM dbo.Rooms WHERE RoomID= @room", conn);
          


            try
            {

                getdesc.Parameters.AddWithValue("@room", roomid);
                conn.Open();
                descLbl.Text = Convert.ToString(getdesc.ExecuteScalar());
                

            }

            finally
            {

                conn.Close();
            }
        }

       
        protected void joinroomnBtn_Click(object sender, EventArgs e)
        { 
            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            string roomID = Request.QueryString["RoomID"];


            int StudentID = 0;
            string username = null;
            Boolean itshere = false;

            if (Session["Uname"] != null)
            {
                username = Convert.ToString(Session["Uname"]);


            }

            
            SqlCommand addstudenttoroom = new SqlCommand("INSERT INTO dbo.roomline (roomID,StudentID) VALUES(@roomid, @SID) ", conn);
            SqlCommand removeroom = new SqlCommand("DELETE FROM dbo.roomline WHERE studentID = @SID  ", conn);
            SqlCommand getstudentid = new SqlCommand("SELECT StudentID FROM Students WHERE Username = @username", conn); 
            SqlCommand isthere = new SqlCommand("SELECT COUNT(studentID) FROM dbo.roomline WHERE studentID = @student", conn);

            try
            {
                getstudentid.Parameters.AddWithValue("@username", username);
                conn.Open();              
                StudentID = Convert.ToInt32(getstudentid.ExecuteScalar());
                isthere.Parameters.AddWithValue("@student", StudentID);
                
                if ((int)isthere.ExecuteScalar() == 0)
                {
                    itshere = false;
                }
                else
                {
                    itshere = true;
                }
            
            }
            finally
            {
                conn.Close();
            }
            
                       if (itshere == false)
                       {
                           try
                           {
               
                         addstudenttoroom.Parameters.AddWithValue("@roomid", roomID);
                         addstudenttoroom.Parameters.AddWithValue("SID", StudentID);
                            
                               conn.Open();
                               addstudenttoroom.ExecuteNonQuery();
                               
                           }

                           finally
                           {
                               conn.Close();
                           }
                       }
                       else
                       {
                         
                           try
                           {
                               removeroom.Parameters.AddWithValue("@RoomID", roomID);
                               removeroom.Parameters.AddWithValue("@SID", StudentID);

                               conn.Open();
                               removeroom.ExecuteNonQuery();
                           }
                           finally
                           {
                               conn.Close();
                           }

                       }
                      
        }

    }
}
    

            
        
    

    
