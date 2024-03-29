﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booklibrary.aspx.cs" Inherits="WebApplication4.Booklibrary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ OutputCache Duration="60" VaryByParam="none" %>--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/CustomScript.js"></script>
   

    <style>
        #Authors_div {
            display: none;
        }

        #Books_div {
            display: none;
        }

        #Author_list {
            text-align: left;
        }

        .w {
            height: 263px;
        }
    </style>


</head>
<body>


    <form id="Author_list" runat="server">


        <asp:ScriptManager ID="ScriptManager" runat="server">
        </asp:ScriptManager>
        
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
        <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged">
            <asp:ListItem Text="choose a language" />
            <asp:ListItem Text="English" Value="en-us" />
            <asp:ListItem Text="ქართული" Value="ka-ge" />
        </asp:DropDownList>


        <asp:Button class="btn btn-info btn-block " runat="server" type="submit" OnClick="Logout" Text="Log out" />
        <br />
        <br />


        <asp:Button class="btn btn-info btn-block " runat="server" type="submit" OnClick="Unnamed_Click" Text="manage users" />


        <label runat="server" id="AddUserToggle">Add Author ▼</label>
        <br />
        <br />
        <div runat="server" id="Authors_div">




            <p>
                <asp:TextBox ID="Name" meta:resourcekey="Name" runat="server"></asp:TextBox>





                <asp:RequiredFieldValidator ControlToValidate="Name" ValidationGroup="authorval" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

                </asp:RequiredFieldValidator>


            </p>


            <p>
                <asp:TextBox ID="Surname" meta:resourcekey="Surname" runat="server"></asp:TextBox>

                <asp:RequiredFieldValidator ControlToValidate="Name" ValidationGroup="authorval" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

                </asp:RequiredFieldValidator>

            </p>



            <p>
                <asp:TextBox ID="Nationality" meta:resourcekey="Nationality" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="Nationality" ValidationGroup="authorval" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

                </asp:RequiredFieldValidator>
            </p>

            <p>
                <asp:TextBox ID="Birthdate" meta:resourcekey="Birthdate" runat="server" AutoComplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="Birthdate" ValidationGroup="authorval" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

                </asp:RequiredFieldValidator>


                <ajaxToolkit:CalendarExtender PopupButtonID="imgPopup" runat="server" TargetControlID="Birthdate" Format="MM/dd/yyyy" />


            </p>

            <p>
                <asp:TextBox ID="Email" meta:resourcekey="Email" runat="server"></asp:TextBox>

                <asp:RegularExpressionValidator
                    runat="server"
                    ID="EmailRegExpValidator"
                    ErrorMessage="Please enter valid email"
                    ForeColor="Red"
                    ControlToValidate="Email"
                    ValidationGroup="authorval"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </p>

            <p>

                <asp:Button ID="Add_button" runat="server" OnClick="AddAuthor"
                    ValidationGroup="authorval"
                    Text="validate"
                    CausesValidation="true"
                    meta:resourceKey="Add_button" />

            </p>

        </div>


        <asp:GridView OnRowDataBound="AuthorGrid_RowDataBound" ID="Author_GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="DataFromLibrary" BackColor="White" BorderColor="#CCCCCC" Height="100px" Width="900px" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="true" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="Nationality" />
                <asp:BoundField DataField="Birthdate" HeaderText="Birthdate (MM/dd/yyyy)" SortExpression="Birthdate" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:CheckBoxField HeaderText="Allow" DataField="AllowAuthor" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
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


        <asp:RegularExpressionValidator
            runat="server"
            ID="RegularExpressionValidator1"
            ErrorMessage="Please enter valid email"
            ForeColor="Red"
            ControlToValidate="Email"
            ValidationGroup="authorval"
            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
        </asp:RegularExpressionValidator>


        <asp:ObjectDataSource ID="DataFromLibrary" runat="server"
            SelectMethod="GetAuthors"
            DeleteMethod="DeleteAuthor"
            UpdateMethod="UpdateAuthor"
            TypeName="WebApplication4.DALlibrary">

            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />

            </DeleteParameters>




        </asp:ObjectDataSource>
        <br />

        <label runat="server" id="AddBookToggle">Add Book ▼</label>
        <br />
        <br />

        <div runat="server" id="Books_div">
            <p>
                <asp:TextBox ID="BookName" meta:resourcekey="bookName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Validator5" ControlToValidate="BookName" ValidationGroup="bookval" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

                </asp:RequiredFieldValidator>
            </p>

            <p>
                <asp:TextBox ID="BookDescribtion" meta:resourcekey="bookDescribtion" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Validator6" ControlToValidate="BookDescribtion" ValidationGroup="bookval" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

                </asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:TextBox ID="BookReleaseDate" meta:resourcekey="BookReleaseDate" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Validator7" ControlToValidate="BookReleaseDate" ValidationGroup="bookval" ErrorMessage="შეავსეთ გამოტოვებული ველი" runat="server">

                </asp:RequiredFieldValidator>
            </p>

            <p>
                <asp:DropDownList ID="AuthorNamesDropdown" runat="server" DataSourceID="AuthorNames" DataTextField="Name" DataValueField="ID">

                    <asp:ListItem Text="choose a author" />
                </asp:DropDownList>
            </p>
            <p>
                <asp:DropDownList ID="GenresDropdown" runat="server" DataSourceID="Genres" DataTextField="Genre" DataValueField="ID">
                    <asp:ListItem Text="choose a Genre" />
                </asp:DropDownList>
            </p>

            <p>
                <asp:Button ID="Book_Add" runat="server" meta:resourceKey="Book_Add" OnClick="AddBook" ValidationGroup="bookval"
                    Text="validate"
                    CausesValidation="true" />
            </p>
        </div>








        <asp:GridView ID="Book_gridview" runat="server" AutoGenerateColumns="False" DataSourceID="DataFromBooks" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="BookName" HeaderText="BookName" SortExpression="BookName" />
                <asp:BoundField DataField="BookDescribtion" HeaderText="BookDescribtion" SortExpression="BookDescribtion" />
                <asp:BoundField DataField="ReleaseDate" HeaderText="ReleaseDate" SortExpression="ReleaseDate" />
                <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" SortExpression="AuthorName" />
                <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
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




                <asp:DropDownList ID="AuthorNamesListDropdown" DataValueField="ID" DataTextField="AuthorName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="AuthorNamesList_SelectedIndexChanged">
                </asp:DropDownList>


                <asp:DropDownList ID="GenresOfAuthorsDropdown" DataValueField="ID" DataTextField="Genre" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                


                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="503px" DataSourceID="SearchAuthorInfoByName">
                    <Columns>
                        <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" SortExpression="AuthorName" />
                        <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                        <asp:BoundField DataField="BookName" HeaderText="BookName" SortExpression="BookName" />
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
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>





        <asp:ObjectDataSource ID="DataFromBooks" runat="server"
            SelectMethod="GetBooks"
            TypeName="WebApplication4.DALlibrary"></asp:ObjectDataSource>


        <asp:ObjectDataSource ID="AuthorNames" runat="server"
            SelectMethod="GetAuthorNames"
            TypeName="WebApplication4.DALlibrary" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>


        <asp:ObjectDataSource ID="Genres" runat="server"
            SelectMethod="GetGenres"
            TypeName="WebApplication4.DALlibrary" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>



        <asp:SqlDataSource ID="SearchAuthorInfoByName" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>"
            SelectCommand="GetSelectedAuthorInfo" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="AuthorNamesListDropdown" Name="AuthorId" PropertyName="SelectedValue" Type="Int32" DefaultValue="0" />
                <asp:ControlParameter ControlID="GenresOfAuthorsDropdown" Name="GenreId" PropertyName="SelectedValue" Type="Int32" DefaultValue="0" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel>

    </form>
</body>
</html>
