﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="IndustryRegistrationViewDetails.aspx.cs" Inherits="MeghalayaUIP.User.PreReg.IndustryRegistrationViewDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../assets/admin/css/accordion.css" rel="stylesheet" />
    <!-- Page Wrapper -->
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card flex-fill">

                <h4 class="mt-2 ml-4">View Details</h4>
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
                <div class="col-md-12">
                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingOne">
                                <h4 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion"
                                        href="#collapseOne" aria-expanded="false" aria-controls="collapseOne"
                                        class="collapsed">Application Details
                                    </a>

                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingOne" aria-expanded="false" style="height: 0px;">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>Applicant And Unit Details</h3>
                                    </div>
                                    <section id="dashboardBasic">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="card-body">
                                                    <h4 class="card-title">1. Basic Details</h4>

                                                    <div class="row">
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <label>Company Registration / Incorporation Date :</label>

                                                                <asp:Label ID="lblregdate" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <label>Udyam/IEM No :</label>

                                                                <asp:Label ID="lblUdyam" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <label>
                                                                    GSTIN Number :</label>

                                                                <asp:Label ID="lblGSTIN" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 600; font-size: 20px;">Correspodence
																		details of authorised representative</span></label>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Name * :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Mobile * :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblMobile" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- </div>
																<div class="col-md-12 d-flex"  > -->
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">E-mail * :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">
                                                                    Locality
																			* :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblLocality" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">
                                                                    District
																			* :</label>
                                                                <div class="col-lg-8">
                                                                    <asp:Label ID="lblDistict" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Mandal * :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblMandal" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- </div>
																<div class="col-md-12 d-flex"  > -->
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Village * :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblVillage" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-4 col-form-label">Pincode * :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:Label ID="lblPincode" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span
                                                                style="font-weight: 900; font-size: 20px;">Proposed
																		Location of
																		Unit</span></label>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Door No.
																			* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lbldrno" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Locality
																			* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblPro_loc" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <!-- </div>
																<div class="col-md-12 d-flex"  > -->
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    District
																			* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblpro_dis" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mandal * :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblPro_Man" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Village
																			* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblPro_vill" runat="server"></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Pin Code
																			* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblPro_Pin" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span
                                                                style="font-weight: 900; font-size: 20px;">Project
																		Details</span></label>
                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Nature of
																			Activity* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblNatureofAct" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Main
																			Manufacturing/ Service
																			Activity* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblMainmanu" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <!-- </div>
																<div class="col-md-12 d-flex"  > -->
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Product to be
																			Manufactured /
																			service to be provided* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblpro_manu" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Date of
																			Commencement of
																			Production/operation* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblDateofcomm" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label fw-bold">
                                                                    If
																			Existing – Production
																			no./ service no.* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblexisting" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Annual
																			Capacity* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblannual" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Estimated Project
																			Cost
																			(INR)* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblestimatedcost" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Land*(in
																			Sq.ft)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblland" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <!-- </div>
																<div class="col-md-12 d-flex"  > -->
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Civil
																			Construction* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblcivil" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Plant & Machinery
																			(INR)* :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblplant" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Main raw
																			materials for the
																			proposed project</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblmain_raw" runat="server"></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Building / Shed
																			(Sq. m)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblbuilding" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Water required
																			(KL/D)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblwater" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Power
																			(KV)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblpower" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Details of waste
																			/ effluent to be
																			generated</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lbldet_waste" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Details of
																			hazardous waste to be
																			generated</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lbldet_hazar" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Investment in
																			Fixed Capital
																			(INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblinvestment" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Durable Fixed
																			Assets
																			(INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lbldurable" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Unit of
																			measurement</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblunitofmeasure" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Building / Shed
																			(INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblbuildingshed" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Water
																			(INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblwaterinr" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Electricity
																			(INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblelectricity" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Working Capital
																			(INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblworking" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span
                                                                style="font-weight: 900; font-size: 20px;">Finance
																		Revenue
																		Details</span></label>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-8 col-form-label">
                                                                    Capital Subsidy/
																			Benefit from
																			UNNATI/ other Central / State Scheme (INR)</label>
                                                                <div class="col-lg-4 d-flex">
                                                                    <asp:Label ID="lblcapital" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Promoter’s Equity
																			(INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblpromoter" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Loan
																			(INR)</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label ID="lblloan" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 900; font-size: 20px; padding-left: 45px">Production and Sales particulars for the Last 5 Years</span></label>
                                                    </div>
                                                    <p></p>
                                                    <div class="table-responsive">
                                                        <center>
                                                            <asp:GridView ID="grdRevenueProj" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                                                GridLines="Both" HeaderStyle-BackColor="Red"
                                                                Width="80%" EnableModelValidation="True">
                                                                <RowStyle />
                                                                <AlternatingRowStyle BackColor="LightGray" />
                                                                <HeaderStyle BackColor="Red" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Items" DataField="ITEMS" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="YEAR1" DataField="YEAR1" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="YEAR2" DataField="YEAR2" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="YEAR3" DataField="YEAR3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="YEAR4" DataField="YEAR4" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="YEAR5" DataField="YEAR5" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                </Columns>
                                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <AlternatingRowStyle BackColor="White" />
                                                            </asp:GridView>
                                                        </center>

                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 900; font-size: 20px; padding-left: 45px">Directors / Promoters Details</span></label>
                                                    </div>
                                                    <p></p>
                                                    <div class="table-responsive">
                                                        <center>
                                                            <asp:GridView ID="grdDirectors" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                                                GridLines="Both" HeaderStyle-BackColor="Red"
                                                                Width="80%" EnableModelValidation="True">
                                                                <RowStyle />
                                                                <AlternatingRowStyle BackColor="LightGray" />
                                                                <HeaderStyle BackColor="Red" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Name" DataField="NAME" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="left" />
                                                                    <asp:BoundField HeaderText="Aadhar No." DataField="IDD_ADNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="PAN No." DataField="IDD_PAN" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="DIN No." DataField="IDD_DINNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Mobile No." DataField="IDD_PHONE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="E-Mail" DataField="IDD_EMAIL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField HeaderText="Address" DataField="ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                </Columns>
                                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                <AlternatingRowStyle BackColor="White" />
                                                            </asp:GridView>
                                                        </center>

                                                    </div>
                                                </div>

                                                <%-- <div class="text-center mt-2">
                                                        <a href="#basictab2" data-toggle="tab">
                                                            <button type="submit"
                                                                class="btn btn-rounded btn-info btn-lg">
                                                                Print</button></a>
                                                    </div>--%>
                                            </div>
                                        </div>
                                        <%-- </div>--%>
                                    </section>
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
                                                <div class="col-md-12">
                                                    <div class="table-responsive">
                                                        <table class="table table-bordered mb-0">
                                                            <thead>
                                                                <tr>
                                                                    <th>Attachment Name</th>
                                                                    <th></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>


                                                                <tr>
                                                                    <td class="fw-bold">DPR</td>

                                                                    <td>
                                                                        <button type="button" class="btn btn-rounded btn-dark">View</button>
                                                                    </td>
                                                                </tr>


                                                            </tbody>
                                                        </table>
                                                    </div>
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
                                                            <asp:BoundField HeaderText="Unit Name" DataField="UNITID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Raised By" DataField="QUERYBY" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Description" DataField="QUERYRAISEDESC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Raised Date" DataField="QUERYDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Response" DataField="QUERYRESPONSEDESC" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Query Response Date" DataField="QUERYRESPONSEDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>

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
                                        <h3>Query Response Attachments Check Lists</h3>
                                    </div>
                                    <section id="dashboardQueryattachmnts">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="grdQryAttachments" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="Both" Width="80%" EnableModelValidation="True" ShowHeaderWhenEmpty="true">
                                                        <RowStyle />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
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
                                                    <asp:GridView ID="grdApplStatus" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD" ForeColor="#333333"
                                                        GridLines="Both" Width="100%" EnableModelValidation="True">
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

                                                            <asp:BoundField HeaderText="Department ID" DataField="PRDA_DEPTID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="false" />
                                                            <asp:BoundField HeaderText="Unit ID" DataField="PRDA_UNITID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Department Name" DataField="MD_DEPT_NAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Dept Process Status" DataField="STATUSDESCRIPTION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Dept Processed Date" DataField="PRDA_DEPTPROCESSDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
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
                        <div class="panel panel-default" id="QueryResondpanel" runat="server" visible="false">
                            <div class="panel-heading" role="tab" id="headingSix">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse"
                                        data-parent="#accordion" href="#collapseSix" aria-expanded="false"
                                        aria-controls="collapseSix">Respond to Query
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseSix" class="panel-collapse show" role="tabpanel"
                                aria-labelledby="headingSix" aria-expanded="false">

                                <div class="card">

                                    <asp:GridView ID="grdQueryRaised" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" CssClass="table-bordered mb-0 GRD"
                                        GridLines="Both" Width="100%" EnableModelValidation="True" ShowHeaderWhenEmpty="true">
                                        <RowStyle />
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="LightGray" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DepQID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblDQID" Text='<%#Eval("IRQID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="QueryByDeptID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblDeptID" Text='<%#Eval("QUERYRAISEDBYDEPTID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UNIT ID">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUNITID" runat="server" Text='<%#Eval("UNITID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Query By (Dept.Name)" DataField="QUERYBY" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Query Raised on" DataField="QUERYDATE" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Query Description" DataField="QUERYRAISEDESC" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" />
                                            <asp:TemplateField HeaderText="Reply to Query">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtResponse" runat="server" TextMode="MultiLine" Width="400PX"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Submit">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnRespond" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnRespond_Click" ></asp:Button>
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
    <!-- /Page Wrapper -->


    <!-- /Main Wrapper -->

    <!-- jQuery -->
</asp:Content>