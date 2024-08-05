<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFELabourDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFELabourDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                                    <!-- <h4 class="card-title">Personal Information</h4> -->

                                    <div class="row">

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label fw-bold"><span style="font-weight: 900;">1. Category of Establishment</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">2. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtname1" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Father's Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtfather" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Age *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtage" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="2"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Designation *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtdesignation" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mobile *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Email *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEmail1" runat="server" class="form-control" onblur="validateEmail(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">District *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlPropLocDist" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPropLocDist_SelectedIndexChanged">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlPropLocTaluka" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPropLocTaluka_SelectedIndexChanged">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlPropLocVillage" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Door No.*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtdoor3" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="50"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Locality *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtlocality3" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Pin Code *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TXTPIN" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="6"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <%--------------------starting of Supervision Div for approval id 25, 26,27, 28 ----------------------------------%>
                                        <div class="row" style="padding-left: 20px" id="divsupervision" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtnames" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Mobile No.*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtMobilenumber" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Email Id.*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Father's Name</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtFathersname" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Door No. *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtDoor1" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="50"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Locality *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLocality1" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">District *</label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="ddlDistricts" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistricts_SelectedIndexChanged">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Mandal *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Village *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                                <asp:ListItem Text="--Village--" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Pincode *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtpincode" runat="server" class="form-control" MaxLength="6"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Designation *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtDesignations" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%--------------------closing of Supervision Div for approval id 25, 26,27, 28 ----------------------------------%>


                                        <%--------------------starting of Perticulars of contractor Div for approval id 25 ----------------------------------%>
                                        <div class="row" style="padding-left: 20px" id="divContrLabr" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Particulars of Contract Labour</span></label>

                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name and Address of the Contractor*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtNameAddress" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name, nature and location of work for which Contract Labour are to be recruited or employed*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLocation" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtContactWork" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="4"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Estimated date of commencement of work *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <%-- <asp:TextBox ID="txtEstimated" runat="server" class="date form-control"></asp:TextBox>
                                                     <i class="fi fi-rr-calendar-lines"></i>--%>
                                                            <asp:TextBox runat="server" ID="txtEstimated" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEstimated"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Estimated date of completion of work*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <%--  <asp:TextBox ID="txtDateWork" runat="server" class="date form-control"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>--%>
                                                            <asp:TextBox runat="server" ID="txtDateWork" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateWork"></cc1:CalendarExtender>
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
                                                            <%--<asp:TextBox ID="txtEmployeeLabour" runat="server" class="date form-control"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>--%>
                                                            <asp:TextBox runat="server" ID="txtEmployeeLabour" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEmployeeLabour"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label"></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="Addbtn" Text="Add Details" class="btn  btn-info btn-lg" runat="server" OnClick="Addbtn_Click" Fore-Color="White" BackColor="YellowGreen" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVLabour" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None"
                                                    Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVLabour_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name and Address" DataField="CFECL_CONTRACTORNAMEADDRESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name,location of work Contract Labour employed" DataField="CFECL_WORKNAMENATURELOCATION" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Maximum No. of Contract Labour establishment on date" DataField="CFECL_MAXCONTRACTLABOUR" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Duration of proposed contract work in a number of days(Min 1 and Max 179)" DataField="CFECL_CONTRACTDURATION" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Estimated date of commencement of work" DataField="CFECL_COMMENCEMENTDATEOFWORK" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Estimated date of completion of work" DataField="CFECL_COMPLETIONDATEOFWORK" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Estimated date of termination Contract Labour " DataField="CFECL_TERMINATIONDATEOFEMP" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />


                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <%--------------------closing of Perticulars of contractor Div for approval id 25 ----------------------------------%>

                                        <%--------------------starting of Perticulars of Migrant Workmen Div for approval id 26 ----------------------------------%>
                                        <div class="row" style="padding-left: 20px" id="divMigrLabr" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Particulars of Migrant Workmen</span></label>

                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name and Address of the Contractor*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtAddressName" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name, nature and location of work for which migrant workmen are to be employed or are employed*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtEmployedName" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="50"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Max No of migrant workmen to be employed on any day through each contractor*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtMaxmigrant" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="50"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Duration of proposed contract work in a number of days(Min 1 and Max 179)*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtContractwork" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="5"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Estimated date of commencement of work*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <%-- <asp:TextBox ID="txtEstwork" runat="server" class="date form-control"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>--%>
                                                            <asp:TextBox runat="server" ID="txtEstwork" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEstwork"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Estimated date of completion of work *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <%-- <asp:TextBox ID="txtEstDate" runat="server" class="date form-control"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>--%>
                                                            <asp:TextBox runat="server" ID="txtEstDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEstDate"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Estimated date of commencement of work*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <%--  <asp:TextBox ID="txtEstDateWork" runat="server" class="date form-control"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>--%>
                                                            <asp:TextBox runat="server" ID="txtEstDateWork" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEstDateWork"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label"></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="btnAddMigrant" Text="Add Details" class="btn  btn-info btn-lg" runat="server" OnClick="btnAddMigrant_Click" Fore-Color="White" BackColor="YellowGreen" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVMigrant" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None" Width="100%" EnableModelValidation="True" Visible="false"
                                                    OnRowDeleting="GVMigrant_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name and Address of the Contractor" DataField="CFEMW_CONTRACTORNAMEADDRESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name,location of work Contract Labour employed Migrant" DataField="CFEMW_MIGRANTNAMENATURELOCATION" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Maximum No. of Migrant establishment on date" DataField="CFEMW_MAXCONTRACTMIGRANT" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Duration of proposed contract work in a number of days(Min 1 and Max 179)" DataField="CFEMW_CONTRACTDURATION" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Estimated date of commencement of work" DataField="CFEMW_COMMENCEMENTDATE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Estimated date of completion of work" DataField="CFEMW_COMPLETIONDATEOFWORK" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Estimated date of termination Migrant WorkMen " DataField="CFEMW_TERMINATIONDATEOFEMPMigrant" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />


                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <br />
                                        <%--------------------closing of Perticulars of Migrant Workmen Div for approval id 26 ----------------------------------%>


                                        <%--------------------starting of div for approval id 27  (16q, 17q, 18q, 19q) and
                                    fro approval id 28 (16q, 17q, 18q, 19q, 20q, 21q, 22q, 23q)----------------------------------%>
                                        <div class="row" style="padding-left: 20px" id="div4questions" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label ">16. Nature of work in which contract labour is employed or is to be employed in the establishment *</label>
                                                        <div class="col-lg-5">
                                                            <asp:TextBox ID="txtLabourEmp" runat="server" class="form-control" MaxLength="300" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label ">17. Estimated date of commencement of building or other construction work *</label>
                                                        <div class="col-lg-5">
                                                            <asp:TextBox ID="txtconstructionwork" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="300"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label ">18. Maximum number of Contract Employees / building workers to be employed on any day *</label>
                                                        <div class="col-lg-5">
                                                            <asp:TextBox ID="txtContractEmployees" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="300"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label ">19. Estimated date of completion of building or other construction work *</label>
                                                        <div class="col-lg-5">
                                                            <asp:TextBox ID="txtbuilding" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="300"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="row" style="padding-left: 20px" id="div5questions" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label ">20. Maximum Number of migrant workmen proposed to be employed in the establishment on any date *</label>
                                                        <div class="col-lg-5">
                                                            <asp:TextBox ID="txtMaximum" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="300"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label ">21. Whether the contractor was convicted of any offence within the preceding five years. If so give details *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblconvicted" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label ">22. Whether there was any order against the contractor revoking or suspending license or forefeiting security deposits in respect of an earlier contract . If so the date of such order. *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblrevoking" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-10 col-form-label ">23. Whether the contractor has worked in any other establishment within the past five years, If so, give details of the Principal Emplyer,Establishments and nature of work *</label>
                                                        <div class="col-lg-2">
                                                            <asp:RadioButtonList ID="rblcontractor" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex row" style="padding-left: 20px">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label ">24. Type of business, trade, industry, manufacture or occupation, which is carried on in the establishment</label>
                                                        <div class="col-lg-4">
                                                            <asp:DropDownList ID="ddlbusiness" runat="server">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <%--<div class="col-md-12 mt-3 d-flex upload">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-form-label col-md-8 ">24. Whether a certificate by the Principal Employer in Form V is enclosed *</label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtPrincipal" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <button type="button" class="btn btn-rounded btn-dark">Upload</button>
                                    </div>
                                </div>--%>

                                        <%--------------------closing of div for approval id 27  (16q, 17q, 18q, 19q) and
                                    fro approval id 28 (16q, 17q, 18q, 19q, 20q, 21q, 22q, 23q)----------------------------------%>


                                        <%--------------------starting of Perticulars  Div for approval id 28 ----------------------------------%>
                                        <div class="row" style="padding-left: 20px" id="divContractorDtls" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Name and address of the contractor(including his father's/ husband's name in case of individuals)</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name of the Contractor/Firm *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtcontractor" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Father's Name</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtfathername" runat="server" class="form-control" onkeypress="return Names()" MaxLength="100"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Age</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtAges" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="2"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Mobile No.*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtmobileno" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Email Id.*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtemailid" runat="server" class="form-control" onblur="validateEmail(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">District *</label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="ddlDistric" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistric_SelectedIndexChanged">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Mandal *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlMandals" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandals_SelectedIndexChanged">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Village *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlvillages" runat="server" class="form-control">
                                                                <asp:ListItem Text="Village" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Door No. *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtdoorno" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="50"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Locality *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtlocal" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Pincode *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtpinnumber" runat="server" class="form-control" MaxLength="6" onkeypress="return validatePincode(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row" style="padding-left: 20px" id="divAgentDtls" runat="server" visible="false">

                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Name and address of the agent or manager of the contractor at the work-site</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Door No. *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtDoor" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Locality *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLocality" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">District *</label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="ddldist" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddldist_SelectedIndexChanged">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Mandal *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlmand" runat="server" class="form-control" OnSelectedIndexChanged="ddlmand_SelectedIndexChanged" AutoPostBack="true">
                                                                <asp:ListItem Text="--Selectl--" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Village *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlvilla" runat="server" class="form-control">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Pincode *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtAgentPincode" runat="server" class="form-control" MaxLength="6"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <%--<div class="col-md-12 mt-2 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label fw-bold"><span style="font-weight: 900;">Total No.of Contract Employees *</span></label>
                                                <div class="col-lg-2">
                                                    <asp:TextBox ID="txtEmployees" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>--%>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Upload below Documents</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">1. Trading / business license granted by the respective District Council (only for non-tribals) </label>
                                                    <div class="col-lg-1 d-flex">: </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupLicgrant" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUpldLICgrant" Text="Upload" OnClick="btnUpldLICgrant_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplLicgrant" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">2.Form-V – Certificate from Principal Employer</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupForm5" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUpldForm5" Text="Upload" OnClick="btnUpldForm5_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplForm5" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">3.Form VIII - License issued for recruiting workers from the state of recruitment  </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupForm8" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUpldForm8" Text="Upload" OnClick="btnUpldForm8_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplForm8" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">4.Form X affixed with epic and photograph of all the workmen (single file of all workmen) </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupForm10" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUplForm10" Text="Upload" OnClick="btnUplForm10_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplForm10" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">
                                                        5.Proof of Residence and Criminal antecedents issued by District Magistrates/Additional
                                                         District Magistrates and Superintendent of Police of the home State of each worker listed
                                                         in form X
                                                    </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupCrimeForm10" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUpldCrimeForm10" Text="Upload" OnClick="btnUpldCrimeForm10_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplCrimeForm10" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">6.Registration of establishment of the principal employer  </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupemployer" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUplEmployer" Text="Upload" OnClick="btnUplEmployer_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplEmployer" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 text-right mb-2">
                                        <asp:Button Text="Previous" runat="server" ID="btnPrevious" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        <asp:Button ID="Btnsave" runat="server" OnClick="Btnsave_Click" Text="Save" class="btn btn-rounded btn-success btn-lg" padding-right="10px" Width="150px" />
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

            <asp:PostBackTrigger ControlID="btnUpldLICgrant" />
            <asp:PostBackTrigger ControlID="btnUpldForm5" />
            <asp:PostBackTrigger ControlID="btnUpldForm8" />
            <asp:PostBackTrigger ControlID="btnUplForm10" />
            <asp:PostBackTrigger ControlID="btnUpldCrimeForm10" />
            <asp:PostBackTrigger ControlID="btnUplEmployer" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>

