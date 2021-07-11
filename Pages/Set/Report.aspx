<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Pages_Set_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <b>Admin / Report</b>
            </div>
        </div>

        <div class="table-responsive">
            <asp:GridView ID="gridViewRepot" runat="server" class="table table-striped text-justify"
                AllowPaging="True" PageSize="20" AllowSorting="True"
                GridLines="None"
                AutoGenerateColumns="False" DataKeyNames="Title" DataSourceID="SqlDataSource1">
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
                    <asp:TemplateField HeaderText="Total order Quantity" SortExpression="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                            ConnectionString="<%$ ConnectionStrings:ServerDb %>"
                            SelectCommand="Select Books.Title, SUM(tblOrder2.Quantity) Quantity from Books join tblOrder2 on Books.Title=tblOrder2.PName Group By Books.Title order By Quantity Desc"></asp:SqlDataSource>
            <br /><br /><br /><br /><br /><br />
        </div>
    </div>
    <!-- /.container-fluid -->

</asp:Content>

