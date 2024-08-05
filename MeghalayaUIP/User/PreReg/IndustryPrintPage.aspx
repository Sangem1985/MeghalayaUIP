<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="IndustryPrintPage.aspx.cs" Inherits="MeghalayaUIP.User.PreReg.IndustryPrintPage" %>

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

    <div class="page-wrapper" style="" align="center">
        <div class="content container-fluid" align="center">
        </div>
        <div id="bodypart" align="center">
            <div class="row">
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
            </div>
            <div class="col-md-12">

                <div class="col-md-1 pb-2 pt-2">
                    <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" OnClick="lbtnBack_Click" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                </div>
                <div class="card">
                    <div class="card-header">
                        <h3>Applicant and Unit Details</h3>
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
                                            <label>3. Company Type</label>
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
                                            <label>5. Company Proposal For</label>
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
                                            <label>7. Registration No </label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblUdyam" runat="server"></asp:Label>
                                        </div>

                                        <div class="col-md-2">
                                            <label>8. Company Registration /Incorporation Date</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblregdate" runat="server"></asp:Label>
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
                                            <label>7. Details of Hazardous Waste to be generated</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblhazdtls" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>8. Estimated Project Cost (INR)</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblEstProjcost" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                        <div class="col-md-2">
                                            <label>9.  Plant & Machinery (INR)</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblPMCost" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>10. Investment in Fixed Capital (INR)</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblIFC" runat="server"></asp:Label>
                                        </div>

                                        <div class="col-md-2">
                                            <label>11. Durable Fixed Assets (INR)</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblDFA" runat="server"></asp:Label>
                                        </div>


                                    </div>


                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                        <div class="col-md-2">
                                            <label>12.  Working Capital (INR)</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblWorkingCapital" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>13. Land Area (in Sq.ft)</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lbllandArea" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>14. Land Value (INR)</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblLandValue" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                        <div class="col-md-2">
                                            <label>15. Area of Building / Shed (Sq. m)</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblBuildingArea" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>16. Value of Building / Shed (INR)</label>
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
                                            <label>18. Power Required (KV)</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblPowerReq" runat="server"></asp:Label>
                                        </div>

                                        <div class="col-md-2">
                                            <label>19.  Value of Power (INR)</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblElectricityValue" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-md-2">
                                            <label>20. Water required (KL/D)</label>
                                        </div>
                                        <div class="col-md-2">
                                            <spna class="dots">:</spna><asp:Label ID="lblWaterReq" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                        <div class="col-md-2">
                                            <label>21. Water Value (INR)</label>
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
        <!-- /Page Wrapper -->
        <br />
        <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
            type="button" value="Print" /><br />
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Visible="false" NavigateUrl="~/Home.aspx"
            ForeColor="#3366CC">Home</asp:HyperLink>
        <br />
    </div>
    <%--</div>
    </div>--%>
</asp:Content>
