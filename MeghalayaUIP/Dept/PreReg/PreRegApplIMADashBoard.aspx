<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegApplIMADashBoard.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegApplIMADashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper" style="margin: 10px 0px !important;">
        <div class="container-fluid">
            <div class="card" style="padding: 10px; border-radius: 4px;">
                <h2 style="font-size: 22px; color: #3f51b5;">IMA Dashboard</h2>
                <div class="card">
                    <div class="card-header">
                        <h3>Industry Registration Applications</h3>
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
                                                    Total Applications
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
                                                    <%--<a href="PreRegApplIMAView.aspx?status=IMAPPROVED" style="color: white"></a>--%>
                                                    Approved 
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-memo-circle-check"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkQueryRaised" ForeColor="White">
                                        <div class="info-box bg-blue hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblQueryRaised" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=CommitteeQuery" style="color: white"></a>--%>
                                                     Query<br />
                                                    Raised 
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkQueryResponded" ForeColor="White">
                                        <div class="info-box bg-yellow hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblQueryResponded" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=IMATOBEPROCESSED" style="color: white"></a>--%>
                                                        Queries Redressed<br />
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

                    <section id="dashboardcount">
                        <div class="container-fluid">
                            <div class="row clearfix">
                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkQuerytoDept" OnClick="linkQuerytoDept_Click" ForeColor="White">
                                        <div class="info-box bg-cyan hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblIMATODEPTQUERY" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=IMAQUERY" style="color: white"></a>--%>
                                                    Queries Raised<br />
                                                    to Department
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkDeptReplyToIMA" OnClick="linkDeptReplyToIMA_Click" ForeColor="White">
                                        <div class="info-box bg-pink hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblIMAQUERYREPLIEDBYDEPT" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=IMAQUERYREPLIED" style="color: white"></a>--%>
                                                    Queries Redressed<br />
                                                    by Department
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkQuerytoApplc" OnClick="linkQuerytoApplc_Click" ForeColor="White">
                                        <div class="info-box bg-cyan hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblIMATOAPPLICANTTQUERY" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=IMAQUERY" style="color: white"></a>--%>
                                                        Query Raised<br />
                                                    to Applicant
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkApplcReplyToIMA" OnClick="linkApplcReplyToIMA_Click" ForeColor="White">
                                        <div class="info-box bg-pink hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblIMAQUERYREPLIEDBYAPPLICANT" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=IMAQUERYREPLIED" style="color: white"></a>--%>
                                                    Query Redressed<br />
                                                    by Applicant
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <%-- <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
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
                            </div>--%>
                            </div>
                        </div>
                    </section>
                </div>
                <div class="card">
                    <div class="card-header">
                        <h3>Query Details (Committee Queries)</h3>
                    </div>
                    <section id="dashboardcount7">
                        <div class="container-fluid">
                            <div class="row clearfix">
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkCommQrytoIMA" OnClick="linkCommQrytoIMA_Click" ForeColor="White">
                                        <div class="info-box bg-blue hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblCommitteeQuery" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=CommitteeQuery" style="color: white"></a>--%>
                                                    Committee Query<br />
                                                    Raised 
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkIMAReplyToComm" OnClick="linkIMAReplyToComm_Click" ForeColor="White">
                                        <div class="info-box bg-pink hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblIMARepltoCommittee" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=IMArepliedtoCommittee" style="color: white"></a>--%>
                                                    Committee Query
                                                    <br />
                                                    Redressed by IMA  
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-edit"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkComQryToAppl" OnClick="linkComQryToAppl_Click" ForeColor="White">
                                        <div class="info-box bg-orange hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblComquryfwdtoapplcnt" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=CommitteeQueryforwardedtoAppl" style="color: white"></a>--%>
                                                    Committee Query<br />
                                                    Forwarded to Applicant
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-import"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>

                                </div>

                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkApplcReplyToComm" OnClick="linkApplcReplyToComm_Click" ForeColor="White">
                                        <div class="info-box bg-pink hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblComquryrepliedbyapplcnt" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=APPLREPLIEDTOCommitteeQUERY" style="color: white"></a>--%>
                                                    Committee Query
                                                    <br />
                                                    Redressed by Applicant 
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-memo-circle-check"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <%--</div>
                            <div class="row clearfix">--%>
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkComQryToDept" OnClick="linkComQryToDept_Click" ForeColor="White">
                                        <div class="info-box bg-orange hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblComquryfwdtoDept" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=CommitteeQueryforwardedtoDept" style="color: white"></a>--%>
                                                        Committee Query<br />
                                                    Forwarded to Department
                                                </div>
                                                <div style="font-size: 12px;"></div>
                                                <i class="fi fi-tr-file-import"></i>
                                            </div>
                                        </div>
                                    </asp:LinkButton>
                                </div>

                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <asp:LinkButton runat="server" ID="linkDeptReplyToComm" OnClick="linkDeptReplyToComm_Click" ForeColor="White">
                                        <div class="info-box bg-pink hover-expand-effect">
                                            <div class="icon">
                                                <h4>
                                                    <asp:Label ID="lblDeptrepliedtoCommittee" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                            <div class="content">
                                                <div class="text">
                                                    <%--<a href="PreRegApplIMAView.aspx?status=DeptREPLIEDTOCommitteeQUERY" style="color: white"></a>--%>
                                                    Committee Query
                                                    <br />
                                                    Redressed by Department 
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
                </div>
            </div>
        </div>
    </div>
</asp:Content>
