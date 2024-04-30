using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebApplication1.Pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the form was submitted
            if (IsPostBack)
            {
                // Extract email and password from the form
                string email = Request.Form["txtEmail"];
                string password = Request.Form["txtPassword"];

                // Validate email and password
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    // Check credentials in the database
                    if (ValidateCredentials(email, password))
                    {
                        // Redirect to viewUsers.aspx if credentials are valid
                        Response.Redirect("viewUsers.aspx");
                    }
                    else
                    {
                        // Display error message for invalid credentials
                        lblErrorMessage.Text = "Invalid credentials";
                    }
                }
            }
        }

        private bool ValidateCredentials(string email, string password)
        {
            // Connection string to your database
            string connectionString = "Data Source=erwin\\MSSQLSERVER01;Initial Catalog=erwin;User Id=erwin17;Password=erwin@1998;";


            // SQL query to check if email and password match any record in the Users table
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";

            // Assuming you store passwords securely (e.g., hashed), you should hash the password before comparing it in the query

            // Initialize a variable to hold the result of the query
            int count = 0;

            // Create and open a connection to the database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query to prevent SQL injection
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    // Open the connection
                    connection.Open();

                    // Execute the query and store the result
                    count = (int)command.ExecuteScalar();
                }
            }

            // If count > 0, it means the credentials are valid
            return count > 0;
        }
    }
}
