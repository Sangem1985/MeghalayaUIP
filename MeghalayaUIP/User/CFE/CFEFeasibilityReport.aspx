<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEFeasibilityReport.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEFeasibilityReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Main Table Styling */
        table {
            width: 80%;
            border-collapse: collapse;
            margin: 20px auto;
            font-family: Arial, sans-serif;
            font-size: 14px;
        }

        th, td {
            border: 1px solid black;
            padding: 8px 12px;
        }

        thead th {
            border: 2px solid black;
            background-color: #f9f9f9;
            text-align: center;
        }

        tbody td {
            border-left: 1px solid black;
            border-right: 1px solid black;
        }

        tbody tr td:nth-child(2) {
            border-bottom: 1px dotted #555;
        }

        .amount {
            text-align: right;
        }

        /* Bank Info Box */
        .bank-info {
            width: 80%;
            margin: 20px auto;
            border: 2px solid red;
            padding: 10px;
            font-size: 14px;
        }

            .bank-info p {
                margin: 5px 0;
            }

        /* Heading Styles */
        .heading {
            text-align: center;
            font-weight: bold;
            font-size: 16px;
            margin-top: 20px;
        }

        .card {
            margin: 20px 100px;
            box-shadow: 1px 2px 3px #495057;
        }

        .mainmenu, .header {
            display: none;
        }

        .powerdept {
            .header123

        {
            display: flex;
            align-items: center;
            padding: 10px 20px;
            border-bottom: 2px solid #000;
        }

        .logo {
            margin-right: 20px;
        }

            .logo img {
                height: 70px;
            }

        .title-section {
            text-align: center;
            flex-grow: 1;
        }

            .title-section h1 {
                margin: 0;
                font-size: 20px;
                font-weight: bold;
            }

        .subtitle {
            font-size: 14px;
            margin-top: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <%--<li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Pre Establishment</a></li>
            --%>
            <li class="breadcrumb-item active" aria-current="page">MPDCL Feasibilty Report </li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="powerdept">
                                <div class="header123">
                                    <div class="logo">
                                        <img src="../../assets/admin/img/power.png" alt="Power Dept Logo" style="width: 100% !important;" />
                                        <!-- Replace logo.png with the actual logo image path -->
                                    </div>
                                    <div class="title-section">
                                        <h1>MEGHALAYA POWER DISTRIBUTION CORPORATION LIMITED</h1>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12  row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                <div class="col-md-12 " style="text-align: center">

                                    <b>FEASIBILITY REPORT
                                      </b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 d-flex">

                                    <%--           <div class="col-md-1"></div>--%>
                                    <div class="col-md-12">
                                        <div runat="server" class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center" visible="false">
                                            <div class="col-md-3" style="text-align: left">
                                                <label>1. Feeder id </label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblFeederid" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">
                                                <label>2. QDID </label>
                                            </div>

                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblQdid" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">
                                                <label>1. Application reg no</label>
                                            </div>

                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblApplicationregno" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">
                                                <label>2. Nearest consumer id </label>
                                            </div>

                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblNearestconsumerid" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">
                                                <label>3. Substation name</label>
                                            </div>

                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblSubstationname" runat="server"></asp:Label>

                                            </div>
                                            <div class="col-md-4" style="text-align: left">
                                                <label>4. Feeder name</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblfeedername" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">
                                                <label>5. DTC</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblDtc" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">
                                                <label>6. Pole number</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblPolenumber" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">
                                                <label>7. Product name</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblProductname" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">
                                                <label>8. Connection type</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblConnectionType" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">

                                                <label>9. Load(KW)</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblLoadKw" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">

                                                <label>10. No of premises</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblNoofpremises" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">

                                                <label>11. Site dimension (sq.f)</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblSitedemension" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">

                                                <label>12. Built up area</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblBuiltuparea" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">

                                                <label>13. No of floors</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblNoofloors" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">

                                                <label>14. Connection phase</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblConnectionphase" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">
                                                <label>15. Building type</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblBuildingtype" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">
                                                <label>16. Requested underground cable size</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblRequestedgroundsize" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">
                                                <label>
                                                    17. Requested overhead<br />
                                                    cable size</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblRequestedoverheadsize" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">
                                                <label>18. Latitude</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblLatitude" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">
                                                <label>19. Longitude</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblLongitude" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">

                                                <label>20. Service type</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblServicetype" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">

                                                <label>21. Billing type</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblBillingtype" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">

                                                <label>22. Area type</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblAreatype" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">

                                                <label>23. Remarks</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">

                                                <label>24. Document id</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblDocumentid" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">

                                                <label>25. Document name</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblDocumentname" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">

                                                <label>26. Document path</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblDocumentpath" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">

                                                <label>27. Meter type</label>
                                            </div>
                                            <div class="col-md-2" style="text-align: left">
                                                <asp:Label ID="lblMetertype" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-4" style="text-align: left">

                                                <label>28. Meter side</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblMeteredside" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                            <div class="col-md-3" style="text-align: left">

                                                <label>29. Load(KVA)</label>
                                            </div>
                                            <div class="col-md-3" style="text-align: left">
                                                <asp:Label ID="lblLoadKva" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-6 d-flex mb-4" style="display: flex !important; flex-direction: row; flex-wrap: nowrap; align-content: center; justify-content: center; align-items: center; text-align: left; margin-left: 25%; padding: 35px;">
                                            <asp:Button ID="btnDownload" class="btn btn-approved btn-sm mr-5 btn-info" runat="server" Text="Download" OnClick="btnDownload_Click"></asp:Button>

                                            <div class="col-md-6">
                                                <button id="btnPrint" onclick="window.print()" class="btn btn-sm btn-info">Print</button>
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
</asp:Content>