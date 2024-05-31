<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="CFEApplDeptProcess.aspx.cs" Inherits="MeghalayaUIP.Dept.CFE.CFEApplDeptProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
    <!-- Page Wrapper -->
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card flex-fill">

                <h4 class="mt-2 ml-4">View Details</h4>
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
                <div class="col-md-12">
                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingOne">
                                <h4 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion"
                                        href="#collapseOne" aria-expanded="false" aria-controls="collapseOne"
                                        class="collapsed">CFE Application Details
                                    </a>

                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingOne" aria-expanded="false" style="height: 0px;">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>CFE Questionnaire Details</h3>
                                    </div>
                                    <div class="alldetails" id="bodypart">
                                        <div class="row mt-4">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Name of Unit</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblnameUnit" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Constitution of the unit</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblconstitution" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Proposal For</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblProposal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Proposed Location</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Mandalr</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblMandal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Village</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblVillage" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Total Extent of Land (in sq.m)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblExtentland" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Built up Area (Including Parking Cellars)</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblBuilt" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Sector</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblSectors" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
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
                                            <%--   <div class="col-xl-4 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>PROPOSED LOCATION OF UNIT ADDRESS</h5>
                                                            <hr />
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Location of Factory</div>
                                                            <div class="col-md-6">Rangareddy</div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>--%>
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
                                                        <div class="col-md-12 mb-4 d-flex tablepadding1">
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
                                                        <div class="col-md-12 tablepadding4">
                                                            <b>Details Of Manufacture Items</b>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding2">
                                                            <div class="col-md-2">Name of Product</div>
                                                            <div class="col-md-3">Annual Manufacturing Capacity (in Tons)</div>
                                                            <div class="col-md-2">Approx. Value in Lakh</div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding2">
                                                            <div class="col-md-2">
                                                                <asp:Label ID="lblitem" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:Label ID="lblQuantityper" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <asp:Label ID="lblQuantity" runat="server"></asp:Label>
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
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Any Other Services Existing in the Same Premises</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblPermise" runat="server"></asp:Label>
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
                                                            <h5>Proposed maximum working hours</h5>
                                                            <hr />
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Per Month</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblMonth" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Expected Month and Year of Trial Production(DD/MM/YYYY)</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblYear" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Probable Date of Requirement of Power Supply(DD/MM/YYYY)</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblPowersupply" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Quantum of energy/load required (in KW)</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblQuantum" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Proposed source of energy/load</div>
                                                            <div class="col-md-6">
                                                                <asp:Label ID="lblEngeryLaod" runat="server"></asp:Label>
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
                                                            <h5>Water</h5>
                                                            <hr />
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Water supply from</div>
                                                                <div class="col-md-6">New Bore well, Rivers/Canals </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Water requirement</div>
                                                                <div class="col-md-6">No</div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Drinking water ( in KL/Day )</div>
                                                                <div class="col-md-6">1.00</div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Water for processing(Industrial use) ( in KL/Day )</div>
                                                                <div class="col-md-6">1.00</div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Source of water</div>
                                                                <div class="col-md-6">watertank</div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Requirement of water (in KL/Day)</div>
                                                                <div class="col-md-6">1209.00</div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">
                                                                    Quantity of water water required for consumptive use (in
										KL/Day)
                                                                </div>
                                                                <div class="col-md-6">1.00</div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Quantity of required for non-consumptive use (in KL/Day)</div>
                                                                <div class="col-md-6">9.00</div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-xl-4 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Transformer protection measures</h5>
                                                            <hr />
                                                        </div>

                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">5 Ltrs. From Trolley *</div>
                                                            <div class="col-md-6">No</div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Fencing</div>
                                                            <div class="col-md-6">-</div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Soak pit</div>
                                                            <div class="col-md-6">No</div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Lightening protection</div>
                                                            <div class="col-md-6">No</div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding1">
                                                            <div class="col-md-6">Control Room</div>
                                                            <div class="col-md-6">No</div>
                                                        </div>
                                                        <div class="col-md-12 mb-5 d-flex tablepadding1">
                                                            <div class="col-md-6">
                                                                Whether the Hydraulic Platform can be moved all around the bldg
                                                            </div>
                                                            <div class="col-md-6">No</div>
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
                                                        <%--<div class="col-md-12 tablepadding4">
								<b>Means of Escape</b>
							</div>--%>

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

                                        <div class="row">
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
                                                                <div class="col-md-6">Distric</div>
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
                                                                                        <asp:HyperLink runat="server" ID="hplApplied" Target="_blank" Text='<%#Eval("CFEA_FILENAME")%>' NavigateUrl='<%#Eval("FILENAME")%>'/>
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
                        <div class="panel panel-default" id="verifypanel" runat="server" visible="true">
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

                                <div class="card" id="scrutiny" runat="server" visible="false">
                                    <div class="table-responsive">
                                        <table align="Center" style="width: 100%; border-color: brown; align-content: center;" class="table table-bordered mb-10">
                                            <tr style="border-color: brown; background-color: midnightblue; color: azure">
                                                <td><b>Name</b></td>
                                                <td><b>Unit Name</b></td>
                                                <td><b>Application No</b></td>
                                                <td style="width: 150px"><b>Application Date</b></td>
                                                <td style="width: 200px"><b>Select Action</b></td>
                                                <td id="tdquryorrej" runat="server" visible="false"><b>
                                                    <asp:Label runat="server" Text="Please Enter Query/Forward Reason" ID="lblremarks"></asp:Label></b>
                                                </td>
                                                <td id="tdaction" runat="server" visible="true">
                                                    <b>Submit Action</b>
                                                </td>
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
                                                    <asp:DropDownList ID="ddlStatus" AutoPostBack="true" runat="server" Class="form-control" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Completed" Value="12"></asp:ListItem>
                                                        <asp:ListItem Text="Completed with Payment Request" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="Raise Query" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Rejected" Value="16"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: central" id="tdquryorrejTxtbx" runat="server" visible="false">
                                                    <asp:TextBox ID="txtRequest" runat="server" TextMode="MultiLine" Rows="3" Columns="50" Visible="false"></asp:TextBox>
                                                    <asp:TextBox runat="server" ID="txtAdditionalAmount" Height="50px" Width="150px" onkeypress="return validateAmount(event)" Visible="false" />
                                                </td>


                                                <td>
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="btn btn-rounded btn-submit btn-lg" Width="150px" />
                                                </td>

                                            </tr>
                                        </table>
                                    </div>
                                </div>

                                <div class="card" id="Approval" runat="server" visible="false">
                                    <div class="table-responsive">
                                        <table align="Center" style="width: 100%; border-color: brown; align-content: center;" class="table table-bordered mb-10">
                                            <tr style="border-color: brown; background-color: midnightblue; color: azure">
                                                <td><b>Name</b></td>
                                                <td><b>Unit Name</b></td>
                                                <td><b>Application No</b></td>
                                                <td style="width: 150px"><b>Application Date</b></td>
                                                <td style="width: 200px"><b>Select Action</b></td>
                                                <td id="tdapproverejection" runat="server" visible="false"><b>
                                                    <asp:Label runat="server" Text="Please Enter RejectionReason" ID="Label1"></asp:Label></b>
                                                </td>
                                                <td id="tdapprovalAction" runat="server" visible="false">
                                                    <b>Submit Action</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="lbl_Name1Approval"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblunitname1Approval" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblApplNoApproval" runat="server"></asp:Label></td>
                                                <td tyle="width: 100px">
                                                    <asp:Label ID="lblapplDateApproval" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:DropDownList ID="ddlapproval" AutoPostBack="true" runat="server" Class="form-control" OnSelectedIndexChanged="ddlapproval_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Approve" Value="13"></asp:ListItem>
                                                        <asp:ListItem Text="Rejected" Value="16"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: central" id="trrejection" runat="server" visible="false">
                                                    <asp:TextBox ID="txtRejection" runat="server" TextMode="MultiLine" Rows="3" Columns="50" Visible="false"></asp:TextBox>
                                                </td>
                                                <td id="tdbtnreject" runat="server" visible="false">
                                                    <asp:Button ID="btnreject" runat="server" Text="Submit" OnClick="btnreject_Click" class="btn btn-rounded btn-submit btn-lg" Width="150px" />
                                                </td>
                                            </tr>
                                            <tr id="trapproval" runat="server" visible="false">
                                                <td>
                                                    <label class="mt-2">Reference No :</label>
                                                </td>
                                                
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtreferenceno" class="form-control mt-2"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:FileUpload runat="server" ID="fuApproval" Width="300px" Font-Italic="true" Height="45px" CssClass="mt-2" />
                                               <asp:Button runat="server" ID="btnUpldapproval" OnClick="btnUpldapproval_Click" Text="Upload" class="btn btn-rounded btn-dark btn-sm mt-2" Width="110px" />
                                                    </td>
                                                <td colspan="2">
                                                    
                                                </td>
                                                <td runat="server" id="tdhyperlink" visible="false">
                                                    <asp:HyperLink ID="hplApproval" runat="server" Target="_blank"></asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr id="trapprovalupload" runat="server" visible="false">
                                                <%--<td>
                                                    <asp:FileUpload runat="server" ID="fuApproval" Width="300px" Font-Italic="true" Height="45px" />
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="btnUpldapproval" OnClick="btnUpldapproval_Click" Text="Upload" class="btn btn-rounded btn-dark btn-sm" Width="110px" />
                                                </td>
                                                <td runat="server" id="tdhyperlink" visible="false">
                                                    <asp:HyperLink ID="hplApproval" runat="server" Target="_blank"></asp:HyperLink>
                                                </td>--%>
                                            </tr>
                                            <tr runat="server" id="TRAPPROVE" visible="false">
                                                <td colspan="5">
                                                    <asp:Button ID="btnApprove" runat="server" Text="Submit" OnClick="btnApprove_Click" class="btn btn-rounded btn-submit btn-lg m-2" Width="150px"  />
                                                </td>
                                            </tr>
                                        </table>
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


    <!-- /Main Wrapper -->

    <!-- jQuery -->

</asp:Content>
