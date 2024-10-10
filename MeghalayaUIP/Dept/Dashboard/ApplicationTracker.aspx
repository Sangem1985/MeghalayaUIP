<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="ApplicationTracker.aspx.cs" Inherits="MeghalayaUIP.Dept.Dashboard.ApplicationTracker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
            <li class="breadcrumb-item">Department</li>
            <li class="breadcrumb-item">Dashboard</li>
            <li class="breadcrumb-item active" aria-current="page">Application Tracker</li>
        </ol>
    </nav>
    <style>
        .col-md-12.d-flex {
            right: -275px;
            padding: 0px 0px !important;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="card-header d-flex justify-content-between">
                        <h4 class="card-title mt-1"><b>Application Tracker:</b></h4>
                        <div class="col-md-1">
                            <asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-body">
                            <div class="col-md-12 ">
                                <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
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
                            <div align="center">
                                <div class="row" align="center">
                                    <div class="panel panel-primary">
                                        <div class="panel-body">

                                            <div class="card-body justify-content-center " align="justify">
                                                <div class="panel panel-default">
                                                    <div class="col-md-12 d-flex justify-content-center align-items-center">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="col-lg-6 col-form-label">Application Type:</label>
                                                                <div class="col-lg-4 d-flex">
                                                                    <asp:DropDownList ID="ddlApplication" runat="server" class=" form-control" AutoPostBack="true">
                                                                        <asp:ListItem Value="0">--ALL--</asp:ListItem>
                                                                        <asp:ListItem Value="IR">INDUSTRY REGISTRATION</asp:ListItem>
                                                                        <asp:ListItem Value="LA">LAND ALLOTTMENT</asp:ListItem>
                                                                        <asp:ListItem Value="CFE">CFE</asp:ListItem>
                                                                        <asp:ListItem Value="CFO">CFO</asp:ListItem>
                                                                        <asp:ListItem Value="REN">RENEWAL</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="col-lg-5 col-form-label">Unit Name:</label>
                                                                <div class="col-lg-4 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtName" class="form-control" TabIndex="1" />

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label class="col-lg-6 col-form-label">UID Number: </label>
                                                                <div class="col-lg-4 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtuid" class="form-control" />

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex justify-content-center align-items-center">

                                                        <div class="col-md-12 float-left ">
                                                            <div class="form-group row justify-content-center" style="padding: 20px">
                                                                <asp:Button ID="btnsubmit" runat="server" Text="Search" OnClick="btnsubmit_Click" ValidationGroup="Search" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                                                <asp:Button ID="btnClear" runat="server" Text="Clear" ValidationGroup="Search" class="btn btn-rounded btn-warning btn-lg" Width="150px" />
                                                            </div>

                                                        </div>

                                                    </div>
                                                    <div>
                                                        <asp:GridView ID="GVIndustry" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="grid-view" ForeColor="#333333"
                                                            GridLines="Both" ShowFooter="true" OnRowDataBound="GVIndustry_RowDataBound"
                                                            Width="100%" EnableModelValidation="True">
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <AlternatingRowStyle BackColor="LightGray" Font-Bold="true" />
                                                            <RowStyle Height="40px" BorderColor="Blue" Font-Bold="true" />
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unitid" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitId" runat="server" Text='<%#Eval("UNITID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="InvesterId" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInvesterId" runat="server" Text='<%#Eval("INVESTERID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="StageID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStageID" runat="server" Text='<%#Eval("STATUS") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               
                                                                <asp:BoundField DataField="UIDNO" HeaderText="UID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="UNITNAME" HeaderText="Name Of the Industry" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="ACTIVITYPROPOSED" HeaderText="Activity Proposed" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="LINEOFACTIVITY" HeaderText="Line of Activity" ItemStyle-HorizontalAlign="Left" />
                                                                <%-- <asp:BoundField DataField="" HeaderText="Total Investment (in Crores)" ItemStyle-HorizontalAlign="Left" />--%>
                                                                <asp:BoundField DataField="DATEOFREGISTER" HeaderText="Date of application" ItemStyle-HorizontalAlign="Left" />

                                                                <asp:TemplateField HeaderText="View Status">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton Text="Click Here" runat="server" ID="lnkIndustry" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>

                                                            </Columns>

                                                        </asp:GridView>
                                                    </div>

                                                    <div>
                                                        <asp:GridView ID="GVLnad" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="grid-view" ForeColor="#333333"
                                                            GridLines="Both" ShowFooter="true" OnRowDataBound="GVLnad_RowDataBound"
                                                            Width="100%" EnableModelValidation="True">
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <AlternatingRowStyle BackColor="LightGray" Font-Bold="true" />
                                                            <RowStyle Height="40px" BorderColor="Blue" Font-Bold="true" />
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="UIDNO" HeaderText="UID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="UNITNAME" HeaderText="Name Of the Industry" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="ACTIVITYPROPOSED" HeaderText="Activity Proposed" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="LINEOFACTIVITY" HeaderText="Line of Activity" ItemStyle-HorizontalAlign="Left" />
                                                                <%-- <asp:BoundField DataField="" HeaderText="Total Investment (in Crores)" ItemStyle-HorizontalAlign="Left" />--%>
                                                                <asp:BoundField DataField="DATEOFREGISTER" HeaderText="Date of application" ItemStyle-HorizontalAlign="Left" />

                                                                <asp:TemplateField HeaderText="View Status">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="lnkLand" Target="_blank" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>

                                                            </Columns>

                                                        </asp:GridView>
                                                    </div>

                                                    <div>
                                                        <asp:GridView ID="GVCFE" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="grid-view" ForeColor="#333333"
                                                            GridLines="Both" ShowFooter="true" OnRowDataBound="GVCFE_RowDataBound"
                                                            Width="100%" EnableModelValidation="True">
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <AlternatingRowStyle BackColor="LightGray" Font-Bold="true" />
                                                            <RowStyle Height="40px" BorderColor="Blue" Font-Bold="true" />
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unitid" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitId" runat="server" Text='<%#Eval("CFEQD_UNITID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="InvesterId" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInvesterId" runat="server" Text='<%#Eval("CFEQD_CREATEDBY") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:BoundField DataField="UIDNO" HeaderText="UID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="UNITNAME" HeaderText="Name Of the Industry" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="ACTIVITYPROPOSED" HeaderText="Activity Proposed" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="LINEOFACTIVITY" HeaderText="Line of Activity" ItemStyle-HorizontalAlign="Left" />
                                                                <%--<asp:BoundField DataField="" HeaderText="Total Investment (in Crores)" ItemStyle-HorizontalAlign="Left" />--%>
                                                                <asp:BoundField DataField="DATEOFREGISTER" HeaderText="Date of application" ItemStyle-HorizontalAlign="Left" />

                                                                <asp:TemplateField HeaderText="View Status">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="lnkCFE" Target="_blank" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>

                                                            </Columns>

                                                        </asp:GridView>
                                                    </div>

                                                    <div>
                                                        <asp:GridView ID="GVCFO" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="grid-view" ForeColor="#333333"
                                                            GridLines="Both" ShowFooter="true" OnRowDataBound="GVCFO_RowDataBound"
                                                            Width="100%" EnableModelValidation="True">
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <AlternatingRowStyle BackColor="LightGray" Font-Bold="true" />
                                                            <RowStyle Height="40px" BorderColor="Blue" Font-Bold="true" />
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unitid" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitId" runat="server" Text='<%#Eval("CFOQD_UNITID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="InvesterId" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInvesterId" runat="server" Text='<%#Eval("CFOQD_CREATEDBY") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="UIDNO" HeaderText="UID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="UNITNAME" HeaderText="Name Of the Industry" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="ACTIVITYPROPOSED" HeaderText="Activity Proposed" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="LINEOFACTIVITY" HeaderText="Line of Activity" ItemStyle-HorizontalAlign="Left" />
                                                                <%--<asp:BoundField DataField="" HeaderText="Total Investment (in Crores)" ItemStyle-HorizontalAlign="Left" />--%>
                                                                <asp:BoundField DataField="DATEOFREGISTER" HeaderText="Date of application" ItemStyle-HorizontalAlign="Left" />

                                                                <asp:TemplateField HeaderText="View Status">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="lnkCFO" Target="_blank" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>

                                                            </Columns>

                                                        </asp:GridView>
                                                    </div>

                                                    <div>
                                                        <asp:GridView ID="GVREN" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="grid-view" ForeColor="#333333"
                                                            GridLines="Both" ShowFooter="true" OnRowDataBound="GVREN_RowDataBound"
                                                            Width="100%" EnableModelValidation="True">
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <AlternatingRowStyle BackColor="LightGray" Font-Bold="true" />
                                                            <RowStyle Height="40px" BorderColor="Blue" Font-Bold="true" />
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Unitid" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitId" runat="server" Text='<%#Eval("RENID_UNITID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="InvesterId" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInvesterId" runat="server" Text='<%#Eval("RENID_CREATEDBY") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="UIDNO" HeaderText="UID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="UNITNAME" HeaderText="Name Of the Industry" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="ACTIVITYPROPOSED" HeaderText="Activity Proposed" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="LINEOFACTIVITY" HeaderText="Line of Activity" ItemStyle-HorizontalAlign="Left" />
                                                                <%-- <asp:BoundField DataField="" HeaderText="Total Investment (in Crores)" ItemStyle-HorizontalAlign="Left" />--%>
                                                                <asp:BoundField DataField="DATEOFREGISTER" HeaderText="Date of application" ItemStyle-HorizontalAlign="Left" />

                                                                <asp:TemplateField HeaderText="View Status">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="lnkRenewal" Target="_blank" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
