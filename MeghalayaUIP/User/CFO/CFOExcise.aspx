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
                    <div class="row">
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
                                                            <asp:TextBox ID="txttradeLic" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtexciselaw" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtDetails" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Strength(Alcohol Content)  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtStrength" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Size*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtSize" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">No. of bottles (in one case)*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtBottle" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">MRP (Rs.) *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtMRP" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Bulk liter (in one case)*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtBulkLiter" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">London Proof liter (in one case)*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLandonProof" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Name & address of Distillery/ Brewery/Winery/Bottling Plant*</label>
                                                        <div class="col-lg-4 d-flex">
                                                            <asp:TextBox ID="txtBottlePlant" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtBrandName" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtAddress" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
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
    </asp:UpdatePanel>
</asp:Content>
