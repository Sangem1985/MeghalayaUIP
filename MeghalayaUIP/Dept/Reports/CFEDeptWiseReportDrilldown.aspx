<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="CFEDeptWiseReportDrilldown.aspx.cs" Inherits="MeghalayaUIP.Dept.Reports.CFEDeptWiseReportDrilldown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../assets/admin/css/user.css" rel="stylesheet" />

    <div class="page-wrapper griddesignmulticount">
        <div class="content container-fluid">
            <%-- <div class="card" id="Applications" runat="server" visible="false">--%>
            <div class="card-header d-flex justify-content-between">
                <h4 class="card-title mt-1"><b>CFE Department Wise Report: </b></h4>
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
                        <asp:GridView ID="GVDepartment" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
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
                               
                                <asp:BoundField HeaderText="UID" DataField="PREREGUIDNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="Name of the Industry" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" ItemStyle-Width="10%" />
                                 <asp:BoundField HeaderText="ProjectCost" DataField="PROJECTCOST" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="District" DataField="DISTRICT" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="30%" />
                                <asp:BoundField HeaderText="Department Name" DataField="DEPARTMENT" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="40%" />
                                <asp:BoundField HeaderText="Approval Name" DataField="APPROVAL" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="50%" />
                                <asp:BoundField HeaderText="Line Of Activity" DataField="LINEOFACTIVITY" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="60%" />
                                <asp:BoundField HeaderText="Address" DataField="UNITADDRESS" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="50%" />
                                   <asp:BoundField HeaderText="Date of application" DataField="DATEOFAPPLICATION" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="20%" />
                                <asp:BoundField HeaderText="Date of scrutiny" DataField="COMPLETEDDATE" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-ForeColor="WindowText" ItemStyle-Width="10%" />
                               
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </section>
            <%--</div>--%>
        </div>
    </div>
</asp:Content>
