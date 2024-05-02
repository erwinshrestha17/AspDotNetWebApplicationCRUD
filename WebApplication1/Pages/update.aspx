<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="WebApplication1.Pages.update" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update User</title>
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
            color: #007bff;
        }

        label {
            display: block;
            margin-bottom: 5px;
            color: #555;
        }

        input[type="text"],
        input[type="email"],
        input[type="password"]
         input[type="date"]{
            width: calc(100% - 16px); /* Adjusting for padding */
            padding: 8px;
            border-radius: 4px;
            border: 1px solid #ccc;
            margin-bottom: 15px;
            box-sizing: border-box; /* Ensure padding doesn't increase width */
        }

        .btn-group {
            display: flex;
            justify-content: space-between;
            margin-top: 20px;
        }

        .btn-group button {
            flex: 1;
            padding: 10px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s, color 0.3s, box-shadow 0.3s;
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
            filter: brightness(90%);
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        #lblMessage {
            color: red;
            text-align: center;
            margin-top: 10px;
        }
        #txtDateOfBirth{
            padding: 8px; 
            border-radius: 4px; 
            border: 1px solid #ccc; 
            width: 100%; 
            box-sizing: border-box;
            
            }
            
            
             select {
                 padding: 8px;
                 border-radius: 4px;
                 border: 1px solid #ccc;
                 width: 100%;
                 box-sizing: border-box;
                 font-size: 16px; 
                 font-family: Arial, sans-serif; 
                 background-color: #fff; 
                 color: #333; /
                 appearance: none; 
                 -webkit-appearance: none; 
                 -moz-appearance: none; 
                 cursor: pointer; 
             }
             
             /* Style for when the dropdown is focused */
             select:focus {
                 outline: none; 
                 border-color: #007bff; 
                 box-shadow: 0 0 5px rgba(0, 123, 255, 0.5); 
             }
             
            
             option {
                 padding: 8px;
                 background-color: #fff; 
                 color: #333; 
             }
         
             option:hover {
                 background-color: #f0f0f0; 
                 color: #007bff; 
             }   
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Update User</h1>
            <div>
                <label for="txtFullName">Full Name:</label>
                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div>
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div>
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div>
                <label for="txtPhoneNumber">Phone Number:</label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div>
               <label for="txtDateOfBirth">Date of Birth:</label>
                <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <br />
       
<br />
            <div class="btn-group">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-update" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-cancel" />
            </div>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>

