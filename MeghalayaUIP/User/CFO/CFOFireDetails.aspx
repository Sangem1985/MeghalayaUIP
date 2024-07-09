<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOFireDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOFireDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
     <nav aria-label="breadcrumb">
										<ol class="breadcrumb mb-0">
											<li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                                            <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Pre-Operational</a></li>
											
											<li class="breadcrumb-item active" aria-current="page">Fire Details</li>
										</ol>
									</nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Fire Details</h4>
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
                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Service Specific Details</span></label>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of Business/Building *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-8 col-form-label">Category of Building for which Fire Clearance is applied  *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlCategory" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Fee Amount (Note: This is an approx. value. The amount may change tentatively)*</label>
                                            <div class="col-lg-2 d-flex">
                                                <asp:TextBox ID="txtFeeAmount" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Location of Building/ Premises:</span></label>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">District</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select District" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
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
                                            <label class="col-lg-6 col-form-label">Village/Town</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                    <asp:ListItem Text="Select Village" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Locality</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLandline" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Nearest Landmark</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtSitArea" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Pincode</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPincode" runat="server" class="form-control" onkeypress="return validatePincode(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Plot Area (in Sq m)</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPlotAREA" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Proposed Drive way (Breadth [in meters]) </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtBreadth" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Build up Area (in Sq m)</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtBuildupArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Existing or proposed Approach Road (L x B [in meters]) *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtExisting" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Details of surrounding occupancies and their probable distance from the proposed building:</span></label>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1 (a). East *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEast" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-8 col-form-label">1 (a). Distance from proposed Building (in meters) *  *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtDistEast" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1 (b). West *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtWest" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-8 col-form-label">1 (b). Distance from proposed Building (in meters)*</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtDistWest" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1 (c). North   *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtNorth" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-8 col-form-label">1 (c). Distance from proposed Building (in meters) *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtDistNorth" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1 (d). South *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtSouth" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-8 col-form-label">1 (d). Distance from proposed Building (in meters)   *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtDistSouth" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Distance from the nearest Fire Station (in meters)*</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtFire" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 text-right mt-2 mb-2">

                                    <asp:Button Text="Previous" runat="server" ID="btnPreviuos" OnClick="btnPreviuos_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" OnClick="btnsave_Click"  Width="150px"/>
                                    <asp:Button ID="btnNext" Text="Next" runat="server" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>

</asp:Content>
