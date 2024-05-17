<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="MainDashboard.aspx.cs" Inherits="MeghalayaUIP.User.MainDashboard" %>

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
										<tr>
										<td scope="row">1</td>
										<td><a href="DashboardDrill.aspx" target="_blank">APRJY200C</a></td>
										<td><a href="DashboardDrill.aspx" target="_blank">Demo Company</a></td>
										<td>Hyderabad</td>
										<td>Approved</td>
										<td class="count">10</td>
										<td class="count">12</td>
										<td class="count">1</td>
									  </tr>
									  <tr>
										<td scope="row">1</td>
										<td><a href="DashboardDrill.aspx" target="_blank">APRJY200C</a></td>
										<td><a href="DashboardDrill.aspx" target="_blank">Demo Company</a></td>
										<td>Hyderabad</td>
										<td>Approved</td>
										<td class="count">10</td>
										<td class="count">12</td>
										<td class="count">1</td>
									  </tr>
									  <tr>
										<td scope="row">1</td>
										<td><a href="DashboardDrill.aspx" target="_blank">APRJY200C</a></td>
										<td><a href="DashboardDrill.aspx" target="_blank">Demo Company</a></td>
										<td>Hyderabad</td>
										<td>Approved</td>
										<td class="count">10</td>
										<td class="count">12</td>
										<td class="count">1</td>
									  </tr>
									  <tr>
										<td scope="row">1</td>
										<td><a href="DashboardDrill.aspx" target="_blank">APRJY200C</a></td>
										<td><a href="DashboardDrill.aspx" target="_blank">Demo Company</a></td>
										<td>Hyderabad</td>
										<td>Approved</td>
										<td class="count">10</td>
										<td class="count">12</td>
										<td class="count">1</td>
									  </tr>
									  <tr>
										<td scope="row">1</td>
										<td><a href="DashboardDrill.aspx" target="_blank">APRJY200C</a></td>
										<td><a href="DashboardDrill.aspx"s target="_blank">Demo Company</a></td>
										<td>Hyderabad</td>
										<td>Approved</td>
										<td class="count">10</td>
										<td class="count">12</td>
										<td class="count">1</td>
									  </tr>

									  
									 
									</tbody>
								  </table>
								
								  
								</div>
						</div>
						</section>


                
            </div>





        </div>
    </div>
</asp:Content>
