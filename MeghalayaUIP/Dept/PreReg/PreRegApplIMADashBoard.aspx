<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegApplIMADashBoard.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegApplIMADashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card">
                <div class="card-header">
                    <h3>IMA Dashboard: Industry Registration Applications</h3>
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
                                            <a href="PreRegApplIMAView.aspx?status=A" style="color: white">Total Application </a>
                                        </div>
                                        <div style="font-size: 12px;">Total Revence Hold Application Received</div>
                                        <i class="fi fi-tr-memo-circle-check"></i>
                                    </div>
                                </div>
                            </div>                            
                        </div>
                    </div>
                </section>
            </div> 
             <div class="card">
                <div class="card-header">
                    <h3>IMA Applications</h3>
                </div>
                <section id="dashboardcount4">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-blue hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblIMATotal" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=IMATotal" style="color: white">Total Applications Forwarded to IMA</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-pink hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblIMATOBEPROCESSED" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=IMATOBEPROCESSED" style="color: white">Applications to be Processed</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-yellow hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblIMAPROCESSED" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=IMAPROCESSED" style="color: white">Applications Processed</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
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
                <section id="dashboardcount5">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-green hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblIMAPPROVED" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=IMAPPROVED" style="color: white">Approved </a>
                                        </div>
                                        <div style="font-size: 12px;"></div>

                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-green hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblIMAQUERY" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=IMAQUERY" style="color: white">Query Raised</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>

                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-green hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblIMAQUERYREPLIED" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=IMAQUERYREPLIED" style="color: white">Query Replied</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>

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
