<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="LADeptdashboard.aspx.cs" Inherits="MeghalayaUIP.Dept.LA.LADeptdashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="../Dashboard/DeptDashBoard.aspx">Dashboard</a></li>
            <li class="breadcrumb-item active" aria-current="page">Land Application</li>
        </ol>
    </nav>
    <div class="page-wrapper LADB" style="margin: 10px 0px !important;">
        <div class="container-fluid">
            <div class="card-header d-flex justify-content-between">
                <h4 class="card-title mt-1"><b></b></h4>
            </div>

            <div class="card" style="padding: 10px; border-radius: 4px;">
                <h2 style="font-size: 22px; color: #3f51b5;"></h2>
                <div class="card">
                    <div class="card-header">
                        <h3>Land Allottment Applications</h3>
                    </div>
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
                    <asp:HiddenField ID="hdnUserID" runat="server" />

                    <section id="dashboardcount">
                        <div class="container-fluid">
                            <div class="row clearfix">
                                <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12 ">
                                    <asp:LinkButton runat="server" ID="linkTotal" OnClick="linkTotal_Click" ForeColor="White">
                                        <div class="info-box bg-orange hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblTotalApp" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    Total Application
                                                   
                                                    <%-- <a href="PreRegApplIMAView.aspx?status=IMATOTAL" style="color: white">Total<br />
                                                    Application </a>--%>
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-ballot-check"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linktobeProc" OnClick="linktobeProc_Click" ForeColor="White">
                                        <div class="info-box bg-yellow hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblIMATOBEPROCESSED" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=IMATOBEPROCESSED" style="color: white"></a>--%>
                                                        Applications to<br />
                                                    be Processed
                                               
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12" id="divCommittee" runat="server" visible="false">
                                    <asp:LinkButton runat="server" ID="lnkforward" ForeColor="White" OnClick="lnkforward_Click">
                                        <div class="info-box bg-cyan hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblForward" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    Forwarded to Land Committee
                                               
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>


                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkApproved" OnClick="linkApproved_Click" ForeColor="White">
                                        <div class="info-box bg-green hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblIMAPPROVED" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    Approved
                                               
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-memo-circle-check"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkRejected" ForeColor="White" OnClick="linkRejected_Click">
                                        <div class="info-box bg-red hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblRejected" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    Rejected
                                               
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <%--  <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12" id="LANDQUERY" runat="server" visible="false">
                                    <asp:LinkButton runat="server" ID="linkQueryRaised" ForeColor="White" OnClick="linkQueryRaised_Click">
                                        <div class="info-box bg-blue hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblQueryRaised" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                     Query<br />
                                                    Raised 
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div> --%>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
