<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOExcise.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOExcise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.4.7/dist/sweetalert2.all.min.js"></script>
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

                    <li class="breadcrumb-item active" aria-current="page">Excise Department Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" id="divText" runat="server">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Excise Department</h4>
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
                                        <div id="div_45_AplicntDtls" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Applicant Details</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label">1. Are you citizen of India as defined in Article 5 to 8 of the Constitution of India? *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblArtical5" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label">2. Has the applicant/ you have has held individual/jointly held one/multiple shop/s or any other excise license? (Provide Details if yes) *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblapplicant" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label">3. Whether applicant’s direct family member/dependents have held individual/jointly held one/multiple shop/s or any other excise license? (Provide Details if yes) *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblMember" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label">4. Are you/applicant an Income Tax Payer? *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblTax" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label">5. Do you/Applicant pay Sales Tax? *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblsaletax" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label">6. Do you/Applicant pay Professional Tax? *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblprofession" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label">7. Are you/applicant in any way related to a Government official working in Excise Department? *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblgoverment" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblgoverment_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex" id="Excisedept" runat="server" visible="false">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">Provide Details Here (if working) :</label>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:TextBox ID="txttradeLic" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label">8. Have you/applicant been punished or penalized or convicted for violation of any Excise laws/rules/orders? *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblviolation" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblviolation_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex" id="txtlaw" runat="server" visible="false">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Provide Details Here (if punished or penalized or convicted for violation of any Excise laws/rules/orders) :</label>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:TextBox ID="txtexciselaw" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label">9. Have You/applicant has ever been convicted by Court of Law for a non bailable offence? *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblConvicted" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblConvicted_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex" id="convictedlaw" runat="server" visible="false">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Provide Details Here (if convicted by Court of Law for a non bailable offence) :</label>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:TextBox ID="txtDetails" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="div_47_BLR" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Brand Details</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name of Brand*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Strength(Alcohol Content)  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtStrength" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Size*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtSize" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">No. of bottles (in one case)*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtBottle" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">MRP (Rs.) *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtMRP" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Bulk liter (in one case)*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtBulkLiter" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">London Proof liter (in one case)*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLandonProof" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Name & address of Distillery/ Brewery/Winery/Bottling Plant*</label>
                                                        <div class="col-lg-4 d-flex">
                                                            <asp:TextBox ID="txtBottlePlant" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="200" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <asp:Button ID="btnAdd" OnClick="btnAdd_Click" Text="Add Details" class="btn btn-rounded btn-green btn-sm" runat="server" Width="110px" />
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="gvBrandDetails" OnRowDeleting="gvBrandDetails_RowDeleting" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table table-bordered" ForeColor="#333333"
                                                    GridLines="None"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <%--<Columns>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="NameofBrand" DataField="" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:TemplateField HeaderText="Name of Brand">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNameofBrand" runat="server" Text="<%#Eval("NameOfBrand") %>" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Strength(Alcohol Content)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStrength" runat="server" Text="<%#Eval("Strength") %>" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Size">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSize" runat="server" Text="<%#Eval("Size") %>" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No. of bottles(in one case)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNumberOfBottles" runat="server" Text="<%#Eval("NumberOfBottles") %>" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MRP (Rs.)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMRPRs" runat="server" Text="<%#Eval("MRPRs") %>" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Bulk liter (in one case)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBulkLiter" runat="server" Text="<%#Eval("BulkLiter") %>" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="London Proof liter (in one case)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLandOnProof" runat="server" Text="<%#Eval("LandOnProof") %>" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name & address of Distillery/ Brewery/Winery/Bottling Plant">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBottlePlant" runat="server" Text="<%#Eval("BottlePlant") %>" ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                        </Columns>--%>
                                                    <Columns>

                                                        <asp:BoundField DataField="NameOfBrand" HeaderText="Name of Brand" />
                                                        <asp:BoundField DataField="Strength" HeaderText="Strength(Alcohol Content)" />
                                                        <asp:BoundField DataField="Size" HeaderText="Size" />
                                                        <asp:BoundField DataField="NumberOfBottles" HeaderText="No. of bottles(in one case)" />
                                                        <asp:BoundField DataField="MRPRs" HeaderText="MRP (Rs.)" />
                                                        <asp:BoundField DataField="BulkLiter" HeaderText="Bulk liter (in one case)" />
                                                        <asp:BoundField DataField="LandOnProof" HeaderText="London Proof liter (in one case)" />
                                                        <asp:BoundField DataField="BottlePlant" HeaderText="Name & address of Distillery/ Brewery/Winery/Bottling Plant" />
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">The Country of Origin of the Liquor *</label>
                                                        <div class="col-lg-6 d-flex">

                                                            <asp:DropDownList runat="server" ID="ddlCountry" class="form-control">
                                                                <%--<asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Value="001">country1</asp:ListItem>
                                                        <asp:ListItem Value="002">Country2</asp:ListItem>--%>
                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">MRP (Rs.) *</label>
                                                        <div class="col-lg-6">
                                                            <asp:RadioButtonList ID="rblMRPRS" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblMRPRS_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" id="MRPGRID" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name of Brand :</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtBrandName" runat="server" class="form-control" onkeypress="return Names(event)" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex justify-content-left">

                                                <div class="form-group row">

                                                    <div class="col-lg-12 d-flex">
                                                        <asp:Button ID="AddBtn" OnClick="AddBtn_Click" Text="Add Details" class="btn btn-rounded btn-green btn-sm" runat="server" Width="110px" />
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GvLiquor" runat="server" AutoGenerateColumns="False" BorderColor="#003399" OnRowDeleting="GvLiquor_RowDeleting"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table table-bordered" ForeColor="#333333"
                                                    GridLines="None" Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>

                                                        <asp:BoundField DataField="CountryName" HeaderText="Country of Origin" />
                                                        <asp:TemplateField HeaderText="MRP (Rs.)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMRPSSelection" runat="server" Text='<%# Eval("MRPSSelection").ToString() == "Y" ? "Yes" : "No" %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="BrandName" HeaderText="Name of Brand" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                            <div class="col-md-12 d-flex" style="margin-top: 20px">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Applying for Renewal of BIO Brands? *</label>
                                                        <div class="col-lg-6">
                                                            <asp:RadioButtonList ID="rblBrand" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblBrand_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6" id="Brands" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">a. Original Year of Registration- From Date :</label>
                                                        <div class="col-lg-4 d-flex">
                                                            <%--<asp:TextBox ID="txtFromDate" runat="server" class="form-control" Type="Date"></asp:TextBox>--%>

                                                            <asp:TextBox runat="server" ID="txtFromDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex" id="TodateReg" runat="server" visible="false">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">b. To Date :</label>
                                                        <div class="col-lg-4 d-flex">
                                                            <%--  <asp:TextBox ID="txtTodate" runat="server" class="form-control" Type="Date"></asp:TextBox>--%>

                                                            <asp:TextBox runat="server" ID="txtTodate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtTodate"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">c. Name and address of the Firm :*</label>
                                                        <div class="col-lg-4 d-flex">
                                                            <asp:TextBox ID="txtAddress" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <h4 class="card-title ml-3">Upload Below Documents</h4>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Noc From Local Area Authority Provisional Recognition *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupTribal" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnTribal" OnClick="btnTribal_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypTribal" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblTribal" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2.NoC from: a. Municipal Board (if within municipal area) b. From Market/ Bazzar Committee (if within market baazar area)  *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupQualification" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnQualification" OnClick="btnQualification_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypQualification" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblQualification" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3.Professional tax clearance certificate (From Autonomous District Council) *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupSpecimen" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnSpecimen" OnClick="btnSpecimen_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypSpecimen" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblSpecimen" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.Sales tax clearance Certificate (From Meghalaya Taxation Department)   *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupHeadman" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnHeadman" OnClick="btnHeadman_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypHeadman" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblHeadman" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">5.Income tax return for last three year   *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupTenancy" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnTenancy" OnClick="btnTenancy_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypTenancy" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblTenancy" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">6.Financial Capacity Certificate (From any bank or financial institution)*</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupRegistration" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnRegistration" OnClick="btnRegistration_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypRegistration" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblRegistration" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">7. Age Proof (Birth Certificate/ School leaving Certificate)  *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupPharmacist" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnPharmacist" OnClick="btnPharmacist_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypPharmacist" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblPharmacist" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">8.Educational Qualification Certificates   *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupQualificationcertificate" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnQualificationcertificate" OnClick="btnQualificationcertificate_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypQualificationcertificate" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblQualificationcertificate" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">9.Marriage Certificate (If Married)   *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupsiteplan" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnsiteplan" OnClick="btnsiteplan_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypsiteplan" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblsiteplan" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">10. Scheduled Tribe/ Caste Certificate   *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupCompetentperson" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnCompetentperson" OnClick="btnCompetentperson_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypCompetentperson" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblCompetentperson" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">11.Trade Licence/ Factories Licence  *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fuppharmacistlist" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnpharmacistlist" OnClick="btnpharmacistlist_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hyppharmacistlist" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblpharmacistlist" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12. Non-Encumbrance Certificate   *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupundertaking1" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnundertaking1" OnClick="btnundertaking1_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypundertaking1" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblundertaking1" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">13.Excise licence held individually/jointly for one/multiple shop/s (Current and Previous)  *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupundertaking2" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnundertaking2" OnClick="btnundertaking2_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypundertaking2" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblundertaking2" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">14.Excise licence held by direct family member/ dependant individually/jointly for one/multiple shop/s (Current and Previous) 18. Meghalaya Pollution Control Board Clearance  *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupstaff" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnstaff" OnClick="btnstaff_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypstaff" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblstaff" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">15. Single Window Agency Clearance    *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupagencyClearance" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnagencyClearance" OnClick="btnagencyClearance_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypagencyClearance" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblagencyClearance" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">16.Detailed Project Report  *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupProjectReport" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnProjectReport" OnClick="btnProjectReport_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypProjectReport" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblProjectReport" runat="server" />
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex mt-2 mb-2 justify-content-end">

                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" OnClick="btnPreviuos_Click" class="btn btn-rounded btn-info btn-lg mr-2" Width="150px" />
                                            <asp:Button ID="btnsave" OnClick="btnsave_Click" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" Text="Next" runat="server" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg ml-2" Width="150px" />

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
            <asp:PostBackTrigger ControlID="btnTribal" />
            <asp:PostBackTrigger ControlID="btnQualification" />
            <asp:PostBackTrigger ControlID="btnSpecimen" />
            <asp:PostBackTrigger ControlID="btnHeadman" />
            <asp:PostBackTrigger ControlID="btnTenancy" />
            <asp:PostBackTrigger ControlID="btnRegistration" />
            <asp:PostBackTrigger ControlID="btnPharmacist" />
            <asp:PostBackTrigger ControlID="btnQualificationcertificate" />
            <asp:PostBackTrigger ControlID="btnsiteplan" />
            <asp:PostBackTrigger ControlID="btnCompetentperson" />
            <asp:PostBackTrigger ControlID="btnpharmacistlist" />
            <asp:PostBackTrigger ControlID="btnundertaking1" />
            <asp:PostBackTrigger ControlID="btnundertaking2" />
            <asp:PostBackTrigger ControlID="btnstaff" />
            <asp:PostBackTrigger ControlID="btnagencyClearance" />
            <asp:PostBackTrigger ControlID="btnProjectReport" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
