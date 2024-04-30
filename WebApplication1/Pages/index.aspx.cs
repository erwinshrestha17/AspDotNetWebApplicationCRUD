using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Reflection;
using System.Web.Services;
using System.Security.Cryptography;
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
            string password = Request.Form["Password"]?.Trim();
            string phoneNumber = Request.Form["PhoneNumber"]?.Trim();

            //string hashPassword = HashPassword(password);

            // Validate input fields, handle null or empty values

            // Create connection string
            string connectionString = "Server=Erwin\\MSSQLSERVER01;Database=erwin;User Id=sa;Password=123;";

            // Create SQL query to check if the email exists
            string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

            // Create SQL query for data insertion
            string insertDataQuery = "INSERT INTO Users (FullName, Email, Password, PhoneNumber) VALUES (@FullName, @, @Password, @PhoneNumber)";

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

                       
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or provide feedback to the user indicating the error
                    }
                }
            }
        }

        
        // Method to generate a SHA256 hash from a plaintext password
       /* public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array, convert byte array to a string
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Method to verify if a plaintext password matches a hashed password
        public static bool VerifyPassword(string plaintextPassword, string hashedPassword)
        {
            // Hash the plaintext password and compare it with the hashed password
            return HashPassword(plaintextPassword) == hashedPassword;
        }*/
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
