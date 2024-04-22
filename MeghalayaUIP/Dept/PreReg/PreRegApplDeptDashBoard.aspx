<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegApplDeptDashBoard.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegApplDeptDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card">
                <div class="card-header">
                    <h3>Dept Dashboard: Industry Registration Applications</h3>
                </div>
                <section id="dashboardcount">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-orange hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblTotalApp" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplDeptView.aspx?status=A" style="color: white">Total Application </a>
                                        </div>
                                        <div style="font-size: 12px;">Total Revence Hold Application Received</div>
                                        <i class="fi fi-tr-memo-circle-check"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-cyan hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblprocessed" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplDeptView.aspx?status=B" style="color: white">Processed </a>
                                        </div>
                                        <div style="font-size: 12px;">Total Processed Application</div>
                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-cyan hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblToBeProcessed" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplDeptView.aspx?status=C" style="color: white">To be Processed </a>
                                        </div>
                                        <div style="font-size: 12px;">Total To be Processed Application</div>
                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
            <div class="card">
                <div class="card-header">
                    <h3>Query Details</h3>
                </div>
                <section id="dashboardcount2">
                    <div class="container-fluid">
                        <div class="row clearfix">

                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-blue hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblQuery" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplDeptView.aspx?status=E" style="color: white">Query Raised</a>
                                        </div>
                                        <div style="font-size: 12px;">Total To be Processed Application</div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-pink hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblQueryReplied" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplDeptView.aspx?status=D" style="color: white">Replied by Applicant</a>
                                        </div>
                                        <div style="font-size: 12px;">Total To be Processed Application</div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-yellow hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblQueryNotRepld" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplDeptView.aspx?status=D" style="color: white">Yet To be Replied</a>
                                        </div>
                                        <div style="font-size: 12px;">Total Rejected Application</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
            <div class="card">
                <div class="card-header">
                    <h3>Query Details</h3>
                </div>
                <section id="dashboardcount3">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-green hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblApproved" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplDeptView.aspx?status=D" style="color: white">Approved </a>
                                        </div>
                                        <div style="font-size: 12px;">Total Query Raised Application Received</div>

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
