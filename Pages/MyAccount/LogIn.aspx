<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="LogIn.aspx.cs" Inherits="Pages_MyAccount_Registration" %>

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
                            <li>My account</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--breadcrumbs area end-->

    <!-- customer login start -->
    <div class="customer_login mt-60">
        <div class="container">
            <div class="row">
                <!--login area start-->
                <div class="col-lg-6 col-md-6">
                    <div class="">
                        <h2>login</h2>
                        <div>
                            <p>
                                <label>Username or email <span>*</span></label>
                                <asp:TextBox ID="txtemaillog" runat="server" ValidationGroup="login" CssClass="form-control" />
                            </p>
                            <p>
                                <label>Passwords <span>*</span></label>
                                <asp:TextBox ID="txtpasslog" ValidationGroup="login" runat="server" TextMode="Password" CssClass="form-control" />
                            </p>
                            <div class="login_submit">
                                <a href="<%= Page.ResolveUrl("~")%>Pages/MyAccount/ForgetPassword.aspx">Lost your password?</a>
                                <label for="remember">
                                    <input id="remember" type="checkbox" />
                                    Remember me
                                </label>
                                <%--<button type="submit">login</button>--%>
                                <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" UseSubmitBehavior="false" CausesValidation="False"></asp:Button>
                            </div>
                        </div>
                    </div>                    
                </div>

                <%-- <div class="col-md-3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="login" CssClass="text-danger" runat="server" ErrorMessage="Email Is Required" ControlToValidate="txtemaillog"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                                                runat="server" ErrorMessage="Invalid Email"
                                                ValidationGroup="login" ControlToValidate="txtemaillog"
                                                CssClass="requiredFieldValidateStyle"
                                                ForeColor="Red"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                            </asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="login" CssClass="text-danger" runat="server" ErrorMessage="Password Is Required" ControlToValidate="txtpasslog"></asp:RequiredFieldValidator>
                                        </div>--%>
                <!--login area start-->

                <!--register area start-->
                <!--register area end-->
            </div>
        </div>
    </div>
    <!-- customer login end -->

</asp:Content>

