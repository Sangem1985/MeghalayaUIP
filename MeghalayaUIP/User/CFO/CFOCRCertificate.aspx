<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOCRCertificate.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOCRCertificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .certificate {
            .header

        {
            text-align: center;
        }

        .logo {
            float: left;
            width: 120px;
        }

        .title {
            font-size: 20px;
            font-weight: bold;
            text-align: center;
        }

        .subtitle {
            text-align: center;
            font-size: 14px;
            margin-bottom: 10px;
        }

        .details {
            margin-top: 20px;
            margin-bottom: 20px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
            font-size: 14px;
        }

        table, th, td {
            border: 1px solid black;
            padding: 8px;
        }

        th {
            background-color: #f2f2f2;
            text-align: left;
        }

        .bold {
            font-weight: bold;
        }

        .footer {
            margin-top: 50px;
            text-align: right;
        }

        .signatory {
            margin-top: 40px;
            text-align: right;
        }

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

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <asp:HiddenField ID="hdnUserID" runat="server" />
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="powerdept">
                                <div class="header123">
                                    <div class="logo">
                                        <img src="../../assets/admin/img/power.png" alt="Power Dept Logo" style="width: 100%;" />
                                        <!-- Replace logo.png with the actual logo image path -->
                                    </div>
                                    <div class="title-section">
                                        <h1>MEGHALAYA POWER DISTRIBUTION CORPORATION LIMITED</h1>
                                        <div class="subtitle">
                                            <asp:Label ID="lblDistrict" runat="server"></asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp; 
                                            <asp:Label ID="lblMandal" runat="server"></asp:Label></div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="certificate">

                                        <div style="clear: both;"></div>
                                        <div class="details">
                                            <p>
                                                <b>No:</b><b> MEPDCL/NC_SERVCERT <b>/</b><asp:Label ID="lblReferenceNo" runat="server"></asp:Label></b>/<b></b><asp:Label ID="lblMpdclDate" runat="server"></asp:Label>
                                            </p>
                                            <p>
                                                <b>Dated:</b>
                                                <asp:Label ID="lblMpdcldated" runat="server"></asp:Label>
                                            </p>
                                            <p>
                                                <b>To,</b><br>
                                            </p>
                                            <b></b>
                                            <asp:Label ID="lblApplicantName" runat="server"></asp:Label>
                                            <br />
                                            <br />

                                            <p><b>Sir/Madam,</b></p>
                                            <p><b>Sub: Service Certificate</b></p>

                                            <p>

                                                <b>Ref: &nbsp;&nbsp </b>1) Your Application No: <b>
                                                    <asp:Label ID="lblRefApplicationNo" runat="server"></asp:Label></b><br>
                                                <b>&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp  </b>2) This office power sanction letter No: <b>
                                                    <asp:Label ID="lblLetterNo" runat="server">&nbsp  <b>Dated:</b>
                                                        <asp:Label ID="lblRefDate" runat="server"></asp:Label></asp:Label></b>
                                            </p>
                                            <p>
                                                With reference to your applications registered vide Application No: <b>
                                                    <asp:Label ID="lblApplicationNo" runat="server"></asp:Label></b>
                                                with us on Date <b>
                                                    <asp:Label ID="lblApplicationDate" runat="server"></asp:Label></b> it is to certify that, your installation has been serviced/energized as under:
                                           
                                            </p>
                                        </div>
                                        <table>
                                            <tr>
                                                <td class="bold">Consumer Name</td>
                                                <td>
                                                    <asp:Label ID="lblConsumerName" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="bold">Address of Installation</td>
                                                <td>
                                                    <asp:Label ID="lblAdress" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="bold">Consumer ID</td>
                                                <td>
                                                    <asp:Label ID="lblconsumerid" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="bold">Date of service</td>
                                                <td>
                                                    <asp:Label ID="lblDateofService" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="bold">Sanctioned Load/ Contract Demand</td>
                                                <td>
                                                    <asp:Label ID="lblSanctionedload" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="bold">Meter Details</td>
                                            </tr>
                                            <tr>
                                                <td>a &nbsp; Meter Make</td>
                                                <td>
                                                    <asp:Label ID="lblMeterMake" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>b &nbsp; Meter Sl. Number</td>
                                                <td>
                                                    <asp:Label ID="lblMeterSlNo" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>c &nbsp; Meter Type</td>
                                                <td>
                                                    <asp:Label ID="lblMeterType" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>d &nbsp; CT/PT Ratio</td>
                                                <td>
                                                    <asp:Label ID="lblCtRatio" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>e &nbsp; Multiplying Factor</td>
                                                <td>
                                                    <asp:Label ID="lblMultuplyingFactor" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="bold">Category Applicable</td>
                                                <td class="bold">CLT</td>
                                                <%--    <td><asp:Label ID="lblApplicable" runat="server"></asp:Label></td>--%>
                                            </tr>
                                            <tr>
                                                <td class="bold">Estimation <b></b>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                               
                                                    <asp:Label ID="lblestimation" runat="server"></asp:Label></td>
                                                <td class="bold">ReceiptNo :
                                               
                                                    <asp:Label ID="lblEstimationReceiptNo" runat="server"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    <b>Date</b>
                                                    <asp:Label ID="lblEstimationDate" runat="server"></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td class="bold">Security Deposit <b></b>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                               
                                                    <asp:Label ID="lblSecurityDeposit" runat="server"></asp:Label></td>
                                                <td class="bold">ReceiptNo : 
                                               
                                                    <asp:Label ID="lblSecurityReceiptNo" runat="server"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;       <b>Date</b>
                                                    <asp:Label ID="lblSecurityDate" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>


                                        <div class="footer">
                                            <p>Yours Faithfully</p>
                                        </div>
                                        <div class="signatory">
                                            <p>
                                                _________________________<br>
                                                Authorized Signatory<br>
                                                CENTRAL SUBDIVISION<br>
                                                <b>MEPDCL</b>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 d-flex mb-4" style="display: flex !important; flex-direction: row; flex-wrap: nowrap; align-content: center; justify-content: center; align-items: center; margin-left: 35%; width: 30%;">

                        <asp:Button ID="btnDownload" class="btn btn-approved btn-sm mr-5 btn-info" Text="Download" runat="server" OnClick="btnDownload_Click1"></asp:Button>

                        <div class="col-md-6" style="width: 30%;">
                            <button id="btnPrint" onclick="window.print()" class="btn btn-sm btn-info">Print</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>






</asp:Content>
