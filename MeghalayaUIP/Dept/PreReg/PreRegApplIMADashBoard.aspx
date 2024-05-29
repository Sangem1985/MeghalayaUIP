<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegApplIMADashBoard.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegApplIMADashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div class="page-wrapper"  style="margin: 10px 0px !important;">
        <div class="container-fluid">
            <div class="card" style="padding:10px;border-radius:4px;">
                <h2 style="font-size:22px;color:#3f51b5;">IMA Dashboard</h2>
                <div class="card">
                <div class="card-header">
                    <h3>Industry Registration Applications</h3>
                </div>
                <section id="dashboardcount">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-orange hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblTotalApp" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=A" style="color: white">Total<br />Application </a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-ballot-check"></i>
                                    </div>
                                </div>
                            </div>                            
                        </div>
                    </div>
                </section>
            
                <section id="dashboardcount">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                <div class="info-box bg-blue hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblIMATotal" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=IMATotal" style="color: white">Total Applications<br /> Forwarded to IMA</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                <div class="info-box bg-yellow hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblIMATOBEPROCESSED" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=IMATOBEPROCESSED" style="color: white">Applications to<br /> be Processed</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-file-edit"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
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
                                        <i class="fi fi-tr-memo-circle-check"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                <div class="info-box bg-cyan hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblIMAQUERY" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=IMAQUERY" style="color: white">Query Raised<br /> to Department</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-file-edit"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-6 col-xs-12">
                                <div class="info-box bg-pink hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblIMAQUERYREPLIED" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=IMAQUERYREPLIED" style="color: white">Query Addressed<br /> by Department</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-file-edit"></i>
                                    </div>
                                </div>
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
                                <div class="info-box bg-blue hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=CommitteeQuery" style="color: white">Committee Query<br /> Raised </a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-file-edit"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-pink hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblDeptrepliedtoCommittee" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=DeptrepliedtoCommittee" style="color: white">Dept Replied to<br /> Committee Query </a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-file-edit"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-orange hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblCommitteeQueryforwardedtoAppl" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=CommitteeQueryforwardedtoAppl" style="color: white">Committee Query<br /> Forwarded to Applicant</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-file-import"></i>
                                    </div>
                                </div>
                            </div>
                        
                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                <div class="info-box bg-pink hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblAPPLREPLIEDTOCommitteeQUERY" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplIMAView.aspx?status=APPLREPLIEDTOCommitteeQUERY" style="color: white">Applicant Replied to<br /> Committee Query</a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-memo-circle-check"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                     </div>
            </div>
        </div>
    </div>
</asp:Content>
