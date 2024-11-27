<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="IncentiveEligibility.aspx.cs" Inherits="MeghalayaUIP.User.INCENTIVE.IncentiveEligibility" %>

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

        .bordered-div {
            border: 2px solid black;
            border-radius: 10px; /* Specifies border thickness, style, and color */
            padding: 10px; /* Adds space between the border and content */
            margin: 10px; /* Adds space outside the border */
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
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-body">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:HiddenField ID="hdnResultTab2" runat="server" />
                                    <asp:HiddenField ID="hdnResultTab3" runat="server" />

                                    <ul class="nav nav-tabs">
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link1" class="nav-link active" runat="server" OnClick="Link1_Click" Style="padding-right: 20px; font-size: 18px; margin-top: -8px !important; padding: 10px 10px 12px !important;"> 
                                    &nbsp;&nbsp;&nbsp;&nbsp;1. Incentive Eligibility Details&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></li>
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link2" class="nav-link" runat="server" OnClick="Link2_Click" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;2. Fixed Capital Investment&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></li>
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link3" class="nav-link" runat="server" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
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
                                                   <%-- <div class="card-body" runat="server" id="divbasic">
                                                        <span class="icon"><i class="fi fi-br-caret-down"></i></span>
                                                    </div>--%>
                                                    <div class="card-header">
                                                        <h4 class="card-title">Incentive Eligibility Details:</h4>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <h4 class="card-title ml-3">1.Basic Details: </h4>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    (a) Name of Unit</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtUnitName" runat="server" class="form-control" onkeypress="return Names()" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">(b).Factory/Unit Address *</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtAddress" runat="server" class="form-control" onkeypress="return Names()" TabIndex="1"></asp:TextBox>
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
                                                                <label class="col-lg-6 col-form-label" id="lblregntype" runat="server">C&RD Block *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtBlock" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Post Office</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtPost" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtemail" runat="server" class="form-control" Type="text" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>

                                                                    </div>
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
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Pincode *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtpincode" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    (C) Office Address</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtOffAddress" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

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
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    District
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="drpdwndist2" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select District" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mandal</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="drpdownmdl2" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Mandal" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Village</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="drpdownvlg2" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Village" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label3" runat="server">Post Office *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtpstofc2" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
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
                                                                    <asp:TextBox ID="txtldln" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Pincode *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtpincode2" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    (d) Registered Office's Address</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtrofcaddrss" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Area/Locality</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtarea2" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label5" runat="server">C&RD Block *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtcrdblck3" runat="server" class="form-control" Type="text"></asp:TextBox>
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
                                                                    <asp:DropDownList ID="drpdwndist3" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select District" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mandal</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="drpdwnmdl3" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Mandal" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Village</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="drpdwnvlg3" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Village" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label6" runat="server">Post Office *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtpostofc3" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtemailid3" runat="server" class="form-control" Type="text" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label7" runat="server">Landline/Mobile NO *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtldln3" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Pincode *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtpincode3" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    (e) Category of Enterprise</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="CategoryDropDown" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Category" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    (f) Sector of Unit</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="drpdwnsectr" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Sector" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Constitution of the unit
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="drpdwncnstitutionunit" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select Ownership" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-6 col-form-label">2.Please Eter the Propeitery details  *</label>
                                                    </div>


                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Name of proprietor/all Partners/all Directors/Secretary and President of the Cooperative Society</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtproptrname" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Resedential Address</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtproptraddress" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    PAN Number</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtproptrpan" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 d-flex justify-content-center">

                                                        <div class="col-md-4">
                                                            <div class="form-group row">

                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Button ID="addprptrdetails" runat="server" Text="ADD" class="form-control"></asp:Button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <div class="table-responsive">
                                                                    <asp:GridView ID="inspectionTeam" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                                                        GridLines="Both" HeaderStyle-BackColor="Red"
                                                                        Width="100%" EnableModelValidation="True">
                                                                        <RowStyle />
                                                                        <AlternatingRowStyle BackColor="LightGray" />
                                                                        <HeaderStyle BackColor="Red" />
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="10px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderText="Name" DataField="prptrname" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                            <asp:BoundField HeaderText="Ownership" DataField="prptrownership" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField HeaderText="PanNum" DataField="pannumbr" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="right" />

                                                                        </Columns>

                                                                    </asp:GridView>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Is Unit</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rbtnunit" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem id="newunit" Text="New " Value="0"></asp:ListItem>
                                                                        <asp:ListItem id="existingunit" Text="Existing " Value="1"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Date of commencement of commercial production/operation
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtCompnyoprDt" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtCompnyoprDt"></cc1:CalendarExtender>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Date of commencing commercial production operation after expansion:

                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtaftrepnsn" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtaftrepnsn"></cc1:CalendarExtender>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Date of commencing commercial production operation before expansion :
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtbfrexpnsn" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtbfrexpnsn"></cc1:CalendarExtender>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Name of  Raw Material</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Source of Raw Material</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Button ID="btnaddrwmtrls" runat="server" Text="ADD" class="form-control"></asp:Button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 d-flex">
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <div class="table-responsive">
                                                                    <asp:GridView ID="rawmtrlsgrdview" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                                                        GridLines="Both" HeaderStyle-BackColor="Red"
                                                                        Width="100%" EnableModelValidation="True">
                                                                        <RowStyle />
                                                                        <AlternatingRowStyle BackColor="LightGray" />
                                                                        <HeaderStyle BackColor="Red" />
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="10px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderText="Name of Raw Materials" DataField="nmrwmtrls" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                            <asp:BoundField HeaderText="Source of Raw Materials" DataField="srcrawmtrls" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                        </Columns>

                                                                    </asp:GridView>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <h4 class="card-title ml-3">Items of production & installed capacity </h4>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Type of service rendered Prior to expansion/diversification</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtsrvcrndrdpriorexpnsn" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Type of service rendered After expansion/diversification</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtsrvcrndrdaftrexpnsn" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Annual installed capacity Prior to expansion/diversification</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtannualtinstldpriorexpnsn" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Annual installed capacity Prior to expansion/diversification</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtannualtinstldaftrexpnsn" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Button ID="btnadditmscpcty" runat="server" Text="ADD" class="form-control"></asp:Button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <div class="table-responsive">
                                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                                                        GridLines="Both" HeaderStyle-BackColor="Red"
                                                                        Width="100%" EnableModelValidation="True">
                                                                        <RowStyle />
                                                                        <AlternatingRowStyle BackColor="LightGray" />
                                                                        <HeaderStyle BackColor="Red" />
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="10px">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderText="srvcrenderedpriorexpnsn" DataField="srvcrenderedpriorexpnsn" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                            <asp:BoundField HeaderText="srvcrenderedaftrexpnsn" DataField="srvcrenderedaftrexpnsn" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField HeaderText="annualinstldcpcitypriorexpnsn" DataField="annualinstldcpcitypriorexpnsn" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                            <asp:BoundField HeaderText="annualinstldcpcityaftrexpnsn" DataField="annualinstldcpcityaftrexpnsn" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                        </Columns>

                                                                    </asp:GridView>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                            </asp:View>

                                            <!---NewTab--->
                                            <asp:View ID="viewRevenue" runat="server">
                                                <div class="col-md-12 d-flex">
                                                    <h4 class="card-title ml-3">Details of Registeration </h4>

                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <h5 class="card-title ml-4">In Case of New Unit </h5>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                EM Part II No
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtemprt2no" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                EM Part II date:
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="Emprt2date" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="Emprt2date"></cc1:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                IEM No.
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtIEMno" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                IEM date:
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="IEMdate" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="IEMdate"></cc1:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                UAM No.
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtUAM" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                UAM date:
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="UAMdate" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="UAMdate"></cc1:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                Permanent Registration No.
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="TextBox1" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                Permanent Registration  date:
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="TextBox4" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                                <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MM-yyyy" TargetControlID="UAMdate"></cc1:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 d-flex">
                                                    <h5 class="card-title ml-4">In Case of Existing Unit </h5>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                EM Part II No
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtexEmpartIIno" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                EM Part II date:
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtexEmpartIIdt" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="dd-MM-yyyy" TargetControlID="Emprt2date"></cc1:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                IEM No.
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtexIEMno" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                IEM date:
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtexIEMdt" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd-MM-yyyy" TargetControlID="txtexIEMdt"></cc1:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                UAM No.
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtexUAMno" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                UAM date:
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtexUAMdt" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" Format="dd-MM-yyyy" TargetControlID="txtexUAMdt"></cc1:CalendarExtender>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                Permanent Registration No.
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtexPmntregNo" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                Permanent Registration  date:
                                                            </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtexPmntregdt" MaxLength="10" TabIndex="1" AutoPostBack="true" class="form-control" />
                                                                <cc1:CalendarExtender ID="CalendarExtender11" runat="server" Format="dd-MM-yyyy" TargetControlID="txtexPmntregdt"></cc1:CalendarExtender>
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
