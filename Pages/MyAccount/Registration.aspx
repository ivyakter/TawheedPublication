<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/DefaultMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Registration.aspx.cs" Inherits="Pages_MyAccount_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager runat="server" ID="sc1"></asp:ScriptManager>
    <br />
    <h1 class="text-center">Registration Form</h1>
    <br />
    <div class="container">
        <div class="tab-pane" id="Registration">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="row form-group">
                            <asp:Label for="email" Text="First Name" runat="server" ID="lblname" class="col-sm-3  control-label">                    </asp:Label>

                            <div class="col-sm-8 inputGroupContainer">
                                <div class="input-group">
                                    <asp:TextBox ID="txtfirstname" ValidationGroup="mailVal" runat="server" CssClass="form-control" placeholder="First Name" />
                                </div>
                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtfirstname" ID="RegularExpressionValidator3" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" runat="server" ForeColor="Red" ErrorMessage="Please Enter a valid First Name"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator9" ValidationGroup="mailVal" CssClass="text-danger" Visible="true" runat="server" ErrorMessage="First Name is required !" ControlToValidate="txtfirstname"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                        <div class="row form-group">
                            <asp:Label Text="Last Name" runat="server" ID="Label3" class="col-sm-3  control-label">
                            </asp:Label>
                            <div class="col-sm-8 inputGroupContainer">
                                <div class="input-group">
                                    <asp:TextBox ID="txtlastname" ValidationGroup="mailVal" runat="server" CssClass="form-control" placeholder="Last Name" />
                                </div>
                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtlastname" ID="MyPassordMinLengthValidator" ValidationExpression="^[\s\S]{2,}$" runat="server" ForeColor="Red" ErrorMessage="Minimum 2 Text required"></asp:RegularExpressionValidator>

                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" ValidationGroup="mailVal" CssClass="text-danger" Visible="true" runat="server" ForeColor="Red" ErrorMessage="This field is Required !" ControlToValidate="txtlastname"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row form-group">
                            <asp:Label ID="lblemaul2" runat="server" Text="Country" class="col-sm-3 control-label">
                            </asp:Label>
                            <div class="col-sm-8 inputGroupContainer">
                                <div class="input-group">
                                    <asp:TextBox ID="txtCountry" ValidationGroup="mailVal" runat="server" CssClass="form-control" placeholder="Country" />
                                </div>
                            </div>
                        </div>

                        <%----------------%>


                        <div class="row form-group">
                            <asp:Label runat="server" Text="Address" ID="Label9" class="col-sm-3  control-label">
                            </asp:Label>
                            <div class="col-sm-8 inputGroupContainer">
                                <div class="input-group">
                                    <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="House Address" />
                                </div>
                            </div>
                        </div>


                    </div>

                    <div class="col-md-6">

                        <div class="row form-group">
                            <asp:Label runat="server" Text="Mobile" ID="Label8" class="col-sm-3  control-label">
                            </asp:Label>
                            <div class="col-sm-8 inputGroupContainer">
                                <div class="input-group">
                                    <asp:TextBox ID="txtmobile" ValidationGroup="mailVal" runat="server" class="form-control" placeholder="Mobile" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" ValidationGroup="mailVal" CssClass="text-danger" runat="server" ErrorMessage="Required Field !" ControlToValidate="txtmobile"></asp:RequiredFieldValidator>
                                    <%--<asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ValidationGroup="mailVal"
                                ControlToValidate="txtmobile" ErrorMessage="Incorrect Mobile Number" ValidationExpression="^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}(\s?\#(\d{4}|\d{3}))?$">
                            </asp:RegularExpressionValidator>--%>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row form-group">
                            <asp:Label runat="server" Text="Email" ID="Label7" class="col-sm-3 control-label">
                            </asp:Label>
                            <div class="col-sm-8 inputGroupContainer">
                                <div class="input-group">
                                    <asp:TextBox ID="txtEmail" ValidationGroup="mailVal" runat="server" class="form-control" placeholder="Confirm Email" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" ValidationGroup="mailVal" CssClass="text-danger" runat="server" ErrorMessage="Required Field !" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revtxtEmail"
                                        runat="server" ControlToValidate="txtEmail"
                                        ForeColor="Red" Display="Dynamic" Text="invalid email"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row form-group">
                            <asp:Label Text="Password" runat="server" ID="lblpass2" class="col-sm-3  control-label">
                            </asp:Label>
                            <div class="col-sm-8 inputGroupContainer">
                                <div class="input-group">
                                    <asp:TextBox ID="txtPassword" ValidationGroup="mailVal" runat="server" TextMode="Password" class="form-control" placeholder="Password" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-6 col-md-offset-2">
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" ValidationGroup="mailVal" CssClass="text-danger" runat="server" ErrorMessage="Required Field !" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row form-group">
                            <asp:Label Text="Confirm Password" runat="server" ID="Label1" class="col-sm-3  control-label">
                            </asp:Label>
                            <div class="col-sm-8 inputGroupContainer">
                                <div class="input-group">
                                    <%--<input name="emailConfirm" type="password" id="Passconfirm" class="form-control" placeholder="Confirm Password" onblur="confirmPassword()" />--%>
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" class="form-control" placeholder="Confirm Password" />

                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" ValidationGroup="mailVal" CssClass="text-danger" runat="server" ErrorMessage="Required Field !" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cvrPassword" runat="server"
                                        ControlToValidate="txtConfirmPassword" ForeColor="Red"
                                        ControlToCompare="txtPassword" Display="Dynamic"
                                        Type="String" Operator="Equal" Text="password doesn't match">
                                    </asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row"></div>
            <hr />
            <div class="row">
                <div class="col-sm-7 col-sm-offset-3">
                    <span>
                        <asp:CheckBox ID="chkagree" runat="server" />
                        I agree that I am 18 years or over and I also agreed with the Tawheed Publication terms & conditions.

                    </span>

                    <hr />
                </div>
            </div>
            <div class="row">
                <div class="col-sm-7 col-sm-offset-5">
                    <asp:Button type="button" ID="btnsaveconti" runat="server" ValidationGroup="mailVal" OnClick="btnsaveconti_Click" Text="Register " OnClientClick="javascript:shouldsubmit=true;"></asp:Button>
                    
                    <asp:Button runat="server" ID="btncancel" Text="Cancel" CausesValidation="false" OnClick="btncancel_Click" class="buttonstyle"></asp:Button>
                    <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <asp:Label runat="server" ID="distan"></asp:Label>

    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?libraries=places&key=AIzaSyDjR14OREWodXlFSAi-S78TwQG5XhGILdg"></script>
    <script type="text/javascript">
        //start popup validation

        //popup validation
        function validationMsgs(message, title, button) {
            navigator.notification.alert(
                   message,
                   function () { },
                   title,
                   button
                );
        }

        $("#btnconvert").bind("click", function () {
            if ($("#converter").valid()) { 
                //Do i have to add a if condition here if i want to proceed to next page?
            }
            $("#converter").validate({
                messages: {
                    from: "this field is required",
                    rate: "this field is required",

                },
                rules: {
                    rate: {
                        min: 1
                    },
                },
                focusInvalid: false,
                submitHandler: function () {
                    return false;
                },
                errorPlacement: function (error, element) {
                    error.appendTo(element.parent().parent().after());
                },
            });
            // end popup validation

            function CheckHouseNo()
            {
                var houseNo = document.getElementById('houseNo').value

                if (isNaN(houseNo)) {

                }
            }
            function GetAddress() {
                var address = document.getElementById('address').value;
                var geocoder = geocoder = new google.maps.Geocoder();
                geocoder.geocode({ 'address': address }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (results[0]) {
                            var latitude = results[0].geometry.location.lat();
                            var longitude = results[0].geometry.location.lng();

                            var rs = calcCrow(51.531228, 0.003344, latitude, longitude);

                            //alert(51.531228, 0.003344, latitude, longitude);

                            document.getElementById('ContentPlaceHolder1_txtDistance').value = rs.toFixed(2);

                            document.getElementById('ContentPlaceHolder1_txtshowpostcode').value = document.getElementById('address').value;


                            //document.getElementById('ContentPlaceHolder1_txtpostcode').value = document.getElementById('address').value;
                        }
                    }
                });
            }

            //This function takes in latitude and longitude of two location and returns the distance between them as the crow flies (in km)
            function calcCrow(lat1, lon1, lat2, lon2) {
                var R = 6371; // km
                var dLat = toRad(lat2 - lat1);
                var dLon = toRad(lon2 - lon1);
                var lat1 = toRad(lat1);
                var lat2 = toRad(lat2);

                var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
                  Math.sin(dLon / 2) * Math.sin(dLon / 2) * Math.cos(lat1) * Math.cos(lat2);
                var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
                var d = R * c;
                var e = d / 1.60; // For Mile
                return e;
            }

            // Converts numeric degrees to radians
            function toRad(Value) {
                return Value * Math.PI / 180;
            }

            //});

            //$('#submit').click(function () {

            //    //alert("Hello");

            //    //Get Postcode
            //    var number = $('#number').val();
            //    var postcode = $('#address').val().toUpperCase();;

            //    //Get latitude & longitude
            //    $.getJSON('https://maps.googleapis.com/maps/api/geocode/json?address=' + postcode + '&key=[AIzaSyDjR14OREWodXlFSAi-S78TwQG5XhGILdg]', function (data) {

            //        var lat = data.results[0].geometry.location.lat;
            //        var lng = data.results[0].geometry.location.lng;

            //        //Get address    
            //        $.getJSON('https://maps.googleapis.com/maps/api/geocode/json?latlng=' + lat + ',' + lng + '&key=[AIzaSyDjR14OREWodXlFSAi-S78TwQG5XhGILdg]', function (data) {
            //            var address = data.results[0].address_components;
            //            var street = address[1].long_name;
            //            var town = address[2].long_name;
            //            var county = address[3].long_name;

            //            //Insert
            //            $('#text').text(number + ', ' + street + ', ' + town + ', ' + county + ', ' + postcode)

            //            alert(number + ', ' + street + ', ' + town + ', ' + county + ', ' + postcode)
            //        });
            //    });
            //});





            function confirmEmail() {
                var email = document.getElementById("ContentPlaceHolder1_txtemail").value
                var confemail = document.getElementById("confemail").value
                if (email != confemail) {
                    alert('Email Not Matching!');
                }


            }

            function confirmPassword() {
                var Password = document.getElementById("ContentPlaceHolder1_txtpassword").value
                var ConfirmPass = document.getElementById("Passconfirm").value
                if (Password != ConfirmPass) {
                    alert('Password Not Matching!');
                }

            }

            <%--    function checkEmail(event) {

            var msg = document.getElementById("<%=lblemail.ClientID%>");
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (!re.test(event.value)) {
                msg.style.visibility = "visible";
                return false;
            }
            return true;
        }--%>


            <%--        function ValidateFirstName(txt) {

            var msg = document.getElementById("<%=lblFirstNAmeError.ClientID%>");
            if (txt.value.length < 1) {

                msg.style.visibility = "visible";
            }

            else {

                msg.style.visibility = "hidden";
            }

        }--%>

            <%--        function ValidateSecondName(txt) {

            var msg = document.getElementById("<%=lblminimum2cherecter.ClientID%>");
            if (txt.value.length < 2) {

                msg.style.visibility = "visible";
            }

            else {

                msg.style.visibility = "hidden";
            }

        }--%>

            <%-- function ValidatePostCode(txt) {

            var msg = document.getElementById("<%=lblminimumfivecharacter.ClientID%>");
            if (txt.value.length < 5) {

                msg.style.visibility = "visible";
            }

            else {

                msg.style.visibility = "hidden";
            }

        }--%>
        }
        )
    </script>




</asp:Content>

