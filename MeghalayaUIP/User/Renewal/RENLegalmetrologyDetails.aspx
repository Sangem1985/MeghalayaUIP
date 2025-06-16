<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENLegalmetrologyDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENLegalmetrologyDetails" %>

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
                            <div class="card" id="divText" runat="server">
                                <div class="card-header">
                                    <h4 class="card-title">Legalmetrology Details</h4>
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
                                            <%--<label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Existing License Details</span></label>--%>
                                            <h4 class="card-title ml-3">Application To Search</h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Licence Number  <span style="color: red">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLicNo" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <%--  <label class="col-lg-6 col-form-label">License Issued Year *</label>--%>
                                                    <div class="col-lg-6">
                                                        <asp:Button ID="btnsearch" runat="server" Text="Search" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-md-4" id="divManu" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License Issued Year <span style="color: red">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLicIssedYear" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div id="divdealer74" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3 mt-3">Details of License</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">License Issued Date  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLiceIssuedDate1" runat="server" class="form-control" Type="text" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                               <cc1:CalendarExtender ID="CalendarExtender10" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLiceIssuedDate1"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Date of last renewal  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtLicDateTo" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLicDateTo"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Expiry date of last renewal  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtLicValiddate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLicValiddate"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Is the License Renewed at least one?  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:RadioButtonList runat="server" ID="rbdLicRenleast" TabIndex="1" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                            </asp:RadioButtonList>

                                                        </div>
                                                    </div>
                                                </div>

                                               <%-- <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Total amount of fee to be paid for Auto Renewal  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtTotalFee" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" />

                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">License Valid up To Date  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtLicvalid1" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" />

                                                        </div>
                                                    </div>
                                                </div>--%>

                                            </div>
                                        </div>


                                        <div id="divRepair75" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3 mt-3">Details of License</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">License Issued Date <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtLicissuedDate1" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLicissuedDate1"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Date of last renewal <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtlastdate1" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtlastdate1"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Expiry date of last renewal<span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtExpireDate1" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtExpireDate1"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Is the License Renewed at least one?  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:RadioButtonList runat="server" ID="rbdRenLeast" TabIndex="1" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                            </asp:RadioButtonList>

                                                        </div>
                                                    </div>
                                                </div>

                                           <%--     <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Total amount of fee to be paid for Auto Renewal  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtTotal" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" />

                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">License Valid up To Date  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtLICValid" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" />

                                                        </div>
                                                    </div>
                                                </div>--%>

                                            </div>
                                        </div>


                                        <div id="divManufacture76" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3 mt-3">Details of License</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Type of license  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtTypeLic" class="form-control" TabIndex="1" AutoPostBack="true" />
                                                            <%--   <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLicDateTo"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name of licensee  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtNameLic" class="form-control" TabIndex="1" AutoPostBack="true" />

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Expiry Date of License  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtExpireLic" class="form-control" TabIndex="1" AutoPostBack="true" />
                                                                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd-MM-yyyy" TargetControlID="txtExpireLic"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Date of Last Renewal  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtDateLastRen" class="form-control" TabIndex="1" AutoPostBack="true" />
                                                               <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateLastRen"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>

                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Expiry Date of Last Renewal <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtExpirDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" />
                                                               <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MM-yyyy" TargetControlID="txtExpirDate"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Renewed up to Year <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtRenYear" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" />

                                                        </div>
                                                    </div>
                                                </div>

                                            </div>


                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Office of Legal Metrology which issued the license  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtLegalLic" class="form-control" TabIndex="1" AutoPostBack="true" />


                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">License Issued Date  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtLicissuedDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" />
                                                               <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLicissuedDate"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Is the License Renewed at least one?  <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:RadioButtonList runat="server" ID="rbdLicRen" TabIndex="1" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                         <%--   <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Click to see Renewal Fees to be Paid  </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:CheckBox ID="RenFee" runat="server" />

                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4" id="Amount" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Total amount of License fee to be paid for Auto Renewal: </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtLicAmount" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" />
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>--%>

                                        </div>


                                        <div class="col-md-12 text-right mt-2 mb-2">

                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" OnClick="btnPreviuos_Click" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded  btn-info btn-lg" Width="150px" OnClick="btnNext_Click" />

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
