<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="RegisterGrievance.aspx.cs" Inherits="MeghalayaUIP.RegisterGrievance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <link rel="stylesheet" href="assets/admin/css/style.css">
    <style>
        .page-wrapper {
            padding-top: 15px;
        }

        div#ContentPlaceHolder1_UpdatePanel1 {
            width: 90%;
            margin: 0px 76px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Grievance</h4>
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
                                    <div class="row">
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">
                                                <asp:Label ID="LabelHeading" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                                    Width="450px"></asp:Label></h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Register <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlRegisterAs" runat="server" class="form-control txtbox"
                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlRegisterAs_SelectedIndexChanged">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                            <asp:ListItem Value="G">Grievance</asp:ListItem>
                                                            <asp:ListItem Value="Q">Query</asp:ListItem>
                                                            <asp:ListItem Value="F">Feedback</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Application Category <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlModule" runat="server" class="form-control"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row" runat="server" id="divapplname" visible="true">
                                                    <label class="col-lg-6 col-form-label">Applicant Name <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtApplcantName" runat="server" class="form-control txtbox"
                                                            MaxLength="40" TabIndex="1" ValidationGroup="group" onkeypress="return Names(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="trData" visible="false" runat="server">
                                                <div class="form-group row" runat="server" id="divPreReg" visible="false">
                                                    <label class="col-lg-6 col-form-label">Select Company Name <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlPreRegUnits" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlPreRegUnits_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group row" runat="server" id="divCFE" visible="false">
                                                    <label class="col-lg-6 col-form-label">Select Company Name <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlCFEUnits" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlCFEUnits_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group row" runat="server" id="divCFO" visible="false">
                                                    <label class="col-lg-6 col-form-label">Select Company Name <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlCFOUnits" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlCFOUnits_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group row" runat="server" id="divIncentives" visible="false">
                                                    <label class="col-lg-6 col-form-label">Select Company Name <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlIncUnits" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlIncUnits_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group row" runat="server" id="divRenewals" visible="false">
                                                    <label class="col-lg-6 col-form-label">Select Company Name <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlRENUnits" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlRENUnits_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Company Name <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtindname" runat="server" class="form-control txtbox"
                                                            MaxLength="40" TabIndex="1" ValidationGroup="group" onkeypress="return Names(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">E-Mail <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control txtbox" TextMode="Email"
                                                            MaxLength="40" TabIndex="1" ValidationGroup="group" onblur="validateEmail(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mobile Number <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMob" runat="server" class="form-control txtbox"
                                                            TabIndex="1" ValidationGroup="group" onkeypress="return PhoneNumberOnly(event)" MaxLength="10" onblur="validateIndianMobileNumber(this);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">District <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddldist" runat="server" class="form-control txtbox"
                                                            TabIndex="1">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Select Department <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddldept" runat="server" class="form-control txtbox"
                                                            TabIndex="1">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Subject <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtSub" runat="server" class="form-control txtbox"
                                                            TabIndex="1" TextMode="MultiLine" Height="40px" onkeypress="return validateNameAndNumbers(event)"
                                                            ValidationGroup="group"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-2 col-form-label">Description <span class="star">*</span></label>
                                                    <div class="col-lg-9 d-flex">
                                                        <asp:TextBox ID="txtDesc" runat="server" class="form-control txtbox"
                                                            TabIndex="1" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)"
                                                            ValidationGroup="group"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-2 col-form-label">Upload (If any)</label>
                                                    <div class="col-lg-8 d-flex">
                                                        <asp:FileUpload ID="FileUpload" runat="server"
                                                            Height="28px" />
                                                        <asp:HyperLink ID="lblFileName1" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-2">
                                                <div class="form-group row mt-1">
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
                                            <div class="col-md-12 float-end">
                                                <div class="form-group row justify-content-end">
                                                    <asp:Button ID="btnClear" Text="Clear" Visible="true" runat="server" class="btn btn-rounded btn-warning btn-lg" OnClick="btnClear_Click" Width="150px" />
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnsave" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
