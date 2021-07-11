<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="Policy.aspx.cs" Inherits="Pages_Set_Policy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script>
        $(function () {
            $('#<%= txtSearch.ClientID  %>').quicksearch('#<%= gridViewPolicy.ClientID  %> tbody tr');
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <b>Admin / Policy</b>
            </div>
        </div>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Manage Policy</h6>
            </div>
            <div class="card-body">

                <asp:Label runat="server" ID="lblhiddenFieldForId" Visible="false"></asp:Label>

                <asp:Panel ID="panelPolicyTable" runat="server">

                    <div class="col-md-4 fa-pull-left">
                        <asp:Button runat="server" ID="btnAddPolicy" CssClass="btn btn-primary btn-sm" Text="Add Policy" OnClick="btnAddPolicy_Click" />
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
                        <asp:GridView ID="gridViewPolicy" runat="server" class="table table-striped text-justify"
                            AllowPaging="True" PageSize="20" AllowSorting="True"
                            GridLines="None"
                            OnRowCommand="gridViewPolicy_RowCommand" OnRowDataBound="gridViewPolicy_RowDataBound"
                            AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:TemplateField HeaderText="Id" SortExpression="Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price" SortExpression="DeliveryCharge">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeliveryCharge" runat="server" Text='<%# Bind("DeliveryCharge") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delivery Charge" SortExpression="ShippingCharge">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShippingCharge" runat="server" Text='<%# Bind("ShippingCharge") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vat %" SortExpression="Vat">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVat" runat="server" Text='<%# Bind("Vat") %>'></asp:Label>
                                    </ItemTemplate>
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
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server"
                                            CssClass="btn btn-primary btn-sm" CommandName="EditPolicy"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Edit</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-success  btn-sm" CommandName="DetailPolicy"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Details</asp:LinkButton>
                                        <asp:LinkButton runat="server" CssClass="btn btn-danger  btn-sm" CommandName="RemovePolicy"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"
                                            OnClientClick="if ( ! Remove()) return false;" meta:resourcekey="btnRemoveResource1">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                            SelectCommand="SELECT * FROM [tblPolicy] ORDER BY [Id] DESC"></asp:SqlDataSource>
                    </div>
                </asp:Panel>

                <asp:Panel ID="panelAddPolicy" Visible="false" runat="server">
                    <div class="mx-auto col-md-8">
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping">Price</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtDeliveryCharge" autocomplete="off" TextMode="Number"
                                    class="form-control" aria-describedby="addon-wrapping"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqtxtDeliveryCharge"
                                ControlToValidate="txtDeliveryCharge" Text="required" Display="Dynamic" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping2">Delivery Charge</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtShippingCharge" autocomplete="off" TextMode="Number"
                                    class="form-control" aria-describedby="addon-wrapping2"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqtxtShippingCharge"
                                ControlToValidate="txtShippingCharge" Text="required" Display="Dynamic" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping3">Vat %</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtVat" autocomplete="off" TextMode="Number"
                                    class="form-control" aria-describedby="addon-wrapping3"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator runat="server" ID="reqtxtVat"
                                ControlToValidate="txtVat" Text="required" Display="Dynamic" ForeColor="Red" />
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
                            Policy Id: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblPolicyIdView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Delivery Charge: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblDeliveryChargeView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Shipping Charge: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblShippingChargeView"></asp:Label>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            Vat %: 
                        </div>
                        <div class="col-md-3">
                            <asp:Label runat="server" ID="lblVatView"></asp:Label>
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
    <!-- /.container-fluid -->
</asp:Content>

