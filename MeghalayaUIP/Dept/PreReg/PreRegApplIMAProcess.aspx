<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegApplIMAProcess.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegApplIMAProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>

    <!-- Page Wrapper -->
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card flex-fill">

                <h4 class="mt-2 ml-4">View Details</h4>
                <div class="col-md-12 ">
                    <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-12 ">
                    <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                        <strong>Warning!</strong>
                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
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
                                        <h3>Applicant And Unit Details</h3>
                                    </div>
                                    <section id="dashboardBasic">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="card-body">
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 600; font-size: 20px;">Company/Unit Details: </span>
                                                        </label>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <label>Company Name :</label>

                                                            <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label>Company PAN No :</label>

                                                            <asp:Label ID="lblCompanyPAN" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label>Company Proposal For :</label>

                                                            <asp:Label ID="lblCompanyProposal" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <label>Company Registration/Incorporation Date :</label>

                                                            <asp:Label ID="lblregdate" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label>Udyam/IEM No :</label>
                                                            <asp:Label ID="lblUdyam" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label>
                                                                GSTIN Number :</label>

                                                            <asp:Label ID="lblGSTIN" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <label>Company Type:</label>

                                                            <asp:Label ID="lblcomptype" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label>Category of Registration:</label>

                                                            <asp:Label ID="lblcatreg" runat="server"></asp:Label>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 600; font-size: 20px;">Correspodence Details of Authorised Representative</span></label>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Name :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Mobile :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblMobile" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- </div>
																<div class="col-md-12 d-flex"  > -->
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">E-mail :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Locality :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblLocality" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">
                                                                    District :</label>
                                                                <div class="col-lg-8">
                                                                    <asp:Label ID="lblDistict" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Mandal :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblMandal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- </div>
																<div class="col-md-12 d-flex"  > -->
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Village :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblVillage" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Pincode :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblPincode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Door No :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lbldoorno_authrep" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label ">
                                                            <span
                                                                style="font-weight: 600; font-size: 20px;">Location of Unit</span></label>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Door No :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lbldrno" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Locality :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblPro_loc" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <!-- </div>
																<div class="col-md-12 d-flex"  > -->
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    District :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblpro_dis" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mandal :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblPro_Man" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Village :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblPro_vill" runat="server"></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Pin Code :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblPro_Pin" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Is Land Required :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblisland" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span
                                                                style="font-weight: 600; font-size: 20px;">Project Details</span></label>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Date of Commencement of Production/Operation :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblDateofcomm" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Nature of Activity :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblNatureofAct" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex" runat="server" id="divManf" visible="false">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Main Manufacturing Activity :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblMainmanuf" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Product to be Manufactured :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblmanufProdct" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label ">
                                                                    Production No :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblProdNo" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Main Raw-Materials :
           
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblmainRM" runat="server"></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Annual Capacity :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblAnnualCap" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Unit of	Measurement</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblunitofmeasure" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex" runat="server" id="divServc" visible="false">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Main Service Activity :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblMainSrvc" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Service to be Provided :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblSrvcProvdng" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label ">
                                                                    Service No. :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblSrvcNo" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Sector :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblSector" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Line Of Activity :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblLOA" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label fw-bold">
                                                                    PCB Category :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblPCBcatogry" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Details of Waste
													/ Effluent to be
													generated :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblwastedtls" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Details of
													Hazardous Waste to be
													generated :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblhazdtls" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Civil Construction :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblcivilConstr" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>
                                                    <div class="col-md-12 d-flex">

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Estimated Project Cost (INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblEstProjcost" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Land Area (in Sq.ft)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lbllandArea" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Land Value (INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblLandValue" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Water required (KL/D) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblWaterReq" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Water Value (INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblWaterValue" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Plant & Machinery (INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblPMCost" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>

                                                    <div class="col-md-12 d-flex">

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Area of Building / Shed
(Sq. m)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblBuildingArea" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Value of Building / Shed
																(INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblBuldingValue" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Power Required (KV) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblPowerReq" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Value of Power (INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblElectricityValue" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Investment in Fixed Capital	(INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblIFC" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Durable Fixed Assets (INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblDFA" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Working Capital (INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblWorkingCapital" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label ">
                                                            <span style="font-weight: 600; font-size: 20px;">Finance Revenue Details</span></label>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-8 col-form-label">
                                                                    Promoter's and Contributors (INR) :</label>
                                                                <div class="col-lg-4 d-flex">
                                                                    <asp:Label ID="lblpromotndcont" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Equity Amount
																			(INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblequityamount" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Term Loan/Working
																			(INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lbltermloanworking" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-8 col-form-label">
                                                                    Unsecured Loan (INR) :</label>
                                                                <div class="col-lg-4 d-flex">
                                                                    <asp:Label ID="lblunsecuredloan" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Internal Resources
																			(INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblinternalresources" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    State Scheme (INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblstatescheme" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-8 col-form-label">
                                                                    Capital Subsidy (INR) :</label>
                                                                <div class="col-lg-4 d-flex">
                                                                    <asp:Label ID="lblcapitalsubsidy" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Benifit from UNNATI
																			(INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblunnati" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Central Scheme
																			(INR) :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblcentralscheme" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-12">
                                                            <div class="form-group row">

                                                                <div class="col-lg-12 d-flex">
                                                                    <p style="color: red; font-family: sans-serif;">
                                                                        <b>
                                                                            <asp:Label ID="lblnote" runat="server" Visible="false">Note: Based on your input regarding Sector/Year of establishment/production, your Unit is not eligible for Incentive under MIIPP, 2024.
However, you can register your unit to get required approvals/ clearances.</asp:Label></b>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 900; font-size: 20px;">Production and Sales particulars for the Last 5 Years</span></label>
                                                    </div>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdRevenueProj" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                                            GridLines="Both" HeaderStyle-BackColor="Red"
                                                            Width="80%" EnableModelValidation="True">
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
                                                                <asp:BoundField HeaderText="Items" DataField="ITEMS" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="left" />
                                                                <asp:BoundField HeaderText="YEAR1" DataField="YEAR1" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="YEAR2" DataField="YEAR2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="YEAR3" DataField="YEAR3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="YEAR4" DataField="YEAR4" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="YEAR5" DataField="YEAR5" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 900; font-size: 20px;">Directors / Promoters Details</span></label>
                                                    </div>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdDirectors" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                                            GridLines="Both" HeaderStyle-BackColor="Red"
                                                            Width="80%" EnableModelValidation="True">
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
                                                                <asp:BoundField HeaderText="Name" DataField="NAME" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="left" />
                                                                <asp:BoundField HeaderText="Aadhar No." DataField="IDD_ADNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="PAN No." DataField="IDD_PAN" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="DIN No." DataField="IDD_DINNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Mobile No." DataField="IDD_PHONE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="E-Mail" DataField="IDD_EMAIL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Address" DataField="ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
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
                                                                    <th></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td class="fw-bold">DPR</td>

                                                                    <td>
                                                                        <asp:LinkButton ID="linkViewDPR" runat="server" OnClick="linkViewDPR_Click"></asp:LinkButton>
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
                                                            <%--<asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />--%>
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
                                        <h3>Query Response Attachments Check Lists</h3>
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
                                                            <asp:BoundField HeaderText="View" DataField="FILENAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:TemplateField HeaderText="SI.No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkViewQueryAttachment" Text='<%#Eval("FILENAME") %>' runat="server" OnClick="linkViewQueryAttachment_Click"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="VIEW" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hplViewQueryAttachment" Text='<%#Eval("FILELOCATION") %>' runat="server"></asp:HyperLink>
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
                                                    <asp:Label runat="server" ID="lblDeptID" Text='<%#Eval("QUERYRAISEDBYDEPTID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UNIT ID">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUNITID" runat="server" Text='<%#Eval("UNITID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Query By (Dept.Name)" DataField="QUERYBY" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Query Raised on" DataField="QUERYDATE" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Query Description" DataField="QUERYRAISEDESC" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" />
                                            <asp:TemplateField HeaderText="Response">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtIMAQueryReply" TextMode="MultiLine" Height="100px" Width="250px" runat="server"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                    <asp:FileUpload ID="FileUploadquery" runat="server" class="btn btn-success" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Select Action">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlQueryAction" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlQueryAction_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Send Response to COMMITTEE Officer" Value="12"></asp:ListItem>
                                                        <asp:ListItem Text="Forward Query to Applicant" Value="15"></asp:ListItem>
                                                        <asp:ListItem Text="Forward Query to Departments" Value="13"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default" id="verifypanel" runat="server" visible="true">
                            <div class="panel-heading" role="tab" id="headingSix" runat="server">
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
                                    <div class="table-responsive">
                                        <table align="Center" style="width: 100%; align-content: center" class="table-hover table-bordered mb-10">
                                            <tr id="trVrfyhdng" runat="server">
                                                <td><b>Name</b></td>
                                                <td><b>Unit Name</b></td>
                                                <td><b>Mobile No</b></td>
                                                <td style="width: 150px"><b>Application Date</b></td>
                                                <td style="width: 200px"><b>Application Action</b></td>
                                                <td id="tdRemarks" runat="server" visible="false"><b>
                                                    <asp:Label runat="server" Text="Please Enter Reamrks if any"></asp:Label></b>
                                                </td>
                                                <td id="tdApplQuery" runat="server" visible="false"><b>
                                                    <asp:Label runat="server" Text="Please Enter Query Description"></asp:Label></b>
                                                </td>
                                                <td id="tdaction" runat="server" visible="true">
                                                    <b>Submit Action</b>
                                                </td>
                                            </tr>
                                            <tr id="trVrfydtls" runat="server">
                                                <td>
                                                    <asp:Label runat="server" ID="lbl_Name1"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblunitname1" runat="server"></asp:Label>
                                                    <%--textarea rows="2" cols="15" class="border-0">TYRES PRIVATE LIMITED UNIT II</textarea>--%>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblApplNo" runat="server"></asp:Label></td>
                                                <td tyle="width: 100px">
                                                    <asp:Label ID="lblapplDate" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:DropDownList ID="ddlStatus" AutoPostBack="true" runat="server" Class="form-control" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Approve & Forwrd to Committe" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="Raise Query to Applicant" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Raise Query to Departments" Value="6"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: central" id="tdRemarksTxtbx" runat="server" visible="false">
                                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Rows="3" Columns="50"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: central" id="tdApplQueryTxtbx" runat="server" visible="false">
                                                    <asp:TextBox ID="txtApplQuery" runat="server" TextMode="MultiLine" Rows="3" Columns="50"></asp:TextBox>
                                                </td>

                                                <td>
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="btn btn-rounded btn-submit btn-lg" Width="150px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: central" id="tdDeptQuery" runat="server" visible="false" colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>Select Department to Raise Query</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddldepartment" runat="server" class="form-control">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>Enter Query Description
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDeptQuery" runat="server" TextMode="MultiLine" Rows="3" Columns="50"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:Button ID="btnAddDeptQry" Text="Add Query" runat="server" class="btn btn-rounded btn-submit btn-lg" Width="125px" OnClick="btnAddDeptQry_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:GridView ID="grdDeptQueries" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD" ForeColor="#333333"
                                                                    OnRowDeleting="grdDeptQueries_RowDeleting">
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                    <EditRowStyle BackColor="#B9D684" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl. No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Department Name" DataField="DEPTNAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:BoundField HeaderText="Deaprtment ID" DataField="DEPTID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:BoundField HeaderText="Query Description" DataField="QUERYDESC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:BoundField HeaderText="UNITID" DataField="UNITID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:BoundField HeaderText="INVESTERID" DataField="INVESTERID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                                        <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                                <td>
                                                    <asp:Button ID="btnQuery" runat="server" Visible="false" Text="Raise Query" Enabled="false" OnClick="btnQuery_Click" class="btn btn-rounded btn-submit btn-lg" />
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
