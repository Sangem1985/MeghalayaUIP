<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="CFEApplDeptProcess.aspx.cs" Inherits="MeghalayaUIP.Dept.CFE.CFEApplDeptProcess" %>

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
                                        class="collapsed">CFE Application Details
                                    </a>

                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse" role="tabpanel"
                                aria-labelledby="headingOne" aria-expanded="false" style="height: 0px;">
                                <div class="card">
                                    <div class="card-header">
                                        <h3>CFE Questionnaire Details</h3>
                                    </div>
                                    <section id="dashboardBasic">
                                        <div class="container-fluid">
                                            <div class="row clearfix">
                                                <div class="card-body">
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 600; font-size: 20px;">Project Details: </span>
                                                        </label>
                                                    </div>


                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Name of Unit</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblnameUnit" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Constitution of the unit</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblconstitution" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Proposal For</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblProposal" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Proposed Location</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblLocation" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Mandal</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblMandal" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Village</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblVillage" runat="server"></asp:Label></div>
                                                    </div>


                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Total Extent of Land (in sq.m)</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblExtentland" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Built up Area (Including Parking Cellars)</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblBuilt" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Sector</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblSectors" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Line of Activity</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblActivity" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Pollution Category of Enterprise</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblPollution" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Type of Industry</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblIndustry" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Location of the unit</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span>
                                                            <asp:Label ID="lblUnitLocation" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Whether land purchased from MIDCL</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblMIDCL" runat="server"></asp:Label></div>
                                                        <%-- <div class="col-md-2"><label>Type of Industry</label></div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="Label3" runat="server"></asp:Label></div>--%>
                                                    </div>





                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 600; font-size: 20px;">Project Financials</span></label>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Proposed Employment</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span>
                                                            <asp:Label ID="lblproposeEMP" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label>Value of Land as per saleDeed(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblLANDINR" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Value of Building(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblBuildingINR" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Value of Plant & Machinery(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblMachineryINR" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Expected Annual Turnover(In INR)</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblExpectTurnINR" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Total Project Cost(in Crores)</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblTPCost" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Enterprise Category</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblEnterpriseCat" runat="server"></asp:Label></div>

                                                    </div>



                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label ">
                                                            <span
                                                                style="font-weight: 600; font-size: 20px;">Project Requirements</span></label>
                                                    </div>


                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Power requirement in KW</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblPowerreq" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Generator Requirement</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblGenerator" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Height of the building(in Meters)</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblHeightBuild" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Is store RS, DS</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblRSDSstore" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Is	manufacture, store, sale, transport explosives</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblExplosive" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Is	Manufacture, store, sale, Petroleum, Diesel,Kerosene</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblPetrol" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Is require Road Cutting Permission</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblRoadcutting" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Is require Non-Encumbrance Certificate</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblEncumbrance" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Is require approval from Commerical Tax </label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span>
                                                            <asp:Label ID="lblCommericalTax" runat="server"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Is Use (High Tension)HT meter Above 70KVA</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblHT" runat="server"></asp:Label></div>
                                                        <div class="col-md-2" runat="server" visible="false" id="divHTMeter">
                                                            <label>Select Voltage</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblVoltage" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Select Power Plant </label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblPowerplant" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Aggregate Capacity</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblCapacity" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Is require Letter for distance from Forest</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblForest" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Is require Non-Forest Land Certificate </label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblNonForest" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Is there any need to Fell trees in Proposed Site</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span>
                                                            <asp:Label ID="lblFelltrees" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-md-2" runat="server" visible="false" id="divtrees">
                                                            <label>Number of trees to be felled (Girth of tree > 30 centimeters)</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblfelledtree" runat="server"></asp:Label></div>
                                                        <div class="col-md-2">
                                                            <label>Does the unit Location fall within 100mts vicinity of any water body?</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblVicinity" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-2">
                                                            <label>Do you have Existing borewell in proposed factory Location</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblborewell" runat="server"></asp:Label></div>
                                                    </div>





                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span
                                                                style="font-weight: 600; font-size: 20px;">Labour Application Type</span></label>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-10">
                                                            <label>1.  Does your Establishment employ 05 or more contract Labour as defined in the Contract Labour(Regulation and Abolition)Act, 1970?</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblRegulationLabour" runat="server"></asp:Label></div>

                                                    </div>
                                                    <div class="col-md-12 row mt-2" runat="server" visible="false" id="trworkers1970">
                                                        <div class="col-md-6">&nbsp;</div>
                                                        <div class="col-md-4">
                                                            <label>No of Workers</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblwork" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">

                                                        <div class="col-md-10">
                                                            <label>2.  Does your Establishment employ 05 or more Inter-State migrant workmen as defined in the Inter-state Migrant Workmen Act, 1979?</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblinterstate" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2" id="interwork" runat="server" visible="false">
                                                        <div class="col-md-6">&nbsp;</div>
                                                        <div class="col-md-4">
                                                            <label>No of Workers</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblInterWorker" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-10">
                                                            <label>3.  Does your Establishment fall under the definition of establishment as per Building and Other Constrution Worker(RE&COS) Act, 1996?</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblRECOS" runat="server"></asp:Label></div>

                                                    </div>
                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-10">
                                                            <label>4.  Whether your Establishment has employed or had employed on any day of the preceding 12 months, 10 or more building workers in any “Building & Other Construction Works”</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblConstruction" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2" runat="server" id="tr1996work" visible="false">
                                                        <div class="col-md-6">&nbsp;</div>
                                                        <div class="col-md-4">
                                                            <label>No of Workers</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="txt1996Workers" runat="server"></asp:Label></div>
                                                    </div>
                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-10">
                                                            <label>5.  License under Contract Labour Act (For Contractor)</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblcontractorLic" runat="server"></asp:Label></div>

                                                    </div>
                                                    <div class="col-md-12 row mt-2" runat="server" visible="false" id="trContrctworkers">
                                                        <div class="col-md-6">&nbsp;</div>
                                                        <div class="col-md-4">
                                                            <label>No of Workers</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblSector" runat="server"></asp:Label></div>
                                                    </div>

                                                    <div class="col-md-12 row mt-2">
                                                        <div class="col-md-10">
                                                            <label>6.  Does your Establishment employ 05 or more contract Labour(License for Contractors) as defined in the contract labour (Regulation and Abolition) Act,1970?</label>
                                                        </div>
                                                        <div class="col-md-2"><span class="dots">:</span><asp:Label ID="lblAbolition" runat="server"></asp:Label></div>

                                                    </div>
                                                    <div class="col-md-12 row mt-2" runat="server" visible="false" id="trcontrworkers1970">
                                                        <div class="col-md-6">&nbsp;</div>
                                                        <div class="col-md-4">
                                                            <label>No of Workers</label>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <span class="dots">:</span>
                                                            <asp:Label ID="lblwork1970" runat="server"></asp:Label>
                                                        </div>
                                                    </div>



                                                    <%--  <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 900; font-size: 20px;">Production and Sales particulars for the Last 5 Years</span></label>
                                                    </div>
                                                    <div class="table-responsive">
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
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <label class="col-lg-12 col-form-label fw-bold">
                                                            <span style="font-weight: 900; font-size: 20px;">Directors / Promoters Details</span></label>
                                                    </div>
                                                    <div class="table-responsive">
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
                                                                <asp:BoundField HeaderText="Address" DataField="ADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ControlStyle-Width="300px" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>--%>
                                                </div>
                                            </div>
                                        </div>

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
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default" id="verifypanel" runat="server" visible="true">
                            <div class="panel-heading" role="tab" id="headingSix">
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
                                        <table align="Center" style="width: 100%; border-color: brown; align-content: center;" class="table table-bordered mb-10">
                                            <tr style="border-color: brown; background-color: midnightblue; color: azure">
                                                <td><b>Name</b></td>
                                                <td><b>Unit Name</b></td>
                                                <td><b>Application No</b></td>
                                                <td style="width: 150px"><b>Application Date</b></td>
                                                <td style="width: 200px"><b>Select Action</b></td>
                                                <td id="tdquryorrej" runat="server" visible="false"><b>
                                                    <asp:Label runat="server" Text="Please Enter Query/Forward Reason" ID="lblremarks"></asp:Label></b>
                                                </td>
                                                <td id="tdaction" runat="server" visible="true">
                                                    <b>Submit Action</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" ID="lbl_Name1"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblunitname1" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblApplNo" runat="server"></asp:Label></td>
                                                <td tyle="width: 100px">
                                                    <asp:Label ID="lblapplDate" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 200px">
                                                    <asp:DropDownList ID="ddlStatus" AutoPostBack="true" runat="server" Class="form-control" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Completed" Value="12"></asp:ListItem>
                                                        <asp:ListItem Text="Completed with Payment Request" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="Raise Query" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Rejected" Value="16"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="vertical-align: central" id="tdquryorrejTxtbx" runat="server" visible="false">
                                                    <asp:TextBox ID="txtRequest" runat="server" TextMode="MultiLine" Rows="3" Columns="50" Visible="false"></asp:TextBox>
                                                    <asp:TextBox runat="server" ID="txtAdditionalAmount" Height="50px" Width="150px" onkeypress="return validateAmount(event)" Visible="false"/>
                                                </td>
                                                 

                                                <td>
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="btn btn-rounded btn-info btn-lg" BackColor="Green" />
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


    <!-- /Main Wrapper -->

    <!-- jQuery -->

</asp:Content>
