<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEPowerCEIGDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEPowerCEIGDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    function handleKeyUp(input) {
        if (input.value.trim() === "") {
            input.style.border = "2px solid red";
        } else {
            input.style.border = "1px solid #767575b5";
        }
    }
    </script>
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="page-wrapper" id="divText" runat="server">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">POWERCEIG Details</h4>
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
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">1.Contracted Maximum Demand in KVA</span></label>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Already installed *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtInstall" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Proposed *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtProposed" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Total *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtTotal" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="4" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">2.Connected Load in KW/HP</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Type of Connected Load</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlLOAD" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="KW" Value="Y"></asp:ListItem>
                                                            <asp:ListItem Text="HP" Value="N"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Already installed *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAlready" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Proposed*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPropose" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Total *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtTotals" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="4" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        3.Regulation</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlRegulation" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRegulation_SelectedIndexChanged">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="divvoltages" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Voltage</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlvtg" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4" id="divpowerplants1" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Plant</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlPlant" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="divpowerplants2" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.Aggregate Transformer Capacity(ATC) (in KVA) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtCapacity" runat="server" class="form-control" onkeypress="validateNumberAndDot(event)" MaxLength="7" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Proposed Location of Factory</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlLocFactory" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="IE" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="IDA" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="SEZ" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="4"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Survey No *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtSurvey" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Extent *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtExtent" runat="server" class="form-control" onkeypress="validateNumberAndDot(event)" MaxLength="7" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Distric</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select District" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
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
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Street Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtStreet" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="200" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Pincode *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPincode" runat="server" class="form-control" onkeypress="return validatePincode(event)" MaxLength="6" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Telephone(incl STD Code)</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtTelephone" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nearest Telephone No*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNearestNo" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of Commencement of Production(dd-MMM-yyyy)*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%-- <asp:TextBox ID="txtDate" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>
                                                        <asp:TextBox runat="server" ID="txtDate" class="form-control" TabIndex="1" MaxLength="10" onkeypress="validateNumberAndHyphen();" onblur="validateDateFormat(this)" onkeyup="handleKeyUp(this)" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Agreement letter between Contractor & Owner *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupoWNER" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnowner" OnClick="btnowner_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypowner" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblowner" runat="server" />

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Contractor License copy *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupLic" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnLic" OnClick="btnLic_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypLic" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblLic" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Contractor/Project electrical supervisor permit copy  *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupElectrical" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnElectrical" OnClick="btnElectrical_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypElectrical" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblElectrical" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Feasibility report from the DISCOMS  *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupdiscoms" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnDiscoms" OnClick="btnDiscoms_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypdiscoms" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lbldiscoms" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Electrical Single line diagram from Point of Commencement of supply to the end use of electrical energy  *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupenergy" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnEnergy" OnClick="btnEnergy_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypenergy" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblenergy" runat="server" />

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">The structural layout showing plan and Elevations with sectional and safe clearances  *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupPlan" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnPlan" OnClick="btnPlan_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypplan" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblplan" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">General arrangement of the equipment drawing showing the location of various equipments.  *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupDraw" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnDraw" OnClick="btnDraw_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypDraw" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblDraw" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">The earthing layout diagram  *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupEarth" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnEarth" OnClick="btnEarth_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypEarth" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblEarth" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 text-right mt-2 mb-2">
                                            <asp:Button Text="Previous" runat="server" ID="btnPrevious" OnClick="btnPrevious_Click" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" Text="Next" runat="server" OnClick="btnNext_Click" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnowner" />
            <asp:PostBackTrigger ControlID="btnLic" />
            <asp:PostBackTrigger ControlID="btnElectrical" />
            <asp:PostBackTrigger ControlID="btnDiscoms" />
            <asp:PostBackTrigger ControlID="btnEnergy" />
            <asp:PostBackTrigger ControlID="btnPlan" />
            <asp:PostBackTrigger ControlID="btnDraw" />
            <asp:PostBackTrigger ControlID="btnEarth" />
        </Triggers>
    </asp:UpdatePanel>



</asp:Content>
