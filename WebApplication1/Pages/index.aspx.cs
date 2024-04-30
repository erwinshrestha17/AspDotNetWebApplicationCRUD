using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Web.Services;
using System.Web.UI;

namespace WebApplication1.Pages
{
    public partial class index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This method is called when the page is loaded
            if(!IsPostBack)
            {
                if (Request.Form["MethodName"] =="add")
                {
                     Btn_click();

                }

            
            }
        }

        public void Btn_click()
        {
            // Retrieve form data
            string fullName = Request.Form["FullName"]?.Trim();
            string email = Request.Form["Email"]?.Trim();
            string password = Request.Form["Password"];
            string phoneNumber = Request.Form["PhoneNumber"]?.Trim();

            // Validate input fields, handle null or empty values

            // Create connection string
            string connectionString = "Server=Erwin\\MSSQLSERVER01;Database=erwin;User Id=sa;Password=123;";

            // Create SQL query to check if the email exists
            string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

            // Create SQL query for data insertion
            string insertDataQuery = "INSERT INTO Users (FullName, Email, Password, PhoneNumber) VALUES (@FullName, @Email, @Password, @PhoneNumber)";

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Check if the email already exists
                using (SqlCommand checkEmailCommand = new SqlCommand(checkEmailQuery, connection))
                {
                    checkEmailCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                    connection.Open();
                    int emailCount = (int)checkEmailCommand.ExecuteScalar();
                    if (emailCount > 0)
                    {
                        // Email already exists, provide error message
                        // You can use ASP.NET controls or JavaScript to display the error message
                        // For example, if you're using ASP.NET WebForms:
                        // ErrorMessageLabel.Text = "Email already exists. Please use a different email.";
                        return;
                    }
                }

                // If email doesn't exist, proceed with data insertion
                using (SqlCommand command = new SqlCommand(insertDataQuery, connection))
                {
                    // Add parameters to the command
                    command.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = fullName;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                    command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = phoneNumber;

                    // Open connection and execute command to insert data
                    try
                    {
                        command.ExecuteNonQuery();
                        // Provide feedback to the user indicating successful data insertion
                        // You can return a message or redirect the user to another page
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or provide feedback to the user indicating the error
                    }
                }
            }
        }

        private bool IsEmailExists(string email)
        {
            string connectionString = "Server=Erwin\\MSSQLSERVER01;Database=erwin;User Id=sa;Password=123;";
            string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(checkEmailQuery, connection))
            {
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                connection.Open();
                int emailCount = (int)command.ExecuteScalar();
                return emailCount > 0;
            }
        }


    }

    // Define a model to represent the form data
    public class FormDataModel
    {
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phonenumber { get; set; }
    }
}
