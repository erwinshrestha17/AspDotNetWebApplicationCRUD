﻿using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication1.Pages
{
    public partial class update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if UserID is provided in the query string
                if (Request.QueryString["UserID"] != null)
                {
                    string userId = Request.QueryString["UserID"];
                    PopulateUserData(userId);
                }
                else
                {
                    // If no UserID is provided, display an error message
                    lblMessage.Text = "User ID is missing.";
                }
            }
        }

        private void PopulateUserData(string userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
            string query = "SELECT FullName, Email, Password, PhoneNumber FROM Users WHERE UserID = @UserID";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Populate form fields with user data
                        txtFullName.Text = reader["FullName"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtPassword.Text = reader["Password"].ToString();
                        txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                    }
                    else
                    {
                        // If no data found for the provided UserID, display an error message
                        lblMessage.Text = "User not found.";
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get UserID from the query string
            string userId = Request.QueryString["UserID"];

            // Get updated data from form fields
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string phoneNumber = txtPhoneNumber.Text;

            // Update the user data in the database
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
            string query = "UPDATE Users SET FullName = @FullName, Email = @Email, Password = @Password, PhoneNumber = @PhoneNumber WHERE UserID = @UserID";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@UserID", userId);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    lblMessage.Text = "User data updated successfully.";
                }
                else
                {
                    lblMessage.Text = "Failed to update user data.";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Redirect back to the viewUsers page
            Response.Redirect("viewUsers.aspx");
        }
       


    }
}