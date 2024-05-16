<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="MainDashboard.aspx.cs" Inherits="MeghalayaUIP.User.MainDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<style>
	
	</style>
    
<div class="page-wrapper griddesignmulticount">

			<div class="content container-fluid">

				

				<div class="card">
					<div class="card-header">
						<h4 class="card-title">Welcome to Dashboard</h4>
						<h4 class="card-title">
                        <label id="unitname" runat="server"></label>
                    </h4>
					</div>
					<section id="dashboardcount">
						<div class="container-fluid">
							<div class="row">
								<table class="table table-bordered table-striped table-hover">
									<thead>
									  <tr>
										<th scope="col">Sl. No.</th>
										<th scope="col">Unit ID</th>
										<th scope="col">Unit Name</th>
										<th scope="col">Unit Address</th>
										<th scope="col">Registration Under<br/> MIIPP 2024 Status</th>
										<th scope="col">Pre-Establishment Approvals</th>
										<th scope="col">Pre-Operational Approvals</th>
										<th scope="col">Incentives</th>
									  </tr>
									</thead>
									<tbody>
										<tr style="border-bottom: 3px solid #fff !important;">
										<td scope="row">1</th>
										<td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample">ajsks50447s</a>
										</td>
										<td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample">Demo Company</a>
										</td>
										<td>Hyderabad</td>
										<td>Approved</td>
										<td class="count">10</td>
										<td class="count">12</td>
										<td class="count">1</td>
									  </tr>
									  <tr class="linedisbale">
										<td colspan="8">
											<div class="collapse" id="collapseExample">
												<div class="card card-body">
												  Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
												</div>
											  </div>
										</td>
									  </tr>
									  <tr style="border-bottom: 3px solid #fff !important;">
										<td scope="row">2</th>
										<td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample1" role="button" aria-expanded="false" aria-controls="collapseExample">ajsks50447s</a>
										</td>
										<td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample1" role="button" aria-expanded="false" aria-controls="collapseExample">Demo Company</a>
										</td>
										<td>Hyderabad</td>
										<td>Approved</td>
										<td class="count">10</td>
										<td class="count">12</td>
										<td class="count">1</td>
									  </tr>
									  <tr class="linedisbale">
										<td colspan="8">
											<div class="collapse" id="collapseExample1">
												<div class="card card-body">
													<div class="table-responsive under">
														<table class="table table-bordered mb-0">
															<thead>
																<tr class="head">
																	<td colspan="2">UNIT ID: KHJSK2542Jj</td>
																	<td colspan="4">UNIT NAME: Demo Company ltd..</td>
																</tr>
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
																	<th scope="col">Pre-Establishment Approvals</th>
																	<td><span class=status4>15</span></td>
																	<td><span class="status">2</span></td>
																	<td><span class="status1">9</span></td>
																	<td><span class="status2">5</span></td>
																	<td><span class="status3">1</span></td>
																</tr>
																<tr>
																	<th scope="col">Pre-Operational Approvals</th>
																	<td><span class=status4>15</span></td>
																	<td><span class="status">2</span></td>
																	<td><span class="status1">9</span></td>
																	<td><span class="status2">5</span></td>
																	<td><span class="status3">1</span></td>
																</tr>
																<tr>
																	
																<th scope="col">Incentives</th>
																<td><span class=status4>15</span></td>
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
										</td>
									  </tr>
									  <tr style="border-bottom: 3px solid #fff !important;">
										<td scope="row">3</th>
										<td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample3" role="button" aria-expanded="false" aria-controls="collapseExample">ajsks50447s</a>
										</td>
										<td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample3" role="button" aria-expanded="false" aria-controls="collapseExample">Demo Company</a>
										</td>
										<td>Hyderabad</td>
										<td>Approved</td>
										<td class="count">10</td>
										<td class="count">12</td>
										<td class="count">1</td>
									  </tr>
									  <tr class="linedisbale">
										<td colspan="8">
											<div class="collapse" id="collapseExample3">
												<div class="card card-body">
												  Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
												</div>
											  </div>
										</td>
									  </tr>
									  <tr style="border-bottom: 3px solid #fff !important;">
										<td scope="row">4</th>
										<td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample4" role="button" aria-expanded="false" aria-controls="collapseExample">ajsks50447s</a>
										</td>
										<td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample4" role="button" aria-expanded="false" aria-controls="collapseExample">Demo Company</a>
										</td>
										<td>Hyderabad</td>
										<td>Approved</td>
										<td class="count">10</td>
										<td class="count">12</td>
										<td class="count">1</td>
									  </tr>
									  <tr class="linedisbale">
										<td colspan="8">
											<div class="collapse" id="collapseExample4">
												<div class="card card-body">
													<div class="table-responsive under">
														<table class="table table-bordered mb-0">
															<thead>
																<tr class="head">
																	<td colspan="2">UNIT ID: KHJSK2542Jj</td>
																	<td colspan="3">UNIT NAME: Demo Company ltd..</td>
																</tr>
																<tr>
																	<th width="20%">Approvals</th>
																	<th>Approved</th>
																	<th>Under Process</th>
																	<th>Rejected</th>
																	<th>Query</th>
																</tr>
															</thead>
															<tbody>
																<tr>
																	<th scope="col">Registration Under MIIPP 2024 Status</th>
																	<td><span class="status">2</span></td>
																	<td><span class="status1">9</span></td>
																	<td><span class="status2">5</span></td>
																	<td><span class="status3">1</span></td>
																</tr>
																<tr>
																	<th scope="col">Pre-Establishment Approvals</th>
																	<td><span class="status">2</span></td>
																	<td><span class="status1">9</span></td>
																	<td><span class="status2">5</span></td>
																	<td><span class="status3">1</span></td>
																</tr>
																<tr>
																	<th scope="col">Pre-Operational Approvals</th>
																	<td><span class="status">2</span></td>
																	<td><span class="status1">9</span></td>
																	<td><span class="status2">5</span></td>
																	<td><span class="status3">1</span></td>
																</tr>
																<tr>
																	
																<th scope="col">Incentives</th>
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
										</td>
									  </tr>

									  
									 
									</tbody>
								  </table>
								
								  
								</div>
						</div>
						</section>

				
					<div class="card-body">
						<!-- Extra Large modal -->
						<!-- <button type="button" class="btn btn-outline-secondary" data-toggle="modal"
							data-target=".bd-example-modal-xl">Entrepreneur Dashboard - CFE<br /> (Pre-Establishment
							Approval)</button> -->
						<div class="modal fade bd-example-modal-xl" tabindex="-1" role="dialog"
							aria-labelledby="myLargeModalLabel" aria-hidden="true">
							<div class="modal-dialog modal-xl">
								<div class="modal-content">
									<div class="modal-header">
										<h4 class="modal-title cfe" id="myLargeModalLabel cfe">Entrepreneur Dashboard - CFE
											(Pre-Establishment Approval)</h4>
										<button class="close" type="button" data-dismiss="modal" aria-label="Close"
											data-original-title="" title=""><span aria-hidden="true">×</span></button>
									</div>
									<div class="modal-body">
										<div class="card">
											<div class="card-header">
												<h4 class="card-title">Consent for Establishment</h4>
											</div>
											<div class="row">
												<div class="col-md-3">
													<a href="Quesstionniare_cfe.html"><button type="button"
															class="btn btn-primary">
															<i class="fe fe-document"></i> Application Status <span
																class="badge badge-light text-success">Submitted</span>
														</button></a>
												</div>
												<div class="col-md-3">
													<a href="DepartmentApprovalDetails.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Common Application Form
															Status <span class="badge badge-light text-danger">Draft</span>
														</button></a>
												</div>
												<div class="col-md-3">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Approvals Required as per
															Invest Meghalaya <span class="badge badge-light">3</span>
														</button></a>
												</div>
												<div class="col-md-3">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Approvals already obtained
															<span class="badge badge-light">10</span>
														</button></a>
												</div>
											</div>
										</div>
										<div class="col-md-12 d-flex">
											<div class="col-md-6">
												<div class="card">
													<div class="card-header">
														<h4 class="card-title">Application Status</h4>
													</div>
													<div class="row" id="apstatus">
														<div class="col-md-6">
															<a href="index1.html"><button type="button" class="btn btn-primary">
																	<i class="fe fe-document"></i> Applied Approvals <br/>&nbsp;<span
																		class="badge badge-light">0</span>
																</button></a>
														</div>
														<div class="col-md-6">
															<a href="index1.html"><button type="button" class="btn btn-primary">
																	<i class="fe fe-document"></i> Yet to be applied <br/>&nbsp;<span
																		class="badge badge-light">10</span>
																</button></a>
														</div>
		
													</div>
												</div>
											</div>
											<div class="col-md-6">
												<div class="card">
													<div class="card-header">
														<h4 class="card-title">Payment Status</h4>
													</div>
													<div class="row"  id="ps">
														<div class="col-md-6">
															<a href="index1.html"><button type="button" class="btn btn-primary">
																	<i class="fe fe-document"></i> Additional Payment required
																	<span class="badge badge-light">0</span>
																</button></a>
														</div>
														<div class="col-md-6">
															<a href="index1.html"><button type="button" class="btn btn-primary">
																	<i class="fe fe-document"></i> Payment Paid <br/>&nbsp; <span
																		class="badge badge-light">10</span>
																</button></a>
														</div>
		
													</div>
												</div>
											</div>
										</div>


										<div class="card">
											<div class="card-header">
												<h4 class="card-title">Pre-Scrutiny Status</h4>
											</div>
											<div class="row" id="pss">
												<div class="col-md-2">
													<a href="Quesstionniare_cfo.html"><button type="button"
															class="btn btn-primary">
															<i class="fe fe-document"></i> Query Raised <span
																class="badge badge-light">0</span>
														</button></a>
												</div>
												<div class="col-md-2">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Query Respond <span class="badge badge-light">0</span>
														</button></a>
												</div>
												<div class="col-md-2">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Yet to Respond <span
																class="badge badge-light">3</span>
														</button></a>
												</div>
												<div class="col-md-2">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Rejected <br/>&nbsp;
															<span class="badge badge-light">0</span>
														</button></a>
												</div>
												<div class="col-md-2">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Completed <br/>&nbsp;
															<span class="badge badge-light">3</span>
														</button></a>
												</div>
												<div class="col-md-2">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Pending <br/>&nbsp;
															<span class="badge badge-light">0</span>
														</button></a>
												</div>
											</div>
										</div>

										

										<div class="card">
											<div class="card-header">
												<h4 class="card-title">Approval Status</h4>
											</div>
											<div class="row" id="ais">
												<div class="col-md-4">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Approval - Issued <br/>&nbsp;<span
																class="badge badge-light">0</span>
														</button></a>
												</div>
												<div class="col-md-4">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Approval - Pending <br/>&nbsp;<span
																class="badge badge-light">1</span>
														</button></a>
												</div>
												<div class="col-md-4">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Approval - Rejected <br/>&nbsp;<span
																class="badge badge-light">10</span>
														</button></a>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
						<!-- Large modal-->
						<!-- <button class="btn btn-outline-secondary" type="button" data-toggle="modal"
							data-target=".bd-example-modal-lg" data-original-title="" title="">Entrepreneur Dashboard -
							CFO<br /> (Pre-Operational Approval)</button> -->
						<div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog"
							aria-labelledby="myLargeModalLabel" aria-hidden="true">
							<div class="modal-dialog modal-xl">
								<div class="modal-content">
									<div class="modal-header">
										<h4 class="modal-title" id="myLargeModalLabel cfo">Entrepreneur Dashboard - CFO
											(Pre-Operational Approval)</h4>
										<button class="close" type="button" data-dismiss="modal" aria-label="Close"
											data-original-title="" title=""><span aria-hidden="true">×</span></button>
									</div>
									<div class="modal-body">
										<div class="card">
											<div class="card-header">
												<h4 class="card-title">Consent for Establishment</h4>
											</div>
											<div class="row">
												<div class="col-md-3">
													<a href="Quesstionniare_cfo.html"><button type="button"
															class="btn btn-primary">
															<i class="fe fe-document"></i> Application Status <span
																class="badge badge-light">Submitted</span>
														</button></a>
												</div>
												<div class="col-md-3">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Common Application Form
															Status <span class="badge badge-light">Draft</span>
														</button></a>
												</div>
												<div class="col-md-3">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Approvals Required as per
															Invest Meghalaya <span class="badge badge-light">3</span>
														</button></a>
												</div>
												<div class="col-md-3">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Approvals already obtained
															<span class="badge badge-light">10</span>
														</button></a>
												</div>
											</div>
										</div>
										<div class="col-md-12 d-flex">
											<div class="col-md-6">
												<div class="card">
													<div class="card-header">
														<h4 class="card-title">Application Status</h4>
													</div>
													<div class="row" id="apstatus">
														<div class="col-md-6">
															<a href="index1.html"><button type="button" class="btn btn-primary">
																	<i class="fe fe-document"></i> Applied Approvals <br/>&nbsp;<span
																		class="badge badge-light">0</span>
																</button></a>
														</div>
														<div class="col-md-6">
															<a href="index1.html"><button type="button" class="btn btn-primary">
																	<i class="fe fe-document"></i> Yet to be applied <br/>&nbsp;<span
																		class="badge badge-light">10</span>
																</button></a>
														</div>
		
													</div>
												</div>
											</div>
											<div class="col-md-6">
												<div class="card">
													<div class="card-header">
														<h4 class="card-title">Payment Status</h4>
													</div>
													<div class="row"  id="ps">
														<div class="col-md-6">
															<a href="index1.html"><button type="button" class="btn btn-primary">
																	<i class="fe fe-document"></i> Additional Payment required
																	<span class="badge badge-light">0</span>
																</button></a>
														</div>
														<div class="col-md-6">
															<a href="index1.html"><button type="button" class="btn btn-primary">
																	<i class="fe fe-document"></i> Payment Paid <br/>&nbsp; <span
																		class="badge badge-light">10</span>
																</button></a>
														</div>
		
													</div>
												</div>
											</div>
										</div>


										<div class="card">
											<div class="card-header">
												<h4 class="card-title">Pre-Scrutiny Status</h4>
											</div>
											<div class="row" id="pss">
												<div class="col-md-2">
													<a href="Quesstionniare_cfo.html"><button type="button"
															class="btn btn-primary">
															<i class="fe fe-document"></i> Query Raised <span
																class="badge badge-light">0</span>
														</button></a>
												</div>
												<div class="col-md-2">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Query Respond <span class="badge badge-light">0</span>
														</button></a>
												</div>
												<div class="col-md-2">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Yet to Respond <span
																class="badge badge-light">3</span>
														</button></a>
												</div>
												<div class="col-md-2">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Rejected <br/>&nbsp;
															<span class="badge badge-light">0</span>
														</button></a>
												</div>
												<div class="col-md-2">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Completed <br/>&nbsp;
															<span class="badge badge-light">3</span>
														</button></a>
												</div>
												<div class="col-md-2">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Pending <br/>&nbsp;
															<span class="badge badge-light">0</span>
														</button></a>
												</div>
											</div>
										</div>

										

										<div class="card">
											<div class="card-header">
												<h4 class="card-title">Approval Status</h4>
											</div>
											<div class="row" id="ais">
												<div class="col-md-4">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Approval - Issued <br/>&nbsp;<span
																class="badge badge-light">0</span>
														</button></a>
												</div>
												<div class="col-md-4">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Approval - Pending <br/>&nbsp;<span
																class="badge badge-light">1</span>
														</button></a>
												</div>
												<div class="col-md-4">
													<a href="index1.html"><button type="button" class="btn btn-primary">
															<i class="fe fe-document"></i> Approval - Rejected <br/>&nbsp;<span
																class="badge badge-light">10</span>
														</button></a>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
						<!-- Small modal-->
						<!-- <button class="btn btn-outline-secondary" type="button" data-toggle="modal"
							data-target=".bd-example-modal-sm" data-original-title="" title="">Others<br /> (Grievance,
							Incentive, Raw material, Help desk)</button> -->
						<div class="modal fade bd-example-modal-sm" tabindex="-1" role="dialog"
							aria-labelledby="mySmallModalLabel" aria-hidden="true">
							<div class="modal-dialog modal-sm">
								<div class="modal-content">
									<div class="modal-header">
										<h4 class="modal-title" id="mySmallModalLabel">Others</h4>
										<button class="close" type="button" data-dismiss="modal" aria-label="Close"
											data-original-title="" title=""><span aria-hidden="true">×</span></button>
									</div>
									<div class="modal-body">Page under Process</div>
								</div>
							</div>
						</div>
					</div>
				</div>

				

				

			</div>
		</div>
</asp:Content>
