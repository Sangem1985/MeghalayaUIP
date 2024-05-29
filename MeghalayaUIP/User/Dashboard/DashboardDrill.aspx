<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="DashboardDrill.aspx.cs" Inherits="MeghalayaUIP.User.Dashboard.DashboardDrill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/user.css" rel="stylesheet" />
    <div class="page-wrapper griddesignmulticount">

        <div class="content container-fluid">

            <div class="card">
                <div class="card-header d-flex justify-content-between">
                    <h4 class="card-title"><b>Welcome to Dashboard </b></h4>
                    <h4 class="card-title">
                        <label id="unitname" runat="server"></label>
                    </h4>
                </div>
                <div class="col-md-12 d-flex card mb-2 pb-0" style="background: #f3f3f3;border-radius: 0px;display: flex !important;flex-wrap: nowrap;flex-direction: row;">
                     <div class="col-md-6 justify-content-around" style="align-items: center;">
                         <div class="justify-content-between justify-content-around">
                            
                             <asp:Label runat="server"><h4 class="card-title mb-0 mt-2">Status of Applications for  All Units </h4></asp:Label>
                     </div>
                    </div>
                        
                       
                    <div class="col-md-6 d-flex justify-content-around" style="border-radius: 0px;display: flex !important;flex-wrap: nowrap;flex-direction: row;align-items: center;">
                                        <div class="col-md-6">Select Unit to view the Status</div>
                                        <div class="col-md-6 d-flex" style="align-items: center;">
                                            <spna class="dots">:</spna>
                                            <asp:DropDownList Width="150px" ID="ddlUnitNames" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlUnitNames_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
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
                                <div class="col-md-12 d-flex mb-4 bg-default-light justify-content-around" style="border: 1px dotted #96ccf3; align-items: center; background-color: rgb(68 141 255 / 12%) !important;">

                                    <div class="col-md-6 d-flex" style="align-items: center;" runat="server" id="divUnit" visible="false">
                                        <div class="col-md-3">Unit ID</div>
                                        <div class="col-md-3" style="align-items: center;"><spna class="dots">:</spna>
                                            <b>
                                                <asp:Label ID="lblUnitID" runat="server"></asp:Label></b>
                                        </div>
                                        <div class="col-md-3" style="align-items: center;">Unit Name</div>
                                        <div class="col-md-3" style="align-items: center;"><spna class="dots">:</spna>
                                            <b>
                                                <asp:Label ID="lblUnitName" runat="server"></asp:Label></b>
                                        </div>
                                    </div>
                                    <div class="col-md-6 d-flex" style="align-items: center;" runat="server" id="div1" visible="true">
                                        <div class="col-md-3">Unit Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:</div>
                                        <div class="col-md-9" style="align-items: center;">
                                            <asp:Label ID="LabelUnitAdress" runat="server">DANALDASILK, DANAL DASILK, SONGSAK, EAST GARO HILLS, 506001</asp:Label>
                                        </div>
                                        
                                    </div>
                                </div>

                                <div class="card" style="width: 100%;">
                                    <div class="table-responsive under table-striped table-hover drilldown preEstablishment">
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
                                                <tr id="trPreReg" runat="server" visible="true">
                                                    <th scope="col" style="text-align: left !important;">Industries Registered with IMA/MIIPP</th>
                                                    <td>
                                                        <span class="status4">
                                                            <asp:LinkButton ID="btnPreRegTotal" runat="server" OnClick="btnPreRegTotal_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                        </span>
                                                    </td>
                                                    <td><span class="status">
                                                        <asp:LinkButton ID="btnPreRegApproved" runat="server" OnClick="btnPreRegApproved_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>
                                                    </td>
                                                    <td><span class="status1">
                                                        <asp:LinkButton ID="btnPreRegUnderProcess" runat="server" OnClick="btnPreRegUnderProcess_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>
                                                    </td>
                                                    <td><span class="status2">
                                                        <asp:LinkButton ID="btnPreRegRejected" runat="server" OnClick="btnPreRegRejected_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>

                                                    </td>
                                                    <td><span class="status3">
                                                        <asp:LinkButton ID="btnPreRegQuery" runat="server" OnClick="btnPreRegQuery_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>
                                                    </td>
                                                </tr>
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
                                                <tr id="trCFO" runat="server" visible="true">
                                                    <th scope="col" style="text-align: left !important;">Pre-Operational Approvals</th>
                                                    <td>
                                                        <span class="status4">
                                                            <asp:LinkButton ID="btnCFOTotal" runat="server" OnClick="btnCFOTotal_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                        </span>
                                                    </td>
                                                    <td><span class="status">
                                                        <asp:LinkButton ID="btnCFOApproved" runat="server" OnClick="btnCFOApproved_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>
                                                    </td>
                                                    <td><span class="status1">
                                                        <asp:LinkButton ID="btnCFOUnderProcess" runat="server" OnClick="btnCFOUnderProcess_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>
                                                    </td>
                                                    <td><span class="status2">
                                                        <asp:LinkButton ID="btnCFORejected" runat="server" OnClick="btnCFORejected_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>

                                                    </td>
                                                    <td><span class="status3">
                                                        <asp:LinkButton ID="btnCFOQuery" runat="server" OnClick="btnCFOQuery_Click" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>
                                                    </td>
                                                </tr>

                                                <tr id="trINC" runat="server" visible="true">
                                                    <th scope="col" style="text-align: left !important;">Incentives</th>
                                                    <td>
                                                        <span class="status4">
                                                            <asp:LinkButton ID="btnINCTotal" runat="server" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                        </span>
                                                    </td>
                                                    <td><span class="status">
                                                        <asp:LinkButton ID="btnINCApproved" runat="server" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>
                                                    </td>
                                                    <td><span class="status1">
                                                        <asp:LinkButton ID="btnINCUnderProcess" runat="server" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>
                                                    </td>
                                                    <td><span class="status2">
                                                        <asp:LinkButton ID="btnINCRejected" runat="server" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>

                                                    </td>
                                                    <td><span class="status3">
                                                        <asp:LinkButton ID="btnINCQuery" runat="server" Font-Underline="false" ForeColor="White"></asp:LinkButton>
                                                    </span>
                                                    </td>
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
