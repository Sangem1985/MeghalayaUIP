<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="IRDistWiseReportDrillDown.aspx.cs" Inherits="MeghalayaUIP.Dept.Reports.IRDistWiseReportDrillDown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table#ContentPlaceHolder1_GVDistWise {
            margin-bottom: 30px;
            border-bottom: 15px solid #3b4474 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../assets/admin/css/user.css" rel="stylesheet" />

    <%--<nav aria-label="breadcrumb">
        <ol class="breadcrumb d-flex justify-content-between">
            <li class="breadcrumb-item active" aria-current="page">&nbsp;</li>
            <li><a href="#"><span class="badge bg-primary text-white fw-bold">Visit Guidance Site</span></a></li>
        </ol>
    </nav>--%>
    <div class="page-wrapper griddesignmulticount">
        <div class="content container-fluid">
            <%-- <div class="card" id="Applications" runat="server" visible="false">--%>
            <div class="card-header d-flex justify-content-between">
                <h4 class="card-title mt-1"><b>District Wise Industry Registrations Report: </b></h4>
                <h4 class="card-title mt-1">
                    <label id="lblStatus" runat="server" visible="false"></label>
                </h4>
                <div class="col-md-1 d-flex " style="align-items: center; margin-right: 60px;">
                    <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" OnClick="lbtnBack_Click" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                    <div class="panel-heading" style="text-align: center">
                        <h2 id="H1" runat="server" class="panel-title d-flex" style="margin-top: 8px; padding: 0px 10px;">
                            <asp:Label ID="lblHeading" runat="server" Visible="false">District Wise Industry Registrations Report</asp:Label>
                            <asp:ImageButton ID="btnPdf" runat="server" ImageUrl="../../assets/admin/img/pdf-icon.png" Width="30px" Height="30px" Style="float: right; margin-right: 10px;" alt="PDF" OnClick="btnPdf_Click" />
                            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="../../assets/admin/img/Excel-icon.png" Width="30px" Height="30px" Style="float: right" alt="EXCEL" OnClick="btnExcel_Click" /></h2>
                    </div>
                </div>
            </div>

            <div>
                <div class="col-md-12 ">
                    <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
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
                <asp:HiddenField ID="hdnPreRegUNITID" runat="server" />
                <asp:HiddenField ID="hdnPreRegUID" runat="server" />
                <asp:HiddenField ID="hdnUserID" runat="server" />
            </div>
            <section id="dashboardcount" class="mt-2">
                <div class="container-fluid">
                    <div class="table-responsive">
                        <asp:GridView ID="GVDistWise" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table table-bordered table-striped table-hover" ForeColor="#333333"
                            GridLines="None" Width="100%" EnableModelValidation="True">
                            <RowStyle />
                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" Height="33px" HorizontalAlign="Center" />

                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="5%">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                                <asp:BoundField HeaderText="Acknowledgement ID" DataField="PREREGUIDNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="District" DataField="UNIT_DISTRICTID" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="Unit Address" DataField="UNITADDRESS" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="30%" />
                                <asp:BoundField HeaderText="Enterprise" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="10%" Visible="false" />
                                <asp:BoundField HeaderText="Status" DataField="STATUS" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="10%" />
                                <%-- <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkButton" runat="server" Text='<%# Eval("") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </section>
            <%--</div>--%>
        </div>
    </div>
</asp:Content>
