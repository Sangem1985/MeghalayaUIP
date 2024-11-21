<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegApplDeptDashBoard.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegApplDeptDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        section#dashboardcount\ IMAqueries i.fi {
    position: absolute;
    top: 15px;
    right: 8px;
    font-size: 50px;
    opacity: 0.3;
    color: #fff;
}
    </style>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/DeptDashBoard.aspx">Dashboard</a></li>
            <li class="breadcrumb-item active" aria-current="page">Industry Registration</li>
        </ol>
    </nav>
    <div class="page-wrapper" style="margin: 10px 0px !important;">

        <div class="container-fluid">
            <div class="card" style="padding: 10px; border-radius: 4px;">
                <%--<h2 style="font-size: 22px; color: #3f51b5;">Department Dashboard</h2>--%>
                <div class="card mt-2" visible="false" runat="server">
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
                         

                                <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                    <div class="info-box bg-yellow hover-expand-effect">
                                        <div class="icon">
                                            <h4>
                                                <asp:Label ID="lblToBeProcessed" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="content">
                                            <div class="text">
                                                <a href="PreRegApplDeptView.aspx?status=C" style="color: white">To be<br />
                                                    Processed </a>
                                            </div>
                                            <div style="font-size: 12px;"></div>
                                            <i class="fi fi-tr-file-import"></i>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
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
                                            <div style="font-size: 12px;"></div>
                                            <i class="fi fi-tr-memo-circle-check"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                    <div class="info-box bg-blue hover-expand-effect">
                                        <div class="icon">
                                            <h4>
                                                <asp:Label ID="lblQuery" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="content">
                                            <div class="text">
                                                <a href="PreRegApplDeptView.aspx?status=E" style="color: white">Query Raised<br />
                                                    to Applicant</a>
                                            </div>
                                            <div style="font-size: 12px;"></div>
                                            <i class="fi fi-tr-file-edit"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                    <div class="info-box bg-pink hover-expand-effect">
                                        <div class="icon">
                                            <h4>
                                                <asp:Label ID="lblQueryReplied" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="content">
                                            <div class="text">
                                                <a href="PreRegApplDeptView.aspx?status=F" style="color: white">Query Addressed<br />
                                                    by Applicant</a>
                                            </div>
                                            <div style="font-size: 12px;"></div>
                                            <i class="fi fi-tr-to-do-alt"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <div class="info-box bg-cyan hover-expand-effect">
                                        <div class="icon">
                                            <h4>
                                                <asp:Label ID="lblIMAQueryforwardedtoAppl" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="content">
                                            <div class="text">
                                                <a href="PreRegApplDeptView.aspx?status=IMAQueryforwardedtoAppl" style="color: white">IMA Query
                                                    <br />
                                                    Forwarded to Applicant</a>
                                            </div>
                                            <div style="font-size: 12px;"></div>
                                            <i class="fi fi-tr-file-import"></i>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                    <div class="info-box bg-pink hover-expand-effect">
                                        <div class="icon">
                                            <h4>
                                                <asp:Label ID="lblAPPLREPLIEDTOIMAQUERY" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                        <div class="content">
                                            <div class="text">
                                                <a href="PreRegApplDeptView.aspx?status=APPLREPLIEDTOIMAQUERY" style="color: white">Applicant Replied<br />
                                                    to IMA Query</a>
                                            </div>
                                            <div style="font-size: 12px;"></div>
                                            <i class="fi fi-tr-to-do-alt"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>

                
                <div class="card mt-4">
                    <div class="card-header">
                        <h3>Industry Registration Applications </h3>
                    </div>
                    <section id="dashboardcount IMAqueries">
                        <div class="container-fluid">
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkTotal" OnClick="linkTotal_Click" ForeColor="White">
                                        <div class="info-box bg-orange hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblTotalApp" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplDeptView.aspx?status=TOTAL" style="color: white"></a>--%>
                                                    Total<br />
                                                    Application 
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-ballot-check"></i>

                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkQryRcvd" OnClick="linkQryRcvd_Click" ForeColor="White">
                                        <div class="info-box bg-blue hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblIMAQuery" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplDeptView.aspx?status=IMATODEPTQUERY" style="color: white"></a>--%>
                                                   Application
                                                    <br />
                                                    Pending 
                                                </div>
                                                <div style="font-size: 12px; padding-left:13px"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkQryRepld" OnClick="linkQryRepld_Click" ForeColor="White">
                                        <div class="info-box bg-pink hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblDeptrepliedtoIMA" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">

                                                    <%--<a href="PreRegApplDeptView.aspx?status=DEPTREPLIEDTOIMA" style="color: white"></a>--%>
                                                    Application
                                                    <br />
                                                    Processed
                                                   
                                                    
                                                </div>
                                                <div style="font-size: 12px;; padding-left:16px"></div>
                                                <i class="fi fi-tr-to-do-alt"></i>
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
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" id="Received" runat="server" visible="false">
                                    <asp:LinkButton runat="server" ID="linkDeptReceived" OnClick="linkDeptReceived_Click" ForeColor="White">
                                        <div class="info-box bg-cyan hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblReceivedDEPTQUERY" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                  DIC Received
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12" id="Sent" runat="server" visible="false">
                                    <asp:LinkButton runat="server" ID="linkDeptSent" OnClick="linkDeptSent_Click" ForeColor="White">
                                        <div class="info-box bg-pink hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblSentDEPT" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                  DIC SentBack 
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>                                                            
                            </div>
                        </div>
                    </section>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
