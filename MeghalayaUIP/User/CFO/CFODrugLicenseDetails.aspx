<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFODrugLicenseDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFODrugLicenseDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Pre-Operational</a></li>

            <li class="breadcrumb-item active" aria-current="page">DrugLicense Details</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">DrugLicense Details</h4>
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
                                        <div class="col-md-4">
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
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">(i). Valid up to date Trading License(TNT)</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txttradeLic" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label">(ii). Valid up to date permission from Municipallity/Contt.Board/Local Dorbar *</label>
                                                <div class="col-lg-4 d-flex">
                                                    <asp:TextBox ID="txtClass" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Particulars of cold storage </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtCapacity" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
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
                                                <asp:RadioButtonList ID="rblLicense" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLicense_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="1" />
                                                    <asp:ListItem Text="No" Value="2" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" id="CanceledLIC" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Please specify license no  </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtspecifyLICNo" runat="server" class="form-control"  onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                    </div>
                                <div runat="server" id="div_52" visible="false">
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Is the premise and plan ready for inspection? *</label>
                                                <div class="col-lg-4">
                                                    <asp:RadioButtonList ID="rblinsection" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblinsection_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="1" />
                                                        <asp:ListItem Text="No" Value="2" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="InspectionDate" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Date for Inspection *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtInspection" runat="server" class="date form-control" Type="text"></asp:TextBox>
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
                                                    <label class="col-lg-6 col-form-label">Name*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Qualification *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtQualification" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Experience(Years)*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtExperience" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
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
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name" DataField="CFODM_EMPNAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Qualification" DataField="CFODM_EMPQLFCATION" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Experience" DataField="CFODM_EMPEXPRNC" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

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
                                                <label class="col-lg-6 col-form-label">Name*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNameTest" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Qualification *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtQualifyTest" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Experience(Years)*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtExperienceTest" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
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

                                    <div class="col-md-12 d-flex justify-content-center">
                                        <asp:GridView ID="GVTESTING" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD"
                                            GridLines="None" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVTESTING_RowDeleting">
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>

                                                <asp:BoundField HeaderText="Name" DataField="CFODT_EMPNAME" ItemStyle-Width="40%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Qualification" DataField="CFODT_EMPQLFCATION" ItemStyle-Width="30%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Experience" DataField="CFODT_EMPEXPRNC" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-Width="10%" />

                                            </Columns>
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
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
                                                    <asp:TextBox ID="txtNameDrug" runat="server" class="form-control" onkeypress="return Names(event)"></asp:TextBox>
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
                                    <div class="col-md-12 d-flex justify-content-center">
                                        <asp:GridView ID="GVDrug" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                            GridLines="None"
                                            Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVDrug_RowDeleting">
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Name of Drug " DataField="CFOD_DRUGNAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                            </Columns>
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
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
  
</asp:Content>
