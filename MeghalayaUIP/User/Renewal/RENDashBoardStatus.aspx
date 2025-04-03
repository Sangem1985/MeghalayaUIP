<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENDashBoardStatus.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENDashBoardStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/deptdashbaords.css" rel="stylesheet" />

    <asp:HiddenField ID="hdnUserID" runat="server" />
    <div class="col-md-12 ">
        <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">×</span></button>
        </div>
    </div>
    <div class="col-md-12 ">
        <div id="Failure" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show" align="Center">
            <strong>Warning!</strong>
            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">×</span>
            </button>
        </div>
    </div>
    <div class="card mt-2">
        <div class="modal-header" style="padding: 3px 30px;">
            <h4 class="modal-title cfe" id="myLargeModalLabel cfe1">Applicant Dashboard - Renewal Approvals</h4>
            <%-- <h5 class="modal-title cfe" id="myLargeModalLabel cfe2">Status View : 
                <select class="form-select" aria-label="Default select example">
                    <option selected>Open this select Status</option>
                    <option value="1" href="AS">Application Stage</option>
                    <option value="2" href="PS">Payment Stage</option>
                    <option value="3" href="PSS">Pre-Scrutiny Stage</option>
                    <option value="4" href="#APS">Approval Stage</option>
                </select>

            </h5>--%>
        </div>

        <div class="page-wrapper cfeuserapplstatus icons">
            <div class="content container-fluid">

                <div class="card">
                    <div class="card-header">
                        <h3>Application Status</h3>
                    </div>
                    <section id="dashboardcount2" class="dashboardcount2">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkApprApplied" OnClick="linkApprApplied_Click">
                                            <%--<a href="#" style="text-decoration: none;">--%>
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-purpule shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-memo-circle-check"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblApprovalsApplied" runat="server">0</asp:Label></h4>
                                                    <%--<p class="text-sm mb-0 text-capitalize">&nbsp;</p>--%>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">Applied Approvals</p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>

                                <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkAddlPaymntdone" OnClick="linkAddlPaymntdone_Click">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-dark shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-search-alt"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblAddlPaymentPaid" runat="server">0</asp:Label></h4>
                                                    <%--<p class="text-sm mb-0 text-capitalize">&nbsp;</p>--%>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">
                                                    Payment Paid<br />
                                                    &nbsp;
                                                </p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>

                                <%-- <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkTobeApplied">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-dark shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-search-alt"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblApprovalstobeApplied" runat="server">0</asp:Label></h4>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">Yet to be applied </p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </section>
                </div>


                <%--   <div class="card" id="AS">
                    <div class="card-header">
                        <h3>Payment Stages</h3>
                    </div>
                    <section id="dashboardcount3" class="dashboardcount3">
                        <div class="container-fluid">
                            <div class="row">
                                
                                
                            </div>
                        </div>
                    </section>
                </div>--%>

                <div class="card" id="PSS">
                    <div class="card-header">
                        <h3>Pre-Scrutiny Stages</h3>
                    </div>
                    <br />
                    <section id="dashboardcount4" class="dashboardcount4">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkScrtnyPendng" OnClick="linkScrtnyPendng_Click">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-dark shadow-dark text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-search-alt"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblScrtnyPendng" runat="server">0</asp:Label></h4>
                                                    <%--<p class="text-sm mb-0 text-capitalize">&nbsp;</p>--%>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">Pending</p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-xl-2 col-sm-6">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkScrtnyCmpltd" OnClick="linkScrtnyCmpltd_Click">
                                            <%--<a href="#" style="text-decoration: none;" title="Pre-Scrutiny Completed With Additional Payment">--%>
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-wait shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-pending"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblScrtnyCmpltd" runat="server">0</asp:Label></h4>
                                                    <%--<p class="text-sm mb-0 text-capitalize">&nbsp;</p>--%>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">Completed</p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-xl-2 col-sm-6">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkScrtnyRejected" OnClick="linkScrtnyRejected_Click">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-dark shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-search-alt"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblScrtnyRejected" runat="server">0</asp:Label></h4>
                                                    <%--<p class="text-sm mb-0 text-capitalize">&nbsp;</p>--%>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">Rejected</p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>

                                <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkQryRaised" OnClick="linkQryRaised_Click">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-purpule shadow-dark text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-file-download"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblQueryRaised" runat="server">0</asp:Label></h4>
                                                    <%--<p class="text-sm mb-0 text-capitalize">&nbsp;</p>--%>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">Query Raised </p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkQueryReplied" OnClick="linkQueryReplied_Click">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-success shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-memo-circle-check"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblQueryReplied" runat="server">0</asp:Label></h4>
                                                    <%--<p class="text-sm mb-0 text-capitalize">&nbsp;</p>--%>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">
                                                    Query Respond 
                                                </p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-xl-2 col-sm-6">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkQueryYettoRespond" OnClick="linkQueryYettoRespond_Click">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-primary shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-vote-nay"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblQueryYettoRespond" runat="server">0</asp:Label></h4>
                                                    <%--<p class="text-sm mb-0 text-capitalize">&nbsp;</p>--%>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">Yet to Respond </p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <br />
                                <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkAddlPaymnt" OnClick="linkAddlPaymnt_Click">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-purpule shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-memo-circle-check"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblAddlPaymentReq" runat="server">0</asp:Label></h4>
                                                    <%-- <p class="text-sm mb-0 text-capitalize">&nbsp;</p>--%>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">Additional Payment required</p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <br />
                                <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="lnkAddPaymentDone" OnClick="lnkAddPaymentDone_Click">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-dark shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-search-alt"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblAddPaymentDone" runat="server">0</asp:Label></h4>
                                                    <%--<p class="text-sm mb-0 text-capitalize">&nbsp;</p>--%>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">
                                                    Additional Payment Paid
                                                </p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>

                <div class="card" id="APS">
                    <div class="card-header">
                        <h3>Approval Stages</h3>
                    </div>
                    <br />
                    <section id="dashboardcount5" class="dashboardcount5">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkApprovalIssued" OnClick="linkApprovalIssued_Click">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-purpule shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-memo-circle-check"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblApprovalIssued" runat="server">0</asp:Label></h4>
                                                    <p class="text-sm mb-0 text-capitalize">Approval Issued</p>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">
                                                    Total Applications 
                                                </p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>

                                <div class="col-xl-2 col-sm-6 mb-xl-0 mb-4">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkApprovalPending" OnClick="linkApprovalPending_Click">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-dark shadow-success text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-search-alt"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblApprovalPending" runat="server">0</asp:Label></h4>
                                                    <p class="text-sm mb-0 text-capitalize">Approval Under Process</p>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">
                                                    Approval Pending 
                                                </p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-xl-2 col-sm-6">
                                    <div class="card">
                                        <asp:LinkButton runat="server" ID="linkApprovalRejected" OnClick="linkApprovalRejected_Click">
                                            <div class="card-header p-3 pt-2">
                                                <div class="icon icon-lg icon-shape bg-gradient-primary shadow-info text-center border-radius-xl mt-n4 position-absolute">
                                                    <i class="fi fi-rr-vote-nay"></i>
                                                </div>
                                                <div class="text-end pt-1">
                                                    <h4 class="mb-0">
                                                        <asp:Label ID="lblApprovalRejected" runat="server">0</asp:Label></h4>
                                                    <p class="text-sm mb-0 text-capitalize">Approval Rejected</p>
                                                </div>
                                            </div>
                                            <hr class="dark horizontal my-0">
                                            <div class="card-footer p-3">
                                                <p class="mb-0">Applications Rejected</p>
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
