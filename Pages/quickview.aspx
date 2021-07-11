<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quickview.aspx.cs" Inherits="Pages_quick_view" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="Kuteshop is new Html theme that we have designed to help you transform your store into a beautiful online showroom. This is a fully responsive Html theme, with multiple versions for homepage and multiple templates for sub pages as well" />
    <meta name="keywords" content="kuteshop,7uptheme" />
    <meta name="robots" content="noodp,index,follow" />
    <meta name='revisit-after' content='1 days' />
    <title>Quick View</title>
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,700' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" type="text/css" href="../css/libs/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/libs/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/libs/bootstrap-theme.css" />
    <link rel="stylesheet" type="text/css" href="../css/libs/jquery.fancybox.css" />
    <link rel="stylesheet" type="text/css" href="../css/libs/jquery-ui.min.css" />
    <link rel="stylesheet" type="text/css" href="../css/libs/owl.carousel.css" />
    <link rel="stylesheet" type="text/css" href="../css/libs/owl.transitions.css" />
    <link rel="stylesheet" type="text/css" href="../css/libs/owl.theme.css" />
    <link rel="stylesheet" type="text/css" href="../css/libs/jquery.mCustomScrollbar.css" />
    <link rel="stylesheet" type="text/css" href="../css/libs/animate.css" />
    <link rel="stylesheet" type="text/css" href="../css/libs/hover.css" />
    <link rel="stylesheet" type="text/css" href="../css/theme.css" media="all" />
    <link rel="stylesheet" type="text/css" href="../css/color-orange.css" media="all" />
    <link rel="stylesheet" type="text/css" href="../css/responsive.css" media="all" />
    <link rel="stylesheet" type="text/css" href="../css/browser.css" media="all" />
    <!-- <link rel="stylesheet" type="text/css" href="css/rtl.css" media="all"/> -->
</head>
<body style="">
    <form id="form1" runat="server">
         <div class="modal fade" id="modal_box" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
                555555555555
                <div class="modal_body">
                    <div class="container">
                        <asp:Repeater runat="server" ID="repeaterBooksQuickView" OnItemCommand="repeaterBooksQuickView_ItemCommand">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-lg-5 col-md-5 col-sm-12">
                                        <div class="modal_tab">
                                            <div class="tab-content product-details-large">
                                                <div class="tab-pane fade show active" id="tab1" role="tabpanel">
                                                    <div class="modal_tab_img">
                                                        <a href="#">
                                                            <asp:Image ID="imgFrontImage" runat="server" Width="300px" Height="350px"
                                                                ImageUrl='<%# "~/BookImage/"+ Eval("Code") +"/"+ Eval("Code")+"Font"+Eval("FontImage") %>'
                                                                AlternateText="no image available" /></a>
                                                    </div>
                                                </div>
                                                <div class="tab-pane fade" id="tab2" role="tabpanel">
                                                    <div class="modal_tab_img">
                                                        <a href="#">
                                                            <asp:Image ID="imgBackImage" runat="server" Width="100%" Height="100%"
                                                                ImageUrl='<%# "~/BookImage/"+ Eval("Code") +"/"+ Eval("Code")+"Back"+Eval("FontImage") %>'
                                                                AlternateText="no image available" /></a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal_tab_button">
                                                <ul class="nav product_navactive owl-carousel" role="tablist">
                                                    <li>
                                                        <a class="nav-link active" data-toggle="tab" href="#tab1" role="tab" aria-controls="tab1" aria-selected="false">
                                                            <asp:Image ID="imgFrontImageView" runat="server" Width="100%" Height="100%"
                                                                ImageUrl='<%# "~/BookImage/"+ Eval("Code") +"/"+ Eval("Code")+"Font"+Eval("FontImage") %>'
                                                                AlternateText="no image available" /></a>
                                                    </li>
                                                    <li>
                                                        <a class="nav-link" data-toggle="tab" href="#tab2" role="tab" aria-controls="tab2" aria-selected="false">
                                                            <asp:Image ID="imgBackImageView" runat="server" Width="100%" Height="100%"
                                                                ImageUrl='<%# "~/BookImage/"+ Eval("Code") +"/"+ Eval("Code")+"Back"+Eval("FontImage") %>'
                                                                AlternateText="no image available" /></a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-7 col-md-7 col-sm-12">
                                        <div class="modal_right">
                                            <div class="modal_title mb-10">
                                                <h2><%#Eval("Title") %></h2>
                                            </div>
                                            <div class="modal_price mb-10">
                                                <span class="new_price">&#2547 <%#Eval("SpecialPrice") %></span>
                                                <span class="old_price">&#2547 <%#Eval("Price") %></span>
                                            </div>
                                            <div class="modal_description mb-15">
                                                <p>
                                                    Authors:<br />
                                                    <asp:Label runat="server" ID="lblBookAuthorsView"></asp:Label>
                                                </p>
                                            </div>
                                            <div class="modal_description mb-15">
                                                Description:
                                                <p><%#Eval("Description") %></p>
                                            </div>
                                            <div class="modal_description mb-15">
                                                <p>
                                                    In Categories:
                                                    <br />
                                                    <asp:Label runat="server" ID="lblBookCategoriesView"></asp:Label>
                                                </p>
                                            </div>
                                            <div class="variants_selects">
                                                <div class="modal_add_to_cart">
                                                    <asp:TextBox TextMode="Number" ID="txtQuantity" Width="10%"
                                                        runat="server" Text="0"></asp:TextBox>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-dark btn-sm"
                                                        CommandName="AddToCart"
                                                        CommandArgument='<%#Eval("Id") + "," + Eval("FontImage") + "," + Eval("Title") + "," + Eval("Price")%>'> 
                                                                ADD TO CART
                                                    </asp:LinkButton>
                                                </div>
                                                <div>
                                                    <asp:RangeValidator ID="rvdtxtQuantity"
                                                        ErrorMessage="Please enter value between 1-99."
                                                        ForeColor="Red" ControlToValidate="txtQuantity"
                                                        MinimumValue="1" MaximumValue="99" runat="server" Type="Integer">
                                                    </asp:RangeValidator>
                                                </div>
                                            </div>
                                            <div class="modal_social">
                                                <h2>Share this product</h2>
                                                <ul>
                                                    <li class="facebook"><a href="#"><i class="fa fa-facebook"></i></a></li>
                                                    <li class="twitter"><a href="#"><i class="fa fa-twitter"></i></a></li>
                                                    <li class="pinterest"><a href="#"><i class="fa fa-pinterest"></i></a></li>
                                                    <i class="google-plus"><a href="#"><i class="fa fa-google-plus"></i></a></i>
                                                    <li class="linkedin"><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                                </ul>
                                            </div>
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
    </form>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/libs/bootstrap.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/libs/jquery.fancybox.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/libs/jquery-ui.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/libs/owl.carousel.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/libs/jquery.jcarousellite.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/libs/jquery.elevatezoom.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/libs/TimeCircles.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/libs/jquery.mCustomScrollbar.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/libs/wow.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/theme.js"></script>
</body>
</html>
