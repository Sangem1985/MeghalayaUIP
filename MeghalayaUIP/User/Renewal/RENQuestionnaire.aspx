<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENQuestionnaire.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENQuestionnaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Renewals</a></li>
            <li class="breadcrumb-item active" aria-current="page">Common Details</li>
        </ol>
    </nav>
    <div class="page-wrapper tabs cfequestionnaire">

        <div class="content container-fluid">
            <section class="comp-section">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title"><b>Renewal </b></h4>
                                <p style="position: absolute; right: 10px; top: 6px; color: red;">
                                    *All Fields Are
										Mandatory
                                </p>

                            </div>

                            <div class="card-body">
                                <asp:HiddenField ID="hdnPreRegUNITID" runat="server" />
                                <asp:HiddenField ID="hdnPreRegUID" runat="server" />
                                <asp:HiddenField ID="hdnUserID" runat="server" />
                                <div class="tab-content">

                                    <div class="card-body">

                                        <div class="row">

                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3">Unit Details: </h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            1. Name of Unit</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtUnitName" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            2.Company Type</label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="ddlCompanyType" runat="server" class="form-control" onkeypress="return Names()">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            3. Nature of
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
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            4. Category of
												Registration*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlRegType" runat="server" class="form-control">
                                                                <asp:ListItem Text="Select Category" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5. Sector</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlSector" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged">
                                                                <asp:ListItem Text="Select" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            6. Line of
																Activity</label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="ddlLine_Activity" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLine_Activity_SelectedIndexChanged">
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
                                                            7. Survey Number</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtSurveyNumber" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            8. Locality</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtUnitLocation" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            9.District
                                                        </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                                <asp:ListItem Text="Select District" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">10. Mandal</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                <asp:ListItem Text="Select Mandal" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">11. Village</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                                <asp:ListItem Text="Select Village" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">12. Pincode</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtUnitPincode" runat="server" class="form-control" onkeypress="return validatePincode(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            13. Total
																		Extent of Land<br />
                                                            (in sq.m)</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLandArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            14. Built up
																		Area (In Sq.m)</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtBuiltArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex" runat="server" visible="false">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            15. Pollution
																		Category of Enterprise</label>
                                                        <div class="col-lg-6">
                                                            <asp:Label ID="lblPCBCategory" Font-Bold="true" runat="server" class="form-control"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            16. Whether land purchased from MIDCL</label>
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

                                            <div class="col-md-12 d-flex" runat="server" visible="false">
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3">Authorised Representative Details: </h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            1. Name
                                                        </label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPromoterName" runat="server" class="form-control" onkeypress="return validateNames(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            2.
														S/o.D/o.W/o</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtSoWoDo" runat="server" class="form-control" onkeypress="return validateNames(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Email</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" onblur="validateEmail(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Mobile No</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtMobileno" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            5. Alternative Mobile
														No*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtAltMobile" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            6. Landline Tel No
                                               
                                                        </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLandlineno" runat="server" class="form-control" onblur="validatePhoneNumber(input_str)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">7. Door No</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtDoorNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">8. Locality</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLocality" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">9. District</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlDistric" runat="server" class="form-control" AutoPostBack="true">
                                                                <asp:ListItem Text="Select Distric" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>

                                            <div class="col-md-12 d-flex">

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">10. Mandal</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" AutoPostBack="true">
                                                                <asp:ListItem Text="Select Mandal" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">11. Village/Town</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                                                <asp:ListItem Text="Select Village" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">12. Pincode</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtpincode" runat="server" class="form-control" onkeypress="return validatePincode(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12  d-flex">

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            13. Women
														Entrepreneur</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:RadioButtonList ID="rblWomen" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            14. Differently
														Abled*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:RadioButtonList ID="rblAbled" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <h4 class="card-title ml-3">Employment Details: </h4>
                                            <%-- <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6">(Total Employee-Direct:</label>
                                                    <div>
                                                        <asp:Label ID="lbltotalEmp" runat="server" value="40" CssClass="font-weight-600"> </asp:Label>)
                                                    </div>
                                                </div>
                                            </div>--%>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Direct Male</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtMale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2.Direct Female</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtFemale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Direct Other Employee</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtDirectOthers" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Indirect Male</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtIndirectMale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5. Indirect Female</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtIndirectFemale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">6. Indirect Other Employee</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtInDirectOthers" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">7. Total Employment</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="TextBox1" runat="server" class="form-control" ReadOnly="true" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3">Project Financials: </h4>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Value of Land as per saleDeed(In INR)</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtLandValue" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Value of Building(In INR)</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtBuildingValue" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Value of Plant & Machinery(In INR)</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPMCost" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Expected Annual Turnover(In INR)</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtAnnualTurnOver" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5. Total Project Cost(INR)</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtTotProjCost" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            6. Enterprise Category
                                                        </label>
                                                        <div class="col-lg-6">
                                                            <h5>
                                                                <asp:Label ID="lblEntCategory" Text="Category" runat="server"></asp:Label></h5>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex mt-2">

                                                <div class="col-md-6">&nbsp;</div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex mt-2 mb-2" id="padding">
                                            <div class="col-md-2">
                                            </div>
                                            <div class="col-md-10 text-right">
                                                <asp:Button runat="server" Text="Save as Draft" Visible="false" ID="btnSave" OnClick="btnSave_Click" class="btn btn-rounded btn-success btn-lg" Width="150px" />


                                                <asp:Button ID="btnNext" Text="Next" Visible="true" runat="server" class="btn btn-rounded btn-info btn-lg" OnClick="btnNext_Click" Width="150px" />

                                            </div>

                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>



            </section>
        </div>
    </div>
</asp:Content>
