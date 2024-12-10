<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENApplDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENApplDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
    <style>
        .card {
            border: 1px solid #fff;
            margin-bottom: 12px;
            box-shadow: 0px 0px 1px 1px #ededed;
            background: #fff;
            min-height: 50px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.2);
            position: relative;
            -webkit-border-radius: 2px;
            -moz-border-radius: 2px;
            -ms-border-radius: 2px;
            border-radius: 2px;
            padding-bottom: 10px;
        }

        h3 {
            font-size: 20px;
            margin-top: 3px;
            margin-bottom: 0px;
            font-weight: 600;
            color: #0b3654;
        }

        .card-body {
            border: 1px dotted #ccc;
            padding: 10px;
            margin: 10px;
        }

        .card-header {
            border: none !important;
        }

        spna.dots {
            margin-right: 24px;
            color: #000;
            font-weight: 100;
            visibility: hidden;
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

        div#ContentPlaceHolder1_divServc, div#ContentPlaceHolder1_divManf {
            display: contents;
        }
    </style>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card flex-fill">
                <div class="col-md-12 d-flex ">
                    <div class="col-md-11 pb-2 pt-2 ">
                        <h4>Renewal Application Details</h4>
                    </div>
                    <%-- <div class="col-md-1 pb-2 pt-2">
                        <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" OnClick="lbtnBack_Click" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                    </div>--%>
                </div>


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
                                        class="collapsed">Renewal
                                    </a>

                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingOne" aria-expanded="false" style="height: 0px;">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Application Details</h3>
                                    </div>
                                    <section id="dashboardBasic">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="card-body">
                                                    <div class="col-md-12 d-flex" style="width: 99%;">
                                                        <h4 class="card-title1 col-lg-12">Renewal Application Deatils</h4>
                                                    </div>
                                                    <b>Unit Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Name of Unit :</label>
                                                        </div>

                                                        <div class="col-md-2 fw-bold text-info">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblnameUnit" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Firm Type</label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblCompanyType" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Nature of Industry</label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblNatureIndustry" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Category of Registration</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblRegCat" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Prov.SSI No  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblProvSSI" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Registration Date </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblRegDate" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Sector</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblSector" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Line of Activity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblActivity" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Pollution Category of Enterprise</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblPCB" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Survey/Door</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblSurvey" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Locality</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblLocalit" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Nearest Landmark</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLandmark" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>District</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDistrict" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Mandal</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMandal" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Village</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblVillage" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>E-Mail ID</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Mobile Number </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMobileNum" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Pincode </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPincode" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Total Extent of Land(in Sq.m)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblTotalExtent" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Built up Area (In Sq.m) </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblBuiltAreaSQM" runat="server"></asp:Label>
                                                        </div>

                                                    </div>


                                                    <h4 class="card-title1 col-lg-12">Authorised Representative Details</h4>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Name</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblName" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>S/o.D/o.W/o</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblSonof" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>E-Mail ID</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblMailid" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Mobile Number </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Alternative Mobile No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblAlternative" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Landline Tel No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblLandlines" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>DoorNo</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDoors" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Locality </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblLocalitys" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>State</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblStates" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>District</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDistricts" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Mandal </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblMandals" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Village</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblVillages" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Pincode</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblPincodeIndustry" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Age </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblAge" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Designation</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Women Entrepreneur</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblWomenEntre" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Differently Abled </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblAbled" runat="server"></asp:Label>
                                                        </div>

                                                    </div>


                                                    <h4 class="card-title1 col-lg-12">Employment Details</h4>
                                                    <div class="col-md-12 tablepadding4">
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Direct Male</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDirectMale" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Direct Female</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDirectFemale" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Direct Other Employee</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblirectEmp" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Indirect Male</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblIndirectMale" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Indirect Female</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblIndirectFemale" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Indirect Other Employee</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblIndirectEmp" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Total Employment</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblTotalEmp" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <h4 class="card-title1 col-lg-12">Project Financials</h4>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>1. Value of Land as per saleDeed(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblLandSaledeed" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2. Value of Building(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblBuilding" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>3. Value of Plant & Machinery(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPMINR" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;" id="Manufacture" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>4.Total Project Cost(in Crores)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblTotalCost" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>5.Expected Annual Turnover(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblAnnualTurn" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>6.  Enterprise Category</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblEnterCat" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div id="BoilerDet" runat="server" visible="false">
                                                        <h4 class="card-title1 col-lg-12">Boiler Details</h4>
                                                        <b>Existing License Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>License No for which renewal is required</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLineOfActivity" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>License Issued Date </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblBoilerLicIssue" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>License/ Renewal valid up to Date </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLcValidupto" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <b>Boiler Location Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Work or Plant where Boiler situated </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblBoilerSituatedPlant" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Factory/Establishment Name </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblFactoryEstName" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Address of Factory/Establishment </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblFactoryAddress" runat="server"></asp:Label>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Distric</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblDirectorate" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Mandal</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblApplied" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Village</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblYearEst" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Locality(B) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblDocumenteryEvidence" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Pin code (B) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblPincodes" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <h4>Boiler Technical Details</h4>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Name of the Manufacturer </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblPersonnelDesig" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Year of Manufacture </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblSite" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Place of Manufacture</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblStrictly81" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Boiler Maker's Number </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblHighStanded" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Intended Working Pressure</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblFirmMaterial" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Fuel use</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblInternalOwn" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Super Heater Rating(kg/cm²/lbs) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblBoiler1950" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Economiser Rating</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblProvide" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Maximum Continuous Evaporation(Tonnes/Hour) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblEvaporationMax" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Re-Heater Rating </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblReheater" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Working Season</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblWorkingSeason" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Working Pressure (In Kg/cm-sq or PSI) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblPSI" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Name of the owner</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblOwner" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Type of Boiler </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblTypeBoiler" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Description of Boiler </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblBoilerDesc" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>BoilerRating </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblBoilerRating" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>In case of Boiler ownership being transfer</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblOwnership" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="RemarkTransfer" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Remarks (Transfers etc.) </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblRemark" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <h4 class="card-title1 col-lg-12">Existing Lisence Details</h4>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Registry No  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblRegNos" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Type of Boiler(H)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblBoilerType" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Boiler Rating(H)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblBoilerRateManu" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Work of Plant where Boiler situated(H)  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblBoilerSituated" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Place of manufacture(H) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblPlaceManu" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Year of manufacture(H) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblYearManu" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Name of the owner(H)  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblOwners" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Max. Cont. Evaporation (Tonnes/Hour)(H) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblEvaporation" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Maximum pressure(Lbs)(H) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblPressure" runat="server"></asp:Label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Repairs(H) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblRepairs" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Hydraulically Tested ON(H)  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblHydraulically" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Upto(H)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblUptoH" runat="server"></asp:Label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>The Loading of the(H) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLoading" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Safety valve is not to exceed(H) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblSafetyExceed" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Period from Date(H) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblPeriodDate" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>To Date(H) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblToDateH" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Remark</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblRemarks" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <b>Fees Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Registration Fees to be Paid (Rs)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblRegFees" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Total Amount to be paid (in Rs)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div id="Pollution" runat="server" visible="false">
                                                        <h4 class="card-title1 col-lg-12">RENBusinessLicense Details</h4>
                                                        <b>Existing License Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div>
                                                                <div class="col-md-2">
                                                                    <label>Previous License Number </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblLicNo" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <div class="col-md-2">
                                                                    <label>License Issue Date</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblLICIssue" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>License Valid Upto  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLICShopValidUpto" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <b>Basic Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div>
                                                                <div class="col-md-2">
                                                                    <label>Name of the Shop/Business Establishment</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblNameEst" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <div class="col-md-2">
                                                                    <label>Whether Establishment is owned by </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblOwnEST" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Name of the Individual/authorized representative </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblIndividual" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div>
                                                                <div class="col-md-2">
                                                                    <label>Mobile Number</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblMobile" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div>
                                                                <div class="col-md-2">
                                                                    <label>E-Mail Id  </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <b>Establishment Address</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div>
                                                                <div class="col-md-2">
                                                                    <label>Address of the establishment</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblAddressEST" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Nature of Business   </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblNatureBusiness" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Type of Establishment    </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblTypeEst" runat="server"></asp:Label>
                                                            </div>

                                                        </div>
                                                    </div>



                                                    <div id="CinemaLicense" runat="server" visible="true">
                                                        <h4 class="card-title1 col-lg-12">Cinema License Details</h4>
                                                        <b>Existing License Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Old Registration Number</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblApplType" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Registration Date </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblTNTDATE" runat="server"></asp:Label>
                                                            </div>

                                                        </div>

                                                        <b>Service Specific Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Name of the Establishment Cinema</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblColdStorage" runat="server"></asp:Label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>NOC issued no. with Issue Date   </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblNocIssued" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Number of seats </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblNumberSeats" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Details of the cinematography equipment's </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblCineMatography" runat="server"></asp:Label>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Type of Business </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblBusiness" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Name of the Proprietor/ Managing Partner/ Kartha/ Managing Director</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblManaging" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>GSTIN number of the Business/ Establishment</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblGSTINEST" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Ownership of Premises</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblOwnerships" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <b>Location of The Cinema Establishment</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Distric </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblDistrictses" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Mandal</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblMandeles" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Village</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblVilla" runat="server"></asp:Label>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Locality </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLocalityes" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Landmark</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLandMarkEST" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Pincode</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblPincod" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div id="LabourDet" runat="server" visible="true">
                                                        <h4 class="card-title1 col-lg-12">Contract Labour Deatils</h4>
                                                        <b>Existing License Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                            <div class="col-md-2">
                                                                <label>License No for which renewal is required </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblEstName" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>License Issued Date </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblAddressEstShop" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>License/ Renewal valid up to Date </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblDistrictEST" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <b>Contractor's Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Title</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblpinest" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Name</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblTotalEst" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>E-Mail ID </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblGoodEst" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Mobile Number</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblDateCommence" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Father's Name (in case of individuals)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblGross" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <b>Particulars of establishment where contract labour is to be employed (Principal Employer)</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Establishment Name  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblbusinessindia" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <h4 class="card-title1 col-lg-12">Address of the Establishment</h4>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Distric</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblForeign" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Mandal</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblMadaled" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Village</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblVillaged" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Locality </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblLocalityLabour" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Nearest Landmark </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblNearestLabour" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Pincode </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblPincodeLabour" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Registration number  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblRegIsterNumber" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Registration Date</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblRegisterDates" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Type of Business, Trade, Industry, Manufacture or occupation, which is carried out in the establishment </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblManuOccupation" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <b>Name and Address of Principal Employer</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Title </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblTitled" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Principal Employer's Name</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblPrincipal" runat="server"></asp:Label>
                                                            </div>

                                                        </div>

                                                        <div id="Contract" runat="server" visible="false">
                                                            <div class="col-md-12 d-flex">
                                                                <label class="col-lg-12 col-form-label fw-bold">
                                                                    <span style="font-weight: 900; font-size: 20px;">Manager or person details responsible for the supervision and control of the establishment</span></label>
                                                            </div>
                                                            <div class="table-responsive">
                                                                <asp:GridView ID="GVDETAILS" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                        <asp:BoundField HeaderText="Title" DataField="RENMD_TITLE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Full Name" DataField="RENMD_FULLNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Address" DataField="RENMD_ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>

                                                        <h4 class="card-title1 col-lg-12">Particulars of Contract Labour</h4>
                                                        <b>Name & Address of Agent or Manager of Contractor at the worksite</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Name </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblNameLabour" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Address</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Name, Nature and location of work in which contract labour is employed / is to be employed in the establishment </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblNameEmpLabour" runat="server"></asp:Label>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>No of days of contract labour </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblContractLabour" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Number of contract labour approved in the existing License </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblApprovedLic" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Maximum number of contract labour proposed to be employed now  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblEmpLabour" runat="server"></asp:Label>
                                                            </div>

                                                        </div>

                                                        <b>Other Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Whether the contractor is convicted of any offence within the proceeding five years  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblProceed5Years" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="FiveYears" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Details </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblConvicteddetails" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Whether there was any order against the contractor revoking or suspending license or forfeiting Security Deposit in respect of an earlier contract </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLicDeposit" runat="server"></asp:Label>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div id="Div1" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Order Date  </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna>
                                                                    <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Whether the contractor has work in any other establishment within the past five years </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblContractor5" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Establishment's Details  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblEstDetails" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Principal's Employers Details   </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblEmpDetails" runat="server"></asp:Label>
                                                            </div>


                                                            <div class="col-md-2">
                                                                <label>Nature of work  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblNaturework" runat="server"></asp:Label>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>

                                                <div id="ContractorMigrant" runat="server" visible="true">
                                                    <h4 class="card-title1 col-lg-12">Contractor Migrant Work Deatils</h4>
                                                    <b>Existing License Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>License No for which renewal is required </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblRenewalLic" runat="server"></asp:Label>
                                                        </div>

                                                        <div>
                                                            <div class="col-md-2">
                                                                <label>License Issued Date </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblIssuedDate" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>License/ Renewal valid up to Date </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblFees" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <b>Contractor's Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Title </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDistrics" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Name </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblMand" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>E-Mail ID</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblTown" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>Mobile Number </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblLocality" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Father's Name (in case of individuals) </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblNearstLand" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <b>Address of the Contractor</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>State </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblPlotArea" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>District  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDistricted" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Mandal</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblMaded" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Village </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblVillaed" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Locality  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblMIGRANTlOCALITY" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Nearest Landmark </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblLandMigrant" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Pincode </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblMigrantPincode" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <b>Contractor's Birth Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Date of Birth or age (in case of individuals) </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblBirthage" runat="server"></asp:Label>
                                                        </div>

                                                        <div id="Birth" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Date </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div id="Ages" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Age</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblAges" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <b>Place of Birth</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>State</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblStateMigrant" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>District</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDistrictMigrant" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Mandal</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMandalMigrant" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                    <div class="col-md-2">
                                                        <label>Village</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblVillageMigrant" runat="server"></asp:Label>
                                                    </div>

                                                    <div>
                                                        <div class="col-md-2">
                                                            <label>Locality </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblReMigrantLocal" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Nearest Landmark </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblReMigrantLand" runat="server"></asp:Label>
                                                    </div>

                                                </div>


                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                    <div class="col-md-2">
                                                        <label>Pincode </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblReMigrantPincode" runat="server"></asp:Label>
                                                    </div>

                                                </div>
                                                <b>Other Details Of The Contractor </b>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                    <div class="col-md-2">
                                                        <label>Whether the applicant is a citizen of India: within the meaning of Article 5 of the Constitution of India.   </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblArtical5" runat="server"></asp:Label>
                                                    </div>

                                                    <div>
                                                        <div class="col-md-2">
                                                            <label>Whether any Criminal Case is pending at the time of making application </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblCriminal" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Whether convicted in connection with a Criminal-Case at any time during the period of five years immediately preceding the date of application </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lbl3Financial" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Whether the applicant holds a trading/business license granted by District Council  </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblDateContract" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>license  </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblLicensed" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>License No </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblLicensedNo" runat="server"></asp:Label>
                                                    </div>

                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Date of the License </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblDateOfLicense" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Valid till date   </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblValidDateLic" runat="server"></asp:Label>
                                                    </div>

                                                </div>


                                                <b>Particulars of establishment where migrant workmen-are to be employed</b>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                    <div class="col-md-2">
                                                        <label>Name of the establishment</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblNameOfEstablish" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <b>Address of the establishment</b>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>State </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblMarket" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>District </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblDistrictEstablish" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Mandal</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblStallNo" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Locality  </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblShillong5Years" runat="server"></asp:Label>
                                                    </div>


                                                    <div class="col-md-2">
                                                        <label>Nearest Landmark</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblDetailsYes" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Pincode</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblGrossTurn" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Type of business, trade, industry, manufacture or occupation, which is carried on in the establishment </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Registration Number of the establishment under the Act  </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblRegUnderAct" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Date of certificate of registration  </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblRegCertificate" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <b>Principal Employer Details</b>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Title</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblPrincipalEmpDet" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Name of the Principal Employer </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblPrincipalEmpName" runat="server"></asp:Label>
                                                    </div>

                                                </div>

                                                <b>Particulars of migrant workmen</b>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Name, Location and Nature of work in which migrant workmen are employed or are to be employed in the establishment</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblMigrantWorkMen" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Duration of the proposed contract work in day(Min 1 and Max 179) </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblContract179" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Commencing Date </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblCommencing" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Ending Date </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblEndingDates" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Name of the agent or manager of the contractor at the work site </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblMaanagingSite" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Maximum number of migrant workmen proposed to be employed in the establishment on any date</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblMigrantEmp" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div id="div2" runat="server" visible="false">
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 900; font-size: 20px;">Directors/Partners</span></label>
                                                    </div>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GVMigrant" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                <asp:BoundField HeaderText="Title" DataField="RENMW_TITLE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                <asp:BoundField HeaderText="Name" DataField="RENMW_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                <asp:BoundField HeaderText="Address" DataField="RENMW_ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>

                                                <b>Other Details</b>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Name and address of the Agent through whom the migrant workmen were recruited  </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblMigrantagent" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Whether the contractor is convicted of any offence within the proceeding five years  </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblContractFiveYears" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Migrant" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>Details</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblContractDetails" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Whether there was any order against the contractor revoking or suspending license or forfeiting Security Deposit in respect of an earlier contract  </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblForfeiting" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Div3" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>Order No  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMigrantOrderNo" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Order Date </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMigrantOrderDate" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Whether the contractor has work in any other establishment within the past five years </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblEstPastFiveYears" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Div4" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>Establishment's Details  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblESTABDetails" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Principal's Employers Details </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPrinciplEstDetails" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div id="Div5" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>Nature of work </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMigrantNatureWork" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Whether a certificate by the principal employer is enclosed </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblEMPEnclosed" runat="server"></asp:Label>
                                                    </div>

                                                </div>




                                                <div id="Drug" runat="server" visible="true">
                                                    <h4 class="card-title1 col-lg-12">Drugs License Details </h4>
                                                    <b>Renewal of license</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>License Number   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblArticle5" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Expiry date of license  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblShopindividual" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Do you hold any previous cancelled license?</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMultiple" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div id="LicNos" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Please specify license no </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblTaxPayer" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <b>Details of Technical Staff employed for Manufacturing and Testing</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Is the premise and plan ready for inspection?  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblExise" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Inspection" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Date for Inspection   </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblProvideDet" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Total Amount to be Paid (Rs.) </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPunished" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <b>Additional Item Fees Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>Additional Fees To be Paid (Rs.)  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lbllawRule" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Late Fees  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblapplicant" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Registration Fees to be Paid(Rs.)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblbailable" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Total Amount to be Paid (Rs.)  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblTotalAmountPaid" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div id="div_47_BLR" runat="server" visible="false">
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">Drug Details</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GVDrugName" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Name of Drug" DataField="REND_DRUGNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                    <div id="div6" runat="server" visible="false">
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">Drug Details</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GVTEST" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Name" DataField="RENST_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Qualification" DataField="RENST_QUALIFICATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Experience" DataField="RENST_EXPERIENCE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                    <div id="div7" runat="server" visible="false">
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">Drug Details</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GVMANU" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Name" DataField="RENDM_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Qualification" DataField="RENDM_QUALIFICATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Experience" DataField="RENDM_EXPERIENCE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                    <div id="div8" runat="server" visible="false">
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">Additional Item</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GVADDED" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Specify additional item" DataField="RENDA_ADDITIONALITEM" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                    <%--  <div id="div9" runat="server" visible="false">
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 900; font-size: 20px;">Details of Technical Staff employed for Manufacturing</span></label>
                                                    </div>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GVHealthy" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                <asp:BoundField HeaderText="Name" DataField="CFODM_EMPNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                <asp:BoundField HeaderText="Qualification" DataField="CFODM_EMPQLFCATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                <asp:BoundField HeaderText="Experience" DataField="CFODM_EMPEXPRNC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>

                                                <div id="div10" runat="server" visible="false">
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 900; font-size: 20px;">Details Of Technical Staff Employed For Testing</span></label>
                                                    </div>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GVTESTING" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                <asp:BoundField HeaderText="Name" DataField="CFODT_EMPNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                <asp:BoundField HeaderText="Qualification" DataField="CFODT_EMPQLFCATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                <asp:BoundField HeaderText="Experience" DataField="CFODT_EMPEXPRNC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>

                                                <div id="div11" runat="server" visible="false">
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 900; font-size: 20px;">Drug Details</span></label>
                                                    </div>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GVDrug" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                <asp:BoundField HeaderText="Name of Drug" DataField="CFOD_DRUGNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>--%>
                                                </div>


                                                <div id="Factories" runat="server" visible="false">
                                                    <h4 class="card-title1 col-lg-12">Factories License Details</h4>

                                                    <b>Applicant's Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Full name of the factory  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDateEstablishments" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Factory license Number  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblRegNoFactory" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>License Issued Date </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDateOfReg" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Latest Renewal No </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblCurrentRegNo" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Latest Renewal Date   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblRegADC" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Lisence Valid Upto Year  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDateRegistration" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <b>Nature of the Manufacturing</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>Carried on in the factory during the last 12 months (in the case of all factories already in existence)  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblNumberRegCurrent" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>To be carried on the factory during the next 12 months (in the case of all factories)    </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPartnership" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Names of the principal products manufactured during the last 12 months  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblCompany" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Values of the principal products manufactured during the last 12 months  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblNames" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <h4 class="card-title1 col-lg-12">Service Specific Details</h4>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Maximum numbers of workers proposed to be employed on any one day during the year. </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblManuDetails" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Maximum number of workers employed on any one day during the last 12 months  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblManumeasure" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Number of workers to be ordinarily employed in the factory</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblWeighting" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Whether the Unit is an Electricity/Power Generating Station?  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblRegNumberTax" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Yesclick" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Total installed capacity of Generating Station- KW </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblGST" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div id="Noclick" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Total installed capacity of DG Set/Standby Power- KW </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblITNumber" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div id="Nos" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Maximum amount of power(K.W. installed or proposed to be installed) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblStateimport" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Full name of the person who shall be the manager of the factory for the purpose of the Act  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLICNumbers" runat="server"></asp:Label>
                                                        </div>


                                                        <div class="col-md-2">
                                                            <label>Residential address of the person who shall be the manager of the factory for the purpose of the Act  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblRegImportMeasure" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Full name of the owner of the premises of the building (including the precincts thereof) refer to section 93 </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblManusold" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Residential address of the owner of the premises of the building (including the precincts thereof) refer to section 93 </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDealerLic" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Full name of the occupier  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblManufactureDetails" runat="server"></asp:Label>
                                                        </div>

                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Residential address of the occupier  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblSkilled" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Whether the factory is a private firm proprietor concern? </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblsemiSkill" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Factory" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Name of proprietor  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblUnskill" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Whether the factory is a public firm proprietor concern? </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblSpecialist" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Proprietor" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Name of Directors </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblManufactureWeight" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Whether factory is Government or Local Fund Factory? </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lbllongtermlease" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div id="Administrative" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Name of Chief Administrative Head </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblvitaothermeans" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Whether Managing Agent has been appointed? </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblElectricEnergy" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Managing" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Name of Managing Agents </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblManuLic" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <b>Construct of factory after commencement of the Rules</b>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>In the case of factory constructed or extended after the date of the commencement of the Rules</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblManuGiveDetails" runat="server"></asp:Label>
                                                        </div>

                                                        <div id="Approvals" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Reference number of approval of the plant for site whether for old or new building and for construction or extension of the factory by the state Government/Chief Inspector(1) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblFinancialloan" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Date of approval of the plant for site whether for old or new building and for construction or extension of the factory by the state Government/Chief Inspector(1)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblManuBank" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div id="ApprovalArrange" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Reference number of approval of the arrangements, if any , made for the disposal of trade waste and effluents and the name of the authority granting such approval.(2) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLabourgiveDetails" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Date of approval of the arrangements, if any , made for the disposal of trade waste and effluents and the name of the authority granting such approval(2) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLoanWeight" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <b>Fees to be payed on calculation</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Final Fees </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblFinalFees" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Penalty </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPenalty" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>License Valid Upto </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLicValidupto" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Total Amount to be Paid </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblTotalAmountbePaid" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                </div>


                                                <div id="Saftey" runat="server" visible="true">
                                                    <h4 class="card-title1 col-lg-12">Safety and Security Details </h4>
                                                    <b>Existing License Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Migrant Worker Registration Number </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMigrantWorkReg" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>District in which Registration was Issued</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMigrantIssued" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <b>Particulars of the next of kin of the applicant in home state</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>Name of next of kin</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblKinhomeState" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Address</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMigrantAddress" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <b>Service Specific Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Whether the applicant was convicted of any offence under any law in force in India?  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblForceIndia" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Whether the applicant has any criminal case pending against him/her?   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblCriminalAgainst" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Declaration that the applicant is not of unsound mind? </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblunsoundMind" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>Nature of Employment/Designation   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblNatureEmployment" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Date of commencement of employment or expected date of commencement  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblExpectedEmp" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Expected duration of stay </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblExpectedDuration" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <b>Location and Address of the work area where the migrant worker was employed as per Previous License</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Details of the work [ Mention specific skill only]  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetailsMention" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>District of the area of work   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDistrictArea" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Area of work [ mention communication address of the work area]   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblAreaOfworkAddress" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Existing Registration Valid Up to Date  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblExistingRegValid" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <b>Location and Address of the work area where the migrant worker will be employed for the Renewal</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Details of the work [ Mention specific skill only] </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblworkMentionSkill" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>District of the area of work(H)   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDistrictAreaofwork" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Area of work [ mention communication address of the work area</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblAreaaddresswork" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Registration will be Renewed Upto Date </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblRegRenewedDate" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <b>Details of the Establishment/Employer</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Name of the Establishment/Employer  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblNameEstEmp" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Address of the establishment   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblAdressEstMigrant" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Contact number of Establishment/Employeer</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblContactEstEmp" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                </div>


                                                <div id="ShopEst" runat="server" visible="true">
                                                    <h4 class="card-title1 col-lg-12">Shops and Establishment </h4>
                                                    <b>Existing License Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>License No for which renewal is required</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLicNoRenewal" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>License Issued Date</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLicIssuedDates" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>License/ Renewal valid up to Date</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLicRenewalvalidupto" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <b>Basic Establishment Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>Name of Establishment </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblNameEstablish" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Constitution of Business</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblBusinessConstitute" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Applicant's Name </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblApplicantNames" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Mobile Number </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMobileNumbers" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>E-Mail Id </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblEmailIdes" runat="server"></asp:Label>
                                                        </div>
                                                    </div>





                                                    <b>Establishments Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Name of the Manager /Agent/other person acting in the general management   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblNameManagement" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Address of the Manager/Agent    </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblAddressAgent" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Category of Establishmnet </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblCategoryEst" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Nature of Business  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblShopBusiness" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Do you have your family members employed in the establishment and residing with and wholly dependent upon you?  </label>
                                                        </div>
                                                        <%--(grid==no visbale false)--%>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblFamilyEstDept" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Do you have employees working in the establishment?</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblEmpEstablish" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div id="NumberEmp" runat="server" visible="false">
                                                            <div class="col-md-2">
                                                                <label>Number of employees  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblNumberEmp" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <b>Postal address and exact location of establishment</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Distric   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblshopdistrict" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Mandal    </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblshopmandal" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Village</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblshopvillage" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Locality   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblshoplocality" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Pincode    </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblshoppincode" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Nearest Landmark</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblshoplandmark" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div id="PostalAddress" runat="server" visible="false">
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">Postal address and exact location of establishment</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GVPROPERTIE" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Name of Proprietor" DataField="RENP_NAMEPROPERTIE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Communication Address" DataField="RENP_COMMUNICATIONADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Community" DataField="RENP_COMMUNITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Community(Others)" DataField="RENP_COMMUNITYOTHER" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>



                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Do you have any other office/godown/warehouse attached to this establishment situated in a different premises  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblgodownEst" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div id="dependentEmp" runat="server" visible="false">
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">Details of employer's family employed in the establishment and residing with and wholly dependent upon him</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GVPATNER" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Name of Partner" DataField="RENPS_NAMEPATNER" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Communication Address" DataField="RENPS_COMMUNICATIONADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                    <div id="Div9" runat="server" visible="false">
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">Details of employer's family employed in the establishment and residing with and wholly dependent upon him</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GVLIMITED" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Name of Director" DataField="RENLC_NAMEOFDIRECTOR" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Communication Address" DataField="RENLC_COMMUNICATIONADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                    <div id="Div10" runat="server" visible="false">
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">Details of employer's family employed in the establishment and residing with and wholly dependent upon him</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GVDETAIL" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Distric" DataField="RENWP_DISTRIC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Mandal" DataField="RENWP_MANDAL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Village" DataField="RENWP_VILLAGE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Locality" DataField="RENWP_LOCALITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Pincode" DataField="RENWP_PINCODE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                    <div id="Div11" runat="server" visible="false">
                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">Details of employer's family employed in the establishment and residing with and wholly dependent upon him</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GVTESTED" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Name" DataField="RENED_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Gender" DataField="RENED_GENDER" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Age" DataField="RENED_AGE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Relationship" DataField="RENED_RELATIONSHIP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                    <b>Renewal Details</b>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Registration will be renewed from date  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblRegRenewed" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Registration will be valid upto date  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblRegValidupto" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>No of years renewed  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblNoYeraRenewed" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Fees  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblFeesRenewal" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Fees for change notice   </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblChangeNotice" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Fine  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblFineMigrant" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Penalty  </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPenaltyes" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Total amount to be paid    </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblAmountpaid" runat="server"></asp:Label>
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
                                                <div class="col-md-12">
                                                    <div class="table-responsive">
                                                        <table class="table table-bordered mb-0">
                                                            <thead>
                                                                <tr>
                                                                    <th>Attachment Name</th>
                                                                    <th>Status</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>


                                                                <tr>
                                                                    <td class="fw-bold">DPR</td>

                                                                    <td style="text-align: center;">
                                                                        <%--   <asp:LinkButton ID="linkViewDPR" runat="server" OnClick="linkViewDPR_Click"></asp:LinkButton>--%>
                                                                        <asp:HyperLink ID="hplViewDPR" runat="server" Visible="false"></asp:HyperLink>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>

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
                                                            <asp:BoundField HeaderText="UNIT ID" DataField="UNITID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Raised By" DataField="QUERYBY" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Description" DataField="QUERYRAISEDESC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
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
                                        <h3>Query Response Attachments Check Lists</h3>
                                    </div>
                                    <section id="dashboardQueryattachmnts">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="grdQryAttachments" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="Both" Width="70%" EnableModelValidation="True" ShowHeaderWhenEmpty="true" HorizontalAlign="Center">
                                                        <RowStyle />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="LightGray" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="View" DataField="FILENAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <%--  <asp:TemplateField HeaderText="SI.No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkViewQueryAttachment" Text='<%#Eval("FILENAME") %>' runat="server" OnClick="linkViewQueryAttachment_Click"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="VIEW" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hplViewQueryAttachment" Text='<%#Eval("FILELOCATION") %>' runat="server"></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                    </asp:GridView>

                                                </div>

                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default" visible="false" runat="server">
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
                                                    <asp:GridView ID="grdApplStatus" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD table-hover" ForeColor="#333333"
                                                        GridLines="None" Width="100%" EnableModelValidation="True">
                                                        <RowStyle />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />

                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:BoundField HeaderText="Department ID" DataField="PRDA_DEPTID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="false" />
                                                            <asp:BoundField HeaderText="Unit ID" DataField="PRDA_UNITID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Department Name" DataField="MD_DEPT_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Dept Process Status" DataField="STATUSDESCRIPTION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Dept Processed Date" DataField="PRDA_DEPTPROCESSDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
