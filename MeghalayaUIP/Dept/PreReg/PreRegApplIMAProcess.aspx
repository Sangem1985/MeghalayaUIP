<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegApplIMAProcess.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegApplIMAProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    function handleKeyUp(input) {
        if (input.value.trim() === "") {
            input.style.border = "2px solid red";
        } else {
            input.style.border = "1px solid #767575b5";
        }
    }
    </script>
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
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
    <!-- Page Wrapper -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="../Dashboard/DeptDashBoard.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="../PreReg/PreRegApplIMAView.aspx">Industry Registrations</a></li>
            <li class="breadcrumb-item active" aria-current="page">Application Details</li>
        </ol>
    </nav>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="page-wrapper" id="divText" runat="server">
        <div class="content container-fluid">
            <div class="card-header d-flex justify-content-between">
                <h4 class="card-title mt-1"><b>Industry Registration Application Details</b></h4>
                <div class="col-md-1">
                    <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" OnClick="lbtnBack_Click" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
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
                        <asp:Label ID="lblmsg0" runat="server" autosize="true"></asp:Label>
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
                                        <h3>Applicant And Unit Details</h3>
                                    </div>
                                    <section id="dashboardBasic">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="card-body">
                                                    <div class="col-md-12 d-flex" style="width: 99%;">
                                                        <h4 class="card-title1 col-lg-12">Firm/Unit Details</h4>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>1. Firm Name :</label>
                                                        </div>

                                                        <div class="col-md-2 fw-bold text-info">
                                                            <spna class="dots">:</spna><asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>2. Firm PAN No</label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblCompanyPAN" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>3. Firm Type</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblcomptype" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>4. GSTIN Number</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblGSTIN" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>5. Firm Proposal For</label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblCompanyProposal" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>6. Category of Registration</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblcatreg" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <asp:Label runat="server" ID="lblregcategory"> </asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblUdyam" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>8. Firm Registration /Incorporation Date</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblregdate" runat="server"></asp:Label>
                                                        </div>

                                                    </div>


                                                    <h4 class="card-title1 col-lg-12">Correspondence Details of Authorised Representative</h4>

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
                                                            <label>Date of Commencement of Production/Operation</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDateofcomm" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Nature of Activity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblNatureofAct" runat="server"></asp:Label>
                                                        </div>

                                                    </div>



                                                    <div class="col-md-12 row  mt-1 " style="padding: 0px 0px 0px 13px; text-align: left;" id="divManf1" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>Main Manufacturing Activity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblMainmanuf" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Main Raw-Materials</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblmainRM" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Production No</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblProdNo" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row  mt-1 " style="padding: 0px 0px 0px 13px; text-align: left;" id="divManf2" runat="server" visible="false">

                                                        <div class="col-md-2">
                                                            <label>Product to be Manufactured</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblmanufProdct" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Annual Capacity of Manufacturing Product</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblAnnualCap" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Unit of	Measurement of Annual Capacity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblunitofmeasure" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;" id="divService" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>Main Service Activity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblMainSrvc" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Service to be Provided</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblSrvcProvdng" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Service No.</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblSrvcNo" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Sector</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblSector" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Line Of Activity</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLOA" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>PCB Category</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPCBcatogry" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Details of Waste / Effluent to be generated</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblwastedtls" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Details of Hazardous Waste to be generated</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblhazdtls" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Estimated Project Cost (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblEstProjcost" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Plant & Machinery (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPMCost" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Investment in Fixed Capital (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblIFC" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Durable Fixed Assets (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblDFA" runat="server"></asp:Label>
                                                        </div>


                                                    </div>


                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Working Capital (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblWorkingCapital" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Land Area (in Sq.ft)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lbllandArea" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Land Value (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblLandValue" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Area of Building / Shed (Sq. m)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblBuildingArea" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Value of Building / Shed (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblBuldingValue" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Civil Construction</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblcivilConstr" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Power Required (KV)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblPowerReq" runat="server"></asp:Label>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <label>Value of Power (INR)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblElectricityValue" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Water required (KL/D)</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna><asp:Label ID="lblWaterReq" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                        <div class="col-md-2">
                                                            <label>Water Value (INR)</label>
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
                                                                <asp:BoundField HeaderText="Nationality." DataField="IDD_NATIONALITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Mobile No." DataField="IDD_PHONE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="E-Mail" DataField="IDD_EMAIL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Address" DataField="ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40%" />
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
                                                        <asp:GridView ID="grdAttachments" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" OnRowDataBound="grdAttachments_RowDataBound"
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
                                                            <EmptyDataTemplate>
                                                                <div align="center" style="text-align: center; padding: 20px;">
                                                                    <b>No Records Found</b>
                                                                </div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                                <div class="col-md-3"></div>

                                            </div>
                                        </div>
                                    </section>
                                </div>
                                <div class="card" runat="server" id="divSupDocs" visible="false">
                                    <div class="card-header">
                                        <h3>
                                            <asp:Label runat="server" Text="Supporting Documents"></asp:Label>
                                        </h3>
                                    </div>
                                    <section id="dashboardAttachmnts">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-md-3"></div>
                                                <div class="col-md-6">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdSupportingDocuments" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" OnRowDataBound="grdSupportingDocuments_RowDataBound"
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
                                                                <asp:BoundField HeaderText="File Uploaded By" DataField="FILEBY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
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
                                                            <EmptyDataTemplate>
                                                                <div align="center" style="text-align: center; padding: 20px;">
                                                                    <b>No Records Found</b>
                                                                </div>
                                                            </EmptyDataTemplate>
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
                                                            <asp:TemplateField HeaderText="Sl.No" HeaderStyle-Width="1px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="center" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Application ID" DataField="PREREGUIDNO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <%--<asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />--%>
                                                            <asp:BoundField HeaderText="Query Raised By" DataField="QUERYBY" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Description" DataField="QUERYRAISEDESC" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Raised To" DataField="QUERYRAISETO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Raised Date" DataField="QUERYDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Response" DataField="QUERYRESPONSEDESC" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Response Date" DataField="QUERYRESPONSEDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div align="center" style="text-align: center; padding: 20px;">
                                                                <b>No Records Found</b>
                                                            </div>
                                                        </EmptyDataTemplate>
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
                                        <h3>Query Response Attachments </h3>
                                    </div>
                                    <section id="dashboardQueryattachmnts">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-md-3"></div>
                                                <div class="col-md-6">
                                                    <asp:GridView ID="grdQryAttachments" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333" OnRowDataBound="grdQryAttachments_RowDataBound"
                                                        GridLines="Both" Width="100%" EnableModelValidation="True" ShowHeaderWhenEmpty="true">
                                                        <RowStyle />
                                                        <AlternatingRowStyle BackColor="LightGray" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="File Uploaded By (Department/Investor)" DataField="FILEBY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                            <asp:BoundField HeaderText="FileName" DataField="FILENAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="false" />
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
                                                        <EmptyDataTemplate>
                                                            <div align="center" style="text-align: center; padding: 20px;">
                                                                <b>No Records Found</b>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                    <%--<div class="table-responsive">                                                      
                                                       </div>--%>
                                                </div>
                                                <div class="col-md-3"></div>
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
                                                            <asp:BoundField HeaderText="Application ID" DataField="PREREGUIDNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Department Name" DataField="MD_DEPT_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Status" DataField="STATUSDESCRIPTION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
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
                                            <%--<asp:TemplateField HeaderText="Response">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtIMAQueryReply" TextMode="MultiLine" Height="100px" Width="250px" runat="server"></asp:TextBox>
                                                    <br />
                                                    <br />
                                                    <asp:FileUpload ID="FileUploadquery" runat="server" class="btn btn-success" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
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

                                    <table id="tblcomqury" runat="server" visible="false" class="table-bordered mb-10">
                                        <tr id="trIMAResponse" runat="server" visible="false">
                                            <td style="width: 200px">Enter Response
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtIMAResponse" Style="height: 50px; width: 600px; margin-top: 10px;" onkeypress="return validateNameInput(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </td>
                                            <td style="width: 180px">Upload File if any: 
                                                <br />
                                                <asp:FileUpload runat="server" ID="FileUploadqueryIMA" Font-Italic="true" BorderColor="Tomato" Style="margin-top: 10px;" padding-right="10px" />

                                                <asp:HyperLink ID="hplAttachment" runat="server" Visible="false" Text="View" Target="_blank" ForeColor="Blue"></asp:HyperLink>
                                            </td>
                                            <td style="width: 110px">
                                                <asp:Button runat="server" ID="btnUpldAttachment" Text="Upload" OnClick="btnUpldAttachment_Click" class="btn btn-dark btn-rounded" Height="35px" Width="110px" /><br />
                                            </td>

                                        </tr>
                                        <tr id="trComQrytoAppl" runat="server" visible="false">
                                            <td style="width: 200px; padding-top: 20px; align-items: center; text-align: center;">Enter Additional Query
                                            </td>
                                            <td colspan="4" style="padding-left: 20px; padding-top: 20px; align-items: left; text-align: left">
                                                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtComQrytoAppl" Height="50px" Width="600px" onkeypress="return validateNameInput(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center" colspan="5">
                                                <asp:Button ID="btnSubmit2" runat="server" Text="Submit" OnClick="btnSubmit2_Click" class="btn btn-rounded btn-submit btn-lg" Width="150px" />
                                            </td>
                                        </tr>
                                    </table>

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
                                        <table align="Center" style="width: 100%; align-content: center" class="table-bordered mb-10">
                                            <tr id="trVrfyhdng" runat="server">
                                                <td><b>Name</b></td>
                                                <td><b>Unit Name</b></td>
                                                <td><b>Application ID</b></td>
                                                <td style="width: 150px"><b>Application Date</b></td>
                                                <td style="width: 200px"><b>Application Action</b></td>
                                                <td id="tdRemarks" runat="server" visible="false"><b>
                                                    <asp:Label runat="server" Text="Please Enter Remarks if any"></asp:Label></b>
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
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblApplNo" runat="server"></asp:Label></td>
                                                <td tyle="width: 100px">
                                                    <asp:Label ID="lblapplDate" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:DropDownList ID="ddlStatus" AutoPostBack="true" runat="server" Class="form-control" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Approve & Forward to Committee" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="Raise Query to Applicant" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Forward to Departments" Value="6"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: central" id="tdRemarksTxtbx" runat="server" visible="false">
                                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Rows="3" Columns="50" onkeypress="return validateNameInput(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: central" id="tdApplQueryTxtbx" runat="server" visible="false">
                                                    <asp:TextBox ID="txtApplQuery" runat="server" TextMode="MultiLine" Rows="3" Columns="50" onkeypress="return validateNameInput(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
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
                                                            <td>Select Department to Forward</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddldepartment" runat="server" class="form-control">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>Enter Remarks
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDeptQuery" runat="server" TextMode="MultiLine" Rows="3" Columns="50" onkeypress="return validateNameInput(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:Button ID="btnAddDeptQry" Text="Add Department" runat="server" class="btn btn-rounded btn-submit btn-lg" Width="200px" OnClick="btnAddDeptQry_Click" />
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
                                                                        <asp:TemplateField Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDEPTID" runat="server" Text='<%#Eval("DEPTID") %>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--<asp:BoundField HeaderText="Department ID" DataField="DEPTID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                                                                        <asp:BoundField HeaderText="Query Description" DataField="QUERYDESC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:BoundField HeaderText="UNIT ID" DataField="UNITID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:BoundField HeaderText="INVESTER ID" DataField="INVESTERID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                                        <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                                <td>
                                                    <asp:Button ID="btnQuery" runat="server" Visible="false" Text="Forward" Enabled="false" OnClick="btnQuery_Click" class="btn btn-rounded btn-submit btn-lg" />
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
