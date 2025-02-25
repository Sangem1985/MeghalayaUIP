<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="PlasticWasteDetails.aspx.cs" Inherits="MeghalayaUIP.User.Services.PlasticWasteDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        input[type=checkbox], input[type=radio] {
            box-sizing: border-box;
            padding: 6px 0px !important;
            margin: 0px 6px !important;
        }
    </style>
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
        function handleKeyUp(input) {
            if (input.value.trim() === "") {
                input.style.border = "2px solid red";
            }
            else {
                input.style.border = "1px solid #767575b5";
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a>Services</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Plastic Waste Management</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" runat="server" id="divText">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Application for registration for Producers/Brand Owners</h4>

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
                                            <h4 class="card-title ml-3">1. Name Of Producer </h4>
                                        </div>
                                        <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">
                                                        Name :
                                                    </label>
                                                    <div class="col-lg-3">
                                                        <asp:TextBox ID="txtNameProducer" Type="text" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex mt-2">
                                            <h4 class="card-title ml-3">2. Address Of Producer: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. DoorNo*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDoorNo" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Locality *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLocal" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        3. State
                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlstate" runat="server" class="form-control" AutoPostBack="true">
                                                            <asp:ListItem Text="Select State" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- meghalaya state --%>
                                        <div class="col-md-12 d-flex" id="trMeghalaya" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        4. District
                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddldist" runat="server" class="form-control" AutoPostBack="true">
                                                            <asp:ListItem Text="Select District" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">5. Mandal</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlmand" runat="server" class="form-control" AutoPostBack="true">
                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">6. Village</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlvilla" runat="server" class="form-control" AutoPostBack="true">
                                                            <asp:ListItem Text="Select Village" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- other states selected so ddl will be disabled textboxes will appear --%>
                                        <div class="col-md-12 d-flex" runat="server" id="trotherstate" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.District *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtOtherlDist" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">5.Mandal *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtOtherlTaluka" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">6.Village *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtOtherVillage" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex" runat="server">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">7.Pincode *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtpincode" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">8.Nearest Landmark</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLANDMARK" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <%-- ------------------------------------------Producer-------------------------------------------- --%>
                                        <div id="divProducer">
                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3">1. Particulars Of the application PART - A GENERAL </h4>
                                            </div>
                                            <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                                <div class="col-md-8">
                                                    <div class="form-group row">
                                                        <label class="col-lg-9 col-form-label">
                                                            Name :
                                                        </label>
                                                        <div class="col-lg-3">
                                                            <asp:TextBox ID="txtProdName" Type="text" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">2. Address Of The Unit: </h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. DoorNo*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtUnitDoor" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Locality *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtUnitLocality" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            3. State
                                                        </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlUnitState" runat="server" class="form-control" AutoPostBack="true">
                                                                <asp:ListItem Text="Select State" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- meghalaya state --%>
                                            <div class="col-md-12 d-flex" id="trUnitMeghalaya" runat="server" visible="false">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            4. District
                                                        </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlUnitDist" runat="server" class="form-control" AutoPostBack="true">
                                                                <asp:ListItem Text="Select District" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5. Mandal</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlUnitMand" runat="server" class="form-control" AutoPostBack="true">
                                                                <asp:ListItem Text="Select Mandal" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">6. Village</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlUnitVilla" runat="server" class="form-control" AutoPostBack="true">
                                                                <asp:ListItem Text="Select Village" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- other states selected so ddl will be disabled textboxes will appear --%>
                                            <div class="col-md-12 d-flex" runat="server" id="trUnitOtrSt" visible="false">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4.District *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtUnitDist" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5.Mandal *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtUnitMand" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">6.Village *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtUnitVillage" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex" runat="server">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">7.Pincode *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtUnitPin" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">8.Nearest Landmark</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtUnitLandmark" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">3. Registration & Manufacturing:</h4>
                                            </div>
                                            <div class="col-md-12 d-flex mt-2">
                                                <label class="col-lg-8 col-form-label">1. Registration required for manufacturing of:</label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">(i) Carry Bags:</label>
                                                        <div class="col-lg-6">
                                                            <asp:CheckBoxList ID="chkCarryBags" runat="server">
                                                                <asp:ListItem Text="(a) Petro-based" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="(b) Compostable" Value="2"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">(ii) Multilayered Plastics:</label>
                                                        <div class="col-lg-6">
                                                            <asp:CheckBox ID="chkMultilayeredPlastics" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Manufacturing Capacity:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtManufacturingCapacity" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Previous Registration No</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPreviousRegistration" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Date:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtDate" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">4. Investment and Production Details:</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Total Capital Invested (INR Lakhs):</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtCapitalInvestment" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Year of Commencement:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtCommencementYear" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">5. Products and Raw Materials:</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. List & Quantum of Products:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtProductsList" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. List & Quantum of Raw Materials:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtRawMaterials" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">6. Compliance with Rules:</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Compliance with 50-micron Thickness Rule:</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:RadioButtonList ID="rblWomen" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">7. Liquid Effluent and Gaseous Emissions:</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">
                                                            1. Does the unit have a valid consent under the Water (Prevention and control of Pollution) Act, 1974 (6 of 1974)?
                                                        If yes, attach a copy *
                                                        </label>
                                                        <div class="col-lg-1 d-flex">
                                                            :
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:TextBox ID="txtWaterActComp" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="fupWaterActComp" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="btnBiomedicalwaste" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="hypWaterActComp" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                        <asp:Label ID="lblWaterActComp" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">
                                                            2. Does the unit have a valid consent under the Air (Prevention and Control of Pollution) Act, 1981 (14 of 1981)?
                                                            If yes, attach a copy *</label>
                                                        <div class="col-lg-1 d-flex">
                                                            :
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:TextBox ID="txtAirPol" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="fupAirPol" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="Button1" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="hypAirPol" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                        <asp:Label ID="lblAirPol" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">8. Solid Wastes Or Rejects:</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Total quantum of waste generated:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtTotalWaste" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Mode of storage within the plant:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtStorageMode" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Disposal Provisions:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtDisposal" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <%-- ----------------------------------------------Brand Owners------------------------------------ --%>
                                        <div id="divBrandOwner">
                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3">1. Particulars Of the application </h4>
                                            </div>
                                            <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                                <div class="col-md-8">
                                                    <div class="form-group row">
                                                        <label class="col-lg-9 col-form-label">
                                                            Name Of Brand Owner:
                                                        </label>
                                                        <div class="col-lg-3">
                                                            <asp:TextBox ID="txtBrandOwnrName" Type="text" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">2. Address Of The Brand Ownder: </h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. DoorNo*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtBOAdd" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Locality *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtBOLocality" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            3. State
                                                        </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="txtBOState" runat="server" class="form-control" AutoPostBack="true">
                                                                <asp:ListItem Text="Select State" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- meghalaya state --%>
                                            <div class="col-md-12 d-flex" id="divBOMeg" runat="server" visible="false">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            4. District
                                                        </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlBODis" runat="server" class="form-control" AutoPostBack="true">
                                                                <asp:ListItem Text="Select District" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5. Mandal</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlBOMan" runat="server" class="form-control" AutoPostBack="true">
                                                                <asp:ListItem Text="Select Mandal" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">6. Village</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlBOVill" runat="server" class="form-control" AutoPostBack="true">
                                                                <asp:ListItem Text="Select Village" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- other states selected so ddl will be disabled textboxes will appear --%>
                                            <div class="col-md-12 d-flex" runat="server" id="divBOtrstate" visible="false">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4.District *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtBODis" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5.Mandal *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtBOMan" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">6.Village *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtBOVill" class="form-control" onkeypress="return Names(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex" runat="server">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">7.Pincode *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtBOPin" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">8.Nearest Landmark</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtBOLandMark" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">3. Registration & Manufacturing:</h4>
                                            </div>
                                            <div class="col-md-12 d-flex mt-2">
                                                <label class="col-lg-8 col-form-label">Registration required for manufacturing of:</label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Previous Registration No</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtBORegNo" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Date:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtBODate" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">4. Investment and Production Details:</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Total Capital Invested (INR Lakhs):</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtBOTotalCapInv" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Year of Commencement:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtBOYearOfComncmnt" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">5. Products and By-products:</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. List and quantum of products and by-products (Ton/Annum)</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtBOProdQuan" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. List and quantum of raw materials used (Ton/Annum)</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtBORawMatQuan" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">6. PERTAINING TO WASTE</h4>
                                            </div>
                                            <div class="col-md-12 d-flex mt-2">
                                                <h5 class="card-title ml-3">Solid Wastes Or Rejects:</h5>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Total quantum of waste generated:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtBOQntmWasteGenertd" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Mode of storage within the plant:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtBOModeStrge" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Disposal Provisions:</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtBODispProv" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex mt-2">
                                                <h4 class="card-title ml-3">7. Pretaining to liquid effluent and gaseous emissions:</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">
                                                            1. Is the unit registered with the District Industries Centre	of	the	State	Government	or	Union territory? If yes, attach a copy. *</label>
                                                        <div class="col-lg-1 d-flex">
                                                            :
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:TextBox ID="txtBOStUT" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="fupBOStUT" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="Button4" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="hypBOStUT" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                        <asp:Label ID="lblBOStUT" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">
                                                            2. Does the unit have a valid consent under the Water (Prevention and control of Pollution) Act, 1974 (6 of 1974)?
If yes, attach a copy *
                                                        </label>
                                                        <div class="col-lg-1 d-flex">
                                                            :
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:TextBox ID="txtBOWaterActConsent" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="fupBOWaterActConsent" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="Button2" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="hypBOWaterActConsent" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                        <asp:Label ID="lblBOWaterActonsent" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">
                                                            3. Does the unit have a valid consent under the Air (Prevention and Control of Pollution) Act, 1981 (14 of 1981)?
    If yes, attach a copy *</label>
                                                        <div class="col-lg-1 d-flex">
                                                            :
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:TextBox ID="txtBOAirPoltn" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="fupAIrPoltn" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="Button3" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="hypAirPoltn" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                        <asp:Label ID="lblAirPoltn" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="btnDisposal" />
            <asp:PostBackTrigger ControlID="btnDetailsSolidWaste" />
            <asp:PostBackTrigger ControlID="btnDetailSiteSelection" />
            <asp:PostBackTrigger ControlID="btnSiteClearance" />
            <asp:PostBackTrigger ControlID="btnEnvironmentalClearance" />
            <asp:PostBackTrigger ControlID="btnAgreement" />
        </Triggers>--%>
    </asp:UpdatePanel>

</asp:Content>
