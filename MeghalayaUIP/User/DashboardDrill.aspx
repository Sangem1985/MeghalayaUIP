<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="DashboardDrill.aspx.cs" Inherits="MeghalayaUIP.User.DashboardDrill" %>
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
						<div class="col-md-2">Unit ID</div>
						
						<div class="col-md-3 d-flex"><spna class="dots">:</spna>
							<select class="form-control" aria-label="Default select example">
								<option selected>Open this select Unit ID</option>
								<option value="1">One</option>
								<option value="2">Two</option>
								<option value="3">Three</option>
							  </select>
						</div>
					</div>
					<div class="col-md-12 row mt-2 mb-4">
						<div class="col-md-2">2. Unit Name</div>
						
						<div class="col-md-3"><spna class="dots">:</spna>Ajantha Company Pvt ltd...</div>
						<div class="col-md-2">&nbsp;</div>
						<div class="col-md-2">Unit Name</div>
						
						<div class="col-md-3 d-flex"><spna class="dots">:</spna>
							<select class="form-control" aria-label="Default select example">
								<option selected>Open this select Unit Name</option>
								<option value="1">One</option>
								<option value="2">Two</option>
								<option value="3">Three</option>
							  </select>
						</div>
					</div>


					
					
												<div class="card card-body">
													<div class="table-responsive under table-striped table-hover drilldown">
														<table class="table table-bordered mb-0">
															<thead>
																
																<tr>
																	<th width="20%">Approvals</th>
																	<th>Total Applications</th>
																	<th>Approved</th>
																	<th>Under Process</th>
																	<th>Rejected</th>
																	<th>Query</th>
																</tr>
															</thead>
															<tbody>
																<!-- <tr>
																	<th scope="col">Registration Under MIIPP 2024 Status</th>
																	<td><span class="status">2</span></td>
																	<td><span class="status1">9</span></td>
																	<td><span class="status2">5</span></td>
																	<td><span class="status3">1</span></td>
																</tr> -->
																<tr>
																	<th scope="col" style="text-align: left !important;">Pre-Establishment Approvals</th>
																	<td><a href="Dashboardstatus.aspx" target="_blank"><span class=status4>15</span></a></td>
																	<td><span class="status">2</span></td>
																	<td><span class="status1">9</span></td>
																	<td><span class="status2">5</span></td>
																	<td><span class="status3">1</span></td>
																</tr>
																<tr>
																	<th scope="col" style="text-align: left !important;">Pre-Operational Approvals</th>
																	<td><a href="Dashboardstatus.aspx" target="_blank"><span class=status4>15</span></a></td>
																	<td><span class="status">2</span></td>
																	<td><span class="status1">9</span></td>
																	<td><span class="status2">5</span></td>
																	<td><span class="status3">1</span></td>
																</tr>
																<tr>
																	
																<th scope="col" style="text-align: left !important;">Incentives</th>
																<td><a href="Dashboardstatus.aspx" target="_blank"><span class=status4>15</span></a></td>
																<td><span class="status">2</span></td>
																	<td><span class="status1">9</span></td>
																	<td><span class="status2">5</span></td>
																	<td><span class="status3">1</span></td>
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
</asp:Content>
