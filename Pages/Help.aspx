<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="Pages_Help" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server" ID="sc1">
    </asp:ScriptManager>
    <div style="padding-bottom: 350px">



        <br />
        <div class="h1 text-center">
            BRR WHOLE SALE  HELP 
        </div>
        <br />

        <div class="col-md-4 col-md-offset-4 col-md-4">
            <asp:DropDownList runat="server" Font-Size="Larger" ID="ddlaction" Height="80%" AutoPostBack="true" OnSelectedIndexChanged="ddlaction_SelectedIndexChanged" CssClass="form-control">
                <asp:ListItem Value="0">--Select One-- </asp:ListItem>
                <asp:ListItem Value="1">Order Status</asp:ListItem>
                <asp:ListItem Value="2">Login </asp:ListItem>
                <asp:ListItem Value="3">Navigation  </asp:ListItem>
                <asp:ListItem Value="4">Password Reset  </asp:ListItem>
                <asp:ListItem Value="5">Payment</asp:ListItem>
                <asp:ListItem Value="6">Recent Invoices and Surveys </asp:ListItem>
                <asp:ListItem Value="7">Register</asp:ListItem>
                <asp:ListItem Value="8">Reports </asp:ListItem>
                <asp:ListItem Value="9">Search </asp:ListItem>
                <asp:ListItem Value="10">Shopping Basket</asp:ListItem>

                <asp:ListItem Value="11">Browsers</asp:ListItem>
                <asp:ListItem Value="12">Devices</asp:ListItem>
                <asp:ListItem Value="13">Operating system</asp:ListItem>
                <asp:ListItem Value="14">Browsers(Desktop)</asp:ListItem>
                <asp:ListItem Value="15">Browsers(Mobile)</asp:ListItem>
                <asp:ListItem Value="16">Cache Clearing(Chrome)</asp:ListItem>
                <asp:ListItem Value="17">Cache Clearing(IE)</asp:ListItem>
                <asp:ListItem Value="18">Cache Clearing(Firefox)</asp:ListItem>
                <asp:ListItem Value="19">Application Cache Clearing(Chrome)</asp:ListItem>
                <asp:ListItem Value="20">Performance</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />

        <div class="col-md-6 col-md-offset-4 text-left" style="padding-top: 20px;">
            <asp:UpdatePanel runat="server" ID="up1">
                <ContentTemplate>

                    <asp:Panel runat="server" ID="pnlOrderstatus" Visible="false">
                        <h4>* Open : The Shopping Basket has Not Been Checked out Yet     </h4>
                        <h4>* Processing : The Order Is Being Processed </h4>
                        <h4>* Expired : The Cut Off Time Has Been Passed For The Shopping Basket</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnllogin" Visible="false">
                        <h4>* Login Button Is Located Top Right Of The Site </h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlnavigation" Visible="false">
                        <h4>* Account Setting </h4>
                        <h4>* Branch Locator </h4>
                        <h4>* Browse / Download Brochures </h4>
                        <h4>* Product Category Navigation </h4>
                        <h4>* Track An order </h4>
                        <h4>* Vendor self Service</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlpasswordreset" Visible="false">
                        <h4>* Go To Password Reset </h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlpayment" Visible="false">
                        <h4>* We Accept, Cash ,Cheque And All Major Cards</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlinvoicesurveys" Visible="false">
                        <h4>* To access Your Recent Invoices And Surveys you Can Click On "Order Manager"</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlregister" Visible="false">
                        <h4>* Registration Is Top Right</h4>
                        <h4>* No SignUp Fees Or Membership Required</h4>
                        <h4>* You Can Register Either As A Personal Or Business Account</h4>
                        <h4>* Please Ensure You Have a Valid Mobile Number Or Landline</h4>
                        <h4>* Please Ensure You Have a Valid PostCode</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlreports" Visible="false">
                        <h4>* You Can Generate An Annual Summery </h4>
                        <h4>* You Can Consolidate Your Invoices</h4>
                        <h4>* You Can Download your Invoices Through Consolidated Invoices</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlsearch" Visible="false">
                        <h4>* Try By Brand</h4>
                        <h4>* Try By Category</h4>
                        <h4>* Try By Item Id</h4>
                        <h4>* Try By Item Ids</h4>
                        <h4>* Try By Item Name</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlshopingbasket" Visible="false">
                        <h4>* We Have A Full Featured Shopping Basket</h4>
                        <h4>* Switching Brand ?-Only Available For Collection</h4>
                        <h4>* Switching Date ?-Yes</h4>
                        <h4>* Switching From Collection to Delivery ?- Yes , But Based On Date</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlbrowser" Visible="false">
                        <h4>* Download -Chrome (Desktop)</h4>
                        <h4>* Download -Chrome (Mobile)</h4>
                        <h4>* Download -Firefox</h4>
                        <h4>* Download -IE10+</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnldevices" Visible="false">
                        <h4>* We Support All Major , Modern Devices</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnloperatingsystem" Visible="false">
                        <h4>* We Support All Major , Modern Operating System</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlbrowserdesktop" Visible="false">
                        <h4>* Before IE10 Is Not Supported</h4>
                        <h4>* Chrome , Please Ensure You Have Latest Version </h4>
                        <h4>* Firefox , 41.0 Is Not Working Properly . Older Version Is OK</h4>
                        <h4>* Safari , Please Ensure You Have At Least Version 4</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlbrowsermobile" Visible="false">
                        <h4>* IOS, At Least Version 8.1 , Run Chrome For IOS If Not Possible</h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlchromecacheclearing" Visible="false">
                        <h4>* You Can Clear Cache By ( Shift + Ctrl + Delete ) </h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlfirefoxcacheclear" Visible="false">
                        <h4>* You Can Clear Cache By ( Shift + Ctrl + Delete ) </h4>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlIEcacheclear" Visible="false">
                        <h4>* You Can Clear Cache By ( Shift + Ctrl + Delete ) </h4>
                    </asp:Panel>

                       <asp:Panel runat="server" ID="pnlperformance" Visible="false">
                           <h4>* Performance Can Vary From Browser To Browser</h4>
                           <h4>* Performance Can Vary From Device To Device</h4>
                           <h4>* Speed And Type Of Your Internet Connection Might Effect The Performance</h4>
                           <h4>* We Are Constantly Striving To make Your Experience Better</h4>
                    </asp:Panel>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>

