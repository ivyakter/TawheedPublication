<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="Publication.aspx.cs" Inherits="Pages_Set_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script>
        $(function () {
            $('#<%= txtSearch.ClientID  %>').quicksearch('#<%= gridViewCategory.ClientID  %> tbody tr');
        })
    </script>
    <script>
        $(document).ready(function () {
            $('#<%= txtCategoryName.ClientID  %>').autocomplete({
                source: '../../GenericHandler/CategoryName.ashx'
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
                <b>Admin / Publication</b>
            </div>
        </div>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Manage Publication</h6>
            </div>
            <div class="card-body">

                <asp:Label runat="server" ID="lblhiddenFieldForId" Visible="false"></asp:Label>

                <asp:Panel ID="panelCategoryTable" runat="server">

                    <div class="col-md-4 fa-pull-left">
                        <asp:Button runat="server" ID="btnAddCategory" CssClass="btn btn-primary btn-sm" Text="Add Publication" OnClick="btnAddCategory_Click" />
                    </div>
                    <div class="col-md-4 fa-pull-right">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <div class="input-group-text">Search...</div>
                            </div>
                            <asp:TextBox runat="server" type="text" class="form-control" Placeholder="Search by name..."
                                ID="txtSearch" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gridViewCategory" runat="server" class="table table-striped text-justify"
                            AllowPaging="True" PageSize="50" AllowSorting="True"
                            GridLines="None" onpageindexchanging="gridViewCategory_PageIndexChanging"
                            OnRowCommand="gridViewCategory_RowCommand" OnRowDataBound="gridViewCategory_RowDataBound"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Id" SortExpression="Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="150" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategoryName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
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
                                            CssClass="btn btn-primary btn-sm" CommandName="EditCategory"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Edit</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-success  btn-sm" CommandName="DetailCategory"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Details</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-danger  btn-sm" CommandName="RemoveCategory"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"
                                            OnClientClick="if ( ! Remove()) return false;" meta:resourcekey="btnRemoveResource1">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                            SelectCommand="SELECT * FROM [tblCategories] ORDER BY [Id] DESC"></asp:SqlDataSource>
                    </div>
                </asp:Panel>

                <asp:Panel ID="panelAddCategory" Visible="false" runat="server">
                    <div class="mx-auto col-md-8">
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping">Publication Name</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtCategoryName" autocomplete="off"
                                    class="form-control" aria-describedby="addon-wrapping"></asp:TextBox>
                                <asp:TextBox visible="false" ID="txtsubcatid" runat="server"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqCategoryName"
                                ControlToValidate="txtCategoryName" Text="required" Display="Dynamic" ForeColor="Red" />
                        </div>  
                        <div class="form-group">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">Description</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtDescription" autocomplete="off"
                                    class="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                <asp:TextBox visible="false" ID="TextBox1" runat="server"></asp:TextBox>
                            </div>
                         <%--   <asp:RequiredFieldValidator runat="server" ID="reqtxtDescription"
                                ControlToValidate="txtDescription" Text="required" Display="Dynamic" ForeColor="Red" />--%>
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
                            Publication Id: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblCategoryIdView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Publication Name: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblCategoryNameView"></asp:Label>
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
                    <asp:Button ID="btnGoBack" runat="server" CausesValidation="false" class="btn btn-secondary  btn-sm"
                        Text="Back" OnClick="btnGoBack_Click" />
                </asp:Panel>

            </div>
        </div>
    </div>
</asp:Content>

