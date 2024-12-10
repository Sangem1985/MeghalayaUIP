<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="LAApplDetails.aspx.cs" Inherits="MeghalayaUIP.User.LA.LAApplDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
    <!-- Page Wrapper -->
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card flex-fill">

                <h4 class="mt-2 ml-4">View Details</h4>
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

                <div class="col-md-12">
                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingOne">
                                <h4 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion"
                                        href="#collapseOne" aria-expanded="false" aria-controls="collapseOne"
                                        class="collapsed">Land Application Details
                                    </a>

                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingOne" aria-expanded="false" style="height: 0px;">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Land IndustrialShed Details</h3>
                                    </div>
                                    <div class="alldetails" id="bodypart">
                                        <div class="row mt-4">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Project Details</h5>
                                                            <hr />
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Firm Name</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">District</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblDistric" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Mandal</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblMandal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Village</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblVillage" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Name of the Industrial Estate/Industrial Area/Export Promotion Industrial Park/Industrial Growth Centre where land/shed is required</h5>
                                                            <hr />
                                                        </div>
                                                        <div align="center">
                                                            <asp:GridView ID="GVIndustrialArea" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                Font-Size="12px" SkinID="gridviewSkin" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex +1 %>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="IE_NAMEOFINUSTRIALPARK" HeaderText="Name of the industrial park" />
                                                                    <asp:BoundField DataField="IE_LANDREQ" HeaderText="Quantum of land required (in square metres)" />
                                                                    <asp:BoundField DataField="IE_SHEDSNO" HeaderText="Nos. of sheds required" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Proposed items for manufacturing</h5>
                                                            <hr />
                                                        </div>
                                                        <div align="center">
                                                            <asp:GridView ID="GVManu" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex +1 %>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="MD_NAMEOFPRODUCT" HeaderText="Name of products" />
                                                                    <asp:BoundField DataField="MD_ANNUALCAPACITY" HeaderText="Annual manufacturing capacity (in tonne)" />
                                                                    <asp:BoundField DataField="MD_APPROXVALUE" HeaderText="Appox. value (₹)" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Proposed annual consumption of major raw material</h5>
                                                            <hr />
                                                        </div>
                                                        <div align="center">
                                                            <asp:GridView ID="GVRawMaterial" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex +1 %>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="RD_NAMEOFRAWMATERIAL" HeaderText="Name of major raw material" />
                                                                    <asp:BoundField DataField="RD_ANNUALCONSUMPTIONCAPACITY" HeaderText="Annual manufacturing capacity (in tonne)" />
                                                                    <asp:BoundField DataField="RD_APPOX" HeaderText="Appox. value (₹ in lakh)" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Power requirement</h5>
                                                            <hr />
                                                        </div>
                                                        <div align="center">
                                                            <asp:GridView ID="GVPOWER" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex +1 %>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField DataField="PD_QUANTUMENERGYLOAD" HeaderText="Quantum of energy/load required (in KW)" />
                                                                    <asp:BoundField DataField="PD_ENERGYLOAD" HeaderText="Proposed source of energy/load" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Proposed requirement of water for manufacturing</h5>
                                                            <hr />
                                                        </div>
                                                        <div align="center">
                                                            <asp:GridView ID="GVWATER" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                                                Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex +1 %>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField DataField="WD_REQWATER" HeaderText="Proposed requirement of water for manufacturing" />
                                                                    <asp:BoundField DataField="WD_SOURCEOFWATER" HeaderText="Proposed source of water" />

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Means of finance (₹ in lakh)</h5>
                                                            <hr />
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Equity</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblEquity" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Term Loan from Bank/FI:</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblBank" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Unsecured loan:</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblUnsecured" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Internal resources:</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblInternal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Any other source:</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblSource" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 d-flex">
                                                                <div class="col-md-6">Total:</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xl-12 col-sm-12 col-12">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="col-md-12">
                                                            <h5>Other Details</h5>
                                                            <hr />
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Category of the enterprise:</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Plant & Machinery (₹ in lakh):</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblPMLakh" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex tablepadding">
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Total project cost (₹ in lakh):</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblCost" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6 d-flex">
                                                                <div class="col-md-6">Details of waste/effluent to be generated:</div>
                                                                <div class="col-md-6">
                                                                    <asp:Label ID="lblDetails" runat="server"></asp:Label>
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
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingTwo">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseTwo" aria-expanded="false"
                                        aria-controls="collapseTwo">Attachments
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingTwo" style="" aria-expanded="false">


                                <div class="card">
                                    <div class="card-header">
                                        <h3>Check Lists</h3>
                                    </div>
                                    <section id="dashboardAttachmnt">
                                        <div class="container-fluid">
                                            <div class="row clearfix">



                                                <div class="table-responsive">
                                                    <asp:GridView ID="grdcfeattachment" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-hover" ForeColor="#333333"
                                                        GridLines="Both" Width="100%" EnableModelValidation="True" ShowHeaderWhenEmpty="true">
                                                        <RowStyle />

                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="File Name" DataField="CFMA_NAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />

                                                            <asp:TemplateField HeaderText="View">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink runat="server" ID="hplApplied" Target="_blank" Text='<%#Eval("CFEA_FILENAME")%>' NavigateUrl='<%#Eval("FILENAME")%>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>

                                                </div>




                                            </div>
                                        </div>
                                    </section>
                                </div>


                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingThree">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseThree" aria-expanded="false"
                                        aria-controls="collapseThree">Query
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseThree" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingThree" aria-expanded="false">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Queries</h3>
                                    </div>
                                    <section id="dashboardQuery">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-sm-12">
                                                    <asp:GridView ID="grdQueries" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                                        GridLines="Both" Width="100%" EnableModelValidation="True" ShowHeaderWhenEmpty="true">
                                                        <RowStyle />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="LightGray" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="UNIT ID" DataField="UNITID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <%--<asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />--%>
                                                            <asp:BoundField HeaderText="Query Raised By" DataField="QUERYBY" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Description" DataField="QUERYRAISEDESC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Raised Date" DataField="QUERYDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Response" DataField="QUERYRESPONSEDESC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Response Date" DataField="QUERYRESPONSEDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>

                                                    </asp:GridView>
                                                </div>

                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingFour">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseFour" aria-expanded="false"
                                        aria-controls="collapseFour">Query Response Attachments
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseFour" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingFour" aria-expanded="false">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Attachments in Response to Query Raised</h3>
                                    </div>
                                    <section id="dashboardQueryattachmnts">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="grdQryAttachments" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="Both" Width="80%" EnableModelValidation="True" ShowHeaderWhenEmpty="true">
                                                        <RowStyle />
                                                        <AlternatingRowStyle BackColor="LightGray" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="File Name" DataField="IDD_FIRSTNAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="View" DataField="IDD_LASTNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    </asp:GridView>
                                                    <%--<div class="table-responsive">                                                      
                                                       </div>--%>
                                                </div>

                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingFive">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseFive" aria-expanded="false"
                                        aria-controls="collapseFive">Status of Application
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseFive" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingFive" aria-expanded="false">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Status of Application</h3>
                                    </div>
                                    <section id="dashboardStatus">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-sm-12">

                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdApplStatus" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-hover" ForeColor="#333333"
                                                            GridLines="Both" Width="100%" EnableModelValidation="True">
                                                            <RowStyle />

                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField HeaderText="Department ID" DataField="Dept_Id" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="false" />
                                                                <asp:BoundField HeaderText="Unit ID" DataField="PRDA_UNITID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Department Name" DataField="MD_DEPT_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Approval Name" DataField="ApprovalName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Dept Process Status" DataField="STATUSDESCRIPTION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Dept Processed Date" DataField="PRDA_DEPTPROCESSDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        </asp:GridView>
                                                    </div>
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
        </div>
    </div>
</asp:Content>
