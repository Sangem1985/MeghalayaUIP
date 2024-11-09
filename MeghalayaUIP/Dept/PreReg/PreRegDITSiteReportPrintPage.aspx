<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreRegDITSiteReportPrintPage.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegDITSiteReportPrintPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">
    <title>Invset Meghalaya - CAF</title>

    <!-- Favicon -->
    <link rel="shortcut icon" type="image/x-icon" href="../images/favicon.png">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="assets/admin/css/bootstrap.min.css">

    <!-- Fontawesome CSS -->
    <link rel="stylesheet" href="assets/admin/css/font-awesome.min.css">

    <!-- Feathericon CSS -->
    <link rel="stylesheet" href="assets/admin/css/feathericon.min.css">

    <link rel="stylesheet" href="assets/admin/plugins/morris/morris.css">

    <!-- Main CSS -->
    <link rel="stylesheet" href="assets/admin/css/style.css">

    <!--[if lt IE 9]>
			<script src="assets/js/html5shiv.min.js"></script>
			<script src="assets/js/respond.min.js"></script>
		<![endif]-->
    <style>
        div#bodypart {
            margin-top: 5rem !important;
        }

        .card-body {
            padding: 5px 7px !important;
        }

        .col-md-12.d-flex.tablepadding .col-md-6.d-flex .col-md-6,
        .col-md-12.d-flex.tablepadding1 .col-md-6,
        .col-md-12.d-flex.tablepadding .col-md-4.d-flex .col-md-6,
        .col-md-12.d-flex.tablepadding3 .col-md-4,
        .col-md-12.d-flex.tablepadding2 .col-md-6,
        .col-md-12.d-flex.tablepadding4,
        .col-md-2,
        .col-md-3 {
            border: 1px solid #ccc;
            padding: 3px 15px;
            margin: 0px 0px;
        }

        .col-md-6.d-flex {
            padding: 0px !important;
        }

        .card {
            border: 1px solid #3879a6;
            margin-bottom: 1.875rem;
        }
        /* .card.bg-primary.text-white {
    background: linear-gradient(0deg, rgba(25, 135, 84, 1) 0%, rgb(18 101 102) 100%);
}
.bg-success, .badge-success {
    background: linear-gradient(0deg, rgba(74, 112, 29, 1) 0%, rgba(6, 111, 34, 1) 100%);
} */
        h5 {
            color: #fff;
            padding: 2px 13px;
            border-radius: 4px;
            text-align: center;
            margin-bottom: 0px !important;
            padding-bottom: 0px !important;
            text-transform: uppercase;
            background: #066f22;
            margin-top: -18px;
            text-shadow: 1px 2px 3px #000;
            border: 1px solid #066f22;
        }

        div#bodypart {
            background: url(../images/background/bg1.jpg);
            background-size: contain;
            background-position: top;
        }
    </style>

    <style>
        .row {
            display: -ms-flexbox;
            display: flex;
            -ms-flex-wrap: wrap;
            flex-wrap: wrap;
            margin-right: -650px;
            margin-left: 10px;
        }

        .info-table .info-table tr {
            width: auto;
            border: solid;
            margin: 20px 0;
        }

        .info-table td {
            padding: 10px 15px;
            text-align: left;
            vertical-align: middle;
        }

        .info-label {
            font-weight: bold;
            color: #333;
        }

        .tblalign {
            text-align: center;
            font-weight: bold;
        }

        .auto-style1 {
            text-align: center;
            font-weight: bold;
            width: 100%;
        }

        .auto-style2 {
            width: 13%;
        }

        .auto-style3 {
            text-align: center;
            font-weight: bold;
            width: 13%;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <!-- Main Wrapper -->
        <div class="main-wrapper">

            <!-- Header -->
            <div class="header">

                <!-- Logo -->
                <div class="header-left">
                    <a href="index.html" class="logo">
                        <img src="../../assets/admin/img/logo.png" alt="Logo"></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight: bold">The Field Officers Inspected Report</span>
                </div>
                <!-- /Logo -->
            </div>
            <div class="bodypart">

                <div class="card-header d-flex justify-content-between">
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
                <p>The Field Visit Team Inspected the,</p>
                <div>
                    <table class="info-table">
                        <tr>
                            <td class="info-label">Unit</td>
                            <td>
                                <asp:Label ID="unitNamelbl" runat="server" Text=""></asp:Label></td>
                            <td class="info-label">Place of Inspection</td>
                            <td>
                                <asp:Label ID="placelbl" runat="server" Text=""></asp:Label></td>
                            <td class="info-label">Inspected Date</td>
                            <td>
                                <asp:Label ID="datelbl" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div class="col-xl-8 col-sm-12 col-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="auto-style1">
                                <h5>Inspection Team Details</h5>
                                <hr />
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="inspectionTeam" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                    GridLines="Both" HeaderStyle-BackColor="Red"
                                    Width="100%" EnableModelValidation="True">
                                    <RowStyle />
                                    <AlternatingRowStyle BackColor="LightGray" />
                                    <HeaderStyle BackColor="Red" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No" ItemStyle-Width="3%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Officer Name" DataField="MEMBERNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Designantion" DataField="DESIGNATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                    </Columns>
                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-body">
                        <div class="col-md-12">
                            <h5>Site Verification Report</h5>
                            <hr />
                        </div>
                        <table style="text-align: center" class="info-table">
                            <tr class="tblalign">
                                <td class="auto-style3">S.no</td>
                                <td class="tblalign">Particulars</td>
                                <td class="tblalign">Remarks</td>
                            </tr>
                            <tr>
                                <td class="auto-style2">1</td>
                                <td>Name of the Unit</td>
                                <td>
                                    <asp:Label ID="nmeunitlbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">2</td>
                                <td>Location of the Unit</td>
                                <td>
                                    <asp:Label ID="locationlbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">3</td>
                                <td>Coordinates of the Site</td>
                                <td>
                                    <asp:Label ID="coordinateslbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">4</td>
                                <td>Total Area of the Site</td>
                                <td>
                                    <asp:Label ID="sitearealbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">5</td>
                                <td>Ownership Status</td>
                                <td>
                                    <asp:Label ID="ownrshplbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">6</td>
                                <td>Land Under Possession of the Unit</td>
                                <td>
                                    <asp:Label ID="undrpossesionunitlbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">7</td>
                                <td>Distance from the Main Road</td>
                                <td>
                                    <asp:Label ID="distmainrdlbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">8</td>
                                <td>Type of the Road</td>
                                <td>
                                    <asp:Label ID="typroadlbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">9</td>
                                <td>Project Construction Commencement</td>
                                <td>
                                    <asp:Label ID="constcommenclbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">10</td>
                                <td>Any Natural Bodies</td>
                                <td>
                                    <asp:Label ID="naturalbodieslbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">11</td>
                                <td>Environmentally Vulnerable Location</td>
                                <td>
                                    <asp:Label ID="envvulnerbleloclbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">12</td>
                                <td>Availability of Power</td>
                                <td>
                                    <asp:Label ID="avalpwrlbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">13</td>
                                <td>Availability of Water</td>
                                <td>
                                    <asp:Label ID="avalwaterlbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="auto-style2">14</td>
                                <td>Other Observations</td>
                                <td>
                                    <asp:Label ID="observationslbl" runat="server" txt=""></asp:Label></td>
                            </tr>
                            <tr>

                                <td style="text-align: center;" class="auto-style2">
                                    <br />
                                    Comments</td>
                                <td colspan="2" style="text-align: center">
                                    <asp:Label ID="cmntslbl" runat="server" txt=""></asp:Label></td>
                            </tr>



                        </table>

                        <div class="col-md-12 d-flex justify-content-center align-items-center" style="text-align: end;">

                            <button id="btnPrint" onclick="window.print()" class="btn btn-dark text-white" style="width: 110px; height: 40px; border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                                type="button">
                                <i class="fa fa-print" aria-hidden="true"></i>Print</button>
                            <asp:HyperLink ID="HyperLink1" CssClass="btn btn-info text-white" Width="110px" runat="server" Font-Bold="True" NavigateUrl="~/Dept/DeptDashBoard.aspx"
                                ForeColor="#3366CC"><i class="fa fa-home" aria-hidden="true"></i> Home</asp:HyperLink>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
