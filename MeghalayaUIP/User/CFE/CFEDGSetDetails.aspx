﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEDGSetDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEDGSetDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Pre Establishment</a></li>

            <li class="breadcrumb-item active" aria-current="page">DG Set Details</li>
        </ol>
    </nav>
    <div class="page-wrapper">

        <div class="content container-fluid">

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">DG Set Details</h3>
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
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                            <div class="row">

                                <h4 class="card-title ml-3">Location of D.G. Set with Full Postal Address*</h4>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Door No/Survey No*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtDoorNo" runat="server" class="form-control" ></asp:TextBox>
                                               
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Locality *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLocality" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Landmark*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLandmark" runat="server" class="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">District *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlLocDist" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLocDist_SelectedIndexChanged">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mandal *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlLocTaluka" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLocTaluka_SelectedIndexChanged">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Village *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlLocVillage" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">PinCode*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPincode" runat="server" class="form-control" onkeypress="return NumberOnly()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <h4 class="card-title ml-3">Whether Supply from the Supplier Licensee is Available</h4>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of Supplier *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtSupplierName" runat="server" class="form-control" onkeypress="return Names()" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Total Connected Load (in KW)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtConnectedLoad" runat="server" class="form-control" onkeypress="validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Total Proposed Load to be Supplied from D.G. Sets (in KW)</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPropLoadfrmDGSet" runat="server" class="form-control" onkeypress="validateNumberAndDot(event)" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-10 col-form-label">Details of Interlock/Change over arrangement provided to prevent accidental paralleling of D.G. Sets to the Supply System *</label>
                                            <div class="col-lg-2 d-flex">
                                                <asp:RadioButtonList ID="rblInterlockProvision" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <%--<i class="fi fi-rr-calendar-lines"></i>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <h4 class="card-title ml-3">Detail of Load proposed to be supplied from D.G Sets</h4>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Motor (AC)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMotorLoad" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Light and Fans *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLghtsFansLoad" runat="server" class="form-control" ></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Other (to be specified)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtOtherLoad" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <h4 class="card-title ml-3">Running Mode and Expected Date of Installation/Completion/Commissioning</h4>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Generators Running Mode  (in case more than one will be installed) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlGenRunningMode" runat="server" class=" form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Parallel" Value="Parallel"></asp:ListItem>
                                                    <asp:ListItem Text="Isolated" Value="Isolated"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Expected Date of Completion of work *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtWrkComplDate" runat="server" class="date form-control" type="text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Expected Date of starting of Installation work *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtWrkStartDate" runat="server" class="date form-control" type="text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Expected Date of Commissioning *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtCommissiongDate" runat="server" class="date form-control" type="text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <h4 class="card-title ml-3">Supervisor/Contractor/Operator Details</h4>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of the Supervisor *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtSuprvisorName" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Supervisor License Number *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtSuprvisorLICno" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of the Contractor who will carry out the internal electricfication</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtContractorName" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Contractor License Number *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtContractorLICno" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of the Person who will be authorized to operate the D.G Sets *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtDGsetOperatorName" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <h4 class="card-title ml-3">DG Set Details</h4>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Capacity *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtDGSetCapacity" runat="server" class="form-control" onkeypress="validateNumberAndDot(event)" ></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Capacity is in KW/KVA *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:RadioButtonList ID="rblDGSetCapacity" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="KW" Value="KW"></asp:ListItem>
                                                    <asp:ListItem Text="KVA" Value="KVA"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Power Factor *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPowerFactor" runat="server" class="form-control" Text="0.8" onkeypress="validateNumberAndDot(event)"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Rated Voltage (KV)  *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtRatedVolatge" runat="server" class="form-control" onkeypress="validateNumberAndDot(event)" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Engine Make/Serial No.*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEngineDtls" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Alternator Make/Serial No *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtAlternatorDtls" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <h4 class="card-title ml-3">Details of earthing (Rule 41) the particulars are required in respect of item 12 of the main proforma</h4>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Type of Equipment *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlEquipment" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Alternator Body" Value="KW"></asp:ListItem>
                                                    <asp:ListItem Text="Alternator Neutral" Value="KVA"></asp:ListItem>
                                                    <asp:ListItem Text="Alternator Control Panel" Value="KVA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Size & materials of earthing conductor *   </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtConductorDtls" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">No. of independent conductor path *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtConductorPaths" runat="server" class="form-control" onkeypress="return NumberOnly()" ></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Type & size electrode and length/dia *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtElectrodeDtls" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Impedance of the systems in ohm *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtImpedance" runat="server" class="form-control" onkeypress="validateNumberAndDot(event)" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Total Impedance of the system in ohm *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtTotalImpedance" runat="server" class="form-control"  onkeypress="validateNumberAndDot(event)" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Type of lighting *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddllighting" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Arrester" Value="Arrester"></asp:ListItem>
                                                    <asp:ListItem Text="Conductor" Value="Conductor"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Insulation Test of Alternator *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtAltrnatrInsTest" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <h4 class="card-title ml-3">Earth Tester and Megger Details</h4>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Earth Tester No. *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEarthTesterNo" runat="server" class="form-control" ></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Make (Earth Tester)*   </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEarthTesterMake" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Range (Earth Tester) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEarthTesterRange" runat="server" class="form-control" ></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Megger No. *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMeggerNo" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Make (Megger) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMeggerMake" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Range (Megger) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMeggerRange" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 text-right mb-3">
                                    <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>