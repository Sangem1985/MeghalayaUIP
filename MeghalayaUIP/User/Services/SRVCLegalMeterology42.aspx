<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCLegalMeterology42.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCLegalMeterology42" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Other Services</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Legal Metrology Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Legal Metrology Details</h4>
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
                                        <%-- APPROVAL ID 123--%>
                                        <div id="divLicenceDealers" runat="server" visible="true">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Other Details:</span></label>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Date of establishment </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtValidate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="txtValidate"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Have you obtain any current registration number of factory/ shop/ establishment?  *</label>
                                                        <div class="col-lg-4">
                                                            <asp:RadioButtonList ID="rblFactRegNo" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblFactRegNo_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex" id="divRegistration" runat="server" visible="false">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Date of registration(w) *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtRegDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtRegDate"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Current registration number(w)   *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtRegNumber" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Have you obtain any current registration number of Municipal Trade licence/ADC?   *</label>
                                                        <div class="col-lg-4">
                                                            <asp:RadioButtonList ID="rblLicADC" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLicADC_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-4" id="divDateReg" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Date of registration *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtDateReg" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateReg"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" id="divCutRegNo" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Current Registration Number   *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtCurrentRegNo" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Is it a partnership firm? *</label>
                                                        <div class="col-lg-4">
                                                            <asp:RadioButtonList ID="rblpartnership" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblpartnership_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Is it a limited company?   *</label>
                                                        <div class="col-lg-4">
                                                            <asp:RadioButtonList ID="rblcompany" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblcompany_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="divpartnership" runat="server" visible="false">
                                                <h4 class="card-title ml-3">Proprietor’s/partners Details: </h4>

                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">1. Name (s) <span class="text-danger">*</span></label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtpartnersName" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">2. Address (s)<span class="text-danger">*</span></label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtAddress" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label"></label>
                                                            <div class="col-lg-6 d-flex">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4 text-center">
                                                        <asp:Button ID="btnAddLOM" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="col-md-12 center-gridview">

                                                    <div class="col-md-8">
                                                        <asp:GridView ID="GVpartners" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                            GridLines="Both" Width="100%" EnableModelValidation="True" Visible="false">
                                                            <RowStyle BackColor="#ffffff" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Name" DataField="NAME" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Address " DataField="ADDRESS" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="col-md-4"></div>
                                                </div>
                                            </div>
                                            <div id="divcompany" runat="server" visible="false">
                                                <h4 class="card-title ml-3">Managing Director Details: </h4>

                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">1. Name (s) <span class="text-danger">*</span></label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtManagName" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">2. Address (s)<span class="text-danger">*</span></label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtManagAddress" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label"></label>
                                                            <div class="col-lg-6 d-flex">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4 text-center">
                                                        <asp:Button ID="btnManaging" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="col-md-12 center-gridview">

                                                    <div class="col-md-8">
                                                        <asp:GridView ID="GVManaging" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                            GridLines="Both" Width="100%" EnableModelValidation="True" Visible="false">
                                                            <RowStyle BackColor="#ffffff" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Name" DataField="NAME" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Address " DataField="ADDRESS" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="col-md-4"></div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Manufacturing Details</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Weights:</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtWeights" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Measures: </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtMeasures" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Weighting Instruments: </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtWeight" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Professional Tax registration Number: </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtRegNo" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5. GST:  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtGST" runat="server" class="form-control" onblur="validateGST(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">6.IT Number: </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtITNo" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Do you intend to import weights, etc. from places outside the State/Country?   *</label>
                                                        <div class="col-lg-6">
                                                            <asp:RadioButtonList ID="rblState" runat="server" onchange="validateRadioButtonList(this)" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblState_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" id="divLicNo" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Licence number: *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLICNumber" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" MaxLength="20"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" id="divWeight" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Registration of Importer of Weights and Measures : *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtRegWeight" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="9"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Have you applied previously for a dealer's licence,either in this State or elsewhere ?   *</label>
                                                        <div class="col-lg-4">
                                                            <asp:RadioButtonList ID="rblDealer" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblDealer_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" id="divDealerLic" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Give details : *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtGiveDetails" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <%-- APPROVAL ID 125--%>
                                        <div id="divInitialstamping" runat="server" visible="true">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Initial Verification And Stamping of Weighing and Measuring Instrument</span></label>
                                            </div>

                                            <h4 class="card-title ml-3">Instrument Details: </h4>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-5">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Instrument type *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtinstrment" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-5">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Class  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtClass" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-5">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Capacity  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtCapacity" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-5">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Make *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtMake" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-5">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Model  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtModel" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-5">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Serial No.  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtSerial" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-5">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Product</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtProduct" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-5">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Quantity  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtQuantity" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-5">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                        </label>
                                                        <div class="col-lg-4 d-flex">
                                                            <asp:Button ID="btnAddDetails" Text="Add Details" class="btn btn-green btn-rounded" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label"></label>
                                                        <div class="col-lg-6 d-flex">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVLegalDept" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Instrument type" DataField="CFOLMI_INSTRTYPE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Class" DataField="CFOLMI_INSTRCLASS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Capacity" DataField="CFOLMI_INSTRCAPACITY" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Make" DataField="CFOLMI_INSTRMAKE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Model" DataField="CFOLMI_INSTRMODELNO" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Serial No" DataField="CFOLMI_INSTRSLNO" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Product" DataField="CFOLMI_INSTRPRODUCT" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Quantity" DataField="CFOLMI_INSTRQUANTITY" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />


                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>

                                    </div>


                                    <div class="col-md-12 text-right mt-2 mb-2">

                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
