<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEPowerDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEPowerDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Pre Establishment</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Power Details</li>
                </ol>
            </nav>
            <div class="page-wrapper" id="divText" runat="server">

                <div class="content container-fluid">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">Power Details</h3>
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

                                        <h4 class="card-title ml-3">Power*</h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Connected Load in KW*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtHP" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        <span class="form-text text-muted mt-2 ml-2"></span>
                                                        <!-- <span class="mt-2">HP</span> -->
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Contracted Maximum Demand in KVA *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMaxDemand" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Required Voltage Level*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlvtglevel" runat="server" class="form-control" onchange="validateDropdown(this)">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="EXISTING" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Any Other Services Existing in the Same Premises*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlPermise" runat="server" class="form-control" onchange="validateDropdown(this)">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <h4 class="card-title ml-3">Proposed Maximum Working Hours</h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Per Day*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMaxhours" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="2" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Per Month*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMonth" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="4" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Expected Month and Year of Trial Production</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%--  <asp:TextBox ID="txttrailProduct" runat="server" class="date form-control"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>--%>
                                                        <asp:TextBox runat="server" ID="txttrailProduct" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" onkeyup="handleKeyUp(this)" />
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txttrailProduct"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4. Probable Date of Requirement of Power Supply*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%-- <asp:TextBox ID="txtPowersupply" runat="server" class="date form-control"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>--%>
                                                        <asp:TextBox runat="server" ID="txtPowersupply" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" onkeyup="handleKeyUp(this)" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtPowersupply"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">5. Quantum of energy/load required (in KW) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtenergy" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">6. Proposed source of energy/load*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlloadenergy" runat="server" class="form-control" onchange="validateDropdown(this)">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="mePDCL" visible="false">
                                            <h4 class="card-title ml-3">Power Feasibility</h4>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">7. Purpose(s) for which electricity will be principally used*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtEtrPrpse" runat="server" class="form-control" onkeypress="return validateNameAndNumbers()" MaxLength="2" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">8. Contracted load / demand required*</label>
                                                        <div class="auto-style1">
                                                            <asp:RadioButtonList ID="rblCmplnc" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Contracted" Value="Contracted" />
                                                                <asp:ListItem Text="Demanded" Value="Demanded" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Character of supply required (tick in the blank box):</label>
                                                        <div class="col-lg-6">
                                                            <asp:CheckBoxList ID="chkCharacterSupply" runat="server">
                                                                <asp:ListItem Text="400V 3Phase 4Wire" Value="400V"></asp:ListItem>
                                                                <asp:ListItem Text="11kV" Value="11kV"></asp:ListItem>
                                                                <asp:ListItem Text="33kV" Value="33kV"></asp:ListItem>
                                                                <asp:ListItem Text="132kV" Value="132kV"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 text-right mb-3">
                                            <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
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
