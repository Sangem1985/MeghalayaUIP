<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="IncentiveRegistration.aspx.cs" Inherits="MeghalayaUIP.User.INCENTIVE.IncentiveRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
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
                    <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Incentive</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Incentive Registration Details</li>
                </ol>
            </nav>
            <div class="page-wrapper tabs">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Incentive Registration Details:</h4>
                                </div>
                                <div class="card-body">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:HiddenField ID="hdnResultTab2" runat="server" />
                                    <asp:HiddenField ID="hdnResultTab3" runat="server" />

                                    <ul class="nav nav-tabs">
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link1" class="nav-link active" runat="server" OnClick="Link1_Click" Style="padding-right: 20px; font-size: 18px; margin-top: -8px !important; padding: 10px 10px 12px !important;"> 
                                    &nbsp;&nbsp;&nbsp;&nbsp;1. Incentive Basic Details&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></li>
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link2" class="nav-link" runat="server" OnClick="Link2_Click" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;2. Fixed Capital Investment&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></li>
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link3" class="nav-link" runat="server" OnClick="Link3_Click" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                    3. Power</asp:LinkButton></li>

                                    </ul>
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
                                        <asp:MultiView ID="MVprereg" runat="server" OnActiveViewChanged="MVprereg_ActiveViewChanged">
                                            <asp:View ID="viewBasic" runat="server">
                                                <div class="tab-pane active" id="basictab1">
                                                    <div class="card-body" runat="server" id="divbasic">
                                                        <span class="icon"><i class="fi fi-br-caret-down"></i></span>
                                                    </div>
                                                    <h4 class="card-title ml-3">1(a)Factory/Unit Address: </h4>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    1.(b) Name of Unit</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtUnitName" runat="server" class="form-control" onkeypress="return Names()" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Area/Locality *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtLocality" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="lblregntype" runat="server">C&RD Block *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtBlock" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    District
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select District" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mandal</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlMandal" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Mandal" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Village</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Village" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Post Office</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtPost" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox11" runat="server" class="form-control" Type="text" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Landline/Mobile NO *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Pincode *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtpincode" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <h4 class="card-title ml-3">(C) Office Address: </h4>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Area/Locality</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtArea" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label2" runat="server">C&RD Block *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtCDBlock" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label3" runat="server">Post Office *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    District
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select District" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mandal</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Mandal" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Village</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="DropDownList3" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Village" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtEmailId" runat="server" class="form-control" Type="text" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label4" runat="server">Landline/Mobile NO *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Pincode *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <h4 class="card-title ml-3">(d) Registered Office's Address </h4>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Area/Locality</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox5" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label5" runat="server">C&RD Block *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox6" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label6" runat="server">Post Office *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox7" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    District
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="DropDownList4" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select District" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mandal</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="DropDownList5" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Mandal" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Village</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="DropDownList6" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Village" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox9" runat="server" class="form-control" Type="text" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label7" runat="server">Landline/Mobile NO *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox8" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Pincode *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox10" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 d-flex">
                                                        <h4 class="card-title ml-3">2.Constitution of the unit: </h4>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">(a).proprietorial/Partnership/ Private limited/Limited Company/Cooperative society/LLP *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtLLP" runat="server" class="form-control" Type="text" onkeypress="return Names(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    (b) Name(s), address(es) of the proprietor/Partners/ Directors/secretary and president of the Cooperative Society</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtDirectors" runat="server" class="form-control" onkeypress="return validateNames(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <h4 class="card-title ml-3">3.Whether new unit or existing unit undergoing expansion: </h4>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <%--<div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label8" runat="server">
                                                                    
 *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtEXUnit" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>--%>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">(a) In case of New unit	*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox13" runat="server" class="form-control" Type="text" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label9" runat="server">Date of commencement of commercial production/operation *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtCompnyRegDt" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtCompnyRegDt"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label10" runat="server">
                                                                    (b) In case of existing unit undergoing expansion *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtUndergoing" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Date of commencing commercial production/operation after expansion	*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtProduction" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtProduction"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label11" runat="server">Date of commencing commercial production/operation before expansion *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtcommercial" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtcommercial"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <h4 class="card-title ml-3">4. Items of production & installed capacity: </h4>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">1.Prior to expansion/diversification</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtMale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">2.After expansion/diversification</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtFemale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">3. Prior to expansion/diversification</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtDirectOthers" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">4. After expansion/diversification</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtIndirectMale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 text-center">
                                                            <asp:Button ID="btnAddLOM" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex justify-content-center">
                                                        <asp:GridView ID="gvTeamMembers" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                            GridLines="None"
                                                            Width="100%" EnableModelValidation="True" Visible="false">
                                                            <RowStyle BackColor="#ffffff" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Prior to expansion/diversification" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="After expansion/diversification" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Prior to expansion/diversification" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="After expansion/diversification" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <h4 class="card-title ml-3">5.Details Of Registration: </h4>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <%--<div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">5. Details of registration</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtDetReg" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>--%>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">(a) In case of New unit</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtUnitNew" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">(i) EM Part II No. & date	</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtEMPart" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEMPart"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">(ii) IEM No. & date</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtIEMDate" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="txtIEMDate"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">b. In case of existing unit undergoing expansion</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtCaseunder" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    (i) Permanent (PMT) Registration/IEM/EM Part II No & date
                                                                </label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtIEM" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="txtIEM"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex mt-2">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">6.	Eligibility Certificate No. & date </label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtEligibility" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEligibility"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 text-right mt-2 mb-2">

                                                        <%-- <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />--%>
                                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                                    </div>
                                                </div>
                                            </asp:View>
                                            <asp:View ID="viewRevenue" runat="server">
                                                <div class="tab-pane active " id="basictab2">
                                                    <div class="card-body" runat="server" id="divRevenue">
                                                        <span class="icon2"><i class="fi fi-br-caret-down"></i></span>
                                                        <h4 class="card-title" style="background: #67bf02; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">2. Fixed Capital Investment</h4>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <asp:GridView ID="grdRevenueProj" runat="server" AutoGenerateColumns="false">
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
                                                                        <asp:TemplateField HeaderText="Particulars" Visible="true" ItemStyle-Width="45%" HeaderStyle-HorizontalAlign="left">
                                                                            <ItemTemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("MRP_DESECRIPTION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- <asp:BoundField DataField="MRP_DESECRIPTION" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Item Description " ItemStyle-Width="250px">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>--%>
                                                                        <asp:TemplateField HeaderText="For new unit (in  )" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear1" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="PriorExpansion (in  )" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear2" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="DuringExpansion(in  )" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear3" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total after expansion(in  )" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear4" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total" Visible="true" ItemStyle-Width="45%" HeaderStyle-HorizontalAlign="left">
                                                                            <ItemTemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("MRP_DESECRIPTION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>

                                                            <div class="col-md-12">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
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
                                                                        <asp:TemplateField HeaderText="Source of finance" Visible="true" ItemStyle-Width="45%" HeaderStyle-HorizontalAlign="left">
                                                                            <ItemTemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("MRP_DESECRIPTION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- <asp:BoundField DataField="MRP_DESECRIPTION" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Item Description " ItemStyle-Width="250px">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>--%>
                                                                        <asp:TemplateField HeaderText="(in  )" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear1" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total" Visible="true" ItemStyle-Width="45%" HeaderStyle-HorizontalAlign="left">
                                                                            <ItemTemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("MRP_DESECRIPTION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>

                                                            <h4 class="card-title ml-3">8(b). Details of Term/Working Loan (if any) : </h4>

                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">1.Name of Bank/ Financial Institution & address</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox12" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">2.Amount of term/ working capital loan sanctioned (in  )</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox14" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">3. Sanction letter No. & date</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox15" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">4. Amount of term/ working capital Loan disbursed (in   )</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox16" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4 text-center">
                                                                    <asp:Button ID="btnbuttons" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex justify-content-center">
                                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                    GridLines="None"
                                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                                    <RowStyle BackColor="#ffffff" />
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Name of Bank/ Financial Institution & address" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Amount of term/ working capital loan sanctioned (in  )" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Sanction letter No. & date" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Amount of term/ working capital Loan disbursed (in   )" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </div>

                                                            <h4 class="card-title ml-3">8(c). Details of equity (if any)  : </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">1.Name</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox17" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">2.Amount (in  )</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox18" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">3. PAN No.</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox19" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">4. Mode of payment</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox20" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4 text-center">
                                                                    <asp:Button ID="Button1" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex justify-content-center">
                                                                <asp:GridView ID="GVequity" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                    GridLines="None"
                                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                                    <RowStyle BackColor="#ffffff" />
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Name" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Amount (in  )" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="PAN No." DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Mode of payment" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </div>

                                                            <h4 class="card-title ml-3">8(d). Details of unsecured loan (if any) : </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">1.Name</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox21" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">2.Amount (in  )</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox22" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">3. PAN No.</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox23" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">4. Mode of payment</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox24" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4 text-center">
                                                                    <asp:Button ID="Button2" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex justify-content-center">
                                                                <asp:GridView ID="GVloan" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                    GridLines="None"
                                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                                    <RowStyle BackColor="#ffffff" />
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Name" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Amount (in  )" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="PAN No." DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Mode of payment" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 text-right mt-2 mb-2">

                                                        <%-- <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />--%>
                                                        <asp:Button ID="Button3" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                                        <asp:Button ID="Button4" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                                    </div>
                                                </div>
                                            </asp:View>
                                            <asp:View ID="viewPromoters" runat="server">
                                                <div class="tab-pane active   " id="basictab3">
                                                    <div class="card-body" runat="server" id="divPromotrs">
                                                        <span class="icon3"><i class="fi fi-br-caret-down"></i></span>
                                                        <h4 class="card-title" style="background: #4db6ac; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">9. Power</h4>
                                                        <div class="row">
                                                            <%--   <h4 class="card-title ml-3">9.Power: </h4>--%>

                                                            <div class="col-md-12 d-flex">
                                                                <%--  <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Power</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox25" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>--%>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(A).In case of new units</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox26" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(i). Sanctioned load </label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox27" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(ii).Connected Load</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox28" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">

                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(iii).Capacity of captive power plant (if any)	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox29" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <h4 class="card-title ml-3">B.	In case of existing units undergoing expansion: </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(i).Sanctioned load prior to expansion</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox30" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(ii).Connected load prior to expansion	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox31" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(iii).Sanction of additional load for expansion	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox32" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(iv).Additional connected load for expansion</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox33" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(v).Capacity of captive power plants (if any)	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox34" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <h4 class="card-title ml-3">Details of land and building: </h4>
                                                            <h4 class="card-title ml-3">A Land & (a)Own land </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(i)	Land area, Revenue village, Dag No.& patta No.</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox35" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(ii).Date of purchase	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox36" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(iii).Date of registration	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox37" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <h4 class="card-title ml-3">(b)	Land allotted by Government/ Government	Agency	 </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(i)	Date of allotment/agreement</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox38" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(ii).Date of taking over possession		</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox39" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <h4 class="card-title ml-3">(c)	Lease holds land	 </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(i)	Date of lease of land</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox40" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(ii).Period of lease		</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox41" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <h4 class="card-title ml-3">B	Building 	 </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(a)	Own building/rented building</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox42" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">In case of own building, built up area		</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox43" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <h4 class="card-title ml-3">10.	Employment generation 	 </h4>
                                                            <div class="col-md-12">
                                                                <asp:GridView ID="GVGeneration" runat="server" AutoGenerateColumns="false">
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
                                                                        <%-- <asp:TemplateField HeaderText="ID" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMRPID" runat="server" Text='<%# Eval("MRPID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Category" Visible="true" ItemStyle-Width="45%" HeaderStyle-HorizontalAlign="left">
                                                                            <ItemTemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("MRP_DESECRIPTION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Few new unit" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear1" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Before expansion/diversification" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear2" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="During  expansion/diversification" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear3" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear4" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>

                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Total employment</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox44" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Total Nos. of local tribals 		</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox45" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Percentage of local tribals 		</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox46" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 text-right mt-2 mb-2">

                                                                <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                                                <asp:Button ID="Button5" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                                                <asp:Button ID="Button6" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
