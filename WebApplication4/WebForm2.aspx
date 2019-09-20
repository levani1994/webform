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
    
       


            <asp:GridView OnRowDataBound="AuthorGrid_RowDataBound" ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="ObjectDataSource1" BackColor="White" BorderColor="#CCCCCC"  Height="100px" Width="800px" BorderStyle="None" 
                BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True">
                <Columns>
                    
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                    <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" />
                    <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                    <asp:BoundField DataField="Birthdate" HeaderText="Birthdate" SortExpression="Birthdate" />
                    <asp:BoundField DataField="DateDeleted" HeaderText="DateDeleted" SortExpression="DateDeleted" />
                    <asp:BoundField DataField="DateUpdated" HeaderText="DateUpdated" SortExpression="DateUpdated" />
                    <asp:BoundField DataField="DateInserted" HeaderText="DateInserted" SortExpression="DateInserted" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />

                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
       
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="GetAllAuthors"
                DeleteMethod="DeleteAuthor" 
                UpdateMethod="UpdateAuthor"
          
                TypeName="WebApplication4.LibraryDataAccessLayer">
                 
                <DeleteParameters>
                    <asp:Parameter  Name="id" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters >
                    <asp:Parameter Name="id" Type="Int32" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="surname" Type="String" />
                    <asp:Parameter Name="nationality" Type="String" />
                    <asp:Parameter Name="genre" Type="String" />
                    <asp:Parameter Name="birthdate" Type="String" />
                    <asp:Parameter Name="DateDeleted" Type="String" />
                    <asp:Parameter Name="DateUpdated" Type="String" />
                    <asp:Parameter Name="DateInserted" Type="String" />
                    
                </UpdateParameters>
                    
                
                
           
            </asp:ObjectDataSource>

            
      
       


        
        <asp:GridView ID="AuthorGrid" OnRowDataBound="AuthorGrid_RowDataBound" runat="server" AutoGenerateColumns="False"
            CellPadding="3" DataKeyNames="ID" DataSourceID="SqlDataSource1" GridLines="Vertical"  Height="100px" Width="800px"
            AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>

                

                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" SortExpression="AuthorName" />
                <asp:BoundField DataField="AuthotLastname" HeaderText="AuthotLastname" SortExpression="AuthotLastname" />
                <asp:BoundField DataField="AuthorNationality" HeaderText="AuthorNationality" SortExpression="AuthorNationality" />
                <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                <asp:BoundField DataField="Birthdate" HeaderText="Birthdate" SortExpression="Birthdate" />
                <asp:BoundField DataField="DateDeleted" HeaderText="DateDeleted" SortExpression="DateDeleted" />
                <asp:BoundField DataField="DateUpdated" HeaderText="DateUpdated" SortExpression="DateUpdated" />
                <asp:BoundField DataField="DateInserted" HeaderText="DateInserted" SortExpression="DateInserted" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
      
       


        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:levaniDBConnectionString %>"
            DeleteCommand="DeleteUser @ID"
            SelectCommand="getAllAuthors"
            UpdateCommand="UpdateAuthors @AuthorName,  @AuthotLastname,  @AuthorNationality,  @Genre,  @Birthdate,  @ID" InsertCommand="DeleteUser" InsertCommandType="StoredProcedure" SelectCommandType="StoredProcedure"> 
            <DeleteParameters>
                <asp:Parameter Name="ID" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="BookID" Type="Int32" />
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




        




       
    </form>
</body>
</html>
