<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_MyAccount_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <div class="tab-pane" id="Registration">

            <div class="col-md-6">
                <div class="row form-group">
                    <asp:Label for="email" Text="First Name" runat="server" ID="lblname" class="col-sm-3  control-label">
                    </asp:Label>
                    <div class="col-sm-8 inputGroupContainer">
                        <div class="input-group">

                            <asp:TextBox ID="txtfirstname" runat="server" CssClass="form-control" placeholder="First Name" />
                            <span class="input-group-addon"><i class="fa fa-pencil"></i></span>
                        </div>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Must" ControlToValidate="txtfirstname"></asp:RequiredFieldValidator>
                </div>

                <div class="row form-group">
                    <asp:Label for="email" Text="Middle Name" runat="server" ID="Label2" class="col-sm-3 control-label">
                    </asp:Label>

                    <div class="col-sm-8 inputGroupContainer">
                        <div class="input-group">
                            <asp:TextBox ID="txtmiddlename" runat="server" CssClass="form-control" placeholder="Middle Name" />
                            <span class="input-group-addon"><i class="fa fa-pencil"></i></span>
                        </div>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Must" ControlToValidate="txtmiddlename"></asp:RequiredFieldValidator>
                </div>
                <div class="row form-group">
                    <asp:Label Text="Last Name" runat="server" ID="Label3" class="col-sm-3  control-label">
                    </asp:Label>

                    <div class="col-sm-8 inputGroupContainer">
                        <div class="input-group">

                            <asp:TextBox ID="txtlastname" runat="server" CssClass="form-control" placeholder="Last Name" />
                            <span class="input-group-addon"><i class="fa fa-pencil"></i></span>

                        </div>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="Must" ControlToValidate="txtlastname"></asp:RequiredFieldValidator>
                </div>
                <div class="row form-group">
                    <asp:Label ID="lblemaul2" runat="server" Text="Country" class="col-sm-3 control-label">
                    </asp:Label>
                    <div class="col-sm-8 inputGroupContainer">
                        <div class="input-group">
                            <asp:DropDownList ID="ddlcountry" class="form-control" runat="server">
                                <asp:ListItem>United Kingdoom</asp:ListItem>
                            </asp:DropDownList>
                            <span class="input-group-addon"><i class="fa fa-globe"></i></span>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtemail2"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
                <div class="row form-group">
                    <asp:Label runat="server" Text="Post Code" ID="Label4" class="col-sm-3 control-label">
                    </asp:Label>
                    <div class="col-sm-8 inputGroupContainer">
                        <div class="input-group">
                            <asp:TextBox ID="txtpostcode" runat="server" class="form-control" OnChange="javascript:GetAddress(this)" placeholder="Post Code" />
                            <input runat="server" id="distance" />
                            <input type="button" id="clickMe" value="Get Address" onclick="GetAddress()" />
                            <span class="input-group-addon"><i class="fa fa-pencil"></i></span>

                        </div>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="Must" ControlToValidate="txtpostcode"></asp:RequiredFieldValidator>
                </div>

                <div class="row form-group">
                    <asp:Label runat="server" Text="Moblile" ID="Label8" class="col-sm-3  control-label">
                    </asp:Label>
                    <div class="col-sm-8 inputGroupContainer">
                        <div class="input-group">
                            <asp:TextBox ID="txtmobile" runat="server" class="form-control" placeholder="Moblile" />
                            <span class="input-group-addon"><i class="fa fa-phone-square"></i></span>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtmobile"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>

            </div>

            <div class="col-md-6">


                <div class="row form-group">
                    <asp:Label runat="server" Text="Landline" ID="Label5" class="col-sm-3  control-label">
                    </asp:Label>
                    <div class="col-sm-8 inputGroupContainer">
                        <div class="input-group">
                            <asp:TextBox ID="txtlandline" runat="server" class="form-control" placeholder="Landline" />
                            <span class="input-group-addon"><i class="fa fa-phone-square"></i></span>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtmobile"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
                <div class="row form-group">
                    <asp:Label runat="server" Text="Email" ID="Label6" class="col-sm-3  control-label">
                    </asp:Label>
                    <div class="col-sm-8 inputGroupContainer">
                        <div class="input-group">
                            <asp:TextBox ID="txtemail" runat="server" class="form-control" placeholder="Email" />
                            <span class="input-group-addon"><i class="fa fa-phone-square"></i></span>

                        </div>
                    </div>
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid"></asp:RegularExpressionValidator>
                </div>
                <div class="row form-group">
                    <asp:Label runat="server" Text="Email confirmation" ID="Label7" class="col-sm-3 control-label">
                    </asp:Label>
                    <div class="col-sm-8 inputGroupContainer">
                        <div class="input-group">
                            <asp:TextBox ID="txtemailconfirm" runat="server" class="form-control" placeholder="Email confirmation" />
                            <span class="input-group-addon"><i class="fa fa-phone-square"></i></span>

                        </div>
                    </div>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" CssClass="ValidationError" ErrorMessage="Not Matched" ToolTip="Password must be the same" ControlToValidate="txtemailconfirm" ControlToCompare="txtemail"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="Must" ControlToValidate="txtemailconfirm"></asp:RequiredFieldValidator>
                </div>
                <div class="row form-group">
                    <asp:Label Text="Password" runat="server" ID="lblpass2" class="col-sm-3  control-label">
                    </asp:Label>
                    <div class="col-sm-8 inputGroupContainer">
                        <div class="input-group">
                            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" class="form-control" placeholder="Password" />
                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                        </div>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ErrorMessage="Must" ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
                </div>
                <div class="row form-group">
                    <asp:Label Text="Confirm Password" runat="server" ID="Label1" class="col-sm-3  control-label">
                    </asp:Label>
                    <div class="col-sm-8 inputGroupContainer">
                        <div class="input-group">
                            <asp:TextBox ID="txtpasswordconfirm" runat="server" TextMode="Password" class="form-control" placeholder="Confirm Password" />
                            <span class="input-group-addon"><i class="fa fa-key"></i></span>

                        </div>
                    </div>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="ValidationError" ErrorMessage="Not Matched" ToolTip="Password must be the same" ControlToValidate="txtpasswordconfirm" ControlToCompare="txtpassword"></asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="text-danger" runat="server" ErrorMessage="Must" ControlToValidate="txtpasswordconfirm"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row"></div>
            <hr />
            <div class="row">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <span>
                    <asp:CheckBox ID="chkagree" runat="server" />
                    I agree that I am 18 years or over and I also agreed with the BRR Whole Sale terms & conditions.</span>
                <hr />
                <div class="col-sm-7 col-sm-offset-5">
                    <%--<asp:Button type="button" ID="btnsaveconti" runat="server" UseSubmitBehavior="false" CausesValidation="false" OnClick="btnsaveconti_Click" Text="Save & Continue" class="btn btn-primary btn-sm"></asp:Button>--%>
                    <%--<asp:Button runat="server" ID="btncancel" Text="Cancel" CausesValidation="false" class="btn btn-default btn-sm"></asp:Button>--%>
                    <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
                </div>

            </div>

        </div>













        Latitude:
    <input type="text" id="address" />

        <input type="button" value="Get Address" onclick="GetAddress()" />
        <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?libraries=places&key=AIzaSyDjR14OREWodXlFSAi-S78TwQG5XhGILdg"></script>
        <script type="text/javascript">
            function GetAddress() {

                var address = document.getElementById('address').value;

                var geocoder = geocoder = new google.maps.Geocoder();
                geocoder.geocode({ 'address': address }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (results[0]) {
                            var latitude = results[0].geometry.location.lat();
                            var longitude = results[0].geometry.location.lng();


                            alert(calcCrow(51.531228, 0.003344, latitude, longitude));
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
                return d;
            }

            // Converts numeric degrees to radians
            function toRad(Value) {
                return Value * Math.PI / 180;
            }

        </script>
        <%--<form id="form1" runat="server">
        <asp:TextBox ID="txtLocation" runat="server" Text=""></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="FindCoordinates" />
        <br />
        <br />
        <asp:GridView ID="GridView1" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
            runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
                <asp:BoundField DataField="Longitude" HeaderText="Longitude" />
            </Columns>
        </asp:GridView>
    </form>--%>
    </form>
</body>
</html>
