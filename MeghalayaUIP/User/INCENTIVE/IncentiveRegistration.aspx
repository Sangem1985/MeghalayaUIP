<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="IncentiveRegistration.aspx.cs" Inherits="MeghalayaUIP.User.INCENTIVE.IncentiveRegistration" %>

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

        .gridview-centered {
            margin: auto;
            text-align: center;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Incentive</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Incentive Registration Details</li>
                </ol>
            </nav>
            <div class="page-wrapper tabs">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Incentive Registration Details:</h4>
                                </div>
                                <div class="card-body">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:HiddenField ID="hdnResultTab2" runat="server" />
                                    <asp:HiddenField ID="hdnResultTab3" runat="server" />

                                    <ul class="nav nav-tabs">
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link1" class="nav-link active" runat="server" OnClick="Link1_Click" Style="padding-right: 20px; font-size: 18px; margin-top: -8px !important; padding: 10px 10px 12px !important;"> 
                                    &nbsp;&nbsp;&nbsp;&nbsp;1. Incentive Basic Details&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></li>
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link2" class="nav-link" runat="server" OnClick="Link2_Click" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;2. Fixed Capital Investment&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></li>
                                        <li class="nav-item">
                                            <asp:LinkButton ID="Link3" class="nav-link" runat="server" OnClick="Link3_Click" Style="padding-right: 10px; font-size: 18px !important; margin-top: -8px !important; padding: 10px 10px 12px !important;">
                                    3. Power</asp:LinkButton></li>

                                    </ul>
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
                                        <asp:MultiView ID="MVprereg" runat="server" OnActiveViewChanged="MVprereg_ActiveViewChanged">
                                            <asp:View ID="viewBasic" runat="server">
                                                <div class="tab-pane active" id="basictab1">
                                                    <div class="card-body" runat="server" id="divbasic">
                                                        <span class="icon"><i class="fi fi-br-caret-down"></i></span>
                                                    </div>
                                                    <h4 class="card-title ml-3">1(a) Unit Address: </h4>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Name of Unit</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtUnitName" runat="server" class="form-control" onkeypress="return Names()" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Company Type <span class="star">*</span></label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlcompanytype" runat="server" class="form-control" TabIndex="1">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Nature of Activity<span class="star">*</span></label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:RadioButtonList ID="rblNatureofActvty" runat="server" RepeatDirection="Horizontal" TabIndex="1">
                                                                        <asp:ListItem Text="Manufacturing" Value="Manufacturing" style="padding-right: 10px"></asp:ListItem>
                                                                        <asp:ListItem Text="Service" Value="Service"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    <%-- <asp:TextBox runat="server" ID="txtNatureofActivity" class="form-control" />--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <h4 class="card-title ml-3">1(b)Factory/Unit Address: </h4>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Area/Locality *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtLocality" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="lblregntype" runat="server">C&RD Block *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtBlock" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Post Office</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtPost" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    District
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mandal</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Village</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
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
                                                                    <asp:TextBox ID="txtpincode" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" Type="text" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mobile NO *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>                                                      
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                    </div>
                                                    <h4 class="card-title ml-3">(c) Office Address: </h4>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Area/Locality</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtAreaoffice" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label2" runat="server">C&RD Block *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtCDBlockoffice" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label3" runat="server">Post Office *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtPostoffice" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    District
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlDistrictoffice" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrictoffice_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mandal</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlMandloffice" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandloffice_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Village</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlVillageoffice" runat="server" class="form-control">
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
                                                                    <asp:TextBox ID="txtPincodeoffice" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtEmailoffice" runat="server" class="form-control" Type="text" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label4" runat="server">Mobile NO *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtLandoffice" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                      
                                                    </div>
                                                    <h4 class="card-title ml-3">(d) Registered Office's Address </h4>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Area/Locality</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtAreaReg" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label5" runat="server">C&RD Block *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtCDReg" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label6" runat="server">Post Office *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtPostReg" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    District
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlDistrictReg" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrictReg_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Mandal</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlMandlReg" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandlReg_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Village</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlVillageReg" runat="server" class="form-control">
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
                                                                    <asp:TextBox ID="txtPicReg" runat="server" class="form-control" Type="text" onkeypress="return validatePincode(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtEmailReg" runat="server" class="form-control" Type="text" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label7" runat="server">Mobile NO *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtLandReg" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                       
                                                    </div>


                                                    <div class="col-md-12 d-flex">
                                                        <h4 class="card-title ml-3">2.Details of the Applicant / Promoter(s) /
													Partner(s) / Director(s) / Members: </h4>
                                                    </div>
                                                   
                                                    <div class="col-md-12 d-flex">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="gvPromoters" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CssClass="GRD table-bordered table-striped table-sm" ForeColor="#333333"
                                                                GridLines="None"
                                                                AlternatingRowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Wrap="true"
                                                                Width="140%" EnableModelValidation="True" Visible="false">
                                                                <RowStyle BackColor="#ffffff" />

                                                                <Columns>

                                                                    <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-CssClass="btn btn-rounded btn-danger1" ItemStyle-VerticalAlign="Middle" ItemStyle-Wrap="true" ItemStyle-ForeColor="White" />
                                                                    <asp:BoundField HeaderText="DIRECTOR_NO" DataField="IDD_DIRECTOR_NO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" Visible="false" />
                                                                    <asp:BoundField HeaderText="UNITID" DataField="IDD_UNITID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" Visible="false" />
                                                                    <asp:BoundField HeaderText="INVESTERID" DataField="IDD_INVESTERID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" Visible="false" />
                                                                    <asp:BoundField HeaderText="First Name" DataField="IDD_FIRSTNAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="Last Name" DataField="IDD_LASTNAME" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />

                                                                    <asp:TemplateField HeaderText="Year 5" ItemStyle-Width="150px">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAadhar" runat="server" Text='<%# Eval("IDD_ADNO") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:BoundField HeaderText="Aadhar No." DataField="IDD_ADNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />--%>
                                                                    <asp:BoundField HeaderText="PAN No." DataField="IDD_PAN" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="DIN No." DataField="IDD_DINNO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="Nationality" DataField="IDD_NATIONALITY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />

                                                                    <asp:BoundField HeaderText="Door No." DataField="IDD_DOORNO" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="Street" DataField="IDD_STREET" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="Country" DataField="IDD_COUNTRYName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="State" DataField="IDD_STATEName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="District" DataField="IDD_DISTRICTName" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="Mandal" DataField="IDD_MANDALName" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="Village" DataField="IDD_CITYName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />

                                                                    <asp:BoundField HeaderText="Pincode" DataField="IDD_PINCODE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="E-mail" DataField="IDD_EMAIL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="Mobile" DataField="IDD_PHONE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />

                                                                </Columns>
                                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />

                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <h4 class="card-title ml-3">3.Whether new unit or existing unit undergoing expansion: </h4>
                                                    </div>

                                                    <div class="col-md-12 d-flex">                                                      
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">(a) In case of New unit	*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtNewUnit" runat="server" class="form-control" Type="text" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label9" runat="server">Date of commencement of commercial production/operation *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtCompnyRegDt" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtCompnyRegDt"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label10" runat="server">
                                                                    (b) In case of existing unit undergoing expansion *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox ID="txtUndergoing" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">

                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Date of commencing commercial production/operation after expansion	*</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtProduction" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtProduction"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label" id="Label11" runat="server">Date of commencing commercial production/operation before expansion *</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtcommercial" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtcommercial"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <h4 class="card-title ml-3">4. Items of production & installed capacity: </h4>

                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">1.Prior to expansion/diversification</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtexpansion" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">2.After expansion/diversification</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtAfter" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">3. Prior to expansion/diversification</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtPrior" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">4. After expansion/diversification</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtdiversification" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 text-center">
                                                            <asp:Button ID="btnAddLOM" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" OnClick="btnAddLOM_Click" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex justify-content-center">
                                                        <asp:GridView ID="gvTeamMembers" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                            GridLines="None"
                                                            Width="100%" EnableModelValidation="True" Visible="false">
                                                            <RowStyle BackColor="#ffffff" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Prior to expansion/diversification" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="After expansion/diversification" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="Prior to expansion/diversification" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField HeaderText="After expansion/diversification" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <h4 class="card-title ml-3">5.Details Of Registration: </h4>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <%--<div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">5. Details of registration</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtDetReg" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>--%>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">(a) In case of New unit</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtUnitNew1" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">(i) EM Part II No	</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtEMPart" runat="server" class="form-control" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">EM Part date	</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtEMPartDate" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender13" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEMPartDate"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>


                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">(ii) IEM No.</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtIEMDate" runat="server" class="form-control" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">(ii) IEM date</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="IEMdate" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="IEMdate"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">b. In case of existing unit undergoing expansion</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtCaseunder" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    (i) Permanent (PMT) Registration/IEM/EM Part II No
                                                                </label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtIEM" runat="server" class="form-control" TabIndex="1"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    (PMT) Registration/IEM/EM Part II No & date
                                                                </label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtRegPartNo2" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd-MM-yyyy" TargetControlID="txtRegPartNo2"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 d-flex">
                                                        <h4 class="card-title ml-3">6.Eligibility Certificate & Date: </h4>
                                                    </div>
                                                    <div class="col-md-12 d-flex mt-2">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Eligibility Certificate No.</label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtEligibilityNo" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Eligibility date </label>
                                                                <div class="col-lg-6">
                                                                    <asp:TextBox ID="txtEligibility" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEligibility"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 text-right mt-2 mb-2">

                                                        <%-- <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />--%>
                                                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                                    </div>
                                                </div>
                                            </asp:View>
                                            <asp:View ID="viewRevenue" runat="server">
                                                <div class="tab-pane active " id="basictab2">
                                                    <div class="card-body" runat="server" id="divRevenue">
                                                        <span class="icon2"><i class="fi fi-br-caret-down"></i></span>
                                                        <h4 class="card-title" style="background: #67bf02; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">2. Fixed Capital Investment</h4>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <asp:GridView ID="GVFiexed" runat="server" AutoGenerateColumns="false" OnRowDataBound="GVFiexed_RowDataBound">
                                                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" HorizontalAlign="Center" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Particulars" Visible="true" ItemStyle-Width="45%" HeaderStyle-HorizontalAlign="left">
                                                                            <ItemTemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("PARAMETER_NAME") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- <asp:BoundField DataField="MRP_DESECRIPTION" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Item Description " ItemStyle-Width="250px">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>--%>
                                                                        <asp:TemplateField HeaderText="For new unit (in  )" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtunit1" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="PriorExpansion (in  )" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtExpansion" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="DuringExpansion(in  )" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtDurExpansion" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total after expansion(in  )" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtAfterExpansion" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--  <asp:TemplateField HeaderText="Total" Visible="true" ItemStyle-Width="45%" HeaderStyle-HorizontalAlign="left">
                                                                            <ItemTemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("MRP_DESECRIPTION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                            <br />
                                                            <h4 class="card-title ml-3">7(a).Source of finance </h4>
                                                            <div class="col-md-12 d-flex justify-content-center">
                                                                <asp:GridView ID="GVSource" runat="server" AutoGenerateColumns="false">
                                                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" HorizontalAlign="Center" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />

                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle Width="70px" />
                                                                        </asp:TemplateField>
                                                                        <%--      <asp:TemplateField HeaderText="ID" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMRPID" runat="server" Text='<%# Eval("MRPID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Source of finance" Visible="true" ItemStyle-Width="60%" HeaderStyle-HorizontalAlign="left">
                                                                            <ItemTemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("PARAMETER_NAME") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- <asp:BoundField DataField="MRP_DESECRIPTION" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="Item Description " ItemStyle-Width="250px">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>--%>
                                                                        <asp:TemplateField HeaderText="(in  )" ItemStyle-Width="180px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtSource" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- <asp:TemplateField HeaderText="Total" Visible="true" ItemStyle-Width="45%" HeaderStyle-HorizontalAlign="left">
                                                                            <ItemTemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                                <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("MRP_DESECRIPTION") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>

                                                            <h4 class="card-title ml-3">8(b). Details of Term/Working Loan (if any) : </h4>

                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">1.Name of Bank/ Financial Institution & address</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtFinancial" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">2.Amount of term/ working capital loan sanctioned (in  )</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtloanterm" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">3. Sanction letter No. & date</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtletterno" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">4. Amount of term/ working capital Loan disbursed (in   )</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtCapitalAmount" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4 text-center">
                                                                    <asp:Button ID="btnbuttons" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" OnClick="btnbuttons_Click" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex justify-content-center">
                                                                <asp:GridView ID="GVLoan" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                    GridLines="None"
                                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                                    <RowStyle BackColor="#ffffff" />
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Name of Bank/ Financial Institution & address" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Amount of term/ working capital loan sanctioned (in  )" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Sanction letter No. & date" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Amount of term/ working capital Loan disbursed (in   )" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </div>

                                                            <h4 class="card-title ml-3">8(c). Details of equity (if any)  : </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">1.Name</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtName21" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">2.Amount (in  )</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtamounnt22" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">3. PAN No.</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtPan23" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">4. Mode of payment</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtPayment24" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4 text-center">
                                                                    <asp:Button ID="Button1" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" OnClick="Button1_Click" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex justify-content-center">
                                                                <asp:GridView ID="GVequity" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                    GridLines="None"
                                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                                    <RowStyle BackColor="#ffffff" />
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Name" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Amount (in  )" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="PAN No." DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Mode of payment" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </div>

                                                            <h4 class="card-title ml-3">8(d). Details of unsecured loan (if any) : </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">1.Name</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtName25" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">2.Amount (in  )</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtAmount26" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">3. PAN No.</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtpan27" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">4. Mode of payment</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtPayment28" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4 text-center">
                                                                    <asp:Button ID="Button2" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" OnClick="Button2_Click" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex justify-content-center">
                                                                <asp:GridView ID="GVUnsecuredloan" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                    GridLines="None"
                                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                                    <RowStyle BackColor="#ffffff" />
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="Name" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Amount (in  )" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="PAN No." DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField HeaderText="Mode of payment" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 text-right mt-2 mb-2">

                                                        <%-- <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />--%>
                                                        <asp:Button ID="Button3" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                                        <asp:Button ID="Button4" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                                    </div>
                                                </div>
                                            </asp:View>
                                            <asp:View ID="viewPromoters" runat="server">
                                                <div class="tab-pane active   " id="basictab3">
                                                    <div class="card-body" runat="server" id="divPromotrs">
                                                        <span class="icon3"><i class="fi fi-br-caret-down"></i></span>
                                                        <h4 class="card-title" style="background: #4db6ac; -webkit-background-clip: text; -webkit-text-fill-color: transparent; font-size: 18px; font-weight: 700 !important; font-family: sans-serif;">9. Power</h4>
                                                        <div class="row">
                                                            <%--   <h4 class="card-title ml-3">9.Power: </h4>--%>
                                                            <h4 class="card-title ml-3">(A).In case of new units </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <%--  <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Power</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox25" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>--%>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(i). Sanctioned load </label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtLoad30" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(ii).Connected Load</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtLoadConn31" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(iii).Capacity of captive power plant (if any)	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtCaptive32" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <h4 class="card-title ml-3">B.	In case of existing units undergoing expansion: </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(i).Sanctioned load prior to expansion</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtundercase33" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(ii).Connected load prior to expansion	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtpriorex34" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(iii).Sanction of additional load for expansion	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtloadadditional35" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(iv).Additional connected load for expansion</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtLoadExpansion36" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(v).Capacity of captive power plants (if any)	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtPowerplant37" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <h4 class="card-title ml-3">Details of land and building: </h4>
                                                            <h4 class="card-title ml-3">A Land & (a)Own land </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(i)	Land area</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtRevenue38" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Revenue village</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox2" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Dag No.</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox3" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">patta No.</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox4" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(ii).Date of purchase	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtPurchase39" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" TabIndex="1" MaxLength="10" onblur="validateDateFormat(this)"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="dd-MM-yyyy" TargetControlID="txtPurchase39"></cc1:CalendarExtender>
                                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(iii).Date of registration	</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtRegistrer40" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" TabIndex="1" MaxLength="10" onblur="validateDateFormat(this)"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd-MM-yyyy" TargetControlID="txtRegistrer40"></cc1:CalendarExtender>
                                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <h4 class="card-title ml-3">(b)	Land allotted by Government/ Government	Agency	 </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(i)	Date of allotment/agreement</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtAllotted41" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" TabIndex="1" MaxLength="10" onblur="validateDateFormat(this)"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender11" runat="server" Format="dd-MM-yyyy" TargetControlID="txtAllotted41"></cc1:CalendarExtender>
                                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(ii).Date of taking over possession		</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtPossession42" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" TabIndex="1" MaxLength="10" onblur="validateDateFormat(this)"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender12" runat="server" Format="dd-MM-yyyy" TargetControlID="txtPossession42"></cc1:CalendarExtender>
                                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <h4 class="card-title ml-3">(c)	Lease holds land	 </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(i)	Date of lease of land</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtleaseland43" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" TabIndex="1" MaxLength="10" onblur="validateDateFormat(this)"></asp:TextBox>
                                                                            <cc1:CalendarExtender ID="CalendarExtender10" runat="server" Format="dd-MM-yyyy" TargetControlID="txtleaseland43"></cc1:CalendarExtender>
                                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(ii).Period of lease		</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtPeriodlease44" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <h4 class="card-title ml-3">B	Building 	 </h4>
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">(a)	Own building</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtBuilding45" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">rented building</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="TextBox5" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">In case of own building, built up area		</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtownbuilt46" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <h4 class="card-title ml-3">10.	Employment generation 	 </h4>
                                                            <div class="col-md-12">
                                                                <asp:GridView ID="GVGeneration" runat="server" AutoGenerateColumns="false">
                                                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" HorizontalAlign="Center" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle Width="50px" />
                                                                        </asp:TemplateField>
                                                                        <%-- <asp:TemplateField HeaderText="ID" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMRPID" runat="server" Text='<%# Eval("MRPID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Category" Visible="true" ItemStyle-Width="45%" HeaderStyle-HorizontalAlign="left">
                                                                            <ItemTemplate>
                                                                                <itemstyle horizontalalign="Center" />
                                                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("PARAMETER_NAME") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Few new unit" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtFewunit47" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Before expansion/diversification" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtbeforeexprasion48" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="During  expansion/diversification" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtdiversification49" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total" ItemStyle-Width="150px">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txttotal50" CssClass="form-control" TabIndex="1" runat="server" onkeypress="return validateNumbersOnly(event)" MaxLength="13" onpaste="return false;"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                            <br />
                                                            <br />
                                                            <div class="col-md-12 d-flex">
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Total employment</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtEmployment51" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Total Nos. of local tribals 		</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtLocalTribe52" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4">
                                                                    <div class="form-group row">
                                                                        <label class="col-lg-6 col-form-label">Percentage of local tribals 		</label>
                                                                        <div class="col-lg-6">
                                                                            <asp:TextBox ID="txtPercentTribals53" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-12 text-right mt-2 mb-2">

                                                                <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                                                <asp:Button ID="Button5" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                                                <asp:Button ID="Button6" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                                            </div>


                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:View>


                                        </asp:MultiView>
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
