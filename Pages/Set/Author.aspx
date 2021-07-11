<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="Author.aspx.cs" Inherits="Pages_Set_Author" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script>
        <%--$(function () {
            $('#<%= txtSearch.ClientID  %>').quicksearch('#<%= gridViewAuthor.ClientID  %> tbody tr');
        })--%>
    </script>
    <script>
        $(document).ready(function () {
            $('#<%= txtAuthorName.ClientID  %>').autocomplete({
                source: '../../GenericHandler/AuthorName.ashx'
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $('#<%= txtDateOfBirth.ClientID  %>').datepicker({
                showOn: 'both',
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                minDate: null,
                maxDate: null
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <b>Admin / Author</b>
            </div>
        </div>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Manage Author</h6>
            </div>
            <div class="card-body">

                <asp:Label runat="server" ID="lblhiddenFieldForId" Visible="false"></asp:Label>

                <asp:Panel ID="panelAuthorTable" runat="server">

                    <div class="col-md-4 fa-pull-left">
                        <asp:Button runat="server" ID="btnAddAuthor" CssClass="btn btn-primary btn-sm" Text="Add Author" OnClick="btnAddAuthor_Click" />
                    </div>
                    <div class="col-md-4 fa-pull-right">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <div class="input-group-text">Search...</div>
                            </div>
                            <asp:TextBox runat="server" type="text" class="form-control" placeholder="Search by name.."
                                ID="txtSearch" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gridViewAuthor" runat="server" class="table table-striped text-justify"
                            AllowPaging="True" PageSize="50" AllowSorting="True" onpageindexchanging="gridViewAuthor_PageIndexChanging"
                            GridLines="None"
                            OnRowCommand="gridViewAuthor_RowCommand" OnRowDataBound="gridViewAuthor_RowDataBound"
                            AutoGenerateColumns="False" >
                            <Columns>
                                <asp:TemplateField HeaderText="Id" SortExpression="Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAuthorName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" SortExpression="Description" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DateOfBirth" SortExpression="DateOfBirth" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateOfBirth" runat="server" Text='<%# Bind("DateOfBirth") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gender" SortExpression="Gender" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGender" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address" SortExpression="Address" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" SortExpression="Email" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Popular" SortExpression="Phone" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="Created By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedBy" runat="server" Text='<%# Bind("CreatedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="CreatedDateTime" HeaderText="Created On">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedDateTime" runat="server" Text='<%# Bind("CreatedDateTime", "{0:dd MMM yyyy (hh:mm tt)}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="Last Updated By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastUpdatedBy" runat="server" Text='<%# Bind("LastUpdatedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="Last Updated On">
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
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server"
                                            CssClass="btn btn-primary btn-sm" CommandName="EditAuthor"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Edit</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" CommandName="DetailAuthor"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Details</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm" CommandName="RemoveAuthor"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"
                                            OnClientClick="if ( ! Remove()) return false;" meta:resourcekey="btnRemoveResource1">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                            SelectCommand="SELECT * FROM [Writer] ORDER BY [Id] DESC"></asp:SqlDataSource>
                    </div>
                </asp:Panel>

                <asp:Panel ID="panelAddAuthor" Visible="false" runat="server">
                    <div class="mx-auto col-md-8">
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping">Author Name</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtAuthorName" autocomplete="off"
                                    class="form-control" aria-describedby="addon-wrapping"></asp:TextBox>
                                <asp:Label ID="lvlWriterCode" runat="server" Visible="false"></asp:Label>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqAuthorName"
                                ControlToValidate="txtAuthorName" Text="required" Display="Dynamic" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Description</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtDescription" autocomplete="off"
                                    class="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                            </div>
                         <%--   <asp:RequiredFieldValidator runat="server" ID="reqtxtDescription"
                                ControlToValidate="txtDescription" Text="required" Display="Dynamic" ForeColor="Red" />--%>

                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Date Of Birth</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtDateOfBirth" autocomplete="off"
                                    class="form-control" placeholder="dd/mm/yyyy" aria-describedby="addon-wrapping"></asp:TextBox>
                            </div>
                          <%--  <asp:RequiredFieldValidator runat="server" ID="reqtxtDateOfBirth"
                                ControlToValidate="txtDateOfBirth" Text="required" Display="Dynamic" ForeColor="Red" />--%>

                        </div>
                        <div class="form-group">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <label class="input-group-text" for="ddlGender">Gender</label>
                                </div>
                                <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="ddlGender" class="custom-select">
                                    <asp:ListItem Value="0" Text="Choose..."></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqddlGender" InitialValue="0"
                                ControlToValidate="ddlGender" Text="required" Display="Dynamic" ForeColor="Red" />

                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Address</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtAddress" autocomplete="off"
                                    class="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </div>
                           <%-- <asp:RequiredFieldValidator runat="server" ID="reqtxtAddress"
                                ControlToValidate="txtAddress" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Email</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtEmail" autocomplete="off"
                                    class="form-control"></asp:TextBox>
                            </div>
                           <%-- <asp:RequiredFieldValidator runat="server" ID="reqtxtEmail"
                                ControlToValidate="txtEmail" Text="required" Display="Dynamic" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="revtxtEmail"
                                runat="server" ControlToValidate="txtEmail"
                                ForeColor="Red" Display="Dynamic" Text="invalid email"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                            </asp:RegularExpressionValidator>--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Popular</span>
                                </div>
                                <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="ddlPopular" class="custom-select">
                                    <asp:ListItem Value="0" Text="Choose..."></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div> 
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Image</span>
                                </div>
                                <asp:FileUpload ID="fileFrontImage" class="form-control" runat="server" onchange="FrontImagePreview(this);" />
                                <asp:Label ID="lvlImage" runat="server" Visible="false"></asp:Label>
                            </div>
                            <div class="row">
                                <asp:Panel runat="server" ID="panelFrontImageEditView" Visible="false">
                                    <div class="col-md-2">
                                        <asp:GridView runat="server" ID="gridViewGetFrontImage" Width="100%"
                                            GridLines="None" AutoGenerateColumns="false" ShowHeader="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="old image">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgFrontImageEditView" runat="server" Width="100px" Height="100px" ImageUrl='<%# "../../BookImage/Writer/"+Eval("Extension") %>' />
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
                            Author Id: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblAuthorIdView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Author Name: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblAuthorNameView"></asp:Label>
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
                            Date Of Birth: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblDateOfBirthView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Gender: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblGenderView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Address: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblAddressView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Email: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblEmailView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Popular: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblPhoneView"></asp:Label>
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
                            Image: 
                        </div>
                        <div class="col-md-3">
                            <asp:GridView runat="server" ID="gridViewImage" Width="100%"
                                GridLines="None" AutoGenerateColumns="false" ShowHeader="false" >
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image ID="imgFrontImageDetailView" runat="server" Width="100px" Height="100px"
                                                ImageUrl='<%# "../../BookImage/Writer/"+Eval("Extension") %>'  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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

