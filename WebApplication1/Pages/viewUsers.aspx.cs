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
    try
    {
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        string storedProcedureName = "ManageUsers";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "selectAll");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);

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

                            if (column.ColumnName == "DateOfBirth" && row[column.ColumnName] != DBNull.Value)
                            {
                                // If the column is "DateOfBirth", format the date to display only the date part
                                DateTime dateOfBirth = Convert.ToDateTime(row[column.ColumnName]);
                                tableCell.InnerText = dateOfBirth.ToShortDateString(); // Display only the date part
                            }
                            else
                            {
                                tableCell.InnerText = row[column.ColumnName].ToString();
                            }

                            // Add the cell to the row
                            tableRow.Cells.Add(tableCell);
                        }

                        // Add action cells for edit and delete buttons
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
    }
    catch (Exception ex)
    {
        // Handle any exceptions here, such as logging or displaying an error message
        lblMessage.Text = "An error occurred: " + ex.Message;
    }
}
        protected void BtnEdit_Click(object sender, EventArgs e) 
        {
            Button btnEdit = (Button)sender;
            string userId = btnEdit.CommandArgument;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
                string storedProcedureName = "ManageUsers";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "select");
                        cmd.Parameters.AddWithValue("@UserID", int.Parse(userId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate form fields with user data
                                string txtFullName = reader["FullName"].ToString();
                                string txtEmail = reader["Email"].ToString();
                                string txtPassword = reader["Password"].ToString();
                                string txtPhoneNumber = reader["PhoneNumber"].ToString();
                                DateTime? dateOfBirth = reader["DateOfBirth"] as DateTime?;

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

    try
    {
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        string storedProcedureName = "ManageUsers";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "delete");
                cmd.Parameters.AddWithValue("@UserID", int.Parse(userId));

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

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
    }
    catch (Exception ex)
    {
        // Handle any exceptions here, such as logging or displaying an error message
        lblMessage.Text = "An error occurred: " + ex.Message;
    }
}
        

    }
}
