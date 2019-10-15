<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication4.WebForm2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ OutputCache Duration="60" VaryByParam="none" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/jquery-ui-1.12.1.min.js"></script>
<script type="text/Javascript">
    function ConfirmOnDelete(item) {
        if (confirm("are you sure to delete: " + item + "?") == true)
            return true;
        else
            return false;
    }

    $(document).ready(function () {
        $("#Author_GridView_CheckBox1_0").click(function () {
            alert("frfrf");
        })
    }
        )
    
</script>
   
   
</head>
<body>
  

    <form id="Author_list" runat="server">
          
        <asp:ScriptManager id="ScriptManager" runat="server">
   </asp:ScriptManager>

        <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged">
            <asp:ListItem Text="choose a language" />
            <asp:ListItem Text="English" Value="en-us" />
             <asp:ListItem Text="ქართული" Value="ka-ge" />
        </asp:DropDownList>
        <asp:Label ID="lbltime" runat="server" />

        <p>
        <asp:TextBox ID="Name"  meta:resourcekey="Name" runat="server"></asp:TextBox>
        
    
            
         
       
        <asp:RequiredFieldValidator ID="validator" ControlToValidate="Name"  ValidationGroup="val1" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

        </asp:RequiredFieldValidator>

      
        </p>


        <p>
            <asp:TextBox ID="Surname"  meta:resourcekey="Surname" runat="server"></asp:TextBox>
            
        <asp:RequiredFieldValidator ID="Validator1" ControlToValidate="Name" ValidationGroup="val1" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

        </asp:RequiredFieldValidator>

        </p>



        <p>
            <asp:TextBox ID="Nationality"  meta:resourcekey="Nationality" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="Validator2" ControlToValidate="Nationality" ValidationGroup="val1" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

        </asp:RequiredFieldValidator>
        </p>
        
         <p>
            <asp:TextBox ID="Birthdate" meta:resourcekey="Birthdate"  runat="server" AutoComplete="off"></asp:TextBox>
             <asp:RequiredFieldValidator ID="Validator3" ControlToValidate="Birthdate" ValidationGroup="val1" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

        </asp:RequiredFieldValidator>
            

                <ajaxToolkit:CalendarExtender  ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="Birthdate" Format="MM/dd/yyyy" />
           
            
        </p> 
      
        <p>
            <asp:TextBox ID="Email" meta:resourcekey="Email"  runat="server"></asp:TextBox>

              <asp:RegularExpressionValidator
                runat="server" 
                ID="EmailRegExpValidator" 
                ErrorMessage="Please enter valid email"
                ForeColor="Red"
                ControlToValidate="Email"
                ValidationGroup="val1"
                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
             </asp:RegularExpressionValidator>
        </p>

        <p>
            
            <asp:Button ID="Add_button" runat="server" OnClick="AddAuthor" 
                ValidationGroup="val1"
                text="validate"
                CausesValidation="true"
                meta:resourceKey="Add_button" />
        
        </p>
       

            <asp:GridView OnRowDataBound="AuthorGrid_RowDataBound" ID="Author_GridView" runat="server" AutoGenerateColumns="False"   DataKeyNames="ID"
                DataSourceID="DataFromLibrary" BackColor="White" BorderColor="#CCCCCC"  Height="100px" Width="900px" BorderStyle="None" 
                BorderWidth="1px" CellPadding="3"  AllowPaging="True"  >
                <Columns>               
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="true"  />
                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" CausesValidation="true" Text='<%# Bind("Name") %>'></asp:TextBox>
                          
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                          
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                    <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" />
                    <asp:BoundField DataField="Birthdate" HeaderText="Birthdate (MM/dd/yyyy)" SortExpression="Birthdate" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />

           <%--     <asp:BoundField DataField="AllowAuthor" HeaderText="AllowAuthor" SortExpression="AllowAuthor"  />--%>
                    <asp:TemplateField  HeaderText="AllowAuthor"  >
                        <ItemTemplate>
                            <asp:CheckBox  
                                ID="myCheckBox"
                                runat="server"
                                AutoPostBack="true"
                                Checked='<%# Convert.ToBoolean(Eval("AllowAuthor")) %>'
                                OnCheckedChanged="CheckBox1_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField  ShowEditButton="True"  ShowDeleteButton="True"/>
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
       
          
            <asp:ObjectDataSource ID="DataFromLibrary" runat="server" 
                SelectMethod="GetAuthors"
                DeleteMethod="DeleteAuthor"
                UpdateMethod="UpdateAuthor"
                TypeName="WebApplication4.LibraryDataAccessLayer"  >
                 
                <DeleteParameters>
                    <asp:Parameter  Name="ID" Type="Int32" />
                   
                </DeleteParameters>

                
                
           
            </asp:ObjectDataSource>

            
      
       
     


        



        
        <p>
            <asp:TextBox ID="BookName"  meta:resourcekey="bookName" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="Validator5" ControlToValidate="BookName" ValidationGroup="val2" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

        </asp:RequiredFieldValidator>
        </p>
       
        <p>
            <asp:TextBox ID="BookDescribtion"  meta:resourcekey="bookDescribtion" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Validator6" ControlToValidate="BookDescribtion" ValidationGroup="val2" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

        </asp:RequiredFieldValidator>
        </p>  
         <p>
            <asp:TextBox ID="BookReleaseDate"  meta:resourcekey="BookReleaseDate" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="Validator7" ControlToValidate="BookReleaseDate" ValidationGroup="val2" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

        </asp:RequiredFieldValidator>
        </p>  

            <p>
              <asp:DropDownList ID="AuthorNamesDropdown" runat="server" DataSourceID="AuthorNames" DataTextField="Name" DataValueField="ID">
                 
                       <asp:ListItem Text="choose a author" />
            </asp:DropDownList>
        </p>
           <p>
          <asp:DropDownList ID="GenresDropdown" runat="server" DataSourceID="Genres" DataTextField="GenreNames" DataValueField="ID">
                       <asp:ListItem Text="choose a Genre" />
            </asp:DropDownList>
        </p>
        
            <p>
                <asp:Button ID="Book_Add" runat="server" meta:resourceKey="Book_Add" OnClick="AddBook"    ValidationGroup="val2"
                text="validate"
                CausesValidation="true" />
           </p>
       


         <asp:gridview runat="server" AutoGenerateColumns="False" DataSourceID="DataFromBooks" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
             <Columns>
                 <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                 <asp:BoundField DataField="BookName" HeaderText="BookName" SortExpression="BookName" />
                 <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" SortExpression="AuthorName" />
                 <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                 <asp:BoundField DataField="BookDescribtion" HeaderText="BookDescribtion" SortExpression="BookDescribtion" />
                 <asp:BoundField DataField="ReleaseDate" HeaderText="ReleaseDate" SortExpression="ReleaseDate" />
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
            </asp:gridview>

        
     <asp:ObjectDataSource ID="DataFromBooks" runat="server"
     SelectMethod="GetBooks" 
     TypeName="WebApplication4.LibraryDataAccessLayer" >
     </asp:ObjectDataSource>


         <asp:ObjectDataSource ID="AuthorNames" runat="server"
          SelectMethod="GetAuthorNames" 
           TypeName="WebApplication4.LibraryDataAccessLayer">
           </asp:ObjectDataSource>


         <asp:ObjectDataSource ID="Genres" runat="server"
          SelectMethod="GetGenres" 
          TypeName="WebApplication4.LibraryDataAccessLayer">
         </asp:ObjectDataSource>



    </form>
</body>
</html>
