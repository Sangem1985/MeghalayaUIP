<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="CFEDeptDashboard.aspx.cs" Inherits="MeghalayaUIP.Dept.CFE.CFEDeptDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/deptdashbaords.css" rel="stylesheet" />
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card">
                <div class="card-header">
                    <h3>Pre-Scrutiny Stage</h3>
                </div>
                <section id="dashboardcount1">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-purpule shadow-dark text-center border-radius-xl mt-n4 position-absolute">
                                           <i class="fi fi-rr-file-download"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Stage</p>
                                            
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">No. of Applications Recevied</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-dark shadow-dark text-center border-radius-xl mt-n4 position-absolute">
                                           <i class="fi fi-rr-search-alt"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Completed</p>
                                            
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">With in 3 Days <br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-primary shadow-primary text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-file-circle-info"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Completed</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Beyond 3 Days<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-success shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                           <i class="fi fi-rr-memo-circle-check"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                           <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Completed</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Total Applications<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-primary shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-vote-nay"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                           <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Completed</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">No. of Applications Rejected</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-wait shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-pending"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Completed</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Approvals Awaiting Payment</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        
                        <div class="row">
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4"></div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-dark shadow-dark text-center border-radius-xl mt-n4 position-absolute">
                                           <i class="fi fi-rr-search-alt"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Pending</p>
                                            
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">With in 3 Days<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-primary shadow-primary text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-file-circle-info"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Pending</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Beyond 3 Days<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-primary shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-file-import"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                           <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Pending</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Today Last Day<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-success shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-memo-circle-check"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                           <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Pending</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Total Applications<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-wait shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-pending"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Pending</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Applications Awaiting Query Response</p>
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
                    <h3>Approval Stages</h3>
                </div>
                <section id="dashboardcount1">
                    <div class="container-fluid">
                        <div class="row">
                           
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-dark shadow-dark text-center border-radius-xl mt-n4 position-absolute">
                                           <i class="fi fi-rr-search-alt"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Approval Under Process</p>
                                            
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">With in 3 Days<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-primary shadow-primary text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-file-circle-info"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Approval Under Process</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Beyond 3 Days<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-info shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-file-import"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                           <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Approval Under Process</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Today Last Day<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-success shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                           <i class="fi fi-rr-memo-circle-check"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                           <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Approval Under Process</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Total Applications<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            
                            
                        </div>
                        <br />
                        
                        <div class="row">
                            
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-dark shadow-dark text-center border-radius-xl mt-n4 position-absolute">
                                           <i class="fi fi-rr-search-alt"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Approval Issued</p>
                                            
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">With in 3 Days<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-primary shadow-primary text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-file-circle-info"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Approval Issued</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Beyond 3 Days<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-success shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-memo-circle-check"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                           <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Approval Issued</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Total Applications<br />&nbsp;</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-info shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-vote-nay"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                           <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Approval Issued</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">No. of Applications Rejected</p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6">
                                <div class="card">
                                    <div class="card-header p-3 pt-2">
                                        <div class="icon icon-lg icon-shape bg-gradient-info shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                            <i class="fi fi-rr-vote-nay"></i>
                                        </div>
                                        <div class="text-end pt-1">
                                            <h4 class="mb-0">10</h4>
                                            <p class="text-sm mb-0 text-capitalize">Approval Issued</p>
                                        </div>
                                    </div>
                                    <hr class="dark horizontal my-0">
                                    <div class="card-footer p-3">
                                        <p class="mb-0">Applications Appeal Against Rejection</p>
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
