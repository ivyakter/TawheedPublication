<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Pages_Set_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script>
        $(function () {
            $('#<%= txtSearch.ClientID  %>').quicksearch('#<%= gridViewAdmin.ClientID  %> tbody tr');
        })
    </script>
    <script>
        $(document).ready(function () {
            $('#<%= txtName.ClientID  %>').autocomplete({
                source: '../../GenericHandler/UserName.ashx'
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <b>Admin / Admin</b>
            </div>
        </div>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Manage Admin</h6>
            </div>
            <div class="card-body">

                <asp:Label runat="server" ID="lblhiddenFieldForId" Visible="false"></asp:Label>

                <asp:Panel ID="panelAdminTable" runat="server">

                    <div class="col-md-4 fa-pull-left">
                        <asp:Button runat="server" ID="btnAddAdmin" CssClass="btn btn-primary btn-sm" Text="Add Admin" OnClick="btnAddAdmin_Click" />
                    </div>
                    <div class="col-md-4 fa-pull-right">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <div class="input-group-text">Search...</div>
                            </div>
                            <asp:TextBox runat="server" type="text" class="form-control"
                                ID="txtSearch" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gridViewAdmin" runat="server" class="table table-striped text-justify"
                            AllowPaging="True" PageSize="20" AllowSorting="True"
                            GridLines="None"
                            OnRowCommand="gridViewAdmin_RowCommand" OnRowDataBound="gridViewAdmin_RowDataBound"
                            AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:TemplateField HeaderText="Id" SortExpression="Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdminName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile Number" SortExpression="Phone">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("MobileNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" SortExpression="CreatedDateTime" HeaderText="Created On">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedDateTime" runat="server" Text='<%# Bind("CreatedDate", "{0:dd MMM yyyy (hh:mm tt)}") %>'></asp:Label>
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
                                            CssClass="btn btn-primary btn-sm" CommandName="EditAdmin"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Edit</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-success  btn-sm" CommandName="DetailAdmin"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Details</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-danger  btn-sm" CommandName="RemoveAdmin"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"
                                            OnClientClick="if ( ! Remove()) return false;" meta:resourcekey="btnRemoveResource1">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                            SelectCommand="SELECT * FROM [tblAdmin] ORDER BY [Id] DESC">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="1" Name="RoleTypeId" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </asp:Panel>

                <asp:Panel ID="panelAddAdmin" Visible="false" runat="server">
                    <div class="mx-auto col-md-8">
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping">Name</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtName" autocomplete="off"
                                    class="form-control" aria-describedby="addon-wrapping"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqName"
                                ControlToValidate="txtName" Text="required" Display="Dynamic" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Mobile No</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtPhone" autocomplete="off"
                                    class="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqtxtPhone"
                                ControlToValidate="txtPhone" Text="required" Display="Dynamic" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="revtxtPhone" runat="server" ErrorMessage="invalid phone number"
                                ControlToValidate="txtPhone" Display="Dynamic" ForeColor="Red"
                                ValidationExpression="^([\+]?(?:00)?[0-9]{1,3}[\s.-]?[0-9]{1,12})([\s.-]?[0-9]{1,4}?)$">
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Email</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtEmail" autocomplete="off"
                                    class="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqtxtEmail"
                                ControlToValidate="txtEmail" Text="required" Display="Dynamic" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="revtxtEmail"
                                runat="server" ControlToValidate="txtEmail"
                                ForeColor="Red" Display="Dynamic" Text="invalid email"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Password</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtPassword" autocomplete="off"
                                    class="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqtxtPassword"
                                ControlToValidate="txtPassword" Text="required" Display="Dynamic" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Confirm Password</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtConfirmPassword" autocomplete="off"
                                    class="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqtxtConfirmPassword"
                                ControlToValidate="txtConfirmPassword" Text="required" Display="Dynamic" ForeColor="Red" />
                            <asp:CompareValidator ID="cvrPassword" runat="server"
                                ControlToValidate="txtConfirmPassword" ForeColor="Red"
                                ControlToCompare="txtPassword" Display="Dynamic"
                                Type="String" Operator="Equal" Text="password doesn't match">
                            </asp:CompareValidator>
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
                            Admin Id: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblAdminIdView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Admin Name: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblAdminNameView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Mobile: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblMobileView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Email/ Username: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblEmailView"></asp:Label>
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
                            Created On:
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblCreateDateTimeView"></asp:Label>
                        </div>
                    </div>
                    <asp:Button ID="btnGoBack" runat="server" CausesValidation="false" class="btn btn-secondary  btn-sm"
                        Text="Back" OnClick="btnGoBack_Click" />
                </asp:Panel>

            </div>
        </div>
    </div>
    <!-- /.container-fluid -->
</asp:Content>

