﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEQuestionnaire.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEQuestionnaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="page-wrapper tabs cfequestionnaire">

        <div class="content container-fluid">
            <section class="comp-section">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title"><b>Questionnaire - For Pre Establishment</b></h4>
                                <p style="position: absolute; right: 10px; top: 6px; color: red;">
                                    *All Fields Are
										Mandatory
                                </p>
                            </div>
                            <div class="card-body">
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
                                <asp:HiddenField ID="hdnPreRegUNITID" runat="server" />
                                <asp:HiddenField ID="hdnPreRegUID" runat="server" />
                                <asp:HiddenField ID="hdnUserID" runat="server" />

                                <%-- <ul class="nav nav-tabs">
                                    <li class="nav-item">--%>
                                <ul class="nav nav-tabs">
                                    <li class="nav-item">
                                        <asp:LinkButton ID="Link1" class="nav-link active" runat="server" OnClick="Link1_Click" Style="padding-right: 20px; font-size: 20px"> 
                                    1. Project Details</asp:LinkButton></li>
                                    <%-- </li>
                                    <li class="nav-item">--%>
                                    <li class="nav-item">
                                        <asp:LinkButton ID="Link2" class="nav-link" runat="server" OnClick="Link2_Click" Style="padding-right: 20px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                    2. Project Financials</asp:LinkButton></li>
                                    <%-- </li>
                                    <li class="nav-item">--%>
                                    <li class="nav-item">
                                        <asp:LinkButton ID="Link3" class="nav-link" runat="server" OnClick="Link3_Click" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                    3. Project Requirements</asp:LinkButton></li>
                                </ul>
                                <%--</li>
                                </ul>--%>
                                <%--<ul class="nav nav-tabs">
                                    <li class="nav-item" runat="server" id="Li1">
                                        <a class="nav-link  active" href="#basictab1" data-toggle="tab">1.Project Details</a>
                                    </li>
                                    <li class="nav-item" runat="server" id="Li2">
                                        <a class="nav-link" href="#basictab2" data-toggle="tab">2.
												Project Financials</a></li>
                                    <li class="nav-item" runat="server" id="Li3"><a class="nav-link" href="#basictab3"
                                        data-toggle="tab">3.
												Project Requirements</a></li>
                                </ul>--%>
                                <div class="tab-content">
                                    <asp:MultiView ID="MVQues" runat="server" OnActiveViewChanged="MVQues_ActiveViewChanged">
                                        <asp:View ID="viewProjDtls" runat="server">
                                            <div class="tab-pane active" id="basictab1">
                                                <div class="card-body">
                                                    <span class="icon"><i class="fi fi-br-caret-down"></i></span>
                                                    <h4 class="card-title" style="background: #004c6d; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">1. Project Details</h4>

                                                    <div class="row">
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        1. Name of Unit</label>
                                                                    <div class="col-lg-6">
                                                                        <asp:TextBox ID="txtUnitName" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        2.Company Type</label>
                                                                    <div class="col-lg-6">
                                                                        <asp:DropDownList ID="ddlCompanyType" runat="server" class="form-control">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        3. Proposal For</label>
                                                                    <div class="col-lg-6">
                                                                        <asp:RadioButtonList ID="rblProposal" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="New" Value="New"></asp:ListItem>
                                                                            <asp:ListItem Text="Expansion" Value="Expansion"></asp:ListItem>
                                                                        </asp:RadioButtonList>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        4. Nature of
																		Industry</label>
                                                                    <div class="col-lg-6">
                                                                        <asp:DropDownList ID="ddlIndustryType" runat="server" class="form-control">
                                                                            <%-- <asp:ListItem Text="Manufacturing" Value="Manufacturing" style="padding-right: 10px"></asp:ListItem>
                                                                    <asp:ListItem Text="Service" Value="Service"></asp:ListItem>--%>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <h5>Unit Location</h5>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        5.District
                                                                    </label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                                            <asp:ListItem Text="Select District" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">6. Mandal</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">7. Village</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                                            <asp:ListItem Text="Select Village" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        8. Total
																		Extent of Land<br />
                                                                        (in sq.m)</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:TextBox ID="txtLandArea" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        9. Built up
																		Area (In Sq.m)</label>
                                                                    <div class="col-lg-6">
                                                                        <asp:TextBox ID="txtBuiltArea" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">10. Sector</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:DropDownList ID="ddlSector" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged">
                                                                            <asp:ListItem Text="Select" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        11. Line of
																		Activity</label>
                                                                    <div class="col-lg-6">
                                                                        <asp:DropDownList ID="ddlLine_Activity" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLine_Activity_SelectedIndexChanged">
                                                                            <asp:ListItem Text="Select" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        12. Pollution
																		Category of Enterprise</label>
                                                                    <div class="col-lg-6">
                                                                        <asp:Label ID="lblPCBCategory" Font-Bold="true" runat="server" class="form-control"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        13. Whether land purchased from MIDCL</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <div class="form-check form-check-inline "> 
                                                                            <asp:RadioButtonList ID="rblMIDCL" runat="server" RepeatDirection="Horizontal"  >
                                                                                <asp:ListItem Text="Yes" Value="1" />
                                                                                <asp:ListItem Text="No" Value="2" />
                                                                            </asp:RadioButtonList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        14. Location
																		of the unit</label>
                                                                    <div class="col-lg-6">
                                                                        <asp:TextBox ID="txtUnitLocation" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-12 d-flex mt-2" id="padding">
                                                        <div class="col-md-2">
                                                        </div>
                                                        <div class="col-md-10 text-right">
                                                            <asp:Button runat="server" Text="Save as Draft" Visible="false" ID="btnsave1" OnClick="btnsave1_Click" class="btn btn-rounded btn-info btn-lg" BackColor="Green" Width="150px" />


                                                            <asp:Button ID="btnNext1" Text="Next" Visible="true" runat="server" class="btn btn-rounded btn-info btn-lg" OnClick="btnNext1_Click" BackColor="#3333ff" Width="150px" />

                                                        </div>
                                                        <%-- <a href="#basictab2" data-toggle="tab">
                                                            <button type="submit"
                                                                class="btn btn-rounded btn-info btn-lg">
                                                                Next</button></a>--%>
                                                    </div>

                                                </div>
                                            </div>
                                        </asp:View>
                                        <asp:View ID="viewProjFin" runat="server">
                                            <div class="tab-pane active" id="basictab2">
                                                <div class="card-body">
                                                    <span class="icon2"><i class="fi fi-br-caret-down"></i></span>
                                                    <h4 class="card-title" style="background: #0067b7; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">2. Project Financials</h4>
                                                    <%--<form action="#">--%>
                                                    <div class="row">
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        1. Proposed
																		Employment</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:TextBox ID="txtPropEmp" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">2. Value of Land as per saleDeed(In INR)</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:TextBox ID="txtLandValue" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">3. Value of Building(In INR)</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:TextBox ID="txtBuildingValue" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">4. Value of Plant & Machinery(In INR)</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:TextBox ID="txtPMCost" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
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

                                                        <div class="col-md-12 d-flex mt-2">
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">5. Expected Annual Turnover(In INR)</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:TextBox ID="txtAnnualTurnOver" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">6. Total Project Cost(in Crores)</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:Label ID="lblTotProjCost" Text="0.00" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex mt-2">
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        7. Enterprise Category
                                                                    </label>

                                                                    <div class="col-lg-4">
                                                                        <h4>
                                                                            <asp:Label ID="lblEntCategory" Text="Category" runat="server"></asp:Label></h4>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">&nbsp;</div>
                                                        </div>

                                                        <div class="col-md-12 d-flex mt-2" id="padding">
                                                            <div class="col-md-2">


                                                                <%--<button type="submit" class="btn btn-rounded btn-success btn-lg">Previous</button>--%>
                                                            </div>
                                                            <div class="col-md-10 text-right">
                                                                <asp:Button Text="Previous" runat="server" ID="btnPreviuos2" class="btn btn-rounded btn-info btn-lg" OnClick="btnPreviuos2_Click" Width="150px" BackColor="#009999" />
                                                                <asp:Button ID="btnsave2" runat="server" Text="Save as Draft" Visible="false" class="btn btn-rounded btn-info btn-lg" padding-right="10px" BackColor="Green" OnClick="btnsave2_Click" Width="150px" />
                                                                <asp:Button ID="btnNext2" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" OnClick="btnNext2_Click" Width="150px" BackColor="#3333ff" />

                                                            </div>
                                                        </div>

                                                    </div>

                                                    <%--</form>--%>
                                                </div>
                                            </div>
                                        </asp:View>
                                        <asp:View ID="viewProjReq" runat="server">
                                            <div class="tab-pane active" id="basictab3">
                                                <div class="card-body">
                                                    <span class="icon3"><i class="fi fi-br-caret-down"></i></span>
                                                    <h4 class="card-title" style="background: #007aff; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">3. Project Requirements</h4>
                                                    <div class="row">
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        1. Power
																		requirement in KW<span
                                                                            class="text-danger">*</span></label>
                                                                    <div class="col-lg-4">
                                                                        <asp:DropDownList ID="ddlPowerReq" runat="server" class="form-control">
                                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        2. Generator
																		Requirement</label>
                                                                    <div class="col-lg-6 d-flex ">
                                                                        <asp:RadioButtonList ID="rblGenerator" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        3. Height of the building(in Meters)</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:TextBox ID="txtBuildingHeight" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">4. Do you store RS, DS</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:RadioButtonList ID="rblRSDSstore" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                 <label class="col-lg-6 col-form-label">
                                                                        5. Do you manufacture, store, sale, transport explosives</label>
                                                                    <div class="col-lg-6 d-flex radio">
                                                                        <asp:RadioButtonList ID="rblexplosives" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        6. Do you Manufacture, store, sale, Petroleum, Diesel, Kerosene</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:RadioButtonList ID="rblPetrlManf" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">7. Do you require Road Cutting Permission</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:RadioButtonList ID="rblRoadCutting" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        8. Do you require Non-Encumbrance Certificate</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:RadioButtonList ID="rblNonEncCert" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">9. Do you require approval from Commerical Tax</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:RadioButtonList ID="rblCommericalTax" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">10. Do you Use (High Tension)HT meter Above 70KVA<span class="text-danger">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:RadioButtonList ID="rblHighTension" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblHighTension_SelectedIndexChanged">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex" runat="server" id="divHTMeter" visible="false">

                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">10a. Select Regulation</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:DropDownList ID="ddlRegulation" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRegulation_SelectedIndexChanged">
                                                                            <asp:ListItem Text="Regulation" Value="0" />
                                                                        </asp:DropDownList>
                                                                        <%-- <p>43(3)- Electrical Installation<br /> 32 - Generating Unit/Generators</p>--%>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6" runat="server" visible="false" id="divvoltages">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">10b. Select Voltage</label>
                                                                    <div class="col-lg-4 d-flex">
                                                                        <asp:DropDownList ID="ddlVoltage" runat="server" class="form-control">
                                                                            <asp:ListItem Text="Voltage" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6" runat="server" visible="false" id="divpowerplants1">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">10b. Select Power Plant</label>
                                                                    <div class="col-lg-4 d-flex">
                                                                        <asp:DropDownList ID="ddlPowerPlant" runat="server" class="form-control">
                                                                            <asp:ListItem Text="Voltage" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">10c. Aggregate Capacity:</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:TextBox ID="txtAggrCapacity" runat="server" class="form-control"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6" runat="server" visible="false" id="divpowerplants2">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">11. Do You require Letter for distance from Forest</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:RadioButtonList ID="rblfrstDistncLtr" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">12. Do you require Non-Forest Land Certificate<span class="text-danger">*</span></label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:RadioButtonList ID="rblNonForstLandCert" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        13. Is there any need to Fell trees in Proposed Site</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:RadioButtonList ID="rblFelltrees" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblFelltrees_SelectedIndexChanged">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6" runat="server" visible="false" id="divtrees">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        Number of
																		trees to be felled
                                                                         (Girth of tree > 30
																		centimeters)</label>
                                                                    <div class="col-lg-4">
                                                                        <asp:TextBox ID="txtNoofTrees" runat="server" class="form-control"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                            </div>



                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-11">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">14. Does the unit Location fall within 100mts vicinity of any water body?</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <asp:RadioButtonList ID="rblwaterbody" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-11">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">
                                                                        15. Do you have Existing borewell in proposed factory Location</label>
                                                                    <div class="col-lg-6 ">
                                                                        <asp:RadioButtonList ID="rblborewell" runat="server" RepeatDirection="Horizontal">
                                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                                            <asp:ListItem Text="No" Value="N" />
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="table labertype mb-3">
                                                            <table class="table">
                                                                <thead>
                                                                    <tr>
                                                                        <th colspan="3" style="margin: 0px !important; padding: 3px 14px !important;">16. Labour Application Type</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <td>16 a.</td>
                                                                        <td>Does your Establishment employ 05 or more contract Labour as defined in the
                                                                       
                                                                    Contract Labour(Regulation and Abolition)Act, 1970?</td>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rblLbrAct1970" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLbrAct1970_SelectedIndexChanged">
                                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                                <asp:ListItem Text="No" Value="N" />
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" visible="false" id="trworkers1970">
                                                                        <td></td>
                                                                        <td align="right">No of Workers</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt1970Workers" runat="server" class="form-control"></asp:TextBox>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td>16 b.</td>
                                                                        <td>Does your Establishment employ 05 or more Inter-State migrant workmen as defined
                                                                    in the Inter-state Migrant Workmen Act, 1979?</td>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rblLbrAct1979" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLbrAct1979_SelectedIndexChanged">
                                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                                <asp:ListItem Text="No" Value="N" />
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" visible="false" id="trworkers1979">
                                                                        <td></td>
                                                                        <td align="right">No of Workers</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt1979Workers" runat="server" class="form-control"></asp:TextBox></td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td>16 c.</td>
                                                                        <td>Does your Establishment fall under the definition of establishment as per Building
                                                                    and Other Constrution Worker(RE&COS) Act, 1996?</td>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rblLbrAct1996" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLbrAct1996_SelectedIndexChanged">
                                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                                <asp:ListItem Text="No" Value="N" />
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" visible="false" id="tr1workers1996">
                                                                        <td></td>
                                                                        <td>Whether your Establishment has employed or had employed on any day of the preceding
                                                                        <br />
                                                                            12 months, 10 or more building workers in any “Building & Other Construction Works”</td>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rblbuildingwork" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblbuildingwork_SelectedIndexChanged">
                                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                                <asp:ListItem Text="No" Value="N" />
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" visible="false" id="tr2workers1996">
                                                                        <td></td>
                                                                        <td align="right">No of Workers</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt1996Workers" runat="server" class="form-control"></asp:TextBox></td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td>16 d.</td>
                                                                        <td>License under Contract Labour Act (For Contractor)
                                                                        <br />
                                                                        </td>
                                                                        <td>
                                                                            <asp:RadioButtonList Style="border: none" ID="rblLabourAct" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLabourAct_SelectedIndexChanged">
                                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                                <asp:ListItem Text="No" Value="N" />
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" visible="false" id="trContrctworkers">
                                                                        <td></td>
                                                                        <td align="right">No of Workers</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtContractWorkers" runat="server" class="form-control"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>16 e.</td>
                                                                        <td>Does your Establishment employ 05 or more contract Labour(License for Contractors) as defined in the contract labour
                                                                    <br />
                                                                            (Regulation and Abolition) Act,1970? 
                                                                        <br />
                                                                        </td>
                                                                        <td>
                                                                            <asp:RadioButtonList Style="border: none" ID="rblForContr1970" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblForContr1970_SelectedIndexChanged">
                                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                                <asp:ListItem Text="No" Value="N" />
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" visible="false" id="trcontrworkers1970">
                                                                        <td></td>
                                                                        <td align="right">No of Workers</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtContr1970wrkrs" runat="server" class="form-control"></asp:TextBox></td>
                                                                    </tr>

                                                                </tbody>



                                                            </table>
                                                        </div>

                                                        <div class="col-md-12 d-flex mt-2" id="padding">
                                                            <div class="col-md-2">
                                                                <asp:Button Text="Show Approvals Required" runat="server" ID="btnApprvlsReq" class="btn btn-rounded btn-info btn-lg" OnClick="btnApprvlsReq_Click" Visible="false"></asp:Button>

                                                            </div>
                                                            <div class="col-md-10 text-right">
                                                                <asp:Button Text="Previous" runat="server" ID="btnPreviuos3" class="btn btn-rounded btn-info btn-lg" OnClick="btnPreviuos3_Click" BackColor="#009999" Width="150px" />
                                                                <asp:Button ID="btnSave3" Text="Submit" runat="server" class="btn btn-rounded btn-info btn-lg" OnClick="btnSave3_Click" BackColor="Green" Width="150px" />

                                                            </div>

                                                        </div>

                                                    </div>



                                                </div>
                                            </div>
                                        </asp:View>
                                    </asp:MultiView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row" runat="server" visible="false" id="divApprovals">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title"><b>Details of Approvals with Fee (in Rs.)</b></h4>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="grdApprovals" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    CssClass="GRD" ForeColor="#333333" Width="90%" ShowFooter="true" OnRowDataBound="grdApprovals_RowDataBound">
                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required ">
                                            <ItemStyle Width="450px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TMD_DeptName" HeaderText="Department">
                                            <ItemStyle Width="180px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FEE" FooterStyle-HorizontalAlign="Right" HeaderText="Fees (Rs.)">
                                            <FooterStyle CssClass="GRDITEM2" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle CssClass="GRDITEM2" Width="150px" HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Approval ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApprID" runat="server" Text='<%# Eval("ApprovalID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Dept ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDeptID" runat="server" Text='<%# Eval("TMD_DEPTID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </section>




        </div>
    </div>
</asp:Content>