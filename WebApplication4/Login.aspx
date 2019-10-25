<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication4.Login" %>

<!DOCTYPE html>
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

</head>

<body>
    <div class="container" style="position: relative">
        <!-- Default form register -->
        <form method="post" class="text-center  border border-primary p-5" style="position: absolute; left: 50%; top: 50%; transform: translate(-50%)" runat="server">

            <p class="h4 mb-4">Sign in</p>

            <!-- E-mail -->
            <input runat="server" type="email" id="Email" class="form-control mb-4" placeholder="E-mail" required="required">

            <!-- Password -->
            <input runat="server" type="password" id="Password" class="form-control mb-4" placeholder="Password" required="required">
        

            <!-- Sign up button -->
          
         <asp:button class="btn btn-info btn-block" runat="server" type="submit" OnClick="UserLogin" Text="Log in" />
            


        </form>

    </div>

</body>

</html>
