<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" CodeFile="Package.aspx.cs" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" Inherits="Pages_Package" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type='text/javascript'>
        function openModal() {
            $('#modal_box').modal('show');
        }
    </script>

    <script type='text/javascript'>
        function openModal2() {
            $('#modal_box2').modal('show');
        }
    </script>

    <script>
        function radioCategories(e) {
            if (!e) e = window.event;
            var sender = e.target || e.srcElement;

            if (sender.nodeName != 'INPUT') return;
            var checker = sender;
            var chkBox = document.getElementById('<%= chkBoxCategories.ClientID %>');
            var chks = chkBox.getElementsByTagName('INPUT');
            for (i = 0; i < chks.length; i++) {
                if (chks[i] != checker)
                    chks[i].checked = false;
            }
        }

        function radioSubCategories(e) {
            if (!e) e = window.event;
            var sender = e.target || e.srcElement;

            if (sender.nodeName != 'INPUT') return;
            var checker = sender;
            var chkBox = document.getElementById('<%= chkBoxSubCategories.ClientID %>');
            var chks = chkBox.getElementsByTagName('INPUT');
            for (i = 0; i < chks.length; i++) {
                if (chks[i] != checker)
                    chks[i].checked = false;
            }
        }
        function radioauthors(e) {
            if (!e) e = window.event;
            var sender = e.target || e.srcElement;

            if (sender.nodeName != 'INPUT') return;
            var checker = sender;
            var chkBox = document.getElementById('<%= chkBoxAuthors.ClientID %>');
            var chks = chkBox.getElementsByTagName('INPUT');
            for (i = 0; i < chks.length; i++) {
                if (chks[i] != checker)
                    chks[i].checked = false;
            }
        }

        function radioPublication(e) {
            if (!e) e = window.event;
            var sender = e.target || e.srcElement;

            if (sender.nodeName != 'INPUT') return;
            var checker = sender;
            var chkBox = document.getElementById('<%= chkBoxPublication.ClientID %>');
            var chks = chkBox.getElementsByTagName('INPUT');
            for (i = 0; i < chks.length; i++) {
                if (chks[i] != checker)
                    chks[i].checked = false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumbs_area">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="breadcrumb_content">
                        <ul>
                            <li><a href="#">home</a></li>
                            <li>Publication </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--breadcrumbs area end-->

    <!--shop  area start-->
    <div class="shop_area shop_reverse mt-60 mb-60" style="margin-top: 5px;">
        <div class="container">
            <asp:Panel ID="Panel1" runat="server">
                <div class="row">

                    <div class="col-lg-3 col-md-12">
                        <!--sidebar widget start-->
                        <aside class="sidebar_widget">
                            <div class="widget_inner">
                                <div class="widget_list widget_categories">
                                    <h2>
                                        <asp:Label runat="server">categories</asp:Label></h2>
                                    <ul>
                                        <li>
                                            <asp:CheckBoxList runat="server" ID="chkBoxCategories" AutoPostBack="true" OnSelectedIndexChanged="chkBoxCategories_SelectedIndexChanged">
                                                <asp:ListItem></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </li>
                                    </ul>
                                </div>
                                <div class="widget_list widget_categories">
                                    <h2>
                                        <asp:Label runat="server">Sub-Categories</asp:Label></h2>
                                    <ul style="overflow-y: scroll; max-height: 300px;">
                                        <li>
                                            <asp:CheckBoxList runat="server" ID="chkBoxSubCategories" AutoPostBack="true" OnSelectedIndexChanged="chkBoxSubCategories_SelectedIndexChanged">
                                                <asp:ListItem></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </li>
                                    </ul>
                                </div>
                                <div class="widget_list widget_categories">
                                    <h2>
                                        <asp:Label runat="server">Authors</asp:Label></h2>
                                    <ul style="overflow-y: scroll; max-height: 300px;">
                                        <li>
                                            <asp:CheckBoxList runat="server" ID="chkBoxAuthors" AutoPostBack="true" OnSelectedIndexChanged="chkBoxAuthors_SelectedIndexChanged">
                                                <asp:ListItem></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </li>
                                    </ul>
                                </div>
                                <div class="widget_list widget_categories">
                                    <h2>
                                        <asp:Label runat="server">Publication</asp:Label></h2>
                                    <ul style="overflow-y: scroll; max-height: 300px;">
                                        <li>
                                            <asp:CheckBoxList runat="server" ID="chkBoxPublication" AutoPostBack="true" OnSelectedIndexChanged="chkBoxPublication_SelectedIndexChanged">
                                                <asp:ListItem></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </li>
                                    </ul>
                                </div>
                                <div class="widget_list widget_filter">
                                    <h2>Filter by price</h2>
                                    <div>
                                        <%--  <div id="slider-range"></div>--%>
                                        <asp:Button runat="server" Text="Filter" type="submit" ID="btnFilter" OnClick="btnFilter_Click" />
                                        <asp:TextBox runat="server" type="text" name="text" min="0" Text="0" ID="txtMin"
                                            TextMode="Number" Style="width: 50px" placeholder="0"></asp:TextBox>
                                        to
                                    <asp:TextBox runat="server" type="text" name="text" min="0" Text="50" ID="txtMax"
                                        TextMode="Number" Style="width: 50px" placeholder="50"></asp:TextBox>
                                    </div>
                                    <div class="row form-group">
                                        <asp:RangeValidator ID="rvdtxtMin"
                                            ErrorMessage="Please enter value between 0-9999."
                                            ForeColor="Red" ControlToValidate="txtMin"
                                            MinimumValue="0" MaximumValue="9999" runat="server" Type="Integer">
                                        </asp:RangeValidator>
                                    </div>
                                    <div class="row form-group">
                                        <asp:RangeValidator ID="rvdtxtMax"
                                            ErrorMessage="Please enter value between 0-9999."
                                            ForeColor="Red" ControlToValidate="txtMax"
                                            MinimumValue="0" MaximumValue="9999" runat="server" Type="Integer">
                                        </asp:RangeValidator>
                                    </div>
                                </div>
                                <div class="widget_list widget_categories">
                                    <h2>
                                        <asp:Label runat="server">Ratings</asp:Label></h2>
                                    <ul>
                                        <li><a href="#"><i class="ion-android-star-outline"></i></a></li>
                                        <li><a href="#"><i class="ion-android-star-outline"></i><i class="ion-android-star-outline"></i></a></li>
                                        <li><a href="#"><i class="ion-android-star-outline"></i><i class="ion-android-star-outline"></i><i class="ion-android-star-outline"></i></a></li>
                                        <li><a href="#"><i class="ion-android-star-outline"></i><i class="ion-android-star-outline"></i><i class="ion-android-star-outline"></i><i class="ion-android-star-outline"></i></a></li>
                                        <li><a href="#"><i class="ion-android-star-outline"></i><i class="ion-android-star-outline"></i><i class="ion-android-star-outline"></i><i class="ion-android-star-outline"></i><i class="ion-android-star-outline"></i></a></li>
                                    </ul>
                                </div>
                            </div>
                        </aside>
                        <!--sidebar widget end-->
                    </div>
                    <div class="col-lg-9 col-md-12">
                        <!--shop wrapper start-->
                        <!--shop toolbar start-->

                        <div class="shop_toolbar_wrapper">
                            <div class="shop_toolbar_btn">
                                <button data-role="grid_3" type="button" class="active btn-grid-3" data-toggle="tooltip" title="3"></button>

                                <button data-role="grid_4" type="button" class=" btn-grid-4" data-toggle="tooltip" title="4"></button>

                                <button data-role="grid_list" type="button" class="btn-list" data-toggle="tooltip" title="List"></button>
                            </div>
                            <div class="">
                                <div class="">
                                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddlSort" AutoPostBack="true" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Sort by most Sale</asp:ListItem>
                                        <asp:ListItem Value="2">Sort by newness</asp:ListItem>
                                        <asp:ListItem Value="3">Sort by up-Coming</asp:ListItem>
                                        <asp:ListItem Value="4">Sort by popularity</asp:ListItem>
                                        <asp:ListItem Value="5">Sort by price: low to high</asp:ListItem>
                                        <asp:ListItem Value="6">Sort by price: high to low</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%--<div class="page_amount">
                            <p>Showing 1–9 of 21 results</p>
                        </div>--%>
                        </div>

                        <asp:Label runat="server" ID="lblMessage" Visible="false" ForeColor="Red" Font-Size="XX-Large" Text="Sorry! we dont have any book related to your search please try another one"></asp:Label>
                        <!--Accordion area end-->

                        <!--shop toolbar end-->
                        <div class="row shop_wrapper">
                            <asp:Repeater runat="server" ID="repeaterBooks" OnItemDataBound="repeaterBooks_ItemDataBound1">
                                <ItemTemplate>
                                    <div class="col-lg-4 col-md-4 col-12 ">
                                        <article class="single_product">
                                            <figure>
                                                <div class="product_thumb">
                                                    <a class="primary_img" href='<%# String.Concat("ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                                        <img style="width: 100%; height: 305px;" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt=""></a>
                                                    <a class="secondary_img" href='<%# String.Concat("ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                                        <img style="width: 100%; height: 305px;" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt=""></a>
                                                    <div class="label_product">
                                                        <asp:Label ID="lvlDiscount" runat="server"><span class="label_sale"><%#Eval("SpecialPrice") %>%</span></asp:Label>
                                                    </div>
                                                    <div class="action_links">
                                                        <ul>
                                                            <li class="wishlist">
                                                                <asp:LinkButton runat="server" ID="LinkButton2" title="Add to Wishlist"
                                                                    CommandName="AddWishlist" CommandArgument='<%#Eval("Id") %>' OnClick="btnWishList_Click"><i class="fa fa-heart-o" aria-hidden="true"></i></asp:LinkButton></li>
                                                            <li class="compare"><a href="#" title="compare"><span class="ion-levels"></span></a></li>
                                                            <li class="quick_button">
                                                                <asp:LinkButton runat="server" ID="btnQuickView" title="quick view"
                                                                    CommandName="QuickView" CommandArgument='<%#Eval("Id") %>' OnClick="btnQuickView_Click"><span class="ion-ios-search-strong"></span></asp:LinkButton></li>
                                                        </ul>
                                                    </div>
                                                    <div class="add_to_cart">
                                                        <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> ADD TO CART</asp:LinkButton>
                                                    </div>
                                                </div>
                                                <div class="product_content grid_content">
                                                    <div class="price_box">
                                                        <%-- <span class="old_price">$86.00</span>--%>
                                                    Tk <span class="current_price"><%# Eval("Price") %></span>
                                                        <span class="old_price"><%# Eval("OldPrice") %></span>
                                                    </div>
                                                    <div class="product_ratings">
                                                        <ul>
                                                            <li><a href="#"><i class="ion-android-star-outline"></i></a></li>
                                                            <li><a href="#"><i class="ion-android-star-outline"></i></a></li>
                                                            <li><a href="#"><i class="ion-android-star-outline"></i></a></li>
                                                            <li><a href="#"><i class="ion-android-star-outline"></i></a></li>
                                                            <li><a href="#"><i class="ion-android-star-outline"></i></a></li>
                                                        </ul>
                                                    </div>
                                                    <h3 class="product_name grid_name"><a href='<%# String.Concat("ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'><%# Eval("Title") %></a></h3>
                                                </div>
                                                <div class="product_content list_content">
                                                    <div class="left_caption">
                                                        <div class="price_box">
                                                            Price: <span class="current_price"><%# Eval("Price") %></span><br />
                                                            Discount: <span class="current_price"><%# Eval("SpecialPrice") %></span>
                                                        </div>
                                                        <h3 class="product_name"><a href='<%# String.Concat("ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'><%# Eval("Title") %></a></h3>
                                                        <div class="product_ratings">
                                                            <ul>
                                                                <li><a href="#"><i class="ion-android-star-outline"></i></a></li>
                                                                <li><a href="#"><i class="ion-android-star-outline"></i></a></li>
                                                                <li><a href="#"><i class="ion-android-star-outline"></i></a></li>
                                                                <li><a href="#"><i class="ion-android-star-outline"></i></a></li>
                                                                <li><a href="#"><i class="ion-android-star-outline"></i></a></li>
                                                            </ul>
                                                        </div>
                                                        <div class="product_desc">
                                                            <p><%# Eval("Description") %></p>
                                                        </div>
                                                    </div>
                                                    <div class="right_caption" style="width: 500px">
                                                        <div class="add_to_cart">
                                                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> ADD TO CART</asp:LinkButton>
                                                        </div>
                                                        <div class="action_links">
                                                            <ul>
                                                                <li class="wishlist">
                                                                    <asp:LinkButton runat="server" ID="btnWishList" title="Add to Wishlist"
                                                                        CommandName="AddWishlist" CommandArgument='<%#Eval("Id") %>' OnClick="btnWishList_Click"><i class="fa fa-heart-o" aria-hidden="true"></i></asp:LinkButton></li>
                                                                <li class="compare"><a href="#" title="compare"><span class="ion-levels"></span>Compare</a></li>
                                                                <li class="quick_button">
                                                                    <asp:LinkButton runat="server" ID="LinkButton1" title="quick view"
                                                                        CommandName="QuickView" CommandArgument='<%#Eval("Id") %>' OnClick="btnQuickView_Click"><span class="ion-ios-search-strong"></span></asp:LinkButton></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
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
                                            </figure>
                                        </article>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>

                        </div>

                        <div class="shop_toolbar t_bottom">
                            <div class="pagination">
                                <ul>
                                    <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
                                        <ItemTemplate>
                                            <li>
                                                <asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server"> <%# Container.DataItem %> </asp:LinkButton></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <li><a href="#">>></a></li>
                                </ul>
                            </div>
                        </div>
                        <!--shop toolbar end-->
                    </div>

                </div>
            </asp:Panel>
        </div>
    </div>
    <!--shop  area end-->

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
                            <asp:Repeater ID="rptPopUp" runat="server">
                                <ItemTemplate>

                                    <div class="col-lg-5 col-md-5 col-sm-12">
                                        <div class="modal_tab">
                                            <div class="tab-content product-details-large">
                                                <div class="tab-pane fade show active" id="tab1" role="tabpanel">
                                                    <div class="modal_tab_img">
                                                        <a href="#">
                                                            <img style="height: 400px;" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt=""></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-7 col-md-7 col-sm-12">
                                        <div class="modal_right">
                                            <div class="modal_title mb-10">
                                                <h2><%# Eval("Title") %></h2>
                                            </div>
                                            <div class="modal_price mb-10">
                                                Price: <span class="new_price"><%# Eval("Price") %></span><br />
                                                Discount: <span class="new_price"><%# Eval("SpecialPrice") %></span>
                                                <%--<span class="old_price">$78.99</span>--%>
                                            </div>
                                            <div class="modal_description mb-15">
                                                <p><%# Eval("Description") %></p>
                                            </div>
                                            <div class="variants_selects">
                                                <div class="variants_size">
                                                    <%--<h2>size</h2>
                                                        <select class="select_option">
                                                            <option value="1">s</option>
                                                            <option value="1">m</option>
                                                            <option value="1">l</option>
                                                            <option value="1">xl</option>
                                                            <option value="1">xxl</option>
                                                        </select>--%>
                                                </div>
                                                <div class="variants_color">
                                                    <span>Edition: <a href="#"><%#Eval("EditionNumber")%></a></span><br />
                                                    <span>Number of Pages: <a href="#"><%#Eval("NumberOfPages")%></a></span><br />
                                                    <span>Status: <a href="#">Active</a></span><br />
                                                    <%--<h2>color</h2>
                                                        <select class="select_option">
                                                            <option value="1">purple</option>
                                                            <option value="1">violet</option>
                                                            <option value="1">black</option>
                                                            <option value="1">pink</option>
                                                            <option value="1">orange</option>
                                                        </select>--%>
                                                </div>
                                                <div class="modal_add_to_cart">
                                                    <div>
                                                        <input min="0" max="100" step="2" value="0" type="number">
                                                        <button type="submit">add to cart</button>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal_social">
                                                <h2>Share this product</h2>
                                                <ul>
                                                    <li class="facebook"><a href="#"><i class="fa fa-facebook"></i></a></li>
                                                    <li class="twitter"><a href="#"><i class="fa fa-twitter"></i></a></li>
                                                    <li class="pinterest"><a href="#"><i class="fa fa-pinterest"></i></a></li>
                                                    <li class="google-plus"><a href="#"><i class="fa fa-google-plus"></i></a></li>
                                                    <li class="linkedin"><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- modal area end-->

    <!-- modal2 area start-->
    <div class="modal fade" id="modal_box2" tabindex="-2" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
                <div class="modal_body" style="height: 700px;">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12">
                                <div class="">
                                    <asp:Repeater runat="server" ID="repeaterBookView">
                                        <ItemTemplate>
                                            <iframe src='<%# "~/BookImage/"+ Eval("Code") +"/"+ Eval("Title")+Eval("Code")+".pdf" %>' width="100%" height="600"></iframe>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

