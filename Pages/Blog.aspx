<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Pages_Blog" %>

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
                            <li>blog</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--breadcrumbs area end-->

    <!--blog area start-->
    <div class="blog_page_section mt-60">
        <div class="container">
            <div class="row">
                <div class="col-lg-9">
                    <div class="blog_wrapper">
                        <div class="blog_header">
                            <h1>Blog</h1>
                            <br />
                            <div class="blog_pagination">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="pagination">
                        <ul>
                            <li>
                                <asp:Button ID="btn_All" runat="server" Text="All" OnClick="btn_All_Click" class="btn btn-primary btn-sm" /></li>
                            <li style="margin:0 20px 0 7px;">
                                <asp:Button ID="btn_popular" runat="server" Text="Popular" OnClick="btn_popular_Click" class="btn btn-primary btn-sm" /></li>
                            <li style="margin:0 20px;">
                                <asp:Button ID="btn_Leatest" runat="server" Text="Leatest" OnClick="btn_Leatest_Click" class="btn btn-primary btn-sm" /></li>
                            <li style="margin:0 20px;">
                                <asp:Button ID="btn_Video" runat="server" Text="Video" OnClick="btn_Video_Click" class="btn btn-primary btn-sm" /></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
                        </div>
                        <div class="row">
                            <asp:Repeater ID="rptBlogs" OnItemDataBound="rptBlogs_ItemDataBound" runat="server">
                                <ItemTemplate>
                                    <div class="col-lg-6 col-md-6">
                                        <article class="single_blog mb-60">
                                            <figure>
                                                <div class="blog_thumb">
                                                    <a href="blog-details.aspx?Id=<%# Eval("Id") %>">
                                                        <asp:Image ID="blogImg" runat="server" ImageUrl='<%# "~/lib/Blog/" + Eval("img") %>' style="width: 420px; height: 250px;" onerror="this.src='../BookImage/Blog.jpg'" />
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
                                                                    type="application/x-shockwave-flash" width="420"
                                                                    height="250" allowscriptaccess="always" allowfullscreen="true"
                                                                    wmode="opaque"></embed>
                                                            </object>
                                                        </ItemTemplate>
                                                        <SeparatorTemplate>
                                                            <br />
                                                        </SeparatorTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <figcaption class="blog_content">
                                                    <h3><a href="blog-details.aspx?Id=<%# Eval("Id") %>"><%# Eval("Title") %></a></h3>
                                                    <div class="blog_meta">
                                                        <span class="author">Posted by : <a href="#"><%# Eval("CreatedBy") %></a> / </span>
                                                        <span class="post_date">On : <a href="#"><%# Eval("UpdatedDate") %></a></span>
                                                    </div>
                                                    <div class="blog_desc">
                                                        <p><%# Eval("Description").ToString().Substring(0,200) %> </p>
                                                    </div>
                                                    <footer class="readmore_button">
                                                        <a href="blog-details.aspx?Id=<%# Eval("Id") %>">read more</a>
                                                    </footer>
                                                </figcaption>
                                            </figure>
                                        </article>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>


                        </div>
                    </div>
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
    <!--blog area end-->

    <!--blog pagination area start-->
    <div class="blog_pagination">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="pagination">
                        <ul>
                            <li class="current">1</li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li class="next"><a href="#">next</a></li>
                            <li><a href="#">>></a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--blog pagination area end-->
</asp:Content>

