<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntenttoInvestPrint.aspx.cs" Inherits="MeghalayaUIP.IntenttoInvestPrint" %>

<!DOCTYPE html>
<html lang="en">

<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">
    <title>Invset Meghalaya - CAF</title>

    <!-- Favicon -->
    <link rel="shortcut icon" type="image/x-icon" href="../images/favicon.png">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="assets/admin/css/bootstrap.min.css">

    <!-- Fontawesome CSS -->
    <link rel="stylesheet" href="assets/admin/css/font-awesome.min.css">

    <!-- Feathericon CSS -->
    <link rel="stylesheet" href="assets/admin/css/feathericon.min.css">

    <link rel="stylesheet" href="assets/admin/plugins/morris/morris.css">

    <!-- Main CSS -->
    <link rel="stylesheet" href="assets/admin/css/style.css">

    <!--[if lt IE 9]>
			<script src="assets/js/html5shiv.min.js"></script>
			<script src="assets/js/respond.min.js"></script>
		<![endif]-->
    <style>
        div#bodypart {
            margin-top: 5rem !important;
        }

        .card-body {
            padding: 5px 7px !important;
        }

        .col-md-12.d-flex.tablepadding .col-md-6.d-flex .col-md-6,
        .col-md-12.d-flex.tablepadding1 .col-md-6,
        .col-md-12.d-flex.tablepadding .col-md-4.d-flex .col-md-6,
        .col-md-12.d-flex.tablepadding3 .col-md-4,
        .col-md-12.d-flex.tablepadding2 .col-md-6,
        .col-md-12.d-flex.tablepadding4,
        .col-md-2,
        .col-md-3 {
            border: 1px solid #ccc;
            padding: 3px 15px;
            margin: 0px 0px;
        }

        .col-md-6.d-flex {
            padding: 0px !important;
        }

        .card {
            border: 1px solid #3879a6;
            margin-bottom: 1.875rem;
        }
        /* .card.bg-primary.text-white {
    background: linear-gradient(0deg, rgba(25, 135, 84, 1) 0%, rgb(18 101 102) 100%);
}
.bg-success, .badge-success {
    background: linear-gradient(0deg, rgba(74, 112, 29, 1) 0%, rgba(6, 111, 34, 1) 100%);
} */
        h5 {
            color: #fff;
            padding: 2px 13px;
            border-radius: 4px;
            text-align: center;
            margin-bottom: 0px !important;
            padding-bottom: 0px !important;
            text-transform: uppercase;
            background: #066f22;
            margin-top: -18px;
            text-shadow: 1px 2px 3px #000;
            border: 1px solid #066f22;
        }

        div#bodypart {
            background: url(../images/background/bg1.jpg);
            background-size: contain;
            background-position: top;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <!-- Main Wrapper -->
        <div class="main-wrapper">

            <!-- Header -->
            <div class="header">

                <!-- Logo -->
                <div class="header-left">
                    <a href="index.html" class="logo">
                        <img src="assets/admin/img/logo.png" alt="Logo">
                    </a>
                    <a href="index.html" class="logo logo-small">
                        <img src="assets/admin/img/logo-small.png" alt="Logo" width="30" height="30">
                    </a>
                </div>
                <!-- /Logo -->

                <h4 class="ml-3 mt-3">Intent To Invest Application Details</h4>



                <!-- Mobile Menu Toggle -->

                <!-- /Mobile Menu Toggle -->

                <!-- Header Right Menu -->

                <!-- /Header Right Menu -->

            </div>
            <!-- /Header -->

            <!-- Sidebar -->

            <!-- /Sidebar -->

            <!-- Page Wrapper -->
            <div id="bodypart">
               
                    <div class="row">

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
                        <asp:HiddenField ID="hdnUserID" runat="server" />
                        <div class="col-xl-8 col-sm-12 col-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="col-md-12">
                                        <h5>Company Details</h5>
                                        <hr />
                                    </div>
                                    <div class="col-md-12 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Name of Company:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblNameCompany" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">PAN:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblPan" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card">
                                <div class="card-body">
                                    <div class="col-md-12">
                                        <h5>Registered Office Address</h5>
                                        <hr />
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Address Line - 1:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblAddress" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Country:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblCountry" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Phone No:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblPhone" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Pin/Zip Code:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblPin" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Email ID:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblEmailId" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Fax No:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblFax" runat="server"></asp:Label></div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Website:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblWebsit" runat="server"></asp:Label></div>
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
                                        <h5>Contact Details</h5>
                                        <hr />
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Name:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblNames" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Designation:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblDesignation" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Email ID:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblEmail" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Mobile No:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblMobile" runat="server"></asp:Label></div>
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
                                        <h5>Project Details</h5>
                                        <hr />
                                    </div>
                                    <div class="col-md-12 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Project Proposal:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblProjectProposal" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Have you signed the MoU/Investment Intention in previous events:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblInvestment" runat="server"></asp:Label></div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Project Category:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblPCB" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Sectors:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblSectors" runat="server"></asp:Label></div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">
                                                Proposed Investment
                                        <br />
                                                (Rs. in Crore):
                                            </div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblProposedInvest" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Proposed Employment:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblEmployment" runat="server"></asp:Label></div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Proposed Project Location:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblProjectLocation" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Expected Year of Commencement of Production:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblExtendYear" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--	<div class="col-xl-4 col-sm-12 col-12">
					<div class="card">
						<div class="card-body">
							<div class="col-md-12">
								<h5>Proposed maximum working hours</h5>
								<hr />
							</div>

							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Per day</div>
								<div class="col-md-6">5</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Per month</div>
								<div class="col-md-6">150</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Expected month and year of trial production</div>
								<div class="col-md-6">02-06-2021</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Probable date of requirement of power supply</div>
								<div class="col-md-6">02-06-2021</div>
							</div>
						</div>
					</div>
				</div>--%>
                    </div>

                    <div class="row">
                        <div class="col-xl-8 col-sm-12 col-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="col-md-12">
                                        <h5>Expectation/Support required from the State Govt</h5>
                                        <hr />
                                    </div>
                                    <div class="col-md-12 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Expectation/Support required from the State Govt:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblExpectation" runat="server"></asp:Label></div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

              
            </div>
            <!-- /Page Wrapper -->
            <br />
            <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                type="button" value="Print" /><br />
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/Home.aspx"
                ForeColor="#3366CC">Home</asp:HyperLink>
            <br />
        </div>

        <!-- /Main Wrapper -->

        <!-- jQuery -->

    </form>
</body>

</html>
