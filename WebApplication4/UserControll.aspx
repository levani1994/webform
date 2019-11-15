<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserControll.aspx.cs" Inherits="WebApplication4.UserControll" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/CustomScript.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">


        <asp:DataList ID="DataList1" runat="server" DataSourceID="UserNames">
            <ItemTemplate>

                <table class="table table-bordered table-striped">
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

                    <tr>
                        <td style="text-align: center;" class=""><%# Eval("ID") %></td>
                        <td style="text-align: center;" class=""><%# Eval("UserName") %></td>
                        <td style="text-align: center;" class=""><%# Eval("UserSurname") %></td>
                        <td style="text-align: center;" class=""><%# Eval("UserEmail") %></td>
                        <td style="text-align: center;" class=""><%# Eval("UserRole") %></td>
                        <td style="text-align: center;">
                            <label data-id="<%# Eval("ID") %>" class="btn btn-success">Edit</label>
                            <label class="btn btn-danger" data-toggle="modal" data-target="#myModal" contenteditable="false">delete</label>
                        </td>
                    </tr>
                </table>



                <%--                    <td>
                        <a class="add" title="" data-toggle="tooltip" data-original-title="Add" style="display: none;"><i class="material-icons">save</i></a>
                        <a class="edit" title="" data-toggle="tooltip" data-original-title="Edit" style="display: inline-block;"><i class="material-icons">create</i></a>
                        <a class="delete" title="" data-toggle="tooltip" data-original-title="Delete"><i class="material-icons">delete</i></a>
                    </td>--%>
            </ItemTemplate>
        </asp:DataList>

        <div id="myModal" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;</button>
                        <h4 class="modal-title">Confirmation</h4>
                    </div>
                    <div class="modal-body">
                        <p>
                            Do you want to save changes you made to document before closing?
                        </p>
                        <p class="text-warning">
                            <small>If you don't save, your changes will be lost.</small>
                        </p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>
                      
                    </div>
                </div>
            </div>
        </div>



    </form>





    <asp:ObjectDataSource ID="UserNames" runat="server" SelectMethod="GetUsers" TypeName="WebApplication4.DALlibrary"></asp:ObjectDataSource>
</body>
</html>

