<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEUserApplStatus.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEUserApplStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/deptdashbaords.css" rel="stylesheet" />
    <style>
        .card h3 {
    font-size: 20px;
    margin-left: 15px;
    margin-top: 3px;
    margin-bottom: -10px;
    font-weight: 600;
    color: #0b3654;
}
    </style>
    <asp:HiddenField ID="hdnUserID" runat="server" />
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
                                    <a href="CFEApplDeptView.aspx?status=TOTALAPPLICATIONS" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-purpule shadow-dark text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-file-download"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblTOTALAPPLICATIONS" runat="server">0</asp:Label></h4>
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
                                    <a href="CFEApplDeptdrill.aspx" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-success shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-memo-circle-check"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblPRESCRUTINYCOMPLETED" runat="server">0</asp:Label></h4>
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
                                    <a href="CFEApplDeptView.aspx?status=REJECTED" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-primary shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-vote-nay"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblPREREJECTED" runat="server">0</asp:Label></h4>
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
                                    <a href="CFEApplDeptView.aspx?status=PRESCRUTINYPENDING" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-dark shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-search-alt"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblPRESCRUTINYPENDING" runat="server">0</asp:Label></h4>
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
                                    <a href="CFEApplDeptView.aspx?status=ADDITIONALPAYMENTRAISED" style="text-decoration: none;" title="Pre-Scrutiny Completed With Additional Payment">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-wait shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-pending"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblADDITIONALPAYMENTRAISED" runat="server">0</asp:Label></h4>
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
                                    <a href="CFEApplDeptView.aspx?status=QUERYPENDING" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-dark shadow-dark text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-search-alt"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblQUERYPENDING" runat="server">0</asp:Label></h4>
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
           
            <div class="card">
                <div class="card-header">
                    <h3>Approval Stages</h3>
                </div>
                <section id="dashboardcount2" class="dashboardcount2">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                <div class="card">
                                    <a href="CFEApplDeptView.aspx?status=TOTALAPPROVALISSUED" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-purpule shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-memo-circle-check"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblTOTALAPPROVALISSUED" runat="server">0</asp:Label></h4>
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
                                    <a href="CFEApplDeptView.aspx?status=APPROVALPENDING" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-dark shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                               <i class="fi fi-rr-search-alt"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblAPPROVALPENDING" runat="server">0</asp:Label></h4>
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
                                    <a href="CFEApplDeptView.aspx?status=REJECTED" style="text-decoration: none;">
                                        <div class="card-header p-3 pt-2">
                                            <div class="icon icon-lg icon-shape bg-gradient-primary shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                <i class="fi fi-rr-vote-nay"></i>
                                            </div>
                                            <div class="text-end pt-1">
                                                <h4 class="mb-0">
                                                    <asp:Label ID="lblREJECTED" runat="server">0</asp:Label></h4>
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
                        

                    </div>
                </section>
            </div>

        </div>
    </div>



    <%--<div class="card">
        <div class="">
            <div class="">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title cfe" id="myLargeModalLabel cfe">Applicant Dashboard - Pre-Establishment Approval</h4>
                    </div>
                    
                    <div class="modal-body">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Application Status For Application ID: MEG10510012024</h4>
                            </div>
                            <div class="row">
                                <div class="col-md-3">

                                    <a href="#">
                                        <button type="button"
                                            class="btn btn-primary">
                                            <i class="fe fe-document"></i>Application Status <span
                                                class="badge badge-light text-success">
                                                <asp:Label ID="lblAppstatus" runat="server"></asp:Label>
                                            </span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-3">
                                    <a href="#">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Common Application Form
															Status <span class="badge badge-light text-danger">
                                                                <asp:Label ID="lblCAFstatus" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-3">
                                    <a href="#">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Approvals Required as per
															Invest Meghalaya <span class="badge badge-light">
                                                                <asp:Label ID="lblApprovalsReq" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-3">
                                    <a href="#">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Approvals already obtained
															<span class="badge badge-light">
                                                                <asp:Label ID="lblApprovalsObtained" runat="server"></asp:Label>
                                                            </span>
                                        </button>
                                    </a>
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
                                            <a href="#">
                                                <button type="button" class="btn btn-primary">
                                                    <i class="fe fe-document"></i>Applied Approvals
                                                    <br />
                                                    &nbsp;<span
                                                        class="badge badge-light"><asp:Label ID="lblApprovalsApplied" runat="server"></asp:Label></span>
                                                </button>
                                            </a>
                                        </div>
                                        <div class="col-md-6">
                                            <a href="#" >
                                                <button type="button" class="btn btn-primary">
                                                    <i class="fe fe-document"></i>Yet to be applied
                                                    <br />
                                                    &nbsp;<span
                                                        class="badge badge-light"><asp:Label ID="lblApprovalstobeApplied" runat="server"></asp:Label></span>
                                                </button>
                                            </a>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="card">
                                    <div class="card-header">
                                        <h4 class="card-title">Payment Status</h4>
                                    </div>
                                    <div class="row" id="ps">
                                        <div class="col-md-6">
                                            <a href="#">
                                                <button type="button" class="btn btn-primary">
                                                    <i class="fe fe-document"></i>Additional Payment required
																	<span class="badge badge-light">
                                                                        <asp:Label ID="lblAddlPaymentReq" runat="server"></asp:Label></span>
                                                </button>
                                            </a>
                                        </div>
                                        <div class="col-md-6">
                                            <a href="#">
                                                <button type="button" class="btn btn-primary">
                                                    <i class="fe fe-document"></i>Payment Paid
                                                    <br />
                                                    &nbsp; <span
                                                        class="badge badge-light">
                                                        <asp:Label ID="lblAddlPaymentPaid" runat="server"></asp:Label></span>
                                                </button>
                                            </a>
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
                                    <a href="#">
                                        <button type="button"
                                            class="btn btn-primary">
                                            <i class="fe fe-document"></i>Query Raised <span
                                                class="badge badge-light">
                                                <asp:Label ID="lblQueryRaised" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a href="#">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Query Respond <span class="badge badge-light">
                                                <asp:Label ID="lblQueryReplied" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a href="#">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Yet to Respond <span
                                                class="badge badge-light">
                                                <asp:Label ID="lblQueryYettoRespond" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a href="index1.html">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Rejected
                                            <br />
                                            &nbsp;
															<span class="badge badge-light">
                                                                <asp:Label ID="lblScrtnyRejected" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a href="#">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Completed
                                            <br />
                                            &nbsp;
															<span class="badge badge-light">
                                                                <asp:Label ID="lblScrtnyCmpltd" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a href="#">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Pending
                                            <br />
                                            &nbsp;
															<span class="badge badge-light">
                                                                <asp:Label ID="lblScrtnyPendng" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                            </div>
                        </div>



                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Approval Status</h4>
                            </div>
                            <div class="row" id="ais">
                                <div class="col-md-4">
                                    <a href="#">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Approval - Issued
                                            <br />
                                            &nbsp;<span
                                                class="badge badge-light"><asp:Label ID="lblApprovalIssued" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-4">
                                    <a href="#">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Approval - Pending
                                            <br />
                                            &nbsp;<span
                                                class="badge badge-light"><asp:Label ID="lblApprovalPanding" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-4">
                                    <a href="#">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Approval - Rejected
                                            <br />
                                            &nbsp;<span
                                                class="badge badge-light"><asp:Label ID="lblApprovalRejected" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>
