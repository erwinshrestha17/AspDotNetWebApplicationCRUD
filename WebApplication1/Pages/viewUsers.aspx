<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewUsers.aspx.cs" Inherits="WebApplication1.Pages.viewUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Table</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        
        table {
            border: 2px solid #ddd;
            border-radius: 8px;
            overflow: hidden;
            width: 80%;
            margin: 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            background-color: #fff;
            border-collapse: collapse; /* Ensure table borders collapse */
        }
        
        th, td {
            padding: 12px;
            text-align: left;
        }
        
        th {
            background-color: #007bff;
            color: #fff;
            text-transform: uppercase;
        }
        
        td {
            border-top: 1px solid #ddd;
        }
        
        .actions {
            display: flex;
            justify-content: space-around;
        }
        
        header {
            background-color: #007bff; 
            color: #fff;
            padding: 10px 20px; 
            display: flex; 
            justify-content: space-between; 
        }
        
        button {
            background-color: #fff;
            color: #007bff; 
            border: none; 
            padding: 8px 16px; 
            border-radius: 4px; 
            cursor: pointer; 
            transition: background-color 0.3s, color 0.3s; 
        }
        
        button:hover {
            background-color: #007bff; 
            color: #fff; 
        }
        
        #logout {
            margin-left: auto;
        }

        /* Add hover effect to table rows */
        tr:hover {
            background-color: #f5f5f5;
        }

        /* Add transition effect to table rows */
        tr {
            transition: background-color 0.3s;
        }

        /* Adjust button padding */
        .actions button {
            padding: 6px 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div id="Add"><button type="button" onclick="Add()">Add</button></div>
            <div id="logout"><button type="button" onclick="logout()">Log Out</button></div>
        </header>
        <div>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Full Name</th>
                        <th>Email</th>
                        <th>Password</th>
                        <th>Phone Number</th>
                        <th>Date of Birth </th>
                        <th>Department</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody id="userTableBody" runat="server">
                    <!-- Table rows will be dynamically added here -->
                </tbody>
            </table>
            <!-- Label to display messages -->
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
    <script>
        function logout() {
            // Redirect to the logout page
            window.location.href = "login.aspx";
        }
        
        function Add() {
            // Redirect to the logout page
            window.location.href = "index.aspx";
        }
    </script>
</body>
</html>
