<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="IndustryRegistration.aspx.cs" Inherits="MeghalayaUIP.User.PreReg.IndustryRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        span.icon, span.icon2, span.icon3 {
            top: 35px !important;
        }

        span.icon3 {
            left: 485px !important;
        }

        div#basictab2 input {
            border: 1px solid #fff;
        }

        tr.GridviewScrollC1Item td, tr.GridviewScrollC1Item2 td {
            padding: 2px 5px 2px 10px;
        }
    </style>
    <div class="page-wrapper tabs">

        <div class="content container-fluid">
            <%--<section class="comp-section">--%>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="col-md-12 d-flex">
                                <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 d-flex">
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                                    <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                            <%-- <ul class="nav nav-tabs">
                                <li class="nav-item" runat="server" id="Li1">
                                    <a class="nav-link  active" href="#basictab1" data-toggle="tab">1.Basic Details</a>
                                </li>
                                <li class="nav-item" runat="server" id="Li2">
                                    <a class="nav-link" href="#basictab2" data-toggle="tab">2. Basic Revenue Projections</a>
                                </li>
                                <li class="nav-item" runat="server" id="Li3">
                                    <a class="nav-link" href="#basictab3" data-toggle="tab">3.Details of the Applicant / Promoter(s) / Partner(s) / Directors(s) / Members</a>
                                </li>
                            </ul>
                            --%>
                            <ul class="nav nav-tabs">
                                <li class="nav-item">
                                    <asp:LinkButton ID="Link1" class="nav-link active" runat="server" OnClick="Link1_Click" Style="padding-right: 20px; font-size: 20px"> 
                                    1. Basic Details</asp:LinkButton></li>
                                <%-- </li>
                                    <li class="nav-item">--%>
                                <li class="nav-item">
                                    <asp:LinkButton ID="Link2" class="nav-link" runat="server" OnClick="Link2_Click" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                    2. Basic Revenue Projections</asp:LinkButton></li>
                                <%-- </li>
                                    <li class="nav-item">--%>
                                <li class="nav-item">
                                    <asp:LinkButton ID="Link3" class="nav-link" runat="server" OnClick="Link3_Click" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                   3. Details of the Applicant / Promoter(s) / Partner(s) / Directors(s) / Members</asp:LinkButton></li>
                            </ul>
                            <div class="tab-content">
                                <asp:MultiView ID="MVprereg" runat="server" OnActiveViewChanged="MVprereg_ActiveViewChanged">
                                    <asp:View ID="viewBasic" runat="server">
                                        <div class="tab-pane active" id="basictab1">
                                            <div class="card-body" runat="server" id="divbasic">
                                                <span class="icon"><i class="fi fi-br-caret-down"></i></span>
                                                <h4 class="card-title" style="background: #abbd07; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">1. Basic Details</h4>

                                                <div class="row">

                                                    <%--<div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900; font-size: 20px;">Basic Details</span></label>
                                                </div>--%>
                                                    <div class="col-md-12 d-flex">

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Company PAN card No *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtPANno" class="form-control" onblur="fnValidatePAN(this);" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Company Name as per PAN *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtUnitName" class="form-control" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Company Type *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlcompanytype" runat="server" class="form-control">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Company Proposal *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rblproposal" runat="server" RepeatDirection="Vertical" RepeatColumns="2">
                                                                        <asp:ListItem Value="Existing" Text="Existing"></asp:ListItem>
                                                                        <asp:ListItem Value="New" Text="New"></asp:ListItem>
                                                                        <asp:ListItem Value="Expansion" Text="Expansion"></asp:ListItem>


                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">GSTIN Number * </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtGSTNo" class="form-control" onblur="validateGST(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Category of Registration*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlRegType" runat="server" class="form-control" OnSelectedIndexChanged="ddlRegType_SelectedIndexChanged" AutoPostBack="true">
                                                                        <asp:ListItem Text="Select Category" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="lblregntype" runat="server">Registraion No *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtUdyamorIEMNo" Enabled="false" class="form-control" onkeypress="return validateNameAndNumbers(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Company Registration / Incorporation Date *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox type="text" runat="server" ID="txtCompnyRegDt" class="date form-control" />
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900; font-size: 20px;">Correspodence Details of Authorised Representative</span></label>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Name *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtAuthReprName" class="form-control" onkeypress="return Names(this)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mobile *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtAuthReprMobile" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">E-mail *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtAuthReprEmail" class="form-control" onblur="validateEmail(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Locality *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtAuthReprLocality" class="form-control" onkeypress="return Names(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">District *</label>
                                                                <div class="col-lg-6">
                                                                    <asp:DropDownList runat="server" ID="ddlAuthReprDist" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAuthReprDist_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mandal/Taluka *</label>
                                                                <div class="col-lg-6 d-flex">

                                                                    <asp:DropDownList runat="server" ID="ddlAuthReprTaluka" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAuthReprTaluka_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Village *</label>
                                                                <div class="col-lg-6 d-flex">

                                                                    <asp:DropDownList runat="server" ID="ddlAuthReprVillage" class="form-control">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Door No. *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtAuthReprDoorNo" class="form-control" onkeypress="return validateNameAndNumbers(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Pincode *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtAuthReprPincode" class="form-control" onkeypress="return validatePincode(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900; font-size: 20px;">Location of Unit</span></label>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-6">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Is Land Required *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList runat="server" ID="rblLandType" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="Own" Text="Own Land"></asp:ListItem>
                                                                        <asp:ListItem Value="Required" Text="Required"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Door No. *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtPropLocDoorno" class="form-control" onkeypress="return validateNameAndNumbers(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Locality *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtPropLocLocality" class="form-control" onkeypress="return Names(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">District *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList runat="server" ID="ddlPropLocDist" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPropLocDist_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Taluka *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList runat="server" ID="ddlPropLocTaluka" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPropLocTaluka_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Village *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList runat="server" ID="ddlPropLocVillage" class="form-control">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Pin Code *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtPropLocPincode" class="form-control" onkeypress="return validatePincode(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900; font-size: 20px;">Project Details</span></label>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Date of Commencement of Production /Operation*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox type="text" runat="server" ID="txtDCPorOperation" class="date form-control" />
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-5 col-form-label">Nature of Activity*</label>
                                                                <div class="col-lg-7 d-flex">
                                                                    <asp:RadioButtonList ID="rblNatureofActvty" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblNatureofActvty_SelectedIndexChanged">
                                                                        <asp:ListItem Text="Manufacturing" Value="Manufacturing" style="padding-right: 10px"></asp:ListItem>
                                                                        <asp:ListItem Text="Service" Value="Service"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    <%-- <asp:TextBox runat="server" ID="txtNatureofActivity" class="form-control" />--%>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex" id="divManf" runat="server" visible="false">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Main Manufacturing Activity*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtMainManf" class="form-control" Visible="true" onkeypress="return Names(event)" />
                                                                    <%--<asp:TextBox runat="server" ID="txtServcActvty" class="form-control" Visible="false" ></asp:TextBox> --%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Product to be Manufactured </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtManfprodct" class="form-control" onkeypress="return Names(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label ">(If Existing) Production No.*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtProductionNo" class="form-control" onkeypress="return validateNameAndNumbers(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex" id="divManf1" runat="server" visible="false">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Main Raw Materials for the Project*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtRawmaterial" class="form-control" onkeypress="return Names(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Annual Capacity*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtAnnualCapacity" class="form-control" onkeypress="return validateNumberAndDot(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Unit of Measurement*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtMeasurementUnits" class="form-control" onkeypress="return validateNameAndNumbers(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex" id="divservc" runat="server" visible="false">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Main Service Activity*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtServcActvty" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Service to be Provided </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtServctobeprovded" class="form-control" onkeypress="return validateNameAndNumbers(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label ">(If Existing) Service No.*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtSrviceno" class="form-control" onkeypress="return validateNameAndNumbers(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Sector*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList runat="server" ID="ddlSector" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Line Of Activity*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList runat="server" ID="ddlLineOfActivity" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLineOfActivity_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Pollution Cataegory*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label runat="server" ID="lblPCBCategory" Text="Category" class="form-control" Enabled="false" Font-Bold="true" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Details of Waste / Effluent to be generated*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtWasteDetails" class="form-control" onkeypress="return Names(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Details of Hazardous Waste to be generated*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtHazWasteDetails" class="form-control" onkeypress="return Names(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Civil Construction*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtCivilConstr" class="form-control" onkeypress="return Names(event)" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Estimated Project Cost (INR)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtEstimatedProjCost" class="form-control" onkeypress="return validateAmount(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Land Area (in Sq. m) *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtLandAreainSqft" class="form-control" onkeypress="return validateNumberAndDot(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Value of Land (INR)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtLandValue" class="form-control" onkeypress="return validateAmount(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Water required (KL/D)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtWaterReqKLD" class="form-control" onkeypress="return validateNumberAndDot(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Value of Water (INR)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtWaterValue" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Plant & Machinery (INR)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtPlantnMachineryCost" class="form-control" onkeypress="return validateAmount(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Area of Building / Shed (Sq. m)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtBuildingAreaSqm" class="form-control" onkeypress="return validateNumberAndDot(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Value of Building / Shed (INR)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtBuildingValue" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Power Required (KV)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtPowerReqKV" class="form-control" onkeypress="return validateNumberAndDot(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Value of Power (INR)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtElectricityValue" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Investment in Fixed Capital (INR)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtCapitalInvestment" class="form-control" onkeypress="return validateAmount(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Durable Fixed Assets (INR)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtFixedAssets" class="form-control" onkeypress="return validateAmount(event)" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Working Capital (INR)*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtWorkingCapital" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900; font-size: 20px;">Finance Revenue Details</span></label>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Promoter’s and Contributors (INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtPromoterEquity" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Equity Amount (INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtEquityAmount" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Term/ Working loan (INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtLoanAmount" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Unsecured Loan (INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtUnsecuredLoan" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Internal Resources (INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtInternalResources" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">State Scheme (INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtstatescheme" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Capital Subsidy (INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtCapitalSubsidy" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Benefit from UNNATI (INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtUNNATI" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Central Scheme  (INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtcentral" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="col-md-12 d-flex" id="eligible" runat="server" visible="false">
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <p style="color: red; font-family: sans-serif;">
                                                                <b>
                                                                    <label class="col-lg-12 col-form-label text-center" id="lbleligibletext" runat="server">
                                                                        Note:  Based on your input regarding Sector/Year of establishment/production, your Unit is not eligible for Incentive under MIIPP, 2024.
However, you can register your unit to get required approvals/ clearances.</label></b>
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="text-right mb-3">
                                                    <asp:Button runat="server" Text="Save as Draft" ID="btnsave1" OnClick="btnsave1_Click" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                                    <asp:Button ID="btnNext1" Text="Next" Visible="true" runat="server" class="btn btn-rounded btn-info btn-lg" OnClick="btnNext1_Click" Width="150px" />
                                                </div>
                                            </div>
                                        </div>
                                    </asp:View>
                                    <asp:View ID="viewRevenue" runat="server">
                                        <div class="tab-pane active  " id="basictab2">

                                            <div class="card-body" runat="server" id="divRevenue">
                                                <span class="icon2"><i class="fi fi-br-caret-down"></i></span>
                                                <h4 class="card-title" style="background: #67bf02; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">2. Basic Revenue Projections</h4>
                                                <%--<form action="#">--%>
                                                <div class="row">

                                                    <div class="col-md-12">
                                                        <asp:GridView ID="grdRevenueProj" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdRevenueProj_RowDataBound">
                                                            <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" HorizontalAlign="Center" />
                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />

                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMRPID" runat="server" Text='<%# Eval("MRPID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Item Description" Visible="true" ItemStyle-Width="42%" HeaderStyle-HorizontalAlign="left">
                                                                    <ItemTemplate>
                                                                        <itemstyle horizontalalign="Center" />
                                                                        <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("MRP_DESECRIPTION") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <%-- <asp:BoundField DataField="MRP_DESECRIPTION" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Item Description " ItemStyle-Width="250px">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>--%>
                                                                <asp:TemplateField HeaderText="Year 1" ItemStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtYear1" CssClass="form-control" runat="server" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Year 2" ItemStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtYear2" CssClass="form-control" runat="server" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Year 3" ItemStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtYear3" CssClass="form-control" runat="server" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Year 4" ItemStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtYear4" CssClass="form-control" runat="server" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Year 5" ItemStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtYear5" CssClass="form-control" runat="server" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="col-md-12" style="padding-top: 10px">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Upload Detailed Project Report (DPR)</label>
                                                            <div class="col-lg-4 d-flex">
                                                                <asp:FileUpload ID="fupDPR" runat="server" />
                                                                <asp:HyperLink ID="hypdpr" runat="server" Target="_blank"></asp:HyperLink>
                                                                <asp:Label ID="lbldpr" runat="server" />
                                                                <asp:Button Text="Upload DPR" runat="server" ID="btndpr" class="btn btn-rounded btn-dark mb-4" OnClick="btndpr_Click" Width="150px" />


                                                            </div>




                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex mt-2 mb-3" id="padding">
                                                        <div class="col-md-2">



                                                            <%--<button type="submit" class="btn btn-rounded btn-success btn-lg">Previous</button>--%>
                                                        </div>
                                                        <div class="col-md-10 text-right">
                                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos2" class="btn btn-rounded btn-info btn-lg" OnClick="btnPreviuos2_Click" Width="150px" />
                                                            <asp:Button ID="btnsave2" runat="server" OnClick="btnsave2_Click" Text="Save as Draft" class="btn btn-rounded btn-success btn-lg" padding-right="10px" Width="150px" />
                                                            <asp:Button ID="btnNext2" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" OnClick="btnNext2_Click" Width="150px" />

                                                        </div>
                                                    </div>
                                                </div>


                                                <%--</form>--%>
                                            </div>
                                        </div>
                                    </asp:View>
                                    <asp:View ID="viewPromoters" runat="server">
                                        <div class="tab-pane active   " id="basictab3">

                                            <div class="card-body" runat="server" id="divPromotrs">
                                                <span class="icon3"><i class="fi fi-br-caret-down"></i></span>
                                                <h4 class="card-title" style="background: #4db6ac; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">3. Details of the Applicant / Promoter(s) /
													Partner(s) / Directors(s) / Members</h4>

                                                <div class="row">
                                                    <div class="col-md-12 d-flex" id="padding">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">First Name *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtApplFrstName" class="form-control" onkeypress="return Names(this)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Last Name *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtApplLstName" class="form-control" onkeypress="return Names(this)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">AADHAR No. *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtApplAadhar" class="form-control" onkeypress="return validateAadhar(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">PAN *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtApplPAN" class="form-control" onblur="fnValidatePAN(this);" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">DIN No. (if available) </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtApplDIN" class="form-control" onkeypress="return validateNumbersOnly(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Nationality *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlApplNationality" runat="server" class="form-control">
                                                                         <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Indian" Value="Indian"></asp:ListItem>
                                                                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>

                                                                    </asp:DropDownList>
                                                                    <%--<asp:TextBox runat="server" ID="txtApplNationality" class="form-control" />--%>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Door No. *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtApplDoorNo" class="form-control" onkeypress="return validateNameAndNumbers(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Street *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtApplStreet" class="form-control" onkeypress="return Names(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">E-mail ID *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtApplEmail" class="form-control" onblur="validateEmail(event)" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex" runat="server">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Pin Code *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtApplPincode" class="form-control" onkeypress="return validatePincode(event)" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Country *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList runat="server" ID="ddlApplCountry" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlApplCountry_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">State *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList runat="server" ID="ddlApplState" class="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlApplState_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox runat="server" ID="txtApplState" class="form-control" Visible="false"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex" runat="server" id="traddredddropdowns">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">District *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList runat="server" ID="ddlApplDist" class="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlApplDist_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Taluka *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList runat="server" ID="ddlApplTaluka" class="form-control" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlApplTaluka_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>


                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">City / Town / Village *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList runat="server" ID="ddlApplVillage" class="form-control" Enabled="false">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>



                                                    <div class="col-md-12 d-flex" runat="server" id="trothercountry" visible="false">

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">District *</label>
                                                                <div class="col-lg-6 d-flex">

                                                                    <asp:TextBox runat="server" ID="txtApplDist" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Taluka *</label>
                                                                <div class="col-lg-6 d-flex">

                                                                    <asp:TextBox runat="server" ID="txtApplTaluka" class="form-control"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">City / Town / Village *</label>
                                                                <div class="col-lg-6 d-flex">

                                                                    <asp:TextBox runat="server" ID="txtApplVillage" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Phone *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtApplMobile" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10" />
                                                                </div>
                                                            </div>

                                                            <%--<button type="button" class="btn btn-successgreen btn-sm mb-3 float-right"><i class="fa fa-plus-square" aria-hidden="true"></i>&nbsp;&nbsp;&nbsp; Add New</button>--%>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label"></label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Button ID="btnAddPromtr" Text="Add Details" class="btn btn-rounded btn-green" runat="server" OnClick="btnAddPromtr_Click" Width="110px" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-10 d-flex">
                                                        <asp:GridView ID="gvPromoters" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                            GridLines="None" OnRowDeleting="gvPromoters_RowDeleting"
                                                            Width="100%" EnableModelValidation="True" Visible="false">
                                                            <RowStyle BackColor="#ffffff" />
                                                            <Columns>

                                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="DIRECTOR_NO" DataField="IDD_DIRECTOR_NO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" Visible="false" />
                                                                <asp:BoundField HeaderText="UNITID" DataField="IDD_UNITID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" Visible="false" />
                                                                <asp:BoundField HeaderText="INVESTERID" DataField="IDD_INVESTERID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" Visible="false" />
                                                                <asp:BoundField HeaderText="First Name" DataField="IDD_FIRSTNAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="Last Name" DataField="IDD_LASTNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="Aadhar No." DataField="IDD_ADNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="PAN No." DataField="IDD_PAN" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="DIN No." DataField="IDD_DINNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="Nationality" DataField="IDD_NATIONALITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                                <asp:BoundField HeaderText="Door No." DataField="IDD_DOORNO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="Street" DataField="IDD_STREET" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="Country" DataField="IDD_COUNTRYName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="State" DataField="IDD_STATEName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="District" DataField="IDD_DISTRICTName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="Mandal" DataField="IDD_MANDALName" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="Village" DataField="IDD_CITYName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                                <asp:BoundField HeaderText="Pincode" DataField="IDD_PINCODE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="E-mail" DataField="IDD_EMAIL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="Mobile" DataField="IDD_PHONE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>

                                                    <div class="col-md-12 d-flex mt-2 mb-3" id="padding">
                                                        <div class="col-md-2">



                                                            <%--<button type="submit" class="btn btn-rounded btn-success btn-lg">Previous</button>--%>
                                                        </div>
                                                        <div class="col-md-10 text-right">
                                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos3" class="btn btn-rounded btn-info btn-lg" OnClick="btnPreviuos3_Click" Width="150px" />
                                                            <asp:Button Text="Preview" runat="server" ID="btnPreview" class="btn btn-rounded btn-update btn-lg" Enabled="false" OnClick="btnPreview_Click" Width="150px" />
                                                            <asp:Button ID="btnSave3" Text="Submit" runat="server" class="btn btn-rounded btn-submit btn-lg" OnClick="btnSave3_Click" BackColor="Green" Width="150px" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </asp:View>

                                </asp:MultiView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--</section>--%>
        </div>
    </div>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>

    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>

    <script type="text/javascript">
        function validateNames(input) {
            var name = input.value;
            var charCode = event.charCode || event.keyCode;


            if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122)) {
                return true;
            } else {
                alert("Enter only alphabets (A-Z, a-z)");
                input.value = "";
                return false;
            }
        }
    </script>

    <script type="text/javascript">
        function checkLength(el) {
            if (el.value.length != 10) {
                alert("Mobile number length must be exactly 10 characters")
            }
        }
    </script>



    <script type="text/javascript">
        function validateEmail(event) {
            var email = event.target.value;
            var isValidEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);

            if (!isValidEmail) {
                event.target.value = "";
                alert("Enter a valid email address");
            }
        }

    </script>


    <script type="text/javascript">
        function validateNumberOnly(input) {
            var inputValue = input.value.trim();
            var regex = /^[0-9]+$/;

            if (!regex.test(inputValue)) {
                alert("Enter numeric values only");
                input.value = "";
                input.focus();
            }
        }

        function NumberOnly(event) {
            var input = event.target;
            validateNumberOnly(input);
        }
    </script>
    <script type="text/javascript">
        function checkLength1(el) {
            if (el.value.length !== 12) {
                alert("Aadhar number length must be exactly 12 characters");
                el.value = "";
                el.focus();
            }
        }

        function validateAadharOnBlur(event) {
            var input = event.target;
            checkLength1(input);
        }
    </script>
    <script type="text/javascript">
        function ValidatePAN() {
            var Obj = document.getElementById("txtApplPAN");
            if (Obj.value != "") {
                ObjVal = Obj.value;
                var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
                if (ObjVal.search(panPat) == -1) {
                    alert("Invalid Pan No");
                    Obj.focus();
                    return false;
                }
            }
        }
    </script>


    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.js"> </script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/js/bootstrap-datepicker.js"> </script>
    <script>

        $(".date").datepicker({
            format: "dd-mm-yyyy",
        });

        $('.date').datepicker('setDate', new Date());

    </script>--%>
</asp:Content>
