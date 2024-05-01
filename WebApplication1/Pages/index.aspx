<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.Pages.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>Index</title>
   <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
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
    #dateofbirth{
    padding: 8px; border-radius: 4px; border: 1px solid #ccc; width: 100%; box-sizing: border-box;
    
    }
    
    button[type="submit"]:hover {
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
          <input type="date" id="dateofbirth" name="dateofbirth" required="required" style="">
         </label><br /><br />
          <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label><br /><br />
         <label>
             <button type="submit" id="Btn_click" name="btn">Submit</button>
         </label><br /><br />
     </div>
     <div>
           <footer>
               Already Have an account ? <a href="login.aspx">Log in </a>
           </footer>
     </div>
 </form>
   <script>
       $(document).ready(function () {
           // Function to handle form submission
           $("#form1").submit(function (event) {
               // Prevent the default form submission
               event.preventDefault();
   
               // Validate form inputs
               if (!validateForm()) {
                   return;
               }
   
               // Submit the form data via AJAX
               $.ajax({
                   type: "POST",
                   url: "index.aspx", // Specify the URL of your server-side method
                   data: {
                       MethodName: "add",
                       FullName: $('#fullname').val(),
                       Email: $('#email').val(),
                       Password: $('#password').val(),
                       Phonenumber: $('#phonenumber').val(),
                       Dateofbirth: $('#dateofbirth').val()
                   },
                   dataType: "json", // Specify the expected data type of the response
                   success: function (response) {
                       // Handle successful submission
                       console.log("Data submitted successfully:");
                       // Optionally, redirect the user or show a success message
                       window.location.reload();
                   },
                
               });
           });
       });
   
       // Function to validate form inputs
       function validateForm() {
           var fullName = $("#fullname").val().trim();
           var email = $("#email").val().trim();
           var password = $("#password").val().trim();
           var phoneNumber = $("#phonenumber").val().trim();
           
           if (fullName === "") {
               showError("Full Name is required.");
               return false;
           }
   
           if (email !== "" && !isValidEmail(email)) {
               showError("Invalid email format.");
               return false;
           }
   
           if (password === "") {
               showError("Password is required.");
               return false;
           }
   
           if (phoneNumber !== "" && !isValidPhoneNumber(phoneNumber)) {
               showError("Invalid phone number format.");
               return false;
           }
   
           return true; // Form inputs are valid
       }
   
       // Function to show error message
       function showError(message) {
           $("#lblErrorMessage").text(message).show(); // Show error message
       }
   
       // Function to validate email format
       function isValidEmail(email) {
           var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
           return emailRegex.test(email);
       }
   
       // Function to validate phone number format
       function isValidPhoneNumber(phoneNumber) {
           var phoneRegex = /^\d{10}$/;
           return phoneRegex.test(phoneNumber);
       }
   </script>

  

</body>
</html>
