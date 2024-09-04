<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOLegalMeterology.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOLegalMeterology" %>

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
                    <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Pre-Operational</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Legal Metrology Department Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Legal Metrology Department</h4>
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
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Instrument Details:</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Instrument type *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtinstrment" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Class  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtClass" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Capacity  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtCapacity" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Make *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMake" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Model  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtModel" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Serial No.  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtSerial" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Product</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtProduct" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Quantity  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtQuantity" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                    </label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:Button ID="btnAddDetails" Text="Add Details" class="btn btn-green btn-rounded" runat="server" OnClick="btnAddDetails_Click" />
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
                                                GridLines="None" OnRowDeleting="GVLegalDept_RowDeleting"
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
                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Other Details:</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of establishment</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%-- <asp:TextBox ID="txtESTDate" runat="server" class="date form-control" type="text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtESTDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtESTDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">Have you obtain any current registration number of factory/ shop/ establishment?  *</label>
                                                    <div class="col-lg-3">
                                                        <asp:RadioButtonList ID="rblfactory" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblfactory_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex" id="Registration" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of registration *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%--  <asp:TextBox ID="txtRegDate" runat="server" class="date form-control" type="text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtRegDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtRegDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Current registration number   *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRegNumber" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">Have you obtain any current registration number of Municipal Trade licence/ADC?  *</label>
                                                    <div class="col-lg-3">
                                                        <asp:RadioButtonList ID="rblMunicipal" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblMunicipal_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="ADCLicense" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of registration  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%--  <asp:TextBox ID="txtDate" runat="server" class="date form-control" type="text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex" id="DateReg" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Current Registration Number   *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%--  <asp:TextBox ID="txtcurrentReg" runat="server" class="date form-control" type="text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtcurrentReg" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtcurrentReg"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Is it a partnership firm?   *</label>
                                                <div class="col-lg-4">
                                                    <asp:RadioButtonList ID="rblFirm" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Is it a limited company?   *</label>
                                                <div class="col-lg-4">
                                                    <asp:RadioButtonList ID="rblLimit" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names(this)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Address  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtAddress" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="50" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Manufacturing Details</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Categories of weights and measures sold/proposed to be sold at present</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Weights: *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtWeight" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Measures:  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtMeasure" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="8"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Weighting Instruments: *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtInstruWeight" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="8"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Professional Tax registration Number: *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtTaxReg" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="8"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">GST:  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtGST" runat="server" class="form-control" onblur="validateGST(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">IT Number: *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtITNmumber" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label">Do you intend to import weights, etc. from places outside the State/Country?   *</label>
                                                <div class="col-lg-4">
                                                    <asp:RadioButtonList ID="rblState" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblState_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="State" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Licence number: *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtLICNumber" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" MaxLength="20"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4" id="Country" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Registration of Importer of Weights and Measures : *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtRegWeight" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="9"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-7 col-form-label">Whether the item (s) proposed to be manufactured will be sold within the State or out side the state or both  *</label>
                                                <div class="col-lg-5">
                                                    <asp:RadioButtonList ID="rblstateside" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Within State" Value="Y" />
                                                        <asp:ListItem Text="Outside State" Value="N" />
                                                        <asp:ListItem Text="Both" Value="3" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-8">
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
                                        <div class="col-md-4" id="DealerLic" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Give details : *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtGiveDetails" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">The number of persons employed/proposed to be employed</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Skilled: </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtskilled" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="9" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Semi-skilled: </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtsemiskilled" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" MaxLength="9"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Unskilled: *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtunskilled" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" MaxLength="9"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Specialist trained in the line: </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txttrained" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="10" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-9 col-form-label">Details of machinery, tools accessories, owned and used for manufacturing weights measures etc:</label>
                                                <div class="col-lg-3 d-flex">
                                                    <asp:TextBox ID="txtmanuowned" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Details of foundry/workshop facilities arranged Whether ownership, long term lease etc :*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtownership" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Facilities of steel casting and hardness testing Vital parts etc or other means: </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtsteel" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Availability of electric energy  *</label>
                                                <div class="col-lg-4">
                                                    <asp:RadioButtonList ID="rblelectric" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Have you applied previously for a manufacturer's licence? *</label>
                                                <div class="col-lg-3">
                                                    <asp:RadioButtonList ID="rblLicdealer" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLicdealer_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="applieddealer" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Give Details </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtDetails" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">

                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Do you received any loan from Government or financial Institution? *</label>
                                                <div class="col-lg-4">
                                                    <asp:RadioButtonList ID="rblInstitute" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblInstitute_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="NameBanker" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of bankers * </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtBanker" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="DetailsGet" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Give Details </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtGetDetails" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-12 d-flex">

                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Have you sufficient stock of loan/test weights. etc.? *</label>
                                                <div class="col-lg-4">
                                                    <asp:RadioButtonList ID="rblLoan" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLoan_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="weightloan" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Give Details </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtDetailsGET" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Have you applied previously for a repairer's licence? *</label>
                                                <div class="col-lg-4">
                                                    <asp:RadioButtonList ID="rblRepaire" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblRepaire_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="License" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">When and with what results?  </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtResults" runat="server" class="form-control" onkeypress="return Names(this)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                      <h4 class="card-title ml-3">Upload Below Documents</h4>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">1.Letter of Consent from the Manufacturer who wish to appoint you as a Dealer *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupLetter" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnTaxClearance" OnClick="btnTaxClearance_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypTaxClearance" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <div class="col-lg-1 d-flex">
                                                    <asp:Label ID="lblTaxClearance" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">2.Manufacturing Licence if you intend to import weights & measures from outside the State *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupGSTREG" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnGSTREG" OnClick="btnGSTREG_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypGSTREG" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <div class="col-lg-1 d-flex">
                                                    <asp:Label ID="lblGSTREG" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">3.Model Approval Certificate of weights and measures to be deal with. *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupWeightdeal" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnLabourLic" OnClick="btnLabourLic_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypLabourLic" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblLabourLic" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">4.Documentary proof of ownership / Lease agreement of Premises.  *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupLease" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnTribals" OnClick="btnTribals_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypLease" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblLease" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">5.GST Registration Certificate.  *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupGSTReg" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnTradeLic" OnClick="btnTradeLic_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypGSTReg" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblGSTReg" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">6.Professional Tax Certificate.  *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupTax" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnCastefirms" OnClick="btnCastefirms_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypTax" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblTax" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">7.Labour Licence.   *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupLabour" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnattorney" OnClick="btnattorney_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypLabour" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblLabour" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">8.Trade Licence from respective ADC in case of Non Tribal.   *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupADC" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnLastissued" OnClick="btnLastissued_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypADC" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblADC" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 text-right mt-2 mb-2">

                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" OnClick="btnPreviuos_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                        <asp:Button ID="btnNext" Text="Next" runat="server" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
            <asp:PostBackTrigger ControlID="btnTaxClearance" />
            <asp:PostBackTrigger ControlID="btnGSTREG" />
            <asp:PostBackTrigger ControlID="btnLabourLic" />
            <asp:PostBackTrigger ControlID="btnTribals" />
            <asp:PostBackTrigger ControlID="btnTradeLic" />
            <asp:PostBackTrigger ControlID="btnCastefirms" />
            <asp:PostBackTrigger ControlID="btnattorney" />
            <asp:PostBackTrigger ControlID="btnLastissued" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
