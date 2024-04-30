using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1.Pages
{
    public partial class viewUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {


                    // Clear any previous rows in the table
                    userTableBody.Controls.Clear();

                    // Dynamically generate table rows and cells
                    foreach (DataRow row in dt.Rows)
                    {
                        HtmlTableRow tableRow = new HtmlTableRow();

                        // Create cells for each column in the DataRow
                        foreach (DataColumn column in dt.Columns)
                        {
                            HtmlTableCell tableCell = new HtmlTableCell();
                            tableCell.InnerText = row[column.ColumnName].ToString();
                            tableRow.Cells.Add(tableCell);
                        }


                        HtmlTableCell actionCell = new HtmlTableCell();
                        Button btnEdit = new Button();
                        btnEdit.Text = "Edit";
                        btnEdit.CommandArgument = row["UserID"].ToString(); // Set the user ID as the command argument
                        btnEdit.Click += BtnEdit_Click; // Attach event handler for edit button click
                        actionCell.Controls.Add(btnEdit);

                        Button btnDelete = new Button();
                        btnDelete.Text = "Delete";
                        btnDelete.CommandArgument = row["UserID"].ToString(); // Set the user ID as the command argument
                        btnDelete.Click += BtnDelete_Click; // Attach event handler for delete button click
                        actionCell.Controls.Add(btnDelete);
                        tableRow.Cells.Add(actionCell);

                        // Add the row to the table body
                        userTableBody.Controls.Add(tableRow);
                    }
                }
                else
                {
                    // If no data found, display a message
                    lblMessage.Text = "No data found.";
                }
            }
        }


        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Button btnEdit = (Button)sender;
            string userId = btnEdit.CommandArgument;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

                // Use parameterized query
                string query = "SELECT * FROM Users WHERE UserID = @UserID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate form fields with user data
                                string txtFullName = reader["FullName"].ToString();
                                string txtEmail = reader["Email"].ToString();
                                string txtPassword = reader["Password"].ToString();
                                string txtPhoneNumber = reader["PhoneNumber"].ToString();

                                // Redirect to the update page with the user ID for editing
                                Response.Redirect($"update.aspx?UserID={userId}");
                            }
                            else
                            {
                                // Handle case where user with provided ID is not found
                                // You can redirect or display an error message
                                lblMessage.Text = "User not found.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here, such as logging or displaying an error message
                lblMessage.Text = "An error occurred: " + ex.Message;
            }
        }




        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            string userId = btnDelete.CommandArgument;

            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID = @UserID", con);
                cmd.Parameters.AddWithValue("@UserID", userId);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    // Reload the page to reflect the changes after deletion
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    // Display an error message if deletion fails
                    lblMessage.Text = "Failed to delete user.";
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Redirect back to the viewUsers page
            Response.Redirect("index.aspx");
        }
        


    

    }
}
