<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOContractorsRegistration.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOContractorsRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
    //let originalValue = "";
    function handleKeyUp(input)
    {
        if (input.value.trim() === "") {
            input.style.border = "2px solid red";
        }
        else {
            input.style.border = "1px solid #767575b5";
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
    }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Pre-Operational</a></li>

                    <li class="breadcrumb-item active" aria-current="page">ContractorsRegistration Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" id="divText" runat="server">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">ContractorsRegistration</h4>
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
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Service Specific Details</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <%-- <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Type of Application  *</label>
                                               <div class="col-lg-6">
                                                <asp:RadioButtonList ID="rblApplication" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text=" New Registration" Value="1" />
                                                    <asp:ListItem Text="Renewal" Value="2" />                                                                                               
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div> --%>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Purpose of Application  *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblPurApplication" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblPurApplication_SelectedIndexChanged">
                                                            <asp:ListItem Text="Roads" Value="1" />
                                                            <asp:ListItem Text="Building" Value="2" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-7 col-form-label">Choose the Class of Contractor registering for  *</label>
                                                    <div class="col-lg-5">
                                                        <asp:RadioButtonList ID="rblRegister" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblRegister_SelectedIndexChanged">
                                                            <asp:ListItem Text="Class I" Value="1" />
                                                            <asp:ListItem Text="Class II" Value="2" />
                                                            <asp:ListItem Text="Class III" Value="3"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <%--   <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Name of Applicant  :</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtNameApplicant" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>--%>
                                        </div>
                                        <%--   <div class="col-md-12 d-flex">
                                      <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Type of Applicant  *</label>
                                               <div class="col-lg-4">
                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Individual" Value="1" />
                                                    <asp:ListItem Text="Firm" Value="2" />                                                   
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div> 
                            </div>--%>
                                        <div class="col-md-12 d-flex" id="applicant" runat="server" visible="false">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Type of Applicant </span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6" id="director" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Directorate  *</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlDirector" class="form-control" onchange="validateDropdown(this)">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6" id="circle" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Circle *</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlCircle" class="form-control" onchange="validateDropdown(this)">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12 d-flex" id="division" runat="server" visible="false">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6">Division  *</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlDivision" class="form-control" onchange="validateDropdown(this)">
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
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of Bank   :*</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtNameBank" runat="server" class="form-control" onkeypress="return Names(this)" MaxLength="50" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Turn Over (in Rs. Lakhs): *</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtTurnOver" runat="server" class="form-control" onkeypress="return validateAmount(event)" MaxLength="9" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Total Value of Works in last 3 financial years (in Rs. Lakhs): *</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtFinancial" runat="server" class="form-control" onkeypress="return validateAmount(event)" MaxLength="9" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date from which working as contractor * :</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <%--  <asp:TextBox ID="txtContractor" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtContractor" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtContractor"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <h4 class="card-title ml-3">Upload Below Documents</h4>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">1.Tax Clearance Certificate on Professional Tax *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupTaxClearance" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnTaxClearance" OnClick="btnTaxClearance_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypTaxClearance" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <div class="col-lg-1 d-flex">
                                                    <asp:Label ID="lblTaxClearance" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">2.GST Registration *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupGSTREG" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnGSTREG" OnClick="btnGSTREG_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypGSTREG" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <div class="col-lg-1 d-flex">
                                                    <asp:Label ID="lblGSTREG" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">3.Certificate of Labour License *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupLabourLic" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnLabourLic" OnClick="btnLabourLic_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypLabourLic" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblLabourLic" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">4.Balance sheets for last three financial years, certified by CA In case of non-Tribals:  *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupTribals" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnTribals" OnClick="btnTribals_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypTribals" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblTribals" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">5.Trading license In case of SC, ST and OBC:  *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupTradeLic" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnTradeLic" OnClick="btnTradeLic_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypTradeLic" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblTradeLic" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">6.Caste certificate In case of firms:  *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupCastefirms" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnCastefirms" OnClick="btnCastefirms_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypCastefirms" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblCastefirms" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">7.Power of attorney In case of renewals:   *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupattorney" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnattorney" OnClick="btnattorney_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypattorney" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblattorney" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">8. Last issued   *</label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:FileUpload ID="fupLastissued" runat="server" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button Text="Upload" runat="server" ID="btnLastissued" OnClick="btnLastissued_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                </div>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:HyperLink ID="hypLastissued" runat="server" Target="_blank"></asp:HyperLink>
                                                </div>
                                                <asp:Label ID="lblLastissued" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 text-right mt-2 mb-2">

                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" OnClick="btnPreviuos_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                        <asp:Button ID="btnNext" Text="Next" runat="server" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
            <asp:PostBackTrigger ControlID="btnTaxClearance" />
            <asp:PostBackTrigger ControlID="btnGSTREG" />
            <asp:PostBackTrigger ControlID="btnLabourLic" />
            <asp:PostBackTrigger ControlID="btnTribals" />
            <asp:PostBackTrigger ControlID="btnTradeLic" />
            <asp:PostBackTrigger ControlID="btnCastefirms" />
            <asp:PostBackTrigger ControlID="btnattorney" />
            <asp:PostBackTrigger ControlID="btnLastissued" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
