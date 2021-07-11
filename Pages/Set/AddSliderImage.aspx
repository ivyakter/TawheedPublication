<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="AddSliderImage.aspx.cs" Inherits="Pages_Set_AddSliderImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" language="javascript">

        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgCurrent.ClientID%>').prop('src', e.target.result)
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <h2>All Images Must Be .jpg Format</h2>
    <p>For Position 4 Image Dimensions(870x270)</p>
    <p>For Position 5 Image Dimensions(270x270)</p>
    <br />
    <div class="col-md-12">
        <div class="row">

            <div class="col-md-8">

                <div class="row form-group">

                    <div class="col-md-4">
                        Image Position:
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox CssClass="form-control" ID="txtposition" runat="server"></asp:TextBox>

                    </div>
                </div>


                <div class="row form-group">
                    <div class="col-md-4">
                        Image
                    </div>

                    <div class="col-md-4">
                        <asp:FileUpload ID="fuImg01" CssClass="form-control" runat="server" onchange="ShowImagePreview(this);" />
                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidatorfuImg01" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="fuImg01"></asp:RequiredFieldValidator>--%>
                    </div>
                </div>

                <div class="row form-group">

                    <div class="col-md-4">
                        Slider Title :
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox CssClass="form-control" ID="txttitle" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row form-group">
                    <div class="col-md-4">
                        Slider Description :
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox CssClass="form-control" ID="txtdesc" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row form-group">
                    <div class="col-md-4">
                        Select SubCategory :
                    </div>
                    <div class="col-md-4">
                        <asp:DropDownList AppendDataBoundItems="true" runat="server" ID="ddlSubCategory" class="custom-select">
                            <asp:ListItem Value="0" Text="Choose..."></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>


                <div class="form-group">
                    <div class="col-md-10 col-sm-9 col-md-offset-2 col-sm-offset-3">
                        <asp:Button CssClass="Button" ID="btnSave" runat="Server" Text="Save" meta:resourcekey="btnSaveResource1"
                            OnClick="btnSave_Click" />

                    </div>
                </div>

            </div>

            <div class="col-md-4">
                <asp:Image ID="imgCurrent" runat="server" Height="150px" Width="150px" ImageAlign="Middle" /><br />
                <span style="color: Red">Image Dimention :644x532</span>
            </div>
        </div>
    </div>
    <br />
    <div class="col-md-12">
        <div class="row">

            <div class="col-md-2">
                <asp:Image ID="Image1" ImageUrl="../../SliderImage/1.jpg" runat="server" Height="150px" Width="150px" ImageAlign="Middle" /><br />
                <span style="color: Red">1</span>
            </div>

            <div class="col-md-2">
                <asp:Image ID="Image2" ImageUrl="../../SliderImage/2.jpg" runat="server" Height="150px" Width="150px" ImageAlign="Middle" /><br />
                <span style="color: Red">2</span>
            </div>

            <div class="col-md-2">
                <asp:Image ID="Image3" ImageUrl="../../SliderImage/3.jpg" runat="server" Height="150px" Width="150px" ImageAlign="Middle" /><br />
                <span style="color: Red">3</span>
            </div>

            <div class="col-md-2">
                <asp:Image ID="Image4" ImageUrl="../../SliderImage/4.jpg" runat="server" Height="150px" Width="150px" ImageAlign="Middle" /><br />
                <span style="color: Red">4</span>
            </div>

            <div class="col-md-2">
                <asp:Image ID="Image5" ImageUrl="../../SliderImage/5.jpg" runat="server" Height="150px" Width="150px" ImageAlign="Middle" /><br />
                <span style="color: Red">5</span>
            </div>

        </div>
    </div>

</asp:Content>

