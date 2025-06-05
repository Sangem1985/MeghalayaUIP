<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENDrugLicDetails2.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENDrugLicDetails2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
        //let originalValue = "";
        function handleKeyUp(input) {
            if (input.value.trim() === "") {
                input.style.border = "2px solid red";
            }
            else {
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


        function validateRadioButtonList(radioGroupContainer) {
            // Find all radio buttons inside the container
            const radioButtons = radioGroupContainer.querySelectorAll('input[type="radio"]');

            // Check if any radio button is selected
            const isSelected = Array.from(radioButtons).some(radio => radio.checked);

            if (!isSelected) {
                // If none are selected, apply red border
                radioGroupContainer.style.border = "2px solid red";
                radioGroupContainer.querySelector('input[type="radio"]').focus(); // Set focus to the first radio button
            } else {
                // Reset the border if an option is selected
                var id = radioGroupContainer.id;
                document.getElementById(id).style.border = "1px solid #767575b5";
                return false;
            }
        }
    </script>
    <style>
        div#drug, div#drugothers, div#drugcommom {
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
                    <div class="row" id="divText" runat="server">
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
                                                        <label class="col-lg-6 col-form-label">Service Apply To:   *</label>
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
                                                        <label class="col-lg-6 col-form-label">Please specify the purpose of application  *</label>
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
                                                            <label class="col-lg-6 col-form-label">License Number *</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="txtLicNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Expiry date of license *</label>
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
                                                            <label class="col-lg-6 col-form-label">Do you hold any previous cancelled license?  *</label>
                                                            <div class="col-lg-6">
                                                                <asp:RadioButtonList ID="rblCancelledLic" onchange="validateRadioButtonList(this)" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblCancelledLic_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                                    <asp:ListItem Text="No" Value="N" />
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4" id="LicNos" runat="server" visible="false">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Please specify license no *</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="txtSpecifyLicNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </asp:Panel>


                                            <div id="divManufacture63" runat="server" visible="true">

                                                <div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Drug Details</span></label>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Name of the Drug *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txttradeLic" runat="server" class="form-control" onkeypress="return Names(this)" onkeyup="handleKeyUp(this)"></asp:TextBox>

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
                                                <div class="col-md-6 d-flex justify-content-center ml-3">
                                                    <asp:GridView ID="GVDrugName" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="None" Width="100%" EnableModelValidation="True" Visible="false">
                                                        <RowStyle BackColor="#ffffff" BorderWidth="1px" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                            <asp:BoundField HeaderText="Name of Drug " DataField="REND_DRUGNAME" ItemStyle-Width="330px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>

                                                <div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Details of Technical Staff employed for Manufacturing and Testing</span></label>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Name *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtnames" runat="server" class="form-control" Type="text" onkeypress="return Names(this)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Qualification *</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="txtqualifies" runat="server" class="form-control" Type="text" onkeypress="return Names(this)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Experience *</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="txtexpered" runat="server" class="form-control" Type="text" onkeypress="return NumberOnly()" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 d-flex justify-content-center">
                                                    <asp:Button ID="btnTesting" runat="server" Text="Add More" OnClick="btnTesting_Click" CssClass="btn btn-green btn-rounded mt-2 mb-4" Width="110px" />
                                                </div>
                                                <div class="col-md-6 d-flex justify-content-center">
                                                    <asp:GridView ID="GVTEST" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="None"
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
                                                <br />
                                                <div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Details Of Technical Staff Employed For Testing</span></label>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Name *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtName" runat="server" class="form-control" Type="text" onkeypress="return Names(this)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Qualification *</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="txtQualifications" runat="server" class="form-control" Type="text" onkeypress="return Names(this)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Experience *</label>
                                                            <div class="col-lg-6">
                                                                <asp:TextBox ID="txtExperiment" runat="server" class="form-control" Type="text" onkeypress="return NumberOnly()" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-12 d-flex justify-content-center">
                                                    <asp:Button ID="Button1" runat="server" Text="Add More" OnClick="Button1_Click" CssClass="btn btn-green btn-rounded mt-2 mb-4" Width="110px" />
                                                </div>
                                                <div class="col-md-6 d-flex justify-content-center">
                                                    <asp:GridView ID="GVSTAFF" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="None"
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

                                                <div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Additional Item</span></label>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Specify if any additional item is required</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtSpecify" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return Names(this)" onkeyup="handleKeyUp(this)"></asp:TextBox>

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
                                                <div class="col-md-6 d-flex justify-content-center ml-3">
                                                    <asp:GridView ID="GVSpecify" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="None" Width="100%" EnableModelValidation="True" Visible="false">
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
                                                <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
                                                <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
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
