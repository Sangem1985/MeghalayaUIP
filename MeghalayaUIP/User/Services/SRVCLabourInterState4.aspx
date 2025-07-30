<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCLabourInterState4.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCLabourInterState4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Labour Details</h4>
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
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Principal Employer Details</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Principal Employer's Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPrincipalName" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Father’s/Husband’s ( in case of individuals )</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtfather" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Principal Employer's E-Mail Id *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEmail1" runat="server" class="form-control" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Principal Employer's Mobile Number *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)" TabIndex="1" onblur="validateIndianMobileNumber(this);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">State *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlSates" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSates_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select State" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Address of the Principal Employer</span></label>
                                        </div>

                                        <div class="col-md-12 d-flex" id="divMeghaState" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        District<span style="color: red">*</span>

                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDistric" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistric_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select District" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                            <asp:ListItem Text="Select Village" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex" id="divOtherState" runat="server" visible="false">
                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">District <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtDistricted" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="50" onkeyup="handleKeyUp(this)" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal/Taluka <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtMandaled" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="50" onkeyup="handleKeyUp(this)" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village <span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtVillagede" class="form-control" onkeypress="return Names(this)" TabIndex="1" MaxLength="50" onkeyup="handleKeyUp(this)" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Locality *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLocality" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nearest Landmark</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLandMark" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="50"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Police Station/Outpost</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPoliceStation" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="50"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Post Office  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPostOffice" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="6" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Pin Code *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TXTPIN" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="6" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row" style="padding-left: 20px" id="divContrLabr" runat="server" visible="true">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Directors/Partners Details</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Title</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlTitle" runat="server" class="form-control">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                                <asp:ListItem Text="SHRI" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="SMIT" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="KUMARI" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="DR" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Full Name</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtDirectorName" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="200"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Address</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtDirectorAddress" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label"></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="btnDirector" Text="Add Details" OnClick="btnDirector_Click" class="btn btn-rounded btn-green" runat="server" Fore-Color="White" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVDirector" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVDirector_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Title" DataField="CFECL_CONTRACTORNAMEADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name" DataField="CFECL_WORKNAMENATURELOCATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Address" DataField="CFECL_MAXCONTRACTLABOUR" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-left: 20px" id="divMigrLabr" runat="server" visible="true">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Manager or person details responsible for the supervision and control of the establishment</span></label>

                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Title</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlTitles" runat="server" class="form-control">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                                <asp:ListItem Text="SHRI" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="SMIT" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="KUMARI" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="DR" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Full Name</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtManagerName" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="50" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Address</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtManagerAddress" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="50" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label"></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="btnManager" Text="Add Details" OnClick="btnManager_Click" class="btn btn-rounded btn-green" runat="server" Fore-Color="White" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVManager" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVManager_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Title" DataField="CFEMW_CONTRACTORNAMEADDRESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Full Name" DataField="CFEMW_MIGRANTNAMENATURELOCATION" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Address" DataField="CFEMW_MAXCONTRACTMIGRANT" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="row" style="padding-left: 20px" id="div1" runat="server" visible="true">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Particulars of Contract Labour</span></label>

                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name and Address of the Contractor*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtNameContractor" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="200"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name, nature and location of work for which Contract Labour are to be recruited or employed*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtNameofLocation" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Maximum No. of Contract Labour proposed to be employed in the establishment on any date *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlMaximumNo" runat="server" class="form-control">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                                <asp:ListItem Text="50 and above but does not exceed 100" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="exceeds 100 but does not exceed 200" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="exceeds 200 but does not exceed 400" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="exceeds 400" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Duration of proposed contract work in a number of days(Min 1 and Max 179)*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtContactWork" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="4" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Estimated date of commencement of work *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtEstimated" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd-MM-yyyy" targetcontrolid="txtEstimated"></cc1:calendarextender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Estimated date of completion of work*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtDateWork" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd-MM-yyyy" targetcontrolid="txtDateWork"></cc1:calendarextender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Estimated date of termination of the employment of Contract Labour *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox runat="server" ID="txtEmployeeLabour" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:calendarextender id="CalendarExtender3" runat="server" format="dd-MM-yyyy" targetcontrolid="txtEmployeeLabour"></cc1:calendarextender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label"></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="btnParticulars" Text="Add Details" OnClick="btnParticulars_Click" class="btn btn-rounded btn-green" runat="server" Fore-Color="White" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVParticulars" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVParticulars_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name and Address" DataField="CFECL_CONTRACTORNAMEADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name,location of work Contract Labour employed" DataField="CFECL_WORKNAMENATURELOCATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Maximum No. of Contract Labour establishment on date" DataField="CFECL_MAXCONTRACTLABOUR" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Duration of proposed contract work in a number of days(Min 1 and Max 179)" DataField="CFECL_CONTRACTDURATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Estimated date of commencement of work" DataField="CFECL_COMMENCEMENTDATEOFWORK" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Estimated date of completion of work" DataField="CFECL_COMPLETIONDATEOFWORK" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Estimated date of termination Contract Labour " DataField="CFECL_TERMINATIONDATEOFEMP" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />


                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 text-right mb-2">
                                        <asp:Button Text="Previous" runat="server" ID="btnPrevious" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        <asp:Button ID="Btnsave" runat="server" Text="Save" class="btn btn-rounded btn-success btn-lg" padding-right="10px" Width="150px" OnClick="Btnsave_Click" />
                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
