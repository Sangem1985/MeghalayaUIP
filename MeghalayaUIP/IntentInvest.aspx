<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="IntentInvest.aspx.cs" Inherits="MeghalayaUIP.IntentInvest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <link rel="stylesheet" href="assets/admin/css/style.css">
    <style>
        table#ContentPlaceHolder1_rblproposal label, table#ContentPlaceHolder1_rblInvestments label {
            font-weight: 100;
        }

        table#ContentPlaceHolder1_rblproposal tr td, table#ContentPlaceHolder1_rblInvestments tr td {
            padding: 0px 10px;
        }

        label.col-lg-6.col-form-label {
            font-weight: 400;
        }

        section.innerpages {
            margin-top: 50px;
            margin-bottom: 10px;
        }

        .card-body {
            background: #fff;
        }

        .widget.link-widget ul {
            width: 100% !important;
        }

        section.innerpages {
            margin-top: 20px;
            margin-bottom: 10px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Services/ Intent to Invest</li>
                </ol>
            </nav>
            <section class="innerpages IntentInvest">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="">
                                <div class="content container-fluid">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="card">
                                                <div class="card-header">
                                                    <h4 class="card-title">Intent to Invest</h4>
                                                </div>
                                                <div class="card-body mobile">
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
                                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Company Details</span></label>

                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Name of Company  <span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="Names()"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">PAN<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtPan" runat="server" class="form-control"></asp:TextBox>
                                                                        <%--onblur="fnValidatePAN(this);"--%>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Registered Office Address</span></label>

                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Address Line - 1  <span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtAddress" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Country<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:DropDownList ID="ddlcountry" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged">
                                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12" id="IndState" runat="server" visible="false">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">State<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:DropDownList ID="ddlstate" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12" id="State" runat="server" visible="false">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">State<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox runat="server" ID="txtstate" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex" id="trMeghastate" runat="server" visible="false">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">District<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged">
                                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Mandal<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Village<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex" runat="server" id="trotherstate" visible="false">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">District <span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">

                                                                        <asp:TextBox runat="server" ID="txtApplDist" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Mandal <span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">

                                                                        <asp:TextBox runat="server" ID="txtApplTaluka" class="form-control" onkeypress="return Names(event)"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Village <span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">

                                                                        <asp:TextBox runat="server" ID="txtApplVillage" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Phone No<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtPhone" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Pin/Zip Code<span class="star">*</span>   </label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtPinCode" runat="server" class="form-control" onkeypress="return validatePincode(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Email ID<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtEmailIds" runat="server" class="form-control" onblur="validateEmail(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Fax No</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtFax" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Website    </label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtwebsite" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Contact Details</span></label>

                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Name<span class="star">*</span>    </label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtNames" runat="server" class="form-control" onkeypress="Names()"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Designation<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtDesignation" runat="server" class="form-control" onkeypress="Names()"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Email ID <span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" onblur="validateEmail(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Mobile No <span class="star">*</span>  </label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtMobilesNo" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Project Details</span></label>

                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-5 col-form-label">Project Proposal <span class="star">*</span></label>
                                                                    <div class="col-lg-7 d-flex">
                                                                        <asp:RadioButtonList ID="rblproposal" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="New" Text="New"></asp:ListItem>
                                                                            <asp:ListItem Value="Expansion" Text="Expansion"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        Project Category <span class="star">*</span>
                                                                        <img src="assets/assetsnew/images/helpImage4.png" title="Micro - Investment in Plant and Machinery or Equipment does not exceed Rs 1 crore and annual turnover does not exceed Rs 5 crore. 
                                                                        Small - Investment in Plant and Machinery or Equipment does not exceed Rs 10 crore and annual turnover does not exceed Rs 50 crore. 
                                                                        Medium - Investment in Plant and Machinery or Equipment does not exceed Rs 50 crore and annual turnover does not exceed Rs 250 crore.
                                                                        Large - Investment in Plant and Machinery or Equipment exceeds Rs 50 crores."
                                                                            style="width: 11%;"></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:DropDownList ID="ddlPCB" runat="server" class="form-control">
                                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Sectors<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:DropDownList ID="ddlsector" runat="server" class="form-control">
                                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        Proposed Investment
                                                                        <br />
                                                                        (Rs. in Crore) <span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtproposedInvest" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Proposed Employment<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtEmployments" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Proposed Project Location<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtProjectlocation" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Expected Year of Commencement of Production <span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtExpectedYear" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Expectation/Support required from the State Govt<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtExpectation" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Have you signed the MoU/ Investment Intention in previous events <span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:RadioButtonList ID="rblInvestments" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                            <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <%--<div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Expectation/Support required from the State Govt</span></label>

                                                </div>--%>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">Please Upload Project Document (DPR)<span class="star">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:FileUpload ID="fupDPR" runat="server"></asp:FileUpload>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex mt-4" style="margin-top: 17px !important; margin-bottom: 7px;">
                                                            <div class="col-md-12 text-center">
                                                                <asp:Button ID="BtnSave" runat="server" Text="Submit" class="btn btn-info btn-submit" padding-right="10px" Width="120px" OnClick="BtnSave_Click" />
                                                                <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-info btn-clear" padding-right="10px" Width="120px" OnClick="btnClear_Click" />

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
                    </div>
                </div>
            </section>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>
             <asp:PostBackTrigger ControlID="BtnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
