<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="INCApplStatus.aspx.cs" Inherits="MeghalayaUIP.User.INCENTIVE.INCApplStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Services/SRVCUserDashboard.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Incentive</li>
                </ol>
            </nav>

            <div class="container">
                <div class="card">
                    <div class="card-header d-flex justify-content-between">
                        <h4 class="card-title">Incentive Tracking Status <span id="lblType"></span></h4>
                        <h4 class="card-title">
                            <label id="unitname"></label>
                        </h4>
                    </div>

                    <section id="dashboardcount" class="mt-2">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-md-12">
                                    <div id="success" class="alert alert-success alert-dismissible fade show d-none" align="center">
                                        <strong>Success!</strong> <span id="lblmsg"></span><span id="Label1"></span>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div id="Failure" class="alert alert-danger alert-dismissible fade show d-none" align="center">
                                        <strong>Warning!</strong> <span id="lblmsg0"></span>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                    </div>
                                </div>
                            </div>

                            <div class="row mt-4">
                                <div class="col-md-6"><strong>1. UID NO:</strong> <span id="lblUnitID" class="fw-bold text-info">INC/2025/102</span></div>
                                <div class="col-md-6"><strong>2. Unit Name:</strong> <span id="lblUnitNmae" class="fw-bold text-info">TEST</span></div>
                            </div>

                            <br>

                           
                            <div class="table-responsive">
                                <table class="table table-bordered text-center">
                                    <thead class="table-dark">
                                        <tr>
                                            <th>S.No</th>
                                            <th>Name of Approval</th>
                                            <th>Date of Application</th>
                                            <th>Date of Payment</th>
                                            <th>Query Raised Date</th>
                                            <th>Response to Query Date</th>
                                            <th>Date of Scrutiny Completion</th>
                                            <th>Date of Additional Payment</th>
                                            <th>Date of Receival for Approval</th>
                                            <th>Date of Completion</th>
                                            <th>Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                      
                                        <tr>
                                            <td>1</td>
                                            <td>Online single window system-Incentives</td>
                                            <td>14-01-2024</td>
                                            <td><a href="#" target="_blank"></a></td>
                                            <td><a href="#" target="_blank"></a></td>
                                            <td><a href="#" target="_blank"></a></td>
                                            <td><a href="#" target="_blank" style="color: black; text-decoration: none;">14-03-2025</a></td>
                                            <td><a href="#" target="_blank"></a></td>
                                            <td></td>
                                            <td>14-03-2025</td>
                                            <td><a href="#" target="_blank">Approved</a></td>
                                        </tr>
                                        
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
