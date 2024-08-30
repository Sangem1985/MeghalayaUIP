<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RegisterHelpDesk.aspx.cs" Inherits="MeghalayaUIP.User.HelpDesk.RegisterHelpDesk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
      .custom-textbox {
    height: 60px !important;
}
    </style>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">HelpDesk</h4>
                        </div>
                        <div class="card-body">
                            <div class="col-md-12 ">
                                <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span></button>
                                </div>
                            </div>
                            <div class="col-md-12 ">
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show" align="Center">
                                    <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                              <asp:HiddenField ID="hdnusername" runat="server" />
                            <div class="row">
                                <div class="col-md-12 d-flex">
                                    <h4 class="card-title ml-3">
                                        <asp:Label ID="LabelHeading" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                            Width="199px"></asp:Label></h4>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name *</label>                                           
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtindname" runat="server" class="form-control txtbox"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row" runat="server" id="divapplname" visible="true">
                                            <label class="col-lg-6 col-form-label">Unit Name *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtApplcantName" runat="server" class="form-control txtbox"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">UID Number *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtUIDNO" runat="server" class="form-control txtbox"
                                                    TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mobile No *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMobileNo" runat="server" class="form-control txtbox"
                                                    TabIndex="1"
                                                    ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Your Mail Id *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEmailid" runat="server" class="form-control txtbox"
                                                    TabIndex="1"
                                                    ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">HelpDesk Type *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlHelpdesk" runat="server" class="form-control txtbox"
                                                    TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Text="Data Correction"></asp:ListItem>
                                                    <asp:ListItem Text="Data Deletion"></asp:ListItem>
                                                    <asp:ListItem Text="Technical Issue"></asp:ListItem>
                                                    <asp:ListItem Text="New Requirement"></asp:ListItem>
                                                    <asp:ListItem Text="Change Request"></asp:ListItem>
                                                    <asp:ListItem Text="Data Porting"></asp:ListItem>
                                                    <asp:ListItem Text="Information"></asp:ListItem>
                                                    <asp:ListItem Text="Others"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label">HelpDesk Description *</label>
                                            <div class="col-lg-9 d-flex">
                                                <asp:TextBox ID="txtDesc" runat="server" class="form-control custom-textbox"
                                                    TabIndex="1" TextMode="MultiLine" Height="100px"
                                                    ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Upload </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:FileUpload ID="FileUpload" runat="server"
                                                    Height="28px" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group row mt-1">
                                            <asp:HyperLink ID="lblFileName1" runat="server" Target="_blank"></asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="col-md-6">
                                            <asp:Label ID="Label560" runat="server" Visible="False"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Button ID="BtnUpload" runat="server" CssClass="form-control txtbox"
                                                TabIndex="10" Text="Upload1"
                                                Visible="False" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-12 float-end">
                                        <div class="form-group row justify-content-end">
                                            <asp:Button ID="btnClear" Text="Clear" Visible="true" runat="server" OnClick="btnClear_Click" class="btn btn-rounded btn-warning btn-lg" Width="150px" />
                                            <asp:Button runat="server" Text="Submit" ID="btnsave" OnClick="btnsave_Click" class="btn btn-rounded btn-submit btn-lg mr-2" Width="150px" />

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
