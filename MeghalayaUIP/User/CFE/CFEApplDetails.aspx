<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEApplDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEApplDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
    <!-- Page Wrapper -->
    <style>
        .col-md-10 {
            border: 1px solid #ccc;
            padding: 3px 15px;
            margin: 0px 0px;
        }
    </style>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <%--<li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx"></a></li>--%>
            <li class="breadcrumb-item active" aria-current="page">Pre-Establishment</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card flex-fill">

                <h4 class="mt-2 ml-4">View Details</h4>
                <div class="col-md-12 ">
                    <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
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
                                        class="collapsed">Pre-Establishment Application Details
                                    </a>

                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingOne" aria-expanded="false" style="height: 0px;">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Questionnaire Details</h3>
                                    </div>
                                    <div class="alldetails" id="bodypart">
                                        <div class="row mt-4">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Name of Unit</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblnameUnit" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Constitution of the unit</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblconstitution" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Proposal For</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblProposal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Proposed Location</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Mandalr</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblMandal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Village</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblVillage" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Total Extent of Land (in sq.m)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblExtentland" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Built up Area (Including Parking Cellars)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblBuilt" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Sector</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblSectors" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Line of Activity</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblActivity" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Pollution Category of Enterprise</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblPollution" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Type of Industry</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblIndustry" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Location of the uni</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblUnitLocation" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Whether land purchased from MIDCL</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblMIDCL" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Project Financials</h5>
                                                            <hr />
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Proposed Employment</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblproposeEMP" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Value of Land as per saleDeed(In INR)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblLANDINR" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Value of Building(In INR)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblBuildingINR" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Value of Plant & Machinery(In INR)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblMachineryINR" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Expected Annual Turnover(In INR)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblExpectTurnINR" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Total Project Cost(in Crores)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblTPCost" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Enterprise Category</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblEnterpriseCat" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <%--<div class="col-md-4 d-flex">
									<div class="col-md-6">Telephone</div>
									<div class="col-md-6">-</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Total extent of site area as per document(in Sq.mts)</div>
									<div class="col-md-6">295700.00</div>
								</div>--%>
                                                        </div>

                                                        <%--<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Proposed area for development(in Sq mts)</div>
									<div class="col-md-6">5636.00</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Total built-up area(in Sq.mts)</div>
									<div class="col-md-6">47243.00</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Existing width of approach road(in feet)</div>
									<div class="col-md-6">67.00</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Type of Approach Road</div>
									<div class="col-md-6">Travel</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Land comes under</div>
									<div class="col-md-6">IALA (TSIIC)</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Case type</div>
									<div class="col-md-6">Partnership</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Category of Industry</div>
									<div class="col-md-6">White</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Caste</div>
									<div class="col-md-6">OC</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Building Approval</div>
									<div class="col-md-6">New</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Differently Abled</div>
									<div class="col-md-6">No</div>
								</div>

							</div>--%>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row">
                                            <div class="col-xl-8 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>ENTREPRENUER&Land</h5>
                                                            <hr />
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Name of Company</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblBNameCompany" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Type of Company</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblTypecompany" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Company Proposal</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCompanyProposal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Category of Registration</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Registration No</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblRegistration" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Registration Date(dd-MM-yyyy)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Type of Factory</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFactory" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <%--<div class="col-md-6 d-flex">
									<div class="col-md-6">Mandal</div>
									<div class="col-md-6">Uppal</div>
								</div>--%>
                                                        </div>
                                                        <%--<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Email-ID</div>
									<div class="col-md-6">kalyan@gmail.com</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Telephone</div>
									<div class="col-md-6">040-2548 5698</div>
								</div>
							</div>--%>
                                                    </div>
                                                </div>
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Authorised Representative Details</h5>
                                                            <hr />
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Name</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">S/o.D/o.W/o</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblso" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Email</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Mobile No</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblMobile" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Alternative MobileNo</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblAlternative" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Landline Tel No</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lbllandline" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Door No</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblDoor" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Locality</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblLocality" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">District</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblDistrict" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Mandal</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblMandals" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Village/Town</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblVillages" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Pincode</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblPincode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Differently Abled</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblAbled" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Women Entrepreneur</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblWomen" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-xl-4 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Unit Location Details</h5>
                                                            <hr />
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Proposed Area for Development(in Sq. mts)</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblDevelopment" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <%--	<div class="col-md-12 d-flex tablepadding1">
								Proposed Investment
							</div>--%>

                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Architect License No</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblARCLIC" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">>Architect Name</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblARCNAME" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Architect Mobile No</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblARCMOBILE" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Structural Engineer Name</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblStrEng" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding1">
                                                            <div class="col-md-6">Structural Mobile No</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblStrMobile" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding1">
                                                            <div class="col-md-6">Structural License No</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblStrLICNO" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding1">
                                                            <div class="col-md-6">Type of Approach Road</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblApproacheRoad" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding1">
                                                            <div class="col-md-6">Existing Width of Approach Road(in feet)</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblWidening" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding1" id="Extend" runat="server" visible="false">
                                                            <div class="col-md-6">Extend of affected area in sq.mts</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblAffectedArea" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            Road Cutting Details
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding1">
                                                            <div class="col-md-6">Length of road to be cut:(in mtrs)</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblroadlength" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-4 d-flex tablepadding1">
                                                            <div class="col-md-6">Number of locations</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblNumber" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xl-8 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>LINE OF ACTIVITY</h5>
                                                            <hr />
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding2">
                                                            <div class="col-md-6">Line of Activity</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lbllineActivity" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div id="divManf" runat="server" visible="true">
                                                            <div class="col-md-12 tablepadding4">
                                                                <b>Details Of Manufacture Items</b>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-xl-8 col-sm-12 col-12">
                                                                    <div class="card">
                                                                        <div class="card-body">
                                                                            <div align="center">
                                                                                <asp:GridView ID="gvManufacture" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                            <ItemTemplate>
                                                                                                <%# Container.DataItemIndex +1 %>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle Width="20px" />
                                                                                        </asp:TemplateField>
                                                                                        <%--  <asp:TemplateField HeaderText="Item Description" Visible="true" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="left">
                                                                                            <ItemTemplate>
                                                                                                <itemstyle horizontalalign="Center" />
                                                                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ITEMS") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>--%>
                                                                                        <asp:BoundField DataField="CFELM_ITEMNAME" HeaderText="Name of Product" />
                                                                                        <asp:BoundField DataField="CFELM_ITEMANNUALCAPACITY" HeaderText="Annual Manufacturing Capacity (in tonne)" />
                                                                                        <asp:BoundField DataField="CFELM_ITEMVALUE" HeaderText="Appox. value (₹)" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 tablepadding4">
                                                            <b>Details Of Raw Materials Used in Process:</b>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-xl-8 col-sm-12 col-12">
                                                                <div class="card">
                                                                    <div class="card-body">
                                                                        <div align="center">
                                                                            <asp:GridView ID="gvRwaMaterial" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                                Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                        <ItemTemplate>
                                                                                            <%# Container.DataItemIndex +1 %>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                        <ItemStyle Width="20px" />
                                                                                    </asp:TemplateField>
                                                                                    <%--  <asp:TemplateField HeaderText="Item Description" Visible="true" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="left">
                                                                                        <ItemTemplate>
                                                                                            <itemstyle horizontalalign="Center" />
                                                                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("CFELM_ITEMNAME") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>--%>
                                                                                    <asp:BoundField DataField="CFERM_ITEMNAME" HeaderText="Name of major raw material" />
                                                                                    <asp:BoundField DataField="CFERM_ITEMANNUALCAPACITY" HeaderText="Annual manufacturing capacity (in tonne)" />
                                                                                    <asp:BoundField DataField="CFERM_ITEMVALUE" HeaderText="Appox. value (₹ in lakh)" />
                                                                                    <asp:BoundField DataField="CFERM_SOURCEOFSUPPLY" HeaderText="Source(s) of supply" />

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
                                            <div class="col-xl-4 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>PROBABLE EMPLOYMENT POTENTIAL(In NO. of persons to be employed)</h5>
                                                            <hr />
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding3">
                                                            <div class="col-md-4"></div>
                                                            <div class="col-md-4">Male</div>
                                                            <div class="col-md-4">FeMale</div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding3">
                                                            <div class="col-md-4">DIRECT</div>
                                                            <div class="col-md-4">
                                                                <asp:Label ID="lblDirectMale" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:Label ID="lblDirectFemale" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding3">
                                                            <div class="col-md-4">INDIRECT</div>
                                                            <div class="col-md-4">
                                                                <asp:Label ID="InMale" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:Label ID="InFemale" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 mb-5 d-flex tablepadding3">
                                                            <div class="col-md-4">TOTAL</div>
                                                            <div class="col-md-4">
                                                                <asp:Label ID="lblEmployees" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <asp:Label ID="lblother" runat="server"></asp:Label>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row">
                                            <div id="PowerDetails" runat="server" visible="false">
                                                <div class="col-xl-8 col-sm-12 col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="col-md-12">
                                                                <h5>Power</h5>
                                                                <hr />
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Connected Load in HP</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblHP" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Contracted Maximum Demand in KVA</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblMaxDemand" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 mb-4 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Required Voltage Level</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblVoltageLevel" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex" id="services" runat="server" visible="false">
                                                                    <div class="col-md-6">Any Other Services Existing in the Same Premises</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPermise" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <h6 class="ml-3"><b>Proposed maximum working hours</b></h6>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Per Day</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDay" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Per Month</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblMonth" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Expected Month and Year of Trial Production(DD/MM/YYYY)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblYear" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Probable Date of Requirement of Power Supply(DD/MM/YYYY)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPowersupply" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Quantum of energy/load required (in KW)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblQuantum" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Proposed source of energy/load</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblEngeryLaod" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-xl-4 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5></h5>
                                                            <hr />
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6"></div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6"></div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6"></div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6"></div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6"></div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6"></div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row">
                                            <div id="waterConn" runat="server" visible="false">
                                                <div class="col-xl-8 col-sm-12 col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="col-md-12">
                                                                <h5>Water</h5>
                                                                <hr />
                                                            </div>
                                                            <h6 class="ml-3"><b>Water Consumption</b></h6>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Drinking Water ( in KL/Day )</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDrink" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Water for Processing(Industrial use) ( in KL/Day )</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblWaterIndu" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Quantity of Water Required for Consumptive Use (in KL/Day)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblReqWater" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Quantity of Water Required for Non-Consumptive Use (in KL/Day)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblNonConsumptive" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div id="tanker" runat="server" visible="false">
                                                                <h6 class="ml-3"><b>Distance of the Water tank from the road (approx):-</b></h6>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Overhead</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblOverhead" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Underground</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblUnderground" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">
                                                                            Choose Available Tanker Capacity[In litres]										
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblTankerCap" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div id="WaterConnection" runat="server" visible="true">

                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Type Of Water Connection </div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblConnection" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex" id="holdno" runat="server" visible="false">
                                                                        <div class="col-md-6">Holding No</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblHold" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding" id="ward" runat="server" visible="false">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Select Ward No </div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblWardNo" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div id="CommercialWater" runat="server" visible="true">
                                                                <h6 class="ml-3"><b>Commercial Establishment</b></h6>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Sub Divisional Office for Application </div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblSubDivision" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Number of persons working in the premise</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblPremise" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Water requirement per day demand </div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblReqDemand" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Any other information </div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblInformations" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <h6 class="ml-3"><b>Water Connection Details</b></h6>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">District </div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblDistrictWater" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Mandal</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="MandalWater" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Village</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblVillageWater" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Locality</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblLocalitywater" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Nearest Landmark</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblNear" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Pincode</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblPinNumber" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Purpose for which connection is required</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblReqConn" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Type of connection</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblTypeCon" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex" id="NominalDN" runat="server" visible="false">
                                                                        <div class="col-md-6">Size of pipe connection for domestic(Diameter Nominal DN (mm))</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lbldomestic" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex" id="DiameterDN" runat="server" visible="false">
                                                                        <div class="col-md-6">Size of pipe connection(Diameter Nominal DN (mm))</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblDiameter" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>



                                                            </div>



                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="Pollutioncontrol" runat="server" visible="false">
                                                <div class="col-xl-4 col-sm-12 col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="col-md-12">
                                                                <h5>HAZARDOUSWASTEDETAILS</h5>
                                                                <hr />
                                                            </div>
                                                            <b>Authorization Required</b>

                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Authorization required for (Please tick appropriate activity or activities</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblReqtrick" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <b>Nature and Quantity</b>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Nature and Quantity to waste handled per annum (in Metric Tons)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblQuantitywaste" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Nature and Quantity to waste stored at any time (in Metric Tons)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblMetrictons" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Nature and Quantity to waste handled per annum (in Kilo Litre)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblhandleannum" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Nature and Quantity to waste stored at any time (in Kilo Litre)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblWastestored" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 mb-5 d-flex tablepadding1">
                                                                <div class="col-md-6">
                                                                    Year of commissioning and commence of production
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblYearProduct" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Whether the industry works</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblindustrywork" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row">
                                            <div id="Fires" runat="server" visible="false">
                                                <div class="col-xl-8 col-sm-12 col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="col-md-12">
                                                                <h5>Fire</h5>
                                                                <hr />
                                                            </div>
                                                            <div class="col-md-12">
                                                                <h5>Location and address of the proposed building </h5>
                                                                <hr />
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">District</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDistrics" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Mandal</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblMan" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Village</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblVill" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Locality</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lbllocal" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Nearest Landmark</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lbNear" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Pincode</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPincodes" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 tablepadding4">
                                                                <b>Other Details</b>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Height of the building (in mtrs.)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblheight" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Height of each floor (in mtrs.)*(min 2.9 mtrs)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblEachfloor" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Plot Area (in Sq m)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblArea" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Proposed build up area (in Sq m)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblbuild" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Proposed Drive way (Breadth with units in meters) </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lbldriveway" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Category of Building for which Fire Clearance is applied</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblcategoryBuild" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Fee Amount in Rs (Note: This is an aprrox. value. The amount may change tentatively)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="feeamount" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6"></div>
                                                                    <div class="col-md-6">-</div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 tablepadding4">
                                                                <b>Details of surrounding occupancies and their probable distance from the proposed building</b>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">East</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblEast" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">
                                                                        Distance from proposed Building (in meters) 
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDistanceprop" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">West</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblwest" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Distance from proposed Building (in meters)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblbUILDDIST" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">North</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblNorth" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Distance from proposed Building (in meters)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDistBuild" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">South</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblSouth" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Distance from proposed Building (in meters)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblbuildProp" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Distance from the nearest Fire Station (in meters)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblFireStation" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="ForestDet" runat="server" visible="false">
                                                <div class="col-xl-4 col-sm-12 col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="col-md-12">
                                                                <h5>Forest Details</h5>
                                                                <hr />
                                                            </div>
                                                            <div class="col-md-12 tablepadding4">
                                                                <b>A. Forest</b>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Species</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblspice" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Timber Length</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblLength" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Timber Volume</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblvolume" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Timber Girth</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblGirth" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Estimated Firewood</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFirewood" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Pole</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblpole" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 tablepadding4">
                                                                <b>B. Boundary Description</b>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">North</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblNorths" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">East</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblEasts" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">West</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblWests" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">South</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblSouths" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 tablepadding4">
                                                                <b>C. GPS Coordinates Details</b>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Establishment Location Address(For which application is being Done)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Latitude</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lbllatitude" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Degrees(L)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblDegreess" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Minutes(L)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblMinte" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Seconds(L)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblseconds" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Longitude</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lbllongitude" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Degrees</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblDegrees" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Minutes</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblMinutes" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Seconds</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblsecond" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">GPS Coordinates (Description)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCoordinates" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Purpose of Application</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblApplication" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Forest Division</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblDivision" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Any other information</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblinformation" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div id="LabourDet" runat="server" visible="false">
                                                <div class="col-xl-12 col-sm-12 col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="col-md-12">
                                                                <h5>Labour Details</h5>
                                                                <hr />
                                                            </div>

                                                            <div class="col-md-12 mb-4 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Category of Establishment</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblEstablish" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <h6 class="ml-3"><b>Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No: </b></h6>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Name</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblNames" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Father's Name</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblFather" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Age</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblAge" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Designation</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Mobile</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblMobiles" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Email</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblMail" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Distric</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lbldist" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Mandal</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblMandalsmandal" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Village</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblVILLAS" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Door</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDoors" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Locality</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblLocalitys" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Pincode</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPins" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="row" style="padding-left: 20px" id="divsupervision" runat="server" visible="false">
                                                                <h6 class="ml-3"><b>Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment </b></h6>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Name</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblMangerName" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Father's Name</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="ManagerFather" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Age</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="ManagerAge" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Designation</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="ManagerDesignation" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Mobile</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblManagerMobile" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Email</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblManagerEmail" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">District</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblManagerDistrict" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Mandal</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblManagerMandal" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Village</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblManagerVillage" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Door</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblManagerDoor" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Locality</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblManagerLocality" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Pincode</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblManagerPincode" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="row" style="padding-left: 20px" id="divContrLabr" runat="server" visible="false">
                                                                <div class="col-md-12 d-flex">
                                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Particulars of Contract Labour</span></label>

                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-xl-8 col-sm-12 col-12">
                                                                        <div class="card">
                                                                            <div class="card-body">
                                                                                <div align="center">
                                                                                    <asp:GridView ID="GVLabour" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                                        Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex +1 %>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                <ItemStyle Width="20px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Item Description" Visible="true" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="left">
                                                                                                <ItemTemplate>
                                                                                                    <itemstyle horizontalalign="Center" />
                                                                                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ITEMS") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="CFECL_CONTRACTORNAMEADDRESS" HeaderText="Name and Address" />
                                                                                            <asp:BoundField DataField="CFECL_WORKNAMENATURELOCATION" HeaderText="Name,location of work Contract Labour employed" />
                                                                                            <asp:BoundField DataField="CFECL_MAXCONTRACTLABOUR" HeaderText="Maximum No. of Contract Labour establishment on date" />
                                                                                            <asp:BoundField DataField="CFECL_CONTRACTDURATION" HeaderText="Duration of proposed contract work in a number of days(Min 1 and Max 179)" />
                                                                                            <asp:BoundField DataField="CFECL_COMMENCEMENTDATEOFWORK" HeaderText="Estimated date of commencement of work" />
                                                                                            <asp:BoundField DataField="CFECL_COMPLETIONDATEOFWORK" HeaderText="Estimated date of completion of work" />
                                                                                            <asp:BoundField DataField="CFECL_TERMINATIONDATEOFEMP" HeaderText="Estimated date of termination Contract Labour" />
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="row" style="padding-left: 20px" id="divMigrLabr" runat="server" visible="false">
                                                                <div class="col-md-12 d-flex">
                                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Particulars of Migrant Workmen</span></label>

                                                                </div>

                                                                <div class="row">
                                                                    <div class="col-xl-8 col-sm-12 col-12">
                                                                        <div class="card">
                                                                            <div class="card-body">
                                                                                <div align="center">
                                                                                    <asp:GridView ID="GVMigrant" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                                        Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex +1 %>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                                <ItemStyle Width="20px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Item Description" Visible="true" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="left">
                                                                                                <ItemTemplate>
                                                                                                    <itemstyle horizontalalign="Center" />
                                                                                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ITEMS") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="CFEMW_CONTRACTORNAMEADDRESS" HeaderText="Name and Address of the Contractor" />
                                                                                            <asp:BoundField DataField="CFEMW_MIGRANTNAMENATURELOCATION" HeaderText="Name,location of work Contract Labour employed Migrant" />
                                                                                            <asp:BoundField DataField="CFEMW_MAXCONTRACTMIGRANT" HeaderText="Maximum No. of Migrant establishment on date" />
                                                                                            <asp:BoundField DataField="CFEMW_CONTRACTDURATION" HeaderText="Duration of proposed contract work in a number of days(Min 1 and Max 179)" />
                                                                                            <asp:BoundField DataField="CFEMW_COMMENCEMENTDATE" HeaderText="Estimated date of commencement of work" />
                                                                                            <asp:BoundField DataField="CFEMW_COMPLETIONDATEOFWORK" HeaderText="Estimated date of completion of work" />
                                                                                            <asp:BoundField DataField="CFEMW_TERMINATIONDATEOFEMPMigrant" HeaderText="Estimated date of termination Migrant WorkMen" />
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                            <div class="row" style="padding-left: 20px" id="div4questions" runat="server" visible="false">
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Nature of work in which contract labour is employed or is to be employed in the establishment</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblNatureOfEmp" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Estimated date of commencement of building or other construction work</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblEstDateBuild" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Maximum number of Contract Employees / building workers to be employed on any day</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblContractEmp" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Estimated date of completion of building or other construction work</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblBuildingWork" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row" style="padding-left: 20px" id="div5questions" runat="server" visible="false">
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Maximum Number of migrant workmen proposed to be employed in the establishment on any date</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblMigrantWorkmen" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Whether the contractor was convicted of any offence within the preceding five years. If so give details</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblPreceding5Years" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Whether there was any order against the contractor revoking or suspending license or forefeiting security deposits in respect of an earlier contract . If so the date of such order.</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblRevokingLic" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Whether the contractor has worked in any other establishment within the past five years, If so, give details of the Principal Emplyer,Establishments and nature of work</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblEstPast5Years" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Type of business, trade, industry, manufacture or occupation, which is carried on in the establishment</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblBusiness" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="row" style="padding-left: 20px" id="divContractorDtls" runat="server" visible="false">
                                                                <div class="col-md-12 tablepadding4">
                                                                    <b>Name and address of the contractor(including his father's/ husband's name in case of individuals):</b>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Name of the Contractor/Firm</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblcontractor" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Father's Name</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblfafname" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Age</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblages" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Mobileno</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblMobileno" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Emailid</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">District</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblDistr" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Mandal</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lbltaluka" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Village</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblVillvillage" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Door</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblDoorno" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Locality</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lbllocals" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Pincode</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblPincodeno" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row" style="padding-left: 20px" id="divAgentDtls" runat="server" visible="false">

                                                                <div class="col-md-12 d-flex">
                                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Name and address of the agent or manager of the contractor at the work-site</span></label>
                                                                </div>

                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Name</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblAgentName" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Door No.</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblAgentDoor" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Locality</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblAgentLocality" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">District</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblAgentDistrict" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Mandal</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblAgentMandal" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Village</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="AgetVillage" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex tablepadding">
                                                                    <div class="col-md-6 d-flex">
                                                                        <div class="col-md-6">Pincode</div>
                                                                        <div class="col-md-6">
                                                                            <asp:Label ID="lblAgentPincode" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>




                                                            </div>



                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div id="Explosive" runat="server" visible="false">
                                                <div class="col-xl-8 col-sm-12 col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="col-md-12">
                                                                <h5>EXPLOSIVE DETAILS</h5>
                                                                <hr />
                                                            </div>
                                                            <div class="col-md-12">
                                                                <h5>Quantity of Explosives proposed to be manufactured/possessed for the purpose stated at serial No. 1 above </h5>
                                                                <hr />
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-xl-8 col-sm-12 col-12">
                                                                    <div class="card">
                                                                        <div class="card-body">
                                                                            <div align="center">
                                                                                <asp:GridView ID="GVEXPLOSIVE" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                            <ItemTemplate>
                                                                                                <%# Container.DataItemIndex +1 %>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle Width="20px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="CFEME_NAME" HeaderText="Name and Description" />
                                                                                        <asp:BoundField DataField="CFEME_CLASS" HeaderText="Class" />
                                                                                        <asp:BoundField DataField="CFEME_DIVISION" HeaderText="Division if any" />
                                                                                        <asp:BoundField DataField="CFEME_QUANTITYTIME" HeaderText="Quantity(at any one time)" />
                                                                                        <asp:BoundField DataField="CFEME_QUANTITYMONTH" HeaderText="Quantity(at any one month)" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Details of site where explosives will be used and distance of site of use from the storage premises (in case of licence for use)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblExplosive" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Details of explosives road van which will be used for transportation of explosives (in case of no objection certificate for road van)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblRoadvan" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <b>Additional information</b>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">(i)I or We have not been convicted under any offence or ordered to execute bond under Chapter VIII of Code of Criminal Procedure, 1973, during the last 10 years ( If yes, please give details)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblCriminal" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex" id="Details" runat="server" visible="false">
                                                                    <div class="col-md-6">Details</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblChapterDetails" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">(ii) Particulars of other licenses: I / We possess under Explosives Act, 1884 (Note: Please write the licence no(s), if any)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblLicPossess" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex" id="LicDetails" runat="server" visible="false">
                                                                    <div class="col-md-6">Details</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDetails" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">(iii) I/We have obtained approval as required under rule 101 from the competent authority: (Note: Please enclose the approval letter, approved drawing(s), other enclosures, if any)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblApprovals" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex" id="approvaldet" runat="server" visible="false">
                                                                    <div class="col-md-6">Details</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblapprovalDet" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">(iv) Any other relevant information</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblRelevant" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="FuelDet" runat="server" visible="false">
                                                <div class="col-xl-4 col-sm-12 col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="col-md-12">
                                                                <h5>Fuel Details</h5>
                                                                <hr />
                                                            </div>
                                                            <div class="col-md-12 tablepadding4">
                                                                <b>Applicant Detail's</b>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Whether No Objection Certificate (NOC) is required for setting up of Petrol Pump?</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblPetrolNoc" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">No Objection Certificate (NOC) required for (mention the purpose clearly)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFuelNoc" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <b>Details of the location</b>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">District</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFuelDistrict" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Mandal</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFuelMandal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Village</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFuelVillage" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Located in which Road?</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblRoad" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">1.Name of Establishment </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblNameESt" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">2. Land Holding Certificate No</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblHoldingCert" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">3.Whether land is under Lease?</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblUnderLease" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">4 (i) If Yes, Please enter Lease Deed Registration No </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblDeedRegNo" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">5 Area of Land as per Land Holding Certificate No </div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblLandHolding" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 tablepadding4">
                                                                <b>6.Description of Land with Boundaries</b>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">(i) North</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFuelNorth" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">(ii) East</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFuelEast" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">(iii) South</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFuelSouth" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">(iv) West</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFuelwest" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <b>7.Area for construction of Retail Outlet measuring (in meters)</b>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">(i) Frontage</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblFrontage" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">(ii) Depth</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblDepth" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Degrees</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="Label39" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Minutes</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="Label40" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Seconds</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="Label41" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">GPS Coordinates (Description)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="Label42" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Purpose of Application</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="Label43" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Forest Division</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="Label44" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Any other information</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="Label45" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div id="DGSETDET" runat="server" visible="false">
                                                <div class="col-xl-8 col-sm-12 col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="col-md-12">
                                                                <h5>DGSETDETAILS</h5>
                                                                <hr />
                                                            </div>
                                                            <div class="col-md-12">
                                                                <h5>Location of D.G. Set with Full Postal Address </h5>
                                                                <hr />
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Door No/Survey No</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGSurveyNo" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Locality</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGLocality" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Landmark</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGLandmark" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">District</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGDistrict" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Mandal</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGMandal" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Village</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGVillage" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">PinCode</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGPincode" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6"></div>
                                                                    <div class="col-md-6">
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 tablepadding4">
                                                                <b>Whether Supply from the Supplier Licensee is Available</b>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Name of Supplier</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGNameSupply" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Total Connected Load (in KW)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblLoadConnect" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Total Proposed Load to be Supplied from D.G. Sets (in KW)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblTotalLoad" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Details of Interlock/Change over arrangement provided to prevent accidental paralleling of D.G. Sets to the Supply System</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblInterlock" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <b>Detail of Load proposed to be supplied from D.G Sets</b>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Motor (AC) </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="LBLdgMotor" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Light and Fans</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGLight" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Other (to be specified)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGOther" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6"></div>
                                                                    <div class="col-md-6">-</div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 tablepadding4">
                                                                <b>Running Mode and Expected Date of Installation/Completion/Commissioning</b>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Generators Running Mode  (in case more than one will be installed)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblGenRunMode" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">
                                                                        Expected Date of Completion of work
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblExpectedCompletion" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Expected Date of starting of Installation work</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDateInstall" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Expected Date of Commissioning</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblExpectedDate" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <b>Supervisor/Contractor/Operator Details</b>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Name of the Supervisor</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGNameSup" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Supervisor License Number</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblSupLicNo" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Name of the Contractor who will carry out the internal electricfication</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblinternalName" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Contractor License Number</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblConLicNo" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Name of the Person who will be authorized to operate the D.G Sets</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGSETName" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <b>DG Set Details</b>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Capacity</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblDGCapacity" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Capacity is in KW/KVA</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblCapcity" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Power Factor</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPowerFactor" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Rated Voltage (KV)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblRatedvtg" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Engine Make/Serial No</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblEngineSerial" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Alternator Make/Serial No</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblMakeserial" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <b>Details of earthing (Rule 41) the particulars are required in respect of item 12 of the main proforma</b>

                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Type of Equipment</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblEquipment" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Size & materials of earthing conductor</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblEarthing" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">No. of independent conductor path</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblIndependent" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Type & size electrode and length/dia</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblelectrode" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Impedance of the systems in ohm </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblSystemohm" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Total Impedance of the system in ohm </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblImpedance" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Type of lighting</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblLighting" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Insulation Test of Alternator </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblAlternator" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <b>Earth Tester and Megger Details</b>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Earth Tester No</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblEarhtTester" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Make (Earth Tester) </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblMakeEarth" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Range (Earth Tester)</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblRangeEarth" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Megger No </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblMeggerNo" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Make (Megger) </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblMake" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Range (Megger) </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblRange" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>


                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-left: 20px" id="CEIGDET" runat="server" visible="false">
                                                <div class="col-xl-4 col-sm-12 col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="col-md-12">
                                                                <h5>POWERCEIG DETAILS</h5>
                                                                <hr />
                                                            </div>
                                                            <div class="col-md-12 tablepadding4">
                                                                <b>Contracted Maximum Demand in KVA</b>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Already installed</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblAlreadyInstall" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Proposed</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCEIGProposed" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Total</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCEIGTotal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <b>Connected Load in KW/HP</b>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Type of Connected Load</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblTypeLoad" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Already installed</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblAlredy" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Proposed</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblProposed" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Total</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Regulation</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblRegulation" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1" id="divvoltages" runat="server" visible="false">
                                                                <div class="col-md-6">Voltage</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCEIGVoltage" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1" id="divpowerplants1" runat="server" visible="false">
                                                                <div class="col-md-6">Plant</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblPlant" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1" id="divpowerplants2" runat="server" visible="false">
                                                                <div class="col-md-6">Aggregate Transformer Capacity(ATC) (in KVA)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblATC" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Proposed Location of Factory</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblLocatFactory" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Survey No</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblSurveyNo" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Extent</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblExtent" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Distric</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCEIGDistrict" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Mandal</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCEIGMandal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Village</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCEIGVillage" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Street Name</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblStreetName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Pincode</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCEIGPin" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Telephone(incl STD Code)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Nearest Telephone No</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblNaerest" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding1">
                                                                <div class="col-md-6">Date of Commencement of Production(dd-MMM-yyyy)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblDateCommence" runat="server"></asp:Label>
                                                                </div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="row" style="padding-left: 20px" id="TaxDet" runat="server" visible="false">
                                                <div class="col-xl-12 col-sm-12 col-12">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="col-md-12">
                                                                <h5>Proffessional Tax Details</h5>
                                                                <hr />
                                                            </div>
                                                            <b>Application Type</b>

                                                            <div class="col-md-12 mb-4 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Apply As</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPTApplyAs" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <h6 class="ml-3"><b>Establishment Details </b></h6>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Name of Establishment</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lbPTEstbName" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Address of Establishment</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPTEstbAddress" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">District of Establishment </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPTDistrict" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Pin Code of Establishment</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPTpincodeel13" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Total number of Employees working in Establishment</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPTEmp" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Date of commencement</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPTDateofComm" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Constitution of Establishment</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPTConst" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Description of Goods and Services supplied by the Establishment</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="lblPTGoodsnServc" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Additional Place of Business</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label18" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-xl-8 col-sm-12 col-12">
                                                                    <div class="card">
                                                                        <div class="card-body">
                                                                            <div align="center">
                                                                                <asp:GridView ID="GVState" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                                    Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                                            <ItemTemplate>
                                                                                                <%# Container.DataItemIndex +1 %>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle Width="20px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="CFEPB_PLACEOFBUSINESS" HeaderText="Place of Business" />
                                                                                        <asp:BoundField DataField="CFEPB_ADDRESS" HeaderText="Address" />
                                                                                        <asp:BoundField DataField="CFEPB_DISTRIC" HeaderText="District" />
                                                                                        <asp:BoundField DataField="CFEPB_TOTALWORKINGEMP" HeaderText="Total working employees" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <h6 class="ml-3"><b>Applicant's Designation </b></h6>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Designation </div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label19" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex">
                                                                    <div class="col-md-6">Do you have registration under any other act?</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label20" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex tablepadding">
                                                                <div class="col-md-6 d-flex" id="RegistrationType" runat="server" visible="false">
                                                                    <div class="col-md-6">Registration Type</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label21" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 d-flex" id="RegNo" runat="server" visible="false">
                                                                    <div class="col-md-6">Regisration No</div>
                                                                    <div class="col-md-6">
                                                                        <asp:Label ID="Label22" runat="server"></asp:Label>
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
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdcfeattachment" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-hover" ForeColor="#333333"
                                                            GridLines="Both" Width="100%" EnableModelValidation="True" ShowHeaderWhenEmpty="true">
                                                            <RowStyle />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="File Name" DataField="CFMA_NAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:TemplateField HeaderText="View">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink runat="server" ID="hplApplied" Target="_blank" Text='<%#Eval("CFEA_FILENAME")%>' NavigateUrl='<%#Eval("FILENAME")%>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
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
                                                                <%--<asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />--%>
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
                                                                <asp:BoundField HeaderText="File Name" DataField="IDD_FIRSTNAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="View" DataField="IDD_LASTNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
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
                                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-hover" ForeColor="#333333"
                                                                GridLines="Both" Width="100%" EnableModelValidation="True">
                                                                <RowStyle />

                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField HeaderText="Department ID" DataField="Dept_Id" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="false" />
                                                                    <asp:BoundField HeaderText="Unit ID" DataField="PRDA_UNITID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Department Name" DataField="MD_DEPT_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Approval Name" DataField="ApprovalName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Dept Process Status" DataField="STATUSDESCRIPTION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Dept Processed Date" DataField="PRDA_DEPTPROCESSDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /Page Wrapper -->


</asp:Content>
