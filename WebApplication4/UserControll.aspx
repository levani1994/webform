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
        <asp:ScriptManager ID="sm" EnablePageMethods="true" runat="server" />


        <asp:DataList ID="DataList1" runat="server" DataSourceID="UserNames">
            <ItemTemplate>
               <%-- <table class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th class="">id</th>
                            <th class="">Name</th>
                            <th class="">SurnName</th>
                            <th class="">Email/Login</th>
                            <th class="">Role</th>
                            <th class="">Edit</th>
                        </tr>
                    </thead>

                </table>--%>

                <table  class="table table-hover shadow-lg rounded ">
                    <tr data-id="<%# Eval("ID") %>">
                        <td style="text-align: center;" class=""><%# Eval("ID") %></td>
                        <td style="text-align: center;" id="name" class=""><%# Eval("UserName") %></td>
                        <td style="text-align: center;" class=""><%# Eval("UserSurname") %></td>
                        <td style="text-align: center;" class=""><%# Eval("UserEmail") %></td>
                        <td style="text-align: center;" class=""><%# Eval("UserRole") %></td>



                        <td style="text-align: center;">
                            <label data-id="<%# Eval("ID") %>" class="btn btn-success" data-toggle="modal" data-target="#myModal" contenteditable="false">Edit</label>
                            <label class="btn btn-danger" >delete</label>
                        </td>
                    </tr>
                </table>


            </ItemTemplate>
        </asp:DataList>


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
                            <input type="text" class="form-control" id="UserName"/>
                        </div>
                        <div class="form-group">


                            <label >Surname</label>
                            <input type="text" class="form-control" id="Surname"/>
                        </div>
                        <div class="form-group">


                            <label>Email address</label>
                            <input type="email" class="form-control" id="Email"/>
                        </div>
                        <div class="form-group">


                            <label>Role</label>
                            <input type="text" class="form-control" id="UserRole"/>
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





    <asp:ObjectDataSource ID="UserNames" runat="server" SelectMethod="GetUsers" TypeName="WebApplication4.DALlibrary"></asp:ObjectDataSource>
</body>
</html>

