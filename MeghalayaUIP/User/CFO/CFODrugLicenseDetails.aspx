<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFODrugLicenseDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFODrugLicenseDetails" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Pre-Operational</a></li>

                    <li class="breadcrumb-item active" aria-current="page">DrugLicense Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" id="divText" runat="server" >
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
                                        <div id="div_39_46" runat="server" visible="false">
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
                                                            <asp:RadioButtonList ID="rblApplication" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Wholesale" Value="1" />
                                                                <asp:ListItem Text="Retails" Value="2" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Validity of Documents Submitted</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">(i). Valid up to date Trading License(TNT)</label>
                                                        <div class="col-lg-4 d-flex">
                                                            <%--<asp:TextBox ID="txttradeLic" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>--%>

                                                            <asp:TextBox runat="server" ID="txttradeLic" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"  onkeyup="handleKeyUp(this)"/>
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txttradeLic"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">(ii). Valid up to date permission from Municipallity/Contt.Board/Local Dorbar *</label>
                                                        <div class="col-lg-4 d-flex">
                                                            <%-- <asp:TextBox ID="txtClass" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>--%>

                                                            <asp:TextBox runat="server" ID="txtClass" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtClass"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Particulars of cold storage </label>
                                                        <div class="col-lg-4 d-flex">
                                                            <asp:TextBox ID="txtCapacity" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)" MaxLength="500" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div runat="server" id="div_license" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Application Details</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-8">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Do you hold any previous cancelled license?   *</label>
                                                        <div class="col-lg-4">
                                                            <asp:RadioButtonList ID="rblLicense" onchange="validateRadioButtonList(this)" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLicense_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" id="CanceledLIC" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Please specify license no  </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtspecifyLICNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div runat="server" id="div_52" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Is the premise and plan ready for inspection? *</label>
                                                        <div class="col-lg-4">
                                                            <asp:RadioButtonList ID="rblinsection" onchange="validateRadioButtonList(this)" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblinsection_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6" id="InspectionDate" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label" style="margin-right: -15px;">Date for Inspection *</label>
                                                        <div class="col-lg-4 d-flex">
                                                            <%--   <asp:TextBox ID="txtInspection" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>--%>

                                                            <asp:TextBox runat="server" ID="txtInspection" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" onkeyup="handleKeyUp(this)"/>
                                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtInspection"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="div_Staff_Manf" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Details of Technical Staff employed for Manufacturing</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">Name*</label>
                                                        <div class="col-lg-8 d-flex">
                                                            <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">Qualification *</label>
                                                        <div class="col-lg-8 d-flex">
                                                            <asp:TextBox ID="txtQualification" runat="server" class="form-control" onkeypress="return Names(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-5 col-form-label">Experience(Years) *</label>
                                                        <div class="col-lg-7 d-flex">
                                                            <asp:TextBox ID="txtExperience" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="4" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label"></label>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:Button ID="btnAdd" Text="Add Details" class="btn btn-rounded btn-green" runat="server" OnClick="btnAdd_Click" Width="110px" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GVHealthy" runat="server" AutoGenerateColumns="False"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD table-hover table-striped"
                                                        GridLines="None"
                                                        Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVHealthy_RowDeleting">
                                                        <RowStyle BackColor="#ffffff" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-Width="100px" />
                                                            <asp:BoundField HeaderText="Name" DataField="CFODM_EMPNAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                            <asp:BoundField HeaderText="Qualification" DataField="CFODM_EMPQLFCATION" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                            <asp:BoundField HeaderText="Experience" DataField="CFODM_EMPEXPRNC" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div runat="server" visible="false" id="div_Staff_Test">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Details Of Technical Staff Employed For Testing</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">Name*</label>
                                                        <div class="col-lg-8 d-flex">
                                                            <asp:TextBox ID="txtNameTest" runat="server" class="form-control" onkeypress="return Names(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">Qualification *</label>
                                                        <div class="col-lg-8 d-flex">
                                                            <asp:TextBox ID="txtQualifyTest" runat="server" class="form-control" onkeypress="return Names(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-5 col-form-label">Experience(Years)*</label>
                                                        <div class="col-lg-7 d-flex">
                                                            <asp:TextBox ID="txtExperienceTest" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="4" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label"></label>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:Button ID="addbutton" Text="Add Details" class="btn btn-rounded btn-green" runat="server" OnClick="addbutton_Click" Width="110px" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GVTESTING" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD table-striped table-hover"
                                                        GridLines="None" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVTESTING_RowDeleting">
                                                        <RowStyle BackColor="#ffffff" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-Width="100px" />
                                                            <asp:BoundField HeaderText="Name" DataField="CFODT_EMPNAME" ItemStyle-BackColor="Wheat" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="420px" />
                                                            <asp:BoundField HeaderText="Qualification" DataField="CFODT_EMPQLFCATION" ItemStyle-BackColor="Wheat" ItemStyle-Width="400px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                            <asp:BoundField HeaderText="Experience" DataField="CFODT_EMPEXPRNC" ItemStyle-BackColor="Wheat" ItemStyle-Width="400px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />


                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="Wheat" />
                                                        <AlternatingRowStyle BackColor="Wheat" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        <div runat="server" id="div_48" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Drug Details</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name of Drug  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtNameDrug" runat="server" class="form-control" onkeypress="return Names(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:Button ID="ADDBTN" Text="Add Details" class="btn btn-rounded btn-green" runat="server" OnClick="ADDBTN_Click" Width="110px" />
                                                </div>
                                            </div>
                                            <%-- <div class="col-md-12 d-flex justify-content-center">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-10 col-form-label"></label>
                                            <div class="col-lg-2 d-flex">
                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                                            <div class="col-md-12">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="GVDrug" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="None"
                                                        Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVDrug_RowDeleting">
                                                        <RowStyle BackColor="#ffffff" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-Width="100px" />
                                                            <asp:BoundField HeaderText="Name of Drug " DataField="CFOD_DRUGNAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <%--   <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Additional Item</span></label>
                                </div> 
                                   <div class="col-md-12 d-flex">
                                         <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Specify if any additional item is required *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtItemreq" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                       </div>
                                 <div class="col-md-12 d-flex justify-content-center">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label"></label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Button ID="btnadds" Text="Add Details" class="btn  btn-info btn-lg" runat="server" Fore-Color="White" BackColor="YellowGreen" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                     <div class="col-md-12 d-flex justify-content-center">
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="None"
                                        Width="100%" EnableModelValidation="True" Visible="false">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Specify if any additional item is required" DataField="" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                          
                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>--%>
                                        </div>
                                        <br />

                                        <h4 class="card-title ml-3">Upload Below Documents</h4>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.ST Certificate/Trading License in case of Non Tribal of new proprietor *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupTribal" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnTribal" OnClick="btnTribal_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypTribal" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblTribal" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2.Qualification Certificate of new proprietor  *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupQualification" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnQualification" OnClick="btnQualification_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypQualification" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblQualification" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3.Specimen signature of new proprietor *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupSpecimen" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnSpecimen" OnClick="btnSpecimen_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypSpecimen" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblSpecimen" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.NOC from Local Headman/Municipal/Cantonment Board in favour of new proprietor  *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupHeadman" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnHeadman" OnClick="btnHeadman_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypHeadman" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblHeadman" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">5.Tenancy agreement   *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupTenancy" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnTenancy" OnClick="btnTenancy_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypTenancy" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblTenancy" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">6.Up to Date Registration of Pharmacist*</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupRegistration" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnRegistration" OnClick="btnRegistration_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypRegistration" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblRegistration" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">7.Specimen Signature of Pharmacist   *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupPharmacist" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnPharmacist" OnClick="btnPharmacist_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypPharmacist" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblPharmacist" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">8. Qualification Certificate of Pharmacist    *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupQualificationcertificate" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnQualificationcertificate" OnClick="btnQualificationcertificate_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypQualificationcertificate" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblQualificationcertificate" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">9.Key and Site Plan    *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupsiteplan" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnsiteplan" OnClick="btnsiteplan_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypsiteplan" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblsiteplan" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">10.Specimen Signature of pharmacist/ Competent person    *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupCompetentperson" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnCompetentperson" OnClick="btnCompetentperson_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypCompetentperson" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblCompetentperson" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">11.Qualification Certificate of pharmacist/ Competent person    *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fuppharmacistlist" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnpharmacistlist" OnClick="btnpharmacistlist_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hyppharmacistlist" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblpharmacistlist" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12.Undertaking I   *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupundertaking1" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnundertaking1" OnClick="btnundertaking1_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypundertaking1" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblundertaking1" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">13.Undertaking II   *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupundertaking2" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnundertaking2" OnClick="btnundertaking2_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypundertaking2" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblundertaking2" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">14.Staff List   *</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupstaff" runat="server" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnstaff" OnClick="btnstaff_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypstaff" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblstaff" runat="server" />
                                                </div>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnTribal" />
            <asp:PostBackTrigger ControlID="btnQualification" />
            <asp:PostBackTrigger ControlID="btnSpecimen" />
            <asp:PostBackTrigger ControlID="btnHeadman" />
            <asp:PostBackTrigger ControlID="btnTenancy" />
            <asp:PostBackTrigger ControlID="btnRegistration" />
            <asp:PostBackTrigger ControlID="btnPharmacist" />
            <asp:PostBackTrigger ControlID="btnQualificationcertificate" />
            <asp:PostBackTrigger ControlID="btnsiteplan" />
            <asp:PostBackTrigger ControlID="btnCompetentperson" />
            <asp:PostBackTrigger ControlID="btnpharmacistlist" />
            <asp:PostBackTrigger ControlID="btnundertaking1" />
            <asp:PostBackTrigger ControlID="btnundertaking2" />
            <asp:PostBackTrigger ControlID="btnstaff" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
