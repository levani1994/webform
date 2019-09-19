<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication4.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ OutputCache Duration="60" VaryByParam="none" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/Javascript">
    function ConfirmOnDelete(item) {
        if (confirm("are you sure to delete: " + item + "?") == true)
            return true;
        else
            return false;
        }  
</script>

</head>
<body>
   

    <form id="form2" runat="server">
            <%--  <asp:Button ID="btnconfirm" runat="server" Font-Bold="True" ForeColor="Red" Style="z-index: 101;
left: 272px; position: absolute; top: 208px" Text="Confrimation MsgBox"
OnClientClick =" return confirm_meth()" Width="160px" />--%>


        <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged">
            <asp:ListItem Text="choose a language" />
            <asp:ListItem Text="English" Value="en-us" />
             <asp:ListItem Text="ქართული" Value="ka-ge" />
        </asp:DropDownList>
        <asp:Label ID="lbltime" runat="server" />

        <p>
        <asp:TextBox ID="Name"  meta:resourcekey="Name" runat="server"></asp:TextBox>
        </p>
         
    
        <p>
            <asp:TextBox ID="Surname"  meta:resourcekey="Surname" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="Nationality"  meta:resourcekey="Nationality" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="Genre"  meta:resourcekey="Genre" runat="server"></asp:TextBox>
        </p>
         <p>
            <asp:TextBox ID="Birthdate" meta:resourcekey="Birthdate"  runat="server"></asp:TextBox>
        </p>

        <p>
            
            <asp:Button ID="Add_button" runat="server" OnClick="AddButton"  meta:resourceKey="Add_button" />
        </p>
    
        <asp:GridView ID="AuthorGrid" OnRowDataBound="AuthorGrid_RowDataBound" runat="server" AutoGenerateColumns="False" EnableViewState="true"
            CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1"
            ForeColor="#333333" GridLines="None"  Height="191px" Width="634px"
            AllowPaging="True" AllowSorting="True" >
            <AlternatingRowStyle BackColor="White" />
           
           
            
           
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" SortExpression="AuthorName" />
                <asp:BoundField DataField="AuthotLastname" HeaderText="AuthotLastname" SortExpression="AuthotLastname" />
                <asp:BoundField DataField="AuthorNationality" HeaderText="AuthorNationality" SortExpression="AuthorNationality" />
                <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                <asp:BoundField DataField="Birthdate" HeaderText="Birthdate" SortExpression="Birthdate" />
                <asp:CommandField ShowDeleteButton="True"  ShowEditButton="True" />
            </Columns>

            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
      
       


        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:levaniDBConnectionString %>"
          
            DeleteCommand="DeteleUser @ID"
            SelectCommand="getAllAuthors"
           
            UpdateCommand="UpdateAuthors @AuthorName,  @AuthotLastname,  @AuthorNationality,  @Genre,  @Birthdate,  @ID"> 
            <DeleteParameters>
                <asp:Parameter Name="BookId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="AuthorName" Type="String" />
                <asp:Parameter Name="AuthotLastname" Type="String" />
                <asp:Parameter Name="AuthorNationality" Type="String" />
                <asp:Parameter Name="Genre" Type="String" />
                <asp:Parameter Name="Birthdate" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="AuthorName" Type="String" />
                <asp:Parameter Name="AuthotLastname" Type="String" />
                <asp:Parameter Name="AuthorNationality" Type="String" />
                <asp:Parameter Name="Genre" Type="String" />
                <asp:Parameter Name="Birthdate" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>





       
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>





       
    </form>
</body>
</html>
