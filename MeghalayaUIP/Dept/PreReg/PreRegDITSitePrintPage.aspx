<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegDITSitePrintPage.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegDITSitePrintPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
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

    <div class="page-wrapper" style="" align="center">
        <div class="content container-fluid" align="center">
        </div>
        <div id="bodypart" align="center">
            <div class="row">
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
            </div>
            <div class="col-md-12">


                <div class="card">
                    <div class="col-md-1 pb-2 pt-2">
                        <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" OnClick="lbtnBack_Click" CssClass="btn btn-sm btn-dark" OnClientClick="history.back(); return false;"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                    </div>
                    <div class="card-header d-flex" style="display: contents !important;">
                        <h3>Field Inspection Report</h3>
                    </div>
                    
                    <div style="display: flex; justify-content: center;">
                        <section id="dashboardBasic" style="width: 70%;">
                            <div class="container-fluid">
                                <div class="row clearfix">
                                    <div class="card-body">
                                     
                                        


                                        
                                        <div class="card">
                                            <div class="card-header">
                                                <h4 class="card-title1 col-lg-12">Field Visit Team Inspection</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left; border: 1px solid #ddd; padding: 10px;">
                                            <div class="col-md-4">
                                                <label>1. Unit </label>
                                            </div>
                                            
                                            <div class="col-md-4 fw-bold text-info">
                                                <span class="dots">:</span> <asp:Label ID="unitNamelbl" runat="server" CssClass="ml-5"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left; border: 1px solid #ddd; padding: 10px;">
                                            <div class="col-md-4">
                                                <label>2. Place of Inspection</label>
                                            </div>
                                            <div class="col-md-8">
                                                <span class="dots">:</span> <asp:Label ID="placelbl" runat="server" CssClass="ml-5"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left; border: 1px solid #ddd; padding: 10px;">
                                            <div class="col-md-4">
                                                <label>3. Inspected Date</label>
                                            </div>
                                            <div class="col-md-8">
                                                <span class="dots">:</span> <asp:Label ID="datelbl" runat="server" CssClass="ml-5"></asp:Label>
                                            </div>
                                        </div>
                                            </div>
                                            </div>


                                        <div class="card">
                                            <div class="card-header">
                                                <h4 class="card-title1 col-lg-12">Inspection Team Details</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="table-responsive">

                                            <asp:GridView ID="inspectionTeam" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                                GridLines="Both" HeaderStyle-BackColor="Red"
                                                Width="100%" EnableModelValidation="True">
                                                <RowStyle />
                                                <AlternatingRowStyle BackColor="LightGray" />
                                                <HeaderStyle BackColor="Red" />
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="14%">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Officer Name" ItemStyle-Width="40%" DataField="MEMBERNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                    <asp:BoundField HeaderText="Designation" ItemStyle-Width="40%" DataField="DESIGNATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                </Columns>

                                            </asp:GridView>
                                        </div>
                                            </div>
                                        </div>
                                        
                                        <br />

                                        <div class="card">
                                            <div class="card-header">
                                                <h4 class="card-title1 col-lg-12">Site Verification Report</h4>
                                            </div>
                                            <div class="card-body">
                                                <div class="table-responsive">
                                                    <div class="table-responsive" style="text-align-last: LEFT;">
                                                <table class="table table-bordered text-center report-table" width="100%">
                                                    <thead>

                                                        <tr>
                                                            <th style="width: 2px;">S.No</th>
                                                            <th style="width: 2px; justify-content: left">Particulars</th>
                                                            <th style="width: 2px;">Remarks</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
                                                            <td>Name of the Unit</td>
                                                            <td>
                                                                <asp:Label ID="nmeunitlbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>2</td>
                                                            <td>Location of the Unit</td>
                                                            <td>
                                                                <asp:Label ID="locationlbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>3</td>
                                                            <td>Coordinates</td>
                                                            <td>
                                                                <asp:Label ID="coordinateslbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>4</td>
                                                            <td>Total Area</td>
                                                            <td>
                                                                <asp:Label ID="sitearealbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style2">5</td>
                                                            <td>Ownership Status</td>
                                                            <td>
                                                                <asp:Label ID="ownrshplbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style2">6</td>
                                                            <td>Land Under Possession of the Unit</td>
                                                            <td>
                                                                <asp:Label ID="undrpossesionunitlbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style2">7</td>
                                                            <td>Distance from the Main Road</td>
                                                            <td>
                                                                <asp:Label ID="distmainrdlbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style2">8</td>
                                                            <td>Type of the Road</td>
                                                            <td>
                                                                <asp:Label ID="typroadlbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style2">9</td>
                                                            <td>Project Construction Commencement</td>
                                                            <td>
                                                                <asp:Label ID="constcommenclbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style2">10</td>
                                                            <td>Any Natural Bodies</td>
                                                            <td>
                                                                <asp:Label ID="naturalbodieslbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style2">11</td>
                                                            <td>Environmentally Vulnerable Location</td>
                                                            <td>
                                                                <asp:Label ID="envvulnerbleloclbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style2">12</td>
                                                            <td>Availability of Power</td>
                                                            <td>
                                                                <asp:Label ID="avalpwrlbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style2">13</td>
                                                            <td>Availability of Water</td>
                                                            <td>
                                                                <asp:Label ID="avalwaterlbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style2">14</td>
                                                            <td>Other Observations</td>
                                                            <td>
                                                                <asp:Label ID="observationslbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                        <tr>
                                                            <td colspan="2"><strong>Comments</strong></td>
                                                            <td>
                                                                <asp:Label ID="cmntslbl" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                            
                                        </div>
                                            </div>
                                        </div>



                                        <h4 class="card-title1 col-lg-12"></h4>
                                        <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 13px; text-align: left;">
                                            

                                        </div>





                                    </div>
                                </div>
                            </div>

                        </section>
                    </div>
                </div>

            </div>

        </div>
        <!-- /Page Wrapper -->
        <br />
        <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
            type="button" value="Print" /><br />
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Visible="false" NavigateUrl="~/Home.aspx"
            ForeColor="#3366CC">Home</asp:HyperLink>
        <br />
    </div>
</asp:Content>
