<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" CodeFile="blog-details.aspx.cs" Inherits="Pages_blog_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                            <li>blog details</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--breadcrumbs area end-->

    <!--blog body area start-->
    <div class="blog_details mt-60">
        <div class="container">
            <div class="row">

                <div class="col-lg-9 col-md-12">
                    <!--blog grid area start-->
                    <div class="blog_wrapper">
                        <article class="single_blog">
                            <asp:Repeater ID="rptBlogDetails" OnItemDataBound="rptBlogDetails_ItemDataBound" runat="server">
                                <ItemTemplate>
                                    <figure>
                                        <div class="post_header">
                                            <h3 class="post_title"><%# Eval("Title") %></h3>
                                            <div class="blog_meta">
                                                <span class="author">Posted by : <a href="#"><%# Eval("CreatedBy") %></a> / </span>
                                                <span class="post_date">On : <a href="#"><%# Eval("UpdatedDate") %></a> /</span>
                                                <span class="post_category">In : <a href="#">Company, Image, Travel</a></span>
                                            </div>
                                        </div>
                                        <div class="blog_thumb">
                                            <a href="#">
                                                <asp:Image ID="blogImg" runat="server" ImageUrl='<%=Page.ResolveUrl("~") %>lib/Blog/<%# Eval("img") %>' Style="width: 100%" onerror="this.src='../BookImage/Blog.jpg'" />
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
                                                            type="application/x-shockwave-flash" width="860" height="615" allowscriptaccess="always" allowfullscreen="true"
                                                            wmode="opaque"></embed>
                                                    </object>
                                                </ItemTemplate>
                                                <SeparatorTemplate>
                                                    <br />
                                                </SeparatorTemplate>
                                            </asp:Repeater>

                                        </div>
                                        <figcaption class="blog_content">
                                            <div class="post_content">
                                                <p><%# Eval("Description") %></p>
                                            </div>
                                            <div class="entry_content">
                                                <div class="post_meta">
                                                    <%--<span>Tags: </span>
                                                    <span><a href="#">, fashion</a></span>
                                                    <span><a href="#">, t-shirt</a></span>
                                                    <span><a href="#">, white</a></span>--%>
                                                </div>

                                                <div class="social_sharing">
                                                    <p>share this post:</p>
                                                    <ul>
                                                        <li><a target="_blank" href="https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Fdevelopers.facebook.com%2Fdocs%2Fplugins%2F&amp;src=sdkpreparse" title="facebook"><i class="fa fa-facebook"></i></a></li>
                                                        <li><a target="_blank" href="https://twitter.com/intent/tweet?" title="twitter"><i class="fa fa-twitter"></i></a></li>
                                                        <li><a target="_blank" href="https://www.instagram.com" title="instagram"><i class="fa fa-instagram"></i></a></li>
                                                        <li><a href="#" title="google+"><i class="fa fa-google-plus"></i></a></li>
                                                        <li><a href="#" title="linkedin"><i class="fa fa-linkedin"></i></a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </figcaption>
                                    </figure>
                                </ItemTemplate>
                            </asp:Repeater>
                        </article>
                        <div class="related_posts">
                            <h3>Related posts</h3>
                            <div class="row">
                                <asp:Repeater ID="rptBlogRelatedPost" OnItemDataBound="rptBlogRelatedPost_ItemDataBound" runat="server">
                                    <ItemTemplate>
                                        <div class="col-lg-4 col-md-4">
                                            <article class="single_related">
                                                <figure>
                                                    <div class="related_thumb">
                                                        <a href="blog-details.aspx?Id=<%# Eval("Id") %>">
                                                            <asp:Image ID="blogImg" runat="server" ImageUrl='<%=Page.ResolveUrl("~") %>lib/Blog/<%# Eval("img") %>' Style="width: 270px; height: 152px;" onerror="this.src='../BookImage/Blog.jpg'" />
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
                                                                        type="application/x-shockwave-flash" width="270" height="152" allowscriptaccess="always" allowfullscreen="true"
                                                                        wmode="opaque"></embed>
                                                                </object>
                                                            </ItemTemplate>
                                                            <SeparatorTemplate>
                                                                <br />
                                                            </SeparatorTemplate>
                                                        </asp:Repeater>

                                                    </div>
                                                    <figcaption class="related_content">
                                                        <div class="blog_meta">
                                                            <span class="author">By : <a href="#"><%# Eval("CreatedBy") %></a> / </span>
                                                            <span class="post_date"><%# Eval("UpdatedDate") %>	</span>
                                                        </div>
                                                        <h4><a href="blog-details.aspx?Id=<%# Eval("Id") %>"><%# Eval("Title") %></a></h4>
                                                    </figcaption>
                                                </figure>
                                            </article>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="comments_box">
                            <div>
                                <asp:Repeater ID="rptrMainComment" OnItemDataBound="rptrMainComment_ItemDataBound" runat="server">
                                    <ItemTemplate>
                                        <div class="reviews_comment_box">
                                            <div class="comment_text">
                                                <div class="reviews_meta">
                                                    <div class="star_rating">
                                                        <ul>
                                                            <%--<asp:Button ID="btnDelete" Visible="false" CommandName="delete" CommandArgument="<%#Eval("Name") %>" runat="server" Text="X" />--%>
                                                            <asp:LinkButton runat="server" ID="btnDeleteCommand" Visible="false"
                                                                CommandName="Delete" CommandArgument='<%#Eval("Id") %>' OnClick="btnDeleteCommand_Click">X</asp:LinkButton>
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
                        </div>
                        <div class="comments_form">
                            <h3>Leave a Reply </h3>
                            <p>Your email address will not be published. Required fields are marked *</p>
                            <div>
                                <div class="row">
                                    <div class="col-12">
                                        <label for="review_comment">Comment </label>
                                        <textarea name="txtreplycomment" style="width: 100%; height: 100px;" id="txtreplycomment" runat="server"></textarea>
                                    </div>
                                    <div class="col-lg-4 col-md-4">
                                        <label for="author">Name</label>
                                        <asp:TextBox ID="txtreplyname" Width="100%" ValidationGroup="mailVal" runat="server" CssClass="form-control" placeholder="First Name" />
                                    </div>
                                    <div class="col-lg-4 col-md-4">
                                        <label for="email">Email </label>
                                        <asp:TextBox ID="txtreplyemail" Width="100%" ValidationGroup="mailVal" runat="server" CssClass="form-control" placeholder="Email" />
                                    </div>
                                </div>
                                <div class="add_to_cart1">
                                    <asp:LinkButton ID="btnaddtocart" runat="server" CssClass="buttonstyle" CausesValidation="false" OnClick="btncomment_Click">Submit Review</asp:LinkButton>
                                </div>
                            </div>
                        </div>

                    </div>
                    <!--blog grid area start-->
                </div>
                <div class="col-lg-3 col-md-12">
                    <div class="blog_sidebar_widget">
                        <div class="widget_list widget_search">
                            <h3>Search</h3>
                            <div>
                                <asp:TextBox runat="server" type="text" placeholder="Search.." OnTextChanged="txtSearch_TextChanged"
                                    ID="txtSearch"></asp:TextBox>
                                <button type="submit">search</button>
                            </div>
                        </div>

                        <div class="widget_list widget_post">
                            <h3>Recent Posts</h3>
                            <asp:Repeater ID="rptRecentPost" runat="server">
                                <ItemTemplate>
                                    <div class="post_wrapper">
                                        <div class="post_info">
                                            <h3><a href="blog-details.aspx?Id=<%# Eval("Id") %>"><%# Eval("Title") %></a></h3>
                                            <span><%# Eval("UpdatedDate") %> </span>
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
    <!--blog section area end-->
</asp:Content>

