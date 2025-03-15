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
                                        <%-- -------------------POWER FEASIBILITY------------------------------------------- --%>

                                        <div class="mePDCL" visible="true">
                                            <h4 class="card-title ml-3">Power Feasibility</h4>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            7.Purpose(s) for which electricity will be principally used*
                                                        </label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPrpse" Type="text" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-5 col-form-label">8. Load Type*</label>
                                                        <div class="col-lg-7 d-flex">
                                                            <asp:RadioButtonList ID="rblCmplnc" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Contracted" Value="Contracted" style="padding-right: 20px" />
                                                                <asp:ListItem Text="Demanded" Value="Demanded" style="padding-right: 20px" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            9. Character of supply required (tick in the blank box):
                                                        </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:CheckBoxList ID="chkCharacterSupply" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="400V 3Phase 4Wire" Value="1" style="padding-right: 20px"></asp:ListItem>
                                                                <asp:ListItem Text="11kV" Value="2" style="padding-right: 20px"></asp:ListItem>
                                                                <asp:ListItem Text="33kV" Value="3" style="padding-right: 20px"></asp:ListItem>
                                                                <asp:ListItem Text="132kV" Value="4" style="padding-right: 20px"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                                <div class="col-md-8">
                                                    <div class="form-group row">
                                                        <label class="col-lg-9 col-form-label">
                                                            10. Connected load required (if in phases, indicate it year wise, for 
                a period of five years) from the date of supply*
                                                        </label>
                                                        <div class="col-lg-3">
                                                            <%--<asp:TextBox ID="txtLoadInPhase" Type="text" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateName(event)"></asp:TextBox>--%>
                                                            <asp:RadioButtonList ID="rblInPhase" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblInPhase_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Yes" style="padding-right: 20px" />
                                                                <asp:ListItem Text="No" Value="No" style="padding-right: 20px" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row d-flex justify-content-center align-items-center" runat="server" visible="false" id="isLoadInPhase" Width="100%">
                                            <div class="col-lg-12">
                                                <div class="card">
                                                    <div class="card-header">
                                                        <h4 class="card-title"><b>Connected Load Required (Year-wise for 5 Years)</b></h4>
                                                    </div>
                                                    <div class="card-body">
                                                        <div class="table-responsive">
                                                            <table class="table table-bordered">
                                                                <thead class="tblHeader" style="background-color: #013161; color: white; text-align: center;" CssClass="GRDHEADER">
                                                                    <tr>
                                                                        <th style="width: 200px;">Year</th>
                                                                        <th style="width: 250px;">Connected Load (kW)</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <td>Year 1</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtYear1" runat="server" CssClass="form-control" TabIndex="1"
                                                                                onkeyup="handleKeyUp(this)" onkeypress="return validateNumbers(event)">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Year 2</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtYear2" runat="server" CssClass="form-control" TabIndex="2"
                                                                                onkeyup="handleKeyUp(this)" onkeypress="return validateNumbers(event)">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Year 3</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtYear3" runat="server" CssClass="form-control" TabIndex="3"
                                                                                onkeyup="handleKeyUp(this)" onkeypress="return validateNumbers(event)">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Year 4</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtYear4" runat="server" CssClass="form-control" TabIndex="4"
                                                                                onkeyup="handleKeyUp(this)" onkeypress="return validateNumbers(event)">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Year 5</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtYear5" runat="server" CssClass="form-control" TabIndex="5"
                                                                                onkeyup="handleKeyUp(this)" onkeypress="return validateNumbers(event)">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                           

                                        </div>
                                        <br />
                                        <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">
                                                        11. Whether any electricity charges due to distribution utility, are outstanding 
                                                            against the consumer body or any of its subsidiaries, at any other station, 
                                                            and, if so, state the details in brief*
                                                    </label>
                                                    <div class="col-lg-3">
                                                        <asp:TextBox ID="txtEleChg" Type="text" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateName(event)"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- documents --%>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-3 col-form-label"></label>
                                                    <div class="col-lg-2 d-flex">
                                                    </div>
                                                    <div class="col-lg-4 d-flex">
                                                        <label class="col-lg-5 col-form-label">Reference No </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">
                                                        Attach the entity of the consumer body *
                                                    </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtCosmrEnty" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupCosmrEnty" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnCosmrEnty" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnCosmrEnty_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypCosmrEnty" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblCosmrEnty" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">
                                                        Attach the proprietorship of the consumer body *
                                                    </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtCsmrBody" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupCsmrBody" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnCsmrBody" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnCsmrBody_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypCsmrBody" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblCsmrBody" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">
                                                        Attach the clearances from the Pollution Control Board (s) (as may be required) *
                                                    </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtPCB" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupPCB" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnPCB" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnPCB_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypPCB" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblPCB" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">
                                                        Attach the clearances from Municipal or Cantonment Board and Urban Affairs authorities (as may be required)*
                                                    </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtMCB" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupMCB" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnMCB" class="btn btn-rounded btn-dark mb-4" Width="150px" Height="35px" OnClick="btnMCB_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypMCB" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblMCB" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">
                                                        Attach environmental clearance from the concerned authorities (as may be required) *
                                                    </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtEnvClr" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupEnvClr" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnEnvClr" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnEnvClr_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypEnvClr" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblEnvClr" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">
                                                        Attach approval of the Single Window Agency of the Industries Departments (in case of 
factories)  *
                                                    </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtSglWdw" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupSglWdw" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnSglWdw" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnSglWdw_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypSglWdw" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblSglWdw" runat="server" />
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnCosmrEnty" />
            <asp:PostBackTrigger ControlID="btnCsmrBody" />
            <asp:PostBackTrigger ControlID="btnPCB" />
            <asp:PostBackTrigger ControlID="btnMCB" />
            <asp:PostBackTrigger ControlID="btnEnvClr" />
            <asp:PostBackTrigger ControlID="btnSglWdw" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
