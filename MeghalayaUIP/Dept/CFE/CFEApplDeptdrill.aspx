<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="CFEApplDeptdrill.aspx.cs" Inherits="MeghalayaUIP.Dept.CFE.CFEApplDeptdrill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/deptdashbaords.css" rel="stylesheet" />
    <link href="../../assets/admin/css/deptdashboard3.css" rel="stylesheet" />
    <div class="page-wrapper cfeappldeptdrill">
        <div class="content container-fluid">
            <div class="card">
                <div class="card-header">
                    <h3>Pre-Scrutiny-Completed</h3>
                </div>
                <section id="dashboardcount3" class="mt-3 mb-3">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <a href="CFEApplDeptView.aspx">
                                <div class="card 1">
                                    <div class="card-headr">
                                        <div class="text">Total</div>
                                         <div class="iocn"><i class="fi fi-tr-memo-circle-check"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                                    </a>
                            </div>
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 2">
                                    <div class="card-headr">
                                        <div class="text">With in 3 Days</div>
                                        <div class="iocn"><i class="fi fi-tr-file-download"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 4">
                                    <div class="card-headr">
                                        <div class="text">Beyond in 3 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             
            
                            
                            
                            
                            
                        </div>
                    </div>
                </section>
            </div>
            <%--*************************************--%>
            <div class="card">
                <div class="card-header">
                    <h3>Pre-Scrutiny-Pending</h3>
                </div>
                <section id="dashboardcount3" class="mt-3 mb-3">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 1">
                                    <div class="card-headr">
                                        <div class="text">Total</div>
                                         <div class="iocn"><i class="fi fi-tr-memo-circle-check"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 2">
                                    <div class="card-headr">
                                        <div class="text">With in 3 Days</div>
                                        <div class="iocn"><i class="fi fi-tr-file-download"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 4">
                                    <div class="card-headr">
                                        <div class="text">Beyond in 3 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             
                             <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 3">
                                    <div class="card-headr">
                                        <div class="text">Today Last Day</div>
                                         <div class="iocn"><i class="fi fi-tr-file-circle-info"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                            
                            
                            
                            
                        </div>
                    </div>
                </section>
            </div>

            <%--*************************************--%>
            <div class="card">
                <div class="card-header">
                    <h3>Approval Under Process</h3>
                </div>
                <section id="dashboardcount3" class="mt-3 mb-3">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 1">
                                    <div class="card-headr">
                                        <div class="text">Total</div>
                                         <div class="iocn"><i class="fi fi-tr-memo-circle-check"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 2">
                                    <div class="card-headr">
                                        <div class="text">With in 3 Days</div>
                                        <div class="iocn"><i class="fi fi-tr-file-download"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 4">
                                    <div class="card-headr">
                                        <div class="text">Beyond in 3 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             
                             <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 3">
                                    <div class="card-headr">
                                        <div class="text">Today Last Day</div>
                                         <div class="iocn"><i class="fi fi-tr-file-exclamation"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                            
                            
                            
                            
                        </div>
                    </div>
                </section>
            </div>
            <%--*************************************--%>
            <div class="card">
                <div class="card-header">
                    <h3>Approval Issued</h3>
                </div>
                <section id="dashboardcount3" class="mt-3 mb-3">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 1">
                                    <div class="card-headr">
                                        <div class="text">Total</div>
                                         <div class="iocn"><i class="fi fi-tr-memo-circle-check"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                            <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 2">
                                    <div class="card-headr">
                                        <div class="text">With in 3 Days</div>
                                        <div class="iocn"><i class="fi fi-tr-file-download"></i></div>
                                        <div class="count">56</div>
                                    </div>
                                        
                                </div>
                            </div>
                             <div class="col-xl-3 col-sm-6 mb-xl-0 mb-4">
                                <div class="card 4">
                                    <div class="card-headr">
                                        <div class="text">Beyond in 3 Days</div>
                                         <div class="iocn"><i class="fi fi-tr-file-upload"></i></div>
                                        <div class="count">56</div>
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
