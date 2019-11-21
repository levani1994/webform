<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserControll.aspx.cs" Inherits="WebApplication4.UserControll" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.4.1.js"></script>

    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <script src="Scripts/CustomScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-hover shadow-lg rounded ">
            <thead>
                <tr>
                    <th class="" style="text-align: center;">Name</th>
                    <th class="" style="text-align: center;">SurnName</th>
                    <th class="" style="text-align: center;">Email/Login</th>
                    <th class="" style="text-align: center;">Role</th>
                </tr>
            </thead>
            <tbody>
                <%foreach (var item in GetUsers())
                    { %>
                <tr data-id="<%= item.Id %>">
                    <td style="text-align: center;" class=""><%= item.UserName %></td>
                    <td style="text-align: center;" id="name" class=""><%= item.UserSurname%></td>
                    <td style="text-align: center;" class=""><%= item.UserEmail %></td>
                    <td style="text-align: center;" class=""><%= item.UserRoles %></td>
                    <td style="text-align: center;">
                        <label data-id="<%= item.Id %>" class="btn btn-success" data-toggle="modal" data-target="#myModal" contenteditable="false">Edit</label>
                        <label class="btn btn-danger">delete</label>
                    </td>
                    <% } %>
                </tr>
            </tbody>
        </table>


        <div id="myModal" class="modal" runat="server">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;</button>
                    </div>
                        <div class="modal-body">
                   

                       
                        <div class="form-group">
                            <label>User Name</label>
                            <input type = "text"  class="form-control" id="UserName" />
                        </div>
                        <div class="form-group">
                            <label>Surname</label>
                            <input type = "text" class="form-control" id="Surname" />
                        </div>
                        <div class="form-group">
                            <label>Email address</label>
                            <input type = "email" class="form-control" id="Email" />
                        </div>
                            
                      

                        <div class="form-group">
                            <label>Role</label>
                            <br />
                            <%foreach (var item in GetRoles())
                                { %>

                   
                           
                                    <input id="<%= item.ID %> " type="checkbox" checked="checked"     ="<%= item.IsSelected %> " value="test" />
                        
                           
                            <label data-attr="<%= item.ID %> "><%= item.RoleName %> </label>
                            <br />
                            <% } %>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button id="UpdateBtn" type="button" class="btn btn-danger" data-dismiss="modal">
                            Update</button>
                    </div>
                </div>
                </div>
            </div>
     
    </form>
</body>
</html>

