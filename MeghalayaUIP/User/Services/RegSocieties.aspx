<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RegSocieties.aspx.cs" Inherits="MeghalayaUIP.User.Services.RegSocieties" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>

    <style>
        i.fi.fi-br-circle-camera {
            font-size: 32px;
            margin-right: -21px;
            padding-left: 6px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="SRVCUserDashboard.aspx">Services</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Application Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" runat="server" id="divText">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Application Processing Location:</h4>
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
                                            <h4 class="card-title ml-3"></h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        1. Kindly choose application submission office depending on the address of your association :</label>
                                                    <div class="col-lg-6">
                                                        <asp:DropDownList ID="ddlApplication" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlApplication_SelectedIndexChanged">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="OFFICE OF THE DEPUTY COMMISSIONER" Value="1" />
                                                            <asp:ListItem Text="OFFICE OF THE SUB DIVISIONAL OFFICER(CIVIL)" Value="2" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="District" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        DISTRICT
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:DropDownList ID="ddldistrict" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="subdivision" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        SUB DIVISION</label>
                                                    <div class="col-lg-6">
                                                        <asp:DropDownList ID="ddlSubDiv" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select-- " Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">Application Type Details </h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Type of Application  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:RadioButtonList ID="rblApplication" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblApplication_SelectedIndexChanged">
                                                            <asp:ListItem Text="Fresh" Value="F" />
                                                            <asp:ListItem Text="Renewal" Value="R" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="divOldReg" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Old Registration Number
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtSoWoDo" runat="server" class="form-control" onkeypress="return validateNames(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="RegDate" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Registration Date*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtRegDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtRegDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h4 class="card-title ml-3">Association Details: </h4>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of the Association</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtNameAssoci" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Address of the association/society</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtAddressSociety" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of establishment</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtEstDate" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEstDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">President Contact Number </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtPresidentNo" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">General Secretary Mobile Number</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtGeneralMobileNo" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">E-Mail</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">Member Details: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Full Name</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtFullName" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Full Address</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtAddress" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Police Station</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtPoliceStation" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Designation(In the society)</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtDesignation" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mobile Number</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtMobileno" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <div class="col-lg-12 d-flex">
                                                        <asp:Button ID="btnMember" runat="server" Text="Add" OnClick="btnMember_Click" CssClass="btn btn-green btn-rounded" Width="110px" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 d-flex justify-content-center">
                                            <asp:GridView ID="GVRegSocieties" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                GridLines="None" Width="100%" EnableModelValidation="True" Visible="false">
                                                <RowStyle BackColor="#ffffff" BorderWidth="1px" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Full Name" DataField="NAME" ItemStyle-Width="330px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Full Address" DataField="ADDRESS" ItemStyle-Width="330px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Police Station" DataField="POLICESTATION" ItemStyle-Width="330px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Designation(In the society)" DataField="DESIGNATION" ItemStyle-Width="330px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Mobile Number" DataField="MOBILENO" ItemStyle-Width="330px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                </Columns>
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>

                                    </div>

                                    <div class="col-md-12 text-right mt-2 mb-2">
                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" OnClick="btnPreviuos_Click" />
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" OnClick="btnsave_Click" />
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
