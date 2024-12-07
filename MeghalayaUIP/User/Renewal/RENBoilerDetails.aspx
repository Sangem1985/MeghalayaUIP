<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENBoilerDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENBoilerDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
    //let originalValue = "";
    function handleKeyUp(input)
    {
        if (input.value.trim() === "") {
            input.style.border = "2px solid red";
        }
        else {
            input.style.border = "1px solid #767575b5";
        }
        }
        function validateDropdown(dropdown) {

            if (dropdown.value === "0") {
                dropdown.style.border = "2px solid red";
                dropdown.focus();
            } else {
                dropdown.style.border = "1px solid #767575b5";
            }
        }


        function validateRadioButtonList(radioGroupContainer) {
            // Find all radio buttons inside the container
            const radioButtons = radioGroupContainer.querySelectorAll('input[type="radio"]');

            // Check if any radio button is selected
            const isSelected = Array.from(radioButtons).some(radio => radio.checked);

            if (!isSelected) {
                // If none are selected, apply red border
                radioGroupContainer.style.border = "2px solid red";
                radioGroupContainer.querySelector('input[type="radio"]').focus(); // Set focus to the first radio button
            } else {
                // Reset the border if an option is selected
                var id = radioGroupContainer.id;
                document.getElementById(id).style.border = "1px solid #767575b5";
                return false;
            }
        }
    </script>
    <style>
        i.fi.fi-br-circle-camera {
            font-size: 32px;
            margin-right: -21px;
            padding-left: 6px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="RENUserDashboard.aspx">Renewal</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Boiler Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" runat="server" id="divText">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Boiler Details</h4>
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
                                            <%--<label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Existing License Details</span></label>--%>
                                            <h4 class="card-title ml-3">Existing License Details</h4>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License No for which renewal is required *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtRenLic" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License Issued Date *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLicIssDate" runat="server" Type="text" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLicIssDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License/ Renewal valid up to Date *</label>
                                                    <div class="col-lg-6">
                                                        <%-- <asp:TextBox ID="txtLicValid" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtLicValid" class="form-control" onkeypress="validateNumberAndHyphen(event);" onkeyup="handleKeyUp(this)" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLicValid"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="col-md-12 d-flex">

                                            <h4 class="card-title ml-3 mt-3">Boiler Location Details</h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Work or Plant where Boiler situated *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtBoilerDet" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Factory/Establishment Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtFactoryName" runat="server" class="form-control" Type="text" onkeypress="return Names(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Address of Factory/Establishment*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEstAddress" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" onkeyup="handleKeyUp(this)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <%--  <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nearest Railway Station *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txt" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>--%>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Distric</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control" onchange="validateDropdown(this)" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select District" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlMandal" runat="server" onchange="validateDropdown(this)" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlVillage" runat="server" onchange="validateDropdown(this)" class="form-control">
                                                            <asp:ListItem Text="Select Village" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Locality(B) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLocality" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return Address(event)" onkeyup="handleKeyUp(this)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Pin code (B) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPincode" runat="server" class="form-control" Type="text" onkeypress="return NumberOnly()" TabIndex="1" onkeyup="handleKeyUp(this)" MaxLength="6"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">

                                            <h4 class="card-title ml-3 mt-3">Boiler Technical Details</h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of the Manufacturer *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNameManu" runat="server" class="form-control" onkeyup="handleKeyUp(this)" TextMode="MultiLine" onkeypress="return Names(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Year of Manufacture *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtYearManu" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MM-yyyy" TargetControlID="txtYearManu"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Place of Manufacture *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtManuPlace" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return Names(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Boiler Maker's Number *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtBoilerNo" runat="server" class="form-control" onkeyup="handleKeyUp(this)" Type="text" onkeypress="return NumberOnly()"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Intended Working Pressure*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtIntended" runat="server" class="form-control" onkeyup="handleKeyUp(this)" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Fuel use</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlFuel" onchange="validateDropdown(this)" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Super Heater Rating(kg/cm²/lbs) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtHeater" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Economiser Rating *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEconomiser" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Maximum Continuous Evaporation(Tonnes/Hour) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEvaporation" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Re-Heater Rating *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtReHeater" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Working Season</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlWorkingsea" onchange="validateDropdown(this)" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Working Pressure (In Kg/cm-sq or PSI) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPressure" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of the owner *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNameOwner" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return Names(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Type of Boiler</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlBoilerType" onchange="validateDropdown(this)" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Description of Boiler *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDescBoiler" runat="server" class="form-control" onkeyup="handleKeyUp(this)" TextMode="MultiLine" onkeypress="return Names(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                        </div>




                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Boiler Rating*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlBoilerRate" onchange="validateDropdown(this)" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">In case of Boiler ownership being transfer *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblOwnership" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblOwnership_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="Remark" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Remarks (Transfers etc.)*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRemaek" runat="server" class="form-control" onkeyup="handleKeyUp(this)" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3 mt-3">Existing Lisence Details</h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Registry No *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRegNo" runat="server" class="form-control" onkeyup="handleKeyUp(this)" Type="text" onkeypress="return NumberOnly()"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Type of Boiler(H)*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlboiler" onchange="validateDropdown(this)" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Boiler Rating(H)*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlRatingBoiler" onchange="validateDropdown(this)" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Work of Plant where Boiler situated(H) *</label>
                                                    <div class="col-lg-6 d-flex">

                                                        <asp:TextBox ID="txtPlantSituated" runat="server" class="form-control" onkeyup="handleKeyUp(this)" Type="text" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>



                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Place of manufacture(H) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtManufacture" runat="server" class="form-control" onkeyup="handleKeyUp(this)" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Year of manufacture(H) *</label>
                                                    <div class="col-lg-6 d-flex">

                                                        <asp:TextBox ID="txtYearManufacture" runat="server" class="form-control" onkeyup="handleKeyUp(this)" Type="text" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="txtYearManufacture"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4 mt-2">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of the owner(H) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtOwner" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return Names(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Max. Cont. Evaporation (Tonnes/Hour)(H) *</label>
                                                    <div class="col-lg-6 d-flex">

                                                        <asp:TextBox ID="txtMaxCount" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>



                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Maximum pressure(Lbs)(H) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMaxPressure" runat="server" onkeyup="handleKeyUp(this)" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Repairs(H) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRepaire" runat="server" class="form-control"  onkeyup="handleKeyUp(this)" Type="text" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Hydraulically Tested ON(H) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtHydraulical" runat="server" onkeyup="handleKeyUp(this)" class="form-control" Type="text" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="txtHydraulical"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Upto(H) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtUpto" runat="server" class="form-control" onkeyup="handleKeyUp(this)" Type="Text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">The Loading of the(H) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLoading" runat="server" class="form-control" onkeyup="handleKeyUp(this)" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Safety valve is not to exceed(H) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtSaftey" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Period from Date(H) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%-- <asp:TextBox ID="txtPeriodDate" runat="server" class="date form-control" Type="Text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtPeriodDate" class="form-control" onkeyup="handleKeyUp(this)" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtPeriodDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">To Date(H) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%--  <asp:TextBox ID="txtDateTo" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtDateTo" onkeyup="handleKeyUp(this)" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateTo"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-2 col-form-label">Remark *</label>
                                                    <div class="col-lg-10 d-flex">
                                                        <asp:TextBox ID="txtRemarktype" runat="server" onkeyup="handleKeyUp(this)" class="form-control" Type="text" onkeypress="return Names(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3 mt-3">Fees Details</h4>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Registration Fees to be Paid (Rs):  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRegFees" runat="server" class="form-control" onkeyup="handleKeyUp(this)" Type="Text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Total Amount to be paid (in Rs): *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAmountPaid" runat="server" class="form-control" onkeyup="handleKeyUp(this)" Type="Text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 text-right mt-2 mb-2">

                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" OnClick="btnPreviuos_Click" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded  btn-info btn-lg" Width="150px" OnClick="btnNext_Click" />

                                        </div>
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
    </asp:UpdatePanel>
</asp:Content>
