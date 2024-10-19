<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="ReportsAbstract.aspx.cs" Inherits="MeghalayaUIP.Dept.Reports.ReportsAbstract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <style>
        .card {
            border: 1px solid #fff;
            margin-bottom: 12px;
            box-shadow: 0px 0px 1px 1px #ededed;
            background: #fff;
            min-height: 50px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.2);
            position: relative;
            -webkit-border-radius: 2px;
            -moz-border-radius: 2px;
            -ms-border-radius: 2px;
            border-radius: 2px;
            padding-bottom: 10px;
        }

        h3 {
            font-size: 20px;
            margin-top: 3px;
            margin-bottom: 0px;
            font-weight: 600;
            color: #0b3654;
        }

        .card-body {
            border: 1px dotted #ccc;
            padding: 10px;
            margin: 10px;
        }

        .card-header {
            border: none !important;
        }

        spna.dots {
            margin-right: 24px;
            color: #000;
            font-weight: 100;
            visibility: hidden;
        }



        div#collapseOne h4 {
            margin-bottom: 5px;
            margin-top: 20px;
            padding-left: 0px;
        }

        .col-md-2 {
            border: 1px solid #ccc;
            padding: 0px 10px;
            margin: -2px 0px;
        }

        h4.card-title1 {
            color: #fff;
            width: 98.7%;
            padding: 1px 0px;
            border-radius: 4px;
            text-align: center;
            margin-bottom: 0px !important;
            padding-bottom: 0px !important;
            text-transform: capitalize;
            background: #2b6698;
            text-shadow: 1px 2px 3px #000;
            border: 1px solid #066f22;
            font-size: 20px;
        }

        div#ContentPlaceHolder1_divServc, div#ContentPlaceHolder1_divManf {
            display: contents;
        }
    </style>
    <!-- Page Wrapper -->
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
            <li class="breadcrumb-item">DashBoard</li>
            <li class="breadcrumb-item active" aria-current="page">Reports</li>
        </ol>
    </nav>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card-header d-flex justify-content-between">
                <h4 class="card-title mt-1"><b>Invest Meghalaya Reports</b></h4>
                <div class="col-md-1">
                    <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                </div>
            </div>
            <div class="card flex-fill">

                <h4 class="mt-2 ml-4" style="text-align: center">Invest Meghalaya Reports</h4>
                <br />
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
                        <asp:Label ID="lblmsg0" runat="server" autosize="true"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                </div>
                <asp:HiddenField ID="hdnUserID" runat="server" />

                <div class="container">
                    <div class="row">

                        <div class="col-md-12 d-flex">
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <%--------Industry Registration Reports-------%>
                                <div class="col-md-12 col-xs-12">
                                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                        <div class="panel panel-default">
                                            <div class="panel-heading" role="tab" id="headingOne">
                                                <h4 class="panel-title">
                                                    <a role="button" data-toggle="collapse" data-parent="#accordion"
                                                        href="#collapseOne" aria-expanded="false" aria-controls="collapseOne"
                                                        class="collapsed">Industry Registration Reports
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseOne" class="panel-collapse collapse" role="tabpanel"
                                                aria-labelledby="headingOne" aria-expanded="false">
                                                <div class="card">
                                                    <section id="dashboardBasic">
                                                        <div class="container-fluid">
                                                            <div class="row clearfix">
                                                                <div id="DashBoardmenu" style="font-weight: bold; font-family: Cambria; font-size: 16px; width: 100%">
                                                                    <ul>
                                                                        <li><a style="text-decoration: none;" target="_blank" href="IRDistWiseReport.aspx"><i
                                                                            class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R1: IR District Wise Reports</a></li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </section>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--------CFE Reports-------------------------%>
                                <div class="col-md-12 col-xs-12">
                                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                        <div class="panel panel-default">
                                            <div class="panel-heading" role="tab" id="headingThree">
                                                <h4 class="panel-title">
                                                    <a role="button" data-toggle="collapse" data-parent="#accordion"
                                                        href="#collapseThree" aria-expanded="false" aria-controls="collapseThree"
                                                        class="collapsed">Pre-Operational Reports
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseThree" class="panel-collapse collapse" role="tabpanel"
                                                aria-labelledby="headingThree" aria-expanded="false">
                                                <div class="card">
                                                    <section id="dashboardBasic2">
                                                        <div class="container-fluid">
                                                            <div class="row clearfix">
                                                                <div id="DashBoardmenu2" style="font-weight: bold; font-family: Cambria; font-size: 16px; width: 100%">
                                                                    <ul>
                                                                        <li><a style="text-decoration: none;" target="_blank" href="CFODeptWiseReport.aspx"><i
                                                                            class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R3: CFO Department Wise Reports</a></li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </section>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <%--------CFO Reports------------------------%>
                                <div class="col-md-12 col-xs-12">
                                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                        <div class="panel panel-default">
                                            <div class="panel-heading" role="tab" id="headingTwo">
                                                <h4 class="panel-title">
                                                    <a role="button" data-toggle="collapse" data-parent="#accordion"
                                                        href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo"
                                                        class="collapsed">Pre-Establishment Reports
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel"
                                                aria-labelledby="headingTwo" aria-expanded="false">
                                                <div class="card">
                                                    <section id="dashboardBasic1">
                                                        <div class="container-fluid">
                                                            <div class="row clearfix">
                                                                <div id="DashBoardmenu1" style="font-weight: bold; font-family: Cambria; font-size: 16px; width: 100%">
                                                                    <ul>
                                                                        <li><a style="text-decoration: none;" target="_blank" href="CFEDeptWiseReport.aspx"><i
                                                                            class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R2: CFE Department Wise Reports</a></li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </section>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%--------Renewal Reports--------------------%>
                                <div class="col-md-12 col-xs-12">
                                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                        <div class="panel panel-default">
                                            <div class="panel-heading" role="tab" id="headingFour">
                                                <h4 class="panel-title">
                                                    <a role="button" data-toggle="collapse" data-parent="#accordion"
                                                        href="#collapseFour" aria-expanded="false" aria-controls="collapseFour"
                                                        class="collapsed">Renewals Reports
                                                    </a>
                                                </h4>
                                            </div>
                                            <div id="collapseFour" class="panel-collapse collapse" role="tabpanel"
                                                aria-labelledby="headingFour" aria-expanded="false">
                                                <div class="card">
                                                    <section id="dashboardBasic3">
                                                        <div class="container-fluid">
                                                            <div class="row clearfix">
                                                                <div id="DashBoardmenu3" style="font-weight: bold; font-family: Cambria; font-size: 16px; width: 100%">
                                                                    <ul>
                                                                        <li><a style="text-decoration: none;" target="_blank" href="RENDeptWiseReport.aspx"><i
                                                                            class="fa fa-fw fa-database" style="text-indent: 20px"></i>&nbsp;&nbsp;&nbsp;&nbsp;R4: Renewal Department Wise Reports</a></li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </section>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>



                            <div class="col-md-1"></div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
