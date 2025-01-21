<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="SingleWindowPortalDashboardDrillDown.aspx.cs" Inherits="MeghalayaUIP.SingleWindowPortalDashboardDrillDown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../assets/admin/css/user.css" rel="stylesheet" />
    <div class="page-wrapper griddesignmulticount">
        <div class="content container-fluid">
            <%-- <div class="card" id="Applications" runat="server" visible="false">--%>
            <div class="card-header d-flex justify-content-between">
                <h4 class="card-title mt-1"><b>Grievance/Feedback/General Query Report: </b></h4>
                <h4 class="card-title mt-1">
                    <label id="lblStatus" runat="server" visible="false"></label>
                </h4>
                <div class="col-md-1">
                    <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" OnClick="lbtnBack_Click" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
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
                        <asp:GridView ID="GVSWP" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table table-bordered table-striped table-hover" ForeColor="#333333"
                            GridLines="None" Width="100%" EnableModelValidation="True" ShowFooter="true">
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
                                <asp:BoundField HeaderText="UnitId" DataField="CFEDA_UNITID" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="20%" Visible="false" />
                                <asp:BoundField HeaderText="Uid" DataField="CFEDA_CFEUIDNO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="Name" DataField="CFEQD_COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="Address" DataField="ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" ItemStyle-Width="20%" />
                                <asp:BoundField HeaderText="Department" DataField="TMD_DeptName" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="15%" />
                                <%--  <asp:TemplateField HeaderText="View" Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkButton" runat="server" Text="View" OnClick="lnkButton_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFilePath" Text='<%#Eval("GRIEVANCE_FILEPATH")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
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
