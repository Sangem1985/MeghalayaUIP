<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENContractRegistationDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENContractRegistationDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Public Work Department</h4>
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
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Type of Application  *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblApplication" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text=" New Registration" Value="Y" />
                                                            <asp:ListItem Text="Renewal" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Purpose of Application:  *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblPurApplication" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Roads" Value="Y" />
                                                            <asp:ListItem Text="Building" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Choose the Class of Contractor registering for  *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblRegister" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblRegister_SelectedIndexChanged">
                                                            <asp:ListItem Text="Class I" Value="1" />
                                                            <asp:ListItem Text="Class II" Value="2" />
                                                            <asp:ListItem Text="Class III" Value="3"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of Applicant  :</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNameApplicant" runat="server" class="form-control" onkeypress="return Names()" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Type of Applicant  *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblApplicant" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblApplicant_SelectedIndexChanged">
                                                            <asp:ListItem Text="Individual" Value="Y" />
                                                            <asp:ListItem Text="Firm" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex" id="applicant" runat="server" visible="false">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Application Submission Details </span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4" id="director" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Directorate  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlDirector" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="circle" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Circle *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlCircle" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="division" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6">Division  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlDivision" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 d-flex ml-3">
                                            <label><span style="font-weight: 900;">Basic Applicant's Details </span></label>
                                        </div>
                                        <div class="col-md-12 d-flex" id="ApplicantName" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Father's Name   :*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtFather" runat="server" class="form-control" onkeypress="return Names()" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mother's Name   :*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMother" runat="server" class="form-control" onkeypress="return Names()" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <%-- <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of Birth/Date of Incorporation*  :</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtBirth" runat="server" class="date form-control" Type="Date"></asp:TextBox>
                                                          <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtBirth"></cc1:CalendarExtender>
                                                       
                                                    </div>
                                                </div>
                                            </div>--%>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of Birth/Date of Incorporation*  :</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtBirth" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtBirth"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="PowerAttorney" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of Power of Attorney  :*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtpowerattorney" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Permanent Address [in Full]  :*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPermanent" runat="server" class="form-control" TabIndex="1" onkeypress="return Address(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Communication Address [in Full] *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtcommuniction" runat="server" class="form-control" TabIndex="1" onkeypress="return Address(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nationality *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlnational" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlnational_SelectedIndexChanged">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="INDIAN" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Other" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex ml-3">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mobile Number   :*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control" MaxLength="10" onblur="validateIndianMobileNumber(this);" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Email  :*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="SateDomical" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">State of Domicile *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlstate" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex ml-3">
                                            <div class="col-md-4" id="social" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Social Category*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlsocial" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex ml-3">
                                            <label><span style="font-weight: 900;">Basic Details as Contractor </span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of Bank   :*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNameBank" runat="server" class="form-control" onkeypress="return Names()" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Turn Over (in Rs. Lakhs): *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtTurnOver" runat="server" class="form-control" onkeypress="return validateAmount(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Total Value of Works in last 3 financial years (in Rs. Lakhs): *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtFinancial" runat="server" class="form-control" onkeypress="return validateAmount(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date from which working as contractor * :</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtContractor" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtContractor"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 text-right mt-2 mb-2">

                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" OnClick="btnPreviuos_Click" />
                                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" OnClick="btnNext_Click" />

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
