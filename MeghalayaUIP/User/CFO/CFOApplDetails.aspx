<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOApplDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOApplDetails" %>

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
                        <h4>Pre-Operational</h4>
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
                                        class="collapsed">Pre-Operational
                                    </a>

                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingOne" aria-expanded="false" style="height: 0px;">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Application Detail's</h3>
                                    </div>
                                    <section id="dashboardBasic">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="card-body">
                                                    <div class="col-md-12 d-flex" style="width: 99%;">
                                                        <h4 class="card-title1 col-lg-12">Project Details</h4>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Name of Unit :</label>
                                                        </div>

                                                        <div class="col-md-2 fw-bold text-info">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblnameUnit" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Company Type</label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblCompanyType" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Proposal For</label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblProposal" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Nature of Industry</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblNatureIndustry" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>District </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDistric" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Mandal</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblMandals" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Village</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblVilla" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Total Extent of Land(in sq.m)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblExtentLand" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Built up	Area (In Sq.m)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblBuiltArea" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Sector</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblSectors" runat="server"></asp:Label>
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
                                                            <spna class="dots">:</spna><asp:Label ID="lblPcb" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Whether land purchased from MIDCL</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMIDCL" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Location of the unit</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLocationUnit" runat="server"></asp:Label>
                                                        </div>

                                                    </div>


                                                    <h4 class="card-title1 col-lg-12">Project Financials</h4>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Proposed Employment</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblproposeEMP" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Value of Land as per saleDeed(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblLANDINR" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Value of Building(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblBuildingINR" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Value of Plant & Machinery(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblMachineryINR" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Expected Annual Turnover(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblExpectTurnINR" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Total Project Cost(in Crores)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblTPCost" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Enterprise Category</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblEnterpriseCat" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <h4 class="card-title1 col-lg-12">ENTREPRENUER&LAND</h4>
                                                    <div class="col-md-12 tablepadding4">
                                                        <b>Organization Details</b>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>1. Name of Company</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblBNameCompany" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2. Type of Company</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblTypecompany" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>3. Company Proposal</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblCompanyProposal" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>4. Category of Registration</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>5. Registration No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblRegistration" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>6. Registration Date</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDate" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>7. Type of Factory</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblFactory" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <h4 class="card-title1 col-lg-12">Authorised Representative Details</h4>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>1. Name</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDetName" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2.  S/o.D/o.W/o</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetSon" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>3. Email</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetEmail" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;" id="Manufacture" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>4. Mobile No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetMobile" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>5. Alternative Mobile No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetAlter" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>6.  Landline Tel No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDetLand" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>7.Door No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetDoor" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>8. Locality</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetLocality" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>9. District</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDetDistrict" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>10. Mandal</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetMandal" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>11. Village/Town</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetVillage" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>12. Pincode</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetPincode" runat="server"></asp:Label>
                                                        </div>

                                                    </div>



                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>13. Women Entrepreneur</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetWomen" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>14. Differently Abled</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDetAbled" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <h4 class="card-title1 col-lg-12">Location Details</h4>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>1.Architect Name</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblArcName" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2. Architect License No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblArcLicNo" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>3. Architect Mobile No.</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblArcMobileNo" runat="server"></asp:Label>
                                                        </div>

                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>4. Structural Engineer Name</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblStrName" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>5.Structural License No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblStrLicNo" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>6. Structural Mobile No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblStrMobileno" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>7. Proposed Area for Development(in Sq. mts)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblAreaDevelop" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>8.  Type of Approach Road</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblRoad" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>9. Existing Width of Approach Road(in feet)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblwidthRoad" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>10.  Affected in Road Widening</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblAffected" runat="server"></asp:Label>
                                                        </div>

                                                        <div runat="server" id="divAffectArea" visible="false">
                                                            <div class="col-md-2">
                                                                <label>11. Extend of affected area in sq.mts</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblExtend" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <h4 class="card-title1 col-lg-12">Employment Details</h4>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>(Total Employee-Direct</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>1. Direct Male</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDirectMale" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2.Direct Female</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDirectFemale" runat="server"></asp:Label>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>3. Direct Other Employee</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblOtherEmp" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>4. Indirect Male</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblIndMale" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>5. Indirect Female</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblIndFemale" runat="server"></asp:Label>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>6. Indirect Other Employee</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblIndEmp" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="row">
                                                        <div class="col-xl-12 col-sm-12 col-12">
                                                            <div class="card">
                                                                <div class="card-body">
                                                                    <div class="col-md-12">
                                                                        <h4 class="card-title1 col-lg-12">Manufacturing Items and Raw Materials Used</h4>
                                                                        <h5></h5>
                                                                        <hr />
                                                                    </div>
                                                                    <%--  <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Line of Activity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLineOfActivity" runat="server"></asp:Label>
                                                        </div>

                                                    </div>--%>
                                                                    <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Details Of Manufacture Items :</b></p>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="gvManufacture" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                                                            GridLines="Both" HeaderStyle-BackColor="Red"
                                                                            Width="100%" EnableModelValidation="True">
                                                                            <RowStyle />
                                                                            <AlternatingRowStyle BackColor="LightGray" />
                                                                            <HeaderStyle BackColor="Red" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Name of Product" DataField="CFOLM_ITEMNAME" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="left" />
                                                                                <asp:BoundField HeaderText="Annual Manufacturing Capacity (in tonne)" DataField="CFOLM_ITEMANNUALCAPACITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField HeaderText="Appox. value (₹)" DataField="CFOLM_ITEMVALUE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                            </Columns>
                                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                            <AlternatingRowStyle BackColor="White" />
                                                                        </asp:GridView>
                                                                    </div>

                                                                    <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Details Of Raw Materials Used in Process :</b></p>
                                                                    <div class="table-responsive">
                                                                        <asp:GridView ID="gvRwaMaterial" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                                <asp:BoundField HeaderText="Name of major raw material" DataField="CFORM_ITEMNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                                <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="CFORM_ITEMANNUALCAPACITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="CFORM_ITEMVALUE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                                <asp:BoundField HeaderText="Source(s) of supply" DataField="CFORM_SOURCEOFSUPPLY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div id="Labourdet" runat="server" visible="false">
                                                        <div class="row">
                                                            <div class="col-xl-12 col-sm-12 col-12">
                                                                <div class="card">
                                                                    <div class="card-body">
                                                                        <div class="col-md-12">
                                                                            <h5>Labour Details</h5>
                                                                            <hr />
                                                                        </div>
                                                                        <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Vendor Technical:</b></p>

                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>1.Whether the firm has ever been approved by any Boilers’ Directorate / Inspectorate?</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblDirectorate" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>2. Classification applied for</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblApplied" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>3. Year of Establishment</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblYearEst" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>4.Is any type of jobs executed by the firm earlier, with special reference to their maximum working pressure, temperature and the materials involved, with documentary evidence?</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblDocumenteryEvidence" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>5. Has your request for recognition as a repairer under Indian Boiler Regulation, 1950 been rejected by any authority</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblRegulation1950" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>6. Whether having rectifier / generator, grinder, general tools and tackles, dye penetrant kit, expander and measuring instruments or any other tools and tackles under regulation 392 (5) (i)?</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblRegulation392" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>7.Detailed list of technical personnel with designation, educational qualifications and relevant experience (attach copies of documents) who are permanently employed with the firm ?</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblPersonnelDesig" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>8. How many working sites can be handled by the firm simultaneously?</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblSite" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>9. Whether the firm is prepared to execute the job strictly in 81 conformity with the regulations and maintain a high standard of work ?</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblStrictly81" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>10.Whether the firm is prepared to accept full responsibility for the work done and is prepared to clarify any controversial issue, if required?</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblHighStanded" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>11.Whether the firm is in a position to supply materials to required specification with proper test certificates if asked for ?</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblFirmMaterial" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>12.Whether the firm has an internal quality control system of their own ??</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblInternalOwn" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>13.Upload document for List of welders employed with copies of current certificate issued by a Competent Authority under the Indian Boiler Regulations, 1950?</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblBoiler1950" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div id="Approved" runat="server" visible="false">
                                                                                <div class="col-md-2">
                                                                                    <label>14. Provide Details</label>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <spna class="dots">:</spna><asp:Label ID="lblProvide" runat="server"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Boiler Technical Details :</b>                                                </p>

                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>Name of the Manufacturer </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblNameManufacture" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Year of manufacture</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblYearManufactures" runat="server"></asp:Label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label>Place of manufacture</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblManufactures" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>Boiler Maker's Number  </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblBoilerMaker" runat="server"></asp:Label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label>Intended Working Pressure </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblIntendedWork" runat="server"></asp:Label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <label>Place of manufacture </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblPlacemodule" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>Super Heater Rating(kg/cm²/lbs)  </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblSuperHeater" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Economiser Rating</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblEcoRating" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Maximum Continuous Evaporation (Tonnes/Hour) </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblMaxTonnes" runat="server"></asp:Label>
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


                                                                        <h4 class="card-title1 col-lg-12">Boiler Technical Details</h4>
                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>Name of the Manufacturer </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblNameManu" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Year of manufacture </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblYearManu" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Place of manufacture</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblPlaceManu" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                        <h4 class="card-title1 col-lg-12">Particulars of Contract Labour</h4>
                                                                        <h4 class="card-title1 col-lg-12">Name & Address of Agent or Manager of Contractor at the worksite</h4>
                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>Name of agent or manager </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblNameManger" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Address of the agent or manager </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblAddressAgent" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Name,Nature and location of work in which contract labour is employed / is to be employed in the establishment</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblEmpLabour" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>No of days of contract labour </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lbllabourDays" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Estimated date of commencement</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblEstDateComm" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Ending Date </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblEndingDate" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>Maximum number of contract labour proposed to be employed</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lbllabourEmp" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Whether the contractor is convicted of any offence within the proceeding five years</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblContractor5" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div id="contractor" runat="server" visible="false">
                                                                                <div class="col-md-2">
                                                                                    <label>Details </label>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <spna class="dots">:</spna><asp:Label ID="lblDetails5" runat="server"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>Whether there was any order against the contractor revoking or suspending license or forfeiting Security Deposit in respect of an earlier contract.</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblRevokingLic" runat="server"></asp:Label>
                                                                            </div>
                                                                            <div id="OrderDate" runat="server" visible="false">
                                                                                <div class="col-md-2">
                                                                                    <label>Order Date</label>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <spna class="dots">:</spna><asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                                                                                </div>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Whether the contractor has work in any other establishment within the past five years </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblPast5" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div id="Principle" runat="server" visible="false">
                                                                                <div class="col-md-2">
                                                                                    <label>Principal's Employers Details </label>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <spna class="dots">:</spna><asp:Label ID="lblEmpDetails" runat="server"></asp:Label>
                                                                                </div>
                                                                            </div>

                                                                            <div id="nature" runat="server" visible="false">
                                                                                <div class="col-md-2">
                                                                                    <label>Establishment's Details </label>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <spna class="dots">:</spna><asp:Label ID="lblEstablishDetails" runat="server"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                            <div id="WorkNature" runat="server" visible="false">
                                                                                <div class="col-md-2">
                                                                                    <label>Nature of work </label>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <spna class="dots">:</spna><asp:Label ID="lblNature" runat="server"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                        </div>

                                                                        <h4 class="card-title1 col-lg-12">Establishments Details</h4>
                                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                            <div class="col-md-2">
                                                                                <label>Name of the Manager /Agent/other person acting in the general management </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblGeneralAct" runat="server"></asp:Label>
                                                                            </div>


                                                                            <div class="col-md-2">
                                                                                <label>Address of the Manager/Agent</label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblManagerAgent" runat="server"></asp:Label>
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
                                                                                <label>Nature of Business </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblNatureBusiness" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Do you have your family members employed in the establishment and residing with and wholly dependent upon you? </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblfamilyestablish" runat="server"></asp:Label>
                                                                            </div>

                                                                            <div class="col-md-2">
                                                                                <label>Do you have employees working in the establishment? </label>
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <spna class="dots">:</spna><asp:Label ID="lblEmpEstablish" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <div class="table-responsive">
                                                                            <asp:GridView ID="GVCFOLabour" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                                    <asp:BoundField HeaderText="Name" DataField="CFOLD_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                                    <asp:BoundField HeaderText="Gender" DataField="CFOLD_GENDER" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                                    <asp:BoundField HeaderText="Age" DataField="CFOLD_AGE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                                    <asp:BoundField HeaderText="Community" DataField="CFOLD_COMMUNITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                                    <asp:BoundField HeaderText="Full Present Address" DataField="CFOLD_FULLADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                                    <asp:BoundField HeaderText="Permanent Address [With District & State]" DataField="CFOLD_ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                                    <asp:BoundField HeaderText="Half Day Leave" DataField="CFOLD_HALFDAY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                                    <asp:BoundField HeaderText="Full Day Leave" DataField="CFOLD_FULLDAY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div id="DrugLic" runat="server" visible="false">
                                                        <h4 class="card-title1 col-lg-12">Health & Family Welfare</h4>
                                                        <b>Application Type and Ownership Details</b>
                                                        <div id="div_39_46" runat="server" visible="true">
                                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                                <div class="col-md-2">
                                                                    <label>Application Type(H) </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblApplType" runat="server"></asp:Label>
                                                                </div>


                                                                <div class="col-md-2">
                                                                    <label>Valid up to date Trading License(TNT)</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblTNTDATE" runat="server"></asp:Label>
                                                                </div>

                                                                <div class="col-md-2">
                                                                    <label>Valid up to date permission from Municipallity/Contt.Board/Local Dorbar</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblMunicipality" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                <div class="col-md-2">
                                                                    <label>Particulars of cold storage</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna>
                                                                    <asp:Label ID="lblColdStorage" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div runat="server" id="div_license" visible="false">
                                                            <h4 class="card-title1 col-lg-12">Application Details</h4>
                                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                                <div class="col-md-2">
                                                                    <label>Do you hold any previous cancelled license?  </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblcancel" runat="server"></asp:Label>
                                                                </div>

                                                                <div id="CanceledLIC" runat="server" visible="false">
                                                                    <div class="col-md-2">
                                                                        <label>Please specify license no</label>
                                                                    </div>
                                                                    <div class="col-md-2">
                                                                        <spna class="dots">:</spna><asp:Label ID="lbllicno" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div runat="server" id="div_52" visible="false">
                                                                    <div class="col-md-2">
                                                                        <label>Is the premise and plan ready for inspection?</label>
                                                                    </div>
                                                                    <div class="col-md-2">
                                                                        <spna class="dots">:</spna><asp:Label ID="lblpremiseplan" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                                <div id="Inception" runat="server" visible="false">
                                                                    <div class="col-md-2">
                                                                        <label>Date for Inspection </label>
                                                                    </div>
                                                                    <div class="col-md-2">
                                                                        <spna class="dots">:</spna><asp:Label ID="lblDateInspe" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div id="div_Staff_Manf" runat="server" visible="false">
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
                                                                        <asp:BoundField HeaderText="Qualification" DataField="CFODM_EMPQLFCATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Experience" DataField="CFODM_EMPEXPRNC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>


                                                        <div runat="server" visible="false" id="div_Staff_Test">
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
                                                                        <asp:BoundField HeaderText="Qualification" DataField="CFODT_EMPQLFCATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Experience" DataField="CFODT_EMPEXPRNC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>


                                                        <div runat="server" id="div_48" visible="false">
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
                                                                        <asp:BoundField HeaderText="Name of Drug " DataField="CFOD_DRUGNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div id="ProffessionalTax" runat="server" visible="false">
                                                        <h4 class="card-title1 col-lg-12">Proffessional Tax Details</h4>
                                                        <b>Establishment Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                            <div class="col-md-2">
                                                                <label>Name of Establishment </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblEstName" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Address of Establishment </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblAddressEst" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>District of Establishment</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblDistrictEST" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Pin Code of Establishment</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblpinest" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Total number of Employees working in Establishment</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblTotalEst" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Description of Goods and Services supplied by the Establishment </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblGoodEst" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Date of commencement </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblDateCommence" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Gross Annual income in the last financial year </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblGross" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Additional Place of Business in MEGHALAYA </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblMeghalaya" runat="server"></asp:Label>
                                                            </div>
                                                        </div>


                                                        <div id="AdditionDetails" runat="server" visible="false">
                                                            <div class="col-md-12 d-flex">
                                                                <label class="col-lg-12 col-form-label fw-bold">
                                                                    <span style="font-weight: 900; font-size: 20px;">Additional Place of Business Details</span></label>
                                                            </div>
                                                            <div class="table-responsive">
                                                                <asp:GridView ID="GVState" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                        <asp:BoundField HeaderText="Place of Business" DataField="CFOPS_PLACEBUSINESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Address" DataField="CFOPS_ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="District" DataField="CFOPS_DISTRIC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Total working employees" DataField="CFOPS_TOTALEMP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Additional Place of Business in INDIA </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblbusinessindia" runat="server"></asp:Label>
                                                            </div>
                                                        </div>


                                                        <div id="Added" runat="server" visible="false">
                                                            <div class="col-md-12 d-flex">
                                                                <label class="col-lg-12 col-form-label fw-bold">
                                                                    <span style="font-weight: 900; font-size: 20px;">Additional Place of Business Details</span></label>
                                                            </div>
                                                            <div class="table-responsive">
                                                                <asp:GridView ID="GVCOUNTRY" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                        <asp:BoundField HeaderText="Place of Business" DataField="CFOPC_PLACEBUSINESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Address" DataField="CFOPC_ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="State" DataField="CFOPC_STATE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Total working employees" DataField="CFOPC_TOTALEMP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>

                                                        <h4 class="card-title1 col-lg-12">Other Details</h4>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Whether office from foreign country?</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblForeign" runat="server"></asp:Label>
                                                            </div>
                                                        </div>


                                                        <div id="foreign" runat="server" visible="false">
                                                            <div class="col-md-12 d-flex">
                                                                <label class="col-lg-12 col-form-label fw-bold">
                                                                    <span style="font-weight: 900; font-size: 20px;">Other place of work, if any, in state</span></label>
                                                            </div>
                                                            <div class="table-responsive">
                                                                <asp:GridView ID="GVFOREIGN" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                        <asp:BoundField HeaderText="Principal Place of Work" DataField="CFOPF_PRINCIPLEWORK" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Address" DataField="CFOPF_ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Employer Name" DataField="CFOPF_EMPNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Monthly Salary/Wages" DataField="CFOPF_MONTHLYWAGES" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Do you have registration under any other act? </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblRegUnder" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="RegistrationType" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Registration Type </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblRegType" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="RegNo" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Regisration No </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblRegNo" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div id="FireDet" runat="server" visible="false">
                                                        <h4 class="card-title1 col-lg-12">Fire Details</h4>
                                                        <b>Service Specific Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                            <div class="col-md-2">
                                                                <label>Name of Business/Building </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblNameofDet" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Category of Building for which Fire Clearance is applied </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblBuildingFire" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Fee Amount</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblFees" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <b>Location of Building/ Premises</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                            <div class="col-md-2">
                                                                <label>District </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblDistrics" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Mandal </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblMand" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Village/Town</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblTown" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                            <div class="col-md-2">
                                                                <label>Locality </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblLocality" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Nearest Landmark </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblNearstLand" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Pincode</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblPin" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Plot Area (in Sq m) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblPlotArea" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Proposed Drive way (Breadth [in meters])  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblBreadth" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Build up Area (in Sq m)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblBuildArea" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Existing or proposed Approach Road (L x B [in meters]) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblApproachRoad" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <h4 class="card-title1 col-lg-12">Details of surrounding occupancies and their probable distance from the proposed building</h4>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>1 (a). East  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblEast" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>1 (a). Distance from proposed Building (in meters) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblDistanceprop" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>1 (b). West </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblwest" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>1 (b). Distance from proposed Building (in meters) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblbUILDDIST" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>1 (c). North </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblNorth" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>1 (c). Distance from proposed Building (in meters)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblDistBuild" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>1 (d). South </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblSouth" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>1 (d). Distance from proposed Building (in meters) </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna>
                                                                <asp:Label ID="lblbuildProp" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Distance from the nearest Fire Station (in meters)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblFireStation" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div id="ContractorReg" runat="server" visible="false">
                                                        <h4 class="card-title1 col-lg-12">ContractorsRegistration</h4>
                                                        <b>Service Specific Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Purpose of Application </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblApplication" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Choose the Class of Contractor registering for </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblRegContractor" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="director" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Directorate</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblManuDirectorate" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div id="circle" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Circle </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblCircle" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="division" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Division </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblDivision" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <b>Basic Details as Contractor </b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Name of Bank   </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblBankName" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Turn Over (in Rs. Lakhs):</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblTurnOver" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Total Value of Works in last 3 financial years (in Rs. Lakhs)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lbl3Financial" runat="server"></asp:Label>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Date from which working as contractor  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblDateContract" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div id="Pollutioncontrol" runat="server" visible="false">
                                                        <h4 class="card-title1 col-lg-12">Pollution Control Board</h4>
                                                        <b>Establishment Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Date of Establishment </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblDateEstablish" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Select Location of Stall</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLocationStall" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Whether the applicant is doing any business in Shillong Municipality during the previous 5 (five) years?  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblShillong5Years" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div id="stall" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Holding Number </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblHoldingNo" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="MarketName" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Market Name </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblMarket" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="District" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>District of Establishment </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblDistrictEstablish" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div id="Districmaster" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Stall number</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblStallNo" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="Municipality" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Details (if Yes)</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblDetailsYes" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Annual Gross Turnover (Rs in Lakhs)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblGrossTurn" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Total Amount </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">BusinessLicense</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GVPollution" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Nature of Business (Main Category)" DataField="CFOBN_MAINCATEGORY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Nature of Business (Sub Category)" DataField="CFOBN_SUBCATEGORY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Fees" DataField="CFOBN_FEE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                    <div id="ExciseDep" runat="server" visible="false">
                                                        <h4 class="card-title1 col-lg-12">Excise Department </h4>
                                                        <b>Applicant Details</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>1. Are you citizen of India as defined in Article 5 to 8 of the Constitution of India?  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblArticle5" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>2. Has the applicant/ you have has held individual/jointly held one/multiple shop/s or any other excise license? </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblindividual" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>3. Whether applicant’s direct family member/dependents have held individual/jointly held one/multiple shop/s or any other excise license? (Provide Details if yes)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblMultiple" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>4. Are you/applicant an Income Tax Payer? </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblTaxPayer" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>5. Do you/Applicant pay Sales Tax? </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblSalesTax" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>6. Do you/Applicant pay Professional Tax?</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblProfessionalTax" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>7. Are you/applicant in any way related to a Government official working in Excise Department? </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblExise" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>8. Have you/applicant been punished or penalized or convicted for violation of any Excise laws/rules/orders?</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblPunished" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>9. Have You/applicant has ever been convicted by Court of Law for a non bailable offence?  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblapplicant" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div id="Excisedept" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Provide Details Here (if working)  </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblProvideDet" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="RulesOrder" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Provide Details Here (if punished or penalized or convicted for violation of any Excise laws/rules/orders) </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lbllawRule" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="convictedlaw" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Provide Details Here (if convicted by Court of Law for a non bailable offence)</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblbailable" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div id="div_47_BLR" runat="server" visible="false">
                                                            <div class="col-md-12 d-flex">
                                                                <label class="col-lg-12 col-form-label fw-bold">
                                                                    <span style="font-weight: 900; font-size: 20px;">Brand Details</span></label>
                                                            </div>
                                                            <div class="table-responsive">
                                                                <asp:GridView ID="gvBrandDetails" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                        <asp:BoundField HeaderText="Name of Brand" DataField="NameOfBrand" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Strength(Alcohol Content)" DataField="Strength" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Size" DataField="Size" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="No. of bottles(in one case)" DataField="NumberOfBottles" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="MRP (Rs.)" DataField="MRPRs" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Bulk liter (in one case)" DataField="BulkLiter" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="London Proof liter (in one case)" DataField="LandOnProof" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:BoundField HeaderText="Name & address of Distillery/ Brewery/Winery/Bottling Plant" DataField="BottlePlant" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>The Country of Origin of the Liquor  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLiquor" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>MRP (Rs.)</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblMRP" runat="server"></asp:Label>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">Brand Details</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GvLiquor" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Country of Origin" DataField="CountryName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Name of Brand" DataField="BrandName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>


                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Applying for Renewal of BIO Brands?  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblRenewalBIO" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="Brands" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>a. Original Year of Registration- From Date</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblRegFromDate" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="TodateReg" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>b. To Date</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblToDate" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>c. Name and address of the Firm  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblNameAddress" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div id="LegalMetrology" runat="server" visible="false">
                                                        <h4 class="card-title1 col-lg-12">Legal Metrology Department Details </h4>

                                                        <div class="col-md-12 d-flex">
                                                            <label class="col-lg-12 col-form-label fw-bold">
                                                                <span style="font-weight: 900; font-size: 20px;">Instrument Details</span></label>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GVLegalDept" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                                    <asp:BoundField HeaderText="Instrument type" DataField="CFOLMI_INSTRTYPE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Class" DataField="CFOLMI_INSTRCLASS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Capacity" DataField="CFOLMI_INSTRCAPACITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Make" DataField="CFOLMI_INSTRMAKE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Model" DataField="CFOLMI_INSTRMODELNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Serial No" DataField="CFOLMI_INSTRSLNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Product" DataField="CFOLMI_INSTRPRODUCT" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Quantity" DataField="CFOLMI_INSTRQUANTITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                        <h4 class="card-title1 col-lg-12">Other Details</h4>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Date of establishment </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblDateEstablishments" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Have you obtain any current registration number of factory/ shop/ establishment?  </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblRegNoFactory" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Have you obtain any current registration number of Municipal Trade licence/ADC?   </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblRegADC" runat="server"></asp:Label>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div id="Registration" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Date of registration </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblDateOfReg" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="RegNumber" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Current registration number </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblCurrentRegNo" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="ADCLicense" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Date of registration  </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblDateRegistration" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div id="DateReg" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Current Registration Number </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblNumberRegCurrent" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Is it a partnership firm?   </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblPartnership" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Is it a limited company? </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblCompany" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Name </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblNames" runat="server"></asp:Label>
                                                            </div>

                                                            <div class="col-md-2">
                                                                <label>Address   </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblAddressed" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <h4 class="card-title1 col-lg-12">Manufacturing Details</h4>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Weights </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblManuDetails" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Measures </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblManumeasure" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Weighting Instruments </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblWeighting" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Professional Tax registration Number </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblRegNumberTax" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>GST </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblGST" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>IT Number</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblITNumber" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Do you intend to import weights, etc. from places outside the State/Country? </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblStateimport" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="State" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Licence number </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblLICNumbers" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div id="Country" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Registration of Importer of Weights and Measures </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblRegImportMeasure" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Whether the item (s) proposed to be manufactured will be sold within the State or out side the state or both </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblManusold" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Have you applied previously for a dealer's licence,either in this State or elsewhere ? </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblDealerLic" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="DealerLic" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Give details </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblManufactureDetails" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <b>The number of persons employed/proposed to be employed</b>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Skilled </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblSkilled" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Semi-skilled </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblsemiSkill" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Unskilled </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblUnskill" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Specialist trained in the line </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblSpecialist" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Details of machinery, tools accessories, owned and used for manufacturing weights measures etc</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblManufactureWeight" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Details of foundry/workshop facilities arranged Whether ownership, long term lease etc </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lbllongtermlease" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div class="col-md-2">
                                                                <label>Facilities of steel casting and hardness testing Vital parts etc or other means</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblvitaothermeans" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Availability of electric energy </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblElectricEnergy" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Have you applied previously for a manufacturer's licence? </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblManuLic" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div id="applieddealer" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Give Details</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblManuGiveDetails" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Do you received any loan from Government or financial Institution? </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblFinancialloan" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="NameBanker" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Name of bankers </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblManuBank" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                            <div id="DetailsGet" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Give Details</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblLabourgiveDetails" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label>Have you sufficient stock of loan/test weights. etc.? </label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblLoanWeight" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="weightloan" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>Give Details  </label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblGiveDet" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                            <div class="col-md-2">
                                                                <label>Have you applied previously for a repairer's licence?</label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <spna class="dots">:</spna><asp:Label ID="lblRepairerLic" runat="server"></asp:Label>
                                                            </div>

                                                            <div id="License" runat="server" visible="false">
                                                                <div class="col-md-2">
                                                                    <label>When and with what results?</label>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <spna class="dots">:</spna><asp:Label ID="lblResults" runat="server"></asp:Label>
                                                                </div>
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

                                                            <asp:BoundField HeaderText="Unit ID" DataField="UNITID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Dept Process Status" DataField="STATUS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Dept Processed Date" DataField="PROCESSDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
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
