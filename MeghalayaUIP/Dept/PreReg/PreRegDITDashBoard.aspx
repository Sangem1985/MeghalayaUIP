<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegDITDashBoard.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegDITDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper IIMADB" style="margin: 10px 0px !important;">
        <div class="container-fluid">
            <div class="card-header d-flex justify-content-between">
                <h4 class="card-title mt-1">Industry Registration Applications<b></b></h4>
                <div class="col-md-1">
                    <asp:LinkButton ID="lbtnBack" OnClick="lbtnBack_Click" runat="server" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                </div>
            </div>

            <div class="card" style="padding: 10px; border-radius: 4px;">
                <h2 style="font-size: 22px; color: #3f51b5;"></h2>
                <div class="card">
                    <div class="card-header">
                        <h3>Industry Registration Applications</h3>
                    </div>
                    <div class="col-md-12 ">
                        <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div id="Failure" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show mt-3" align="Center">
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

                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 ">
                                    <asp:LinkButton runat="server" ID="lnkAppliaction" OnClick="lnkAppliaction_Click" ForeColor="White">
                                        <div class="info-box bg-red hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    Total Applications                     
                                                        <br />
                                                    in the District                
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>

                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 ">
                                    <asp:LinkButton runat="server" ID="linkTotal" OnClick="linkTotal_Click" ForeColor="White">
                                        <div class="info-box bg-orange hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblTotalApp" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    Total Applications                                                 
                                                   <br />
                                                    From MIPA
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-ballot-check"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linktobeProc" OnClick="linktobeProc_Click" ForeColor="White">
                                        <div class="info-box bg-yellow hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblDPRTOBEPROCESSED" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    Application                                                   
                                                    <br />
                                                    Pending
                                               
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkProcessed" OnClick="linkProcessed_Click" ForeColor="White">
                                        <div class="info-box bg-green hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblDPRPROCESSED" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    Application                                                   
                                                    <br />
                                                    Processed 
                                               
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-memo-circle-check"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </section>
                    <section id="dashboardcount1">
                        <div class="container-fluid">
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" id="Sent" runat="server" visible="false">
                                    <asp:LinkButton runat="server" ID="linkForQuerytoDept" OnClick="linkForQuerytoDept_Click" ForeColor="White">
                                        <div class="info-box bg-cyan hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblForwardedDEPTQUERY" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    DC Forwarded <br />to DIC                                               
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" id="Received" runat="server" visible="false">
                                    <asp:LinkButton runat="server" ID="linkDeptRecived" OnClick="linkDeptRecived_Click" ForeColor="White">
                                        <div class="info-box bg-pink hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblReceivedDEPT" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    DC Received <br />from DIC
                                               
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>

                                <%-- <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" id="divDICQuery" runat="server" visible="false">
                                    <asp:LinkButton runat="server" ID="lnkDCQuery" OnClick="lnkDCQuery_Click" ForeColor="White">
                                        <div class="info-box bg-pink hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblDICQuery" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    DIC Query<br />
                                                    Raised
                
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>--%>
                            </div>
                        </div>
                    </section>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
