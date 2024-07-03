<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegApplCommitteeDashBoard.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegApplCommitteeDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/DeptDashBoard.aspx">Dashboard</a></li>            
            <li class="breadcrumb-item active" aria-current="page">Committee</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card">
                <div class="card-header">
                    <h3>Committee Dashboard: Industry Registration Applications</h3>
                </div>
                <div class="col-md-12 ">
                    <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-md-12 ">
                    <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                        <strong>Warning!</strong>
                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                    </div>
                </div>
                <asp:HiddenField ID="hdnUserID" runat="server" />
                <section id="dashboardcount">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                <asp:LinkButton runat="server" ID="linkTotal" OnClick="linkTotal_Click" ForeColor="White">
                                    <div class="info-box bg-orange hover-expand-effect">
                                        <div class="icon">
                                            <h4>
                                                <asp:Label ID="lblTotalApp" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="content">
                                            <div class="text">
                                                <%--<a href="PreRegApplCommitteeView.aspx?status=COMMTOTAL" style="color: white"></a>--%>
                                                Total Application 
                                            </div>
                                            <div style="font-size: 12px;"></div>
                                            <i class="fi fi-tr-memo-circle-check"></i>
                                        </div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <%--<div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-cyan hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblprocessed" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplCommitteeView.aspx?status=COMMPROCESSED" style="color: white">Processed </a>
                                        </div>
                                        <div style="font-size: 12px;">Total Processed Application</div>
                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                <asp:LinkButton runat="server" ID="linktobeProc" OnClick="linktobeProc_Click" ForeColor="White">
                                    <div class="info-box bg-cyan hover-expand-effect">
                                        <div class="icon">
                                            <h4>
                                                <asp:Label ID="lblToBeProcessed" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="content">
                                            <div class="text">
                                                <%--<a href="PreRegApplCommitteeView.aspx?status=COMMTOBEPROCESSED" style="color: white"></a>--%>
                                                To be Processed 
                                            </div>
                                            <div style="font-size: 12px;"></div>
                                            <i class="fi fi-tr-file-import"></i>
                                        </div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                <asp:LinkButton runat="server" ID="linkApproved" OnClick="linkApproved_Click" ForeColor="White">
                                    <div class="info-box bg-green hover-expand-effect">
                                        <div class="icon">
                                            <h4>
                                                <asp:Label ID="lblApproved" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="content">
                                            <div class="text">
                                                <%--<a href="PreRegApplCommitteeView.aspx?status=COMMAPPROVED" style="color: white"></a>--%>
                                                Approved 
                                            </div>
                                            <div style="font-size: 12px;"></div>

                                        </div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                <asp:LinkButton runat="server" ID="linkRejected" OnClick="linkRejected_Click" ForeColor="White">
                                    <div class="info-box bg-yellow hover-expand-effect">
                                        <div class="icon">
                                            <h4>
                                                <asp:Label ID="lblRejected" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="content">
                                            <div class="text">
                                                <%--<a href="PreRegApplCommitteeView.aspx?status=COMMREJECTED" style="color: white"></a>--%>
                                                Rejected 
                                            </div>
                                            <div style="font-size: 12px;"></div>
                                        </div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
            <div class="card">
                <%-- <div class="card-header">
                    <h3>Query Details</h3>
                </div>--%>
                <section id="dashboardcount2">
                    <div class="container-fluid">
                        <div class="row clearfix">

                            <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                <asp:LinkButton runat="server" ID="linkQueryRaised" OnClick="linkQueryRaised_Click" ForeColor="White">
                                    <div class="info-box bg-blue hover-expand-effect">
                                        <div class="icon">
                                            <h4>
                                                <asp:Label ID="lblQuery" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="content">
                                            <div class="text">
                                                <%--<a href="PreRegApplCommitteeView.aspx?status=COMMQUERY" style="color: white"></a>--%>
                                                Query Raised
                                            </div>
                                            <div style="font-size: 12px;"></div>
                                        </div>
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                <asp:LinkButton runat="server" ID="linkQueryReplied" OnClick="linkQueryReplied_Click" ForeColor="White">
                                    <div class="info-box bg-pink hover-expand-effect">
                                        <div class="icon">
                                            <h4>
                                                <asp:Label ID="lblQueryReplied" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="content">
                                            <div class="text">
                                                <%--<a href="PreRegApplCommitteeView.aspx?status=COMMQUERYREPLIED" style="color: white"></a>--%>
                                                Queries Redressed
                                            </div>
                                            <div style="font-size: 12px;"></div>
                                        </div>
                                    </div>
                                </asp:LinkButton>
                            </div>

                        </div>
                    </div>
                </section>
            </div>
            <div class="card">
                <%-- <div class="card-header">
                    <h3>Query Details</h3>
                </div>--%>
                <section id="dashboardcount3">
                    <div class="container-fluid">
                        <div class="row clearfix">
                        </div>
                    </div>
                </section>
            </div>

        </div>
    </div>
</asp:Content>
