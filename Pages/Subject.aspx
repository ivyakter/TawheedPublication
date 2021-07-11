<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" CodeFile="Subject.aspx.cs" Inherits="Pages_Writer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="col-md-12">
        <asp:Repeater ID="rptSubject" runat="server">
            <ItemTemplate>
                <div class="col-md-12">
                    <div class="col-md-4">
                        <p><%#Eval("Name") %></p>
                    </div>
                    <div class="col-md-8">
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:Label runat="server" Font-Bold="true" Font-Size="XX-Large" ForeColor="#663300" ID="lblemptydate"></asp:Label>
    <div class="grid-pro-color">
        <div class="row">
            <asp:Repeater ID="rptrWriterBooks" runat="server" OnItemDataBound="rptrWriterBooks_ItemDataBound">
                <ItemTemplate>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="item-product" style="padding: 10px 30px; border-bottom: 2px solid #f8f9f9;">

                            <div class="product-thumb">
                                <a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>' class="product-thumb-link">

                                    <img style="height: 200px !important" width="300" src="../BookImage/<%#Eval("Code") %>/<%#Eval("Code") %>Font<%#Eval("FontImage") %>" alt="<%#Eval("Title")%>" />

                                    <asp:Label ID="lvlDiscount" runat="server">
                                                                    <div  class="discount"><p><%# Eval("SpecialPrice") %><sub>%</sub> </p><span>Off</span></div></asp:Label>
                                </a>
                                <a href='<%# String.Concat("Pages/quickview.aspx?PID=", Eval("Id").ToString()) %>' class="quickview-link plus fancybox.iframe">quick view</a>

                            </div>
                            
                            <div class="product-info">
                                <h3 class="product-title" style="padding-top: 10px;"><a href='<%# String.Concat("Pages/ProductDetails.aspx?PID=", Eval("Id").ToString()) %>' class="product-thumb-link"><b><%# Eval("Title") %></b></a></h3>

                                <div class="product-price" style="text-align: left">
                                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <span style="font-size: small">Price :  </span>Tk. <ins><span><%# Eval("Price") %></span></ins>
                                    <%--<span style="font-size: small">Spacial Price :</span> Tk. <ins><span><%# Eval("SpecialPrice") %></span></ins>--%>
                                </div>

                                
                                <div>
                                    <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btnaddtocart_Click1">
                                                               <i class="fa fa-shopping-basket"></i> ADD TO CART</asp:LinkButton>
                                </div>

                                <!-- all Hidden file -->
                                <asp:HiddenField ID="hfCatID" Value='<%# Eval("Id") %>' runat="server" />
                                <asp:HiddenField ID="hfSubCatID" Value='<%# Eval("Subject") %>' runat="server" />
                                <asp:HiddenField ID="hfBrandID" Value='<%# Eval("Writer") %>' runat="server" />
                                <asp:HiddenField ID="hfPId" Value='<%# Eval("Id") %>' runat="server" />
                                <asp:HiddenField ID="hfname" Value='<%# Eval("Title") %>' runat="server" />
                                <asp:HiddenField ID="hfprice" Value='<%# Eval("Price") %>' runat="server" />
                                <asp:HiddenField ID="hfproductid" Value='<%# Eval("Code") %>' runat="server" />
                                <asp:HiddenField ID="hfimagename" Value='<%# Eval("FontImage") %>' runat="server" />
                                <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("FontImage") %>' runat="server" />
                                <asp:HiddenField ID="hfvatamount" Value='<%# Eval("SpecialPrice") %>' runat="server" />
                                <!-- all Hidden file End -->
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>
    </div>
</asp:Content>

