<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENIndustryDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENIndustryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        i.fi.fi-br-circle-camera {
            font-size: 32px;
            margin-right: -21px;
            padding-left: 6px;
        }
    </style>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Renewal</a></li>

            <li class="breadcrumb-item active" aria-current="page">Renewal Application Details</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Renewal Application Deatils:</h4>
                        </div>
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
                            <div class="row">
                                <div class="col-md-12 d-flex">
                                    <h4 class="card-title ml-3"></h4>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                1. Name of Unit</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtUnitName" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                2.Company Type</label>
                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="ddlCompanyType" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Registration number *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtRegNo" runat="server" class="form-control" Type="text"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Registration Date *</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtRegDate" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                Sector of Enterprise*
                                            </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlSectorEnter" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                    <asp:ListItem Text="Manufacturing" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="Service" Value="N"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Sector</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlsector" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlsector_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                Line of Activity*
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
                                                Pollution Category of Enterprise*
                                            </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Label ID="lblPCBCategory" Font-Bold="true" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <h6 class="fs-20">Project Financials</h6>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                1. Proposed
																		Employment</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtPropEmp" runat="server" class="form-control" AutoPostBack="true" OnTextChanged="txtPropEmp_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. Value of Land as per saleDeed(In INR)</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtLandValue" runat="server" class="form-control" onkeypress="return validateAmount(event)" AutoPostBack="true" OnTextChanged="txtLandValue_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. Value of Building(In INR)</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtBuildingValue" runat="server" class="form-control" onkeypress="return validateAmount(event)" AutoPostBack="true" OnTextChanged="txtBuildingValue_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4. Value of Plant & Machinery(In INR)</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtPMCost" runat="server" class="form-control" onkeypress="return validateAmount(event)" AutoPostBack="true" OnTextChanged="txtPMCost_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">5. Expected Annual Turnover(In INR)</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtAnnualTurnOver" runat="server" class="form-control" onkeypress="return validateAmount(event)" AutoPostBack="true" OnTextChanged="txtAnnualTurnOver_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">6. Total Project Cost(in Crores)</label>
                                            <div class="col-lg-6">
                                                <asp:Label ID="lblTotProjCost" Text="0.00" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex mt-2">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                7. Enterprise Category
                                            </label>

                                            <div class="col-lg-6">
                                                <h5>
                                                    <asp:Label ID="lblEntCategory" Text="Category" runat="server"></asp:Label></h5>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">&nbsp;</div>
                                </div>

                                <h6 class="fs-20">Unit Location</h6>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                5.District
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
                                            <label class="col-lg-6 col-form-label">6. Mandal</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select Mandal" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">7. Village</label>
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
                                            <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEmailId" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mobile Number *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" MaxLength="10"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Door*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtDoors" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Locality *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLocality" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Nearest Landmark</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLANDMARK" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Pincode *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtpincode" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <h6 class="fs-20">Current Address</h6>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of Promoter *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtName" runat="server" class="form-control" Type="text"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mobile Number *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtphoneno" runat="server" class="form-control" MaxLength="10"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">DoorNo*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtDoorNo" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Locality *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLocal" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                State
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
                                                District
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
                                            <label class="col-lg-6 col-form-label">Mandal</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlmand" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlmand_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select Mandal" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">7. Village</label>
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
                                            <label class="col-lg-6 col-form-label">District *</label>
                                            <div class="col-lg-6 d-flex">

                                                <asp:TextBox runat="server" ID="txtApplDist" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mandal *</label>
                                            <div class="col-lg-6 d-flex">

                                                <asp:TextBox runat="server" ID="txtApplTaluka" class="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Village *</label>
                                            <div class="col-lg-6 d-flex">

                                                <asp:TextBox runat="server" ID="txtApplVillage" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Pincode *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPin" runat="server" class="form-control" Type="text"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Age *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtAge" runat="server" class="form-control" Type="text"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Designation *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtDesignation" runat="server" class="form-control" Type="text"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12 text-right mt-2 mb-2">

                                <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
