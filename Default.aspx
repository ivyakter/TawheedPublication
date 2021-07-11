<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="_Default" %>

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

    <!--slider area start-->
    <section class="slider_section mb-70">
        <div class="slider_area owl-carousel">
            <div class="single_slider d-flex align-items-center" data-bgimg="SliderImage/1.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="slider_content">
                                <asp:Repeater ID="rptShopNow1" runat="server">
                                    <ItemTemplate>
                                        <a class="button" href='<%= Page.ResolveUrl("~")%>Pages/Books.aspx?SubCat=<%#Eval("Subcategory") %>'>shop now</a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="single_slider d-flex align-items-center" data-bgimg="SliderImage/2.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="slider_content">
                                <asp:Repeater ID="rptShopNow2" runat="server">
                                    <ItemTemplate>
                                        <a class="button" href='<%= Page.ResolveUrl("~")%>Pages/Books.aspx?SubCat=<%#Eval("Subcategory") %>'>shop now</a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="single_slider d-flex align-items-center" data-bgimg="SliderImage/3.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="slider_content">
                                <asp:Repeater ID="rptShopNow3" runat="server">
                                    <ItemTemplate>
                                        <a class="button" href='<%= Page.ResolveUrl("~")%>Pages/Books.aspx?SubCat=<%#Eval("Subcategory") %>'>shop now</a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--slider area end-->

    <!--Upcoming product area start-->
    <section class="product_area mb-46">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="section_title">
                        <h2>Upcoming Books</h2>
                    </div>
                </div>
            </div>

            <div class="sliderclass">

                <asp:Repeater ID="rptUpcomingProduct" runat="server" OnItemDataBound="rptBooks_ItemDataBound">
                    <ItemTemplate>
                        <article class="single_product">
                            <figure>
                                <div class="product_thumb">
                                    <a class="primary_img" href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='BookImage/DefaultBook.jpg'" alt=""></a>
                                    <a class="secondary_img" href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Back<%#Eval("FontImage") %>" onerror="this.src='BookImage/DefaultBook.jpg'" alt=""></a>
                                    <div class="label_product">
                                        <asp:Label ID="lvlDiscount" runat="server"><span class="label_sale"><%#Eval("SpecialPrice") %>%</span></asp:Label>
                                    </div>
                                    <div class="action_links">
                                        <ul>
                                            <li class="wishlist">
                                                <asp:LinkButton runat="server" ID="btnWishList" title="Add to Wishlist"
                                                    CommandName="AddWishlist" CommandArgument='<%#Eval("Id") %>' OnClick="btnWishList_Click"><i class="fa fa-heart-o" aria-hidden="true"></i></asp:LinkButton></li>
                                            <%--<li class="wishlist"><a href="wishlist.html" title="Add to Wishlist"><i class="fa fa-heart-o" aria-hidden="true"></i></a></li>--%>
                                            <li class="compare"><a href="#" title="compare"><span class="ion-levels"></span></a></li>
                                            <li class="quick_button">
                                                <asp:LinkButton runat="server" ID="btnQuickView" title="quick view"
                                                    CommandName="QuickView" CommandArgument='<%#Eval("Id") %>' OnClick="btnQuickView_Click"><span class="ion-ios-search-strong"></span></asp:LinkButton></li>
                                        </ul>
                                    </div>
                                    <div class="add_to_cart">
                                        <asp:LinkButton ID="btnaddtocart" runat="server" CausesValidation="false" OnClick="btnaddtocart_Click1"><i class="fa fa-shopping-basket"></i> ADD TO CART</asp:LinkButton>
                                    </div>
                                </div>
                                <figcaption class="product_content">
                                    <div class="price_box">
                                        Tk <span class="current_price"><%# Eval("Price") %></span>
                                        <span class="old_price"><%# Eval("OldPrice") %></span>
                                    </div>
                                    <h3 class="product_name"><a href="<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>"><%# Eval("Title") %></a></h3>
                                </figcaption>
                                <!-- all Hidden file -->
                                <asp:HiddenField ID="hfCatID" Value='<%# Eval("Id") %>' runat="server" />
                                <asp:HiddenField ID="hfPId" Value='<%# Eval("Id") %>' runat="server" />
                                <%-- <asp:Label runat="server"  ID="Label2" Text='<%# Eval("Title") %>'></asp:Label>--%>
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
    <!--Upcoming product area end-->

    <!--New product area start-->
    <section class="product_area mb-46">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="section_title">
                        <h2>New Books</h2>
                    </div>
                </div>
            </div>

            <div class="sliderclass">

                <asp:Repeater ID="rptNewProduct" runat="server" OnItemDataBound="rptBooks_ItemDataBound">
                    <ItemTemplate>
                        <article class="single_product">
                            <figure>
                                <div class="product_thumb">
                                    <a class="primary_img" href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='BookImage/DefaultBook.jpg'" alt=""></a>
                                    <a class="secondary_img" href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Back<%#Eval("FontImage") %>" onerror="this.src='BookImage/DefaultBook.jpg'" alt=""></a>
                                    <div class="label_product">
                                        <asp:Label ID="lvlDiscount" runat="server"><span class="label_sale"><%#Eval("SpecialPrice") %>%</span></asp:Label>
                                    </div>
                                    <div class="action_links">
                                        <ul>
                                            <li class="wishlist">
                                                <asp:LinkButton runat="server" ID="btnWishList" title="Add to Wishlist"
                                                    CommandName="AddWishlist" CommandArgument='<%#Eval("Id") %>' OnClick="btnWishList_Click"><i class="fa fa-heart-o" aria-hidden="true"></i></asp:LinkButton></li>
                                            <%--<li class="wishlist"><a href="wishlist.html" title="Add to Wishlist"><i class="fa fa-heart-o" aria-hidden="true"></i></a></li>--%>
                                            <li class="compare"><a href="#" title="compare"><span class="ion-levels"></span></a></li>
                                            <li class="quick_button">
                                                <asp:LinkButton runat="server" ID="btnQuickView" title="quick view"
                                                    CommandName="QuickView" CommandArgument='<%#Eval("Id") %>' OnClick="btnQuickView_Click"><span class="ion-ios-search-strong"></span></asp:LinkButton></li>
                                        </ul>
                                    </div>
                                    <div class="add_to_cart">
                                        <asp:LinkButton ID="btnaddtocart" runat="server" CausesValidation="false" OnClick="btnaddtocart_Click1"><i class="fa fa-shopping-basket"></i> ADD TO CART</asp:LinkButton>
                                    </div>
                                </div>
                                <figcaption class="product_content">
                                    <div class="price_box">
                                        Tk <span class="current_price"><%# Eval("Price") %></span>
                                        <span class="old_price"><%# Eval("OldPrice") %></span>
                                    </div>
                                    <h3 class="product_name"><a href="<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>"><%# Eval("Title") %></a></h3>
                                </figcaption>
                                <!-- all Hidden file -->
                                <asp:HiddenField ID="hfCatID" Value='<%# Eval("Id") %>' runat="server" />
                                <asp:HiddenField ID="hfPId" Value='<%# Eval("Id") %>' runat="server" />
                                <%-- <asp:Label runat="server"  ID="Label2" Text='<%# Eval("Title") %>'></asp:Label>--%>
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
    <!--New product area end-->

    <!--Best Sale product area start-->
    <section class="product_area mb-46">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="section_title">
                        <h2>Best Sale Books</h2>
                    </div>
                </div>
            </div>

            <div class="sliderclass">

                <asp:Repeater ID="rptTopSoldBooks" runat="server" OnItemDataBound="rptBooks_ItemDataBound">
                    <ItemTemplate>
                        <article class="single_product">
                            <figure>
                                <div class="product_thumb">
                                    <a class="primary_img" href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='BookImage/DefaultBook.jpg'" alt=""></a>
                                    <a class="secondary_img" href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                        <img style="width: 184px; height: 184px;" src="BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Back<%#Eval("FontImage") %>" onerror="this.src='BookImage/DefaultBook.jpg'" alt=""></a>
                                    <div class="label_product">
                                        <asp:Label ID="lvlDiscount" runat="server"><span class="label_sale"><%#Eval("SpecialPrice") %>%</span></asp:Label>
                                    </div>
                                    <div class="action_links">
                                        <ul>
                                            <li class="wishlist">
                                                <asp:LinkButton runat="server" ID="btnWishList" title="Add to Wishlist"
                                                    CommandName="AddWishlist" CommandArgument='<%#Eval("Id") %>' OnClick="btnWishList_Click"><i class="fa fa-heart-o" aria-hidden="true"></i></asp:LinkButton></li>
                                            <%--<li class="wishlist"><a href="wishlist.html" title="Add to Wishlist"><i class="fa fa-heart-o" aria-hidden="true"></i></a></li>--%>
                                            <li class="compare"><a href="#" title="compare"><span class="ion-levels"></span></a></li>
                                            <li class="quick_button">
                                                <asp:LinkButton runat="server" ID="btnQuickView" title="quick view"
                                                    CommandName="QuickView" CommandArgument='<%#Eval("Id") %>' OnClick="btnQuickView_Click"><span class="ion-ios-search-strong"></span></asp:LinkButton></li>
                                        </ul>
                                    </div>
                                    <div class="add_to_cart">
                                        <asp:LinkButton ID="btnaddtocart" runat="server" CausesValidation="false" OnClick="btnaddtocart_Click1"><i class="fa fa-shopping-basket"></i> ADD TO CART</asp:LinkButton>
                                    </div>
                                </div>
                                <figcaption class="product_content">
                                    <div class="price_box">
                                        Tk <span class="current_price"><%# Eval("Price") %></span>
                                        <span class="old_price"><%# Eval("OldPrice") %></span>
                                    </div>
                                    <h3 class="product_name"><a href="<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>"><%# Eval("Title") %></a></h3>
                                </figcaption>
                                <!-- all Hidden file -->
                                <asp:HiddenField ID="hfCatID" Value='<%# Eval("Id") %>' runat="server" />
                                <asp:HiddenField ID="hfPId" Value='<%# Eval("Id") %>' runat="server" />
                                <%-- <asp:Label runat="server"  ID="Label2" Text='<%# Eval("Title") %>'></asp:Label>--%>
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
    <!--Best Sale product area end-->

    <!--top- category area start-->
    <section class="top_category_product mb-70">
        <div class="container">
            <div class="row">
                <div class="col-lg-2 col-md-3">
                    <div class="top_category_header">
                        <h3>Popular Book This Week</h3>
                        <p></p>
                        <a href="Pages/Books.aspx">Show All Categories</a>
                    </div>
                </div>
                <div class="col-lg-10 col-md-9">
                    <div class="top_category_container category_column5 owl-carousel">
                        <asp:Repeater ID="rptPopularBook" runat="server">
                            <ItemTemplate>
                                <div class="col-lg-2">
                                    <article class="single_category">
                                        <figure>
                                            <div class="category_thumb">
                                                <a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                                    <img style="width: 132px; height: 125px;" src="BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='BookImage/DefaultBook.jpg'" alt=""></a>
                                            </div>
                                            <figcaption class="category_name">
                                                <h3><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'><%#Eval("Title") %></a></h3>
                                            </figcaption>
                                        </figure>
                                    </article>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--top- category area end-->

    <!--banner area start-->
    <div class="banner_area mb-40">
        <div class="container">
            <div class="row">
                <div class="col-lg-9 col-md-9">
                    <div class="single_banner mb-30">
                        <div class="banner_thumb">
                            <asp:Repeater ID="rptShopNow4" runat="server">
                                <ItemTemplate>
                                    <a href='<%= Page.ResolveUrl("~")%>Pages/Books.aspx?SubCat=<%#Eval("Subcategory") %>'>
                                        <img style="width: 100%; height: 270px;" src="SliderImage/4.jpg" alt="" /></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3">
                    <div class="single_banner mb-30">
                        <div class="banner_thumb">
                            <asp:Repeater ID="rptShopNow5" runat="server">
                                <ItemTemplate>
                                    <a href='<%= Page.ResolveUrl("~")%>Pages/Books.aspx?SubCat=<%#Eval("Subcategory") %>'>
                                        <img style="width: 100%; height: 270px;" src="SliderImage/5.jpg" alt="" /></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--banner area end-->

    <!--product area start-->
    <section class="product_area mb-46">
        <div class="container">
            <asp:Repeater ID="rptSubjectName" runat="server" OnItemDataBound="rptSubjectName_ItemDataBound">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-12">
                            <div class="section_title">
                                <h2>Shop <a href="<%= Page.ResolveUrl("~")%>Pages/Books.aspx?SubCat=<%#Eval("Id") %>"><%# Eval("Name") %></a> Collection</h2>
                                <asp:HiddenField ID="hfCateId" runat="server" Value='<%#Eval("Id") %>' />
                            </div>
                        </div>
                    </div>
                    <div class="sliderclass">
                        <asp:Repeater ID="rptBooks" runat="server" OnItemDataBound="rptBooks_ItemDataBound">
                            <ItemTemplate>
                                <article class="single_product">
                                    <figure>
                                        <div class="product_thumb">
                                            <a class="primary_img" href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                                <img style="width: 184px; height: 184px;" src="BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='BookImage/DefaultBook.jpg'" alt=""></a>
                                            <a class="secondary_img" href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>'>
                                                <img style="width: 184px; height: 184px;" src="BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='BookImage/DefaultBook.jpg'" alt=""></a>
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
                    <br />
                    <asp:Repeater ID="rptHiddenFile1" runat="server">
                        <ItemTemplate>
                            <%--<asp:Label runat="server"  ID="Label2" Text='<%# Eval("Title") %>'></asp:Label>--%>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>
    <!--product area end-->

    <!--blog area start-->
    <section class="blog_section mb-70">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="section_title">
                        <h2>From the Blog</h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="blog_carousel blog_column4 owl-carousel">
                    <asp:Repeater ID="rptBlogRelatedPost" OnItemDataBound="rptBlogRelatedPost_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-3">
                                <article class="single_blog">
                                    <figure>
                                        <div class="blog_thumb">
                                            <a href="Pages/blog-details.aspx?Id=<%# Eval("Id") %>">
                                                <asp:Image ID="blogImg" runat="server" ImageUrl='<%# "~/lib/Blog/" + Eval("img") %>' style="width: 270px; height: 152px;"  onerror="this.src='BookImage/Blog.jpg'" />
                                                </a>
                                            <%--for Video--%>
                                            <asp:Label ID="lvlId" runat="server" Visible="false" Text='<%# Eval("Id") %>'></asp:Label>
                                            <asp:Label ID="lvlCode" runat="server" Visible="false" Text='<%# Eval("Code") %>'></asp:Label>
                                            <asp:Repeater ID="VideosRepeater" runat="server">
                                                <ItemTemplate>
                                                    <object width="420" height="250">
                                                        <%--<param name="movie" value="http://www.youtube.com/v/
		<%# Eval("VideoId") %>"></param>--%>
                                                        <param name="allowFullScreen" value="true"></param>
                                                        <param name="allowscriptaccess" value="always"></param>
                                                        <param name="wmode" value="opaque"></param>
                                                        <embed src="http://www.youtube.com/v/<%# Eval("img") %>?"
                                                            type="application/x-shockwave-flash" width="270"
                                                            height="152" allowscriptaccess="always" allowfullscreen="true"
                                                            wmode="opaque"></embed>
                                                    </object>
                                                </ItemTemplate>
                                                <SeparatorTemplate>
                                                    <br />
                                                </SeparatorTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <figcaption class="blog_content">
                                            <p class="post_author">By <a href="#"><%# Eval("CreatedBy") %></a> <%# Eval("UpdatedDate") %></p>
                                            <h3 class="post_title"><a href="Pages/blog-details.aspx?Id=<%# Eval("Id") %>"><%# Eval("Title") %></a></h3>
                                        </figcaption>
                                    </figure>
                                </article>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>
    <!--blog area end-->

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
                                                            <img style="height: 400px;" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" onerror="this.src='BookImage/DefaultBook.jpg'" alt=""></a>
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

