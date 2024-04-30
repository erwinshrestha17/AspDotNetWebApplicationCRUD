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
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <table>
                <thead>
                    
                    <tr>
                        <th>ID</th>
                        <th>Full Name</th>
                        <th>Email</th>
                        <th>Password</th>
                        <th>Phone Number</th>
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


</body>
</html>
