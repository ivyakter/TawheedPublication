<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="Book.aspx.cs" Inherits="Pages_Set_Book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script>
        <%--$(function () {
            $('#<%= txtSearch.ClientID  %>').quicksearch('#<%= gridViewBook.ClientID  %> tbody tr');
        })--%>
    </script>
    <script>
        $(document).ready(function () {
            $('#<%= txtBookTitle.ClientID  %>').autocomplete({
                source: '../../GenericHandler/BookName.ashx'
            });
        });
    </script>
    <%--<script>
        $(document).ready(function () {
            $('#<%= txtPublisher.ClientID  %>').autocomplete({
                source: '../../GenericHandler/PublisherName.ashx'
            });
        });
    </script>--%>
    <script>
        $(document).ready(function () {
            $('#<%= txtPublishedDate.ClientID  %>').datepicker({
                showOn: 'both',
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                minDate: null,
                maxDate: null
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $('#<%= ddlCategory.ClientID  %>').select2({
                placeholder: 'Choose...'
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $('#<%= ddlAuthor.ClientID  %>').select2({
                placeholder: 'Choose...'
            });
        });
    </script>
    <script type="text/javascript">
        function FrontImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgFrontImage.ClientID%>').prop('src', e.target.result)
                        .width(100)
                        .height(100);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <script type="text/javascript">
        function BackImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgBackImage.ClientID%>').prop('src', e.target.result)
                        .width(100)
                        .height(100);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <b>Admin / Book</b>
            </div>
        </div>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Manage Book</h6>
            </div>
            <div class="card-body">

                <asp:Label runat="server" ID="lblhiddenFieldForId" Visible="false"></asp:Label>

                <asp:Panel ID="panelBookTable" runat="server">

                    <div class="col-md-4 fa-pull-left">
                        <asp:Button runat="server" ID="btnAddBook" CssClass="btn btn-primary btn-sm" Text="Add Book" OnClick="btnAddBook_Click" />
                    </div>
                    <div class="col-md-4 fa-pull-right">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <div class="input-group-text">Search...</div>
                            </div>
                            <asp:TextBox runat="server" type="text" class="form-control"
                                ID="txtSearch" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gridViewBook" runat="server" class="table table-striped text-justify"
                            AllowPaging="True" PageSize="50" AllowSorting="True"
                            GridLines="None" onpageindexchanging="gridViewBook_PageIndexChanging"
                            OnRowCommand="gridViewBook_RowCommand" OnRowDataBound="gridViewBook_RowDataBound"
                            AutoGenerateColumns="False" >
                            <Columns>
                                <asp:TemplateField HeaderText="Id" SortExpression="Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title" SortExpression="Title">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBookTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblISBN" runat="server" Text='<%# Bind("ISBN") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number of Pages" SortExpression="NumberOfPages" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumberOfPages" runat="server" Text='<%# Bind("NumberOfPages") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Published Date" SortExpression="PublishedDate" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPublishedDate" runat="server" Text='<%# Bind("PublishedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                                
                                <asp:TemplateField HeaderText="Edition Number" SortExpression="EditionNumber" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEditionNumber" runat="server" Text='<%# Bind("EditionNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price" SortExpression="Price" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Discount" SortExpression="SpecialPrice" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSpecialPrice" runat="server" Text='<%# Bind("SpecialPrice") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" SortExpression="Description" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Most Sale" SortExpression="MostSale" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMostSale" runat="server" Text='<%# Bind("MostSale") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Front Image" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFrontImage" runat="server" Text='<%# Bind("FontImage") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Back Image" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBackImage" runat="server" Text='<%# Bind("BackImage") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pdf" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPdf" runat="server" Text='<%# Bind("Pdf") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="CreatedDateTime" HeaderText="Created On">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedDateTime" runat="server" Text='<%# Bind("CreatedDateTime", "{0:dd MMM yyyy (hh:mm tt)}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Views" SortExpression="Views">
                                    <ItemTemplate>
                                        <asp:Label ID="lblView" runat="server" Text='<%# Bind("Count") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Updated By" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastUpdatedBy" runat="server" Text='<%# Bind("LastUpdatedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Updated On" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastUpdatedDateTime" runat="server" Text='<%# Bind("LastUpdatedDateTime", "{0:dd MMM yyyy (hh:mm tt)}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnStatus" CssClass="badge badge-success" runat="server"
                                            CausesValidation="False"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="ActivateDeactivate"
                                            Text='<%# Bind("Status") %>' OnClientClick="if ( ! Update()) return false;"
                                            meta:resourcekey="btnUpdateResource1">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server"
                                            CssClass="btn btn-primary btn-sm" CommandName="EditBook"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Edit</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" CommandName="DetailBook"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Details</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm" CommandName="RemoveBook"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"
                                            OnClientClick="if ( ! Remove()) return false;" meta:resourcekey="btnRemoveResource1">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                            SelectCommand="SELECT * FROM [Books] ORDER BY [Id] DESC"></asp:SqlDataSource>
                    </div>
                </asp:Panel>

                <asp:Panel ID="panelAddBook" Visible="false" runat="server">
                    <div class="mx-auto col-md-8">
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Book Title</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtBookTitle" autocomplete="off"
                                    class="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqtxtBookTitle"
                                ControlToValidate="txtBookTitle" Text="required" Display="Dynamic" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Category</span>
                                </div>
                                <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="ddlMain" OnTextChanged="ddlMain_TextChanged" AutoPostBack="true" class="custom-select">
                                    <asp:ListItem Value="0" Text="Choose..."></asp:ListItem>
                                </asp:DropDownList>                                
                            </div>
                            <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddlMain" 
                            InitialValue="0"  Display="Dynamic" ForeColor="Red"  ErrorMessage="required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <label class="input-group-text" for="ddlCategory">SubCategory</label>
                                </div>
                                <%--                                <asp:DropDownList runat="server" AppendDataBoundItems="false" ID="ddlCategory"
                                    multiple="multiple" class="custom-select">
                                </asp:DropDownList>--%>
                                <select id="ddlCategory" name="ddlCategory[]" runat="server" class="form-control" multiple="true">
                                    <option value="0">Select Category</option>
                                </select>
                                <%--                                <asp:ListBox ID="ddlCategory" runat="server" 
                                    class="form-control select2" SelectionMode="Multiple">
                                </asp:ListBox>--%>
                            </div>
                         <%--   <asp:RequiredFieldValidator runat="server" ID="reqddlCategory" InitialValue="0"
                                ControlToValidate="ddlCategory" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <label class="input-group-text" for="ddlAuthor">Author</label>
                                </div>
                                <%--                                <asp:DropDownList runat="server" AppendDataBoundItems="false" ID="ddlAuthor"
                                    multiple="multiple" class="custom-select">
                                </asp:DropDownList>--%>
                                <select id="ddlAuthor" name="ddlAuthor[]" runat="server" class="form-control" multiple="true">
                                    <option value="0">Select Author</option>
                                </select>
                                <%--                                <asp:ListBox ID="ddlAuthor" runat="server" 
                                    class="form-control select2" SelectionMode="Multiple">
                                </asp:ListBox>--%>
                            </div>
                         <%--   <asp:RequiredFieldValidator runat="server" ID="reqddlAuthor"
                                ControlToValidate="ddlAuthor" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>

                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">ISBN</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtISBN"
                                    class="form-control"></asp:TextBox>
                            </div>
                          <%--  <asp:RequiredFieldValidator runat="server" ID="reqISBN"
                                ControlToValidate="txtISBN" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Number Of Pages</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtNumberOfPages" TextMode="Number"
                                    class="form-control"></asp:TextBox>
                            </div>
                         <%--   <asp:RequiredFieldValidator runat="server" ID="reqtxtNumberOfPages"
                                ControlToValidate="txtNumberOfPages" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Publication</span>
                                </div>
                                <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="ddlPublication" class="custom-select">
                                    <asp:ListItem Value="0" Text="Choose..."></asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:TextBox runat="server" ID="txtPublisher"
                                    class="form-control"></asp:TextBox>--%>
                            </div>
                           <%-- <asp:RequiredFieldValidator runat="server" ID="reqtxtPublisher"
                                ControlToValidate="txtPublisher" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Published Date</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtPublishedDate"
                                    class="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                            </div>
                          <%--  <asp:RequiredFieldValidator runat="server" ID="reqtxtPublishedDate"
                                ControlToValidate="txtPublishedDate" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Edition Number</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtEditionNumber" TextMode="Number"
                                    class="form-control"></asp:TextBox>
                            </div>
                         <%--   <asp:RequiredFieldValidator runat="server" ID="reqtxtEditionNumber"
                                ControlToValidate="txtEditionNumber" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Price</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtPrice"
                                    class="form-control"></asp:TextBox>
                            </div>
                          <%--  <asp:RequiredFieldValidator runat="server" ID="reqPrice"
                                ControlToValidate="txtPrice" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Old Price</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtOldPrice"
                                    class="form-control"></asp:TextBox>
                            </div>
                          <%--  <asp:RequiredFieldValidator runat="server" ID="reqPrice"
                                ControlToValidate="txtPrice" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Discount</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtSpecialPrice"
                                    class="form-control"></asp:TextBox>
                            </div>
                          <%--  <asp:RequiredFieldValidator runat="server" ID="reqSpecialPrice"
                                ControlToValidate="txtSpecialPrice" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <%--<div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Discount Price</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtDiscountPrice"
                                    class="form-control"></asp:TextBox>
                            </div>
                        </div>--%>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Description</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtDescription" autocomplete="off"
                                    class="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                            </div>
                          <%--  <asp:RequiredFieldValidator runat="server" ID="reqtxtDescription"
                                ControlToValidate="txtDescription" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Front Image</span>
                                </div>
                                <asp:FileUpload ID="fileFrontImage" class="form-control" runat="server" onchange="FrontImagePreview(this);" />
                            </div>
                            <div class="row">
                                <asp:Panel runat="server" ID="panelFrontImageEditView" Visible="false">
                                    <div class="col-md-2">
                                        <asp:GridView runat="server" ID="gridViewGetFrontImage" Width="100%"
                                            GridLines="None" AutoGenerateColumns="false" ShowHeader="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="old image">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgFrontImageEditView" runat="server" Width="100px" Height="100px" ImageUrl='<%# "../../BookImage/"+ Eval("Code") +"/"+ Eval("Code")+"Font"+Eval("FontImage") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                                <div class="col-md-2">
                                    <asp:Label runat="server" CssClass="font-weight-bold">new image</asp:Label>
                                    <asp:Image runat="server" ID="imgFrontImage" />
                                </div>
                            </div>
                          <%--  <asp:RequiredFieldValidator runat="server" ID="reqfileFrontImage"
                                ControlToValidate="fileFrontImage" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Back Image</span>
                                </div>
                                <asp:FileUpload ID="fileBackImage" class="form-control" runat="server" onchange="BackImagePreview(this);" />
                            </div>
                            <div class="row">
                                <asp:Panel runat="server" ID="panelBackImageEditView" Visible="false">
                                    <div class="col-md-2">
                                        <asp:GridView runat="server" ID="gridViewGetBackImage" Width="100%"
                                            GridLines="None" AutoGenerateColumns="false" ShowHeader="true" >
                                            <Columns>
                                                <asp:TemplateField HeaderText="old image">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgBackImageEditView" runat="server" Width="100px" Height="100px"
                                                            ImageUrl='<%# "../../BookImage/"+ Eval("Code") +"/"+ Eval("Code")+"Back"+Eval("FontImage") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                                <div class="col-md-2">
                                    <asp:Label runat="server" CssClass="font-weight-bold">new image</asp:Label>
                                    <asp:Image runat="server" ID="imgBackImage" />
                                </div>
                            </div>
                        <%--    <asp:RequiredFieldValidator runat="server" ID="reqfileBackImage"
                                ControlToValidate="fileBackImage" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Pdf</span>
                                </div>
                                <asp:FileUpload ID="filePdf" class="form-control" runat="server" />
                            </div>
                            <div>
                                <asp:GridView runat="server" Visible="false" ID="gridViewGetPdf" Width="100%"
                                    GridLines="None" AutoGenerateColumns="False" ShowHeader="true"
                                    OnRowCommand="gridViewGetPdf_RowCommand" DataSourceID="SqlDataSource2">
                                    <Columns>
                                        <asp:TemplateField HeaderText="old file">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDownloadPdf" runat="server" CausesValidation="false"
                                                    CommandName="DownloadPdf" Text='<%# Eval("Pdf") %>'
                                                    CommandArgument='<%# Eval("Pdf") %>'>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                         <%--   <asp:RequiredFieldValidator runat="server" ID="reqPdf"
                                ControlToValidate="filePdf" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <label class="input-group-text" for="ddlMostSale">Most Sale</label>
                                </div>
                                <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="ddlMostSale" class="custom-select">
                                    <asp:ListItem Value="0" Text="Choose..."></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        <%--    <asp:RequiredFieldValidator runat="server" ID="reqddlMostSale" InitialValue="0"
                                ControlToValidate="ddlMostSale" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <label class="input-group-text" for="ddlMostSale">Upcoming</label>
                                </div>
                                <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="ddlUpcoming" class="custom-select">
                                    <asp:ListItem Value="0" Text="Choose..."></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                       <%--     <asp:RequiredFieldValidator runat="server" ID="reqddlUpcoming" InitialValue="0"
                                ControlToValidate="ddlUpcoming" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <label class="input-group-text" for="ddlMostSale">New</label>
                                </div>
                                <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="ddlNew" class="custom-select">
                                    <asp:ListItem Value="0" Text="Choose..."></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                           <%-- <asp:RequiredFieldValidator runat="server" ID="reqddlNew" InitialValue="0"
                                ControlToValidate="ddlNew" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <label class="input-group-text" for="ddlMostSale">Popular</label>
                                </div>
                                <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="ddlPopular" class="custom-select">
                                    <asp:ListItem Value="0" Text="Choose..."></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                           <%-- <asp:RequiredFieldValidator runat="server" ID="reqddlNew" InitialValue="0"
                                ControlToValidate="ddlNew" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-secondary btn-sm"
                            Text="Cancel" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary btn-sm" Text="Submit" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnUpdate" Visible="false" runat="server" class="btn btn-primary btn-sm" Text="Update"
                            OnClick="btnUpdate_Click" OnClientClick="if ( ! Update()) return false;"
                            meta:resourcekey="btnUpdateResource1" />
                    </div>
                </asp:Panel>

                <asp:Panel runat="server" ID="panelDetail" Visible="false">
                    <div class="row form-group">
                        <div class="col-md-3">
                            Book Id: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblBookIdView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Book Title: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblBookTitleView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Book Categories: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblBookCategory"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            SubCategories List: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblBookCategoriesView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Book Authors: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblBookAuthorsView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            View Count: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblBookViewCount"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            ISBN: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblISBNView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Number Of Pages: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblNumberOfPagesView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Published Date: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblPublishedDateView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Edition Number: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblEditionNumberView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Price: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblPriceView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Old Price: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblOldprice"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Discount: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblSpecialPriceView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Description: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblDescriptionView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Status: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblStatusView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Most Sale: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblMostSaleView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Front Image: 
                        </div>
                        <div class="col-md-3">
                            <asp:GridView runat="server" ID="gridViewFrontImageView" Width="100%"
                                GridLines="None" AutoGenerateColumns="false" ShowHeader="false" >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image ID="imgFrontImageDetailView" runat="server" Width="100px" Height="100px"
                                                ImageUrl='<%# "../../BookImage/"+ Eval("Code") +"/"+ Eval("Code")+"Font"+Eval("FontImage") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceFrontImage" runat="server"
                                ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                                SelectCommand="SELECT [Id], [FontImage] FROM [Books] WHERE ([Id] = @Id)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lblhiddenFieldForId"
                                        Name="Id" PropertyName="Text" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Back Image: 
                        </div>
                        <div class="col-md-3">
                            <asp:GridView runat="server" ID="gridViewBackImageView" Width="100%"
                                GridLines="None" AutoGenerateColumns="false" ShowHeader="false" >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image ID="imgBackImageDetailView" runat="server" Width="100px" Height="100px" ImageUrl='<%# "../../BookImage/"+ Eval("Code") +"/"+ Eval("Code")+"Back"+Eval("FontImage") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceBackImage" runat="server"
                                ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                                SelectCommand="SELECT [Id], [BackImage] FROM [Books] WHERE ([Id] = @Id)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lblhiddenFieldForId"
                                        Name="Id" PropertyName="Text" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Pdf: 
                        </div>
                        <div class="col-md-3">
                            <asp:GridView runat="server" ID="gridViewPdfDownload" Width="100%"
                                GridLines="None" AutoGenerateColumns="False" ShowHeader="False"
                                OnRowCommand="gridViewPdfDownload_RowCommand" DataSourceID="SqlDataSource2">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDownloadPdf" runat="server" CausesValidation="false"
                                                CommandName="DownloadPdf" Text='<%# Eval("Pdf") %>'
                                                CommandArgument='<%# Eval("Pdf") %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                                ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                                SelectCommand="SELECT [Id], [Pdf] FROM [Books] WHERE ([Id] = @Id)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lblhiddenFieldForId"
                                        Name="Id" PropertyName="Text" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>

                    <div class="row form-group">
                        <div class="col-md-3">
                            Created By:
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblCreatedByView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Created On:
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblCreateDateTimeView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Last Updated By:
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblLastUpdatedByView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Last Updated On:
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblLastUpdatedOnView"></asp:Label>
                        </div>
                    </div>
                    <asp:Button ID="btnGoBack" runat="server" CausesValidation="false" class="btn btn-secondary btn-sm"
                        Text="Back" OnClick="btnGoBack_Click" />
                </asp:Panel>

            </div>
        </div>
    </div>
    <!-- /.container-fluid -->
</asp:Content>

