<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="BMWDetails.aspx.cs" Inherits="MeghalayaUIP.User.Services.BMWDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .tableBMW {
            width: 70%;
        }

        input[type=checkbox], input[type=radio] {
            box-sizing: border-box;
            padding: 6px 0px !important;
            margin: 0px 3px !important;
        }
        .auto-style1 {
            display: block;
            width: 100%;
            height: 35px;
            font-size: 14px;
            font-weight: 400;
            line-height: 1.5;
            color: #333;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            box-shadow: none;
            border: 1px solid #ced4da;
            background-color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a>Services</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Bio-Medical Waste Management</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" runat="server" id="divText">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Application for Authorization Under Bio-Medical Waste Management:</h4>
                                </div>
                                <div class="card-body">
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
                                    <div class="row">
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">1. Particulars of Application: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        a) Name of the Applicant:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtNameApplicant" runat="server" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">
                                                        b) Name of the health care facility (HCF)/common bio-medical waste treatment facility(CBWTF):</label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:RadioButtonList ID="rblMedical" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="HCF" Value="Y" />
                                                            <asp:ListItem Text="CBWTF" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">c) E-Mail ID*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEmailId" runat="server" class="form-control" onblur="validateEmail(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">d) Mobile Number *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">e) Website Address:</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtweb" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                        </div>


                                        <div class="col-md-12 d-flex mt-3">
                                            <h4 class="card-title ml-3">2. Activity for which authorisation is sought: </h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">a) Authorization required for (Please tick appropriate activity or activities *</label>
                                                </div>
                                                <div class="col-lg-12 d-flex">
                                                    <asp:CheckBoxList ID="CHKAuthorized" runat="server" RepeatDirection="Horizontal" RepeatColumns="7" Style="padding: 20px">
                                                        <asp:ListItem Text="Generation" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Segregation" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Collection" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Storage" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Packing" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Reception" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="Transportation" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="Recycling" Value="9"></asp:ListItem>
                                                        <asp:ListItem Text="Disposal or destruction" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="Disposal or destruction" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="Transfer" Value="12"></asp:ListItem>
                                                        <asp:ListItem Text="Any other form of handling" Value="13"></asp:ListItem>
                                                        <asp:ListItem Text="Treatment or processing or conversion" Value="8"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br />

                                    <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    b) Select number of beds for authorization*
                                                </label>
                                                <div class="col-lg-6 ">
                                                    <asp:DropDownList ID="ddlAuthBeds" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddlAuthBeds_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0" Selected="false"></asp:ListItem>
                                                        <asp:ListItem Text="Upto 25 Beds" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Upto 50 Beds" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Upto 75 Beds" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Upto 100 Beds" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Above 100 Beds" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="HCF (Non-bedded, Private, Investment up to 10 Lacs)" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="HCF (Non-bedded, Private, Investment above 10 Lacs)" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="HCF (Non-bedded, Non-Profit Making)" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="Research & Educational Institutions/Veterinary Institutions/Animal Houses" Value="9"></asp:ListItem>
                                                        <asp:ListItem Text="Common Bio-Medical Waste Treatment Facility" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="Govt. District Health Centre (Irrespective of number of beds)" Value="11"></asp:ListItem>


                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">c) Please select number of years*</label>
                                                <div class="col-lg-6">
                                                    <asp:DropDownList ID="ddlAuthYears" AutoPostBack="true" runat="server" CssClass="auto-style1" OnSelectedIndexChanged="ddlAuthYears_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0" Selected="false"></asp:ListItem>
                                                        <asp:ListItem Text="1 Year" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="5 Years" Value="5"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">d) Total Fees*</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtBedFee" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" AutoPostBack="true" TabIndex="1" ReadOnly="true" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex mt-3">
                                        <h4 class="card-title ml-3">3. Application for fresh or renewal of authorisation (please tick whatever is applicable): </h4>
                                    </div>

                                    <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    a) Applied for CTO/CTE
                                                </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:RadioButtonList ID="rblauthorisation" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblauthorisation_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="Yes" style="margin-right: 20px;" />
                                                        <asp:ListItem Text="No" Value="No" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="divPCB" runat="server" visible="false">
                                            <div class="form-group row">

                                                <label class="col-lg-6 col-form-label">i) Under the Water (Prevention and Control of Pollution) Act, 1974*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtPCB" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="divPCB1981" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">ii) Under the Air (Prevention and Control of Pollution) Act, 1981: *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtPCB1981" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    b) Application for:
                                                </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:RadioButtonList ID="rblAppliedFor" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblAppliedFor_SelectedIndexChanged">
                                                        <asp:ListItem Text="Fresh" Value="Fresh" style="margin-right: 20px;" />
                                                        <asp:ListItem Text="Renewal" Value="Renewal" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="divRenewal" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    i) In case of renewal previous authorisation number</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtRenno" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="divRenewalDate" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    ii) In case of renewal previous authorisation Date:
                                               
                                                </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtAuthorisationDate" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtAuthorisationDate"></cc1:CalendarExtender>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex mt-3">
                                        <h4 class="card-title ml-3">4. (HCF/CBWTF) </h4>
                                    </div>
                                    <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    (i) Address of the health care facility (HCF) or common bio-medical waste treatment facility (CBWTF):*</label>
                                                <div class="col-lg-4 d-flex">
                                                    <asp:TextBox ID="txtAddress" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    (ii) GPS coordinates of health care facility (HCF) or common bio-medical waste treatment facility (CBWTF):*</label>
                                                <div class="col-lg-4 d-flex">
                                                    <%--<asp:RadioButtonList ID="rblGPS" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="HCF" Value="Y" />
                                                            <asp:ListItem Text="CBWTF" Value="N" />
                                                        </asp:RadioButtonList>--%>
                                                    <asp:TextBox ID="txtGPS" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex mt-3">
                                        <h4 class="card-title ml-3">5. Details of health care facility (HCF) or common bio-medical waste treatment facility (CBWTF):</h4>
                                    </div>
                                    <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">i) Number of beds of HCF:</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtNoHCF" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">ii) Number of patients treated per month by HCF:</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtHCFNO" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">iii) Number healthcare facilities covered by CBMWTF:</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtHealthCBMWFT" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">iv) No of beds covered by CBMWTF:</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtNobedcbmwtf" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">v) Installed treatment and disposal capacity of CBMWTF:</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtcapacitytreat" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">vi) Area or distance covered by CBMWTF:</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtdistance" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">vii) Quantity of Bio-medical waste handled, treated or disposed.</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtwastetreat" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex mt-3">
                                        <h4 class="card-title ml-3">6. Category of waste:</h4>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Category*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlcategory" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                        <%-- <asp:ListItem Text="Yellow" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Red" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="White(Translucent)" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Blue" Value="4"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Type of waste*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlwaste" runat="server" class="form-control">
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Quantity Generated or Collected, Kg/ day</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtQuantity" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Method of Treatmentand Disposal (ReferSchedule – I)</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtMethod" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 text-center">
                                            <asp:Button ID="btnAdd" Text="Add Details" runat="server" OnClick="btnAdd_Click" class="btn btn-rounded btn-green" Width="110px" />
                                        </div>

                                    </div>

                                    <div class="col-md-12 d-flex justify-content-center">
                                        <asp:GridView ID="GVWaste" runat="server" AutoGenerateColumns="false" OnRowDeleting="GVWaste_RowDeleting">
                                            <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" HorizontalAlign="Center" />
                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />

                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category" Visible="true" ItemStyle-Width="60%" HeaderStyle-HorizontalAlign="left">
                                                    <ItemTemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                        <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("BMW_TYPE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Type of waste" Visible="true" ItemStyle-Width="60%" HeaderStyle-HorizontalAlign="left">
                                                    <ItemTemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                        <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("BMW_NAME") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Quantity Generated or Collected, Kg/ day" ItemStyle-Width="60%" HeaderStyle-HorizontalAlign="left">
                                                    <ItemTemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("BMW_QUANTITYGENERATED") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Method of Treatment and Disposal (ReferSchedule – I)" ItemStyle-Width="60%" HeaderStyle-HorizontalAlign="left">
                                                    <ItemTemplate>
                                                        <itemstyle horizontalalign="Center" />
                                                        <asp:Label ID="lblDisposal" runat="server" Text='<%# Eval("BMW_TREATMENTDISPOSAL") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <br />
                                    <div class="col-md-12 d-flex mt-3">
                                        <h4 class="card-title ml-3">7. Brief description of arrangements for handling of biomedical waste (attach details): </h4>
                                    </div>

                                    <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">i) Mode of transportation (if any) of bio-medical waste:</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtBiowaste" runat="server" class="form-control" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <label class="col-lg-6 col-form-label">ii) Details of treatment equipment (please give details such as the number, type & capacity of each unit)</label>
                                    <div class="col-md-12 d-flex justify-content-center">
                                        <div class="tableBMW">
                                            <asp:GridView ID="GVBIOMedical" runat="server" AutoGenerateColumns="false" OnRowDataBound="GVBIOMedical_RowDataBound">
                                                <HeaderStyle VerticalAlign="Middle" Width="70%" Height="40px" CssClass="GridviewScrollC1HeaderWrap" HorizontalAlign="Center" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />

                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category" Visible="false" ItemStyle-Width="60%" HeaderStyle-HorizontalAlign="left">
                                                        <ItemTemplate>
                                                            <itemstyle horizontalalign="Center" />
                                                            <asp:Label ID="lblBMWID" runat="server" Text='<%# Eval("BMW_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Details Of Treatment" Visible="true" ItemStyle-Width="40%" HeaderStyle-HorizontalAlign="left">
                                                        <ItemTemplate>
                                                            <itemstyle horizontalalign="Center" />
                                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("BMW_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="No of units" ItemStyle-Width="180px">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtSource" CssClass="form-control" TabIndex="1" runat="server" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="capacity of each unit" ItemStyle-Width="180px">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtCapacity" CssClass="form-control" TabIndex="1" runat="server" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>


                                    <h4 class="card-title ml-3 mt-5">Upload Document:</h4>
                                    <div class="col-md-12 d-flex" style="margin-top: -35px;">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-3 col-form-label"></label>
                                                <div class="col-lg-2 d-flex">
                                                </div>
                                                <div class="col-lg-4 d-flex">
                                                    <label class="col-lg-5 col-form-label">Reference No </label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-4 col-form-label">7. Contingency plan of common bio-medical waste treatment facility (CBWTF)  </label>
                                                <div class="col-lg-1 d-flex">
                                                    :
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:TextBox ID="txtCBWTFBIO" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupBiomedicalwaste" runat="server" />
                                                </div>
                                                <div class="col-lg-1 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnBiomedicalwaste" OnClick="btnBiomedicalwaste_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" Height="34px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypBiomedicalwaste" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblBiomedicalwaste" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-4 col-form-label">8. Details of directions or notices or legal actions if any during the period of earlier authorisation:  </label>
                                                <div class="col-lg-1 d-flex">
                                                    :
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:TextBox ID="txtlegalDet" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fuplegalnotice" runat="server" />
                                                </div>
                                                <div class="col-lg-1 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnlegalnotice" OnClick="btnlegalnotice_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" Height="34px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hyplegalnotice" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lbllegalnotice" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 text-right mt-2 mb-2">
                                    <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" OnClick="btnPreviuos_Click" />
                                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" OnClick="btnNext_Click" />

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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnBiomedicalwaste" />
            <asp:PostBackTrigger ControlID="btnlegalnotice" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
