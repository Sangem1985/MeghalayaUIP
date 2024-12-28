<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="HazardousDetails.aspx.cs" Inherits="MeghalayaUIP.User.Services.HazardousDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table#ContentPlaceHolder1_chkActivities tr {
            display: inline;
            padding: 19px;
        }

        table#ContentPlaceHolder1_chkActivities {
            width: 100% !important;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <contenttemplate>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb mb-0">
                <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                <li class="breadcrumb-item"><a>Services</a></li>

                <li class="breadcrumb-item active" aria-current="page">Hazardous Waste Management</li>
            </ol>
        </nav>
        <div class="page-wrapper">
            <div class="content container-fluid">
                <div class="row" runat="server" id="divText">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Application for Authorization Under Hazardous Waste Management:</h4>
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
                                        <h4 class="card-title ml-3">General Details </h4>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    Firm Name:</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    Firm Location:</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtfirmlocation" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    Name of the occupier of the facility or operator of disposal facility with designation:</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtoccupiername" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtEmailId" runat="server" class="form-control"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Mobile Number *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">FAX Code:</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtfax" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-2">
                                            <label>Authorisation Required For:</label>
                                        </div>
                                        <div class="col-md-10 d-flex">
                                            <asp:CheckBoxList ID="chkActivities" runat="server" RepeatDirection="Vertical">
                                                <asp:ListItem Value="1">Generation</asp:ListItem>
                                                <asp:ListItem Value="2">Collection</asp:ListItem>
                                                <asp:ListItem Value="3">Storage</asp:ListItem>
                                                <asp:ListItem Value="4">Transportation</asp:ListItem>
                                                <asp:ListItem Value="5">Reception</asp:ListItem>
                                                <asp:ListItem Value="6">Reuse</asp:ListItem>
                                                <asp:ListItem Value="7">Recycling</asp:ListItem>

                                                <asp:ListItem Value="8">Recovery</asp:ListItem>
                                                <asp:ListItem Value="9">Pre-processing</asp:ListItem>
                                                <asp:ListItem Value="10">Co-processing</asp:ListItem>
                                                <asp:ListItem Value="11">Utilisation</asp:ListItem>
                                                <asp:ListItem Value="12">Treatment</asp:ListItem>
                                                <asp:ListItem Value="13">Disposal</asp:ListItem>
                                                <asp:ListItem Value="14">Incineration</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nature and quantity of waste handled per annum (in metric tonne/kilo litre)*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtwstntrqtyanum" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nature and quantity of waste stored at any time (in metric tonne/kilo litre)*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtwstntrqtyatm" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Year of commissioning and commencement:*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox runat="server" ID="txtyrcmsng" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" onkeyup="handleKeyUp(this)" />
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtyrcmsng"></cc1:CalendarExtender>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Whether the Firm works:*</label>
                                                <asp:RadioButtonList ID="rblShifts" runat="server">
                                                    <Items>
                                                        <asp:ListItem Text="01 Shift" Value="01" />
                                                        <asp:ListItem Text="02 Shifts" Value="02" />
                                                        <asp:ListItem Text="Round the clock" Value="Round" />
                                                    </Items>
                                                </asp:RadioButtonList>
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
    </contenttemplate>

</asp:Content>

