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
                        <a href="" class="list-group-item list-group-item-action">
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("UserName") %>' /></a>


                    </div>




                </ItemTemplate>

            </asp:DataList>
            <div class="list-group">
                <button type="button" class="list-group-item list-group-item-action active">
                    Cras justo odio
                </button>
                <button type="button" class="list-group-item list-group-item-action">Dapibus ac facilisis in</button>
                <button type="button" class="list-group-item list-group-item-action">Morbi leo risus</button>
                <button type="button" class="list-group-item list-group-item-action">Porta ac consectetur ac</button>
                <button type="button" class="list-group-item list-group-item-action">Vestibulum at eros</button>
            </div>







        </div>

    </form>
    <asp:ObjectDataSource ID="UserNames" runat="server" SelectMethod="GetUsers" TypeName="WebApplication4.DALlibrary" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
</body>
</html>

