<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Pages/adduser.aspx.cs" Inherits="WebApplication1.Pages.adduser" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
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
            border-collapse: collapse;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <button type="button" onclick="createInputFields()">Add</button>
        </div>
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Phone</th>
                    <th>Address</th>
                    <th>Gender</th>
                    <th>Nationality</th>
                </tr>
            </thead>
            <tbody id="inputFieldsContainer">
                <!-- Input fields for each person will be dynamically generated here -->
            </tbody>
        </table>
        <button type="button" id="SaveButton" onclick="addPerson()">save</button>
    </form>

    <script>
        let people = [];

        function createInputFields() {
            const container = document.getElementById("inputFieldsContainer");
            const newRow = document.createElement("tr");
            newRow.innerHTML = `
                <td><input type="text" name="name" placeholder="Name"></td>
                <td><input type="email" name="email" placeholder="Email"></td>
                <td><input type="tel" name="phone" placeholder="Phone"></td>
                <td><input type="text" name="address" placeholder="Address"></td>
                <td><input type="text" name="gender" placeholder="Gender"></td>
                <td><input type="text" name="nationality" placeholder="Nationality"></td>
            `;
            container.appendChild(newRow);
        }

        function addPerson() {
            const inputs = document.querySelectorAll("#inputFieldsContainer input");
            const person = {};
            inputs.forEach(input => {
                person[input.name] = input.value;
            });
            console.log(person)
        }

    

   
    </script>
</body>
</html>
