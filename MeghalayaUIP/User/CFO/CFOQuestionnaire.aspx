<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOQuestionnaire.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOQuestionnaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <style>
        .page-wrapper.tabs {
            a #ContentPlaceHolder1_Link1

        {
            background: #dce775 !important;
            padding: 10px 7px !important;
            margin: 0px 6px !important;
            color: #000 !important;
            border-radius: 22px 0px !important;
            font-weight: 500;
        }

        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Pre-Operational</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Questionnaire</li>
                </ol>
            </nav>
            <div class="page-wrapper tabs cfequestionnaire cfo">

                <div class="content container-fluid">
                    <section class="comp-section">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-header">
                                        <h4 class="card-title"><b>Questionnaire (Know Your Approvals) - For Pre Operational</b></h4>
                                        <p style="position: absolute; right: 10px; top: 6px; color: red;">
                                            *All Fields Are
										Mandatory
                                        </p>
                                    </div>
                                    <div class="card-body">

                                        <asp:HiddenField ID="hdnPreRegUNITID" runat="server" />
                                        <asp:HiddenField ID="hdnPreRegUID" runat="server" />
                                        <asp:HiddenField ID="hdnUserID" runat="server" />

                                        <%-- <ul class="nav nav-tabs">
                                    <li class="nav-item">--%>
                                        <ul class="nav nav-tabs">
                                            <li class="nav-item">
                                                <asp:LinkButton ID="Link1" class="nav-link" runat="server" OnClick="Link1_Click" Style="padding-right: 20px !important; font-size: 18px !important; margin-top: -8px !important;">
                                            1. Project Details</asp:LinkButton></li>
                                            <%-- </li>
                                    <li class="nav-item">--%>
                                            <li class="nav-item">
                                                <asp:LinkButton ID="Link2" class="nav-link" runat="server" OnClick="Link2_Click" Enabled="false" Style="padding-right: 20px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                            2. Project Financials</asp:LinkButton></li>
                                            <%-- </li>
                                    <li class="nav-item">--%>
                                            <li class="nav-item">
                                                <asp:LinkButton ID="Link3" class="nav-link" runat="server" OnClick="Link3_Click" Enabled="false" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
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
                                                            <h4 class="card-title" style="background: #abbd07; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">1. Project Details</h4>

                                                            <div class="row">
                                                                <div class="col-md-12 d-flex">
                                                                    <div class="col-md-4">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                1. Name of Unit</label>
                                                                            <div class="col-lg-6">
                                                                                <asp:TextBox ID="txtUnitName" runat="server" class="form-control" onkeypress="return Names(event)" Enabled="false" TabIndex="1"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                2.Company Type</label>
                                                                            <div class="col-lg-6">
                                                                                <asp:DropDownList ID="ddlCompanyType" runat="server" class="form-control" Enabled="false">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                3. Proposal For</label>
                                                                            <div class="col-lg-6 d-flex">
                                                                                <asp:DropDownList ID="rblProposal" runat="server" TabIndex="1" class="form-control" Enabled="false">
                                                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                                                    <asp:ListItem Value="New" Text="New"></asp:ListItem>
                                                                                    <asp:ListItem Value="Existing" Text="Existing"></asp:ListItem>
                                                                                    <asp:ListItem Value="Expansion" Text="Expansion"></asp:ListItem>
                                                                                </asp:DropDownList>
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
                                                                <h6 class="fs-20">Unit Location</h6>
                                                                <div class="col-md-12 d-flex">
                                                                    <div class="col-md-4">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                1.District
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex">
                                                                                <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                                                    <asp:ListItem Text="Select District" Value="0" />
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">2. Mandal</label>
                                                                            <div class="col-lg-6 d-flex">
                                                                                <asp:DropDownList ID="ddlMandal" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                                    <asp:ListItem Text="Select Mandal" Value="0" />
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>

                                                                    <div class="col-md-4">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">3. Village</label>
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
                                                                                4. Total
																		Extent of Land<br />
                                                                                (in sq.m)</label>
                                                                            <div class="col-lg-6 d-flex">
                                                                                <asp:TextBox ID="txtLandArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="16" TabIndex="1"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                5. Built up
																		Area (In Sq.m)</label>
                                                                            <div class="col-lg-6">
                                                                                <asp:TextBox ID="txtBuiltArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="16"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">6. Sector</label>
                                                                            <div class="col-lg-6 d-flex">
                                                                                <asp:DropDownList ID="ddlSector" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged" Enabled="false">
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
                                                                                7. Line of
																		Activity</label>
                                                                            <div class="col-lg-6">
                                                                                <asp:DropDownList ID="ddlLine_Activity" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLine_Activity_SelectedIndexChanged" Enabled="false">
                                                                                    <asp:ListItem Text="Select" Value="0" />
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                8. Pollution
																		Category of Enterprise</label>
                                                                            <div class="col-lg-6">
                                                                                <asp:Label ID="lblPCBCategory" Font-Bold="true" runat="server" class="form-control" Enabled="false"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                9. Whether land purchased from MIDCL</label>
                                                                            <div class="col-lg-6 d-flex">
                                                                                <div class="form-check form-check-inline ">
                                                                                    <asp:RadioButtonList ID="rblMIDCL" runat="server" RepeatDirection="Horizontal">
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
                                                                                10. Location
																		of the unit</label>
                                                                            <div class="col-lg-6">
                                                                                <asp:TextBox ID="txtUnitLocation" runat="server" class="form-control" onkeypress="return Names()" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>


                                                            <div class="col-md-12 d-flex mt-2" id="padding">
                                                                <div class="col-md-2">
                                                                </div>
                                                                <div class="col-md-10 text-right mb-3">
                                                                    <asp:Button runat="server" Text="Save as Draft" Visible="false" ID="btnsave1" OnClick="btnsave1_Click" class="btn btn-rounded btn-warning btn-lg" Width="150px" />


                                                                    <asp:Button ID="btnNext1" Text="Next" Visible="true" runat="server" class="btn btn-rounded btn-info btn-lg" OnClick="btnNext1_Click" Width="150px" />

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
                                                            <h4 class="card-title" style="background: #67bf02; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">2. Project Financials</h4>
                                                            <%--<form action="#">--%>
                                                            <div class="row">
                                                                <div class="col-md-12 d-flex">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                1. Proposed
																		Employment</label>
                                                                            <div class="col-lg-4">
                                                                                <asp:TextBox ID="txtPropEmp" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="7" TabIndex="1"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">2. Value of Land as per saleDeed(In INR)</label>
                                                                            <div class="col-lg-4">
                                                                                <asp:TextBox ID="txtLandValue" runat="server" class="form-control" onkeypress="return validateAmount(event)" MaxLength="16" TabIndex="1"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">3. Value of Building(In INR)</label>
                                                                            <div class="col-lg-4">
                                                                                <asp:TextBox ID="txtBuildingValue" runat="server" class="form-control" onkeypress="return validateAmount(event)" MaxLength="16" TabIndex="1"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">4. Value of Plant & Machinery(In INR)</label>
                                                                            <div class="col-lg-4">
                                                                                <asp:TextBox ID="txtPMCost" runat="server" class="form-control" onkeypress="return validateAmount(event)" MaxLength="16" TabIndex="1"></asp:TextBox>
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
                                                                                <asp:TextBox ID="txtAnnualTurnOver" runat="server" class="form-control" onkeypress="return validateAmount(event)" MaxLength="16" TabIndex="1"></asp:TextBox>
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
                                                                                <h6 class="fs-20">
                                                                                    <asp:Label ID="lblEntCategory" Text="Category" runat="server"></asp:Label>
                                                                                </h6>
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
                                                                        <asp:Button ID="btnsave2" runat="server" Text="Save as Draft" Visible="false" class="btn btn-warning btn-info btn-lg" OnClick="btnsave2_Click" Width="150px" />
                                                                        <asp:Button ID="btnNext2" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" OnClick="btnNext2_Click" Width="150px" />

                                                                    </div>
                                                                </div>

                                                            </div>

                                                            <%--</form>--%>
                                                        </div>
                                                    </div>
                                                </asp:View>
                                                <asp:View ID="viewProjReq" runat="server">
                                                    <div class="tab-pane active" id="basictab3">
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
                                                        <div class="card-body">
                                                            <span class="icon3"><i class="fi fi-br-caret-down"></i></span>
                                                            <h4 class="card-title" style="background: #4db6ac; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">3. Project Requirements</h4>
                                                            <div class="row">

                                                                <div class="col-md-12 d-flex">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                1. Do you require Registration of Migrant Workers under The Meghalaya Identification, Registration of
                                                                        Migrant Workers Act, 2020?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex">
                                                                                <asp:RadioButtonList ID="rblRegMigrantWorkers" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                2. Do you require Registration of Manufacturers / Repairers/Erectors of Boilers?</label>
                                                                            <div class="col-lg-6 d-flex">
                                                                                <asp:RadioButtonList ID="rblRegManfRepairs" runat="server" RepeatDirection="Horizontal">
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
                                                                                3. Do you require Registration of Contractors for Works and services and Renewal?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblServicesRenewal" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                4. Do you require Registration of Boiler?</label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblBoilers" runat="server" RepeatDirection="Horizontal">
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
                                                                                5. Do you require License to Work as a Factory?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblLicensetoWorkFac" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblLicensetoWorkFac_SelectedIndexChanged" AutoPostBack="true">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                6. Do you require License for contractors under the Interstate Migrant Workmen Act 1979?</label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblInterstateMigrantWorkmen" runat="server" RepeatDirection="Horizontal">
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
                                                                                7. Do you require License for Contractors under the Contract Labour Act 1970?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblContractLabourAct1970" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                8. Do you require Licence for Retail and Wholesale Drug Licence?</label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblWDruglicence" runat="server" RepeatDirection="Horizontal">
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
                                                                                9. Do you require Licence as Repairers of Weights & Measures?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblRPLicenceWeights" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                10. Do you require Licence as Manufacturer of Weights & Measures?</label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblMFLicenceWeights" runat="server" RepeatDirection="Horizontal">
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
                                                                                11. Do you require Licence as Dealers in Weights & Measures?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblLicenceDealers" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                12. Do you require Initial Verification And Stamping of Weighing and Measuring Instrument?</label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblVerificationInstrument" runat="server" RepeatDirection="Horizontal">
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
                                                                                13. Do you require Fire Safety Certificate?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblFireSafety" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                14. Do you require Excise License for Wholesale, Retail, Bottling, Distillery Plant?</label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblExciseLicenseDistillery" runat="server" RepeatDirection="Horizontal">
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
                                                                                15. Do you require Change of Constitution of Licence for Retail and Wholesale Drug licence?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblConstitutionLicenceRWD" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                16. Do you require Brand and Label Registration?</label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblBrandLabelReg" runat="server" RepeatDirection="Horizontal">
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
                                                                                17. Do you require Application For The Grant/Renewal Of License To Manufacture Drugs For Purpose Of Examination, Test Or Analysis?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblPurposeofExamination" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                18. Do you require Application For The Grant Of Loan License To Manufacture For Sale Or For Distribution Of 
                                                                        Drugs Specified In Schedule C, C (1) Excluding Those Specified In Part Xb & Schedule X?</label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblScheduleX" runat="server" RepeatDirection="Horizontal">
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
                                                                                19. Do you require Application For The Grant Of A Loan License To Manufacture For Sale Or For 
                                                                        Distribution Of Drugs Other Than That Specified In Schedule C, C(1), X?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblDrugloanlicmanfnotshedulec" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                20. Do you require Application For The Grant /Renewal Of License To Repack For Sale Or For Distribution Of Drugs Other
                                                                        Than That Specified In Schedule C, C(1) Excluding Those Specified In Schedule X?</label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblDruglicrepacksale" runat="server" RepeatDirection="Horizontal">
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
                                                                                21. Do you require Application For The Grant /Renewal Of License To Manufacture For Sale Or For
                                                                        Distribution Of Large Volume Parenterals/Sera And Vaccines Excluding Those Specified In Schedule X?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblDruglicmanfsalevaccnotshedulex" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                22. Do you require Application for Certificate of Enrollment of Professional Tax under the Meghalaya Professions
                                                                        Trades Callings and Employment Taxation Rules?</label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblProftaxcert" runat="server" RepeatDirection="Horizontal">
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
                                                                                23. Do you require CFO from pollution contorl board?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblCFOPCB" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                24. Do you require Occupancy certificate?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblOccupancyCertificate" runat="server" RepeatDirection="Horizontal">
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
                                                                                25. Do you require Boilers steam Pipeline Erection Permission Certificate from Boilers Department?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblErectionPermission" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                26. Do you require Boilers steam pipeline registration number certificate?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblPipelineCertificate" runat="server" RepeatDirection="Horizontal">
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
                                                                                27. Do you require Registration of Shops and Establishment - FORM - A?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblShpsestbregformA" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                28. Do you require Application for grant of Business License?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblBusinesssLic" runat="server" RepeatDirection="Horizontal">
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
                                                                                29. Do you require License for local sale, Import and export permit of Spirit and Indian-made foreign liquor (IMFL)?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblLiquorLic" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                30. Do you require State Excise - Excise Verification Certificate ?
                                                                            </label>
                                                                            <div class="col-lg-6 d-flex ">
                                                                                <asp:RadioButtonList ID="rblExciseVerification" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                                    <asp:ListItem Text="No" Value="N" />
                                                                                </asp:RadioButtonList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 d-flex" id="txtPower" runat="server" visible="false">
                                                                    <div class="col-md-6">
                                                                        <div class="form-group row">
                                                                            <label class="col-lg-6 col-form-label">
                                                                                Power
																		requirement in KW<span
                                                                            class="text-danger">*</span></label>
                                                                            <div class="col-lg-4">
                                                                                <asp:DropDownList ID="ddlPowerReq" runat="server" class="form-control" TabIndex="1">
                                                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>



                                                                <div class="col-md-12 d-flex mt-2" id="padding">
                                                                    <div class="col-md-2">
                                                                        <asp:Button Text="Show Approvals Required" runat="server" ID="btnApprvlsReq" class="btn btn-rounded btn-info btn-lg" OnClick="btnApprvlsReq_Click" Visible="false"></asp:Button>

                                                                    </div>
                                                                    <div class="col-md-10 text-right mb-2">
                                                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos3" class="btn btn-rounded btn-info btn-lg" OnClick="btnPreviuos3_Click" Width="150px" />
                                                                        <asp:Button ID="btnSave3" Text="Submit" runat="server" class="btn btn-rounded btn-submit btn-lg" OnClick="btnSave3_Click" Width="150px" />
                                                                        <asp:Button ID="btnNext3" runat="server" Text="Next" OnClick="btnNext3_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
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
                                        <div class="table-responsive">
                                            <asp:GridView ID="grdApprovals" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="GRD table-bordered" ForeColor="#333333" Width="100%" ShowFooter="true" OnRowDataBound="grdApprovals_RowDataBound">
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
                                                    <asp:BoundField DataField="DeptName" HeaderText="Department">
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
                                                            <asp:Label ID="lblDeptID" runat="server" Text='<%# Eval("DeptId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
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
