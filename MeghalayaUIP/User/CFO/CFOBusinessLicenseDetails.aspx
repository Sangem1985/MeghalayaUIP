<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOBusinessLicenseDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOBusinessLicenseDetails" %>

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

                    <li class="breadcrumb-item active" aria-current="page">Pollution Control Board Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" id="divText" runat="server">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Pollution Control Board</h4>
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
                                        <div id="PCB59" runat="server" visible="false"></div>
                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Establishment Details</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <%--<div class="col-md-8">
												<div class="form-group row">
													<label class="col-lg-6 col-form-label">Address of the establishment, from where it is to be conducted *</label>
													<div class="col-lg-3 d-flex">
														<asp:TextBox ID="txtEstDet" runat="server" class="form-control"></asp:TextBox>
													</div>
												</div>
											</div>--%>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of Establishment  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <%--  <asp:TextBox ID="txtaddress" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtaddress" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" onkeyup="handleKeyUp(this)" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtaddress"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-3 col-form-label">Select Location of Stall*</label>
                                                    <div class="col-lg-9">
                                                        <asp:RadioButtonList ID="rblBusiness" runat="server" onchange="validateRadioButtonList(this)" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblBusiness_SelectedIndexChanged">
                                                            <asp:ListItem Text="Private owned establishment" Value="Y" />
                                                            <asp:ListItem Text="Municipal owned shop/establishment" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex" id="stall" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Holding Number *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtHolding" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" MaxLength="8" onkeyup="handleKeyUp(this)" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Market Name  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlDistric" class="form-control" onchange="validateDropdown(this)">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex" id="Districmaster" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">District of Establishment *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlESTDistric" class="form-control" onchange="validateDropdown(this)">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Stall number *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtstall" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1" MaxLength="7" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-8 col-form-label">Whether the applicant is doing any business in Shillong Municipality during the previous 5 (five) years?  *</label>
                                                    <div class="col-lg-4">
                                                        <asp:RadioButtonList ID="rblmunicipality" runat="server" onchange="validateRadioButtonList(this)" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblmunicipality_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="Municipality" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Details (if Yes)*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDetails" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" MaxLength="400" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Nature of Business</span></label>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Annual Gross Turnover (Rs in Lakhs) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlAnnual" class="form-control" onchange="validateDropdown(this)">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nature of Business (Main Category) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlNature" class="form-control" onchange="validateDropdown(this)">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nature of Business (Sub Category) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlBusiness" class="form-control" onchange="validateDropdown(this)">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Fees *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtFees" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="10" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Button ID="btnAdd" Text="Add Details" class="btn btn-green btn-rounded" runat="server" OnClick="btnAdd_Click" Width="110px" />
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex justify-content-center">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label"></label>
                                                    <div class="col-lg-6 d-flex">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex justify-content-center">
                                            <asp:GridView ID="GVPollution" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                GridLines="None"
                                                Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVPollution_RowDeleting">
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Nature of Business (Main Category)" DataField="CFOBN_MAINCATEGORY" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Nature of Business (Sub Category)" DataField="CFOBN_SUBCATEGORY" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Fees" DataField="CFOBN_FEE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                </Columns>
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Total Amount *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAmount" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="10" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
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
