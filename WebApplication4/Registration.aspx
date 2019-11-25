<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication4.Registration" %>

<!DOCTYPE html>
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>registration</title>
</head>
<body>
    <div class="container" style="position: relative">
        <!-- Default form register -->
        <form method="post" class="text-center  border border-primary p-5" style="position: absolute; left: 50%; top: 50%; transform: translate(-50%)" runat="server">
            <p class="h4 mb-4">Sign up</p>
            <div class="form-row mb-4">
                <div class="col">
                    <!-- First name -->
                    <input runat="server" type="text" id="FirstName" class="form-control" placeholder="First name" required="required">
                </div>
                <div class="col">
                    <!-- Last name -->
                    <input runat="server" type="text" id="LastName" class="form-control" placeholder="Last name" required="required">
                </div>
            </div>

            <!-- E-mail -->
            <input runat="server" type="email" id="Email" class="form-control mb-4" placeholder="E-mail" required="required">

            <!-- Password -->
            <input runat="server" type="password" id="Password" class="form-control" placeholder="Password" required="required" aria-describedby="passwordHelperBlock">
            <small id="passwordHelperBlock" class="form-text text-muted mb-4">al least 8 symbols
            </small>
            <input runat="server" type="password" id="RepeatPassword" class="form-control mb-4" placeholder="Repeat Password" required="required">

            <div class="custom-file">
                <input type="file" class="custom-file-input" id="inputGroupFile01"
                    aria-describedby="inputGroupFileAddon01" runat="server">
                <label class="custom-file-label" for="inputGroupFile01">Choose file</label>
            </div>

            <br />

            <br />

            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <!-- Sign up button -->
            <asp:Button class="btn btn-info btn-block" runat="server" type="submit" OnClick="UserRegistration" Text="Sign up" />
            <p class="h6">or</p>
            <a href="Login.aspx" class="btn btn-info btn-block">Log in</a>
        </form>
    </div>
</body>
</html>
