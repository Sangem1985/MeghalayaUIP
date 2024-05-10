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

			<h4 class="ml-3 mt-3">Invest Meghalaya Common Application Form</h4>



			<!-- Mobile Menu Toggle -->

			<!-- /Mobile Menu Toggle -->

			<!-- Header Right Menu -->

			<!-- /Header Right Menu -->

		</div>
		<!-- /Header -->

		<!-- Sidebar -->

		<!-- /Sidebar -->

		<!-- Page Wrapper -->
		<div class="" id="bodypart">
			<div class="row ">
				<div class="col-xl-8 col-sm-12 col-12 ">
					<div class="card">
						<div class="card-body">
							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">UID No</div>
									<div class="col-md-6">MIC003003184743</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">NAME OF INDUSTRIAL UNDERTAKING</div>
									<div class="col-md-6">ABC_ABC</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">NAME OF PROMOTER</div>
									<div class="col-md-6">KFC</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">S/o. D/o. W/o</div>
									<div class="col-md-6">Kalyanbabu</div>
								</div>
							</div>

						</div>
					</div>
				</div>
				<div class="col-xl-4 col-sm-12 col-12">
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
				</div>
			</div>

			<div class="row">
				<div class="col-xl-12 col-sm-12 col-12">
					<div class="card">
						<div class="card-body">
							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Survey No</div>
									<div class="col-md-6">458/EE4/1,458/E4,458/E3</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Nameof District Grampanchayat/IE/IDA/SEZ</div>
									<div class="col-md-6">IP_GACHIBOWLI</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Village/Town</div>
									<div class="col-md-6">GACHIBOWLI</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Mandal</div>
									<div class="col-md-6">Serilingampally</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">District</div>
									<div class="col-md-6">Rangareddy</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">PinCode</div>
									<div class="col-md-6">500097</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Email-ID</div>
									<div class="col-md-6">kalyan@gmail.com</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Telephone</div>
									<div class="col-md-6">-</div>
								</div>
								<div class="col-md-4 d-flex">
									<div class="col-md-6">Total extent of site area as per document(in Sq.mts)</div>
									<div class="col-md-6">295700.00</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
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
								<h5>ADDRESS OF THE ENTREPRENUER</h5>
								<hr />
							</div>
							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Door No.</div>
									<div class="col-md-6">56 </div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Street Name</div>
									<div class="col-md-6">Ashok Nagar</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Village/Town</div>
									<div class="col-md-6">Uppal</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">State</div>
									<div class="col-md-6">Telangana</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">District</div>
									<div class="col-md-6">Adilabad</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Pincode</div>
									<div class="col-md-6">500035</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Cell No</div>
									<div class="col-md-6">9898989568</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Mandal</div>
									<div class="col-md-6">Uppal</div>
								</div>
							</div>
							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Email-ID</div>
									<div class="col-md-6">kalyan@gmail.com</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Telephone</div>
									<div class="col-md-6">040-2548 5698</div>
								</div>
							</div>
						</div>
					</div>
					<div class="card">
						<div class="card-body">
							<div class="col-md-12">
								<h5>Category of Registration</h5>
								<hr />
							</div>
							<div class="col-md-12 mb-4 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Registration No</div>
									<div class="col-md-6">202403245689</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Date</div>
									<div class="col-md-6">24-03-2024</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="col-xl-4 col-sm-12 col-12">
					<div class="card">
						<div class="card-body">
							<div class="col-md-12">
								<h5>PROPOSAL</h5>
								<hr />
							</div>

							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Proposal For</div>
								<div class="col-md-6">New</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								Proposed Investment
							</div>

							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Land Value(in Lakhs)</div>
								<div class="col-md-6">60.00</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Building Value(in Lakhs)</div>
								<div class="col-md-6">100.00</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Plant and Machinery Value (in Lakhs)</div>
								<div class="col-md-6">100.00</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Total Value (in Lakhs)</div>
								<div class="col-md-6">260</div>
							</div>
							<div class="col-md-12 mb-4 d-flex tablepadding1">
								<div class="col-md-6">Annual Turnover(in Lakhs)</div>
								<div class="col-md-6">60</div>
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
								<div class="col-md-6">Rope (plastic and cotton)</div>
							</div>
							<div class="col-md-12 tablepadding4">
								<b>LINE OF MANUFACTURE</b>
							</div>
							<div class="col-md-12 d-flex tablepadding2">
								<div class="col-md-2">S No</div>
								<div class="col-md-3">Item</div>
								<div class="col-md-2">Quantity</div>
								<div class="col-md-2">Units</div>
								<div class="col-md-3">Quantity Per</div>
							</div>
							<div class="col-md-12 d-flex tablepadding2">
								<div class="col-md-2">1</div>
								<div class="col-md-3">GCMGFC</div>
								<div class="col-md-2">200</div>
								<div class="col-md-2">KG</div>
								<div class="col-md-3">Day</div>
							</div>
							<div class="col-md-12 tablepadding4">
								<b>RAW MATERIALS USED IN PROCESS</b>
							</div>
							<div class="col-md-12 d-flex tablepadding2">
								<div class="col-md-2">S No</div>
								<div class="col-md-3">Item</div>
								<div class="col-md-2">Quantity</div>
								<div class="col-md-2">Units</div>
								<div class="col-md-3">Quantity Per</div>
							</div>
							<div class="col-md-12 d-flex tablepadding2">
								<div class="col-md-2">1</div>
								<div class="col-md-3">GCMGFC</div>
								<div class="col-md-2">200</div>
								<div class="col-md-2">KG</div>
								<div class="col-md-3">Day</div>
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
								<div class="col-md-4">5</div>
								<div class="col-md-4">45</div>
							</div>
							<div class="col-md-12 d-flex tablepadding3">
								<div class="col-md-4">INDIRECT</div>
								<div class="col-md-4">0</div>
								<div class="col-md-4">0</div>
							</div>
							<div class="col-md-12 mb-5 d-flex tablepadding3">
								<div class="col-md-4">TOTAL</div>
								<div class="col-md-4">5</div>
								<div class="col-md-4">45</div>
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
									<div class="col-md-6">Contracted maximum demand in KVA</div>
									<div class="col-md-6">6501 </div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Connected load in KW/HP</div>
									<div class="col-md-6">0/8234</div>
								</div>
							</div>

							<div class="col-md-12 mb-4 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Aggregate Installed Capacity OF The transformer to be
										installed by the Entreprenuer</div>
									<div class="col-md-6">0</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Required Voltage Level</div>
									<div class="col-md-6">33 KV</div>
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
									<div class="col-md-6">Quantity of water water required for consumptive use (in
										KL/Day)</div>
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
								<div class="col-md-6">Whether the Hydraulic Platform can be moved all around the bldg
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
							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Height of the building (in mtrs.)</div>
									<div class="col-md-6">20.00</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Height of each floor (in mtrs.)</div>
									<div class="col-md-6">3.0</div>
								</div>
							</div>
							<div class="col-md-12 tablepadding4">
								<b>Means of Escape</b>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Intrnal Stair Case</div>
									<div class="col-md-6">-</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">External Stair Case</div>
									<div class="col-md-6">1.00</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Width of Stair Case (min 1)</div>
									<div class="col-md-6">-</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">No Of Exits</div>
									<div class="col-md-6">-</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Width of each exit (in mts.)</div>
									<div class="col-md-6">-</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Width of Stair Case(min 1.5 mtrs)</div>
									<div class="col-md-6">-</div>
								</div>
							</div>
							<div class="col-md-12 tablepadding4">
								<b>Open spaces all around the building: (in mts)</b>
							</div>
							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">East</div>
									<div class="col-md-6">1.00</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">West</div>
									<div class="col-md-6">1.00</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">North</div>
									<div class="col-md-6">1.00</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">South</div>
									<div class="col-md-6">1.00</div>
								</div>
							</div>
							<div class="col-md-12 tablepadding4">
								<b>Automatic Fire Fighting System</b>
							</div>


							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Sprinkler</div>
									<div class="col-md-6">No</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Foam</div>
									<div class="col-md-6">-</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">CO2</div>
									<div class="col-md-6">No</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">DCP</div>
									<div class="col-md-6">-</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Fire service inlet: One - 4 way</div>
									<div class="col-md-6">-</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Under ground static water tank capacity (in hydrants lts.)
									</div>
									<div class="col-md-6">-</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Number of Court yard</div>
									<div class="col-md-6">-</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Fire pumps - Diesel</div>
									<div class="col-md-6">-</div>
								</div>
							</div>

							<div class="col-md-12 d-flex tablepadding">
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Fire pumps - Electrical 15 mtrs. To 30 mtrs. Ht.</div>
									<div class="col-md-6">-</div>
								</div>
								<div class="col-md-6 d-flex">
									<div class="col-md-6">Fire pumps - Electrical 30 mtrs. To 45 mtrs. Ht.</div>
									<div class="col-md-6">-</div>
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
								<div class="col-md-6">ghm</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Timber Length</div>
								<div class="col-md-6">1</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Timber Volume</div>
								<div class="col-md-6">1</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Timber Girth</div>
								<div class="col-md-6">1</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Estimated Firewood</div>
								<div class="col-md-6">1</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">Pole</div>
								<div class="col-md-6">1</div>
							</div>

							<div class="col-md-12 tablepadding4">
								<b>B. Boundary Description</b>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">North</div>
								<div class="col-md-6">1</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">East</div>
								<div class="col-md-6">1</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">West</div>
								<div class="col-md-6">1</div>
							</div>
							<div class="col-md-12 d-flex tablepadding1">
								<div class="col-md-6">South</div>
								<div class="col-md-6">1</div>
							</div>
							
						</div>
					</div>
					<div class="col-md-12">
						<div class="alert alert-danger" role="alert">
							<b>Note</b> : "please make sure all details are correct"
						  </div>
						  
						 
						  <div class="d-grid gap-2 d-md-flex justify-content-md-end">
							<a href="../admin/index.html"><button class="btn btn-warning mr-5" type="button">Home</button></a>
							<button type="button" class="btn btn-dark ml-5">Print</button>
							
						  </div>
					</div>
				</div>
			</div>

		</div>
		<!-- /Page Wrapper -->

	</div>
	<!-- /Main Wrapper -->

	<!-- jQuery -->
	
</form>
</body>

</html>