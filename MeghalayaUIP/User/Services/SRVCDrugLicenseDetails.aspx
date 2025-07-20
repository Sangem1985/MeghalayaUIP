<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCDrugLicenseDetails.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCDrugLicenseDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        div#ContentPlaceHolder1_div_52, div#ContentPlaceHolder1_div_Staff_Manf, div#ContentPlaceHolder1_div_Staff_Test, div#ContentPlaceHolder1_div_48 {
            width: 100%;
        }
    </style>
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
                    <li class="breadcrumb-item active" aria-current="page">DrugLicense Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">DrugLicense Details</h4>
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
                                        <div id="div_39_46" runat="server" visible="true">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Application Type and Ownership Details</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <%-- <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Type of Ownership(H):   *</label>
                                               <div class="col-lg-8">
                                                <asp:RadioButtonList ID="rblOwnership" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblOwnership_SelectedIndexChanged">
                                                    <asp:ListItem Text="Proprietary" Value="1" />
                                                    <asp:ListItem Text="Partnership" Value="2" />
                                                    <asp:ListItem Text="Public Ltd Company" Value="3" />
                                                    <asp:ListItem Text="Private Ltd Company" Value="4" />                                                
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div> --%>
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Application Type(H) :   *</label>
                                                        <div class="col-lg-6">
                                                            <asp:RadioButtonList ID="rblApplication" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblApplication_SelectedIndexChanged">
                                                                <asp:ListItem Text="Wholesale" Value="W" />
                                                                <asp:ListItem Text="Retails" Value="R" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div id="divWholesale" runat="server" visible="false">
                                                <div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Name of the Competent Person / Pharmacist</span></label>
                                                </div>

                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-6">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Please Select :   *</label>
                                                            <div class="col-lg-6">
                                                                <asp:RadioButtonList ID="rblSelect" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblSelect_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Competent Person" Value="1" />
                                                                    <asp:ListItem Text="Pharmacist" Value="2" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-6" id="divCompetent" runat="server" visible="false">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">(i).Name of the Pharmacist/Competent Person </label>
                                                            <div class="col-lg-4 d-flex">
                                                                <asp:TextBox ID="txtCompetentName" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="500" TabIndex="1"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex" id="divPharmacist" runat="server" visible="false">
                                                    <div class="col-md-6">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">(iii).Valid up to date </label>
                                                            <div class="col-lg-4 d-flex">
                                                                <asp:TextBox runat="server" ID="txtValidate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtValidate"></cc1:CalendarExtender>
                                                                <i class="fi fi-rr-calendar-lines"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">(ii).Registration No </label>
                                                            <div class="col-lg-4 d-flex">
                                                                <asp:TextBox ID="txtRegNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="500" TabIndex="1"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div id="divRetail" runat="server" visible="false">
                                                <div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold">
                                                        <span style="font-weight: 900;">Name of Pharmacist</span>
                                                    </label>
                                                </div>

                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">(i).Name(s) Pharmacist  :</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtNamePharma" runat="server" class="form-control" onkeypress="return Names(event)" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">(ii).Registration No :</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtRetailRegNo" runat="server" class="form-control" onkeypress="return Names(event)" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">(iii).Valid up to date :</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox runat="server" ID="txtDateValid" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateValid"></cc1:CalendarExtender>
                                                                <i class="fi fi-rr-calendar-lines"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex justify-content-center">
                                                    <div class="form-group row">
                                                        <div class="col-lg-12 d-flex">
                                                            <asp:Button ID="btnPharmacist" Text="Add Details" OnClick="btnPharmacist_Click" class="btn btn-rounded btn-green btn-sm" runat="server" Width="110px" />
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-md-12 d-flex justify-content-center">
                                                    <asp:GridView ID="GVPharmacist" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table table-bordered" ForeColor="#333333"
                                                        GridLines="None" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVPharmacist_RowDeleting">
                                                        <RowStyle BackColor="#ffffff" />
                                                        <Columns>

                                                            <asp:BoundField DataField="SRVCDRD_NAMEPHARMACIST" HeaderText="Name Pharmacist" />
                                                            <asp:BoundField DataField="SRVCDRD_REGISTRATIONNO" HeaderText="Registration No" />
                                                            <asp:BoundField DataField="SRVCDRD_VALIDDATE" HeaderText="Valid up to date" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="white" ItemStyle-ForeColor="WindowText" />
                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="white" ItemStyle-ForeColor="WindowText" ControlStyle-CssClass="btn btn-danger" />
                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>

                                            </div>


                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Validity of Documents Submitted</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">(i). Valid up to date Trading License(TNT)</label>
                                                        <div class="col-lg-4 d-flex">
                                                            <asp:TextBox runat="server" ID="txttradeLic" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txttradeLic"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">(ii). Valid up to date permission from Municipallity/Contt.Board/Local Dorbar *</label>
                                                        <div class="col-lg-4 d-flex">
                                                            <asp:TextBox runat="server" ID="txtMunicipalDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtClass"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Particulars of cold storage </label>
                                                        <div class="col-lg-4 d-flex">
                                                            <asp:TextBox ID="txtColdstorage" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)" MaxLength="500" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">

                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Drugs Categories(P) *</label>
                                                        <div class="col-lg-12 d-flex">
                                                            <asp:CheckBoxList ID="CHKAuthorized" runat="server" RepeatDirection="Vertical" RepeatColumns="3" Style="padding: 20px" AutoPostBack="true" OnSelectedIndexChanged="CHKAuthorized_SelectedIndexChanged">
                                                                <asp:ListItem Text="Specified in Schedules C and C(1)" Value="1" style="padding-right: 20px"></asp:ListItem>
                                                                <asp:ListItem Text="Specified in Schedule X" Value="2" style="padding-right: 20px"></asp:ListItem>
                                                                <asp:ListItem Text="Other than those specified in Schedule C, C(I) and X" Value="3" style="padding-right: 20px"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>
                                        </div>

                                        <div class="col-md-12 text-right mt-2 mb-2">

                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" OnClick="btnsave_Click" />
                                            <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded  btn-info btn-lg" Width="150px" />

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
