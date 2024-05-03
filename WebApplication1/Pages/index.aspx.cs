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
            string department = Request.Form["TagSelection"]?.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(phoneNumber))
            {
                return;
            }

            // NormalInsertQuery(fullName, email, password, phoneNumber, dateOfBirth);
             ManageUserSP("insert",fullName,email,password,phoneNumber,dateOfBirth,department);




        }

        private static void ManageUserSP(string action, string fullName, string email, string password, string phoneNumber, string dateOfBirth , string department)
        {
            string connectionString = "Data Source=erwin\\MSSQLSERVER01;Initial Catalog=erwin;User Id=erwin17;Password=erwin@1998;"; 
            string storedProcedureName = "ManageUsers";
            
            
            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@Action", action);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@Department", department);
                    

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        // Handle success
                        Console.WriteLine("User action ({0}) executed successfully.", action);
                    }
                    catch (SqlException ex)
                    {
                        // Handle SQL exceptions
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        // Handle other exceptions
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

        }
    }
}
