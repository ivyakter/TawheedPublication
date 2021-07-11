<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="Pages_MyAccount_ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .form-gap {
            padding-top: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="form-gap"></div>
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="text-center">
                            <h3><i class="fa fa-lock fa-4x"></i></h3>
                            <h2 class="text-center">Forgot Password?</h2>
                            <p>We Are Sending You The Password</p>
                            <div class="panel-body">

                                <div id="register-form">

                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-envelope color-blue"></i></span>
                                            <asp:TextBox runat="server" ID="txtemail" placeholder="email address" class="form-control"></asp:TextBox>
                                            <%--<input id="email" name="email" placeholder="email address" class="form-control" type="email">--%>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button runat="server" ID="btnsave" CausesValidation="false" OnClick="btnsave_Click" class="btn btn-lg btn-primary btn-block" Text="Send Email"  />
                                       <%-- <input name="recover-submit" class="btn btn-lg btn-primary btn-block" value="Reset Password" type="submit">--%>
                                    </div>
                                    <asp:Label runat="server" ID="lblerror" Visible="false" ForeColor="#ff0000" Font-Size="Larger"></asp:Label>
                                   <%-- <input type="hidden" class="hide" name="token" id="token" value="">--%>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

