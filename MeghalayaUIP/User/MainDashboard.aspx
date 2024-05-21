<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="MainDashboard.aspx.cs" Inherits="MeghalayaUIP.User.MainDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../assets/admin/css/user.css" rel="stylesheet" />
    <div class="page-wrapper griddesignmulticount">
        <div class="content container-fluid">
            <div class="card">
                <div class="card-header d-flex justify-content-between">
                    <h4 class="card-title">Welcome to Dashboard</h4>
                    <h4 class="card-title">
                        <label id="unitname" runat="server"></label>
                    </h4>
                </div>
                <div>
                    <div class="col-md-12 d-flex">
                        <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-12 d-flex">
                        <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                            <strong>Warning!</strong>
                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnPreRegUNITID" runat="server" />
                    <asp:HiddenField ID="hdnPreRegUID" runat="server" />
                    <asp:HiddenField ID="hdnUserID" runat="server" />
                </div>
                <section id="dashboardcount" class="mt-2">
                    <div class="container-fluid">
                        <div class="row">
                            <asp:GridView ID="gvUserDashboard" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD table-striped table-hover" ForeColor="#333333"
                                GridLines="None" Width="100%" EnableModelValidation="True" OnRowDataBound="gvUserDashboard_RowDataBound">
                                <RowStyle />
                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="5%">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                                    <asp:BoundField HeaderText="Unit ID" DataField="UNITID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                                    <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                    <asp:BoundField HeaderText="Unit Address" DataField="UNITADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                        FooterStyle-CssClass="text-center" DataTextField="STATUS" HeaderText="Registration Under MIIPP 2024 Status">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                        FooterStyle-CssClass="text-center" DataTextField="PRE_ESTB_APPROVALS" HeaderText="Pre-Establishment">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                        FooterStyle-CssClass="text-center" DataTextField="PRE_OPERATIONAL_APPROVALS" HeaderText="Pre-Operational">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                        FooterStyle-CssClass="text-center" DataTextField="INCENTIVES" HeaderText="Incentives">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
