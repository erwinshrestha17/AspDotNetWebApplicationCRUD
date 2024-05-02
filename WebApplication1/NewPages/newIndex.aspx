<%@ Page Title="Title" Language="C#" MasterPageFile="MasterPage" CodeBehind="newIndex.aspx.cs" Inherits="WebApplication1.NewPages.newIndex" %>

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
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 300px;
        }
        label {
            margin-bottom: 10px;
        }
        input[type="text"],
        input[type="email"],
        input[type="password"],
        input[type="tel"],
        input[type="date"],
        button[type="submit"] {
            padding: 8px;
            border-radius: 4px;
            border: 1px solid #ccc;
            width: 100%;
            box-sizing: border-box;
            margin-bottom: 10px;
        }
        button[type="submit"] {
            background-color: #007bff;
            color: #fff;
            cursor: pointer;
            transition: background-color 0.3s;
        }
        button[type="submit"]:hover {
            background-color: #0056b3;
        }
        footer {
            margin-top: 20px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="newform1" runat="server">
        <div>
            <label>
                <input type="text" id="fullname" name="fullname" placeholder="Full Name" required="required" />
            </label>
            <label>
                <input type="email" id="email" name="email" placeholder="Email" />
            </label>
            <label>
                <input type="password" id="password" name="password" placeholder="Password" required="required" />
            </label>
            <label>
                <input type="tel" id="phonenumber" name="phonenumber" placeholder="Contact Number" required="required" />
            </label>
            <label>
                <input type="date" id="dateofbirth" name="dateofbirth" required="required" />
            </label>
            <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <br /><br />
            <button type="submit" id="Btn_click" name="btn">Submit</button>
        </div>
        <div>
            <footer>
                Already Have an account ? <a href="login.aspx">Log in</a>
            </footer>
        </div>
    </form>
  <script>
      function onSubmit() {
          var formData = {
              fullname: $('#fullname').val(),
              email: $('#email').val(),
              password: $('#password').val(),
              phonenumber: $('#phonenumber').val(),
              dateofbirth:$('#dateofbirth').val()
          };
          $.ajax({
              type: "POST",
              url: "index.aspx", // Specify the URL of your server-side method
              data: {
                  MethodName :"add",
                  FullName: $('#fullname').val(),
                  Email: $('#email').val(),
                  Password: $('#password').val(),
                  Phonenumber: $('#phonenumber').val(),
                  dateofbirth:$('#dateofbirth').val()
                  
              },
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
                  }
              });
          });
      });
  
      // Function to validate form inputs
      function validateForm() {
          var fullName = $("#fullname").val().trim();
          var email = $("#email").val().trim();
          var password = $("#password").val().trim();
          var phoneNumber = $("#phonenumber").val().trim();
          var dateofbirth=$("#dateofbirth").val().trim();
  
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