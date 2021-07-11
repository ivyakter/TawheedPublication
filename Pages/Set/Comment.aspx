<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="Comment.aspx.cs" Inherits="Pages_Set_Comment" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <b>Admin / Comment</b>
            </div>
        </div>

        <div class="table-responsive">
            <h2>Books Comments</h2>
            <asp:GridView ID="gridViewBookComment" runat="server" class="table table-striped text-justify" OnRowCommand="gridViewBookComment_RowCommand"
                AllowPaging="True" PageSize="20" AllowSorting="True"
                GridLines="None" AutoGenerateColumns="False" >
                <Columns>
                    <asp:TemplateField HeaderText="Sl." SortExpression="Sl.">
                        <ItemTemplate>
                            <%#Container.DataItemIndex +1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Book Name" SortExpression="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment" SortExpression="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblComment" runat="server" Text='<%# Bind("Comments") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <ItemTemplate>
                            <asp:Label ID="lbName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date" SortExpression="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete" SortExpression="Quantity">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDeleteCommand" Style="color:red; font:bold" CommandName="Delete" CommandArgument='<%#Eval("Id") %>' >X</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                            SelectCommand="Select Comments.Id, Title, Name, Comments, Comments.Date from Comments join Books ON Comments.PId=Books.Id Where LevelNo='User' order By Comments.Date Desc"></asp:SqlDataSource>
            <br /><br />
            <h2>Blogs Comments</h2>
                      <asp:GridView ID="gridViewBlogComment" runat="server" class="table table-striped text-justify"
                AllowPaging="True" PageSize="20" AllowSorting="True"
                GridLines="None" OnRowCommand="gridViewBlogComment_RowCommand"
                AutoGenerateColumns="False" >
                <Columns>
                    <asp:TemplateField HeaderText="Sl." SortExpression="Sl.">
                        <ItemTemplate>
                            <%#Container.DataItemIndex +1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Blog Id" SortExpression="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("PId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment" SortExpression="Comment">
                        <ItemTemplate>
                            <asp:Label ID="lblComment" runat="server" Text='<%# Bind("Comments") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date" SortExpression="Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete" SortExpression="Delete">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDeleteCommand" Style="color:red; font:bold" CommandName="Delete" CommandArgument='<%#Eval("Id") %>'>X</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                            SelectCommand="Select * from Comments Where LevelNo='Bolger' order By Comments.Date Desc"></asp:SqlDataSource>
            <br /><br /><br /><br /><br /><br />
        </div>
    </div>
    <!-- /.container-fluid -->

</asp:Content>

