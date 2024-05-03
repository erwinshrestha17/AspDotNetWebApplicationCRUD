using System;
using System.Data;
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
        else
        {
            // Display error message for empty email or password fields
            lblErrorMessage.Text = "Please enter both email and password";
        }
    }
}

private bool ValidateCredentials(string email, string password)
{
    try
    {
        // Connection string to your database
        string connectionString = "YourConnectionString";

        // Stored procedure name
        string storedProcedureName = "CheckUserCredentialsLogin";

        // Create a SqlConnection object
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create a SqlCommand object for the stored procedure
            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                // Specify the command type as stored procedure
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                // Add an output parameter to retrieve the result
                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@UserCount";
                outputParameter.SqlDbType = SqlDbType.Int;
                outputParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(outputParameter);

                // Open the connection
                connection.Open();

                // Execute the stored procedure
                command.ExecuteNonQuery();

                // Directly return the boolean result based on the output parameter value
                return (int)outputParameter.Value > 0;
            }
        }
    }catch (Exception ex)
    {
        // Log or handle the exception
        lblErrorMessage.Text = "An error occurred while validating credentials: " + ex.Message;
        // You can also log the exception details for debugging purposes
        // LogException(ex);
        return false;
    }
}





    }
}
