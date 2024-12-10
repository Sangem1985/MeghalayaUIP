<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="LAQuestionnaire.aspx.cs" Inherits="MeghalayaUIP.User.LA.LAQuestionnaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
    function handleKeyUp(input) {
        if (input.value.trim() === "") {
            input.style.border = "2px solid red";
        } else {
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
    </script>
    <div class="page-wrapper" id="divText" runat="server">
        <div class="content container-fluid">

            <div class="row">
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
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">APPLICATION FORM FOR ALLOTMENT OF LAND/INDUSTRIAL SHED</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 600; font-size: 20px;">Project Details</span></label>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                1. Firm Name</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtUnitName" runat="server" class="form-control" onkeypress="return Names()" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                2. District
                                            </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" onchange="validateDropdown(this)">
                                                    <asp:ListItem Text="Select District" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. Mandal</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" onchange="validateDropdown(this)">
                                                    <asp:ListItem Text="Select Mandal" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4. Village</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control" onchange="validateDropdown(this)">
                                                    <asp:ListItem Text="Select Village" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <hr />
                                <div class="col-md-12 d-flex mt-3">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 600; font-size: 20px;">Name of the Industrial Estate/Industrial Area/Export Promotion Industrial Park/Industrial Growth Centre where land/shed is required</span></label>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Name of the industrial park*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlname" runat="server" class="form-control" onchange="validateDropdown(this)">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. Quantum of land required (in square metres) *</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtQuantum" runat="server" class="form-control" Type="text" onkeypress="return NumberOnly()" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. No's. of sheds required  *</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtSheds" runat="server" class="form-control" Type="text" onkeypress="return NumberOnly()" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex mt-3">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 600; font-size: 20px;">Proposed items for manufacturing</span></label>
                                </div>


                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Name of products*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtNameProduct" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. Annual manufacturing capacity (in tonne)*</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtAnnualManu" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. Appox. value (₹)*</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtAppox" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex justify-content-end">
                                    <asp:Button ID="btnAddManu" runat="server" Text="Add More" OnClick="btnAddManu_Click" CssClass="btn btn-green btn-rounded mt-2 mb-4 mr-4" Width="110px" />
                                </div>
                                <div class="justify-content-center" style="margin-left: 0%;">
                                    <div class="col-md-12 justify-content-center">
                                        <asp:GridView ID="GVManu" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-responsive GRD table table-bordered table-striped table-hover" ForeColor="#333333"
                                            GridLines="None" Width="80%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVManu_RowDeleting">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Status" ItemStyle-Width="100px" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ControlStyle-CssClass="btn btn-danger btn-sm" ControlStyle-ForeColor="White" />
                                                <asp:BoundField HeaderText="Name of products " DataField="MD_NAMEOFPRODUCT" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="MD_ANNUALCAPACITY" ItemStyle-Width="500px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Appox. value (₹)" DataField="MD_APPROXVALUE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                            </Columns>
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex mt-3">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 600; font-size: 20px;">Proposed annual consumption of major raw material</span></label>
                                </div>


                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Name of major raw material  *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtannual" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. Annual consumption capacity (in tonne)</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtCapacity" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. Appox. value (₹ in lakh)  *</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtValue" runat="server" class="form-control" Type="text" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex justify-content-end">
                                    <asp:Button ID="btnAddraw" runat="server" Text="Add More" OnClick="btnAddraw_Click" CssClass="btn btn-green btn-rounded mt-2 mb-4 mr-4" Width="110px" />
                                </div>
                                <div class="justify-content-center" style="margin-left: 0%;">
                                    <div class="col-md-12 justify-content-center">
                                        <asp:GridView ID="GVRawMaterial" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-responsive GRD table table-bordered table-striped table-hover" ForeColor="#333333"
                                            GridLines="None" Width="90%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVRawMaterial_RowDeleting">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Status" ItemStyle-Width="100px" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ControlStyle-CssClass="btn btn-danger btn-sm" ControlStyle-ForeColor="White" />
                                                <asp:BoundField HeaderText="Name of major raw material" DataField="RD_NAMEOFRAWMATERIAL" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RD_ANNUALCONSUMPTIONCAPACITY" ItemStyle-Width="500px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RD_APPOX" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                            </Columns>
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <hr />
                                <div class="col-md-12 d-flex mt-3">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 600; font-size: 20px;">Power requirement</span></label>
                                </div>


                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Quantum of energy/load required (in KW) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEnergyLoad" runat="server" class="form-control" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. Proposed source of energy/load</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlSourceLoad" runat="server" class="form-control" onchange="validateDropdown(this)">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex justify-content-end">
                                    <asp:Button ID="btnAddPower" runat="server" Text="Add More" OnClick="btnAddPower_Click" CssClass="btn btn-green btn-rounded mt-2 mb-4 mr-4" Width="110px" />
                                </div>
                            </div>
                            <div class="justify-content-center" style="margin-left: 0%;">
                                <div class="col-md-12 justify-content-center">
                                    <asp:GridView ID="GVPOWER" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-responsive GRD table table-bordered table-striped table-hover" ForeColor="#333333"
                                        GridLines="None" Width="60%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVPOWER_RowDeleting">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Status" ItemStyle-Width="100px" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ControlStyle-CssClass="btn btn-danger btn-sm" ControlStyle-ForeColor="White" />
                                            <asp:BoundField HeaderText="Quantum of energy/load required (in KW)" DataField="PD_QUANTUMENERGYLOAD" ItemStyle-Width="400px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Proposed source of energy/load" DataField="PD_ENERGYLOAD" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <hr />
                            <div class="col-md-12 d-flex mt-3">
                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 600; font-size: 20px;">Proposed requirement of water for manufacturing</span></label>
                            </div>

                            <div class="col-md-12 d-flex">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">1. Proposed requirement of water for manufacturing *</label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtWaterManu" runat="server" class="form-control" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">2. Proposed source of water</label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:DropDownList ID="ddlSourcewater" runat="server" class="form-control" onchange="validateDropdown(this)">
                                                <asp:ListItem Text="--Select--" Value="0" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-12 d-flex justify-content-end">
                                <asp:Button ID="btnAdded" runat="server" Text="Add More" OnClick="btnAdded_Click" CssClass="btn btn-green btn-rounded mt-2 mb-4" Width="110px" />
                            </div>
                            <div class="col-md-12 d-flex justify-content-left">
                                <asp:GridView ID="GVWATER" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-responsive GRD table table-bordered table-striped table-hover" ForeColor="#333333"
                                    GridLines="None" Width="80%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVWATER_RowDeleting">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <RowStyle BackColor="#ffffff" />
                                    <Columns>
                                        <asp:CommandField HeaderText="Status" ItemStyle-Width="100px" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ControlStyle-CssClass="btn btn-danger btn-sm" ControlStyle-ForeColor="White" />
                                        <asp:BoundField HeaderText="Proposed requirement of water for manufacturing" DataField="WD_REQWATER" ItemStyle-Width="600px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                        <asp:BoundField HeaderText="Proposed source of water" DataField="WD_SOURCEOFWATER" ItemStyle-Width="400px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                    </Columns>
                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </div>
                            <hr />
                            <div class="col-md-12 d-flex mt-3">
                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 600; font-size: 20px;">Means of finance (₹ in lakh)</span></label>
                            </div>

                            <div class="col-md-12 d-flex">
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">1. Equity*</label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtEquity" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">2. Term Loan from Bank/FI </label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtTermLoan" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">3. Unsecured loan *</label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtUnsecured" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 d-flex">
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">4. Internal resources *</label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtInternal" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">5. Any other source</label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtothersource" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">6. Total</label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtTotal" runat="server" class="form-control" onkeypress="return NumberOnly()" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="col-md-12 d-flex mt-3">
                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 600; font-size: 20px;">Other Details</span></label>
                            </div>

                            <div class="col-md-12 d-flex">
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">1. Category of the enterprise*</label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:DropDownList ID="ddlEnterprise" runat="server" class="form-control" onchange="validateDropdown(this)">
                                                <asp:ListItem Text="--Select--" Value="0" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">2. Plant & Machinery (₹ in lakh)* </label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtPMLakh" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">3. Total project cost (₹ in lakh)*</label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtprojectCost" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 d-flex">
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">4. Details of waste/effluent to be generated</label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtGenerated" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12 text-right mb-3">
                                <asp:Button ID="btnPrevious" runat="server" Text="Previous" class="btn btn-rounded btn-info btn-lg" Width="150px" Visible="false" />
                                <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" class="btn btn-rounded btn-submit btn-lg" Width="150px" />
                                <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-rounded btn-info btn-lg" Width="150px" Visible="false" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
