<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEUserApplStatus.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEUserApplStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="">
            <div class="">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title cfe" id="myLargeModalLabel cfe">Entrepreneur Dashboard - CFE
											(Pre-Establishment Approval)</h4>
                    </div>
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
                    <div class="modal-body">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Consent for Establishment</h4>
                            </div>
                            <div class="row">
                                <div class="col-md-3">

                                    <a href="Quesstionniare_cfe.html">
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
                                    <a href="DepartmentApprovalDetails.html">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Common Application Form
															Status <span class="badge badge-light text-danger">
                                                                <asp:Label ID="lblCAFstatus" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-3">
                                    <a href="index1.html">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Approvals Required as per
															Invest Meghalaya <span class="badge badge-light">
                                                                <asp:Label ID="lblApprovalsReq" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-3">
                                    <a href="index1.html">
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
                                            <a href="index1.html">
                                                <button type="button" class="btn btn-primary">
                                                    <i class="fe fe-document"></i>Applied Approvals
                                                    <br />
                                                    &nbsp;<span
                                                        class="badge badge-light"><asp:Label ID="lblApprovalsApplied" runat="server"></asp:Label></span>
                                                </button>
                                            </a>
                                        </div>
                                        <div class="col-md-6">
                                            <a href="index1.html">
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
                                            <a href="index1.html">
                                                <button type="button" class="btn btn-primary">
                                                    <i class="fe fe-document"></i>Additional Payment required
																	<span class="badge badge-light">
                                                                        <asp:Label ID="lblAddlPaymentReq" runat="server"></asp:Label></span>
                                                </button>
                                            </a>
                                        </div>
                                        <div class="col-md-6">
                                            <a href="index1.html">
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
                                    <a href="Quesstionniare_cfo.html">
                                        <button type="button"
                                            class="btn btn-primary">
                                            <i class="fe fe-document"></i>Query Raised <span
                                                class="badge badge-light">
                                                <asp:Label ID="lblQueryRaised" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a href="index1.html">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Query Respond <span class="badge badge-light">
                                                <asp:Label ID="lblQueryReplied" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-2">
                                    <a href="index1.html">
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
                                    <a href="index1.html">
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
                                    <a href="index1.html">
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
                                    <a href="index1.html">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Approval - Issued
                                            <br />
                                            &nbsp;<span
                                                class="badge badge-light"><asp:Label ID="lblApprovalIssued" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-4">
                                    <a href="index1.html">
                                        <button type="button" class="btn btn-primary">
                                            <i class="fe fe-document"></i>Approval - Pending
                                            <br />
                                            &nbsp;<span
                                                class="badge badge-light"><asp:Label ID="lblApprovalPanding" runat="server"></asp:Label></span>
                                        </button>
                                    </a>
                                </div>
                                <div class="col-md-4">
                                    <a href="index1.html">
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
    </div>
</asp:Content>
