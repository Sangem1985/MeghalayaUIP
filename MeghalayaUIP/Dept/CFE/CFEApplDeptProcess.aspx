<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="CFEApplDeptProcess.aspx.cs" Inherits="MeghalayaUIP.Dept.CFE.CFEApplDeptProcess" %>

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
        function validateDropdown(dropdown) {

            if (dropdown.value === "0") {
                dropdown.style.border = "2px solid red";
                dropdown.focus();
            } else {
                dropdown.style.border = "1px solid #767575b5";
            }
        }
    </script>
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/DeptDashBoard.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="#">Pre Establishment</a></li>
            <li class="breadcrumb-item active" aria-current="page">Application Details</li>
        </ol>
    </nav>
    <!-- Page Wrapper -->
    <div class="page-wrapper" id="divText" runat="server">
        <div class="content container-fluid">
            <div class="card-header d-flex justify-content-between">
                <h4 class="card-title mt-1"><b>Pre Establishment Application Details</b></h4>

                <div class="col-md-1">
                    <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" OnClick="lbtnBack_Click" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                </div>
            </div>
            <div class="card flex-fill">

                <h4 class="mt-2 ml-4">View Details</h4>
                <div class="col-md-12 d-flex">
                    <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">×</span></button>
                    </div>
                </div>
                <div class="col-md-12 d-flex">
                    <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                        <strong>Warning!</strong>
                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">×</span></button>
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
                                   <br />
                                    <br />
                                    <div class="alldetails" id="bodypart">
                                            <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Questionnaire Details</h5>
                                                            <hr />
                                                        </div>
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
                                                            <h5>Entreprenur and Land Details</h5>
                                                            <hr />
                                                        </div>

                                        <%--<h4 class="card-title1 col-lg-12">ENTREPRENUER&LAND</h4>--%>
                                        <div class="col-md-12 tablepadding4">
                                            <b>Organization Details :</b>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            <div class="col-md-2">
                                                <label>1. Name of Firm</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna>
                                                <asp:Label ID="lblBNameCompany" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>2. Type of Firm</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna>
                                                <asp:Label ID="lblTypecompany" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-2">
                                                <label>3. Firm Proposal</label>
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
                                           
                                        <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Authorised Representative Details :</b></p>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            <div class="col-md-2">
                                                <label>1. Name</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna>
                                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>2.  S/o.D/o.W/o</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblso" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-2">
                                                <label>3. Email</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblEmail" runat="server"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;" id="Manufacture" runat="server" visible="false">
                                            <div class="col-md-2">
                                                <label>4. Mobile No</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblMobile" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>5. Alternative Mobile No</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblAlternative" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>6.  Landline Tel No</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna>
                                                <asp:Label ID="lbllandline" runat="server"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            <div class="col-md-2">
                                                <label>7.Door No</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblDoor" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>8. Locality</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblLocality" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>9. District</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna>
                                                <asp:Label ID="lblDistrict" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                            <div class="col-md-2">
                                                <label>10. Mandal</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblMandals" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-2">
                                                <label>11. Village/Town</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblVillages" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>12. Pincode</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblPincode" runat="server"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            <div class="col-md-2">
                                                <label>13. Women Entrepreneur</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblWomen" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>14. Differently Abled</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblAbled" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Location Details :</b></p>
                                        
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            <div class="col-md-2">
                                                <label>1.Architect Name</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblARCNAME" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>2. Architect License No</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblARCLIC" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>3. Architect Mobile No.</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblARCMOBILE" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            <div class="col-md-2">
                                                <label>4. Structural Engineer Name</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblStrEng" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-2">
                                                <label>5.Structural License No</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblStrLICNO" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-2">
                                                <label>6. Structural Mobile No</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblStrMobile" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            <div class="col-md-2">
                                                <label>7. Proposed Area for Development(in Sq. mts)</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblDevelopment" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>8.  Type of Approach Road</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblApproacheRoad" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>9. Existing Width of Approach Road(in feet)</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblWidening" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            <div class="col-md-2">
                                                <label>10. Length of road to be cut:(in mtrs)</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblroadlength" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-2">
                                                <label>12. Number of locations</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblNumber" runat="server"></asp:Label>
                                            </div>
                                            <div id="Extend" runat="server" visible="false" style="width: 100%;display: contents;">
                                                <div class="col-md-2">
                                                    <label>13. Extend of affected area in sq.mts</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblAffectedArea" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Probable Employment Potential (In NO. of persons to be employed) :</b></p>
                                        
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            <div class="col-md-2">
                                                <label>DIRECTMALE</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblDirectMale" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>DIRECTFEMALE</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblDirectFemale" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>INDIRECTMALE</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="InMale" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            <div class="col-md-2">
                                                <label>INDIRECTFEMALE</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="InFemale" runat="server"></asp:Label>
                                            </div>

                                            <div class="col-md-2">
                                                <label>TOTAL</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblEmployees" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-2">
                                                <label>TOTAL</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lblother" runat="server"></asp:Label>
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
                                                            <h5>Manufacturing Items and Raw Materials Used</h5>
                                                            <hr />
                                                        </div>
                                        

                                        <%--<div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            <div class="col-md-2">
                                                <label>Line of Activity</label>
                                            </div>
                                            <div class="col-md-2">
                                                <spna class="dots">:</spna><asp:Label ID="lbllineActivity" runat="server"></asp:Label>
                                            </div>
                                        </div>--%>
                                           
                                                
                                        <div id="divManf" runat="server" visible="false">
                                           
                                             <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Details Of Manufacture Items :</b></p>
                                            <div class="table-responsive">
                                                <asp:GridView ID="gvManufacture" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                    Font-Size="12px" SkinID="gridviewSkin" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="CFELM_ITEMNAME" HeaderText="Name of Product" />
                                                        <asp:BoundField DataField="CFELM_ITEMANNUALCAPACITY" HeaderText="Annual Manufacturing Capacity (in tonne)" />
                                                        <asp:BoundField DataField="CFELM_ITEMVALUE" HeaderText="Appox. value (₹)" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        
                                             <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Details Of Raw Materials Used in Process :</b></p>
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvRwaMaterial" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                Font-Size="12px" SkinID="gridviewSkin" Width="100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
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



                                         
                                        <div id="PowerDetails" runat="server" visible="false">                                            
                                            <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                        <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>POWER Details</h5>
                                                            <hr />
                                                        </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Connected Load in HP</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblHP" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Contracted Maximum Demand in KVA </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblMaxDemand" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Required Voltage Level</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblVoltageLevel" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div id="services" runat="server" visible="false">
                                                    <div class="col-md-2">
                                                        <label>Any Other Services Existing in the Same Premises </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblPermise" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Proposed maximum working hours :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                <div class="col-md-2">
                                                    <label>Per Day </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblDay" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Per Month </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblMonth" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Expected Month and Year of Trial Production(DD/MM/YYYY)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblYear" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Probable Date of Requirement of Power Supply(DD/MM/YYYY) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblPowersupply" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Quantum of energy/load required (in KW) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblQuantum" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                            </div>

                                        <div id="waterConn" runat="server" visible="false">
                                            <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                        <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Water Details</h5>
                                                            <hr />
                                                        </div>
                                            
                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Water Consumption :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Drinking Water ( in KL/Day )</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDrink" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Water for Processing(Industrial use) ( in KL/Day ) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblWaterIndu" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Quantity of Water Required for Consumptive Use (in KL/Day)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblReqWater" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-6" style="border:1px solid #ccc;">
                                                    <label>Quantity of Water Required for Non-Consumptive Use (in KL/Day)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblNonConsumptive" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Distance of the Water tank from the road (approx)</b></p>
                                            <%--     <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div id="tanker" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>Overhead</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblOverhead" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Underground</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblUnderground" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Choose Available Tanker Capacity[In litres]</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblTankerCap" runat="server"></asp:Label>
                                                    </div>
                                                </div>--%>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Type Of Water Connection  </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblConnection" runat="server"></asp:Label>
                                                </div>

                                                <div id="holdno" runat="server" visible="false">
                                                    <div class="col-md-2">
                                                        <label>Holding No </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblHold" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Select Ward No</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblWardNo" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div id="CommercialWater" runat="server" visible="false">
                                                <b>Commercial Establishment</b>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Sub Divisional Office for Application </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblSubDivision" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Number of persons working in the premise </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblPremise" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Water requirement per day demand  </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblReqDemand" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Any other information</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblInformations" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <b>Water Connection Details</b>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>District </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblDistrictWater" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Mandal </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="MandalWater" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Village </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblVillageWater" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Locality </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblLocalitywater" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Nearest Landmark </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblNear" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Pincode </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblPinNumber" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Purpose for which connection is required </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblReqConn" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Type of connection </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna>
                                                        <asp:Label ID="lblTypeCon" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                    <div id="NominalDN" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>Size of pipe connection for domestic(Diameter Nominal DN (mm)) </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lbldomestic" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div id="DiameterDN" runat="server" visible="false">
                                                        <div class="col-md-2">
                                                            <label>Size of pipe connection(Diameter Nominal DN (mm)) </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <spna class="dots">:</spna>
                                                            <asp:Label ID="lblDiameter" runat="server"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            </div>
                                                    </div>
                                                </div>
                                                </div>
                                        </div>

                                        <div id="HazradousWaterDetails" runat="server" visible="false">
                                               <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                        <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Hazardous Waste Details</h5>
                                                            <hr />
                                                        </div>

                                         
                                             <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Authorization Required :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-8" style="border:1px solid #ccc;">
                                                    <label>Authorization required for (Please tick appropriate activity or activities</label>
                                                </div>
                                                <div class="col-md-4" style="border:1px solid #ccc;">
                                                    <spna class="dots">:</spna><asp:Label ID="lblReqtrick" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <p class="card-title1 col-lg-12 mt-4 mb-0"> <b>Nature and Quantity :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Nature and Quantity to waste handled per annum (in Metric Tons) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblQuantitywaste" runat="server"></asp:Label>
                                                </div>


                                                <div class="col-md-2">
                                                    <label>Nature and Quantity to waste stored at any time (in Metric Tons) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblMetrictons" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Nature and Quantity to waste handled per annum (in Kilo Litre) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblhandleannum" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                <div class="col-md-2">
                                                    <label>Nature and Quantity to waste stored at any time (in Kilo Litre)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblWastestored" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Year of commissioning and commence of production</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblYearProduct" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Whether the industry works </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblindustrywork" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                                    </div>
                                                </div>
                                                   </div>
                                            </div>

                                        <div id="Fires" runat="server" visible="false">
                                              <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                        <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Fire Details</h5>
                                                            <hr />
                                                        </div>
                                           
                                            <p class="card-title1 col-lg-12 mt-4 mb-0"> <b>Location and address of the proposed building :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                <div class="col-md-2">
                                                    <label>District </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblDistrics" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Mandal</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblMan" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Village</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblVill" runat="server"></asp:Label>
                                                </div>
                                            </div>


                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                <div class="col-md-2">
                                                    <label>Locality </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lbllocal" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Nearest Landmark </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lbNear" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Pincode</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblPincodes" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"> <b>Other Details :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Height of the building (in mtrs.)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblheight" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Height of each floor (in mtrs.)*(min 2.9 mtrs)  </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblEachfloor" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Plot Area (in Sq m)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna>
                                                    <asp:Label ID="lblArea" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Proposed build up area (in Sq m) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblbuild" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Proposed Drive way (Breadth with units in meters)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lbldriveway" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Category of Building for which Fire Clearance is applied </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblcategoryBuild" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-6" style="border:1px solid #ccc;">
                                                    <label>Fee Amount in Rs (Note: This is an aprrox. value. The amount may change tentatively) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="feeamount" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"> <b>Details of surrounding occupancies and their probable distance from the proposed building :</b>
                                                </p>
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
                                                    </div>
                                                </div>
                                                  </div>
                                            </div>

                                        <div id="ForestDet" runat="server" visible="false">
                                             <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                      <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Forest Details</h5>
                                                            <hr />
                                                        </div>
                                            
                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>A. Forest</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Species </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblspice" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Timber Length</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblLength" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Timber Volume </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblvolume" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Timber Girth </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblGirth" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Estimated Firewood</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblFirewood" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Pole </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblpole" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>B. Boundary Description</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                <div class="col-md-2">
                                                    <label>North </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblNorths" runat="server"></asp:Label>
                                                </div>


                                                <div class="col-md-2">
                                                    <label>East </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblEasts" runat="server"></asp:Label>
                                                </div>


                                                <div class="col-md-2">
                                                    <label>West </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblWests" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>South</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblSouths" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>C. GPS Coordinates Details</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Establishment Location Address(For which application is being Done)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Latitude </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lbllatitude" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Degrees(L) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDegreess" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Minutes(L)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblMinte" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Seconds(L)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblseconds" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Longitude</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lbllongitude" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Degrees</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDegrees" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Minutes</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblMinutes" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Seconds </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblsecond" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>GPS Coordinates (Description)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblCoordinates" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Purpose of Application</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblApplication" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Forest Division </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDivision" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Any other information</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblinformation" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                                    </div>
                                                </div>
                                                 </div>
                                                    </div>

                                        <div id="LabourDet" runat="server" visible="false">
                                            <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                      <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Labour Details</h5>
                                                            <hr />
                                                        </div>
                                            

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Category of Establishment</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblEstablish" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <p class="card-title1 col-lg-12 mt-4 mb-0"> <b>Full name and address of the Principal Employer(furnish
                                                father's name in the case of individuals) with Phone No :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Name</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblNames" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Father's Name</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblFather" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Age</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblAge" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Designation</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Mobile</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblMobiles" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Email</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblMail" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>District</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lbldist" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Mandal</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblMandalsmandal" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Village</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblVILLAS" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Door</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDoors" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Locality</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblLocalitys" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Pincode</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblPins" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"> <b>Boiler Technical Details :</b>
                                                </p>
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

                                            <div id="divsupervision" runat="server" visible="false">
                                                <h4 class="card-title1 col-lg-12">Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment </h4>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Name </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblMangerName" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Father's Name </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="ManagerFather" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Designation</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="ManagerDesignation" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Mobile </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblManagerMobile" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Email </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblManagerEmail" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>District</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblManagerDistrict" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Mandal </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblManagerMandal" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Village </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblManagerVillage" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Door</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblManagerDoor" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Locality </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblManagerLocality" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Pincode </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblManagerPincode" runat="server"></asp:Label>
                                                    </div>


                                                </div>
                                            </div>

                                            <div id="divContrLabr" runat="server" visible="false">
                                                
                                                 <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Particulars of Contract Labour :</b></p>
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GVLabour" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                            <asp:BoundField HeaderText="Name and Address" DataField="CFECL_CONTRACTORNAMEADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                            <asp:BoundField HeaderText="Name,location of work Contract Labour employed" DataField="CFECL_WORKNAMENATURELOCATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Maximum No. of Contract Labour establishment on date" DataField="CFECL_MAXCONTRACTLABOUR" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Duration of proposed contract work in a number of days(Min 1 and Max 179)" DataField="CFECL_CONTRACTDURATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Estimated date of commencement of work" DataField="CFECL_COMMENCEMENTDATEOFWORK" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Estimated date of completion of work" DataField="CFECL_COMPLETIONDATEOFWORK" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Estimated date of termination Contract Labour" DataField="CFECL_TERMINATIONDATEOFEMP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                            <div id="divMigrLabr" runat="server" visible="false">
                                                
                                                <p class="card-title1 col-lg-12 mt-4 mb-0"> <b>Particulars of Migrant Workmen :</b></p>
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
                                                            <asp:BoundField HeaderText="Name and Address of the Contractor" DataField="CFEMW_CONTRACTORNAMEADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                            <asp:BoundField HeaderText="Name,location of work Contract Labour employed Migrant" DataField="CFEMW_MIGRANTNAMENATURELOCATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Maximum No. of Migrant establishment on date" DataField="CFEMW_MAXCONTRACTMIGRANT" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Duration of proposed contract work in a number of days(Min 1 and Max 179)" DataField="CFEMW_CONTRACTDURATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Estimated date of commencement of work" DataField="CFEMW_COMMENCEMENTDATE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Estimated date of completion of work" DataField="CFEMW_COMPLETIONDATEOFWORK" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Estimated date of termination Migrant WorkMen" DataField="CFEMW_TERMINATIONDATEOFEMPMigrant" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                            <div id="div4questions" runat="server" visible="false">
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Nature of work in which contract labour is employed or is to be employed in the establishment </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblNatureOfEmp" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Estimated date of commencement of building or other construction work </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblEstDateBuild" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Maximum number of Contract Employees / building workers to be employed on any day</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblContractEmp" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Estimated date of completion of building or other construction work </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblBuildingWork" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div id="div5questions" runat="server" visible="false">
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Maximum Number of migrant workmen proposed to be employed in the establishment on any date</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblMigrantWorkmen" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Whether the contractor was convicted of any offence within the preceding five years. If so give details</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblPreceding5Years" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Whether there was any order against the contractor revoking or suspending license or forefeiting security deposits in respect of an earlier contract . If so the date of such order. </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblRevokingLic" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Whether the contractor has worked in any other establishment within the past five years, If so, give details of the Principal Emplyer,Establishments and nature of work</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblEstPast5Years" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Type of business, trade, industry, manufacture or occupation, which is carried on in the establishment</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblBusiness" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="divContractorDtls" runat="server" visible="false">
                                                <b>Name and address of the contractor(including his father's/ husband's name in case of individuals):</b>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                    <div class="col-md-2">
                                                        <label>Name of the Contractor/Firm </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblcontractor" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Father's Name </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblfafname" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Age</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblages" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Mobileno </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblMobileno" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Emailid</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>District </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblDistr" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Mandal </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lbltaluka" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Village </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblVillvillage" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Door </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblDoorno" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Locality </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lbllocals" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Pincode </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblPincodeno" runat="server"></asp:Label>
                                                    </div>

                                                </div>
                                            </div>

                                            <div id="divAgentDtls" runat="server" visible="false">
                                                <b>Name and address of the agent or manager of the contractor at the work-site</b>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Name </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblAgentName" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Door No. </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblAgentDoor" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Locality </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblAgentLocality" runat="server"></asp:Label>
                                                    </div>

                                                </div>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>District </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblAgentDistrict" runat="server"></asp:Label>
                                                    </div>

                                                    <div class="col-md-2">
                                                        <label>Mandal </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblAgentMandal" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <label>Village </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="AgetVillage" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                    <div class="col-md-2">
                                                        <label>Pincode </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblAgentPincode" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                                    </div>
                                                </div>
                                                 </div>
                                                    </div>

                                        <div id="Explosive" runat="server" visible="false">
                                             <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                      <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Explosive Details</h5>
                                                            <hr />
                                                        </div>
                                            

                                            <div class="col-md-12 d-flex">
                                                
                                                 <p class="card-title1 col-lg-12 mt-4 mb-0"> <b>Quantity of Explosives proposed to be manufactured/possessed 
                                                        for the purpose stated at serial No. 1 above :</b></p>

                                                <div class="table-responsive">
                                                    <asp:GridView ID="GVEXPLOSIVE" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
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
                                                            <asp:BoundField HeaderText="Name and Description" DataField="CFEME_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                            <asp:BoundField HeaderText="Class" DataField="CFEME_CLASS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Division if any" DataField="CFEME_DIVISION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Quantity(at any one time)" DataField="CFEME_QUANTITYTIME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Quantity(at any one month)" DataField="CFEME_QUANTITYMONTH" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-4"  style="border:1px solid #ccc;">
                                                    <label>Details of site where explosives will be used and distance of site of use from the 
                                                        storage premises (in case of licence for use) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblExplosive" runat="server"></asp:Label>
                                                </div>


                                                <div class="col-md-4" style="border:1px solid #ccc;">
                                                    <label>Details of explosives road van which will be used for transportation of explosives (in case of no objection certificate for road van) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblRoadvan" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                             <p class="card-title1 col-lg-12 mt-4 mb-0"> <b>Additional information :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">

                                                <div class="col-md-2">
                                                    <label>(i)I or We have not been convicted under any offence or ordered to execute bond under Chapter VIII of Code of Criminal Procedure, 1973, during the last 10 years ( If yes, please give details)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblCriminal" runat="server"></asp:Label>
                                                </div>
                                                <div id="Details" runat="server" visible="false" style="width:100%;display:contents;">
                                                    <div class="col-md-2">
                                                        <label>Details </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblChapterDetails" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>(ii) Particulars of other licenses: I / We possess under Explosives Act, 1884 (Note: Please write the licence no(s), if any) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblLicPossess" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div id="LicDetails" runat="server" visible="false" style="width:100%;display:contents;">
                                                    <div class="col-md-2">
                                                        <label>Details </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblDetails" runat="server"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>(iii) I/We have obtained approval as required under rule 101 from the competent authority: (Note: Please enclose the approval letter, approved drawing(s), other enclosures, if any)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblApprovals" runat="server"></asp:Label>
                                                </div>
                                                <div id="approvaldet" runat="server" visible="false" style="width:100%;display:contents;">
                                                    <div class="col-md-2">
                                                        <label>Details</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblapprovalDet" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>(iv) Any other relevant information</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblRelevant" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                                      </div>
                                                </div>
                                                 </div>
                                                    </div>

                                        <div id="FuelDet" runat="server" visible="false">
                                            <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                      <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Fuel Details</h5>
                                                            <hr />
                                                        </div>
                                            

                                            
                                                           <p class="card-title1 col-lg-12 mt-4 mb-0"> <b>Applicant Detail's :</b></p>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-8" style="border:1px solid #ccc;">
                                                    <label>Whether No Objection Certificate (NOC) is required for setting up of Petrol Pump? </label>
                                                </div>
                                                <div class="col-md-4" style="border:1px solid #ccc;">
                                                    <spna class="dots">:</spna><asp:Label ID="lblPetrolNoc" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-8" style="border:1px solid #ccc;">
                                                    <label>No Objection Certificate (NOC) required for (mention the purpose clearly) </label>
                                                </div>
                                                <div class="col-md-4" style="border:1px solid #ccc;">
                                                    <spna class="dots">:</spna><asp:Label ID="lblFuelNoc" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Details of the location :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>District</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblFuelDistrict" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Mandal</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblFuelMandal" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Village</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblFuelVillage" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Located in which Road?</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblRoad" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>1.Name of Establishment</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblNameESt" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>2. Land Holding Certificate No</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblHoldingCert" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>3.Whether land is under Lease?</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblUnderLease" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>4 (i) If Yes, Please enter Lease Deed Registration No</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDeedRegNo" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>5 Area of Land as per Land Holding Certificate No</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblLandHolding" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                           <p class="card-title1 col-lg-12 mt-4 mb-0"> <b>Description of Land with Boundaries :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>(i) North</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblFuelNorth" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>(ii) East</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblFuelEast" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>(iii) South</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblFuelSouth" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>(iv) West</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblFuelwest" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Area for construction of Retail Outlet measuring (in meters) :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>(i) Frontage</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblFrontage" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>(ii) Depth</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDepth" runat="server"></asp:Label>
                                                </div>

                                            </div>
                                        </div>
                                                    </div>
                                                </div>
                                                 </div>
                                                    </div>

                                        <div id="DGSETDET" runat="server" visible="false">

                                            <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                        <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>GDSET Details</h5>
                                                            <hr />
                                                        </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Location of D.G. Set with Full Postal Address :</b></p>
                                            
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Door No/Survey No</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGSurveyNo" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Locality</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGLocality" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Landmark</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGLandmark" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>District</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGDistrict" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Mandal</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGMandal" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Village</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGVillage" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>pincode</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGPincode" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Whether Supply from the Supplier Licensee is Available :</b></p>
                                            
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Name of Supplier</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGNameSupply" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Total Connected Load (in KW)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblLoadConnect" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Total Proposed Load to be Supplied from D.G. Sets (in KW)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTotalLoad" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-10" style="border: 1px solid #ccc;">
                                                    <label>Details of Interlock/Change over arrangement provided to prevent accidental paralleling of D.G. Sets to the Supply System</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblInterlock" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Detail of Load proposed to be supplied from D.G Sets :</b></p>
                                           
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Motor (AC)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="LBLdgMotor" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Light and Fans</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGLight" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Other (to be specified)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGOther" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Running Mode and Expected Date of Installation/Completion/Commissioning :</b></p>
                                            
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Generators Running Mode  (in case more than one will be installed)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblGenRunMode" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Expected Date of Completion of work</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblExpectedCompletion" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Expected Date of starting of Installation work</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDateInstall" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Expected Date of Commissioning</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblExpectedDate" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Supervisor/Contractor/Operator Details :</b></p>
                                            
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Name of the Supervisor  </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGNameSup" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Supervisor License Number </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblSupLicNo" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Name of the Contractor who will carry out the internal electricfication </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblinternalName" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Contractor License Number  </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblConLicNo" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Name of the Person who will be authorized to operate the D.G Sets</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGSETName" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>DG Set Details :</b></p>
                                           
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Capacity </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDGCapacity" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Capacity is in KW/KVA</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblCapcity" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Power Factor </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblPowerFactor" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Rated Voltage (KV)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblRatedvtg" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Engine Make/Serial No </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblEngineSerial" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Alternator Make/Serial No </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblMakeserial" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Details of earthing (Rule 41) the particulars are required in respect of item 12 of the main proforma :</b></p>
                                            
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Type of Equipment </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblEquipment" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Size & materials of earthing conductor</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblEarthing" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>No. of independent conductor path </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblIndependent" runat="server"></asp:Label>
                                                </div>
                                            </div>


                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Type & size electrode and length/dia </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblelectrode" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Impedance of the systems in ohm </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblSystemohm" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Total Impedance of the system in ohm </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblImpedance" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Type of lighting </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblLighting" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Insulation Test of Alternator </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblAlternator" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Earth Tester and Megger Details :</b></p>
                                            
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Earth Tester No </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblEarhtTester" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Make (Earth Tester) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblMakeEarth" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Range (Earth Tester)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblRangeEarth" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Megger No  </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblMeggerNo" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Make (Megger) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblMake" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Range (Megger) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblRange" runat="server"></asp:Label>
                                                </div>
                                            </div>


                                            </div>
                                                    </div>
                                                </div>
                                                </div>


                                        </div>

                                        <div id="CEIGDET" runat="server" visible="false">
                                            <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                      <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Power CEIG Details</h5>
                                                            <hr />
                                                        </div>
                                            
                                             <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Contracted Maximum Demand in KVA :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Already installed</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblAlreadyInstall" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Proposed </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblCEIGProposed" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Total </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblCEIGTotal" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                             <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Connected Load in KW/HP :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Type of Connected Load</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTypeLoad" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Already installed </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblAlredy" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Proposed </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblProposed" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Total </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Regulation</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblRegulation" runat="server"></asp:Label>
                                                </div>
                                                <div id="divvoltages" runat="server" visible="false">
                                                    <div class="col-md-2">
                                                        <label>Voltage</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblCEIGVoltage" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div id="divpowerplants1" runat="server" visible="false">
                                                    <div class="col-md-2">
                                                        <label>Plant</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblPlant" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div id="divpowerplants2" runat="server" visible="false">
                                                    <div class="col-md-2">
                                                        <label>Aggregate Transformer Capacity(ATC) (in KVA) </label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblATC" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Proposed Location of Factory</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblLocatFactory" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Survey No</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblSurveyNo" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Extent </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblExtent" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>District </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblCEIGDistrict" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Mandal</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblCEIGMandal" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Village </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblCEIGVillage" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Street Name </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblStreetName" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Pincode</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblCEIGPin" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Telephone(incl STD Code) </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTelephone" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Nearest Telephone No </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblNaerest" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Date of Commencement of Production(dd-MMM-yyyy)</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblDateCommence" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                                     </div>
                                                </div>
                                                 </div>
                                                    </div>

                                        <div id="TaxDet" runat="server" visible="false">
                                              <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                      <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Proffessional Tax Details</h5>
                                                            <hr />
                                                        </div>
                                          
                                           <p class="card-title1 col-lg-12 mt-4 mb-0">  <b>Application Type :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Apply As</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxApplyAs" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                             <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Establishment Details :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Name of Establishment</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxNameEst" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Address of Establishment</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxAddress" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>District of Establishment</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxDistrict" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Pin Code of Establishment</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxPincode" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Total number of Employees working in Establishment</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxTotalEst" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Date of commencement</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxDateCommence" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Constitution of Establishment</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxEst" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Description of Goods and Services supplied by the Establishment</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxGoodsService" runat="server"></asp:Label>
                                                </div>

                                                <div class="col-md-2">
                                                    <label>Additional Place of Business</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxPlace" runat="server"></asp:Label>
                                                </div>
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
                                                        <asp:BoundField HeaderText="Place of Business" DataField="CFEPB_PLACEOFBUSINESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                        <asp:BoundField HeaderText="District" DataField="CFEPB_DISTRIC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Address" DataField="CFEPB_ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Total working employees" DataField="CFEPB_TOTALWORKINGEMP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>


                                             <p class="card-title1 col-lg-12 mt-4 mb-0"><b>Applicant's Designation :</b></p>
                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div class="col-md-2">
                                                    <label>Please Select Designation</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxDesignation" runat="server"></asp:Label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label>Do you have registration under any other act?</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <spna class="dots">:</spna><asp:Label ID="lblTaxRegAct" runat="server"></asp:Label>
                                                </div>
                                                <div id="RegistrationType" runat="server" visible="false">
                                                    <div class="col-md-2">
                                                        <label>Registration Type</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lbltaxRegType" runat="server"></asp:Label>
                                                    </div>
                                                    k
                                                </div>
                                            </div>

                                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                                <div id="RegNo" runat="server" visible="false">
                                                    <div class="col-md-2">
                                                        <label>Registration No</label>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <spna class="dots">:</spna><asp:Label ID="lblTaxReNo" runat="server"></asp:Label>
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
                                    <div class="card-header" runat="server" id="divChecklistAttachment">
                                        <h3>Check Lists</h3>
                                    </div>
                                    <section id="dashboardAttachmnt">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="grdcfeattachment" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4"  ForeColor="#333333"
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
                                                            <asp:BoundField HeaderText="File Name" DataField="MA_NAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

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
                        <div class="panel panel-default" id="Query" runat="server" visible="false">
                            <div class="panel-heading" role="tab" runat="server" id="headingThree">
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
                                                            <%--<asp:BoundField HeaderText="Query Raised By" DataField="QUERYBY" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />--%>
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
                        <div class="panel panel-default" id="QueryAttachment" runat="server" visible="true">
                            <div class="panel-heading" role="tab" runat="server" id="headingFour">
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
                                        aria-controls="collapseSix">
                                        <asp:Label runat="server" ID="lblVerf"></asp:Label>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseSix" class="panel-collapse show" role="tabpanel"
                                aria-labelledby="headingSix" aria-expanded="false">

                                <div class="card" id="scrutiny" runat="server" visible="false">
                                    <div class="table-responsive">
                                        <table align="Center" style="width: 100%; border-color: brown; align-content: center;" class="table table-bordered mb-10">
                                            <tr style="border-color: brown; background-color: midnightblue; color: azure">
                                                <%--<td><b>Name</b></td>--%>
                                                <td><b>Unit Name</b></td>
                                                <td><b>Application No</b></td>
                                                <td style="width: 150px"><b>Application Date</b></td>
                                                <td style="width: 200px"><b>Select Action</b></td>
                                                <td id="tdquryorrej" runat="server" visible="false"><b>
                                                    <asp:Label runat="server" Text="Please Enter Query/Forward Reason" ID="lblremarks"></asp:Label></b>
                                                </td>
                                                <td id="tdInspReport" runat="server" visible="false">
                                                    <b>Upload Inspection Report</b>
                                                </td>
                                                <td id="tdaction" runat="server" visible="true">
                                                    <b>Submit Action</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <%--<td>
                                                    <asp:Label runat="server" ID="lbl_Name1"></asp:Label></td>--%>
                                                <td>
                                                    <asp:Label ID="lblunitname1" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblApplNo" runat="server"></asp:Label></td>
                                                <td tyle="width: 100px">
                                                    <asp:Label ID="lblapplDate" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:DropDownList ID="ddlStatus" AutoPostBack="true" runat="server" Class="form-control" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" onchange="validateDropdown(this)">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Completed" Value="12"></asp:ListItem>
                                                        <asp:ListItem Text="Completed with Payment Request" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="Raise Query" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="Rejected" Value="17"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: central" id="tdquryorrejTxtbx" runat="server" visible="false">
                                                    <asp:TextBox ID="txtRequest" runat="server" TextMode="MultiLine" Rows="3" Columns="50" Visible="false" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    <asp:TextBox runat="server" ID="txtAdditionalAmount" Height="50px" Width="150px" onkeypress="return validateAmount(event)" Visible="false" onkeyup="handleKeyUp(this)"/>
                                                </td>
                                                <td id="tdInspReport1" runat="server" visible="false">
                                                    
                                                    <asp:FileUpload runat="server" ID="fupInspReport" Width="300px" Font-Italic="true" Height="45px" CssClass="mt-2" />
                                                    <asp:Button runat="server" ID="btnInspReport" OnClick="btnInspReport_Click" Text="Upload" class="btn btn-rounded btn-dark btn-sm mt-2" Width="110px" Height="30px" /><br />
                                                    <asp:HyperLink ID="hplInspReport" runat="server" Visible="false"></asp:HyperLink>
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
                                               <%-- <td><b>Name</b></td>--%>
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
                                              <%--  <td>
                                                    <asp:Label runat="server" ID="lbl_Name1Approval"></asp:Label></td>--%>
                                                <td>
                                                    <asp:Label ID="lblunitname1Approval" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblApplNoApproval" runat="server"></asp:Label></td>
                                                <td tyle="width: 100px">
                                                    <asp:Label ID="lblapplDateApproval" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:DropDownList ID="ddlapproval" AutoPostBack="true" runat="server" Class="form-control" OnSelectedIndexChanged="ddlapproval_SelectedIndexChanged" onchange="validateDropdown(this)">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Approve" Value="13"></asp:ListItem>
                                                        <asp:ListItem Text="Rejected" Value="16"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: central" id="trrejection" runat="server" visible="false">
                                                    <asp:TextBox ID="txtRejection" runat="server" TextMode="MultiLine" Rows="3" Columns="50" Visible="false" onkeyup="handleKeyUp(this)"></asp:TextBox>
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
                                                    <asp:TextBox runat="server" ID="txtreferenceno" class="form-control mt-2" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:FileUpload runat="server" ID="fuApproval" Width="300px" Font-Italic="true" Height="45px" CssClass="mt-2" />
                                                    <asp:Button runat="server" ID="btnUpldapproval" OnClick="btnUpldapproval_Click" Text="Upload" class="btn btn-rounded btn-dark btn-sm mt-2" Width="110px" />
                                                </td>
                                                <td colspan="2"></td>
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
                                                    <asp:Button ID="btnApprove" runat="server" Text="Submit" OnClick="btnApprove_Click" class="btn btn-rounded btn-submit btn-lg m-2" Width="150px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default" id="Offlineverifypanel" runat="server" visible="false">
                            <div class="panel-heading" role="tab" id="headingSeven">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseSeven" aria-expanded="false"
                                        aria-controls="collapseSeven">
                                        <asp:Label runat="server" ID="lblOfflineVerify">Verification of Application</asp:Label>
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseSeven" class="panel-collapse show" role="tabpanel"
                                aria-labelledby="headingSeven" aria-expanded="false">

                                <div class="card" id="offlinescrutiny" runat="server" visible="true">
                                    <div class="table-responsive">
                                        <table align="Center" style="width: 100%; border-color: brown; align-content: center;" class="table table-bordered mb-10">
                                            <tr style="border-color: brown; background-color: midnightblue; color: azure">
                                                <td><b>Name</b></td>
                                                <td><b>Unit Name</b></td>
                                                <td><b>Application No</b></td>
                                                <td style="width: 150px"><b>Application Date</b></td>
                                                <td style="width: 200px"><b>Select Action</b></td>
                                                <td id="td4" runat="server" visible="false"><b>
                                                    <asp:Label runat="server" Text="Please Enter RejectionReason" ID="Label8"></asp:Label></b>
                                                </td>
                                                <td id="td5" runat="server" visible="true">
                                                    <b>Submit Action</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="lblNameOffline"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblUnitNameOffline" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAppNoOffline" runat="server"></asp:Label></td>
                                                <td tyle="width: 50px">
                                                    <asp:Label ID="lblAppDateOffline" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:DropDownList ID="ddlActionOffline" AutoPostBack="true" runat="server" Class="form-control" OnSelectedIndexChanged="ddlapproval_SelectedIndexChanged" onchange="validateDropdown(this)">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Approve" Value="13"></asp:ListItem>
                                                        <asp:ListItem Text="Rejected" Value="16"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: central" id="tdOfflineReason" runat="server" visible="false">
                                                    <asp:TextBox ID="txtRejectReasonOffline" runat="server" TextMode="MultiLine" Rows="3" Columns="50" Visible="false" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </td>
                                                <td id="td7" runat="server" visible="true">
                                                    <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="btnreject_Click" class="btn btn-rounded btn-submit btn-lg" Width="150px" />
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
