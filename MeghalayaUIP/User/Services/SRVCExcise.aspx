<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCExcise.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCExcise" %>

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
                    <li class="breadcrumb-item"><a href="SRVCUserDashboard.aspx">Other Services</a></li>
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
                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Brand Details</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of Brand*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNameBrand" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
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
                                        </div>
                                        <div class="col-md-12 d-flex justify-content-center">
                                            <div class="col-md-2 text-center">
                                                <asp:Button ID="btnBrand" Text="Add Brand Details" OnClick="btnBrand_Click" class="btn btn-rounded btn-green btn-sm" runat="server" Width="140px" />
                                            </div>
                                        </div>
                                        <br />

                                        <div class="col-md-12 d-flex justify-content-center">
                                            <asp:GridView ID="GVBrand" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table table-bordered" ForeColor="#333333"
                                                GridLines="None" OnRowDeleting="GVBrand_RowDeleting"
                                                Width="100%" EnableModelValidation="True" Visible="false">
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:BoundField DataField="SRVCEBD_NAMEOFBRAND" HeaderText="Name of Brand" />
                                                    <asp:BoundField DataField="SRVCEBD_STRENGTH" HeaderText="Strength(Alcohol Content)" />
                                                    <asp:BoundField DataField="SRVCEBD_SIZE" HeaderText="Size" />
                                                    <asp:BoundField DataField="SRVCEBD_NUMBEROFBOTTLES" HeaderText="No. of bottles(in one case)" />
                                                    <asp:BoundField DataField="SRVCEBD_MRPRS" HeaderText="MRP (Rs.)" />
                                                    <asp:BoundField DataField="SRVCEBD_BULKLITER" HeaderText="Bulk liter (in one case)" />
                                                    <asp:BoundField DataField="SRVCEBD_LANDONPROOF" HeaderText="London Proof liter (in one case)" />
                                                    <asp:BoundField DataField="SRVCEBD_BOTTLEPLANT" HeaderText="Name & address of Distillery/ Brewery/Winery/Bottling Plant" />
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" ItemStyle-BackColor="white" ItemStyle-ForeColor="WindowText" />
                                                </Columns>
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>
                                        <br />

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">The Country of Origin of the Liquor *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlCountry" class="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Applying for Registration for BIO Brand?  *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblBIOBrand" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblMRPRS_SelectedIndexChanged">
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

                                        <div class="col-md-12 d-flex">
                                        </div>

                                        <div class="col-md-12 d-flex justify-content-center">
                                            <div class="form-group row">
                                                <div class="col-lg-12 d-flex">
                                                    <asp:Button ID="BtnCountry" Text="Add Details" OnClick="BtnCountry_Click" class="btn btn-rounded btn-green btn-sm" runat="server" Width="110px" />
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex justify-content-center">
                                            <asp:GridView ID="GvLiquor" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table table-bordered" ForeColor="#333333"
                                                GridLines="None" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GvLiquor_RowDeleting">
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>

                                                     <asp:BoundField DataField="SRVCELD_COUNTRYID" HeaderText="Country of Origin" />
                                                    <asp:BoundField DataField="SRVCELD_APPLYREGBIOBRAND" HeaderText="Bio Brand" />
                                                    <asp:BoundField DataField="SRVCELD_BRANDNAME" HeaderText="Name of Brand" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="white" ItemStyle-ForeColor="WindowText" />
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="white" ItemStyle-ForeColor="WindowText" ControlStyle-CssClass="btn btn-danger" />
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
                                            <div class="col-md-6" id="divBrands" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">a. Original Year of Registration- From Date :</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox runat="server" ID="txtFromDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex" id="divTodateReg" runat="server" visible="false">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">b. To Date :</label>
                                                    <div class="col-lg-4 d-flex">
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


                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Aim and Object Details</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">The aims and object must be Literally , Social , Cultural , Educational , Charitable and Scientific</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Aim*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAim" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Object *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtObject" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <div class="col-md-2 text-center">
                                                        <asp:Button ID="btnAim" Text="Add" OnClick="btnAim_Click" class="btn btn-rounded btn-green btn-sm" runat="server" Width="140px" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>                                                                            

                                        <div class="col-md-12 d-flex justify-content-center">
                                            <asp:GridView ID="GVAIM" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table table-bordered" ForeColor="#333333"
                                                GridLines="None" OnRowDeleting="GVAIM_RowDeleting"
                                                Width="100%" EnableModelValidation="True" Visible="false">
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:BoundField DataField="SRVCAD_AIM" HeaderText="Aim" />
                                                    <asp:BoundField DataField="SRVCAD_OBJECT" HeaderText="Object" />
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" ItemStyle-BackColor="white" ItemStyle-ForeColor="WindowText" />
                                                </Columns>
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Member Details</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Designation  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDesignation" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Occupation (in real life) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtOccupation" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Address (as per EPIC) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAddressEPIC" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">State   *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtState" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">District  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDistrict" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mobile No *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMobileno" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" MaxLength="10" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex justify-content-center">
                                            <div class="col-md-2 text-center">
                                                <asp:Button ID="btnMembers" Text="Add" OnClick="btnMembers_Click" class="btn btn-rounded btn-green btn-sm" runat="server" Width="140px" />
                                            </div>
                                        </div>
                                        <br />

                                        <div class="col-md-12 d-flex justify-content-center">
                                            <asp:GridView ID="GVMember" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table table-bordered" ForeColor="#333333"
                                                GridLines="None" OnRowDeleting="GVMember_RowDeleting"
                                                Width="100%" EnableModelValidation="True" Visible="false">
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:BoundField DataField="SRVCEMD_NAME" HeaderText="Name" />
                                                    <asp:BoundField DataField="SRVCEMD_DESIGNATION" HeaderText="Designation" />
                                                    <asp:BoundField DataField="SRVCEMD_OCCUPATION" HeaderText="Occupation (in real life)" />
                                                    <asp:BoundField DataField="SRVCEMD_ADDRESS" HeaderText="Address (as per EPIC)" />
                                                    <asp:BoundField DataField="SRVCEMD_STATE" HeaderText="State" />
                                                    <asp:BoundField DataField="SRVCEMD_DISTRICT" HeaderText="District" />
                                                    <asp:BoundField DataField="SRVCEMD_MOBILENO" HeaderText="Mobile" />
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" ItemStyle-BackColor="white" ItemStyle-ForeColor="WindowText" />
                                                </Columns>
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>


                                        <div class="col-md-12 d-flex mt-2 mb-2 justify-content-end">
                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg mr-2" Width="150px" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" OnClick="btnsave_Click" />
                                            <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg ml-2" Width="150px" />

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
