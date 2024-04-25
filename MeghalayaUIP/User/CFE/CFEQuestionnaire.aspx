<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEQuestionnaire.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEQuestionnaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">

        <div class="content container-fluid">



            <section class="comp-section">

                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Questionnaire - Consent for Establishment</h4>
                                <p style="position: absolute; right: 10px; top: 6px; color: red;">
                                    *All Fields Are
										Mandatory
                                </p>
                            </div>
                            <div class="card-body">
                                <asp:HiddenField ID="hdnUserID" runat="server" />
                                <ul class="nav nav-tabs">
                                    <li class="nav-item"><a class="nav-link  active" href="#basictab1" data-toggle="tab">1.
												Project Details</a></li>
                                    <li class="nav-item"><a class="nav-link" href="#basictab2" data-toggle="tab">2.
												Project Financials</a></li>
                                    <li class="nav-item"><a class="nav-link" href="#basictab3"
                                        data-toggle="tab">3.
												Project Requirements</a></li>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane show active" id="basictab1">
                                        <div class="card-body">
                                            <h4 class="card-title">1. Project Details</h4>

                                            <div class="row">
                                                <div class="col-md-12 d-flex" id="padding">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                1. Name of
																		Unit</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="Name_Unit" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                2.
																		Constitution of the unit</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="Constit_Unit" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                Proposal For</label>
                                                            <div class="col-lg-6">
                                                                <asp:DropDownList ID="ddlProposal" runat="server" class="form-control">
                                                                    <asp:ListItem Text="Select" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-md-12 d-flex" id="padding">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-9 col-form-label">
                                                                3. Whether
																		land purchased from MIDCL</label>
                                                            <div class="col-lg-3 d-flex">
                                                                <div class="form-check form-check-inline">
                                                                    <asp:RadioButtonList ID="rblTSIIC" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                        <asp:ListItem Text="No" Value="2" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-12 d-flex" id="padding">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                4. Proposed
																		Location</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:DropDownList ID="ddlLocation" runat="server" class="form-control" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Select District" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Mandal</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Select Mandal" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Village</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                                    <asp:ListItem Text="Select Village" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-12 d-flex" id="padding">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                5. Total
																		Extent of Land</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:DropDownList ID="ddlLand" runat="server" class="form-control">
                                                                    <asp:ListItem Text="Select" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Acres</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="Acres" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label
                                                                class="col-lg-6 col-form-label">
                                                                Gunthas</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="Gunthas" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 d-flex" id="padding">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                In Square
																		Meters (in Sq.ft)</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="Square_Meters" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                6. Built up
																		Area (Including Parking Cellars)</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="Built_Area" runat="server" class="form-control"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                7. Pollution
																		Category of Enterprise</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="Pollution_Category" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 d-flex" id="padding">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                8. Line of
																		Activity</label>
                                                            <div class="col-lg-6">
                                                                <asp:DropDownList ID="ddlLine_Activity" runat="server" class="form-control" OnSelectedIndexChanged="ddlLine_Activity_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Select" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                9. Type of
																		Enterprise</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="Type_Enterprise" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                10. Location
																		of the unit</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="Location_Unit" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex" id="padding">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Sector</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:DropDownList ID="ddlSector" runat="server" class="form-control" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Select" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="text-right">
                                                <a href="#basictab2" data-toggle="tab">
                                                    <button type="submit"
                                                        class="btn btn-rounded btn-info btn-lg">
                                                        Next</button></a>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="tab-pane" id="basictab2">
                                        <div class="card-body">
                                            <h4 class="card-title">2. Project Financials</h4>
                                            <form action="#">
                                                <div class="row">
                                                    <div class="col-md-12 d-flex" id="padding">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    11. Proposed
																		Employment</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtProposed" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    13.
																		Project Cost</label>
                                                                <div class="col-lg-6">
                                                                    <asp:DropDownList ID="ddlProjectCost" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Select" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">14.Value of Land as per saleDeed(In INR)</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtLandsale" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex" id="padding">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">15.Value of Building(In INR)</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtbuilding" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">16.Value of Plant & Machinery(In INR)</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtplant" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">17.Expected Annual Turnover(In INR)</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtAnnualTurn" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>


                                                    <div class="table-responsive" id="Mention_Zero" runat="server" visible="false">
                                                        <table class="table table-bordered mb-0">
                                                            <thead>
                                                                <tr>

                                                                    <th colspan="2">(Mention Zero in case of leased
																			premises)</th>
                                                                    <th>New Investment</th>

                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td rowspan="3">a.</td>
                                                                    <td>Value of Land as per saleDeed</td>
                                                                    <td>
                                                                        <input type="text" class="form-control"
                                                                            value="0"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>In Rs. Lakhs</td>
                                                                    <td>
                                                                        <input type="text" class="form-control"
                                                                            value="0" disabled></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Land Market Value as Per SRO for (14062.37
																			Square Meter)</td>
                                                                    <td>
                                                                        <input type="text" class="form-control"
                                                                            value="20000000.00">
                                                                        <button type="button"
                                                                            class="btn btn-warning mt-1">
                                                                            <i
                                                                                class="fa fa-inr"
                                                                                aria-hidden="true"></i>Click Here
																				to Calculate Market Value as Per
																				SRO</button>
                                                                    </td>

                                                                </tr>

                                                                <tr>
                                                                    <td rowspan="2">b.</td>
                                                                    <td>Value of Building<span
                                                                        class="text-danger">*</span></td>
                                                                    <td>
                                                                        <input type="text" class="form-control"
                                                                            value="0"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>In Rs. Lakhs</td>
                                                                    <td>
                                                                        <input type="text" class="form-control"
                                                                            value="0" disabled></td>
                                                                </tr>

                                                                <tr>
                                                                    <td rowspan="2">c.</td>
                                                                    <td>Value of Plant & Machinery or Service
																			Equipment<span class="text-danger">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <input type="text" class="form-control"
                                                                            value="0"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>In Rs. Lakhs</td>
                                                                    <td>
                                                                        <input type="text" class="form-control"
                                                                            value="0" disabled></td>
                                                                </tr>

                                                                <tr>
                                                                    <td rowspan="2">d.</td>
                                                                    <td>Expected Annual Turnover<span
                                                                        class="text-danger">*</span></td>
                                                                    <td>
                                                                        <input type="text" class="form-control"
                                                                            value="70000000"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>In Rs. Lakhs</td>
                                                                    <td>
                                                                        <input type="text" class="form-control"
                                                                            value="700.00000" disabled></td>
                                                                </tr>
                                                                <thead>
                                                                    <tr>

                                                                        <th colspan="2">Total Project Cost(in
																				Lakhs)<span class="text-danger">*</span>
                                                                        </th>
                                                                        <th>0</th>

                                                                    </tr>
                                                                </thead>

                                                            </tbody>
                                                        </table>
                                                    </div>

                                                    <div class="col-md-12 d-flex mt-2" id="padding">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Total Project Cost(in INR)</label>
                                                                <div class="col-lg-6">
                                                                    <asp:Label ID="lbllabel" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Category
																		enterprise</label>
                                                                <div class="col-lg-3">:</div>
                                                                <div class="col-lg-3">
                                                                    <h4>Small</h4>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">&nbsp;</div>
                                                    </div>

                                                    <div class="col-md-12 d-flex mt-2" id="padding">
                                                        <div class="col-md-6">
                                                            <a href="#basictab1" data-toggle="tab">
                                                                <button type="submit"
                                                                    class="btn btn-rounded btn-success btn-lg">
                                                                    Previous</button></a>
                                                        </div>
                                                        <div class="col-md-6 text-right">
                                                            <a href="#basictab3" data-toggle="tab">
                                                                <button type="submit"
                                                                    class="btn btn-rounded btn-info btn-lg">
                                                                    Next</button></a>
                                                        </div>
                                                    </div>

                                                </div>

                                            </form>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="basictab3">
                                        <div class="card-body">
                                            <h4 class="card-title">3. Project Requirements</h4>
                                            <form action="#">
                                                <div class="row">
                                                    <div class="table-responsive mb-3">
                                                        <table
                                                            class="table table table-bordered table-striped mb-0">
                                                            <thead>
                                                                <tr class="table-primary">
                                                                    <th>Sl. No.</th>
                                                                    <th>Select</th>
                                                                    <th>Water required from</th>
                                                                    <th>Water Required per day( in KLD)</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td>1</td>
                                                                    <td>
                                                                        <input class="checkbox" type="checkbox"
                                                                            name="checkbox"></td>
                                                                    <td>HMWS & SB</td>
                                                                    <td>
                                                                        <asp:TextBox ID="HMWS" runat="server" class="form-control"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2</td>
                                                                    <td>
                                                                        <input class="checkbox" type="checkbox"
                                                                            name="checkbox"></td>
                                                                    <td>Rivers/Canals</td>
                                                                    <td>
                                                                        <asp:TextBox ID="Rivers" runat="server" class="form-control"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>3</td>
                                                                    <td>
                                                                        <input class="checkbox" type="checkbox"
                                                                            name="checkbox"></td>
                                                                    <td>CDMA</td>
                                                                    <td>
                                                                        <asp:TextBox ID="CDMA" runat="server" class="form-control"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>4</td>
                                                                    <td>
                                                                        <input class="checkbox" type="checkbox"
                                                                            name="checkbox"></td>
                                                                    <td>Mission Bhagiratha</td>
                                                                    <td>
                                                                        <asp:TextBox ID="MissionBhagiratha" runat="server" class="form-control"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <div class="col-md-12 d-flex" id="padding">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    14. Power
																		requirement in HP<span
                                                                            class="text-danger">*</span></label>
                                                                <div class="col-lg-6">
                                                                    <asp:DropDownList ID="ddlPowerHP" runat="server" class="form-control">
                                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    15(a). Do you
																		manufacture, store, sale, transport
																		explosives</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rblexplosives" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                        <asp:ListItem Text="No" Value="2" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    16. Do you
																		have Existing borewell in proposed factory
																		Location</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rblborewell" runat="server" RepeatDirection="Horizontal" Width="210px">
                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                        <asp:ListItem Text="No" Value="2" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex" id="padding">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    15(b). Do you
																		Manufacture, store, sale, Petroleum, Diesel,
																		Kerosene</label>
                                                                <div class="col-lg-4 d-flex">
                                                                    <asp:RadioButtonList ID="rblManufacture" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                        <asp:ListItem Text="No" Value="2" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    17. Generator
																		Requirement</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rblGenerator" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                        <asp:ListItem Text="No" Value="2" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    18. Height of
																		the building(in Meters)</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtHeight" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>





                                                    <div class="col-md-12 d-flex" id="padding">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    19. Is there
																		any need to Fell trees in Proposed Site</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rblFelltrees" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Number of
																		trees to be felled (Girth of tree > 30
																		centimeters)</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txttree" runat="server" class="form-control"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Are there any
																		trees in Non-Exempted (Other than trees in this
																		List )</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rbltrees" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                        <asp:ListItem Text="No" Value="2" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="table-responsive mb-3">
                                                        <table class="table table-bordered mb-0">
                                                            <thead>
                                                                <tr>
                                                                    <th colspan="3" style="margin: 0px !important; padding: 3px 14px !important;">20. Labour Application Type</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td rowspan="2">20 a.</td>
                                                                    <td>Does your establishment employ 05 or more contract Labour as defined in the
                                                                        <br />
                                                                        Contract Labour(Regulation and Abolition)Act, 1970?</td>
                                                                    <td>
                                                                        <asp:RadioButtonList ID="rblContractLabour" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                            <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>No of Workers</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtWorker" runat="server" class="form-control"></asp:TextBox></td>
                                                                </tr>

                                                                <tr>
                                                                    <td rowspan="2">20 b.</td>
                                                                    <td>Does your establishment employ 05 or more Inter-State migrant workmen as defined<br />
                                                                        in the Inter-state Migrant Workmen Act, 1979?</td>
                                                                    <td>
                                                                        <asp:RadioButtonList ID="rblstateMigrant" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                            <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>No of Workers</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtmigrantwork" runat="server" class="form-control"></asp:TextBox></td>
                                                                </tr>

                                                                <tr>
                                                                    <td rowspan="3">20 c.</td>
                                                                    <td>Does your establishment fall under the definition of establishment as per Building<br />
                                                                        and Other Constrution Worker(RE&COS) Act, 1996?</td>
                                                                    <td>
                                                                        <asp:RadioButtonList ID="rblRECOS" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                            <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>

                                                                    <td>Whether your establishment has employed or had employed on any day of the preceding
                                                                        <br />
                                                                        12 months, 10 or more building workers in any “Building & Other Construction Works”</td>
                                                                    <td>
                                                                        <asp:RadioButtonList ID="rblbuildingwork" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
                                                                            <asp:ListItem Value="N">No</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>No of Workers</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtemployedwork" runat="server" class="form-control"></asp:TextBox></td>
                                                                </tr>

                                                                <tr>
                                                                    <td rowspan="2">20 d.</td>
                                                                    <td>Does your establishment provide 05 or more inter-state migrant workmen on contractual basis as
                                                                        <br />
                                                                        defined in the Inter-state Migrant Workmen Act, 1979?(for Contractor)</td>
                                                                    <td>
                                                                        <asp:RadioButtonList ID="rblworkmen" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                            <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>No of Workers</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtmigrantworkmen" runat="server" class="form-control"></asp:TextBox></td>
                                                                </tr>

                                                                <tr>
                                                                    <td rowspan="1">20 e.</td>
                                                                    <td>Does your establishment employ 05 or more contract labour(License for contractors) as defined
                                                                        <br />
                                                                        in the contract labour(Regulation and Abolition) act, 1970?</td>
                                                                    <td>
                                                                        <asp:RadioButtonList ID="rblRegulationRegulation" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="1" />
                                                                            <asp:ListItem Text="No" Value="2" />
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>


                                                            </tbody>



                                                        </table>
                                                    </div>


                                                    <div class="col-md-12 d-flex" id="padding">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">21. Does the unit Location fall within 100mts vicinity of any water body?</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rblwaterbody" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                        <asp:ListItem Text="No" Value="2" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">22. Do you require approval from Commerical Tax</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rblCommericalTax" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                        <asp:ListItem Text="No" Value="2" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">23. DO you Use (High Tension)HT meter Above 70KVA<span class="text-danger">*</span></label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rblHighTension" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex" id="padding">

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Regulation</label>
                                                                <div class="col-lg-6">

                                                                    <asp:DropDownList ID="ddlRegulation" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Regulation" Value="0" />
                                                                    </asp:DropDownList>
                                                                    <p>43(3)- Electrical Installation/ 32 - Generating Unit/Generators</p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Voltage</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlvtg" runat="server" class="form-control">
                                                                        <asp:ListItem Text="Voltage" Value="0" />
                                                                    </asp:DropDownList>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Aggregate Capacity</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtCapacity" runat="server" class="form-control"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 d-flex" id="padding">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">24. Do you store RS, DS</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rblstore" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="1" />
                                                                        <asp:ListItem Text="No" Value="2" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            &nbsp;
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 d-flex text-center" id="padding">
                                                        <div class="col-md-4">
                                                            <a href="#basictab2">
                                                                <button type="submit" class="btn btn-rounded btn-success1 btn-lg"><span class="spinner-border spinner-border-sm mr-2 mb-1" role="status"></span>Show Approvals Required</button></a>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <a href="#basictab2">
                                                                <button type="submit" class="btn btn-rounded btn-success1 btn-lg"><span class="spinner-border spinner-border-sm mr-2 mb-1" role="status"></span>Submit Questionnaire</button></a>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <a href="#basictab2">
                                                                <button type="submit" class="btn btn-rounded btn-success2 btn-lg">Show Enclousers List</button></a>
                                                        </div>


                                                    </div>

                                                    <div class="col-md-12 d-flex mt-4" id="padding">
                                                        <div class="col-md-6">
                                                            <a href="#basictab2" data-toggle="tab">
                                                                <button type="submit"
                                                                    class="btn btn-rounded btn-success btn-lg">
                                                                    Previous</button></a>
                                                        </div>

                                                    </div>

                                                </div>



                                            </form>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Fee Details(in Rs.)</h4>
                            </div>
                            <div class="card-body">
                                <div class="table-responsive">
                                    <table class="table table-hover table-bordered mb-0">
                                        <thead>
                                            <tr>
                                                <th>S No</th>
                                                <th>Approval Required</th>
                                                <th>Department</th>
                                                <th>Fees (Rs.)</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1</td>
                                                <td>SERVICE CONNECTION CERTIFICATE FROM TSNPDCL</td>
                                                <td>TSNPDCL</td>
                                                <td>0</td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <td>PERMISSION FROM GROUND WATER DEPARTMENT TO DIG BORE WELL</td>
                                                <td>GROUND WATER</td>
                                                <td>14,500</td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <td>PROVISIONAL NOC FROM FIRE SERVICES DEPARTMENT</td>
                                                <td>FIRE</td>
                                                <td>50,000</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </section>




        </div>
    </div>
</asp:Content>
