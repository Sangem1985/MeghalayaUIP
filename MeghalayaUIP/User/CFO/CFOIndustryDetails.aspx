<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOIndustryDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOIndustryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
        function validateEmail(event) {
            var email = event.target.value;
            var isValidEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);

            if (!isValidEmail) {
                event.target.value = "";
                alert("Enter a valid email address");
            }
        }
        $(document).ready(function () {
            $('input[type="text"]').on('paste', function (e) {
                e.preventDefault();
            });
        });

    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2023:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtRegDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

        }
        $(function () {
            var date = new Date();
            var yrRange = "2023:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtRegDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });

        });
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="#">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="#">Pre Establishment</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Industry Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">Details of Organization, Authorised Representative and Unit Location </h3>
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
                                    <asp:HiddenField ID="hdnPreRegUID" runat="server" />

                                    <div class="row">
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">Organization Details: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Name of Company</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtIndustryName" runat="server" class="form-control" onkeypress="return validateNames(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        2. Type of
														Company *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlCompanyType" runat="server" class="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Company Proposal *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="rblproposal" runat="server" TabIndex="1" class="form-control" Enabled="false">
                                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Value="New" Text="New"></asp:ListItem>
                                                            <asp:ListItem Value="Existing" Text="Existing"></asp:ListItem>
                                                            <asp:ListItem Value="Expansion" Text="Expansion"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12  d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        4. Category of
														Registration*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlRegType" runat="server" class="form-control" OnSelectedIndexChanged="ddlRegType_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Category" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <%-- <label class="col-lg-6 col-form-label">6. Registration No*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRegistrationNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>--%>
                                                    <label class="col-lg-6 col-form-label" id="lblregntype" runat="server">5. Registraion No <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtUdyamorIEMNo" Enabled="false" TabIndex="1" class="form-control" onkeypress="return validateNameAndNumbers(event)" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        6. Registration Date *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%--<asp:TextBox ID="txtRegDate" runat="server" class="form-control" onkeypress="datefunction(date_input)"></asp:TextBox>--%>

                                                        <asp:TextBox ID="txtRegDate" runat="server" TabIndex="1" ValidationGroup="group" class="date form-control"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>

                                                        <%--  <asp:TextBox runat="server" ID="txtRegDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" OnTextChanged="txtCompnyRegDt_TextChanged" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtRegDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12  d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">7. Type of Factory*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlFactories" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Hazardous" Value="Hazardous"></asp:ListItem>
                                                            <asp:ListItem Text="Non Hazardous" Value="Non Hazardous"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
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
                                                        <asp:TextBox ID="txtMobileno" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10" onblur="validateIndianMobileNumber(this);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        5. Alternative Mobile
														No*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAltMobile" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10" onblur="validateIndianMobileNumber(this);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        6. Landline Tel No
                                               
                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLandlineno" runat="server" class="form-control" onkeypress="validateNumberAndHyphen();" MaxLength="8"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">7. Door No</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDoorNo" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">8. Locality</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLocality" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">9. District</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDistric" runat="server" class="form-control" OnSelectedIndexChanged="ddlDistric_SelectedIndexChanged" AutoPostBack="true">
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
                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">11. Village/Town</label>
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
                                                        <asp:TextBox ID="txtpincode" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="6"></asp:TextBox>
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
                                                        18. Differently
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

                                        <div class="col-md-12  d-flex">
                                        </div>
                                        <%--     <h5 class="card-title ml-3">Project Details(New Investmen)</h5>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                1. Land Value(in
														Lakhs)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLandValue" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                2. Building Value(in
														Lakhs)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtBuildingValue" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                3. Plant and Machinery
														Value(in Lakhs) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPlant_Machinery" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12  d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                4. Total Value(in
														Lakhs)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtTotalProjValue" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                                        <h4 class="card-title ml-3">Location Details: </h4>
                                        <%-- 
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                10. Location
																		of the unit</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtUnitLocation" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1.Plot No/Door No.*</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtUnitDoorNo" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">5. Locality*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtUnitLocality" runat="server" class="form-control" onkeypress="return validateNames(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. District</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlUnitDistrict" runat="server" class="form-control" OnSelectedIndexChanged="ddlUnitDistrict_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. Mandal</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlUnitMandal" runat="server" class="form-control" OnSelectedIndexChanged="ddlUnitMandal_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4. Village/Town</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlUnitVillage" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">6. Pincode</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtUnitPincode" runat="server" class="form-control" onkeypress="return validatePincode(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">7.Landline Tel No(If available)</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtUnitLandlineno" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">13. Building Height(In mtrs)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtBuildingHeight" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">12. Total Built up Area(in Sq. mts)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtBuiltUpArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">8. Total Extent of Land(in Sq. mts)</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtSiteArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    

                                </div>
                               
                                        --%>
                                        <div class="col-md-12 d-flex">
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.	Architect Name*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtArchitectName" runat="server" class="form-control" onkeypress="return validateNames(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2.	Architect License No.*</label>
                                                    <div class="col-lg-6 d-flex">

                                                        <asp:TextBox ID="txtArchitectLicNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3.	Architect Mobile No.*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtArchitectMobileno" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.	Structural Engineer Name</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtStrEngnrName" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">5.	Structural License No.</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtStrLicNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">6.	Structural Mobile No</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtStrEngnrMobileno" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">7. Proposed Area for Development(in Sq. mts)*</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtDevelopmentArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">8. Type of Approach Road*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlApproachRoad" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="BLACK TOP" Value="BLACK TOP" />
                                                            <asp:ListItem Text="CC" Value="CC" />
                                                            <asp:ListItem Text="GRAVEL" Value="GRAVEL" />
                                                            <asp:ListItem Text="WBM" Value="WBM" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">9. Existing Width of Approach Road(in feet)*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtExstngWidth" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">10. Affected in Road Widening*</label>
                                                    <div class="col-lg-6 d-flex radio">
                                                        <asp:RadioButtonList ID="rblAffectedroad" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblAffectedroad_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" runat="server" id="divAffectArea" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">11. 	Extend of affected area in sq.mts*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAffectedArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <h4 class="card-title ml-3">Employment Details: </h4>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6">(Total Employee-Direct:</label>
                                                <div>
                                                    <asp:Label ID="lbltotalEmp" runat="server" value="40" CssClass="font-weight-600"> </asp:Label>)
                                                </div>
                                            </div>
                                        </div>
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

                                        <h4 id="hdngRdCtng" visible="false" runat="server" class="card-title ml-3">Road Cutting Details</h4>
                                        <div class="col-md-12 d-flex" id="divRDctng" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Length of road to be cut:(in mtrs) *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtRdCutlenght" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Number of locations *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtRdCutLocations" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 text-right mb-2">
                                    <asp:Button Text="Previous" runat="server" ID="btnPrevious" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" Text="Next" runat="server" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
    </asp:UpdatePanel>
</asp:Content>
