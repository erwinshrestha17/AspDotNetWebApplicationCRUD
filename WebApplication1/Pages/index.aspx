<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.Pages.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index</title>

    <style>
    body {
        font-family: Arial, sans-serif;
        margin: 0;
        padding: 0;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        background-color: #f0f0f0;
    }
    
    form {
        background-color: #fff;
        padding: 20px;
        border-radius: 8px;
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        width: 300px;
        display: flex;
        flex-direction: column;
        align-items:center;
    }
    
    label {
        margin-bottom: 10px;
    }
    
    input[type="text"],
    input[type="email"],
    input[type="password"],
    input[type="tel"],
    button[type="submit"] {
        padding: 8px;
        border-radius: 4px;
        border: 1px solid #ccc;
        margin-bottom: 15px;
    }
    
    button[type="submit"] {
        background-color: #007bff;
        color: #fff;
        border: none;
        cursor: pointer;
        transition: background-color 0.3s;
    }
    
    button[type="submit"]:hover {
        background-color: #0056b3;
    }
</style>
</head>
<body>
 <form id="form1"  method="post" runat="server">
    <h2>Register</h2>

     <div>
         <label>
            <input type="text" id="fullname" name="fullname" placeholder="Full Name" required="required"/>
        </label><br /><br />
         <label>
             <input type="email" id="email" name="email" placeholder="Email" />
         </label><br /><br />
         <label>
             <input type="password" id="password" name="password" placeholder="Password" required="required"/>
         </label><br /><br />
         <label>
             <input type="tel" id="phonenumber" name="phonenumber" placeholder="Contact Number" required="required" />
         </label><br /><br />
         <label>
             <button type="submit" id="Btn_click" name="btn" onclick="onSubmit()">Submit</button>
         </label><br /><br />
         <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>

     </div>
 </form>
   <script>
       function onSubmit() {
           var formData = {
               fullname: $('#fullname').val(),
               email: $('#email').val(),
               password: $('#password').val(),
               phonenumber: $('#phonenumber').val(),
           };
           $.ajax({
               type: "POST",
               url: "index.aspx", // Specify the URL of your server-side method
               data: {
                   MethodName :"add",
                   FullName: $('#fullname').val(),
                   Email: $('#email').val(),
                   Password: $('#password').val(),
                   Phonenumber: $('#phonenumber').val()
               } ,
             //  contentType: "application/json; charset=utf-8", // Set content type to JSON
               dataType: "json", // Specify the expected data type of the response
               success: function (response) {
                   // Handle successful submission
                   console.log("Data submitted successfully:");
                   // Optionally, redirect the user or show a success message
               },
               error: function (xhr, status, error) {
                   // Handle errors
                   console.log("An error occurred:");
                   // Optionally, display an error message to the user
               }
           });
       }
   </script>

     <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            // Function to handle form submission
            $("#form1").submit(function (event) {
                // Prevent the default form submission
                event.preventDefault();
            });
        });
    </script>

    <script>
        function validateForm() {
            var fullName = document.getElementById("fullname").value.trim();
            var email = document.getElementById("email").value.trim();
            var password = document.getElementById("password").value.trim();
            var phoneNumber = document.getElementById("phonenumber").value.trim();

            if (fullName === "") {
                showError("Full Name is required.");
                return;
            }

            if (email !== "" && !isValidEmail(email)) {
                showError("Invalid email format.");
                return;
            }

            if (password === "") {
                showError("Password is required.");
                return;
            }

            if (phoneNumber !== "" && !isValidPhoneNumber(phoneNumber)) {
                showError("Invalid phone number format.");
                return;
            }

            // If all validations pass, submit the form
            document.getElementById("form1").submit();
        }

        function showError(message) {
            document.getElementById("lblErrorMessage").innerText = message;
        }

        function isValidEmail(email) {
            // Basic email validation
            var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            return emailRegex.test(email);
        }

        function isValidPhoneNumber(phoneNumber) {
            // Basic phone number validation (10 digits)
            var phoneRegex = /^\d{10}$/;
            return phoneRegex.test(phoneNumber);
        }
    </script>
</body>
</html>
