<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="Pages_ProductDetails" MaintainScrollPositionOnPostback="true" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--breadcrumbs area start-->
    <div class="breadcrumbs_area">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="breadcrumb_content">
                        <ul>
                            <li><a href="index.html">home</a></li>
                            <li>product details</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--breadcrumbs area end-->
    <asp:Repeater runat="server" ID="rptrsingleimage" OnItemDataBound="rptrsingleimage_ItemDataBound">
        <ItemTemplate>
            <!--product details start-->
            <div class="product_details mt-60 mb-60">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6 col-md-6">
                            <div style="width: 400px;" class="product-details-tab">
                                <a href="#" data-toggle="modal" data-target="#myModal" ><div class="details-trangle"></div></a>
                                <div id="img-1" class="zoomWrapper single-zoom">
                                    <a href="#">
                                        <img id="zoom1" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" data-zoom-image="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt="big-1">
                                    </a>
                                </div>
                                <div class="single-zoom-thumb">
                                    <ul class="s-tab-zoom" id="gallery_01">
                                        <li>
                                            <a href="#" class="elevatezoom-gallery active" data-update="" data-image="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" data-zoom-image="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>">
                                                <img src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt="zo-th-1" />
                                            </a>

                                        </li>
                                        <li>
                                            <a href="#" class="elevatezoom-gallery active" data-update="" data-image="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Back<%#Eval("FontImage") %>" data-zoom-image="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Back<%#Eval("FontImage") %>">
                                                <img src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Back<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt="zo-th-1" />
                                            </a>

                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6">
                            <div class="product_d_right">
                                <div>

                                    <h1><%#Eval("Title") %></h1>
                                    <div class="product_nav">
                                        <ul>
                                            <li class="prev"><a href="#"><i class="fa fa-angle-left"></i></a></li>
                                            <li class="next"><a href="#"><i class="fa fa-angle-right"></i></a></li>
                                        </ul>
                                    </div>
                                    <div class=" product_ratting">
                                        <ul>
                                            <li><a href="#"><i class="fa fa-star"></i></a></li>
                                            <li><a href="#"><i class="fa fa-star"></i></a></li>
                                            <li><a href="#"><i class="fa fa-star"></i></a></li>
                                            <li><a href="#"><i class="fa fa-star"></i></a></li>
                                            <li><a href="#"><i class="fa fa-star"></i></a></li>
                                            <li class="review"><a href="#">(customer review ) </a></li>
                                        </ul>
                                    </div>
                                    <div class="price_box">
                                        <span class="current_price">TK. <%# Eval("Price") %></span>
                                        <span class="old_price"> <%# Eval("OldPrice") %></span>
                                        <br />
                                        Discount:<span class=""> <%# Eval("SpecialPrice") %></span>

                                    </div>
                                    <div class="product_desc">
                                        <p>
                                            <%#Eval("Description")%><br />
                                        </p>
                                    </div>
                                    <div class=" product_d_action">
                                    </div>
                                    <div class="product_meta">
                                        <span>Category: <a href="#">Books</a></span><br />
                                        <span>SubCategory: <a href="#">
                                            <asp:Label ID="lvlSubCategory" runat="server"></asp:Label></a></span><br />
                                        <span>Edition: <a href="#"><%#Eval("EditionNumber")%></a></span><br />
                                        <span>Number of Pages: <a href="#"><%#Eval("NumberOfPages")%></a></span><br />
                                        <span>Status: <a href="#">Active</a></span><br />
                                    </div>
                                    <div class="product_variant quantity">
                                        <label>quantity</label>
                                        <input min="1" max="100" value="1" type="number">
                                    </div>
                                    <div class="add_to_cart1">
                                        <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> ADD TO CART</asp:LinkButton>
                                        <a data-toggle="modal" data-target="#myModal" href="#">Read Some</a>
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
                                    </div>
                                    <!-- modal area start-->
                                    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
                                        <div class="modal-dialog modal-dialog-centered" role="document">
                                            <div class="modal-content">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                                <div class="modal_body" style="height:1000px">
                                                    <div class="container">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <%--<iframe src="../BookImage/<%#Eval("Code") %>/<%#Eval("Title") %><%#Eval("Code") %>.pdf"></iframe>--%>
                                                                <embed src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>.pdf#toolbar=0&navpanes=0&scrollbar=0" width="100%" style="height:945px" type="application/pdf">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <br />
                                <br />
                                <div class="priduct_social">
                                    <ul>
                                        <li><a class="facebook" target="_blank" href="https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Fdevelopers.facebook.com%2Fdocs%2Fplugins%2F&amp;src=sdkpreparse" title="facebook">Like</a></li>
                                        <li><a class="twitter" target="_blank" href="https://twitter.com/intent/tweet?" title="twitter"><i class="fa fa-twitter"></i>tweet</a></li>
                                        <li><a class="pinterest" target="_blank" href="https://www.instagram.com" title="instagram"><i class="fa fa-pinterest"></i>instagram</a></li>
                                        <li><a class="google-plus" target="_blank" href="https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Fdevelopers.facebook.com%2Fdocs%2Fplugins%2F&amp;src=sdkpreparse" title="facebook"><i class="fa fa-facebook"></i>share</a></li>
                                        <li><a class="linkedin" href="#" title="linkedin"><i class="fa fa-linkedin"></i>linked</a></li>
                                    </ul>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--product details end-->

            <!--product info start-->
            <div class="product_d_info mb-60">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="product_d_inner">
                                <div class="product_info_button">
                                    <ul class="nav" role="tablist">
                                        <li>
                                            <a class="active" data-toggle="tab" href="#info" role="tab" aria-controls="info" aria-selected="false">Description</a>
                                        </li>
                                        <li>
                                            <a data-toggle="tab" href="#sheet" role="tab" aria-controls="sheet" aria-selected="false">Specification</a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="tab-content">
                                    <div class="tab-pane fade show active" id="info" role="tabpanel">
                                        <div class="product_info_content">
                                            <p>
                                                <%#Eval("Description")%><br />
                                            </p>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="sheet" role="tabpanel">
                                        <div class="product_d_table">
                                            <div>
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td class="first_child">Name</td>
                                                            <td><%#Eval("Title")%></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="first_child">Author</td>
                                                            <td>
                                                                <asp:Label ID="lvlWriter" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="first_child">ISBN</td>
                                                            <td><%#Eval("ISBN")%></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="first_child">Publish Date</td>
                                                            <td><%#Eval("PublishedDate")%></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <!--product info end-->

    <!--product area start-->
    <section class="product_area related_products">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="section_title">
                        <h2>Related Products On Same Category</h2>
                    </div>
                </div>
            </div>
            <div class="sliderclass">
                <asp:Repeater runat="server" ID="rptrrelatedproduct" OnItemDataBound="rptrrelatedproduct_ItemDataBound">
                    <ItemTemplate>
                        <article class="single_product">
                            <figure>
                                <div class="product_thumb">
                                    <a class="primary_img" href='<%# String.Concat("ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt=""></a>
                                    <a class="secondary_img" href='<%# String.Concat("ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Back<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt=""></a>
                                    <div class="label_product">
                                        <asp:Label ID="lvlDiscount" runat="server"><span class="label_sale"><%#Eval("SpecialPrice") %>%</span></asp:Label>
                                    </div>
                                    <div class="action_links">
                                        <ul>
                                            <li class="wishlist">
                                                <asp:LinkButton runat="server" ID="btnWishList" title="Add to Wishlist"
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
                                <figcaption class="product_content">
                                    <div class="price_box">
                                        Tk <span class="current_price"><%# Eval("Price") %></span>
                                        <span class="old_price"><%# Eval("OldPrice") %></span>
                                    </div>
                                    <h3 class="product_name"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'><%# Eval("Title") %></a></h3>
                                </figcaption>
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
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
    <!--product area end-->

    <!--product area start-->
    <section class="product_area upsell_products">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="section_title">
                        <h2>More Books On This Writer</h2>
                    </div>
                </div>
            </div>
            <div class="sliderclass">
                <asp:Repeater runat="server" ID="rptSameWriter" OnItemDataBound="rptSameWriter_ItemDataBound">
                    <ItemTemplate>
                        <article class="single_product">
                            <figure>
                                <div class="product_thumb">
                                    <a class="primary_img" href='<%# String.Concat("ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt=""></a>
                                    <a class="secondary_img" href='<%# String.Concat("ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Back<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt=""></a>
                                    <div class="label_product">
                                        <asp:Label ID="lvlDiscount" runat="server"><span class="label_sale"><%#Eval("SpecialPrice") %>%</span></asp:Label>
                                    </div>
                                    <div class="action_links">
                                        <ul>
                                            <li class="wishlist">
                                                <asp:LinkButton runat="server" ID="btnWishList" title="Add to Wishlist"
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
                                <figcaption class="product_content">
                                    <div class="price_box">
                                        Tk <span class="current_price"><%# Eval("Price") %></span>
                                        <span class="old_price"><%# Eval("OldPrice") %></span>
                                    </div>
                                    <h3 class="product_name"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'><%# Eval("Title") %></a></h3>
                                </figcaption>
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
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
    <!--product area end-->

    <!--product area start-->
    <section class="product_area related_products">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="section_title">
                        <h2>Related Products On Same Publication</h2>
                    </div>
                </div>
            </div>
            <div class="sliderclass">
                <asp:Repeater runat="server" ID="rptRetaledPublication" OnItemDataBound="rptrrelatedproduct_ItemDataBound">
                    <ItemTemplate>
                        <article class="single_product">
                            <figure>
                                <div class="product_thumb">
                                    <a class="primary_img" href='<%# String.Concat("ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt=""></a>
                                    <a class="secondary_img" href='<%# String.Concat("ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Back<%#Eval("FontImage") %>" onerror="this.src='<%=Page.ResolveUrl("~") %>BookImage/DefaultBook.jpg'" alt=""></a>
                                    <div class="label_product">
                                        <asp:Label ID="lvlDiscount" runat="server"><span class="label_sale"><%#Eval("SpecialPrice") %>%</span></asp:Label>
                                    </div>
                                    <div class="action_links">
                                        <ul>
                                            <li class="wishlist">
                                                <asp:LinkButton runat="server" ID="btnWishList" title="Add to Wishlist"
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
                                <figcaption class="product_content">
                                    <div class="price_box">
                                        Tk <span class="current_price"><%# Eval("Price") %></span>
                                        <span class="old_price"><%# Eval("OldPrice") %></span>
                                    </div>
                                    <h3 class="product_name"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'><%# Eval("Title") %></a></h3>
                                </figcaption>
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
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
    <!--product area end-->

    <!--Review area start-->
    <section class="product_area related_products">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="section_title">
                        <h2>Review</h2>
                    </div>
                </div>
            </div>
            <div class="col-md-9">
                <div class="reviews_wrapper">
                    <%--<h2>review for <%#Eval("Title")%></h2>--%>
                    <div>
                        <asp:Repeater ID="rptrMainComment" OnItemDataBound="rptrMainComment_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <div class="reviews_comment_box">
                                    <div class="comment_text">
                                        <div class="reviews_meta">
                                            <div class="star_rating">
                                                <ul>
                                                    <li><a href="#"><i class="ion-ios-star"></i></a></li>
                                                    <li><a href="#"><i class="ion-ios-star"></i></a></li>
                                                    <li><a href="#"><i class="ion-ios-star"></i></a></li>
                                                    <li><a href="#"><i class="ion-ios-star"></i></a></li>
                                                    <li><a href="#"><i class="ion-ios-star"></i></a></li>  
                                                </ul>
                                            </div>
                                            <p><strong><%#Eval("Name") %> </strong>- <%#Eval("Date") %></p>
                                            <span><%#Eval("Comments") %></span>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="comment_title">
                        <h2>Add a review </h2>
                        <p>Your email address will not be published.  Required fields are marked </p>
                    </div>
                    <div class="product_ratting mb-10">
                        <h3>Your rating</h3>
                        <ul>
                            <li><a href="#"><i class="fa fa-star"></i></a></li>
                            <li><a href="#"><i class="fa fa-star"></i></a></li>
                            <li><a href="#"><i class="fa fa-star"></i></a></li>
                            <li><a href="#"><i class="fa fa-star"></i></a></li>
                            <li><a href="#"><i class="fa fa-star"></i></a></li>
                        </ul>
                    </div>
                    <div class="product_review_form">
                        <div>
                            <div class="row">
                                <div class="col-12">
                                    <label for="review_comment">Your review </label>
                                    <textarea name="txtreplycomment" id="txtreplycomment" runat="server"></textarea>
                                </div>
                                <div class="col-lg-6 col-md-6">
                                    <label for="author">Name</label>
                                    <asp:TextBox ID="txtreplyname" Width="100%" ValidationGroup="mailVal" runat="server" CssClass="form-control" placeholder="First Name" />
                                </div>
                                <div class="col-lg-6 col-md-6">
                                    <label for="email">Email </label>
                                    <asp:TextBox ID="txtreplyemail" Width="100%" ValidationGroup="mailVal" runat="server" CssClass="form-control" placeholder="Email" />
                                </div>
                            </div>
                            <%--<asp:Button runat="server" ID="btncomment" CausesValidation="false" class="radius" BackColor="#A6A5A5" OnClick="btncomment_Click" Text="Submit Review" />--%>
                            <div class="add_to_cart1">
                                <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btncomment_Click">Submit Review</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--Review area end-->


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
</asp:Content>

