<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFELandDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFELandDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <div class="page-wrapper">

        <div class="content container-fluid">

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Enterprise Location Details</h4>
                        </div>
                        <div class="card-body">
                            <!-- <h4 class="card-title">Personal Information</h4> -->
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
                                <h3 class="card-title ml-4">Location of the Unit</h3>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Survey No/Plot *</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtSurveyno" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. District</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Text="Select District" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. Mandal</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Text="Select Mandal" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4. Village/Town</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                    <asp:ListItem Text="Select Village" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">5. Name of Grampanchayat*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtGrampanchayat" runat="server" class="form-control" onkeypress="return validateNames(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">6. Pincode</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtpincode" runat="server" class="form-control" onkeypress="return validatePincode(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">7. Tel No(Landline)(If available)</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLandline" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">8. Total Extent of Site Area as Per Documents(in Sq. mts)</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtSiteArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">9. Type of Building</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlBuildingType" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">10. Land Use as per Master Plan*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlLandplan" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">11. Proposed Area for Development(in Sq. mts)*</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtDevelopmentArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">12. Total Built up Area(in Sq. mts)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtBuiltUpArea" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">13. Height of the Building(In mtrs)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtBuildingHeight" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">14. Existing Width of Approach Road(in feet)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtExstngWidth" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">15. Type of Approach Road*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlApproachRoad" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">16. Land Location falls under*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddllandlocation" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">17. Building Approval*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlBuildingApproval" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">18. Please Select Line of Activity</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlLineofActivity" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">19.PCB Category of Industry</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPCBCategory" runat="server" class="form-control" ></asp:TextBox>                                               
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">20. 	Affected in Road Widening*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:RadioButtonList ID="rblAffectedroad" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="1" />
                                                    <asp:ListItem Text="No" Value="2" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">21. Is land part of*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlland" runat="server" class="form-control">
                                                    <asp:ListItem Text="Select" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-12 mt-4 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1.	Architect License No.*</label>
                                            <div class="col-lg-6 d-flex">

                                                <asp:TextBox ID="txtArchitectLicNo" runat="server" class="form-control"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2.	Architect Name*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtArchitectName" runat="server" class="form-control" onkeypress="return validateNames(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3.	Architect Mobile No.*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtArchitectMobileno" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 mt-4 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1.	Structural Engineer Name</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtStrEngnrName" runat="server" class="form-control" onkeypress="return validateNames(event)"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2	Structural Mobile No</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtStrEngnrMobileno" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3.	Structural License No.</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtStrLicNo" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-12 mt-3 d-flex upload">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-8">1 	Architectural dwg. in Pre-DCR</label>
                                            <div class="col-md-4">
                                                <asp:FileUpload ID="fupArchitechDwg" runat="server" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <button type="button" class="btn btn-rounded btn-dark">Upload</button>
                                    </div>
                                </div>

                                <div class="col-md-12 mt-3 d-flex upload">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-8">2 	Common Affidavit <a href="#">Common Affidavit Form</a></label>
                                            <div class="col-md-4">
                                                <asp:FileUpload ID="fupAffidavit" runat="server" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <button type="button" class="btn btn-rounded btn-dark">Upload</button>
                                    </div>
                                </div>


                                <div class="col-md-12 d-flex mt-2">
                                    <div class="col-md-6">


                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn  btn-info btn-lg" OnClick="btnPreviuos_Click" />
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" class="btn btn-rounded btn-info btn-lg" padding-right="10px" BackColor="Green" />


                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn  btn-info btn-lg" OnClick="btnNext_Click" />

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
