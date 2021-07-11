<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" EnableEventValidation="false" Inherits="Pages_MyAccount_MyAccount" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function anchor_test() {
            Session.RemoveAll();
            window.location = "<%=Page.ResolveUrl("~") %>Default.aspx";
            //window.alert("This is an anchor test.");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- my account start  -->
    <section class="main_content_area">
        <div class="container">
            <div class="account_dashboard">
                <div class="row">
                    <div class="col-sm-12 col-md-3 col-lg-3">
                        <!-- Nav tabs -->
                        <div class="dashboard_tab_button">
                            <ul role="tablist" class="nav flex-column dashboard-list">
                                <li><a href="#dashboard" data-toggle="tab" class="nav-link active">Dashboard</a></li>
                                <li><a href="#orders" data-toggle="tab" class="nav-link">Orders</a></li>
                                <li><a href="#downloads" data-toggle="tab" class="nav-link">Wishlist</a></li>
                                <li><a href="#address" data-toggle="tab" class="nav-link">Profile Details</a></li>
                                <li><a href="#blog-details" data-toggle="tab" class="nav-link">Blogs</a></li>
                                <li><a href="#Creat_blog" data-toggle="tab" class="nav-link">Write Blog</a></li>
                                <li><a href="#" onserverclick="btnlogin_Click" runat="server" class="nav-link">LogOut</a></li>
                                <li></li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-9 col-lg-9">
                        <!-- Tab panes -->
                        <div class="tab-content dashboard_content">
                            <div class="tab-pane fade show active" id="dashboard">
                                <h3>Dashboard </h3>
                                <p>
                                    Hello <a href="#">
                                        <asp:Label ID="lblSurname" runat="server"></asp:Label></a>, (If you are not <a href="#">
                                            <asp:Label ID="lblSurname1" runat="server"></asp:Label></a> then please logout)<br />
                                    <br />
                                    From your account dashboard. you can easily check &amp; view your <a href="#">recent orders</a>, manage your <a href="#">shipping and billing addresses</a> and <a href="#">Edit your password and account details.</a>
                                </p>
                                Email: <b>
                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                </b>

                                <asp:Label ID="lblPassword" Visible="false" runat="server"></asp:Label>
                            </div>
                            <div class="tab-pane fade" id="Creat_blog">
                                <h3>Create A Blog</h3>
                                <div class="login">
                                    <div class="login_form_container">
                                        <div class="account_login_form">
                                            <div>
                                                <p>Already have an account? <a href="#">Log in instead!</a></p>
                                                <br />
                                                <div style="border: 1px solid #808080; margin-bottom: 25px; padding: 20px; border-radius: 10px;" class="mx-auto col-md-11">
                                                    <div class="form-group">
                                                        <div class="input-group flex-nowrap">
                                                            <div class="input-group-prepend">
                                                                <span style="font-size: 15px; font-weight: 500;" class="input-group-text">Blog Title</span>
                                                            </div>
                                                            <asp:TextBox runat="server" placeholder="In 20 Word" ID="txtBlogTitle" autocomplete="off"
                                                                class="form-control"></asp:TextBox>
                                                        </div>
                                                        <asp:RequiredFieldValidator runat="server" ID="reqtxtBookTitle"
                                                            ControlToValidate="txtBlogTitle" Text="required" Display="Dynamic" ForeColor="Red" />
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span style="font-size: 15px; font-weight: 500;" class="input-group-text">Description</span>
                                                            </div>
                                                            <asp:TextBox runat="server" ID="txtDescription" autocomplete="off"
                                                                class="form-control" TextMode="MultiLine" Rows="15"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="input-group">
                                                            <div class="input-group-prepend">
                                                                <span style="font-size: 15px; font-weight: 500;" class="input-group-text">Image</span>
                                                            </div>
                                                            <asp:FileUpload ID="fileFrontImage" class="form-control" runat="server" onchange="FrontImagePreview(this);" />
                                                            <br />

                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                Related image                                    
                                                            </div>
                                                        </div>
                                                        <%--  <asp:RequiredFieldValidator runat="server" ID="reqfileFrontImage"
                                ControlToValidate="fileFrontImage" Text="required" Display="Dynamic" ForeColor="Red" />--%>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <span class="custom_checkbox">
                                                    <label>
                                                        <input type="checkbox" value="1" name="newsletter" />
                                                        Sign up for our newsletter<br />
                                                        <em>You may unsubscribe at any moment. For that purpose, please find our contact info in the legal notice.</em></label>
                                                </span>
                                                <div class="save_button primary_btn default_button">
                                                    <asp:Button CssClass="buttonstyle" OnClick="btnSave_Click" ID="btnSave" runat="server" Text="Save" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="orders">
                                <h3>Orders</h3>
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th>Order</th>
                                                <th>VoucherNo</th>
                                                <th>Status</th>
                                                <th>Total Amount</th>
                                                <th>Date</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptOrders" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>1</td>
                                                        <td><%# Eval("InvoiceNumber") %></td>
                                                        <td><span class="success"><%# Eval("Status") %></span></td>
                                                        <td><%# Eval("TotalPaymentAmount") %></td>
                                                        <td><%# Eval("InvoiceDateTime") %></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="downloads">
                                <h3>Downloads</h3>
                                <div class="table-responsive">
                                    <table class="table">
                                        <thead>
                                            <tr>
                                                <th>Product Name</th>
                                                <th>Price</th>

                                                <th>Image</th>
                                                <th></th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptWishlist" OnItemCommand="rptWishlist_ItemCommand" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Eval("Title") %></td>
                                                        <td><%# Eval("Price") %></td>
                                                        <td><span>
                                                            <img style="width: 100px; height: 100px;" src="<%=Page.ResolveUrl("~") %>BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" alt="<%# Eval("Title") %>" /></span></td>
                                                        <td>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="buttonstyle" CommandName="delete" CommandArgument='<%#Eval("Id") %>' CausesValidation="false" >Delete</asp:LinkButton>
                                                            </td>
                                                        
                                                        <td>
                                                            <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               ADD TO CART</asp:LinkButton></td>
                                                    </tr>
                                                    <!-- all Hidden file -->
                                                    <asp:HiddenField ID="hfCatID" Value='<%# Eval("Id") %>' runat="server" />
                                                    <asp:HiddenField ID="hfPId" Value='<%# Eval("Id") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("Title") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("Price") %>' runat="server" />
                                                    <asp:HiddenField ID="hfproductid" Value='<%# Eval("Code") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("FontImage") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("FontImage") %>' runat="server" />
                                                    <asp:HiddenField ID="hfvatamount" Value='<%# Eval("SpecialPrice") %>' runat="server" />
                                                    <!-- all Hidden file End -->
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="tab-pane" id="address">
                                <p>The following addresses will be used on the checkout page by default.</p>
                                <h4 class="billing-address">Billing address</h4>
                                <%--<a href="#" class="view">Edit</a>--%>

                                <p>
                                    <strong>
                                        <asp:Label ID="lblName" runat="server"></asp:Label></strong>
                                </p>
                                <address>
                                    Country: 
                                    <asp:Label ID="lblCountry" runat="server"></asp:Label><br />
                                    Address: 
                                    <asp:Label ID="lblAddress" runat="server"></asp:Label><br />
                                    Email:    
                                    <asp:Label ID="lblEmail1" runat="server"></asp:Label><br />
                                    Phone:    
                                    <asp:Label ID="lblPhone" runat="server"></asp:Label><br />
                                    Join Date:
                                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                                    <br />
                                </address>
                                <ul>
                                    <li class="quick_button"><a href="#" data-toggle="modal" data-target="#modal_box" title="quick view">Edit</a></li>
                                </ul>

                                <!-- modal area start-->
                                <div class="modal fade" id="modal_box" tabindex="-1" role="dialog" aria-hidden="true">
                                    <div class="modal-dialog modal-dialog-centered" role="document">
                                        <div class="modal-content">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                            <div class="modal_body">
                                                <div class="container">
                                                    <div class="row">
                                                        <div class="col-lg-2 col-md-2 col-sm-2">
                                                            <div class="modal_tab">
                                                                <div class="tab-content product-details-large">
                                                                </div>
                                                                <div class="modal_tab_button">
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-8 col-md-8 col-sm-12">
                                                            <div class="modal_right">
                                                                <div class="variants_selects">
                                                                    <div>
                                                                        <asp:Panel runat="server" ID="panelDetail">
                                                                            Name: 
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" /><br />
                                                                            Country: 
                                    <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" /><br />
                                                                            Address: 
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" /><br />
                                                                            Email:    
                                    <asp:TextBox ID="txtEmail" Enabled="false" runat="server" CssClass="form-control" /><br />
                                                                            Phone:    
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" /><br />
                                                                            Password:    
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" /><br />
                                                                            Join Date:
                                    <asp:TextBox ID="txtJoinDate" Enabled="false" runat="server" CssClass="form-control" />
                                                                            <br />
                                                                        </asp:Panel>
                                                                    </div>
                                                                    <div class="modal_add_to_cart">
                                                                        <div>
                                                                            <asp:Button ID="btnlogin" runat="server" Text="Save" OnClick="btnEdit_Click" UseSubmitBehavior="false" CausesValidation="False"></asp:Button>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2 col-md-2 col-sm-2">
                                                            <div class="modal_tab">
                                                                <div class="tab-content product-details-large">
                                                                </div>
                                                                <div class="modal_tab_button">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- modal area end-->
                            </div>

                            <div class="tab-pane fade" id="blog-details">
                                <h3>Active Blog details </h3>
                                <div class="login">
                                    <div class="login_form_container">
                                        <div class="table-responsive">
                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th>Order</th>
                                                        <th>Title</th>
                                                        <th>Status</th>
                                                        <th>Date</th>
                                                        <th>Actions</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="rptBlogDetails" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>1</td>
                                                                <td><%# Eval("Title") %></td>
                                                                <td><span class="success"><%# Eval("Status") %></span></td>
                                                                <td><%# Eval("CreatedDate") %></td>
                                                                <td><a href="<%= Page.ResolveUrl("~") %>Pages/blog-details.aspx?Id=<%# Eval("Id") %>" target="_blank" class="view">view</a></td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- my account end   -->

</asp:Content>

