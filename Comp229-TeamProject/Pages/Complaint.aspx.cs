using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamProject.Pages
{
    public partial class Complaint : System.Web.UI.Page
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
            if(role == "FDESK" || role == "ADMIN")
            {
                Response.Redirect("~/Pages/FdeskComplaints.aspx");
            }
        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
            /*Creates a new user*/
            if (Page.IsValid)

            {
                SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");
                SqlCommand addComp = new SqlCommand("INSERT INTO Complaints(complaintDescription) VALUES(@complaint)", conn);
                String Complaint = complaintbx.Text;


                try
                {
                    addComp.Parameters.AddWithValue("@complaint", Complaint);
                    conn.Open();
                    addComp.ExecuteNonQuery();

                }

                catch (Exception exception)
                {
                    Label1.Text = exception.Message.ToString();
                }
                finally
                {
                    conn.Close();
                    Label1.Text = "successful";
                   Response.Redirect("~/Pages/HomePage.aspx");
                }
            }
        }
    }
}