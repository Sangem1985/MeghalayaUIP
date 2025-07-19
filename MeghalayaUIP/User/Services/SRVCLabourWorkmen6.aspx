<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCLabourWorkmen6.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCLabourWorkmen6" %>

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
                    <li class="breadcrumb-item"><a href="SRVCUserDashboard.aspx">Other Services</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Contractor Migrant Work</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Contractor Migrant Work Deatils</h4>
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
                                        <p class="fw-bold ml-3">Contractor's Birth Details</p>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of Birth or age<span style="color: red">*</span></label>

                                                    <div class="col-lg-6 d-flex">
                                                        <asp:RadioButtonList ID="rblDateofBirth" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblDateofBirth_SelectedIndexChanged">
                                                            <asp:ListItem Text="DOB" Value="D" />
                                                            <asp:ListItem Text="Age" Value="A" />
                                                        </asp:RadioButtonList>
                                                    </div>

                                                </div>
                                            </div>

                                            <div class="col-md-4" id="DateBirth" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date<span style="color: red">*</span></label>
                                                    <div class="col-lg-6">

                                                        <asp:TextBox runat="server" ID="txtDateBirth" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateBirth"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="Age" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Age<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAges" runat="server" class="form-control" Type="text" onkeypress="return NumberOnly()" MaxLength="2"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <p class="fw-bold ml-3">Place of Birth:</p>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        State<span style="color: red">*</span>

                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlSates" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSates_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select State" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="divdistrict1" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        District<span style="color: red">*</span>

                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDistric" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistric_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select District" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="divMandal1" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12" id="divdistrict" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">District <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtDistricted" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="50" onkeyup="handleKeyUp(this)" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12" id="divMandal" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtMandaled" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="50" onkeyup="handleKeyUp(this)" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4" id="divVillage1" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                            <asp:ListItem Text="Select Village" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12" id="divVillage" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtVillagede" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="50" onkeyup="handleKeyUp(this)" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Locality<span style="color: red">*</span> </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLocal" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nearest Landmark<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNearMark" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Pincode<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPin" runat="server" class="form-control" TabIndex="1" MaxLength="6" onkeypress="return NumberOnly()"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <p class="fw-bold ml-3">Other Details Of The Contractor</p>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-7 col-form-label">Whether the applicant is a citizen of India: within the meaning of Article 5 of the Constitution of India.<span style="color: red">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:RadioButtonList ID="rblArtical5" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-7 col-form-label">Whether any Criminal Case is pending at the time of making application<span style="color: red">*</span></label>

                                                <div class="col-lg-3 d-flex">
                                                    <asp:RadioButtonList ID="rblMakeApplicationCrime" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>

                                                </div>


                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-7 col-form-label">Whether convicted in connection with a Criminal-Case at any time during the period of five years immediately preceding the date of application<span style="color: red">*</span></label>

                                                <div class="col-lg-3 d-flex">
                                                    <asp:RadioButtonList ID="rblCriminalCase" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-7 col-form-label">Whether the applicant holds a trading/business license granted by District Council <span style="color: red">*</span></label>

                                                <div class="col-lg-3 d-flex">
                                                    <asp:RadioButtonList ID="rblDistricCouncil" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblDistricCouncil_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="Licdetails" runat="server" visible="false">
                                        <p class="fw-bold ml-3">Name of District Council granting</p>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">license <span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlLic" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="GHADC" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="JHADC" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="KHADC" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License No<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLicNo" runat="server" class="form-control" Type="text" onkeypress="return NumberOnly()"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of the License<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%--  <asp:TextBox ID="txtDateLic" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtDateLic" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateLic"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4" id="Validdate" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Valid till date <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <%-- <asp:TextBox ID="txtValidDate" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>

                                                    <asp:TextBox runat="server" ID="txtValidDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="txtValidDate"></cc1:CalendarExtender>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12" id="Tribal" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-7 col-form-label">Tribal <span style="color: red">*</span></label>
                                                <div class="col-lg-2 d-flex">
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:RadioButtonList ID="rblTribal" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4" id="Reasons" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Reasons <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtReasons" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" MaxLength="250" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <p class="fw-bold ml-3">Particulars of establishment where migrant workmen-are to be employed</p>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of the establishment<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNameofEstablish" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-9 col-form-label">Type of business, trade, industry, manufacture or occupation, which is carried on in the establishment <span style="color: red">*</span></label>
                                                <div class="col-lg-3 d-flex">
                                                    <asp:TextBox ID="txtbusiness" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Registration Number of the establishment under the Act<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtRegNoEst" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Date of certificate of registration <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <%--   <asp:TextBox ID="txtDateRegCert" runat="server" class="date form-control" Type="text"></asp:TextBox>
                     <i class="fi fi-rr-calendar-lines"></i>--%>

                                                    <asp:TextBox runat="server" ID="txtDateRegCert" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateRegCert"></cc1:CalendarExtender>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <p class="fw-bold ml-3">Address of the establishment</p>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    District<span style="color: red">*</span>

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
                                                <label class="col-lg-6 col-form-label">Mandal<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlmand" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlmand_SelectedIndexChanged">
                                                        <asp:ListItem Text="Select Mandal" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Village<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlvilla" runat="server" class="form-control">
                                                        <asp:ListItem Text="Select Village" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Locality<span style="color: red">*</span> </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtLocality" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nearest Landmark<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtLandmark" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Pincode<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtPincode" runat="server" class="form-control" Type="text" TabIndex="1" MaxLength="6" onkeypress="return NumberOnly()"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <p class="fw-bold ml-3">Principal Employer Details</p>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Title<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList runat="server" ID="ddlTitles" class="form-control">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Shri" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Smt" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Kumari" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Dr" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of the Principal Employer <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNameEmp" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <p class="fw-bold ml-3">Particulars of migrant workmen</p>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name, Location and Nature of work in which migrant workmen are employed or are to be employed in the establishment<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNameMigrantEmp" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Duration of the proposed contract work in day(Min 1 and Max 179)<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtContractorMin" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Commencing Date <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox runat="server" ID="txtCommencingDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                    <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MM-yyyy" TargetControlID="txtCommencingDate"></cc1:CalendarExtender>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Ending Date <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <%-- <asp:TextBox ID="txtEnding" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>


                                                    <asp:TextBox runat="server" ID="txtEnding" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                    <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEnding"></cc1:CalendarExtender>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of the agent or manager of the contractor at the work site <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtSiteManager" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Maximum number of migrant workmen proposed to be employed in the establishment on any date <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtMaxEstEmp" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Directors/Partners</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Title  <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList runat="server" ID="ddlTitle" class="form-control">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Shri" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Smt" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Kumari" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Dr" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtName" runat="server" class="form-control" Type="text" onkeypress="return Names(this)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Address<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtAddress" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4 offset-md-5 text-center">
                                            <div class="form-group row">
                                                <div class="col-lg-12 d-flex">
                                                    <asp:Button ID="btnMigrant" runat="server" Text="Add More" OnClick="btnMigrant_Click" CssClass="btn btn-green btn-rounded" Width="110px" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex justify-content-center">
                                        <asp:GridView ID="GVMigrant" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                            GridLines="None" OnRowDeleting="GVMigrant_RowDeleting"
                                            Width="100%" EnableModelValidation="True" Visible="false">
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Title" DataField="Title" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Name" DataField="Name" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Address" DataField="Address" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                            </Columns>
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>

                                    <p class="fw-bold ml-3">Person(s) in-charge of and responsible to the company / firm</p>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Title  <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList runat="server" ID="DropDownList1" class="form-control">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Shri" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Smt" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Kumari" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Dr" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" Type="text" onkeypress="return Names(this)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Address<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4 offset-md-5 text-center">
                                            <div class="form-group row">
                                                <div class="col-lg-12 d-flex">
                                                    <asp:Button ID="Button1" runat="server" Text="Add More" CssClass="btn btn-green btn-rounded" Width="110px" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex justify-content-center">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                            GridLines="None"
                                            Width="100%" EnableModelValidation="True" Visible="false">
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Title" DataField="RENMW_TITLE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Name" DataField="RENMW_NAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Address" DataField="RENMW_ADDRESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                            </Columns>
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>

                                    <p class="fw-bold ml-3">State and District from where the migrant workmen were recruited</p>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    State<span style="color: red">*</span>

                                                </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlStates" runat="server" class="form-control" AutoPostBack="true">
                                                        <asp:ListItem Text="Select State" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">District<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlDistrictes" runat="server" class="form-control" AutoPostBack="true">
                                                        <asp:ListItem Text="Select District" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name and address of the Agent through whom the migrant workmen were recruited<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtMigrantWorkmen" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-9 col-form-label">Whether the contractor was convicted of any offence within the proceeding five years<span style="color: red">*</span></label>
                                                <div class="col-lg-3 d-flex">
                                                    <asp:RadioButtonList ID="rblContractor" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblContractor_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mt-2" id="Details" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Details <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtDetail" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" MaxLength="200"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-9 col-form-label">Whether there was any order against the contractor revoking or suspending license or forfeiting security deposit in respect of an earlier contract <span style="color: red">*</span></label>
                                                <div class="col-lg-3 d-flex">
                                                    <asp:RadioButtonList ID="rblLicSuspending" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLicSuspending_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex" id="divOrder" runat="server" visible="false">
                                        <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Order No <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtOrderNo" class="form-control" runat="server" onkeypress="return NumberOnly()" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Order Date <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">

                                                    <asp:TextBox runat="server" ID="txtOrderDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                    <cc1:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd-MM-yyyy" TargetControlID="txtOrderDate"></cc1:CalendarExtender>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-9 col-form-label">Whether the contractor has worked in any other establishment within the past five years<span style="color: red">*</span></label>
                                                <div class="col-lg-3 d-flex">
                                                    <asp:RadioButtonList ID="rblfiveyears" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblfiveyears_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-12 d-flex" id="divEstablishDetails" runat="server" visible="false">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Establishment<span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtEstablishDetails" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Principal Employer <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtEmpDetails" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nature of Work <span style="color: red">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNature" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-9 col-form-label">Whether a certificate by the principal employer is enclosed. <span style="color: red">*</span></label>
                                                <div class="col-lg-3 d-flex radio">
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:RadioButtonList ID="rblEmpClosed" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                        </asp:RadioButtonList>

                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 text-right mt-2 mb-2">

                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded  btn-info btn-lg" Width="150px" />

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
    </asp:UpdatePanel>
</asp:Content>
