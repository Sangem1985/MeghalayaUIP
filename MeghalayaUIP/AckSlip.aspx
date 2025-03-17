<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AckSlip.aspx.cs" Inherits="MeghalayaUIP.AckSlip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ACKNOWLEDGEMENT SLIP</title>
    <link href="assets/admin/css/style.css" rel="stylesheet" />
    <style>
        ul.list-unstyled.mb-0.list-item li {
            list-style: none;
        }

        .invoice-container {
            background-color: #fff;
            border: 1px solid #dfdfdf;
            margin: 0 auto 1.875rem;
            max-width: 900px;
            padding: 1.5rem;
            border-radius: 8px;
            box-shadow: 1px 3px 7px 1px #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="page-wrapper" style="min-height: 293px;">
                <div class="content container-fluid">

                    <!-- Invoice Container -->
                    <div class="invoice-container">

                        <div class="row">
                            <div class="col-sm-12 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <img alt="Logo" class="img-fluid" src="assets/admin/img/logo.png" />
                            </div>

                            <div class="col-sm-6 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <div class="invoice-details text-center d-flex" style="text-align: center;">
                                    <h3 class="text-uppercase" style="margin-bottom: 0;"><u>Application Acknowledgement</u></h3>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 m-b-20">
                                <ul class="list-unstyled mb-0 list-item">
                                    <li>Date :
                                        <label runat="server"   id="lblDate">10/03/2025</label>
                                        <br />
                                        <br />
                                    </li>
                                    <li>
                                        <label runat="server" id="lblEnterPrise"></label>
                                    </li>
                                    <li>Dear Applicant,<br />
                                        <br />
                                        Your Application for the following services has been successfully submitted to Invest Meghalaya Authority, Government of Meghalaya.</li>
                                    <br />
                                    1. NoC for Ground Water Abstraction for Commercial Connection. <br />
                                    2.Certificate for non-availability of water supply from water supply agency. <br />
                                    3.Permission to Draw Water from River/Public Tanks.
                                </ul>
                                <div class="col-sm-12 m-b-20 text-center" style="display: flex; justify-content: center;">
                                    <div class="invoice-details text-center d-flex" style="text-align: center;">
                                        <h3 class="text-uppercase" style="margin-bottom: 0;"><u>Application Summary</u></h3>
                                    </div>
                                </div>
                                <ul class="list-unstyled mb-0 list-item">
                                    <li>Application Reference Number is : <b>
                                        <label runat="server" id="lblUIDNo">CTE/2025/1001/101	</label>
                                    </b>
                                        <br />
                                        <br />
                                    </li>
                                    <li>Your application was received by Online mode on
                                        <label runat="server" id="lblDate1">10/03/2025</label>
                                        .</li>
                                </ul>
                            </div>

                        </div>
                        <div style="display: flex; justify-content: center;">
                            <input id="btnPrint" onclick="window.print()"
                                style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                                type="button" value="Print" />
                        </div>

                    </div>


                    <!-- /Invoice Container -->

                </div>
            </div>
        </div>
    </form>

</body>
</html>
