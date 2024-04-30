using Amazon.Runtime.Internal.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = Request[ "txtEmail"].Trim();
            string password = Request["txtPassword"].Trim();

            // Validate email and password (you may add more validation logic if needed)
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                //lblMessage.Text = "Please enter both email and password.";
                return;
            }

            // Check if the credentials match any record in the database table "Users"
            string connectionString = "your_connection_string_here"; // Update this with your actual connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Redirect to viewUsers.aspx if credentials match
                        Response.Redirect("viewUsers.aspx");
                    }
                    else
                    {
                        // Display error message if credentials are invalid
                        //lblMessage.Text = "Invalid credentials.";
                    }
                }
            }
        }
    }
}