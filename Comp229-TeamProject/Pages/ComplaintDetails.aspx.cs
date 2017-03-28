using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_TeamProject.Pages
{
    public partial class ComplaintDetails : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=dormapp.database.windows.net;Initial Catalog=Dorms;Persist Security Info=True;User ID=dormapp;Password=Magnum123");

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isAuthenticated = (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;

            if (!isAuthenticated)
            {
                Response.Redirect("~/Pages/Registration.aspx");
            }
            SqlCommand getdetails = new SqlCommand("SELECT complaintDescription FROM dbo.Complaints WHERE complaintID= @id", conn);
            string id = Request.QueryString["complaintID"];
            try
            {

                
                conn.Open();
                getdetails.Parameters.AddWithValue("@id", id);
                detailslbl.Text = Convert.ToString(getdetails.ExecuteScalar());

            }

            finally
            {

                conn.Close();
            }
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            SqlCommand deletedetails = new SqlCommand("DELETE FROM dbo.Complaints WHERE complaintID= @id", conn);
            string id = Request.QueryString["complaintID"];
            try
            {


                conn.Open();
                deletedetails.Parameters.AddWithValue("@id", id);
                deletedetails.ExecuteScalar();

            }

            finally
            {

                conn.Close();
                Response.Redirect("~/Pages/FdeskMain.aspx");
            }
        }
    }
}