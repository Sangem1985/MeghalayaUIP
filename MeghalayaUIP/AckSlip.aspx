﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AckSlip.aspx.cs" Inherits="MeghalayaUIP.AckSlip" %>

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
							<div class="col-sm-12 m-b-20 text-center" style="display: flex;justify-content: center;">
								<img alt="Logo" class="img-fluid" src="assets/admin/img/acklogo.jpg" "="">
							</div>
                
							<div class="col-sm-6 m-b-20 text-center"  style="display: flex;justify-content: center;">
								<div class="invoice-details text-center d-flex" style="text-align: center;">
									<h3 class="text-uppercase" style="margin-bottom: 0;"><u>ACKNOWLEDGEMENT SLIP</u></h3>
									<h3>Registration for MIIPP</h3>
									
								</div>
							</div>
						</div>
						<div class="row">
							<div class="col-sm-12 m-b-20">
								<ul class="list-unstyled mb-0 list-item">
									<li>Date : <label runat="server" id="lblDate" ></label></li>
									<li><label runat="server" id="lblEnterPrise" ></label> ,</li>
									<li>Your intent to invest in Meghalaya has been successfully submitted to Planning, Investment Promotion and<br />Sustainable Development Department, Meghalaya.</li>
									<li>Your Application reference number is : <label runat="server" id="lblUIDNo"><b>IMA/2024/00004</b></label></li>
								</ul>
							</div>
						</div>
						
						
						
						
					</div>
					<!-- /Invoice Container -->
					
				</div>			
			</div>
        </div>
    </form>
</body>
</html>