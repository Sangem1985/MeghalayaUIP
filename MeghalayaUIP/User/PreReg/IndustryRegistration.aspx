<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="IndustryRegistration.aspx.cs" Inherits="MeghalayaUIP.User.PreReg.IndustryRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        span.icon, span.icon2, span.icon3 {
            top: 70px !important;
        }

        span.icon3 {
            left: 50% !important;
        }

        /*div#basictab2 input {
            border: 1px solid #fff;
        }
*/
        tr.GridviewScrollC1Item td, tr.GridviewScrollC1Item2 td {
            padding: 2px 5px 2px 10px;
        }

        td.btn.btn-rounded.btn-danger1 {
            background: red;
            color: #fff !important;
            padding: 1px 5px;
            width: 73%;
            margin: 5px 14px;
            border: 1px solid #000;
        }

            td.btn.btn-rounded.btn-danger1 a:hover, td.btn.btn-rounded.btn-danger1 a:active, td.btn.btn-rounded.btn-danger1 a:focus {
                outline: none;
                text-decoration: none;
                color: #ffffff;
            }
    </style>
    <style>
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
            padding-top: 60px;
        }

        /* Modal content */
        .modal-content {
            background-color: #fefefe;
            margin: 5% auto; /* 15% from the top and centered */
            padding: 20px;
            border: 1px solid #888;
            width: 80%; /* Could be more or less, depending on screen size */
        }

        /* Close button */
        .close {
            color: #2c2929;
            font-size: 28px;
            font-weight: bold;
            float: right;
            text-align: right;
        }

            .close:hover,
            .close:focus {
                color: black;
                text-decoration: none;
                cursor: pointer;
            }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal">
                <div class="modal-content">

                    <div class="card-header" style="background: #c7dbff; display: flex; flex-wrap: nowrap; flex-direction: row; justify-content: space-between; align-items: flex-end;">
                        <h4 class="card-title"><b>Welcome to the Industry Registration with Invest Meghalaya Authority/MIIPP 2024</b></h4>
                        <h4><span class="close">&times;</span></h4>
                    </div>
                    <p>
                        <ul>
                            <li>Please be ready with all <b>details</b> to be filled and <b>attachments to be Uploaded</b>.</li>
                            <li>By submitting this application, you agree that the information provided is accurate and complete. Any false information may result in the rejection of your application.</li>
                            <li>We reserve the right to verify the information provided in your application. Providing false or misleading information may result in disqualification.

                            </li>
                            <li>If your application is successful, you agree to comply with all relevant terms of service and policies of our organization.</li>
                        </ul>
                    </p>
                    <p><b><i class="fi fi-br-triangle-warning"></i>Disclaimer!</b> : Incomplete application and irrelevant documents will be returned to the applicant.</p>
                </div>
            </div>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item active" aria-current="page">Industry Registration</li>
                </ol>
            </nav>

            <div class="page-wrapper tabs">
                <div class="content container-fluid">
                    <%--<section class="comp-section">--%>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">

                                    <h4 class="card-title"><b>Industry Registration with Invest Meghalaya Authority/MIIPP 2024</b></h4>

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
                                    <asp:HiddenField ID="hdnResultTab2" runat="server" />
                                    <asp:HiddenField ID="hdnResultTab3" runat="server" />

                                    <ul class="nav nav-tabs">
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link1" class="nav-link active" runat="server" OnClick="Link1_Click" Style="padding-right: 20px; font-size: 18px; margin-top: -8px !important; padding: 10px 10px 12px !important;"> 
                                    &nbsp;&nbsp;&nbsp;&nbsp;1. Basic Details&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></li>
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link2" class="nav-link" runat="server" OnClick="Link2_Click" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;2. Revenue Projections&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></li>
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link3" class="nav-link" runat="server" OnClick="Link3_Click" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                    3. Details of the Applicant / Promoter(s) / Partner(s) / Directors(s) / Members</asp:LinkButton></li>
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link4" class="nav-link" runat="server" OnClick="Link4_Click" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 6px !important;"> 
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4. Enclosures&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></li>
                                    </ul>
                                    <div class="tab-content">
                                        <asp:MultiView ID="MVprereg" runat="server" OnActiveViewChanged="MVprereg_ActiveViewChanged">
                                            <asp:View ID="viewBasic" runat="server">
                                                <div class="tab-pane active" id="basictab1">
                                                    <div class="card-body" runat="server" id="divbasic">
                                                        <span class="icon"><i class="fi fi-br-caret-down"></i></span>
                                                        <h4 class="card-title" style="background: #abbd07; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">1. Basic Details</h4>

                                                        <div class="row">
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Company PAN card No <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtPANno" class="form-control" onblur="fnValidatePAN(this);" MaxLength="10" TabIndex="1" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Company Name as per PAN <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtUnitName" class="form-control" TabIndex="1" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Company Type <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList ID="ddlcompanytype" runat="server" class="form-control" TabIndex="1">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>


                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">GSTIN Number <span class="star">*</span> </label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtGSTNo" class="form-control" Onkeypress="validateCharandNumberinput();" onblur="validateGST(event)" TabIndex="1" MaxLength="15" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Company Proposal <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList ID="ddlproposal" runat="server" TabIndex="1" class="form-control">
                                                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                                                <asp:ListItem Value="New" Text="New"></asp:ListItem>
                                                                                <asp:ListItem Value="Existing" Text="Existing"></asp:ListItem>
                                                                                <asp:ListItem Value="Expansion" Text="Expansion"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">
                                                                            Category of Registration<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList ID="ddlRegType" runat="server" class="form-control" TabIndex="1" OnSelectedIndexChanged="ddlRegType_SelectedIndexChanged" AutoPostBack="true">
                                                                                <asp:ListItem Text="Select Category" Value="0" />
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                            <div class="col-md-12 d-flex">

                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label" id="lblregntype" runat="server">Registraion No <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtUdyamorIEMNo" Enabled="false" TabIndex="1" class="form-control" onkeypress="return validateNameAndNumbers(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Company Registration / Incorporation Date<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtCompnyRegDt" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtCompnyRegDt"></cc1:CalendarExtender>
                                                                            <i class="fi fi-rr-ckalendar-lines"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <div class="col-md-12 d-flex">
                                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900; font-size: 20px;">Correspondence Details of Authorised Representative</span></label>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Name <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtAuthReprName" class="form-control" onkeypress="return Names(this)" TabIndex="1" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Mobile <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtAuthReprMobile" class="form-control" TabIndex="1" onkeypress="return PhoneNumberOnly(event)" MaxLength="10" onblur="validateIndianMobileNumber(this);" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">E-mail <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtAuthReprEmail" class="form-control" onblur="validateEmail(event)" TabIndex="1" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Locality <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtAuthReprLocality" class="form-control" onkeypress="return Address(event)" TabIndex="1" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">District <span class="star">*</span></label>
                                                                        <div class="col-lg-6">
                                                                            <asp:DropDownList runat="server" ID="ddlAuthReprDist" class="form-control" AutoPostBack="true" TabIndex="1" OnSelectedIndexChanged="ddlAuthReprDist_SelectedIndexChanged">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Mandal/Taluka <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">

                                                                            <asp:DropDownList runat="server" ID="ddlAuthReprTaluka" class="form-control" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlAuthReprTaluka_SelectedIndexChanged">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Village <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">

                                                                            <asp:DropDownList runat="server" ID="ddlAuthReprVillage" class="form-control" TabIndex="1">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Door No. <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtAuthReprDoorNo" class="form-control" onkeypress="return Address(event)" TabIndex="1" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Pincode <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtAuthReprPincode" class="form-control" TabIndex="1" MaxLength="6" onkeypress="return NumberOnly()" />
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
                                                                        <label class="col-lg-4 col-form-label">Is Land Required <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:RadioButtonList runat="server" ID="rblLandType" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblLandType_SelectedIndexChanged">
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
                                                                        <label class="col-lg-6 col-form-label">Door No.</label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtPropLocDoorno" class="form-control" TabIndex="1" onkeypress="return Address(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Locality <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtPropLocLocality" class="form-control" TabIndex="1" onkeypress="return Address(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">District <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList runat="server" ID="ddlPropLocDist" class="form-control" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlPropLocDist_SelectedIndexChanged">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Taluka <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList runat="server" ID="ddlPropLocTaluka" class="form-control" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlPropLocTaluka_SelectedIndexChanged">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Village <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList runat="server" ID="ddlPropLocVillage" class="form-control" TabIndex="1">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Pin Code <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtPropLocPincode" class="form-control" TabIndex="1" MaxLength="6" onkeypress="return NumberOnly()" />
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
                                                                        <label class="col-lg-6 col-form-label">Date of Commencement of Production /Operation<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtDCPorOperation" class="form-control" TabIndex="1" onkeypress="validateNumberAndHyphen();" onblur="validateDateFormat(this)" />
                                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDCPorOperation"></cc1:CalendarExtender>
                                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-5">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-5 col-form-label">Nature of Activity<span class="star">*</span></label>
                                                                        <div class="col-lg-7 d-flex">
                                                                            <asp:RadioButtonList ID="rblNatureofActvty" runat="server" RepeatDirection="Horizontal" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="rblNatureofActvty_SelectedIndexChanged">
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
                                                                        <label class="col-lg-6 col-form-label">Main Manufacturing Activity<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtMainManf" class="form-control" TabIndex="1" Visible="true" onkeypress="return Names(event)" />
                                                                            <%--<asp:TextBox runat="server" ID="txtServcActvty" class="form-control" Visible="false" ></asp:TextBox> --%>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Main Raw Materials for the Project<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtRawmaterial" class="form-control" TabIndex="1" onkeypress="return Names(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label ">(If Existing) Production No.<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtProductionNo" class="form-control" TabIndex="1" onkeypress="return validateNameAndNumbers(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex" id="divManf1" runat="server" visible="false">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Product to be Manufactured </label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtManfprodct" class="form-control" TabIndex="1" onkeypress="return Names(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Annual Capacity of Manufacturing Product <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtAnnualCapacity" class="form-control" TabIndex="1" onkeypress="return validateNumberAndDot(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Unit of Measurement of Annual Capacity<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtMeasurementUnits" class="form-control" TabIndex="1" onkeypress="return Names(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex" id="divservc" runat="server" visible="false">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Main Service Activity<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtServcActvty" class="form-control" TabIndex="1" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Service to be Provided <span class="star">*</span> </label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtServctobeprovded" class="form-control" TabIndex="1" onkeypress="return validateNameAndNumbers(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label ">(If Existing) Service No.</label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtSrviceno" class="form-control" TabIndex="1" onkeypress="return validateNameAndNumbers(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Sector<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList runat="server" ID="ddlSector" class="form-control" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged">
                                                                                <%--<asp:ListItem Text="--Select--" Value="0"></asp:ListItem>--%>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Line Of Activity<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList runat="server" ID="ddlLineOfActivity" class="form-control" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlLineOfActivity_SelectedIndexChanged">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Pollution Category<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:Label runat="server" ID="lblPCBCategory" Text="Category" class="form-control" TabIndex="1" Enabled="false" Font-Bold="true" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="col-md-12 d-flex">

                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Details of Waste / Effluent to be generated<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtWasteDetails" class="form-control" TabIndex="1" onkeypress="return Names(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Details of Hazardous Waste to be generated<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtHazWasteDetails" class="form-control" TabIndex="1" onkeypress="return Names(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Estimated Project Cost (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtEstimatedProjCost" class="form-control" TabIndex="1" onkeypress="return validateAmount(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>


                                                            </div>

                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Plant & Machinery (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtPlantnMachineryCost" class="form-control" TabIndex="1" onkeypress="return validateAmount(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Investment in Fixed Capital (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtCapitalInvestment" class="form-control" TabIndex="1" onkeypress="return validateAmount(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Durable Fixed Assets (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtFixedAssets" class="form-control" TabIndex="1" onkeypress="return validateAmount(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Working Capital (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtWorkingCapital" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Land Area (in Sq. m) <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtLandAreainSqft" class="form-control" TabIndex="1" onkeypress="return validateNumberAndDot(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Value of Land (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtLandValue" class="form-control" TabIndex="1" onkeypress="return validateAmount(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Area of Building / Shed (Sq. m)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtBuildingAreaSqm" class="form-control" TabIndex="1" onkeypress="return validateNumberAndDot(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Value of Building / Shed (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtBuildingValue" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Civil Construction (Sqm)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtCivilConstr" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>


                                                            </div>
                                                            <div class="col-md-12 d-flex">

                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Power Required (KV)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtPowerReqKV" class="form-control" TabIndex="1" onkeypress="return validateNumberAndDot(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Value of Power (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtElectricityValue" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Water required (KL/D)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtWaterReqKLD" class="form-control" TabIndex="1" onkeypress="return validateNumberAndDot(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Value of Water (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtWaterValue" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <div class="col-md-12 d-flex">
                                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900; font-size: 20px;">Finance Details</span></label>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4" runat="server" visible="false">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Promoter’s and Contributors (INR) <span class="star">*</span> </label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtPromoterEquity" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Equity Amount (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtEquityAmount" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Term/ Working loan (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtLoanAmount" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Unsecured Loan (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtUnsecuredLoan" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">

                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Internal Resources (INR)<span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtInternalResources" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">State Scheme (INR) <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtstatescheme" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Central Scheme  (INR) <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtcentral" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4" runat="server" visible="false">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Capital Subsidy (INR) <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtCapitalSubsidy" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Benefit from UNNATI (INR) <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtUNNATI" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
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
                                                        <h4 class="card-title" style="background: #67bf02; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">2. Revenue Projections</h4>
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
                                                                                <asp:TextBox ID="txtYear1" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Year 2" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear2" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Year 3" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear3" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Year 4" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear4" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Year 5" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtYear5" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                            <br />


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
													Partner(s) / Director(s) / Members</h4>

                                                        <div class="row">
                                                            <div class="col-md-12 d-flex" id="padding">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">First Name <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtApplFrstName" class="form-control" TabIndex="1" onkeypress="return Names(this)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Last Name <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtApplLstName" class="form-control" TabIndex="1" onkeypress="return Names(this)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">AADHAR No. <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtApplAadhar" class="form-control" TabIndex="1" onkeypress="return NumberOnly()" MaxLength="12" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">

                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">PAN <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtApplPAN" class="form-control" TabIndex="1" onblur="fnValidatePAN(this);" MaxLength="10" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">DIN No. (if available) </label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtApplDIN" class="form-control" TabIndex="1" onkeypress="return validateNumbersOnly(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Nationality <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList ID="ddlApplNationality" runat="server" class="form-control" TabIndex="1">
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
                                                                        <label class="col-lg-6 col-form-label">Door No. <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtApplDoorNo" class="form-control" TabIndex="1" onkeypress="return Address(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Street <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtApplStreet" class="form-control" TabIndex="1" onkeypress="return Address(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">E-mail ID <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtApplEmail" class="form-control" TabIndex="1" onkeypress="validateEmailInput(event)" onblur="validateEmail(event)" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <div class="col-md-12 d-flex" runat="server">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Pin Code <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtApplPincode" MaxLength="6" class="form-control" TabIndex="1" onkeypress="return NumberOnly()" />
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Country <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList runat="server" ID="ddlApplCountry" class="form-control" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlApplCountry_SelectedIndexChanged">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">State <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList runat="server" ID="ddlApplState" class="form-control" TabIndex="1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlApplState_SelectedIndexChanged">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox runat="server" ID="txtApplState" class="form-control" TabIndex="1" onkeypress="return Names(event)" Visible="false"></asp:TextBox>

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex" runat="server" id="traddredddropdowns">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">District <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList runat="server" ID="ddlApplDist" class="form-control" TabIndex="1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlApplDist_SelectedIndexChanged">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>

                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Taluka <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList runat="server" ID="ddlApplTaluka" class="form-control" TabIndex="1" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlApplTaluka_SelectedIndexChanged">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>


                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">City / Town / Village <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:DropDownList runat="server" ID="ddlApplVillage" class="form-control" TabIndex="1" Enabled="false">
                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                            </asp:DropDownList>

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>



                                                            <div class="col-md-12 d-flex" runat="server" id="trothercountry" visible="false">

                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">District <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">

                                                                            <asp:TextBox runat="server" ID="txtApplDist" class="form-control" TabIndex="1" onkeypress="return Names(event)"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Taluka <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">

                                                                            <asp:TextBox runat="server" ID="txtApplTaluka" class="form-control" TabIndex="1" onkeypress="return Names(event)"></asp:TextBox>

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">City / Town / Village <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">

                                                                            <asp:TextBox runat="server" ID="txtApplVillage" class="form-control" TabIndex="1" onkeypress="return Names(event)"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Phone <span class="star">*</span></label>
                                                                        <div class="col-lg-6 d-flex">
                                                                            <asp:TextBox runat="server" ID="txtApplMobile" class="form-control" TabIndex="1" onkeypress="return PhoneNumberOnly(event)" onblur="validateIndianMobileNumber(this);" MaxLength="10" />
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

                                                            <div class="col-md-12 d-flex">
                                                                <div class="table-responsive">
                                                                    <asp:GridView ID="gvPromoters" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CssClass="GRD table-bordered table-striped table-sm" ForeColor="#333333"
                                                                        GridLines="None" OnRowDeleting="gvPromoters_RowDeleting" AlternatingRowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Wrap="true"
                                                                        Width="140%" EnableModelValidation="True" Visible="false">
                                                                        <RowStyle BackColor="#ffffff" />

                                                                        <Columns>

                                                                            <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-CssClass="btn btn-rounded btn-danger1" ItemStyle-VerticalAlign="Middle" ItemStyle-Wrap="true" ItemStyle-ForeColor="White" />
                                                                            <asp:BoundField HeaderText="DIRECTOR_NO" DataField="IDD_DIRECTOR_NO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" Visible="false" />
                                                                            <asp:BoundField HeaderText="UNITID" DataField="IDD_UNITID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" Visible="false" />
                                                                            <asp:BoundField HeaderText="INVESTERID" DataField="IDD_INVESTERID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" Visible="false" />
                                                                            <asp:BoundField HeaderText="First Name" DataField="IDD_FIRSTNAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="Last Name" DataField="IDD_LASTNAME" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="Aadhar No." DataField="IDD_ADNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="PAN No." DataField="IDD_PAN" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="DIN No." DataField="IDD_DINNO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="Nationality" DataField="IDD_NATIONALITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />

                                                                            <asp:BoundField HeaderText="Door No." DataField="IDD_DOORNO" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="Street" DataField="IDD_STREET" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="Country" DataField="IDD_COUNTRYName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="State" DataField="IDD_STATEName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="District" DataField="IDD_DISTRICTName" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="Mandal" DataField="IDD_MANDALName" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="Village" DataField="IDD_CITYName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />

                                                                            <asp:BoundField HeaderText="Pincode" DataField="IDD_PINCODE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="E-mail" DataField="IDD_EMAIL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                            <asp:BoundField HeaderText="Mobile" DataField="IDD_PHONE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />

                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />

                                                                    </asp:GridView>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex mt-2 mb-3" id="padding">
                                                                <div class="col-md-2">



                                                                    <%--<button type="submit" class="btn btn-rounded btn-success btn-lg">Previous</button>    class="btn btn-rounded btn-submit btn-lg"--%>
                                                                </div>
                                                                <div class="col-md-10 text-right">
                                                                    <asp:Button Text="Previous" runat="server" ID="btnPreviuos3" class="btn btn-rounded btn-info btn-lg" OnClick="btnPreviuos3_Click" Width="150px" />
                                                                    <asp:Button ID="btnSave3" Text="Save as Draft" runat="server" class="btn btn-rounded btn-success btn-lg" OnClick="btnSave3_Click" Width="150px" />
                                                                    <asp:Button Text="Next" runat="server" ID="btnNext3" class="btn btn-rounded btn-info btn-lg" OnClick="btnNext3_Click" Width="150px" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </asp:View>


                                            <asp:View ID="viewAttachments" runat="server">
                                                <div class="tab-pane active" id="basictab4">

                                                    <div class="card-body" runat="server" id="divenclos">
                                                        <span class="icon4"><i class="fi fi-br-caret-down"></i></span>
                                                        <h4 class="card-title" style="background: #4794e7; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">4. Enclosures</h4>

                                                        <div class="row">

                                                            <div class="col-md-12" style="padding-top: 10px">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-4 col-form-label">1. Company Registration Certificate <span class="star">*</span></label>
                                                                    <div class="col-lg-3 d-flex">
                                                                        <asp:FileUpload ID="fupcompanyregistration" runat="server" />
                                                                    </div>
                                                                    <div class="col-lg-1 d-flex">
                                                                        <asp:Button Text="Upload" runat="server" ID="btnregistration" class="btn btn-rounded btn-dark mb-4" OnClick="btnregistration_Click" />
                                                                    </div>
                                                                    <div class="col-lg-4 d-flex">
                                                                        <asp:HyperLink ID="hplcompanyregistration" runat="server" Target="_blank"></asp:HyperLink>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label class="col-lg-4 col-form-label">2. Udyam/IEM Document <span class="star">*</span></label>
                                                                    <div class="col-lg-3 d-flex">
                                                                        <asp:FileUpload ID="fupUdyam" runat="server" />
                                                                    </div>
                                                                    <div class="col-lg-1 d-flex">
                                                                        <asp:Button Text="Upload" runat="server" ID="btnUdyam" class="btn btn-rounded btn-dark mb-4" OnClick="btnUdyam_Click" />
                                                                    </div>
                                                                    <div class="col-lg-4 d-flex">
                                                                        <asp:HyperLink ID="hplUdyam" runat="server" Target="_blank"></asp:HyperLink>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label class="col-lg-4 col-form-label">3. PAN Document <span class="star">*</span></label>
                                                                    <div class="col-lg-3 d-flex">
                                                                        <asp:FileUpload ID="fupPAN" runat="server" />
                                                                    </div>
                                                                    <div class="col-lg-1 d-flex">
                                                                        <asp:Button Text="Upload" runat="server" ID="btnPAN" class="btn btn-rounded btn-dark mb-4" OnClick="btnPAN_Click" />
                                                                    </div>
                                                                    <div class="col-lg-4 d-flex">
                                                                        <asp:HyperLink ID="hplPAN" runat="server" Target="_blank"></asp:HyperLink>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label class="col-lg-4 col-form-label">4. GST Certificate <span class="star">*</span></label>
                                                                    <div class="col-lg-3 d-flex">
                                                                        <asp:FileUpload ID="fupGSTIN" runat="server" />
                                                                    </div>
                                                                    <div class="col-lg-1 d-flex">
                                                                        <asp:Button Text="Upload" runat="server" ID="btnGSTIN" class="btn btn-rounded btn-dark mb-4" OnClick="btnGSTIN_Click" />
                                                                    </div>
                                                                    <div class="col-lg-4 d-flex">
                                                                        <asp:HyperLink ID="hplGSTIN" runat="server" Target="_blank"></asp:HyperLink>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label class="col-lg-4 col-form-label">5. CIN Document <span class="star">*</span></label>
                                                                    <div class="col-lg-3 d-flex">
                                                                        <asp:FileUpload ID="fupCIN" runat="server" />
                                                                    </div>
                                                                    <div class="col-lg-1 d-flex">
                                                                        <asp:Button Text="Upload" runat="server" ID="btnCIN" class="btn btn-rounded btn-dark mb-4" OnClick="btnCIN_Click" />
                                                                    </div>
                                                                    <div class="col-lg-4 d-flex">
                                                                        <asp:HyperLink ID="hplCIN" runat="server" Target="_blank"></asp:HyperLink>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label class="col-lg-4 col-form-label">6. Upload Detailed Project Report (DPR)</label>
                                                                    <%--<div class="col-lg-8 d-flex">--%>
                                                                    <div class="col-lg-3 d-flex">
                                                                        <asp:FileUpload ID="fupDPR" runat="server" />
                                                                    </div>
                                                                    <div class="col-lg-1 d-flex">
                                                                        <asp:Button Text="Upload" runat="server" ID="btndpr" class="btn btn-rounded btn-dark mb-4" OnClick="btndpr_Click" />
                                                                    </div>
                                                                    <div class="col-lg-4 d-flex">
                                                                        <asp:HyperLink ID="hypdpr" runat="server" Target="_blank"></asp:HyperLink>
                                                                        <asp:Label ID="lbldpr" runat="server" Visible="false" />
                                                                    </div>

                                                                    <%--</div>--%>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label class="col-lg-4 col-form-label">7. Bank Appraisal Document <span class="star">*</span></label>
                                                                    <div class="col-lg-3 d-flex">
                                                                        <asp:FileUpload ID="fupBankAppraisal" runat="server" />
                                                                    </div>
                                                                    <div class="col-lg-1 d-flex">
                                                                        <asp:Button Text="Upload" runat="server" ID="btnBankAppraisal" class="btn btn-rounded btn-dark mb-4" OnClick="btnBankAppraisal_Click" />
                                                                    </div>
                                                                    <div class="col-lg-4 d-flex">
                                                                        <asp:HyperLink ID="hplBankAppraisal" runat="server" Target="_blank"></asp:HyperLink>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex mt-2 mb-3" id="padding">

                                                                <div class="col-md-10 text-right">
                                                                    <asp:Button Text="Previous" runat="server" ID="BtnPrevious4" class="btn btn-rounded btn-info btn-lg" OnClick="BtnPrevious4_Click" Width="150px" />
                                                                    <asp:Button Text="Preview" runat="server" ID="btnPreview" class="btn btn-rounded btn-update btn-lg" OnClick="btnPreview_Click" Width="150px" />

                                                                    <asp:Button ID="btnSave4" Text="Submit" runat="server" class="btn btn-rounded btn-submit btn-lg" OnClick="btnSave4_Click" BackColor="Green" Width="150px" />
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>

            <asp:PostBackTrigger ControlID="txtCompnyRegDt" />
            <asp:PostBackTrigger ControlID="txtDCPorOperation" />

            <asp:PostBackTrigger ControlID="btnregistration" />
            <asp:PostBackTrigger ControlID="btnUdyam" />
            <asp:PostBackTrigger ControlID="btnPAN" />
            <asp:PostBackTrigger ControlID="btnGSTIN" />
            <asp:PostBackTrigger ControlID="btnCIN" />
            <asp:PostBackTrigger ControlID="btndpr" />
            <asp:PostBackTrigger ControlID="btnBankAppraisal" />
        </Triggers>

    </asp:UpdatePanel>


    <script>
        function showModalOnce() {
            // Get the modal
            var modal = document.getElementById("myModal");
            // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];

            // Open the modal
            //modal.style.display = "block";

            // Check if the modal has been shown before
            if (!localStorage.getItem('modalShown')) {
                // Open the modal
                modal.style.display = "block";
                // Set localStorage to indicate that the modal has been shown
                localStorage.setItem('modalShown', 'true');
            }

            // When the user clicks on <span> (x), close the modal
            span.onclick = function () {
                modal.style.display = "none";
            }

            // When the user clicks anywhere outside of the modal, close it
            window.onclick = function (event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                }
            }
        }
        window.onload = showModalOnce;
    </script>

    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $(".datepicker").datepicker({
                dateFormat: 'dd-mm-yyyy' // Customize the date format as needed
            });
        }
        $(document).ready(function () {
            pageLoad();
        });
        window.onload = datepicker;
    </script>

    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
</asp:Content>
