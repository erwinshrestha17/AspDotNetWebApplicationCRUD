<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="WebApplication1.Pages.update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update</title>
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

        form {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            width: 300px;
        }

        h1 {
            margin-top: 0;
            text-align: center;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"],
        input[type="email"],
        input[type="password"] {
            width: 100%;
            padding: 8px;
            border-radius: 4px;
            border: 1px solid #ccc;
            margin-bottom: 15px;
            box-sizing: border-box; /* Ensure padding doesn't increase width */
        }

        .btn-group {
            display: flex;
            justify-content: space-between;
        }

        .btn-group button {
            flex: 1;
            padding: 10px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .btn-update {
            background-color: #007bff;
            color: #fff;
            margin-right: 5px;
        }

        .btn-cancel {
            background-color: #dc3545;
            color: #fff;
            margin-left: 5px;
        }

        .btn-update:hover,
        .btn-cancel:hover {
            background-color: #0056b3;
        }

        #lblMessage {
            color: red;
            text-align: center;
            margin-top: 10px;
        }
    </style>
    
    
</head>
<body>
 <form id="form1" runat="server">
        <div>
            <h1>Update User</h1>
            <div>
                <label for="">Full Name:</label>
                <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <label for="">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <label for="">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <br />
            <div>
                <label for="">Phone Number:</label>
                <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
