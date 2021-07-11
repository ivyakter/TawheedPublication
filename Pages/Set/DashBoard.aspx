<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="Pages_Set_DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-body">
        <div class="page-wrapper">
            <!-- Page-header start -->
            <div class="page-header">
                <div class="row align-items-end">
                    <div class="col-lg-8">
                        <div class="page-header-title">
                            <div class="d-inline">
                                <h4>Invoice Summary</h4>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="page-header-breadcrumb">
                            <ul class="breadcrumb-title">
                                <li class="breadcrumb-item">
                                    <a href="index.html"><i class="feather icon-home"></i></a>
                                </li>
                                <li class="breadcrumb-item"><a href="#!">Widget</a> </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Page-header end -->
            <!-- Page body start -->
            <div class="page-body">
                <div class="row">
                    <div class="col-lg-12">
                        <!-- Recent Orders card start -->
                        <div class="card">
                            <div class="card-header">
                                <h5>Recent Orders</h5>

                            </div>
                            <div class="card-block table-border-style">
                                <div class="table-responsive">
                                    <table class="table table-lg table-styling">
                                        <thead>
                                            <tr class="table-primary">
                                                <th>#</th>
                                                <th>Order No.</th>
                                                <th>Customer Email</th>
                                                <th>Price</th>
                                                <th>Date</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptRecentOrder">
                                                <ItemTemplate>
                                                    <tr>
                                                        <th scope="row">1</th>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("InvoiceNumber") %>'></asp:Label></td>
                                                        <td><asp:Label ID="Label2" runat="server" Text='<%# Bind("Email") %>'></asp:Label></td>
                                                        <td><asp:Label ID="Label3" runat="server" Text='<%# Bind("TotalPaymentAmount") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("InvoiceDateTime") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!-- Recent Orders card end -->
                    </div>
                    <br />
                    <div class="col-xl-12">
                        <br />
                        <!-- Sales and expense card start -->
                        <div class="card">
                            <div class="card-header">
                                <h5>Sales And Expenses</h5>
                            </div>
                            <div class="card-block">
                                <canvas id="barChart" width="400" height="300"></canvas>
                            </div>
                        </div>
                        <!-- Sales and expense card end -->
                    </div>
                </div>
            </div>
            <!-- Page body end -->
        </div>
    </div>





</asp:Content>

