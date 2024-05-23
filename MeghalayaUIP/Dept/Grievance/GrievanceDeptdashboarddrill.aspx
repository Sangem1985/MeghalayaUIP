<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="GrievanceDeptdashboarddrill.aspx.cs" Inherits="MeghalayaUIP.Dept.Grievance.GrievanceDeptdashboarddrill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/deptdashbaords.css" rel="stylesheet" />
    <link href="../../assets/admin/css/deptdashboard3.css" rel="stylesheet" />
    <div class="page-wrapper cfeappldeptdrill">
        <div class="content container-fluid">
            <div class="col-md-12 row mb-3">
						
						<div class="col-md-6">&nbsp;</div>
						<div class="col-md-3">Grievance Applications Status</div>
						
						<div class="col-md-3 d-flex"><spna class="dots">:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</spna>
							<select class="form-control" aria-label="Default select example">
								<option selected="">Know Applications Status</option>
								<option value="1">Total</option>
								<option value="2">Pending</option>
								<option value="3">Redressed</option>
                                <option value="3">Rejected</option>
							  </select>
						</div>
					</div>
            <div class="card">
                <div class="card-header">
                    <h3>Grievance - Total Applications</h3>
                </div>
                <section id="dashboardcount3" class="mt-3 mb-3">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <a href="CFEApplDeptView.aspx">
                                <div class="card 2">
                                    <div class="card-headr">
                                        <div class="text">Pending With in 7 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-memo-circle-check"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                                    </a>
                            </div>
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 4">
                                    <div class="card-headr">
                                        <div class="text">Pending Beyond 7 Days</div>
                                        <div class="iocn"><i class="fi fi-tr-file-download"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 2">
                                    <div class="card-headr">
                                        <div class="text">Redressed With in 7 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 4">
                                    <div class="card-headr">
                                        <div class="text">Redressed Beyond 7 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4 mt-5">
                                <div class="card 2">
                                    <div class="card-headr">
                                        <div class="text">Rejected With in 7 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4 mt-5">
                                <div class="card 4">
                                    <div class="card-headr">
                                        <div class="text">Rejected Beyond 7 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
            
                            
                            
                            
                            
                        </div>
                    </div>
                </section>
            </div>
            <%--*************************************--%>
            <div class="card">
                <div class="card-header">
                    <h3>Grievance - Pending Applications</h3>
                </div>
                <section id="dashboardcount3" class="mt-3 mb-3">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <a href="CFEApplDeptView.aspx">
                                <div class="card 2">
                                    <div class="card-headr">
                                        <div class="text">Pending With in 7 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-memo-circle-check"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                                    </a>
                            </div>
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 4">
                                    <div class="card-headr">
                                        <div class="text">Pending Beyond 7 Days</div>
                                        <div class="iocn"><i class="fi fi-tr-file-download"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                          </div>
                    </div>
                </section>
            </div>

            <%--*************************************--%>
            <div class="card">
                <div class="card-header">
                    <h3>Grievance - Redressed Applications</h3>
                </div>
                <section id="dashboardcount3" class="mt-3 mb-3">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 2">
                                    <div class="card-headr">
                                        <div class="text">Redressed With in 7 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 4">
                                    <div class="card-headr">
                                        <div class="text">Redressed Beyond 7 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
            <%--*************************************--%>
            <div class="card">
                <div class="card-header">
                    <h3>Grievance - Rejected Applications</h3>
                </div>
                <section id="dashboardcount3" class="mb-3 mt-3">
                    <div class="container-fluid">
                        <div class="row">
                           <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 2">
                                    <div class="card-headr">
                                        <div class="text">Rejected With in 7 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 4">
                                    <div class="card-headr">
                                        <div class="text">Rejected Beyond 7 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
