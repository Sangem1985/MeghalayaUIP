<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOProffessionalTax.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOProffessionalTax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
       <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Pre-Operational</a></li>

            <li class="breadcrumb-item active" aria-current="page">Proffessional Tax Details</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Proffessional Tax Details</h4>
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
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Establishment Details</span></label>
                                </div>
                                <div class="col-md-12 d-flex">

                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of Establishment *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEstDet" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Address of Establishment *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtaddress" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">District of Establishment *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlDistric" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">

                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Pin Code of Establishment *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPincode" runat="server" class="form-control" onkeypress="return validatePincode(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Total number of Employees working in Establishment</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEmployeeESt" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Description of Goods and Services supplied by the Establishment *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtGoodssupplie" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Date of commencement *</label>
                                            <div class="col-lg-6 d-flex">
                                             <%--   <asp:TextBox ID="txtDate" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                 <i class="fi fi-rr-calendar-lines"></i>--%>

                                                  <asp:TextBox runat="server" ID="txtDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Gross Annual income in the last financial year *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtIncome" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12">
                                    <div class="form-group row">
                                        <label class="col-lg-4 col-form-label">Additional Place of Business in MEGHALAYA *</label>
                                        <div class="col-lg-3">
                                            <asp:RadioButtonList ID="rblBusiness" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblBusiness_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="Y" />
                                                <asp:ListItem Text="No" Value="N" />
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                                <div id="AdditionDetails" runat="server" visible="false">
                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label">Additional Place of Business Details:</label>
                                    </div>
                                    <div class="col-md-12 d-flex" id="AdditionPlace" runat="server" visible="false">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Place of Business*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtplacebusiness" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Address*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtadd" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-5 col-form-label">District *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList runat="server" ID="ddldist" class="form-control">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex" id="totalemp" runat="server" visible="false">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Total working employees *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtEMP" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Button ID="btnAdd" Text="Add Details" class="btn btn-rounded btn-green" runat="server" OnClick="btnAdd_Click" Width="110px" />
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex justify-content-center">
                                    <asp:GridView ID="GVState" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="None"
                                        Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVState_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Place of Business" DataField="CFOPS_PLACEBUSINESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Address" DataField="CFOPS_ADDRESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="District" DataField="CFOPS_DISTRIC" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Total working employees" DataField="CFOPS_TOTALEMP" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-8 col-form-label">Additional Place of Business in INDIA *</label>
                                            <div class="col-lg-4">
                                                <asp:RadioButtonList ID="rblbusinessindia" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblbusinessindia_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="Added" runat="server" visible="false">
                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label">Additional Place of Business Details:</label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Place of Business*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtBusinessplace" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Address*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtAddeddet" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-5 col-form-label">State *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList runat="server" ID="ddlState" class="form-control">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Total working employees *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtwork" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnAdeed" Text="Add Details" class="btn btn-rounded btn-green" runat="server" OnClick="btnAdeed_Click" Width="110px" />
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex justify-content-center">
                                    <asp:GridView ID="GVCOUNTRY" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="None"
                                        Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVCOUNTRY_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Place of Business" DataField="CFOPC_PLACEBUSINESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Address" DataField="CFOPC_ADDRESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="State" DataField="CFOPC_STATE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Total working employees" DataField="CFOPC_TOTALEMP" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>



                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold">Other Details</label>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-8 col-form-label">Whether office from foreign country? *</label>
                                            <div class="col-lg-4">
                                                <asp:RadioButtonList ID="rblForeign" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblForeign_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex" id="foreign" runat="server" visible="false">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Principal Place of Work *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPrinciple" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" id="country" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Address*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtAdded" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Employer Name *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEmployee" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex" id="monthly" runat="server" visible="false">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Monthly Salary/Wages *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtsalary" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">

                                            <div class="col-lg-2 d-flex">
                                                <asp:Button ID="Addedbtn" Text="Add Details" class="btn btn-rounded btn-green" runat="server" OnClick="Addedbtn_Click" Width="110px" />
                                            </div>
                                        </div>
                                    </div>
                                    <%--	<div class="col-md-4">
												<div class="form-group row">
													<label class="col-lg-6 col-form-label">Name*</label>
													<div class="col-lg-6 d-flex">
														<asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
													</div>
												</div>
											</div>
										  <div class="col-md-12 d-flex">														
											<div class="col-md-4">
												<div class="form-group row">
													<label class="col-lg-6 col-form-label">Address *</label>
													<div class="col-lg-6 d-flex">
														<asp:TextBox ID="txtaddresses" runat="server" class="form-control"></asp:TextBox>
													</div>
												</div>
											</div>
										 </div>--%>
                                </div>
                                <div id="Address" runat="server" visible="false">
                                    <div class="col-md-12 d-flex justify-content-center">
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold">Other place of work, if any, in state:</label>
                                </div>
                                <div class="col-md-12 d-flex justify-content-center">
                                    <asp:GridView ID="GVFOREIGN" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="None"
                                        Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVFOREIGN_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Principal Place of Work" DataField="CFOPF_PRINCIPLEWORK" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Address" DataField="CFOPF_ADDRESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Employer Name" DataField="CFOPF_EMPNAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Monthly Salary/Wages" DataField="CFOPF_MONTHLYWAGES" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">No. of Branch Certificate of enrolment required  *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtBranch" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-8 col-form-label">Do you have registration under any other act? *</label>
                                            <div class="col-lg-3">
                                                <asp:RadioButtonList ID="rblother" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblother_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4" id="RegistrationType" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Registration Type *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlRegType" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" id="RegNo" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Regisration No*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TXTRegNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
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

