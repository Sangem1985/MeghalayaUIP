<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCLegalMeterology.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCLegalMeterology" %>

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
                                        <div id="divManfReprDlr" runat="server" visible="true">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Workshop Details:</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. District </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" TabIndex="1" onchange="validateDropdown(this)">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Mandal *</label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" TabIndex="1">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Village *</label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="ddlVillage" runat="server" class="form-control" TabIndex="1">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Nearest landmark: </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtTaxReg" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5. Police Station:  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtGST" runat="server" class="form-control" onblur="validateGST(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">6.Post Office/Outpost: *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtITNmumber" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">7.Pincode : *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox1" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Other Details:</span></label>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">7. Date of Establishment of workshop/factory  *</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox runat="server" ID="TextBox2" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtRegDate"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Have you obtain any registration number of factory/ shop/ establishment? *</label>
                                                        <div class="col-lg-4">
                                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">8. Have you obtain any registration number of Municipal Trade licence/ADC?  *</label>
                                                        <div class="col-lg-4">
                                                            <asp:RadioButtonList ID="rblMunicipal" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex" id="Registration" runat="server" visible="true">
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
                                            <div class="col-md-12 d-flex" id="ADCLicense" runat="server" visible="true">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">8a. Date of registration  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDate"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">8b. Current Registration Number   *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtcurrentReg" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtcurrentReg"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Is it a partnership firm? *</label>
                                                        <div class="col-lg-4">
                                                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
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
                                                            <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div id="divpartnership" runat="server" visible="true">
                                                <h4 class="card-title ml-3">Proprietor’s/partners Details: </h4>

                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">1. Name (s) <span class="text-danger">*</span></label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtManfItemName" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">2. Address (s)<span class="text-danger">*</span></label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtManfAnnualCapacity" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">3.Father's/ Husband's name <span class="text-danger">*</span></label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtManfValue" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7"></asp:TextBox>
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
                                                                <asp:BoundField HeaderText="Father's/ Husband's name" DataField="FATHER" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="col-md-4"></div>
                                                </div>
                                            </div>



                                            <div id="divcompany" runat="server" visible="true">
                                                <h4 class="card-title ml-3">Managing Director Details: </h4>

                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">1. Name (s) <span class="text-danger">*</span></label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="TextBox3" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">2. Address (s)<span class="text-danger">*</span></label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="TextBox4" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">3.Father's/ Husband's name <span class="text-danger">*</span></label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="TextBox5" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7"></asp:TextBox>
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
                                                        <asp:Button ID="Button1" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
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
                                                                <asp:BoundField HeaderText="Father's/ Husband's name" DataField="FATHER" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="col-md-4"></div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Manufacturing Details:</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">                                                
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Nature of manufacturing activities at present: *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox7" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-8">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">The type of weights and measures proposed to be manufactured viz</label>
                                                        <div class="col-lg-6 d-flex">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Weights: *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtWeight" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Measures:  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtMeasure" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Weighting Instruments: *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtInstruWeight" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>




                                            <div id="divManfRepr" runat="server" visible="true">
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
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Availability of electric energy  *</label>
                                                            <div class="col-lg-6">
                                                                <asp:RadioButtonList ID="rblelectric" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                    <asp:ListItem Text="No" Value="N" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%--</div>
                                            <div class="col-md-12 d-flex">--%>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Details of machinery, tools accessories, owned and used for manufacturing weights measures etc</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtmanuowned" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Details of foundry/workshop facilities arranged Whether ownership, long term lease etc*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtownership" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Facilities of steel casting and hardness testing Vital parts etc or other means: </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtsteel" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Do you received any loan from Government or financial Institution?  *</label>
                                                        <div class="col-lg-6">
                                                            <asp:RadioButtonList ID="rblFinance" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Do you received any loan from Government or financial Institution? *</label>
                                                        <div class="col-lg-4">
                                                            <asp:RadioButtonList ID="rblInstitute" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex" id="divFinanceBank" runat="server" visible="false">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name of bankers  * </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtBanker" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Give Details</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtGetDetails" runat="server" class="form-control" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">GST </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox6" runat="server" class="form-control" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Professional Tax registration Number </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox8" runat="server" class="form-control" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">IT Number</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox9" runat="server" class="form-control" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Whether the item (s) proposed to be manufactured will be sold within the State or out side the state or both  *</label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="rblstateside" class="form-control" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Within State" Value="Y" />
                                                                <asp:ListItem Text="Outside State" Value="N" />
                                                                <asp:ListItem Text="Both" Value="3" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Have you applied previously for a manufacturer's licence? *</label>
                                                        <div class="col-lg-6">
                                                            <asp:RadioButtonList ID="rblLicdealer" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" id="applieddealer" runat="server" visible="true">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Give Details </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtDetails" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                           <%-- APPROVAL ID 42--%>
                                             <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Manufacturing Details</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Weights: *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox10" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Measures:  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox11" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Weighting Instruments: *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox12" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Professional Tax Reg No: *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox13" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="8"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5. GST Reg No:  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox14" runat="server" class="form-control" onblur="validateGST(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">6.IT Number: *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox15" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="8" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                             <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Do you intend to import weights, etc. from places outside the State/Country?   *</label>
                                                        <div class="col-lg-6">
                                                            <asp:RadioButtonList ID="rblState" runat="server" onchange="validateRadioButtonList(this)" RepeatDirection="Horizontal" AutoPostBack="true">
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
                                                  <div class="col-md-4" id="Country" runat="server" visible="false">
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
                                                            <asp:RadioButtonList ID="rblDealer" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
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


                                            <div class="col-md-12 text-right mt-2 mb-2">

                                                <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                                <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                                <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
