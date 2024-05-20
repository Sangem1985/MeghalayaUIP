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
                <section id="dashboardcount" class="mt-2">
                    <div class="container-fluid">
                        <div class="row">
                            <asp:GridView ID="gvUserDashboard" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD table-striped table-hover" ForeColor="#333333"
                                GridLines="None" Width="100%" EnableModelValidation="True">
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
                                    <asp:BoundField HeaderText="Unit ID" DataField="UNITID" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                                    <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                    <asp:BoundField HeaderText="Unit Address" DataField="UNITADDRESS" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                    <asp:BoundField HeaderText="Registration Under MIIPP 2024 Status" DataField="STATUS" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                    <asp:BoundField HeaderText="Pre-Establishment" DataField="PRE_ESTB_APPROVALS" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                    <asp:BoundField HeaderText="Pre-Operational" DataField="PRE_OPERATIONAL_APPROVALS" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                    <asp:BoundField HeaderText="Incentives" DataField="INCENTIVES" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                    </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>
