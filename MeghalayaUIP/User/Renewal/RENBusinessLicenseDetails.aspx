<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENBusinessLicenseDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENBusinessLicenseDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
    //let originalValue = "";
    function handleKeyUp(input)
    {
        if (input.value.trim() === "") {
            input.style.border = "2px solid red";
        }
        else {
            input.style.border = "1px solid #767575b5";
        }
    }
    </script>
    <style>
        i.fi.fi-br-circle-camera {
            font-size: 32px;
            margin-right: -21px;
            padding-left: 6px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Renewal</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Business License Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" runat="server" id="divText">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Business License Details</h4>
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
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Existing License Details</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Previous License Number*</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLicNo" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License Issue Date *</label>
                                                    <div class="col-lg-6">
                                                        <%--  <asp:TextBox ID="txtLicIssue" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtLicIssue" class="form-control" onkeypress="validateNumberAndHyphen(event);" onkeyup="handleKeyUp(this)" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLicIssue"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License Valid Upto *</label>
                                                    <div class="col-lg-6">
                                                        <%-- <asp:TextBox ID="txtLicValid" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtLicValid" class="form-control" onkeypress="validateNumberAndHyphen(event);" onkeyup="handleKeyUp(this)" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLicValid"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Basic Details</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of the Shop/Business Establishment *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNameBusiness" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Whether Establishment is owned by *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblOwned" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Firm/Company" Value="Y" />
                                                            <asp:ListItem Text="Individual" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of the Individual/authorized representative *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtIndividualName" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mobile Number *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" MaxLength="10" onblur="validateIndianMobileNumber(this);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">E-Mail Id *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtEmailId" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Passport Size Photograph of Individual/Authorized Representative *</label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupPhoto" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btndpr" OnClick="btndpr_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:HyperLink ID="hypPhoto" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Establishment Address</span></label>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Address of the establishment *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtAddress" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nature of Business  *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtNatureBusiness" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Type of Establishment  *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblApplication" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Private owned establishment" Value="Y" />
                                                            <asp:ListItem Text="Municipal owned shop/establishment" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 text-right mt-2 mb-2">

                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" OnClick="btnPreviuos_Click" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded  btn-info btn-lg" Width="150px" OnClick="btnNext_Click" />

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
            <asp:PostBackTrigger ControlID="btndpr" />

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
