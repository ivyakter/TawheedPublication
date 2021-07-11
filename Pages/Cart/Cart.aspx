<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Pages_Cart_Cart" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:Label runat="server" ID="lblloigin" Visible="false"></asp:Label>

    <asp:Panel runat="server" ID="pnl2">

        <%--<div style="font-size:5px;">

        </div>--%>

        <div id="content">
            <div class="content-page woocommerce">
                <div class="container">
                    <div class="cart-content-page">
                        <h2 class="title-shop-page">my cart</h2>



                        <asp:GridView ID="GridView1" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
                            OnRowCommand="GridView1_RowCommand" CssClass="table table-striped table-bordered table-hover" DataKeyNames="pid" AutoGenerateColumns="False"
                            runat="server" Visible="False" EmptyDataText="Empty Shopping Cart">

                            <AlternatingRowStyle BackColor="White" />

                            <Columns>
                                <asp:TemplateField HeaderText="Product Id" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("pid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Barcode" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBarcode" runat="server" Text='<%# Eval("Barcode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField Visible="false" HeaderText="Image" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <img src="../../ProductImage/<%#Eval("pid") %>/<%#Eval("Imagename")%><%#Eval("Imageextension")%>" width="70px" height="70px" alt="<%#Eval("Imagename")%>" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpname" runat="server" Text='<%# Eval("pname") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Button ID="btdcre" runat="server" Text="-" CommandName="decrement" Visible="false" CausesValidation="false" UseSubmitBehavior="false"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        <asp:Label ID="LblQ" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>
                                        <%--<asp:Button ID="btincre" runat="server" Text="+" CommandName="increment" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />--%>
                                        <asp:Button ID="btincre" runat="server" Text="+" CausesValidation="false" UseSubmitBehavior="false" CommandName="increment" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCtyUpdate" runat="server" Width="20px" Text='<%# Eval("quantity") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ControlStyle Height="20px" Width="50px" />
                                    <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Price" FooterStyle-Font-Bold="True" FooterStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblprice" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        &nbsp;
                            <asp:Label ID="Label1" runat="server" Text="Grand Total :"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Center" Font-Bold="True"></FooterStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Discount %" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblhfvatamount" runat="server" Text='<%# Eval("hfvatamount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Total Price" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltotal" runat="server" Text='<%# Eval("total") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lbltt" Font-Bold="true" runat="server" />
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <FooterStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                            </Columns>



                        </asp:GridView>


                    </div>
                    <br />
                    <div class="row form-group">
                        <asp:Label Text="Special Request" runat="server" ID="Label3" class="col-sm-3  control-label">
                        </asp:Label>

                        <div class="col-sm-8 inputGroupContainer">
                            <div class="input-group">

                                <asp:TextBox ID="txtspecialrequest" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Special Requist" />
                                <span class="input-group-addon"><i class="fa fa-pencil"></i></span>

                            </div>
                        </div>

                    </div>

                    <br />

                    <div class="row" style="text-align: center">


                        <asp:Button runat="server" ID="btncheckout" Text="Check Out" CssClass="buttonstyle" CausesValidation="false" UseSubmitBehavior="false" OnClick="btncheckout_Click" />

                        &nbsp;&nbsp;&nbsp;
                         <asp:Button runat="server" ID="btncontinue" Text="Continur Shopping" OnClick="btncontinue_Click" CssClass="buttonstyle" UseSubmitBehavior="false" CausesValidation="false" />
                        <%--<a href="../../Home.aspx" class="buttonstyle">Continur Shopping</a>--%>
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>
    <br />
    <br />
    <asp:UpdatePanel runat="server" ID="up1">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pan1" Visible="false">

                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <h2 class="title-shop-page">Customer Information</h2>
                                <asp:UpdatePanel ID="updatepanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="my-profile-box register-content-box">
                                            <div class="form-my-account">
                                                <div class="row">
                                                    <div class="col-md-10" style="padding-top: 30px">
                                                        <asp:Label Text="Please Fillup All Information To Confirm Order" Font-Italic="true" Font-Size="Larger" ForeColor="Red" runat="server" ID="lblconfirm"></asp:Label>
                                                        <hr />
                                                        <div class="row form-group">
                                                            <asp:Label ID="lblemaul2" runat="server" Text="Email :" class="col-sm-3 control-label">
                                                            </asp:Label>
                                                            <div class="col-sm-9 inputGroupContainer">
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtEmail" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" runat="server" class="form-control" placeholder="Email" required />
                                                                    <%--<span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>--%>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtemail2"></asp:RequiredFieldValidator>--%>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row form-group">
                                                            <asp:Label for="email" Text="Name :" runat="server" ID="lblname" class="col-sm-3 control-label">
                                                            </asp:Label>
                                                            <div class="col-sm-9 inputGroupContainer">
                                                                <div class="input-group">

                                                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Full Name" required />
                                                                    <%--<span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>--%>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtname"></asp:RequiredFieldValidator>--%>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <%--<div class="row form-group">
                                                            <asp:Label Text="Password :" runat="server" ID="Label2" class="col-sm-3 control-label">
                                                            </asp:Label>
                                                            <div class="col-sm-9 inputGroupContainer">
                                                                <div class="input-group">

                                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" />
                                                                    <%--<span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>--%>
                                                                <%--</div>
                                                            </div>
                                                        </div>--%>

                                                        <div class="row form-group">
                                                            <asp:Label runat="server" Text="Mobile :" ID="lblmobile" class="col-sm-3 control-label">
                                                            </asp:Label>
                                                            <div class="col-sm-9 inputGroupContainer">
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="Mobile" required />
                                                                    <%--<span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtmobile"></asp:RequiredFieldValidator>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row form-group">
                                                            <asp:Label Text="Address :" runat="server" ID="lblpass2" class="col-sm-3 control-label">
                                                            </asp:Label>
                                                            <div class="col-sm-9 inputGroupContainer">
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="form-control" placeholder="Address" required />

                                                                    <%--<span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>--%>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtpass2"></asp:RequiredFieldValidator>--%>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row form-group">
                                                            <asp:Label Text="Ref ID :" runat="server" ID="lblrefid" class="col-sm-3 control-label">
                                                            </asp:Label>
                                                            <div class="col-sm-9 inputGroupContainer">
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtrefid" runat="server" class="form-control" placeholder="Ref ID " />
                                                                    <%--<span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>--%>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <h2 class="title-shop-page"></h2>
                            <div class="row">
                                <asp:Panel ID="Panel2" runat="server">
                                    <asp:Label Text="Please Choice Payment Option" Font-Italic="true" Font-Size="Larger" ForeColor="Red" runat="server" ID="lblpayment"></asp:Label>
                                    <hr />
                                    <ul class="nav nav-tabs" id="myTab">
                                        <li class="active"><a data-toggle="tab" href="#wallets">Payment On Mobile</a></li>
                                        <li><a data-toggle="tab" href="#cod">Cash On Delivery</a></li>
                                        <li><a data-toggle="tab" href="#cards">CREDIT/DEBIT CARDS</a></li>
                                    </ul>
                                    <div class="tab-content col-sm-12">
                                        <div id="wallets" class="tab-pane fade in active">
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                                <ContentTemplate>

                                                    <table class="table" width="100%">
                                                        <tr>
                                                            <td style="text-align: right">Select Payment Method</td>
                                                            <td></td>
                                                            <td style="text-align: left">
                                                                <asp:DropDownList ID="ddlPaymentMethod" runat="server" OnSelectedIndexChanged="ddlPaymentMethod_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                    <asp:ListItem>Skrill</asp:ListItem>
                                                                    <asp:ListItem>Bikash</asp:ListItem>
                                                                    <asp:ListItem>Datch Bangla Mobile Bangking</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">                                                                                                                              
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:MultiView ID="MultiView1" runat="server">
                                                                    <asp:View ID="VSkrilled" runat="server">
                                                                        <table class="table" width="100%">
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <div id="Div2">
                                                                                        <p><img src="../../images/SkrillLogo.png" width="30px" /></p>
                                                                                        <p>
                                                                                            <b>Skril Payment Steps :</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            You can make payments from your Skrill Account to our <b>Skrill Account</b> .
                                                                                        </p>
                                                                                        <p>
                                                                                            01. Go to your Skrill Account 
                                                                                        </p>
                                                                                        <p>
                                                                                            02. Choose <b>Send Money</b> option 
                                                                                        </p>
                                                                                        <p>
                                                                                            03. Enter the Skrill Account Number to Recipient email: <b>httkislam@gmail.com</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            04. Enter the Amount <b style="color: brown;">$<asp:Literal ID="ltrlPayAmt1" runat="server"></asp:Literal>
                                                                                            </b>then enter Review and then send.
                                                                                        </p>
                                                                                        <p>
                                                                                            05. Go to All Transactions and click arrow below and note that the Transaction ID
                                                                                        </p>
                                                                                        <p>
                                                                                            06. Place the Transaction Id into Transaction Number TextBox
                                                                                        </p>
                                                                                        <p>
                                                                                            07. Enter your skrill Email Address 
                                                                                        </p>
                                                                                        <p>
                                                                                            Done! You have complited your Payment from Skrill.
                                                                                        </p>

                                                                                    </div>
                                                                                    <br />
                                                                                    <br />
                                                                                    <div class="panel-header" style="height: 30px; background-color: #79a3aa; padding: 10px; font-size: 16px">Skilled Payment</div>
                                                                                    <br />
                                                                                    <br />
                                                                                    <div>
                                                                                        Enter here Skill Transaction Number :&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtSkillTransaction" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div>
                                                                                        Skrill Email Address.(Send from) :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtEmailSkrill" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <br />
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:View>
                                                                    <asp:View ID="VBikash" runat="server">
                                                                        <table class="table" width="100%">
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <div id="bkasMannualText">
                                                                                        <p><img src="../../images/BkashLogo.png" width="30px" /></p>
                                                                                        <p>
                                                                                            <b>bKash Payment Steps :</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            You can make payments from your bKash Account to our <b>Merchant</b> .
                                                                                        </p>
                                                                                        <p>
                                                                                            01. Go to your bKash Mobile Menu by dialing <b>*247#</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            02. Choose <b>Payment</b> option by pressing <b>3</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            03. Enter the Merchant bKash Account Number <b>01677802233</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            04. Enter the fare <b style="color: brown;">$<asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                                                                            </b>you want to pay.
                                                                                        </p>
                                                                                        <p>
                                                                                            05. Write the word <b>tickets</b> against your payment
                                                                                        </p>
                                                                                        <p>
                                                                                            06. Enter the Counter Number <b>0</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            07. Now enter your bKash Mobile Menu <b>PIN</b> to confirm
                                                                                        </p>
                                                                                        <p>
                                                                                            Done! You will receive a <b>confirmation message</b> from bKash.
                                                                                        </p>
                                                                                        <p>
                                                                                            *If Reference or Counter No. or both are not applicable, you can skip them by entering <b>0</b>.
                                                                                        </p>
                                                                                        <p>
                                                                                            <b>*** Please wait 2 minutes..... Then try with your bKash Trx ID, otherwise you will see the &quot;Access denied . Transation ID is not related to username&quot; messsage</b>.
                                                                                        </p>
                                                                                        <p>
                                                                                            &nbsp;
                                                                                        </p>
                                                                                    </div>
                                                                                    <br />
                                                                                    <br />
                                                                                    <div class="panel-header" style="height: 30px; background-color: #79a3aa; padding: 10px; font-size: 16px">Bikash Payment</div>
                                                                                    <br />
                                                                                    <br />
                                                                                    <div>
                                                                                        Enter here Bikash Transaction Number :
                                                        <asp:TextBox ID="txtBikashTranstacitonNumebr" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div>
                                                                                        Bikash Phone No.(Send from) :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtMobileBikash" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <br />
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:View>
                                                                    <asp:View ID="VDutchBangla" runat="server">
                                                                        <table class="table" width="100%">
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <div id="Div1">
                                                                                        <p><img src="../../images/DutchBanglaBank.png" width="30px" /></p>
                                                                                        <p>
                                                                                            <b>Dutch Bangla Payment Steps :</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            You can make payments from your Dutch Bangla Account to our <b>Merchant</b> .
                                                                                        </p>
                                                                                        <p>
                                                                                            01. Go to your Dutch Bangla Mobile Menu by dialing <b>*247#</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            02. Choose <b>Payment</b> option by pressing <b>3</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            03. Enter the Merchant Dutch Bangla Account Number <b>01677802233</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            04. Enter the fare <b style="color: brown;">$<asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                                                                            </b>you want to pay.
                                                                                        </p>
                                                                                        <p>
                                                                                            05. Write the word <b>tickets</b> against your payment
                                                                                        </p>
                                                                                        <p>
                                                                                            06. Enter the Counter Number <b>0</b>
                                                                                        </p>
                                                                                        <p>
                                                                                            07. Now enter your Dutch Bangla Mobile Menu <b>PIN</b> to confirm
                                                                                        </p>
                                                                                        <p>
                                                                                            Done! You will receive a <b>confirmation message</b> from bKash.
                                                                                        </p>
                                                                                        <p>
                                                                                            *If Reference or Counter No. or both are not applicable, you can skip them by entering <b>0</b>.
                                                                                        </p>
                                                                                        <p>
                                                                                            <b>*** Please wait 2 minutes..... Then try with your Dutch Bangla Trx ID, otherwise you will see the &quot;Access denied . Transation ID is not related to username&quot; messsage</b>.
                                                                                        </p>
                                                                                        <p>
                                                                                            &nbsp;
                                                                                        </p>
                                                                                    </div>
                                                                                    <br />
                                                                                    <br />
                                                                                    <div class="panel-header" style="height: 30px; background-color: #79a3aa; padding: 10px; font-size: 16px">Bikash Payment</div>
                                                                                    <br />
                                                                                    <br />
                                                                                    <div>
                                                                                        Enter here Dutch Transaction Number :
                                                        <asp:TextBox ID="txtDutchBanglaTransaction" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <div>
                                                                                        Dutch Phone No.(Send from) :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtPhoneNumDutch" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                    </div>
                                                                                    <br />
                                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:View>
                                                                </asp:MultiView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div id="cards" class="tab-pane fade ">
                                            <div style="font-size: inherit; line-height: inherit;">
                                                <p><b>Please ensure your card is active and on hand to fill in your details.</b></p>
                                                <p style="margin: 17px 0"></p>
                                                <p>Click Confirm Order below to complete payment and check-out.</p>

                                                <p style="margin: 17px 0"></p>
                                                <p><b>Cancellation  Policy: </b></p>

                                                <p style="margin: 17px 0">Please have the exact amount available as our delivery driver may not be carrying sufficient change.</p>
                                                <p style="margin: 17px 0"></p>
                                                <p><b>Online Refund Policy:</b></p>
                                                <p style="margin: 17px 0"></p>
                                                <p>Online refund will take 7 to 10 working days. It might take longer based on bank and transaction method.</p>
                                                <p>*By clicking "Confirm Order" you are agreeing to all <a href="<%=Page.ResolveUrl("~")%>" style="color: blue;">Terms &amp; Conditions.</a></p>

                                                <div>
                                                    <div>
                                                        <%-- <asp:Button ID="btnShowLogin" runat="server" Text="Confirm Mobile payment" CssClass="btn btn-danger" />--%>


                                                        <asp:Button ID="btncard" CssClass="btn btn-primary btn-md" OnClick="btncard_Click" runat="server" Text="Pay With card" />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="cod" class="tab-pane fade">
                                            <div style="font-size: inherit; line-height: inherit;">
                                                <p>Pay cash at your doorstep at the time of order delivery.</p>
                                                <p style="margin: 17px 0"></p>
                                                <p style="margin: 17px 0"><b>Important:</b></p>
                                                <p style="margin: 17px 0">Please have the exact amount available as our delivery driver may not be carrying sufficient change.</p>
                                                <p style="margin: 17px 0"></p>
                                                <p style="margin: 17px 0">If you have multiple items in an order, you might not receive every item at same time. Don't worry - all your items will arrive shortly.</p>
                                                <p style="margin: 17px 0"></p>
                                                <p style="margin: 17px 0"><b>Caution: Final Step </b></p>
                                                <p style="margin: 17px 0">This is the final step. Once you click "Confirm Order", you will not be able to change or edit your order. </p>
                                                <p>To cancel, edit or change your order go back to top and edit/delete product.</p>
                                                <p style="margin: 17px 0"></p>
                                                <p style="margin: 17px 0">Please note that we have the right to refuse or cancel any order at any time whether or not the order has been confirmed and your credit card charged. In case of cancellation of prepaid orders (fully or partially), full amount paid by the customer will be refunded within 2-3 business days of cancelling the orders.</p>
                                                <p style="margin: 17px 0">*By clicking "Confirm Order" you are agreeing to all </p>

                                            </div>

                                        </div>

                                    </div>

                                </asp:Panel>
                            </div>
                        </div>


                        

                    </div>
                </div>
                <div class="col-md-12" style="text-align: center;">
                            <asp:Button ID="btncod" CausesValidation="false" UseSubmitBehavior="false" runat="server" Text="Confirm Order" CssClass="btn btn-danger" OnClick="btncod_Click" />
                            <br />
                            <br />
                        </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

