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
            if (!IsPostBack)
            {
                if (Request.Form["MethodName"] == "add")
                {
                    Btn_click();
                }
            }
        }

        private void Btn_click() 
        {
            string fullName = Request.Form["FullName"]?.Trim();
            string email = Request.Form["Email"]?.Trim();
            string password = Request.Form["Password"]?.Trim();
            string phoneNumber = Request.Form["PhoneNumber"]?.Trim();
            string dateOfBirth = Request.Form["DateOfBirth"]?.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber))
            {
                return;
            }

            string connectionString = "Data Source=erwin\\MSSQLSERVER01;Initial Catalog=erwin;User Id=erwin17;Password=erwin@1998;";
            string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
            string insertDataQuery = "INSERT INTO Users (FullName, Email, Password, PhoneNumber, DateOfBirth) VALUES (@FullName, @Email, @Password, @PhoneNumber, @DateOfBirth)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand checkEmailCommand = new SqlCommand(checkEmailQuery, connection))
                {
                    checkEmailCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                    int emailCount = (int)checkEmailCommand.ExecuteScalar();
                    if (emailCount > 0)
                    {
                        lblErrorMessage.Text = "Email already exists. Please use a different email.";
                    }
                    else
                    {
                        using (SqlCommand command = new SqlCommand(insertDataQuery, connection))
                        {
                            command.Parameters.AddWithValue("@FullName", fullName);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Password", password);
                            command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);

                            try
                            {
                                command.ExecuteNonQuery();
                                Response.Redirect("login.aspx");
                            }
                            catch (Exception ex)
                            {
                                // Log the exception or provide feedback to the user indicating the error
                                lblErrorMessage.Text = "An error occurred while registering. Please try again later.";
                                // Log the exception details
                                // Log.Error(ex, "Error occurred while registering user.");
                            }
                        }
                    }
                }
            }

    
    
        }
        
    }
}
