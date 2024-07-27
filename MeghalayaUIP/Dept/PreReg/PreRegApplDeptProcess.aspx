<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegApplDeptProcess.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegApplDeptProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    </style>

    <!-- Page Wrapper -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/DeptDashBoard.aspx">Dashboard</a></li>
            <li class="breadcrumb-item active" aria-current="page">Industry Registration Details</li>
        </ol>
    </nav>
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
                                                    <div class="col-md-12 d-flex" style="width: 99%;">
                                                        <h4 class="card-title1 col-lg-12">Company/Unit Details</h4>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>1. Company Name :</label>
                                                        </div>

                                                        <div class="col-md-2 fw-bold text-info">
                                                            <spna class="dots">:</spna><asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2. Company PAN No</label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblCompanyPAN" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>3. Company Proposal For</label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblCompanyProposal" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>4. Company Registration /Incorporation Date</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblregdate" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>5. Udyam/IEM No </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblUdyam" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>6. GSTIN Number</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblGSTIN" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>7. Company Type</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblcomptype" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>8. Category of Registration</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblcatreg" runat="server"></asp:Label>
                                                        </div>


                                                    </div>


                                                    <h4 class="card-title1 col-lg-12">Correspodence Details of Authorised Representative</h4>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>1. Name</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblName" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2. Mobile</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMobile" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>3. E-mail</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>4. Locality</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLocality" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>5. District</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDistict" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>6. Mandal</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMandal" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>7. Village</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblVillage" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>8. Pincode</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPincode" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>9. Door No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lbldoorno_authrep" runat="server"></asp:Label>
                                                        </div>

                                                    </div>


                                                    <h4 class="card-title1 col-lg-12">Location of Unit</h4>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>1. Land (Own/Required)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblisland" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2" id="divDrNo1" runat="server" visible="false">
                                                            <label>1 a. Door No</label>
                                                        </div>
                                                        <div class="col-md-2" id="divDrNo2" runat="server" visible="false">
                                                            <spna class="dots">:</spna><asp:Label ID="lbldrno" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2. Locality</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPro_loc" runat="server"></asp:Label>
                                                        </div>

                                                        <%-- </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">--%>
                                                        <div class="col-md-2">
                                                            <label>3. District</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblpro_dis" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>4. Mandal</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPro_Man" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>5. Village</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPro_vill" runat="server"></asp:Label>
                                                        </div>
                                                        <%--</div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        --%>
                                                        <div class="col-md-2">
                                                            <label>6. Pin Code</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPro_Pin" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <h4 class="card-title1 col-lg-12">Project Details</h4>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>1. Date of Commencement of Production/Operation</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDateofcomm" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2. Nature of Activity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblNatureofAct" runat="server"></asp:Label>
                                                        </div>

                                                    </div>



                                                    <div class="col-md-12 row  mt-1 " style="padding: 0px 0px 0px 13px; text-align: left;" id="divManf1" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>2a. Main Manufacturing Activity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMainmanuf" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>2b.  Main Raw-Materials</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblmainRM" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>2c. Production No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblProdNo" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row  mt-1 " style="padding: 0px 0px 0px 13px; text-align: left;" id="divManf2" runat="server" visible="false">

                                                        <div class="col-md-2">
                                                            <label>2d. Product to be Manufactured</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblmanufProdct" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>2e. Annual Capacity of Manufacturing Product</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblAnnualCap" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2f. Unit of	Measurement of Annual Capacity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblunitofmeasure" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;" id="divService" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>2a. Main Service Activity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblMainSrvc" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>2b. Service to be Provided</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblSrvcProvdng" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2c. Service No.</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblSrvcNo" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>3. Sector</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblSector" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>4. Line Of Activity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLOA" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>5. PCB Category</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPCBcatogry" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>6. Details of Waste / Effluent to be generated</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblwastedtls" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>16. Details of Hazardous Waste to be generated</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblhazdtls" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>18. Estimated Project Cost (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblEstProjcost" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>23.  Plant & Machinery (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPMCost" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>28. Investment in Fixed Capital (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblIFC" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>29. Durable Fixed Assets (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDFA" runat="server"></asp:Label>
                                                        </div>


                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>30.  Working Capital (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblWorkingCapital" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>19. Land Area (in Sq.ft)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lbllandArea" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>20. Land Value (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLandValue" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>24. Area of Building / Shed (Sq. m)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblBuildingArea" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>25. Value of Building / Shed (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblBuldingValue" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>17. Civil Construction</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblcivilConstr" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>26. Power Required (KV)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPowerReq" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>27.  Value of Power (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblElectricityValue" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>21. Water required (KL/D)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblWaterReq" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>22. Water Value (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblWaterValue" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <h4 class="card-title1 col-lg-12">Finance Revenue Details</h4>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>1. Equity Amount (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblequityamount" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2. Term Loan/Working (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lbltermloanworking" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>3. Unsecured Loan (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblunsecuredloan" runat="server"></asp:Label>
                                                        </div>


                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                        <div class="col-md-2">
                                                            <label>4. Internal Resources (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblinternalresources" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>5. State Scheme (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblstatescheme" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>6. Central Scheme (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblcentralscheme" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>7. Benifit from UNNATI (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblunnati" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2" runat="server" visible="false">
                                                            <label>8. Capital Subsidy (INR)</label>
                                                        </div>
                                                        <div class="col-md-2" runat="server" visible="false">
                                                            <spna class="dots">:</spna><asp:Label ID="lblcapitalsubsidy" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2" runat="server" visible="false">
                                                            <label>9. Promoter's and Contributors (INR)</label>
                                                        </div>
                                                        <div class="col-md-2" runat="server" visible="false">
                                                            <spna class="dots">:</spna><asp:Label ID="lblpromotndcont" runat="server"></asp:Label>
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
                                                                <asp:BoundField HeaderText="Name" DataField="NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                <asp:BoundField HeaderText="Aadhar No." DataField="IDD_ADNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="PAN No." DataField="IDD_PAN" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="DIN No." DataField="IDD_DINNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Mobile No." DataField="IDD_PHONE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="E-Mail" DataField="IDD_EMAIL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Address" DataField="ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            </Columns>

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
                                                                        <asp:LinkButton ID="linkAttachment" Text='<%#Eval("FILENAME")%>' runat="server" OnClick="linkAttachment_Click"></asp:LinkButton>
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
                                                            <asp:BoundField HeaderText="View" DataField="FILENAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:TemplateField HeaderText="SI.No">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="linkViewQueryAttachment" Text='<%#Eval("FILENAME") %>' runat="server" OnClick="linkViewQueryAttachment_Click"></asp:LinkButton>
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
                                                                    <asp:DropDownList ID="ddlStatus" AutoPostBack="true" runat="server" Class="form-control" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
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
                                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="btn btn-rounded btn-submit btn-lg" />
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
                                                                    <asp:Button ID="btnQuery" runat="server" Visible="false" Text="Raise Query" OnClick="btnQuery_Click" class="btn btn-rounded btn-info btn-lg" BackColor="Green" />
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
                                                    <asp:TextBox ID="txtIMAQueryReply" TextMode="MultiLine" Height="70px" Width="250px" runat="server"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                    <asp:FileUpload ID="FileUploadquery" runat="server" />
                                                    <br />
                                                    <asp:Button runat="server" ID="btnUpldAttachment" Text="Upload" OnClick="btnUpldAttachment_Click" class="btn btn-dark btn-rounded" Height="35px" Width="110px" /><br />
                                                    <br />
                                                    <asp:HyperLink ID="hplAttachment" runat="server" Visible="false" Text="File Not Uploaded" Target="_blank" ForeColor="Blue"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Send Response to IMA">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnsendresponsetoIMA" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnsendresponsetoIMA_Click" /><br />
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
