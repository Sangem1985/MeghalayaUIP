<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="Dashboardstatus.aspx.cs" Inherits="MeghalayaUIP.User.Dashboardstatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../assets/admin/css/user.css" rel="stylesheet" />
    <div class="page-wrapper griddesignmulticount">

			<div class="content container-fluid">

				

				<div class="card">
					<div class="card-header d-flex justify-content-between">
                    <h4 class="card-title">Welcome to Dashboard</h4>
                    <h4 class="card-title">
                        <label id="unitname" runat="server"></label>
                    </h4>
                </div>
					<section id="dashboardcount" class="mt-2">
						<div class="container-fluid">
							<div class="row">

					<div class="col-md-12 row mt-4">
						<div class="col-md-2">1. Unit ID</div>
						
						<div class="col-md-3 fw-bold text-info"><spna class="dots">:</spna>APRJY200C</b></div>
						<div class="col-md-2">&nbsp;</div>
						<div class="col-md-2">3. Date of Unit Application</div>
						
						<div class="col-md-3"><spna class="dots">:</spna>03-05-2024</div>
					</div>
					<div class="col-md-12 row mt-2 mb-4">
						<div class="col-md-2">2. Unit Name</div>
						
						<div class="col-md-3"><spna class="dots">:</spna>Ajantha Company Pvt ltd...</div>
						<div class="col-md-2">&nbsp;</div>
						<div class="col-md-2">4. Category of Industry</div>
						
						<div class="col-md-3"><spna class="dots">:</spna>Small</div>
					</div>
					
					<div class="card-body table fix">
						<div class="table-responsive table-hover table-striped table-bordered">
							<table class="table table-bordered mb-0">
								<thead>
									<tr>
										<th colspan="4"></th>
										
										<th colspan="3" style="text-align: center;">Pre-Scrutiny Status</th>
										<th></th>
										<th colspan="2" style="text-align: center;">Approval Stage</th>
										<th></th>
										
									</tr>
									<tr>
										<th rowspan="2">S.No.</th>
										<th>Name of Approval</th>
										<th>Approval Applied<br/> Date</th>
										<th>Date of Payment</th>
										<th>Date of Query</th>
										<th>Date of Query <br/>Response</th>
										<th>Pre-Scrutiny <br/>Completion <br/>Date</th>
										<th>Date of <br/>Additional<br/> Payment</th>
										<th>Date Recevied<br/> to Approval<br/> Stage</th>
										<th>Date of <br/>Completion</th>
										<th>Status</th>
									</tr>
								</thead>
								<tbody>
									<tr>
										<td>1</td>
										<td>Factory Licence</td>
										<td>03-01-2024</td>
										<td class="text-info">09-03-2024</td>
										<td></td>
										<td></td>
										<td>09-03-2024</td>
										<td>09-03-2024</td>
										<td>09-03-2024</td>
										<td>09-03-2024</td>
										<td class="text-info">Approved</td>
									</tr>
									<tr>
										<td>2</td>
										<td>Factory Licence</td>
										<td>03-01-2024</td>
										<td class="text-info">09-03-2024</td>
										<td></td>
										<td></td>
										<td>09-03-2024</td>
										<td>09-03-2024</td>
										<td>09-03-2024</td>
										<td>09-03-2024</td>
										<td class="text-info">Approved</td>
									</tr>
									
								</tbody>
							</table>
						</div>
					</div>

								</div>
							</div>
						</section>
											</div>

			
				</div>

				

				

			</div>
</asp:Content>
