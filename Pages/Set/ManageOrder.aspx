<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ManageOrder.aspx.cs" Inherits="Pages_Set_ManageOrder" MaintainScrollPositionOnPostback="true" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script>
        $(function () {
            $('#<%= txtSearch.ClientID  %>').quicksearch('#<%= gridViewOrders.ClientID  %> tbody tr');
        })

    </script>--%>
    <script type='text/javascript'>
        function openModal() {
            $('#modal_box').modal('show');
        }
    </script>
    <%--<script src="../../lib/admin/js/print.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <b>Admin / Orders</b>
            </div>
        </div>

        <!-- DataTales Example -->
        <div class="container-fluid">
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Orders</h6>
                </div>
                <div class="card-body">

                    <asp:Label runat="server" ID="lblhiddenFieldForId" Visible="false"></asp:Label>

                    <asp:Panel ID="panelOrdersTable" runat="server">
                        <div class="col-md-4 fa-pull-left">
                            <asp:Button runat="server" ID="btnListCustomer" CssClass="btn btn-primary btn-sm" Text="List Customer" OnClick="btnListCustomer_Click" />
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
                            <asp:GridView runat="server" ID="gridViewOrders" class="table table-striped text-justify" AllowPaging="True" PageSize="10" AllowSorting="True" GridLines="None" OnRowCommand="gridViewOrders_RowCommand" OnRowDataBound="gridViewOrders_RowDataBound" AutoGenerateColumns="False" OnPageIndexChanging="gridViewOrders_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Invoice Number" SortExpression="InvoiceNumber" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceNumber" runat="server" Text='<%# Bind("InvoiceNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer Name" SortExpression="CustomerName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustomerName" runat="server" Text='<%# Bind("CustomerName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Payment Amount" SortExpression="TotalPaymentAmount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalPaymentAmount" runat="server" Text='<%# Bind("TotalPaymentAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" SortExpression="OrderStatus">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnStatus" CssClass="badge badge-warning" runat="server"
                                                CausesValidation="False"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="PaidUnpaid"
                                                Text='<%# Bind("Status") %>' OnClientClick="if ( ! Update()) return false;"
                                                meta:resourcekey="btnUpdateResource1">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Date" SortExpression="InvoiceDateTime">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceDateTime" runat="server" Text='<%# Bind("InvoiceDateTime", "{0:dd MMM yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-success  btn-sm" CommandName="DetailOrder"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Details</asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="btnCancel" CssClass="btn btn-danger  btn-sm" CommandName="CancelOrder"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"
                                                OnClientClick="if ( ! Update()) return false;" meta:resourcekey="btnRemoveResource1">Remove</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ServerDb %>" SelectCommand="SELECT
                                      [InvoiceNumber]
                                      ,[CustomerName]
                                      ,[TotalPaymentAmount]
                                      ,[Status]
                                      ,[InvoiceDateTime]
                                  FROM [tawheedpublicationsbd].[dbo].[tblOrder]"></asp:SqlDataSource>

                            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                                SelectCommand="SELECT * FROM [tblOrder] where Status!='Cancelled' ORDER BY [Id] DESC"></asp:SqlDataSource>
                            Paid list
                            <asp:GridView runat="server" ID="gvPaidList" class="table table-striped text-justify" AllowPaging="True" PageSize="10" AllowSorting="True" GridLines="None" OnRowCommand="gvPaidList_RowCommand" OnRowDataBound="gridViewOrders_RowDataBound" AutoGenerateColumns="False" OnPageIndexChanging="gvPaidList_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Invoice Number" SortExpression="InvoiceNumber" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceNumber" runat="server" Text='<%# Bind("InvoiceNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer Name" SortExpression="CustomerName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustomerName" runat="server" Text='<%# Bind("CustomerName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Payment Amount" SortExpression="TotalPaymentAmount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalPaymentAmount" runat="server" Text='<%# Bind("TotalPaymentAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" SortExpression="OrderStatus">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnStatus" CssClass="badge badge-warning" runat="server"
                                                CausesValidation="False"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="PaidUnpaid"
                                                Text='<%# Bind("Status") %>' OnClientClick="if ( ! Update()) return false;"
                                                meta:resourcekey="btnUpdateResource1">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order Date" SortExpression="InvoiceDateTime">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceDateTime" runat="server" Text='<%# Bind("InvoiceDateTime", "{0:dd MMM yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-success  btn-sm" CommandName="DetailOrder"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Details</asp:LinkButton>
                                           <%-- <asp:LinkButton runat="server" ID="btnCancel" CssClass="btn btn-danger  btn-sm" CommandName="CancelOrder"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"
                                                OnClientClick="if ( ! Update()) return false;" meta:resourcekey="btnRemoveResource1">Remove</asp:LinkButton>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="panelDetail" Visible="false">
                        <h1 class="text-center">Tawheed Publications- Invoice</h1>
                        <br />
                        <br />
                        <div id="printableArea">
                            <div class="row form-group">
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th scope="col">Invoice Number</th>
                                                <th scope="col">
                                                    <asp:Label runat="server" ID="lblInvoiceNumberView"></asp:Label></th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div class="row form-group">
                                <h3>Billing Details</h3>
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th scope="col">Order From,</th>
                                                <th scope="col"></th>
                                                <th scope="col">Delivering To,</th>
                                                <th scope="col"></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th scope="row">Name</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblOrderFromNameView"></asp:Label></td>
                                                <th scope="row">Customer Name</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblCustomerNameView"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <th scope="row">Mobile</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblOrderFromPhoneView"></asp:Label></td>
                                                <th scope="row">Mobile</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblMobileView"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <th scope="row">Address</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblOrderFromAddressView"></asp:Label></td>
                                                <th scope="row">Address</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblAddressView"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <th scope="row">Email</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblOrderFromEmailView"></asp:Label></td>
                                                <th scope="row">Email</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblEmailView"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <th scope="row">Invoice Date</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblOrderFromInvoiceDateView"></asp:Label></td>
                                                <th scope="row">Invoice Date</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblInvoiceDateView"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <th scope="row"></th>
                                                <td></td>
                                                <th scope="row">Due Date</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblDueDateView"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <th scope="row"></th>
                                                <td></td>
                                                <th scope="row">Status</th>
                                                <td>
                                                    <asp:Label runat="server" ID="lblStatusView"></asp:Label></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div class="row form-group">
                                <h3>Purchase Details</h3>
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView runat="server" ID="gridViewBookDetails" class="table table-striped text-justify"
                                            AllowPaging="True" PageSize="100" AllowSorting="True"
                                            GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
                                            <Columns>
                                                <%--  <asp:TemplateField HeaderText="Book Image">
                                            <ItemTemplate>
                                                <asp:Image ID="imgFrontImageDetailView" runat="server" Width="100px" Height="100px"
                                                    ImageUrl='<%# "~/Content/BookFrontImage/" + Eval("BookFrontImage") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Book">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBookTitle" runat="server" Text='<%# Bind("PName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Price (Tk)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Discount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSubTotal" Text='<%# Bind("Discount") %>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ServerDb %>" SelectCommand="SELECT * FROM [tblOrder2] WHERE ([InvoiceNumber] = @InvoiceNumber)">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lblInvoiceNumberView" Name="InvoiceNumber" PropertyName="Text" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div class="row form-group">
                                <h3>Payable Details</h3>
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th scope="col">Delivery Charge</th>
                                                <th scope="col">
                                                    <asp:Label runat="server" ID="lblDeliveryChargeView"></asp:Label>
                                                    Tk</th>
                                            </tr>
                                            <tr>
                                                <th scope="col">Total Payment Amount</th>
                                                <th scope="col">
                                                    <asp:Label runat="server" ID="lblTotalPaymentAmountView"></asp:Label>
                                                    Tk</th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <asp:Button ID="btnGoBack" runat="server" CausesValidation="false" class="btn btn-secondary  btn-sm"
                            Text="Back" OnClick="btnGoBack_Click" />
                        <%--                        <input id="btnPrint" type="button" value="Invoice" class="btn btn-primary btn-sm" onclick="printDiv('printableArea')" />--%>
                        <asp:Button runat="server" ID="btnInvoice" CssClass="btn btn-primary btn-sm" Text="Invoice" OnClick="btnInvoice_Click" Visible="true" />
                    </asp:Panel>

                    <asp:Panel Visible="false" ID="panelCustomerList" runat="server">
                        <div class="col-md-4 fa-pull-right">
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <div class="input-group-text">Search...</div>
                                </div>
                                <asp:TextBox runat="server" type="text" class="form-control"
                                    ID="TextBox1" autocomplete="off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="gridViewCustomerList" runat="server" class="table table-striped text-justify" AllowPaging="True" PageSize="20" AllowSorting="True" GridLines="None" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource4" OnRowCommand="gridViewCustomerList_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" SortExpression="Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="150" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdminName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="150" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="150" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile Number" SortExpression="Phone">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="150" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="true" SortExpression="CreatedDateTime" HeaderText="Created On">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedDateTime" runat="server" Text='<%# Bind("CreateDate", "{0:dd MMM yyyy (hh:mm tt)}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkb1" runat="server" Text="Select All" OnCheckedChanged="sellectAll"
                                                AutoPostBack="true" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkb2" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="true" SortExpression="Action" HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-success  btn-sm" CommandName="DetailCustomer" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false">Details</asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="btnCancel" CssClass="btn btn-danger  btn-sm" CommandName="deleteCustomer"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"
                                                OnClientClick="if ( ! Update()) return false;" meta:resourcekey="btnRemoveResource1">Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server"
                                ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                                SelectCommand="SELECT * FROM [CustomerRegistration] ORDER BY [Id] DESC">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="1" Name="RoleTypeId" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>

                            <asp:Repeater ID="rptPopUp" Visible="false" runat="server">
                                <ItemTemplate>
                                    <div class="col-lg-7 col-md-7 col-sm-12">
                                        <div class="modal_right">
                                            <div class="modal_title mb-10">
                                                <h3>Customer Details</h3>
                                                Name: <b><%# Eval("FirstName") %></b>
                                            </div>
                                            <div class="modal_price mb-10">
                                                Address: <span class="new_price"><%# Eval("Address") %></span><br />
                                                Phone: <span class="new_price"><%# Eval("Phone") %></span><br />
                                                Email: <span class="new_price"><%# Eval("Email") %></span>
                                            </div>
                                            
                                            <div class="variants_selects">
                                                <div class="variants_color">
                                                    <span>Password: <a href="#"><%#Eval("Password")%></a></span><br />
                                                    <span>CreateDate: <a href="#"><%#Eval("CreateDate")%></a></span><br />
                                                    <br />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="col-md-4 fa-pull-right">
                            <asp:Button runat="server" ID="btn_Back" OnClick="btn_Back_Click" Visible="false" CssClass="btn btn-primary btn-sm" Text="Back" />
                            <asp:Button runat="server" ID="btnEmail" OnClick="btnEmail_Click" CssClass="btn btn-primary btn-sm" Text="Send Email" />
                            <asp:Button runat="server" ID="btnSms" OnClick="btnSms_Click" CssClass="btn btn-primary btn-sm" Text="Send Sms" />
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="panelAddEmailOrSms" Visible="false" runat="server">
                        <div class="mx-auto col-md-8">
                            <asp:Label runat="server" ID="lblCount"></asp:Label>
                            <div class="form-group">
                                <div class="input-group flex-nowrap">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text" id="addon-wrapping">Subject: </span>
                                    </div>
                                    <asp:TextBox runat="server" ID="txtSubject" Visible="false"
                                        class="form-control" aria-describedby="addon-wrapping"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group flex-nowrap">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text" id="addon-wrapping2">Message</span>
                                    </div>
                                    <asp:TextBox runat="server" ID="txtMessage" autocomplete="off" TextMode="MultiLine" Rows="10"
                                        class="form-control" aria-describedby="addon-wrapping2"></asp:TextBox>
                                </div>
                            </div>
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-secondary btn-sm"
                                Text="Cancel" OnClick="btnCancel_Click" />
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary btn-sm" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <!-- /.container-fluid -->
</asp:Content>

