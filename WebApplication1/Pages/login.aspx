<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.Pages.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
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

        h2 {
            margin-top: 0;
            text-align: center;
        }

        label {
            display: block;
            margin-bottom: 5px;
        }

        input[type="email"],
        input[type="password"] {
            width: 100%;
            padding: 8px;
            border-radius: 4px;
            border: 1px solid #ccc;
            margin-bottom: 15px;
            box-sizing: border-box; /* Ensure padding doesn't increase width */
        }

        button {
            width: 100%;
            padding: 10px;
            border: none;
            border-radius: 4px;
            background-color: #007bff;
            color: #fff;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        button:hover {
            background-color: #0056b3;
        }
        a {
            color: #007bff; 
            text-decoration: none; 
            transition: color 0.3s; 
        }
        
        a:hover {
            color: #0056b3; 
        }
        
    </style>
</head>
<body>
<form id="form1" runat="server" onsubmit="return validateForm()">
    <div>
        <h2>Log In</h2>
        <div>
            <label for="txtEmail">Email:</label>
            <input type="email" id="txtEmail" name="txtEmail" placeholder="Enter your email" required />
            <span class="error-message" id="emailError"></span>
        </div>
        <div>
            <label for="txtPassword">Password:</label>
            <input type="password" id="txtPassword" name="txtPassword" placeholder="Enter your password" required />
            <span class="error-message" id="passwordError"></span>
        </div>
        <button type="submit" id="btn" onclick="btnLogin_Click">Log In</button>
         <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>

    </div>
    <div>
            <footer>
            Don't Have an account ? <a href="index.aspx">Register</a>
            </footer>
    </div>
</form>
 


<script>
    function validateForm() {
        var email = document.getElementById("txtEmail").value;
        var password = document.getElementById("txtPassword").value;
        var emailError = document.getElementById("emailError");
        var passwordError = document.getElementById("passwordError");

        // Reset error messages
        emailError.innerText = "";
        passwordError.innerText = "";

        // Validate email
        if (email.trim() === "") {
            emailError.innerText = "Please enter your email";
            return false;
        } else if (!isValidEmail(email)) {
            emailError.innerText = "Please enter a valid email address";
            return false;
        }

        // Validate password
        if (password.trim() === "") {
            passwordError.innerText = "Please enter your password";
            return false;
        }

        return true; // Submit the form
    }

    function isValidEmail(email) {
        // Regular expression for validating email address
        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
    }
</script>

</body>
</html>

