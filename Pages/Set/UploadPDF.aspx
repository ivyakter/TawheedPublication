<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="UploadPDF.aspx.cs" Inherits="Pages_Set_UploadPDF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <b>Admin / Blog</b>
            </div>
        </div>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Upload PDF</h6>
            </div>
            <div class="card-body">
                <asp:Label runat="server" ID="lblhiddenFieldForId" Visible="false"></asp:Label>

                <asp:Panel ID="panelUploadPFD" runat="server">
                    <div class="mx-auto col-md-8">
                        <div class="form-group">
                            <%--<div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping">Title: </span>
                                </div>
                                <asp:TextBox runat="server" ID="txtTitle" autocomplete="off"
                                    class="form-control" aria-describedby="addon-wrapping"></asp:TextBox>
                            </div>--%>
                        </div>
                        <div class="form-group">
                            <%--<div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping2">Description</span>
                                </div>
                                <asp:TextBox runat="server" ID="txtDescription" autocomplete="off" TextMode="MultiLine" Rows="10"
                                    class="form-control" aria-describedby="addon-wrapping2"></asp:TextBox>
                            </div>--%>
                        </div>
                        <div class="form-group">
                            <div class="input-group flex-nowrap">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" id="addon-wrapping3">Upload PDF</span>
                                </div>
                                <asp:FileUpload ID="fileFrontImage" class="form-control" runat="server" onchange="FrontImagePreview(this);" />
                            </div>
                            
                        </div>
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" class="btn btn-secondary btn-sm"
                            Text="Cancel" OnClick="btnCancel_Click"
                             />
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary btn-sm" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                </asp:Panel>

            </div>
        </div>
    </div>
    <!-- /.container-fluid -->

</asp:Content>

