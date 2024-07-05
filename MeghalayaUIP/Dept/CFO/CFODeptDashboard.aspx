<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="CFODeptDashboard.aspx.cs" Inherits="MeghalayaUIP.Dept.CFO.CFODeptDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/deptdashbaords.css" rel="stylesheet" />
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/DeptDashBoard.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="#">Pre-Opearational</a></li>
            <li class="breadcrumb-item active" aria-current="page">Department Dashboard</li>
        </ol>
    </nav>
    <div class="page-wrapper cfodeptdashboard">
        <div class="content container-fluid">
            <div class="col-md-11">
                <h4 style="margin-left: -10px; padding-top: 20px">Pre-Opearational Applications :
                 <asp:Label runat="server" ID="lblHdng"></asp:Label></h4>
                <div class="col-md-1">
                    <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" OnClick="lbtnBack_Click" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                </div>

            </div>

            <div class="card">
                <div class="card-header">
                    <h3>Pre-Scrutiny Stage</h3>
                </div>
                <section id="dashboardcount1">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <a href="CFOApplDeptView.aspx?status=TOTALAPPLICATIONS" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-purpule shadow-dark text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-file-download"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblTOTALAPPLICATIONS" runat="server"></asp:Label></h4>
                                                <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Stage</p>
                                            </div>
                                        </div>
                                        <hr class="dark horizontal my-0">
                                        <div class="card-footer p-3">
                                            <p class="mb-0">No. of Applications Recevied</p>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <a href="CFOApplDeptdrill.aspx" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-success shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-memo-circle-check"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblPRESCRUTINYCOMPLETED" runat="server"></asp:Label></h4>
                                                <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Completed</p>
                                            </div>
                                        </div>
                                        <hr class="dark horizontal my-0">
                                        <div class="card-footer p-3">
                                            <p class="mb-0">
                                                Applications Completed Scrutiny 
                                            </p>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6">
                                <div class="card">
                                    <a href="CFOApplDeptView.aspx?status=REJECTED" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-primary shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-vote-nay"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblPREREJECTED" runat="server"></asp:Label></h4>
                                                <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Rejected</p>
                                            </div>
                                        </div>
                                        <hr class="dark horizontal my-0">
                                        <div class="card-footer p-3">
                                            <p class="mb-0">No. of Applications Rejected</p>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6">
                                <div class="card">
                                    <a href="CFOApplDeptView.aspx?status=PRESCRUTINYPENDING" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-dark shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-search-alt"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblPRESCRUTINYPENDING" runat="server"></asp:Label></h4>
                                                <p class="text-sm mb-0 text-capitalize">Pre-Scrutiny Pending</p>
                                            </div>
                                        </div>
                                        <hr class="dark horizontal my-0">
                                        <div class="card-footer p-3">
                                            <p class="mb-0">
                                                Scrutiny Pending Applications                                             
                                            </p>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6">
                                <div class="card">
                                    <a href="CFOApplDeptView.aspx?status=ADDITIONALPAYMENTRAISED" style="text-decoration: none;" title="Pre-Scrutiny Completed With Additional Payment">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-wait shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-pending"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblADDITIONALPAYMENTRAISED" runat="server"></asp:Label></h4>
                                                <p class="text-sm mb-0 text-capitalize">With Additional Payment</p>
                                            </div>
                                        </div>
                                        <hr class="dark horizontal my-0">
                                        <div class="card-footer p-3">
                                            <p class="mb-0">Approvals Awaiting Payment</p>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <a href="CFOApplDeptView.aspx?status=QUERYPENDING" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-dark shadow-dark text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-search-alt"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblQUERYPENDING" runat="server"></asp:Label></h4>
                                                <p class="text-sm mb-0 text-capitalize">Query Raised</p>

                                            </div>
                                        </div>
                                        <hr class="dark horizontal my-0">
                                        <div class="card-footer p-3">
                                            <p class="mb-0">
                                                Query Response Pending<br />
                                            </p>
                                        </div>
                                    </a>
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
                <section id="dashboardcount2">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <a href="CFOApplDeptView.aspx?status=TOTALAPPROVALISSUED" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-purpule shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-memo-circle-check"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblTOTALAPPROVALISSUED" runat="server"></asp:Label></h4>
                                                <p class="text-sm mb-0 text-capitalize">Approval Issued</p>
                                            </div>
                                        </div>
                                        <hr class="dark horizontal my-0">
                                        <div class="card-footer p-3">
                                            <p class="mb-0">
                                                Total Applications 
                                            </p>
                                        </div>
                                    </a>
                                </div>
                            </div>

                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <a href="CFOApplDeptView.aspx?status=APPROVALPENDING" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-dark shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-search-alt"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblAPPROVALPENDING" runat="server"></asp:Label></h4>
                                                <p class="text-sm mb-0 text-capitalize">Approval Under Process</p>
                                            </div>
                                        </div>
                                        <hr class="dark horizontal my-0">
                                        <div class="card-footer p-3">
                                            <p class="mb-0">
                                                Approval Pending 
                                            </p>
                                        </div>
                                    </a>
                                </div>
                            </div>
                            <div class="col-xl-2 col-sm-6">
                                <div class="card">
                                    <a href="CFOApplDeptView.aspx?status=REJECTED" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-primary shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-vote-nay"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblREJECTED" runat="server"></asp:Label></h4>
                                                <p class="text-sm mb-0 text-capitalize">Approval Rejected</p>
                                            </div>
                                        </div>
                                        <hr class="dark horizontal my-0">
                                        <div class="card-footer p-3">
                                            <p class="mb-0">Applications Rejected</p>
                                        </div>
                                    </a>
                                </div>
                            </div>

                        </div>
                        <br />

                    </div>
                </section>
            </div>

        </div>
    </div>
</asp:Content>
