<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="LAApplDeptProcess.aspx.cs" Inherits="MeghalayaUIP.Dept.LA.LAApplDeptProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/DeptDashBoard.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="#">Land Allottment</a></li>
            <li class="breadcrumb-item active" aria-current="page">Application Details</li>
        </ol>
    </nav>
    <!-- Page Wrapper -->
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card-header d-flex justify-content-between">
                <h4 class="card-title mt-1"><b>Allottment Application Details</b></h4>

                <div class="col-md-1">
                    <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                </div>
            </div>
            <div class="card flex-fill">

                <h4 class="mt-2 ml-4">View Details</h4>
                <div class="col-md-12 d-flex">
                    <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">×</span></button>
                    </div>
                </div>
                <div class="col-md-12 d-flex">
                    <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                        <strong>Warning!</strong>
                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">×</span></button>
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
                                        <h3>Land Allottment Details</h3>
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
                                    <div class="card-header" runat="server" id="divChecklistAttachment">
                                        <h3>Check Lists</h3>
                                    </div>
                                    <section id="dashboardAttachmnt">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="grdAttachments" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" OnRowDataBound="grdcfeattachment_RowDataBound"
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
                                                            <asp:BoundField HeaderText="File Name" DataField="LAA_FILEDESCRIPTION" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:TemplateField HeaderText="View">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="linkAttachment" Text='<%#Eval("LAA_FILENAME")%>' runat="server"></asp:HyperLink>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFilePath" Text='<%#Eval("FILELOCATION")%>' runat="server"></asp:Label>
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

                                                                <asp:BoundField HeaderText="Department ID" DataField="TMD_DEPTID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="false" />
                                                                <asp:BoundField HeaderText="Unit ID" DataField="AL_LAUNITID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Department Name" DataField="TMD_DeptName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Approval Name" DataField="USERNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Dept Process Status" DataField="STATUSDESCRIPTION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Dept Processed Date" DataField="DEPTPROCESSDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
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







                        <div class="panel panel-default" id="Indverifypanel" runat="server" visible="true">
                            <div class="panel-heading" role="tab" id="headingSix" runat="server">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseSix" aria-expanded="false"
                                        aria-controls="collapseSix">Verification of Application
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseSix" class="panel-collapse show" role="tabpanel"
                                aria-labelledby="headingSix" aria-expanded="false">

                                <div class="card">
                                    <div class="table-responsive">
                                        <table align="Center" style="width: 100%; align-content: center" class="table-bordered mb-10">
                                            <tr id="trVrfyhdng" runat="server">
                                                <%--<td><b>Name</b></td>
                                                <td><b>Unit Name</b></td>--%>
                                                <td><b>Application ID</b></td>
                                                <td style="width: 150px"><b>Application Date</b></td>
                                                <td style="width: 200px"><b>Application Action</b></td>
                                                <td><b>
                                                    <asp:Label runat="server" Text="Please Enter Remarks"></asp:Label></b>
                                                </td>

                                                <td id="tdaction" runat="server" visible="true">
                                                    <b>Submit Action</b>
                                                </td>
                                            </tr>
                                            <tr id="trVrfydtls" runat="server">
                                                <td>
                                                    <asp:Label ID="lblApplNo" runat="server"></asp:Label></td>
                                                <td tyle="width: 100px">
                                                    <asp:Label ID="lblapplDate" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" Class="form-control">
                                                        <asp:ListItem Text="Forward to Land Allotment Committee" Value="7"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: central">
                                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Rows="3" Columns="50" onkeypress="return Address(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>


                                                    <p>Upload File: </p>
                                                    <asp:FileUpload runat="server" ID="FileUploadqueryLand" Font-Italic="true" BorderColor="Tomato" Style="margin-top: 10px;" padding-right="10px" />

                                                    <asp:HyperLink ID="hplAttachment" runat="server" Visible="false" Text="View" Target="_blank" ForeColor="Blue"></asp:HyperLink>
                                                    <asp:Button runat="server" ID="btnUpldAttachment" Text="Upload" OnClick="btnUpldAttachment_Click" class="btn btn-dark btn-rounded" Height="35px" Width="110px" /><br />
                                                </td>

                                                <td>
                                                    <asp:Button ID="btnIndSubmit" runat="server" Text="Submit" OnClick="btnIndSubmit_Click" class="btn btn-rounded btn-submit btn-lg" Width="150px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: central" id="tdDeptQuery" runat="server" visible="false" colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>Select Department to Forward</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddldepartment" runat="server" class="form-control">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>Enter Remarks
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDeptQuery" runat="server" TextMode="MultiLine" Rows="3" Columns="50" onkeypress="return Address(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:Button ID="btnAddDeptQry" Text="Add Department" runat="server" class="btn btn-rounded btn-submit btn-lg" Width="200px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:GridView ID="grdDeptQueries" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD" ForeColor="#333333">
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                    <EditRowStyle BackColor="#B9D684" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl. No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Department Name" DataField="DEPTNAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:TemplateField Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDEPTID" runat="server" Text='<%#Eval("DEPTID") %>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Query Description" DataField="QUERYDESC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:BoundField HeaderText="UNIT ID" DataField="UNITID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:BoundField HeaderText="INVESTER ID" DataField="INVESTERID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnQuery" runat="server" Visible="false" Text="Forward" Enabled="false" class="btn btn-rounded btn-submit btn-lg" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>

                                </div>

                            </div>
                        </div>


                        <div class="panel panel-default" id="divLandAllotmentPanel" runat="server" visible="true">
                            <div class="panel-heading" role="tab" id="divLand" runat="server">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseSeven" aria-expanded="false"
                                        aria-controls="collapseSeven">Verification of Application
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseSeven" class="panel-collapse show" role="tabpanel"
                                aria-labelledby="headingSeven" aria-expanded="false">

                                <div class="card">
                                    <div class="table-responsive">
                                        <table align="Center" style="width: 100%; align-content: center" class="table-bordered mb-10">
                                            <tr id="tr1" runat="server">
                                                <td><b>Application ID</b></td>
                                                <td style="width: 150px"><b>Application Date</b></td>
                                                <td style="width: 200px"><b>Application Action</b></td>
                                                <td><b>
                                                    <asp:Label runat="server" Text="Please Enter Remarks"></asp:Label></b>
                                                </td>

                                                <td id="td1" runat="server" visible="true">
                                                    <b>Submit Action</b>
                                                </td>
                                            </tr>
                                            <tr id="tr2" runat="server">
                                                <td>
                                                    <asp:Label ID="lblApplicationID" runat="server"></asp:Label></td>
                                                <td tyle="width: 100px">
                                                    <asp:Label ID="lblApplicationDate" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:DropDownList ID="ddlLandAllotment" runat="server" Class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLandAllotment_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Approved" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="Rejected" Value="9"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: central">
                                                    <asp:TextBox ID="txtLandRemarks" runat="server" TextMode="MultiLine" Rows="3" Columns="50" onkeypress="return Address(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                                                        
                                                    <p id="PPPayment" runat="server" visible="false"></p>
                                                        <asp:TextBox ID="txtPayment" runat="server" onkeypress="return NumberOnly()" MaxLength="10" onkeyup="handleKeyUp(this)" Visible="false"></asp:TextBox>
                                                   


                                                    <p id="divUpload" runat="server"></p>
                                                    <asp:FileUpload runat="server" ID="fupLandAllotment" Font-Italic="true" BorderColor="Tomato" Style="margin-top: 10px;" padding-right="10px" />

                                                    <asp:HyperLink ID="hypLandAllotment" runat="server" Visible="false" Text="View" Target="_blank" ForeColor="Blue"></asp:HyperLink>
                                                    <asp:Button runat="server" ID="btnLandAllotment" Text="Upload" OnClick="btnLandAllotment_Click" class="btn btn-dark btn-rounded" Height="35px" Width="110px" /><br />


                                                </td>



                                                <td>
                                                    <asp:Button ID="btnLand" runat="server" Text="Submit" class="btn btn-rounded btn-submit btn-lg" Width="150px" OnClick="btnLand_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: central" id="td2" runat="server" visible="false" colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>Select Department to Forward</td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>Enter Remarks
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Rows="3" Columns="50" onkeypress="return Address(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:Button ID="Button3" Text="Add Department" runat="server" class="btn btn-rounded btn-submit btn-lg" Width="200px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD" ForeColor="#333333">
                                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                    <EditRowStyle BackColor="#B9D684" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl. No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Department Name" DataField="DEPTNAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:TemplateField Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDEPTID" runat="server" Text='<%#Eval("DEPTID") %>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Query Description" DataField="QUERYDESC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:BoundField HeaderText="UNIT ID" DataField="UNITID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                        <asp:BoundField HeaderText="INVESTER ID" DataField="INVESTERID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button4" runat="server" Visible="false" Text="Forward" Enabled="false" class="btn btn-rounded btn-submit btn-lg" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /Page Wrapper -->
</asp:Content>
