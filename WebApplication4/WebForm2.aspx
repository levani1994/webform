<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication4.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>


    <form id="form2" runat="server">
        <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged">
            <asp:ListItem Text="choose a language" />
            <asp:ListItem Text="English" Value="en-us" />
             <asp:ListItem Text="ქართული" Value="ka-ge" />
        </asp:DropDownList>
       


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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None"  Height="191px" Width="634px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" SortExpression="AuthorName" />
                <asp:BoundField DataField="AuthotLastname" HeaderText="AuthotLastname" SortExpression="AuthotLastname" />
                <asp:BoundField DataField="AuthorNationality" HeaderText="AuthorNationality" SortExpression="AuthorNationality" />
                <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                <asp:BoundField DataField="Birthdate" HeaderText="Birthdate" SortExpression="Birthdate" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
      

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:levaniDBConnectionString %>"
            DeleteCommand="DeteleUser @ID"
            SelectCommand="getAllAuthors"
            UpdateCommand="UpdateAuthors @AuthorName,  @AuthotLastname,  @AuthorNationality,  @Genre,  @Birthdate,  @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
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
    </form>
</body>
</html>
