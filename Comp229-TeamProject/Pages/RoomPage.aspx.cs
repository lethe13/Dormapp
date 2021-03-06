﻿using System;
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
            bool isAuthenticated = (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                Response.Redirect("~/Pages/Registration.aspx");
            }

            string roomid = Request.QueryString["RoomID"];
            roomnameLbl.Text = roomid;


            SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
            SqlCommand getdesc = new SqlCommand("SELECT Description FROM dbo.Rooms WHERE RoomID= @room", conn);
            SqlCommand getmaxocc = new SqlCommand("SELECT maxoccupants FROM dbo.Rooms WHERE RoomID= @room", conn);



            try
            {

                getdesc.Parameters.AddWithValue("@room", roomid);
                getmaxocc.Parameters.AddWithValue("@room", roomid);
                conn.Open();
                descLbl.Text = Convert.ToString(getdesc.ExecuteScalar());
               // maxlbl.Text = Convert.ToString(getmaxocc.ExecuteScalar());


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

            int maxmembers = 0;
            int StudentID = 0;
            string username = null;
            Boolean room = false;
            Boolean itshere = false;

            if (Session["Uname"] != null)
            {
                username = Convert.ToString(Session["Uname"]);


            }

            
            SqlCommand addstudenttoroom = new SqlCommand("INSERT INTO dbo.roomline (roomID,studentID) VALUES(@roomid, @SID) ", conn);
            SqlCommand removeroom = new SqlCommand("DELETE FROM dbo.roomline WHERE studentID = @SID  ", conn);
            SqlCommand getstudentid = new SqlCommand("SELECT StudentID FROM Students WHERE Username = @username", conn); 
            SqlCommand isthere = new SqlCommand("SELECT COUNT(studentID) FROM dbo.roomline WHERE studentID = @student", conn);
            SqlCommand countmem = new SqlCommand("SELECT COUNT(studentID) FROM dbo.roomline WHERE roomID = @roomid", conn);

            try
            {
                getstudentid.Parameters.AddWithValue("@username", username);
                conn.Open();              
                StudentID = Convert.ToInt32(getstudentid.ExecuteScalar());
                isthere.Parameters.AddWithValue("@student", StudentID);
                countmem.Parameters.AddWithValue("@roomid", StudentID);

                if ((int)isthere.ExecuteScalar() == 0)
                {
                    itshere = false;
                }
                else
                {
                    itshere = true;
                }
                /*
                if ((int)countmem.ExecuteScalar() <= maxmembers)
                {
                    room = true;
                }
                else
                {
                    room = false;
                }*/
            
            }
            finally
            {
                conn.Close();
            }

            if (itshere == false)
            {/*
                if (room == true)
                {*/
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
                        String url = String.Format("RoomPage.aspx?RoomID={0}", roomID);
                        Response.Redirect(url);
                    }
                }

             
                    
              /*  }*/
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
                    String url = String.Format("RoomPage.aspx?RoomID={0}", roomID);
                    Response.Redirect(url);
                }

                }
        }

        protected void gamelistsql_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }

    }

    

            
        
    

    
