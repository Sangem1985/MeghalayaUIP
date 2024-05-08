<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="CFEDeptDashboard.aspx.cs" Inherits="MeghalayaUIP.Dept.CFE.CFEDeptDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .box {
            padding: 3px;
            border: 1px solid #673AB7;
            border-radius: 8px;
        }

        .col-lg-2.col-md-2.col-sm-6.col-xs-12 {
            max-width: 20% !important;
            min-width: 20% !important;
        }
    </style>
    <div class="page-wrapper CFEdeptdashboard">
        <div class="content container-fluid">
            <h4>Consent for Establishment</h4>
            <div class="card">

                <section id="dashboardcount">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <div class="card-header">
                                    <h3 style="font-size: 26px;">Pre-Scrutiny Stage</h3>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <div class="info-box bg-orange hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblTotalApp1" runat="server">10967</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">No of Application Received</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-memo-circle-check"></i>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                </section>
                <%-- </div>
                <div class="card">--%>
                <div class="card-header">
                    <h3>Pre-Scrutiny-Completed</h3>
                </div>
                <section id="dashboardcount4">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-pink hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label1" runat="server">99</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">With in 3 Days</a>
                                        </div>
                                        <i class="fi fi-tr-memo-circle-check"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-cyan hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label2" runat="server">2</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">Beyond 3 Days</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-yellow hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label3" runat="server">10099</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">Total</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-red hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label5" runat="server">10</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">No of Applications Rejected</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-orange hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label6" runat="server">100</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">No of Approvals Awaiting Payment
                                            </a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>
                </section>
                <%--</div>
                <div class="card">--%>
                <div class="card-header">
                    <h3>Pre-Scrutiny-Pending</h3>
                </div>
                <section id="dashboardcount4">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-pink hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label4" runat="server">99</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">With in 3 Days</a>
                                        </div>
                                        <i class="fi fi-tr-memo-circle-check"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-cyan hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label7" runat="server">2</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">Beyond 3 Days</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-blue hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label8" runat="server">10099</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">Today Last Day</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-yellow hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label9" runat="server">10</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">Total</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-orange hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label10" runat="server">100</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">No of Applications Awaiting Query Response</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>
                </section>
            </div>

           <%-- <div class="card">
                <div class="card-header" style="padding-top: 23px;">
                                    <h3 style="font-size: 26px;"></h3>
                                </div>
                
                </div>--%>
                <div class="card">
                <div class="card-header">
                    <h3 style="font-size: 26px;margin-bottom: 10px;">Approval Stages</h3>
                </div>
                <section id="dashboardcount4">
                    <div class="card-header">
                    <h3>Approval UnderProcess</h3>
                </div>
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-pink hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label12" runat="server">99</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">With in Time Limits</a>
                                        </div>
                                        <i class="fi fi-tr-memo-circle-check"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-cyan hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label13" runat="server">2</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">Beyond Time Limits</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-blue hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label14" runat="server">10099</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">Today Last Day</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-yellow hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label15" runat="server">10</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">Total</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            
                        </div>


                    </div>
                </section>
                <%--</div>
                <div class="card">--%>
                <div class="card-header">
                    <h3>Approval Issued</h3>
                </div>
                <section id="dashboardcount4">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-pink hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label17" runat="server">99</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">With in Time Limits</a>
                                        </div>
                                        <i class="fi fi-tr-memo-circle-check"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-cyan hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label18" runat="server">2</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">Beyond Time Limits</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-yellow hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label19" runat="server">10099</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">Total</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-red hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label20" runat="server">10</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">No of Applications Rejected</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-orange hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label21" runat="server">100</asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="#" style="color: white">No of Applications Appeal against Rejection</a>
                                        </div>

                                        <i class="fi fi-tr-file-import"></i>
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
