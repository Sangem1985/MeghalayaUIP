<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SWMDetails.aspx.cs" Inherits="MeghalayaUIP.User.Services.SWMDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        input[type=checkbox], input[type=radio] {
            box-sizing: border-box;
            padding: 6px 0px !important;
            margin: 0px 6px !important;
        }
    </style>
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
        function handleKeyUp(input) {
            if (input.value.trim() === "") {
                input.style.border = "2px solid red";
            }
            else {
                input.style.border = "1px solid #767575b5";
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a>Services</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Solid Waste Management</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" runat="server" id="divText">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Application for Authorization Under Solid Waste Management:</h4>
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
                                            <h4 class="card-title ml-3">1. Particulars of Application: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">
                                                        Name of the local body/agency appointed by them/operator of facility :
                                                    </label>
                                                    <div class="col-lg-3">
                                                        <asp:TextBox ID="txtNameLocalBody" Type="text" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex mt-2">
                                            <h4 class="card-title ml-3">2. Nodal Officer & Designation: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">
                                                        Officer authorised by the local body/agency responsible
                                                        for operation of processing/treatment or disposal facility
                                                    </label>
                                                    <div class="col-lg-3">
                                                        <asp:TextBox ID="txtDesignation" Type="text" class="form-control" runat="server" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex mt-2">
                                            <h4 class="card-title ml-3">3. Authorization Requirements: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-8 col-form-label">1. For setting up and opeartion of the facility: (Please tick mark)*</label>
                                                    <div class="col-lg-12 d-flex">
                                                        <asp:CheckBoxList ID="CHKAuthorization" runat="server" RepeatDirection="Vertical" RepeatColumns="4" Style="padding: 20px">
                                                            <asp:ListItem Text="Waste Processing" Value="1" class="pr-4"></asp:ListItem>
                                                            <asp:ListItem Text="Recycling" Value="3" class="pr-4"></asp:ListItem>
                                                            <asp:ListItem Text="Treatment" Value="4" class="pr-4"></asp:ListItem>
                                                            <asp:ListItem Text="Dispersal at Landfill" Value="5" class="pr-4"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">
                                                        2. For all kind of Solid Waste Management Facility authorization, Please select number of years*
                                                    </label>
                                                    <div class="col-lg-3 ">
                                                        <asp:DropDownList ID="ddlAuthYears" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlAuthYears_SelectedIndexChanged">
                                                            <asp:ListItem Text="--Select--" Value="0" Readonly="True" Disabled="True"></asp:ListItem>
                                                            <asp:ListItem Text="1 Year" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="5 Years" Value="5"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Total Fees*</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtAuthFee" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" AutoPostBack="true" TabIndex="1" ReadOnly="true" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex mt-2">
                                            <h4 class="card-title ml-3">4. Processing / Recycling / Treatment of solid waste</h4>
                                        </div>
                                        <div class="col-md-12 d-flex flex-wrap" style="margin-top: -10px;">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        i. Total Quantity of waste to be processed per day:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtWasteProduced" Type="number" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Quantity of waste to be recycled:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtWasteRecycled" runat="server" Type="number" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Quantity of waste to be treated:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtWasteTreated" runat="server" Type="number" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Quantity of waste to be disposed into landfill:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtWasteDisposed" runat="server" Type="number" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        ii. Utitlization programme for waste processed(Product Utitlization) :
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtUtilisation" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Quantity of leachate:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtQuanLeachate" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Treatment technology for leachate:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtTreatmentLeachate" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        iv. Measures to be taken for prevention and control of environmental pollution
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtMeasuresForPrevention" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        v. Measures to be taken for safety of workers working in the plant
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtMeasuresForSafety" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">5. Disposal Of Solid Waste: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex flex-wrap">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Number Of sites identified:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtSiteIdentified" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Quantity of waste to be disposed per day:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtQantityWasteDisposed" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Details Of Existing Site under operation :
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtExistingSiteUnderOperation" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Methodology and operational details of landfilling :
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLandfillingDetails" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Measures taken to check environmental pollution :
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtMeasureToChkEnvPoltn" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex mt-4">
                                            <h4 class="card-title ml-3">6. Attachments: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex" style="margin-top: -25px;">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-3 col-form-label"></label>
                                                    <div class="col-lg-2 d-flex">
                                                    </div>
                                                    <div class="col-lg-4 d-flex">
                                                        <label class="col-lg-5 col-form-label">Reference No </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Methodology for disposal  </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtCBWTFSWM" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupDisposal" runat="server" />

                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnDisposal" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnDisposal_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypSolidwaste" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblSolidwaste" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Details on solid waste processing/recycling/treatment/disposal facility </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtSWPRTD" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupDetailsSolidWaste" runat="server" />

                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnDetailsSolidWaste" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnDetailsSolidWaste_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypSWPRTD" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblSWPRTD" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Details of methodology or criteria followed for site selection </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtDetailSiteSel" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupDetailSiteSelection" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnDetailSiteSelection" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnDetailSiteSelection_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypDetailSiteSel" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblDetailSiteSel" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Site Clearance </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtSiteClr" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupSiteClearance" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnSiteClearance" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnSiteClearance_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypSiteClr" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblSiteClearance" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Environmental Clearance Consent for eshtablishment </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtEnvClearance" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupEnvironmentalClearance" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnEnvironmentalClearance" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnEnvironmentalClearance_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypEnvClearance" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblEnvClearance" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Agreement Between municipal authority and opearting agency </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtAgreement" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupAgreement" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnAgreement" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnAgreement_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypAgreement" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblAgreement" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 text-right mt-2 mb-2">
                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" OnClick="btnPreviuos_Click" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" OnClick="btnsave_Click" />
                                            <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" OnClick="btnNext_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnDisposal" />
            <asp:PostBackTrigger ControlID="btnDetailsSolidWaste" />
            <asp:PostBackTrigger ControlID="btnDetailSiteSelection" />
            <asp:PostBackTrigger ControlID="btnSiteClearance" />
            <asp:PostBackTrigger ControlID="btnEnvironmentalClearance" />
            <asp:PostBackTrigger ControlID="btnAgreement" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
