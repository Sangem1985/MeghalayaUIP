<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegApplDeptDashBoard.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegApplDeptDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper" style="margin: 10px 0px !important;">
        
        <div class="container-fluid">
            <div class="card" style="padding:10px;border-radius:4px;">
            <h2 style="font-size:22px;color:#3f51b5;">Department Dashboard</h2>
            <div class="card mt-2">
                <div class="card-header">
                    <h3>Industry Registration Applications</h3>
                    
                </div>
                <section id="dashboardcount">
                    
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-orange hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblTotalApp" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplDeptView.aspx?status=A" style="color: white">Total<br />Application </a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-ballot-check"></i>
                                        
                                    </div>
                                </div>
                            </div>
                            <%-- <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
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
                            </div>--%>
                            <div class="col-lg-2 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-yellow hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblToBeProcessed" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplDeptView.aspx?status=C" style="color: white">To be<br /> Processed </a>
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
                                            <a href="PreRegApplDeptView.aspx?status=E" style="color: white">Query Raised<br /> to Applicant</a>
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
                                            <a href="PreRegApplDeptView.aspx?status=F" style="color: white">Query Addressed<br /> by Applicant</a>
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
                    <h3>Query Details (IMA Queries)</h3>
                </div>
                <section id="dashboardcount4">
                    <div class="container-fluid">
                        <div class="row clearfix">
                            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-blue hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblIMAQuery" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplDeptView.aspx?status=IMAQuery" style="color: white">IMA Query<br /> Raised </a>
                                        </div>
                                        <div style="font-size: 12px;"></div>
                                        <i class="fi fi-tr-file-edit"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                                <div class="info-box bg-pink hover-expand-effect">
                                    <div class="icon">
                                        <h4>
                                            <asp:Label ID="lblDeptrepliedtoIMA" runat="server"></asp:Label>
                                        </h4>
                                    </div>
                                    <div class="content">
                                        <div class="text">
                                            <a href="PreRegApplDeptView.aspx?status=DeptrepliedtoIMA" style="color: white">Department Replied <br />to IMA Query </a>
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
                                            <a href="PreRegApplDeptView.aspx?status=IMAQueryforwardedtoAppl" style="color: white">IMA Query <br />Forwarded to Applicant</a>
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
                                            <a href="PreRegApplDeptView.aspx?status=APPLREPLIEDTOIMAQUERY" style="color: white">Applicant Replied<br /> to IMA Query</a>
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
                </div>
        </div>
    </div>
</asp:Content>
