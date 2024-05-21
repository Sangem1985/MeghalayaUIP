<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="DashboardDrill.aspx.cs" Inherits="MeghalayaUIP.User.DashboardDrill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../assets/admin/css/user.css" rel="stylesheet" />
    <div class="page-wrapper griddesignmulticount">

        <div class="content container-fluid">

            <div class="card">
                <div class="card-header d-flex justify-content-between">
                    <h4 class="card-title">Welcome to Dashboard <asp:Label ID="lblmodule" runat="server"></asp:Label></h4>
                    <h4 class="card-title">
                        <label id="unitname" runat="server"></label>
                    </h4>
                </div>
                <section id="dashboardcount" class="mt-2">
                    <div class="container-fluid">
                        <div class="row">
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
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                            <div class="col-md-12 row mt-4">
                                <div class="col-md-2">1. Unit ID</div>

                                <div class="col-md-3 fw-bold text-info">
                                    <spna class="dots">:</spna>
                                    <b>
                                        <asp:Label ID="lblUnitID" runat="server"></asp:Label></b>
                                </div>
                                <div class="col-md-3">Select other Unit to view the Status</div>

                                <div class="col-md-2 d-flex">
                                    <spna class="dots">:</spna>
                                    <asp:DropDownList ID="ddlUnitNames" runat="server" class="form-control" OnSelectedIndexChanged="ddlUnitNames_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-2 mb-4">
                                <div class="col-md-2">2. Unit Name</div>

                                <div class="col-md-3 fw-bold text-info">
                                    <spna class="dots">:</spna><b><asp:Label ID="lblUnitName" runat="server"></asp:Label></b>
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
                                            <tr id="trCFE" runat="server" visible="true">
                                                <th scope="col" style="text-align: left !important;">Pre-Establishment Approvals</th>
                                                <td>
                                                    <span class="status4">
                                                        <asp:LinkButton ID="btnCFETotal" runat="server" OnClick="btnCFETotal_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>
                                                </td>
                                                <td><span class="status">
                                                    <asp:LinkButton ID="btnCFEApproved" runat="server" OnClick="btnCFEApproved_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                </span>
                                                </td>
                                                <td><span class="status1">
                                                    <asp:LinkButton ID="btnCFEUnderProcess" runat="server" OnClick="btnCFEUnderProcess_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                </span>
                                                </td>
                                                <td><span class="status2">
                                                    <asp:LinkButton ID="btnCFERejected" runat="server" OnClick="btnCFERejected_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                </span>

                                                </td>
                                                <td><span class="status3">
                                                    <asp:LinkButton ID="btnCFEQuery" runat="server" OnClick="btnCFEQuery_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                </span>
                                                </td>
                                            </tr>
                                            <tr id="trCFO" runat="server" visible="false">
                                                <th scope="col" style="text-align: left !important;">Pre-Operational Approvals</th>
                                                <td><a href="Dashboardstatus.aspx" target="_blank"><span class="status4">15</span></a></td>
                                                <td><span class="status">2</span></td>
                                                <td><span class="status1">9</span></td>
                                                <td><span class="status2">5</span></td>
                                                <td><span class="status3">1</span></td>
                                            </tr>

                                            <tr id="trINC" runat="server" visible="false">
                                                <th scope="col" style="text-align: left !important;">Incentives</th>
                                                <td><a href="Dashboardstatus.aspx" target="_blank"><span class="status4">15</span></a></td>
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
    </div>
</asp:Content>
