<%@ Page Title="" Language="C#" MasterPageFile="~/outernew.Master" AutoEventWireup="true" CodeBehind="ViewCertifcateDetails.aspx.cs" Inherits="MeghalayaUIP.ViewCertifcateDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="assets/admin/css/style.css">
    <style>
        th {
            background: #728ab0;
            color: #fff;
            line-height: 35px;
        }

        td {
            background: #fff;
            line-height: 35px;
            font-weight: 500;
        }

        table#ContentPlaceHolder1_gvDetails {
            box-shadow: 1px 4px 4px #ccc;
            margin-bottom: 20px;
        }

        .table-responsive {
            white-space: normal;
            border-radius: 6px !important;
        }
    </style>
    <section class="innerpages IntentInvest mt-4">
        <div class="container">
            <div class="row">
                <div class="col-md-12">

                    <div class="">
                        <div class="content container-fluid">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <h4 class="card-title">View Certificate Details</h4>
                                        </div>
                                        <div class="card-body mobile">
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
                                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-lg-6 col-form-label">Type of Application</label>
                                                        <div class="col-lg-12 d-flex">
                                                            <asp:DropDownList ID="ddlTypeApplication" runat="server" aria-label="Default select example" class="form-control" Style="width: 100%; height: 32px;">
                                                                <asp:ListItem Value="0" Selected="True">Select Application</asp:ListItem>
                                                                <asp:ListItem Value="1">CFE</asp:ListItem>
                                                                <asp:ListItem Value="2">CFO</asp:ListItem>
                                                                <asp:ListItem Value="3">Renewals</asp:ListItem>
                                                                <asp:ListItem Value="5">Services</asp:ListItem>
                                                                <asp:ListItem Value="4">Startups</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-lg-12 col-form-label">Enter UID Number</label>
                                                        <div class="col-lg-12 d-flex">
                                                            <input type="text" id="txtUIDNo" runat="server" class="form-control" name="input" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                    <div class="form-group">
                                                        <label class="col-lg-12 col-form-label">Enter Name of Unit</label>
                                                        <div class="col-lg-12 d-flex">
                                                            <input type="text" id="txtUnitName" runat="server" class="form-control" name="input" />
                                                        </div>
                                                    </div>
                                                </div>



                                            </div>
                                            <div class="col-md-12 mt-4" style="text-align: center;">
                                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-info btn-submit" Width="120px" OnClick="btnsubmit_Click" />
                                            </div>

                                            <div class="col-md-12 d-flex" id="divGrid" runat="server" visible="false" style="margin-top: 25px;">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="table table-dark table-striped table-bordered" ForeColor="#333333" Width="100%" BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px"
                                                        EmptyDataText="No Data Available" OnRowDataBound="gvDetails_RowDataBound">
                                                        <RowStyle CssClass="GRDITEM" VerticalAlign="Middle" />
                                                        <HeaderStyle CssClass="GRDHEADER" Font-Bold="True" ForeColor="Black" BackColor="blanchedalmond" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">

                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="NAMEOFUNIT" HeaderText="Unit Name">
                                                                <ItemStyle Width="350px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UIDNO" HeaderText="UID No">
                                                                <ItemStyle Width="350px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UNITLOCATION" HeaderText="Unit Location">
                                                                <ItemStyle Width="350px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UNITADDRESS" HeaderText="Unit Address">
                                                                <ItemStyle Width="350px" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Download">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink Text="View" Target="_blank" CssClass="btn btn-sm btn-info" runat="server" ID="hypView" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unit Id" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUnitId" runat="server" Text='<%# Eval("UNITID")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="Uid No" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUID" runat="server" Text='<%# Eval("UIDNO")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unit Name" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUnitName" runat="server" Text='<%# Eval("NAMEOFUNIT")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Application Type" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApptype" runat="server" Text='<%# Eval("APPTYPE")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- <asp:TemplateField HeaderText="Date" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("DATEOFAPPROVAL")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>


                                            <div class="col-md-12 d-flex" id="divStatup" runat="server" visible="false" style="margin-top: 25px;">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GVStratup" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="table table-dark table-striped table-bordered" ForeColor="#333333" Width="100%" BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px"
                                                        EmptyDataText="No Data Available" OnRowDataBound="gvDetails_RowDataBound">
                                                        <RowStyle CssClass="GRDITEM" VerticalAlign="Middle" />
                                                        <HeaderStyle CssClass="GRDHEADER" Font-Bold="True" ForeColor="Black" BackColor="blanchedalmond" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">

                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="100px" />
                                                            </asp:TemplateField>

                                                            <asp:BoundField DataField="UIDNO" HeaderText="UID No">
                                                                <ItemStyle Width="350px" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="BUSINESSNAME" HeaderText="Business Name">
                                                                <ItemStyle Width="350px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="NAMEOFPERSON" HeaderText="Person Name">
                                                                <ItemStyle Width="350px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="EMAILID" HeaderText="EMAIL ID">
                                                                <ItemStyle Width="350px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BLOCK" HeaderText="Address">
                                                                <ItemStyle Width="350px" />
                                                            </asp:BoundField>

                                                            <asp:TemplateField HeaderText="Download">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink Text="View" Target="_blank" CssClass="btn btn-sm btn-info" runat="server" ID="hypView" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Unit Id" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUnitId" runat="server" Text='<%# Eval("UIDNO")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Application Type" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblApptype" runat="server" Text='<%# Eval("NAMEOFPERSON")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("DATEOFAPPROVAL")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



        </div>
    </section>
</asp:Content>
