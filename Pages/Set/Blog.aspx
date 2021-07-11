<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Pages_Set_Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        <%--$(function () {
            $('#<%= txtSearch.ClientID  %>').quicksearch('#<%= gridViewBlog.ClientID  %> tbody tr');
        })--%>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <b>Admin / Blog</b>
            </div>
        </div>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Manage Blog</h6>
            </div>
            <div class="card-body">

                <asp:Label runat="server" ID="lblhiddenFieldForId" Visible="false"></asp:Label>

                <asp:Panel ID="panelBlogTable" runat="server">

                    <div class="col-md-4 fa-pull-left">
                        <asp:Button runat="server" ID="btnAddBlog" CssClass="btn btn-primary btn-sm" Text="Write A Blog" OnClick="btnAddBlog_Click" />
                    </div>
                    <div class="col-md-4 fa-pull-right">
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <div class="input-group-text">Search...</div>
                            </div>
                            <asp:TextBox runat="server" type="text" class="form-control" placeholder="Search by title.."
                                ID="txtSearch" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="gridViewBlog" runat="server" class="table table-striped text-justify"
                            AllowPaging="True" PageSize="20" AllowSorting="True"
                            GridLines="None"
                            OnRowCommand="gridViewBlog_RowCommand" OnRowDataBound="gridViewBlog_RowDataBound"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Id" SortExpression="Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title" SortExpression="DeliveryCharge">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeliveryCharge" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="Created By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedBy" runat="server" Text='<%# Bind("CreatedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="CreatedDateTime" HeaderText="Created On">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedDateTime" runat="server" Text='<%# Bind("CreatedDate", "{0:dd MMM yyyy (hh:mm tt)}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="Last Updated By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastUpdatedBy" runat="server" Text='<%# Bind("UpdatedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="Last Updated On">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastUpdatedDateTime" runat="server" Text='<%# Bind("UpdatedDate", "{0:dd MMM yyyy (hh:mm tt)}") %>'></asp:Label>
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
                                            CssClass="btn btn-primary btn-sm" CommandName="EditBlog"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Edit</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-success  btn-sm" CommandName="DetailBlog"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Details</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-danger  btn-sm" CommandName="RemoveBlog"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"
                                            OnClientClick="if ( ! Remove()) return false;" meta:resourcekey="btnRemoveResource1">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                            SelectCommand="SELECT * FROM [tblBlog] ORDER BY [Id] DESC"></asp:SqlDataSource>
                    </div>
                </asp:Panel>

                <asp:Panel ID="panelAddBlog" Visible="false" runat="server">
                    <div class="mx-auto col-md-8">
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping">Title: </span>
                                </div>
                                <asp:TextBox runat="server" ID="txtTitle" autocomplete="off"
                                    class="form-control" aria-describedby="addon-wrapping"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping2">Description</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtDescription" autocomplete="off" TextMode="MultiLine" Rows="10"
                                    class="form-control" aria-describedby="addon-wrapping2"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping3">Image</span>
                                </div>
                                <asp:FileUpload ID="fileFrontImage" class="form-control" runat="server" onchange="FrontImagePreview(this);" />
                            </div>
                            <div class="row">
                                <asp:Panel runat="server" ID="panelImageEditView" Visible="false">
                                    <div class="col-md-2">
                                        <asp:GridView runat="server" ID="gridViewImage" Width="100%"
                                            GridLines="None" AutoGenerateColumns="false" ShowHeader="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="old image">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgFrontImageEditView" runat="server" Width="100px" Height="100px" ImageUrl='<%# "../../lib/Blog/"+ Eval("img") %>' />
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
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="font-weight-bold">Or</asp:Label>
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping4">Video: </span>
                                </div>
                                <asp:TextBox runat="server" ID="txtVideo" autocomplete="off" placeholder="Ex: tF3dQTLJYTI&t=6s"
                                    class="form-control" aria-describedby="addon-wrapping4"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping5">Category: </span>
                                </div>
                                <asp:DropDownList class="form-control" ID="ddlCategory" runat="server">
                                    <asp:ListItem>Popular</asp:ListItem>
                                    <asp:ListItem>Leatest</asp:ListItem>
                                    <asp:ListItem>Video</asp:ListItem>
                                </asp:DropDownList>
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
                            Blog Id: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblBlogIdView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Blog Title: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblBlogTitleView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Image: 
                        </div>
                        <div class="col-md-9">
                            <asp:Repeater ID="rptBlogImage" runat="server">
                                <ItemTemplate>
                                    <asp:Image ID="imgFrontImageEditView" runat="server" Width="100px" Height="100px" ImageUrl='<%# "../../lib/Blog/"+ Eval("img") %>' />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Description: 
                        </div>
                        <div class="col-md-9">
                            <asp:Label runat="server" ID="lblDescriptionView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Created by: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblCreatedByView"></asp:Label>
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
    <!-- /.container-fluid -->
</asp:Content>

