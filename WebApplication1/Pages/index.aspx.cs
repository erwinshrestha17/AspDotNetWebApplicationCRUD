﻿using System;
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

        public void Btn_click()
        {
            // Retrieve form data
            string fullName = Request.Form["FullName"]?.Trim();
            string email = Request.Form["Email"]?.Trim();
            string password = Request.Form["Password"]?.Trim();
            string phoneNumber = Request.Form["PhoneNumber"]?.Trim();
            string dateofbirth = Request.Form["dateofbirth"]?.Trim();

            // Validate input fields
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber))
            {
                // Handle empty fields
                return;
            }

            // Check if email already exists
            if (IsEmailExists(email))
            {
                // Handle email already exists
                lblErrorMessage.Text = "Email already exists. Please use a different email.";
                return;
            }

            // Create connection string
            string connectionString = "Server=Erwin\\MSSQLSERVER01;Database=erwin;User Id=sa;Password=123;";

            // Create SQL query for data insertion
            string insertDataQuery = "INSERT INTO Users (FullName, Email, Password, PhoneNumber,DateOfBirth) VALUES (@FullName, @Email, @Password, @PhoneNumber,@DateOfBirth)";

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertDataQuery, connection))
                {
                    // Add parameters to the command
                    command.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = fullName;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                    command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = phoneNumber;
                    command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dateofbirth;
                    // Open connection and execute command to insert data
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        // Data inserted successfully
                        // Redirect to the same page
                        Response.Redirect("login.aspx");
                        // Commit transaction
                    }
                    catch (Exception ex)
                    {
                        // Handle and log exceptions
                    }
                }
            }
        }

        private bool IsEmailExists(string email)
        {
            // Create connection string
            string connectionString = "Server=Erwin\\MSSQLSERVER01;Database=erwin;User Id=sa;Password=123;";
            // Create SQL query to check if email exists
            string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(checkEmailQuery, connection))
                {
                    // Add parameter to the command
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;

                    // Open connection and execute command to check if email exists
                    connection.Open();
                    int emailCount = (int)command.ExecuteScalar();
                    return emailCount > 0;
                }
            }
        }
    }
}
