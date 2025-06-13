<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENDrugsLicenseDetails1.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENDrugsLicenseDetails1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <style>
        div#drug, div#drug1, div#drug2, div#drugothers, div#drugcommom {
            width: 100%;
            border: 1px solid #ccc;
            margin: 4px 15px;
            border-radius: 8px;
            padding: 0px 10px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="RENUserDashboard.aspx">Renewal</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Drugs License Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Drugs License Details</h4>
                                </div>
                                <div class="card-body">
                                    <div class="col-md-12">
                                        <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span></button>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
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
                                        <div class="drug" id="drug">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Application Processing Location</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Service Apply To:<span style="color: red">*</span></label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="ddlservice" runat="server" class="form-control" RepeatDirection="Horizontal" AutoPostBack="true">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-md-12 d-flex">
                                                <%--Renewal of license--%>
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Application Details</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Please specify the purpose of application <span style="color: red">*</span></label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="rblLicense" runat="server" class="form-control" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLicense_SelectedIndexChanged">
                                                                <asp:ListItem Text="--Select--" Value="-1" />
                                                                <asp:ListItem Text="New registration for Grant of license" Value="N" />
                                                                <asp:ListItem Text="Renewal of license" Value="R" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:Panel ID="pnlLicenseDetails" runat="server" Visible="false">
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">License Number <span style="color: red">*</span></label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="txtLicNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Expiry date of license<span style="color: red">*</span></label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox runat="server" ID="txtExpiryDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd-MM-yyyy" TargetControlID="txtExpiryDate"></cc1:CalendarExtender>
                                                                <i class="fi fi-rr-calendar-lines"></i>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Do you hold any previous cancelled license? <span style="color: red">*</span></label>
                                                            <div class="col-lg-6">
                                                                <asp:RadioButtonList ID="rblCancelledLic" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblCancelledLic_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                    <asp:ListItem Text="No" Value="N" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4" id="LicNos" runat="server" visible="false">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Please specify license no<span style="color: red">*</span></label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="txtSpecifyLicNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </asp:Panel>
                                        </div>
                                        <div class="drugcommon" id="drug2">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Drug Details</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name of the Drug <span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txttradeLic" runat="server" class="form-control" onkeypress="return Names(this)"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <div class="col-lg-12 d-flex">

                                                            <asp:Button ID="btn" runat="server" Text="Add More" OnClick="btn_Click" CssClass="btn btn-green btn-rounded" Width="110px" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- <div class="col-md-6 d-flex justify-content-center ml-3">--%>
                                            <div class="col-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVDrugName" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVDrugName_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" BorderWidth="1px" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name of Drug " DataField="REND_DRUGNAME" ItemStyle-Width="330px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="drugcommon" id="drug1">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Details of Technical Staff employed for Manufacturing and Testing</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name<span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtnames" runat="server" class="form-control" Type="text" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Qualification <span style="color: red">*</span></label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtqualifies" runat="server" class="form-control" Type="text" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Experience<span style="color: red">*</span></label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtexpered" runat="server" class="form-control" Type="text" onkeypress="return NumberOnly()"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:Button ID="btnTesting" runat="server" Text="Add More" OnClick="btnTesting_Click" CssClass="btn btn-green btn-rounded mt-2 mb-4" Width="110px" />
                                            </div>
                                            <%--<div class="col-md-6 d-flex justify-content-center">--%>
                                            <div class="col-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVSTAFF" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None" OnRowDeleting="GVSTAFF_RowDeleting"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" BorderWidth="1px" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name" DataField="RENDM_NAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Qualification" DataField="RENDM_QUALIFICATION" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Experience" DataField="RENDM_EXPERIENCE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                            <br />
                                        </div>

                                        <div class="drugcommon" id="drugcommom">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Details Of Technical Staff Employed For Testing</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name<span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtName" runat="server" class="form-control" Type="text" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Qualification<span style="color: red">*</span></label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtQualifications" runat="server" class="form-control" Type="text" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Experience<span style="color: red">*</span></label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtExperiment" runat="server" class="form-control" Type="text" onkeypress="return NumberOnly()"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:Button ID="Button1" runat="server" Text="Add More" OnClick="Button1_Click" CssClass="btn btn-green btn-rounded mt-2 mb-4" Width="110px" />
                                            </div>
                                            <div class="col-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVTEST" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None" OnRowDeleting="GVTEST_RowDeleting"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" BorderWidth="1px" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name" DataField="RENST_NAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Qualification" DataField="RENST_QUALIFICATION" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Experience" DataField="RENST_EXPERIENCE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <div class="drug" id="drugothers">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Additional Item</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Specify if any additional item is required<span style="color: red">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtSpecify" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return Names(this)"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <div class="col-lg-12 d-flex">
                                                            <asp:Button ID="btnspecify" runat="server" Text="Add More" OnClick="btnspecify_Click" CssClass="btn btn-green btn-rounded" Width="110px" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVSpecify" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVSpecify_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" BorderWidth="1px" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Additional Item" DataField="RENDA_ADDITIONALITEM" ItemStyle-Width="330px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>

                                        </div>






                                        <div class="col-md-12 text-right mt-2 mb-2">
                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" OnClick="btnPreviuos_Click" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" Text="Next" runat="server" OnClick="btnNext_Click" class="btn btn-rounded  btn-info btn-lg" Width="150px" />

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

