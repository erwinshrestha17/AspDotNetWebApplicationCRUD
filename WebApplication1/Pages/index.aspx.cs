using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebApplication1.Pages
{
    public partial class index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Call Btn_click method to handle form submission when the page is loaded
            Btn_click();
        }

        private void Btn_click()
        {
            // Check if the form is submitted
            if (IsPostBack)
            {
                // Retrieve form data
                string fullName = Request.Form["fullname"]?.Trim();
                string email = Request.Form["email"]?.Trim();
                string password = Request.Form["password"]?.Trim();
                string phoneNumber = Request.Form["phonenumber"]?.Trim();
                string dateOfBirth = Request.Form["dateofbirth"]?.Trim();
                
                

                try
                {
                    // Validate input fields
                    if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                        string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber) ||
                        string.IsNullOrEmpty(dateOfBirth))
                    {
                        // Handle empty fields
                        lblErrorMessage.Text = "All fields are required.";
                        return;
                    }

                    // Call the ManageUsers stored procedure to insert data
                    int rowsAffected = ManageUsers("insert", fullName, email, password, phoneNumber, dateOfBirth);
                    if (rowsAffected > 0)
                    {
                        // Clear the form fields or show a success message
                        // For example:
                        lblErrorMessage.Text = "Data inserted successfully!";
                    }
                    else
                    {
                        // Handle insertion failure
                        lblErrorMessage.Text = "Failed to insert data into the database.";
                    }
                }
                catch (Exception ex)
                {
                    // Handle and log exceptions
                    lblErrorMessage.Text = "An error occurred: " + ex.Message;
                }

                // Redirect to another page after form submission
                Response.Redirect("AnotherPage.aspx");
            }
        }

        private int ManageUsers(string action, string fullName, string email, string password, string phoneNumber, string dateOfBirth)
        {
            // Create connection string
            string connectionString = "YourConnectionString";

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ManageUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Action", action);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                    // Add output parameter to get rows affected
                    SqlParameter rowsAffectedParam = new SqlParameter("@RowsAffected", SqlDbType.Int);
                    rowsAffectedParam.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(rowsAffectedParam);

                    // Open connection and execute command
                    connection.Open();
                    command.ExecuteNonQuery();

                    // Get the value of the output parameter
                    return (int)rowsAffectedParam.Value;
                }
            }
        }
    }
}
