<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="SrvcApplDeptProcess.aspx.cs" Inherits="MeghalayaUIP.Dept.Services.SrvcApplDeptProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <style>
        spna.dots {
            margin-right: 24px;
            color: #000;
            font-weight: 100;
            visibility: hidden;
        }

        .col-md-2 {
            padding: 0px;
        }

        div#collapseOne h4 {
            margin-bottom: 5px;
            margin-top: 20px;
            padding-left: 0px;
        }

        .col-md-2 {
            border: 1px solid #ccc;
            padding: 0px 10px;
            margin: -2px 0px;
        }

        h4.card-title1 {
            color: #fff;
            width: 98.7%;
            padding: 1px 0px;
            border-radius: 4px;
            text-align: center;
            margin-bottom: 0px !important;
            padding-bottom: 0px !important;
            text-transform: capitalize;
            background: #2b6698;
            text-shadow: 1px 2px 3px #000;
            border: 1px solid #066f22;
            font-size: 20px;
        }

        .dropdown-menu.show {
            transform: translate3d(-75px, 60px, 0px) !important;
        }
    </style>

    <!-- Page Wrapper -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/DeptDashBoard.aspx">Dashboard</a></li>
            <li class="breadcrumb-item active" aria-current="page">Other Services Details</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card-header d-flex justify-content-between">
                <h4 class="card-title mt-1"><b>Other Services Details</b></h4>
                <div class="col-md-1">
                    <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                </div>
            </div>
            <div class="card flex-fill">

                <h4 class="mt-2 ml-4">View Details</h4>
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
                <div class="col-md-12">
                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingOne">
                                <h4 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion"
                                        href="#collapseOne" aria-expanded="false" aria-controls="collapseOne"
                                        class="collapsed">Application Details
                                    </a>

                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingOne" aria-expanded="false" style="height: 0px;">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Applicant And Firm Details</h3>
                                    </div>
                                    <section id="dashboardBasic">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="card-body">
                                                    <div class="col-md-12 d-flex" style="width: 99%;">
                                                        <h4 class="card-title1 col-lg-12">Company/Unit Details</h4>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Name of Unit</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblUnitName" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Company Type</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblCompanyType" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Nature of Industry</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblNatureIndustry" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Category of Registration</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblRegCategory" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Registration Number</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblRegNo" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Registration Date</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblRegDate" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Sector</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblSector" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Line of Activity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblLineActivity" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Pollution Category of Enterprise</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblPollutionCategory" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Survey/Door</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblSurveyDoor" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Built-up Area (in Sq.m)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblBuiltArea" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Total Extent of Land (in Sq.m)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblLandArea" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Locality</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblLocalitys" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Nearest Landmark</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblLandmark" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>District</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblDistrict" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Mandal</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblMandal1" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Village</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblVillage1" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>E-Mail ID</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Mobile Number</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Pincode</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblpincode1" runat="server"></asp:Label>
                                                        </div>

                                                    </div>





                                                    <h4 class="card-title1 col-lg-12">Authorised Representative Details: </h4>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Name</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblName" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>S/o. D/o. W/o</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblSoWoDo" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>E-Mail ID</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Mobile Number</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblnumber" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Alternative Mobile No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblAltMobile" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Landline Tel No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblLandlineNo" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Door No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblDoorNo" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Locality</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblLocal" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>State</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblState" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;" runat="server" id="trotherstate" visible="false">
                                                        <div class="col-md-2">
                                                            <label>District</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblApplDist" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Mandal</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblApplTaluka" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Village</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblApplVillage" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Pincode</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblPincode" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Age</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblAge" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Designation</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblDesignation1" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Women Entrepreneur</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblWomenEntrepreneur" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Differently Abled</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblDifferentlyAbled" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <h4 class="card-title1 col-lg-12">Employement Details</h4>
                                                    <h4 class="card-title ml-3">Employment Details: </h4>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Direct Male</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblDirectMale" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Direct Female</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblDirectFemale" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Direct Other Employee</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblDirectOther" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Indirect Male</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblIndirectMale" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Indirect Female</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblIndirectFemale" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Indirect Other Employee</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblIndirectOther" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Total Employment</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblTotalEmployment" runat="server"></asp:Label>
                                                        </div>
                                                    </div>



                                                    <h4 class="card-title1 col-lg-12">Project Finanacials</h4>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>1. Value of Land as per saleDeed (In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblLandValue" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>2. Value of Building (In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblBuildingValue" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>3. Value of Plant & Machinery (In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblPMCost" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>4. Total Project Cost (In Crores)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblTotProjCost" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>5. Expected Annual Turnover (In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblAnnualTurnOver" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>6. Enterprise Category</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span><asp:Label ID="lblEntCategory" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div id="Solidwaste" runat="server" visible="true">

                                                        <h4 class="card-title1 col-lg-12">Solid Waste Management Details</h4>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Name of the local body/agency appointed by them/operator of facility</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblNameLocalBody" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Officer authorised by the local body/agency</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>For setting up and operation of the facility (Authorization)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblAuthorization" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Total Quantity of waste to be processed per day</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblWasteProduced" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Quantity of waste to be recycled</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblWasteRecycled" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Quantity of waste to be treated</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblWasteTreated" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Quantity of waste to be disposed into landfill</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblWasteDisposed" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Utilization programme for waste processed (Product Utilization)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblUtilisation" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Quantity of leachate</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblQuanLeachate" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                            <div class="col-md-2">
                                                                <label>Treatment technology for leachate</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblTreatmentLeachate" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Measures to be taken for prevention and control of environmental pollution</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblMeasuresForPrevention" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Measures to be taken for safety of workers</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblMeasuresForSafety" runat="server"></asp:Label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Number of sites identified</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblSiteIdentified" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Quantity of waste to be disposed per day</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblQuantityWasteDisposed" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Details of existing site under operation</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblExistingSiteUnderOperation" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Methodology and operational details of landfilling</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblLandfillingDetails" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Measures taken to check environmental pollution</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblMeasureToChkEnvPoltn" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div id="BioMedical" runat="server" visible="true">
                                                        <h4 class="card-title1 col-lg-12">Bio-Medical Waste Management Details</h4>
                                                        <h5 class="card-title ml-3">Particulars of Application:</h5>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>i) Name of the Applicant:</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblNameApplicant" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>ii) Name of the health care facility (HCF)/common bio-medical waste treatment facility (CBWTF):</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblMedical" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>E-Mail ID*</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="Labelemail" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                            <div class="col-md-2">
                                                                <label>Mobile Number *</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="Labelmobile" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Website Address:</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblWebsite" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <h5 class="card-title ml-3">Activity for which authorisation is sought:</h5>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Authorization Required for</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelAuthreqfor" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <h5 class="card-title ml-3">Application for fresh or renewal of authorisation:</h5>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Applied for CTO/CTE</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelCtoCte" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>In case of renewal previous authorisation number</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelRenno" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>In case of renewal previous authorisation Date:</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="Labelrenprvsdate" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <h5 class="card-title ml-3">Status of Consents</h5>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Under the Water (Prevention and Control of Pollution) Act, 1974</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="Labelpcb" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Under the Air (Prevention and Control of Pollution) Act, 1981</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="Labelpcb1981" runat="server"></asp:Label>
                                                            </div>

                                                        </div>
                                                        <h5 class="card-title ml-3">(HCF/CBWTF)</h5>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Address of the health care facility (HCF) or common bio-medical waste treatment facility (CBWTF)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelrblHealth" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>GPS coordinates of health care facility (HCF) or common bio-medical waste treatment facility (CBWTF)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelrblGPS" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <h5 class="card-title ml-3">Details of health care facility (HCF) or common bio-medical waste treatment facility (CBWTF)</h5>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>i) Number of beds of HCF</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelNoHCF" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>ii) Number of patients treated per month by HCF</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelHCFNO" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>iii) Number healthcare facilities covered by CBMWTF</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelHealthCBMWFT" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>iv) No of beds covered by CBMWTF</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelNobedcbmwtf" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>v) Installed treatment and disposal capacity of CBMWTF</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelCapacityTreat" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>vi) Area or distance covered by CBMWTF</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelDistance" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>vii) Quantity of Bio-medical waste handled, treated or disposed</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="LabelWasteTreat" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Category</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="Labelcategory" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Type of Waste</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="Labeltypwaste" runat="server"></asp:Label>
                                                            </div>

                                                        </div>

                                                        <br />
                                                        <div class="col-md-12 d-flex justify-content-center">
                                                            <asp:GridView ID="GVWaste" runat="server" AutoGenerateColumns="false">
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
                                                                        <ItemStyle Width="70px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Category" Visible="true" ItemStyle-Width="60%" HeaderStyle-HorizontalAlign="left">
                                                                        <ItemTemplate>
                                                                            <itemstyle horizontalalign="Center" />
                                                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("BMW_CATEGORY") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Type of waste" Visible="true" ItemStyle-Width="60%" HeaderStyle-HorizontalAlign="left">
                                                                        <ItemTemplate>
                                                                            <itemstyle horizontalalign="Center" />
                                                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("BMW_TYPEWASTE") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Quantity Generated or Collected, Kg/ day" ItemStyle-Width="60%" HeaderStyle-HorizontalAlign="left">
                                                                        <ItemTemplate>
                                                                            <itemstyle horizontalalign="Center" />
                                                                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("BMW_QUANTITYGENERATED") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Method of Treatment and Disposal (ReferSchedule – I)" ItemStyle-Width="60%" HeaderStyle-HorizontalAlign="left">
                                                                        <ItemTemplate>
                                                                            <itemstyle horizontalalign="Center" />
                                                                            <asp:Label ID="lblDisposal" runat="server" Text='<%# Eval("BMW_TREATMENTDISPOSAL") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                    <div id="Div1" runat="server" visible="true">
                                                        <h4 class="card-title1 col-lg-12">Power Distribution Corporation Limited</h4>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>i) Status in Relation to the premises:</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>ii) Location and Address of the premises including Police Sation:</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblPSAddress" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>iii)Nature of LT Supply*</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <span class="dots">:</span><asp:Label ID="lblLTSupply" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                </div>

                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingTwo">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseTwo" aria-expanded="false"
                                        aria-controls="collapseTwo">Attachments
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingTwo" style="" aria-expanded="false">


                                <div class="card">
                                    <div class="card-header">
                                        <h3>Check Lists</h3>
                                    </div>
                                    <section id="dashboardAttachmnt">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-md-3"></div>
                                                <div class="col-md-6">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdAttachments" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                <asp:BoundField HeaderText="Attachment Name" DataField="FILEDESCRIPTION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                <asp:TemplateField HeaderText="View">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="linkAttachment" Text='<%#Eval("FILENAME")%>' runat="server"></asp:HyperLink>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="View" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFilePath" Text='<%#Eval("FILELOCATION")%>' runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>

                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="col-md-3"></div>

                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingThree">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseThree" aria-expanded="false"
                                        aria-controls="collapseThree">Query
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseThree" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingThree" aria-expanded="false">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Queries</h3>
                                    </div>
                                    <section id="dashboardQuery">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-sm-12">
                                                    <asp:GridView ID="grdQueries" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                                        GridLines="Both" Width="100%" EnableModelValidation="True" ShowHeaderWhenEmpty="true">
                                                        <RowStyle />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="LightGray" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Application ID" DataField="PREREGUIDNO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                            <%-- <asp:BoundField HeaderText="UNIT ID" DataField="UNITID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />--%>
                                                            <asp:BoundField HeaderText="Query Raised By" DataField="QUERYBY" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Description" DataField="QUERYRAISEDESC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Raised To" DataField="QUERYRAISETO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Raised Date" DataField="QUERYDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Response" DataField="QUERYRESPONSEDESC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Response Date" DataField="QUERYRESPONSEDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>

                                                    </asp:GridView>
                                                </div>

                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingFour">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseFour" aria-expanded="false"
                                        aria-controls="collapseFour">Query Response Attachments
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseFour" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingFour" aria-expanded="false">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Attachments in Response to Query Raised</h3>
                                    </div>
                                    <section id="dashboardQueryattachmnts">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="grdQryAttachments" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="Both" Width="80%" EnableModelValidation="True" ShowHeaderWhenEmpty="true">
                                                        <RowStyle />
                                                        <AlternatingRowStyle BackColor="LightGray" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="FileName" DataField="FILENAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:TemplateField HeaderText="View">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="linkViewQueryAttachment" Text='<%#Eval("FILENAME") %>' runat="server"></asp:HyperLink>

                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFilePath" Text='<%#Eval("FILELOCATION")%>' runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>
                                                    <%--<div class="table-responsive">                                                      
                               </div>--%>
                                                </div>

                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingFive">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseFive" aria-expanded="false"
                                        aria-controls="collapseFive">Status of Application
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseFive" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingFive" aria-expanded="false">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Status of Application</h3>
                                    </div>
                                    <section id="dashboardStatus">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-sm-12">

                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdApplStatus" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD" ForeColor="#333333"
                                                            GridLines="Both" Width="100%" EnableModelValidation="True">
                                                            <RowStyle />
                                                            <AlternatingRowStyle BackColor="LightGray" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField HeaderText="Department ID" DataField="PRDA_DEPTID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="false" />
                                                                <asp:BoundField HeaderText="Application ID" DataField="PREREGUIDNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Department Name" DataField="MD_DEPT_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Dept Process Status" DataField="STATUSDESCRIPTION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Dept Processed Date" DataField="PRDA_DEPTPROCESSDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:TemplateField HeaderText="Site Inspection Report" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkView" runat="server" Visible="false" Text="View"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default" id="verifypanel" runat="server" visible="false">
                            <div class="panel-heading" role="tab" id="headingSix">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseSix" aria-expanded="false"
                                        aria-controls="collapseSix">Verification of Application
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseSix" class="panel-collapse show" role="tabpanel"
                                aria-labelledby="headingSix" aria-expanded="false">

                                <div class="card">
                                    <div class="card-header">
                                        <h3>Verification of Application</h3>
                                    </div>
                                    <section id="dashboardStatus">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-sm-12">

                                                    <div class="table-responsive">
                                                        <table align="Center" style="width: 100%; border-color: brown; align-content: center;" class="table table-bordered mb-10">
                                                            <tr style="border-color: brown; background-color: midnightblue; color: azure">
                                                                <td><b>Name</b></td>
                                                                <td><b>Unit Name</b></td>
                                                                <td><b>Application No</b></td>
                                                                <td style="width: 150px"><b>Application Date</b></td>
                                                                <td style="width: 200px"><b>Select Action</b></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lbl_Name1"></asp:Label></td>
                                                                <td>
                                                                    <asp:Label ID="lblunitname1" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblApplNo" runat="server"></asp:Label></td>
                                                                <td tyle="width: 100px">
                                                                    <asp:Label ID="lblapplDate" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 200px">
                                                                    <asp:DropDownList ID="ddlStatus" AutoPostBack="true" runat="server" Class="form-control">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Approve & Forwrd to IMA" Value="5"></asp:ListItem>
                                                                        <asp:ListItem Text="Raise Query" Value="4"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div>

                                                        <table align="Center" style="width: 70%; border: none; align-content: flex-start" id="tblaction" runat="server" visible="false">
                                                            <tr>
                                                                <td colspan="3">
                                                                    <table class="table-bordered table-hover table-primary mb-3" style="width: 100%; border: none; align-content: flex-start">
                                                                        <tr runat="server" visible="false" id="trheading">
                                                                            <td><b>Paramater Name</b></td>
                                                                            <td><b>Applicant Data</b></td>
                                                                            <td><b>Department Value</b></td>
                                                                        </tr>
                                                                        <tr id="trIndsDept" runat="server" visible="false">
                                                                            <td>
                                                                                <label>Land Area</label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblApplLandArea" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDeptLandArea" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trPowerDept" runat="server" visible="false">
                                                                            <td>
                                                                                <label>Power Required</label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblApplPowerReq" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDeptPower" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trWaterDept" runat="server" visible="false">
                                                                            <td>
                                                                                <label>Water Required</label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblApplWaterReq" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDeptWater" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trForestDept1" runat="server" visible="false">
                                                                            <td>
                                                                                <label>
                                                                                    Details of waste /<br />
                                                                                    Effluent to be generated</label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblApplWastedtls" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtDeptWastedtls" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trForestDept2" runat="server" visible="false">
                                                                            <td>
                                                                                <label>
                                                                                    Details of Hazardous 
                                            <br />
                                                                                    waste to be generated</label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblApplHazWaste" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox runat="server" ID="txtHazWaste" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>
                                                                        <asp:Label ID="lblaction" runat="server"></asp:Label>
                                                                    </b>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtRequest" runat="server" TextMode="MultiLine" Height="50px" Width="350px" Visible="true"></asp:TextBox>
                                                                </td>

                                                                <td colspan="2" align="Center">
                                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-rounded btn-submit btn-lg" />
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td style="vertical-align: central" id="tdquery" runat="server" visible="false" colspan="3">
                                                                    <asp:GridView ID="gvdeptquery" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD" ForeColor="#333333"
                                                                        GridLines="None" Width="100%" EnableModelValidation="True">
                                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl No.">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Department">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddldepartment" runat="server">
                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Query Description">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtquery" runat="server"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:TemplateField>
                                                                            <asp:ButtonField CommandName="Add" Text="Add">
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:ButtonField>
                                                                            <asp:ButtonField CommandName="Remove" Text="Delete">
                                                                                <ItemStyle CssClass="scroll_td" />
                                                                            </asp:ButtonField>
                                                                        </Columns>
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="#B9D684" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:GridView>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnQuery" runat="server" Visible="false" Text="Raise Query" class="btn btn-rounded btn-info btn-lg" BackColor="Green" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default" id="QueryResondpanel" runat="server" visible="false">
                            <div class="panel-heading" role="tab" id="headingSeven">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseSeven" aria-expanded="false"
                                        aria-controls="collapseSeven">Respond to Query
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseSeven" class="panel-collapse show" role="tabpanel"
                                aria-labelledby="headingSeven" aria-expanded="false">

                                <div class="card">
                                    <asp:GridView ID="grdQueryRaised" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" CssClass="table-bordered mb-0 GRD"
                                        GridLines="Both" Width="100%" EnableModelValidation="True" ShowHeaderWhenEmpty="true">
                                        <RowStyle />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="LightGray" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DepQID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblDQID" Text='<%#Eval("IRQID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="QueryByDeptID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblDeptID" Text='<%#Eval("QUERYRAISEDTODEPTID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UNIT ID" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUNITID" runat="server" Text='<%#Eval("UNITID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Application ID" DataField="PREREGUIDNO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                            <asp:BoundField HeaderText="Query By (Dept.Name)" DataField="QUERYBY" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Query Raised on" DataField="QUERYDATE" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Query Description" DataField="QUERYRAISEDESC" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" />
                                            <asp:TemplateField HeaderText="Response">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtIMAQueryReply" TextMode="MultiLine" Height="70px" Width="250px" runat="server" onkeypress="return validateNameInput(event)"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                    <asp:FileUpload ID="FileUploadquery" runat="server" />
                                                    <br />
                                                    <asp:Button runat="server" ID="btnUpldAttachment" Text="Upload" class="btn btn-dark btn-rounded" Height="35px" Width="110px" /><br />
                                                    <br />
                                                    <asp:HyperLink ID="hplAttachment" runat="server" Visible="false" Text="File Not Uploaded" Target="_blank" ForeColor="Blue"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Send Response to IMA">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnsendresponsetoIMA" CssClass="btn btn-success" runat="server" Text="Submit" /><br />
                                                    <br />
                                                    <%--<asp:Button ID="btnsendIMAQuerytoApplicant" CssClass="btn btn-success" runat="server" Text="Forward Query to Applicant" OnClick="btnsendIMAQuerytoApplicant_Click" />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>



                </div>
            </div>
        </div>
    </div>

    <!-- /Page Wrapper -->


    <!-- /Main Wrapper -->

    <!-- jQuery -->
</asp:Content>
