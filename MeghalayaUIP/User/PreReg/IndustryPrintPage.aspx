<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="IndustryPrintPage.aspx.cs" Inherits="MeghalayaUIP.User.PreReg.IndustryPrintPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper" style="">
        <div class="content container-fluid">
            <div class="main-wrapper">

                <!-- Header -->
                <div class="header">

                    <!-- Logo -->
                    <div class="header-left">
                        <a href="index.html" class="logo">
                            <img src="assets/admin/img/logo.png" alt="Logo">
                        </a>
                        <a href="index.html" class="logo logo-small">
                            <img src="assets/admin/img/logo-small.png" alt="Logo" width="30" height="30">
                        </a>
                    </div>
                    <!-- /Logo -->

                    <h4 class="ml-3 mt-3">Industry Print Page</h4>



                    <!-- Mobile Menu Toggle -->

                    <!-- /Mobile Menu Toggle -->

                    <!-- Header Right Menu -->

                    <!-- /Header Right Menu -->

                </div>
                <!-- /Header -->

                <!-- Sidebar -->

                <!-- /Sidebar -->

                <!-- Page Wrapper -->
                <div id="bodypart">
                    <div class="row">
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
                        <asp:HiddenField ID="hdnUserID" runat="server" />
                        <div class="col-xl-8 col-sm-12 col-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="col-md-12">
                                        <h5>Basic Details</h5>
                                        <hr />
                                    </div>
                                    <div class="col-md-12 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Company PAN card No:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblPANNo" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Company Proposal:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblproposal" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Company Registration:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblRegistration" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Udyam/IEM No:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblUdyam" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">GSTIN Number:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblGSTNumber" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card">
                                <div class="card-body">
                                    <div class="col-md-12">
                                        <h5>Correspodence Details of Authorised Representative</h5>
                                        <hr />
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Name:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblName" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">E-mail:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblEmail" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Locality:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lbllocality" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">District:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lbldistic" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Mandal:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblMandal" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Village:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblVillage" runat="server"></asp:Label></div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Pincode:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblPincode" runat="server"></asp:Label></div>
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-xl-8 col-sm-12 col-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="col-md-12">
                                        <h5>Proposed Location of Unit</h5>
                                        <hr />
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Is Land Required:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblLand" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Door No:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblDoor" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Locality:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblLocal" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">District:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lbldist" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Taluka:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lbltaluka" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Village:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblvilla" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Pin Code:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblPIN" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-8 col-sm-12 col-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="col-md-12">
                                        <h5>Project Details</h5>
                                        <hr />
                                    </div>
                                    <div class="col-md-12 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Date of Commencement of Production /Operation::</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblDate" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Nature of Activity:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblActivity" runat="server"></asp:Label></div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Main Manufacturing Activity:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblManufacture" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Product to be Manufactured:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lbProductManf" runat="server"></asp:Label></div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Main Service Activity:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblMainActivity" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Service to be Provided:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblProvided" runat="server"></asp:Label></div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">If Existing – Production no./ Service No:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblExisting" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Sector:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblSector" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Line Of Activity:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblLineActivity" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Pollution Cataegory:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblPCB" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Main Raw Materials for the Proposed Project:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblRawMaterial" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Details of Waste / Effluent to be generated:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblgenerated" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Details of Hazardous Waste to be generated:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="Label1" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Details of Waste / Effluent to be generated:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblHazardous" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Civil Construction:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblCivil" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Land Area (in Sq.ft):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblLandarea" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Area of Building / Shed (Sq. m):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblBuilding" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Water required (KL/D):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblWater" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Power Required (KV):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblPower" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Unit of Measurement:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblMeasurement" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Annual Capacity:</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblCapacity" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Estimated Project Cost (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblProjectCost" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Plant & Machinery (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblPlantMach" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Investment in Fixed Capital (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblInvestment" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Durable Fixed Assets (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblFixedassets" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Value of Land (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblValueLand" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Value of Building / Shed (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblBuildingshed" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Value of Water (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblvaluewater" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mb-4 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Value of Electricity (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblElectricity" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Working Capital (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblworkingCapital" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Capital Subsidy (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblCapitalsub" runat="server"></asp:Label></div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xl-8 col-sm-12 col-12">
                            <div class="card">
                                <div class="card-body">
                                    <div class="col-md-12">
                                        <h5>Finance Revenue Details</h5>
                                        <hr />
                                    </div>
                                    <div class="col-md-12 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Capital Subsidy/ Benefit from UNNATI/ other Central / State Scheme (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblExpectation" runat="server"></asp:Label></div>
                                        </div>
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Promoter’s Equity (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblPromoters" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex tablepadding">
                                        <div class="col-md-6 d-flex">
                                            <div class="col-md-6">Loan Amount (INR):</div>
                                            <div class="col-md-6">
                                                <asp:Label ID="lblLoanAmount" runat="server"></asp:Label></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-8 col-sm-12 col-12">
                            <div class="card">
                                <div class="card-body">
                                    <div align="center">
                                        <asp:GridView ID="GrdYear" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                            Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Item Description" Visible="true" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="left">
                                                    <ItemTemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                        <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ITEMS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="YEAR1" HeaderText="Year1" />
                                                <asp:BoundField DataField="YEAR2" HeaderText="Year2" />
                                                <asp:BoundField DataField="YEAR3" HeaderText="Year3" />
                                                <asp:BoundField DataField="YEAR4" HeaderText="Year4" />
                                                <asp:BoundField DataField="YEAR5" HeaderText="Year5" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xl-8 col-sm-12 col-12">
                            <div class="card">
                                <div class="card-body">
                                    <div align="center">
                                        <asp:GridView ID="Gridviewname" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                                            Font-Size="12px" SkinID="gridviewSkin" Width="800px">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Item Description" Visible="true" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="left">
                                                    <ItemTemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                        <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ITEMS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="NAME" HeaderText="NAME" />
                                                <asp:BoundField DataField="IDD_ADNO" HeaderText="AADHAR No" />
                                                <asp:BoundField DataField="IDD_PAN" HeaderText="PAN" />
                                                <asp:BoundField DataField="IDD_DINNO" HeaderText="DIN No" />
                                                <asp:BoundField DataField="IDD_NATIONALITY" HeaderText="Nationality" />
                                                <asp:BoundField DataField="ADDRESS" HeaderText="Address" />
                                                <asp:BoundField DataField="IDD_EMAIL" HeaderText="E-mail ID" />
                                                <asp:BoundField DataField="IDD_PHONE" HeaderText="Phone" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
                <!-- /Page Wrapper -->
                <br />
                <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                    type="button" value="Print" /><br />
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="~/Home.aspx"
                    ForeColor="#3366CC">Home</asp:HyperLink>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
