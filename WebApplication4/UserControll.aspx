<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserControll.aspx.cs" Inherits="WebApplication4.UserControll" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container-fluid">

            <asp:DataList ID="DataList1" runat="server" DataSourceID="UserNames">
                <ItemTemplate>



                    <div class="list-group">
                        <a href="UserControll<%# Eval("ID") %>" class="list-group-item list-group-item-action">
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("ID") %>' /></a>


                    </div>




                </ItemTemplate>

            </asp:DataList>







        </div>

    </form>
    <asp:ObjectDataSource ID="UserNames" runat="server" SelectMethod="GetUsers" TypeName="WebApplication4.DALlibrary" ></asp:ObjectDataSource>
</body>
</html>

