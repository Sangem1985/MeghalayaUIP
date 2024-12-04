<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENIndustryDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENIndustryDetails" %>

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

                    <li class="breadcrumb-item active" aria-current="page">Renewal Application Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" runat="server" id="divText">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Renewal Application Details:</h4>
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
                                            <h4 class="card-title ml-3">Unit Details: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        1. Name of Unit</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtUnitName" runat="server" class="form-control" onkeypress="return Names()" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        2.Company Type</label>
                                                    <div class="col-lg-6">
                                                        <asp:DropDownList ID="ddlCompanyType" runat="server" class="form-control">
                                                            <asp:ListItem Text="Select CompanyType" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        3.Nature of Industry</label>
                                                    <div class="col-lg-6">
                                                        <asp:DropDownList ID="ddlSectorEnter" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select-- " Value="0" />
                                                            <asp:ListItem Text="Manufacturing" Value="Manufacturing"></asp:ListItem>
                                                            <asp:ListItem Text="Service" Value="Service"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        4. Category of
												Registration*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlRegType" runat="server" class="form-control" OnSelectedIndexChanged="ddlRegType_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="Select Category" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label" id="lblregntype" runat="server">5.Registration number *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRegNo" runat="server" class="form-control" Type="text" Enabled="false" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">6.Registration Date *</label>
                                                    <div class="col-lg-6">
                                                        <%-- <asp:TextBox ID="txtRegDate" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtRegDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" onkeyup="handleKeyUp(this)" />
                                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtRegDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">7.Sector</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlsector" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlsector_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        8.Line of Activity*
                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlLineActivity" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLineActivity_SelectedIndexChanged">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        9.Pollution Category of Enterprise*
                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:Label ID="lblPCBCategory" Font-Bold="true" runat="server" class="form-control"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        10. Survey/Door</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtDoors" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">11.Locality *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLocality" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12.Nearest Landmark</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLANDMARK" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        13.District
                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select District" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">14. Mandal</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">15. Village</label>
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
                                                    <label class="col-lg-6 col-form-label">16.E-Mail ID*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEmailId" runat="server" class="form-control" Type="text" onblur="validateEmail(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">17.Mobile Number *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">18.Pincode *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtpincode" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        19. Total
																		Extent of Land<br />
                                                        (in Sq.m)</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLandArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        20. Built up
																		Area (In Sq.m)</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtBuiltArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">Authorised Representative Details: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" Type="text" onkeypress="return Names(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        2.
														S/o.D/o.W/o</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtSoWoDo" runat="server" class="form-control" onkeypress="return validateNames(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3.E-Mail ID*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" Type="text" onblur="validateEmail(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.Mobile Number *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtphoneno" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        5. Alternative Mobile
														No*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAltMobile" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        6. Landline Tel No
                                               
                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLandlineno" runat="server" class="form-control" onblur="validatePhoneNumber(input_str)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">7.DoorNo*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDoorNo" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">8.Locality *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLocal" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        9.State
                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlstate" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select State" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex" id="otherDistric" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        10.District
                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddldist" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddldist_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select District" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">11.Mandal</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlmand" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlmand_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12. Village</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlvilla" runat="server" class="form-control">
                                                            <asp:ListItem Text="Select Village" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex" runat="server" id="trotherstate" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">10.District *</label>
                                                    <div class="col-lg-6 d-flex">

                                                        <asp:TextBox runat="server" ID="txtApplDist" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">11.Mandal *</label>
                                                    <div class="col-lg-6 d-flex">

                                                        <asp:TextBox runat="server" ID="txtApplTaluka" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12.Village *</label>
                                                    <div class="col-lg-6 d-flex">

                                                        <asp:TextBox runat="server" ID="txtApplVillage" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">13.Pincode *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPin" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">14.Age *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAge" runat="server" class="form-control" Type="text" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">15.Designation *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDesignation" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12  d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        16. Women
														Entrepreneur</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:RadioButtonList ID="rblWomen" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        17. Differently
														Abled*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:RadioButtonList ID="rblAbled" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h4 class="card-title ml-3">Employment Details: </h4>
                                        <%-- <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6">(Total Employee-Direct:</label>
                                                    <div>
                                                        <asp:Label ID="lbltotalEmp" runat="server" value="40" CssClass="font-weight-600"> </asp:Label>)
                                                    </div>
                                                </div>
                                            </div>--%>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Direct Male</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtMale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2.Direct Female</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtFemale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Direct Other Employee</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtDirectOthers" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4. Indirect Male</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtIndirectMale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">5. Indirect Female</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtIndirectFemale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">6. Indirect Other Employee</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtInDirectOthers" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">7. Total Employment</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtPropEmp" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">Project Financials: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <%--  <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                1. Proposed
																		Employment</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtPropEmp" runat="server" class="form-control" AutoPostBack="true" OnTextChanged="txtPropEmp_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>--%>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Value of Land as per saleDeed(In INR)</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLandValue" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" AutoPostBack="true" OnTextChanged="txtLandValue_TextChanged" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Value of Building(In INR)</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtBuildingValue" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" AutoPostBack="true" OnTextChanged="txtBuildingValue_TextChanged" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Value of Plant & Machinery(In INR)</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtPMCost" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" AutoPostBack="true" OnTextChanged="txtPMCost_TextChanged" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4. Total Project Cost(in Crores)</label>
                                                    <div class="col-lg-6">
                                                        <asp:Label ID="lblTotProjCost" Text="0.00" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">5. Expected Annual Turnover(In INR)</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtAnnualTurnOver" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" AutoPostBack="true" OnTextChanged="txtAnnualTurnOver_TextChanged" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        6. Enterprise Category
                                                    </label>

                                                    <div class="col-lg-6">
                                                        <h5>
                                                            <asp:Label ID="lblEntCategory" Text="Category" runat="server"></asp:Label></h5>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex mt-2">

                                            <div class="col-md-6">&nbsp;</div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 text-right mt-2 mb-2">

                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                        <asp:Button ID="btnNext" Text="Next" OnClick="btnNext_Click" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
