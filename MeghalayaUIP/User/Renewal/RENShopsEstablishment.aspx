<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENShopsEstablishment.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENShopsEstablishment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .SO {
            width: 100%;
        }

        ddldist
        i.fi.fi-br-circle-camera {
            font-size: 32px;
            margin-right: -21px;
            padding-left: 6px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Renewal</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Shops and Establishment</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Shops and Establishment Details</h4>
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
                                            <%--<label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Existing License Details</span></label>--%>
                                            <h4 class="card-title ml-3">Existing License Details</h4>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License No for which renewal is required *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLicNo" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License Issued Date *</label>
                                                    <div class="col-lg-6">
                                                        <%--  <asp:TextBox ID="txtLicIssueDate" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtLicIssueDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLicIssueDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License/ Renewal valid up to Date *</label>
                                                    <div class="col-lg-6">
                                                        <%-- <asp:TextBox ID="txtLicValidDate" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>--%>

                                                        <asp:TextBox runat="server" ID="txtLicValidDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtLicValidDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="col-md-12 d-flex">

                                            <h4 class="card-title ml-3 mt-3">Basic Establishment Details</h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of Establishment *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txttradeLic" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Constitution of Business</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlconstitution" runat="server" class="form-control" OnSelectedIndexChanged="ddlconstitution_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Proprietorship" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Partnership Firm" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Limited Company" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Applicant's Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtApplicantName" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mobile Number *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">E-Mail Id *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEmailId" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Photo of the Employer/Proprietor /Partner *</label>
                                                    <div class="col-lg-7 d-flex">
                                                        <asp:FileUpload ID="fupphoto" runat="server" />
                                                        <asp:HyperLink ID="hypphoto" runat="server" Target="_blank"></asp:HyperLink>
                                                        <asp:Label ID="lblphoto" runat="server" />
                                                        <asp:Button Text="Upload DPR1" runat="server" ID="btnphoto" OnClick="btnphoto_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />


                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="Proprietor" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3 mt-3">Proprietor Details</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name of Proprietor  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtProprtie" runat="server" class="form-control"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Communication Address *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtcommonAddress" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Community *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlcommunity" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlcommunity_SelectedIndexChanged">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                                <asp:ListItem Text="Khasi" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Garo" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Jaintia" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Others" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4" id="other" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Community(Others) *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtOther" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">

                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="btnAddDetails" Text="Add More" runat="server" OnClick="btnAddDetails_Click" CssClass="btn btn-sm btn-rounded btn-green" Width="110" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVPROPERTIE" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None"
                                                    Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVPROPERTIE_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name of Proprietor" DataField="RENP_NAMEPROPERTIE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Communication Address" DataField="RENP_COMMUNICATIONADDRESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Community" DataField="RENP_COMMUNITY" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Community(Others)" DataField="RENP_COMMUNITYOTHER" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div id="Partnership" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3 mt-3">Partnership Firm Details</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name of Partner  *</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtPartner" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Communication Address  *</label>
                                                        <div class="col-lg-6">
                                                            <%--  <asp:TextBox ID="txtAddressCommon" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                            <i class="fi fi-rr-calendar-lines"></i>--%>

                                                            <asp:TextBox runat="server" ID="txtAddressCommon" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtAddressCommon"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">

                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="btnpatner" Text="Add More" OnClick="btnpatner_Click" runat="server" CssClass="btn btn-sm btn-rounded btn-green" Width="110" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVPATNER" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None"
                                                    Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVPATNER_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name of Partner " DataField="RENPS_NAMEPATNER" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Communication Address" DataField="RENPS_COMMUNICATIONADDRESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div id="LimitedCompany" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3 mt-3">Limited Company Details</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name of Director  *</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtNameDirect" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Communication Address   *</label>
                                                        <div class="col-lg-6">
                                                            <%-- <asp:TextBox ID="txtAddressCommunicate" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                            <i class="fi fi-rr-calendar-lines"></i>--%>

                                                            <asp:TextBox runat="server" ID="txtAddressCommunicate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtAddressCommunicate"></cc1:CalendarExtender>
                                                            <i class="fi fi-rr-calendar-lines"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">

                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="btncompanydet" Text="Add More" runat="server" OnClick="btncompanydet_Click" CssClass="btn btn-sm btn-rounded btn-green" Width="110" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVLIMITED" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None"
                                                    Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVLIMITED_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name of Director " DataField="RENLC_NAMEOFDIRECTOR" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Communication Address" DataField="RENLC_COMMUNICATIONADDRESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3 mt-3">Establishments Details</h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of the Manager /Agent/other person acting in the general management *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNameAgent" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Address of the Manager/Agent *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAddressAgent" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Category of Establishmnet *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nature of Business *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNature" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Do you have your family members employed in the establishment and residing with and wholly dependent upon you? *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblFamilymember" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblFamilymember_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Do you have employees working in the establishment? *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblEMPEst" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblEMPEst_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="col-md-12 d-flex" id="NumberEmp" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Number of employees *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEMPNo" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Employee List Only .doc .docx format allowed(<a href="#">Download Sample Format</a>) *</label>
                                                    <div class="col-lg-8 d-flex">
                                                        <asp:FileUpload ID="fupDPR" runat="server" />
                                                        <asp:HyperLink ID="hypdpr" runat="server" Target="_blank"></asp:HyperLink>
                                                        <asp:Label ID="lbldpr" runat="server" />
                                                        <asp:Button Text="Upload DPR" runat="server" ID="btndpr" OnClick="btndpr_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />


                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">

                                            <h4 class="card-title ml-3 mt-3">Postal address and exact location of establishment</h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Distric</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select District" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                            <asp:ListItem Text="Select Village" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Locality *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtlocate" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Pincode *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtpin" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nearest Landmark *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLandmark" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Do you have any other office/godown/warehouse attached to this establishment situated in a different premises *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblOwnership" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblOwnership_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="SO" id="DETAILSGRID" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">

                                                <h4 class="card-title ml-3 mt-3">Situation of Office, Storeroom or workplace attached to the establishment</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            Distric</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddldist" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddldist_SelectedIndexChanged">
                                                                <asp:ListItem Text="Select District" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Mandal</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlMAND" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMAND_SelectedIndexChanged">
                                                                <asp:ListItem Text="Select Mandal" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Village</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlVilla" runat="server" class="form-control">
                                                                <asp:ListItem Text="Select Village" Value="0" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Locality *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLocal" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Pincode  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtpincode" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">

                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="btnaddmore" Text="Add More" runat="server" OnClick="btnaddmore_Click" CssClass="btn btn-sm btn-rounded btn-green" Width="110" />
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>



                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVDETAILS" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None"
                                                    Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVDETAILS_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Distric" DataField="RENWP_DISTRIC" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Mandal" DataField="RENWP_MANDAL" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Village" DataField="RENWP_VILLAGE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Locality" DataField="RENWP_LOCALITY" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Pincode" DataField="RENWP_PINCODE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>

                                    </div>
                                    <div id="TestGrid" runat="server" visible="false">
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3 mt-3">Details of employer's family employed in the establishment and residing with and wholly dependent upon him</h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Gender</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Transgender" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Age *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAge" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Relationship</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlRelation" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:Button ID="btnAdd" Text="Add More" runat="server" OnClick="btnAdd_Click" CssClass="btn btn-sm btn-rounded btn-green" Width="110" />
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex justify-content-center">
                                        <asp:GridView ID="GVTEST" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                            GridLines="None"
                                            Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVTEST_RowDeleting">
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Name" DataField="RENED_NAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Gender" DataField="RENED_GENDER" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Age" DataField="RENED_AGE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Relationship" DataField="RENED_RELATIONSHIP" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                            </Columns>
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <h4 class="card-title ml-3 mt-3">Renewal Details</h4>
                                </div>
                                <div class="col-md-12 d-flex">

                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Registration will be renewed from date :</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Label ID="lblRegDate" runat="server" class="form-control"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Registration will be valid upto date:</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Label ID="lblRegUptoDate" runat="server" class="form-control"></asp:Label>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">No of years renewed :</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Label ID="lblYearRenewed" runat="server" class="form-control"></asp:Label>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Fees :</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Label ID="lblFees" runat="server" class="form-control"></asp:Label>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Fees for change notice :</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Label ID="lblFeesChange" runat="server" class="form-control"></asp:Label>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Fine :</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Label ID="lblFine" runat="server" class="form-control"></asp:Label>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Penalty :</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Label ID="lblPenalty" runat="server" class="form-control"></asp:Label>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Total amount to be paid :</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Label ID="lblTotalPaid" runat="server" class="form-control"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 text-right mt-2 mb-2">

                                    <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" OnClick="btnPreviuos_Click" />
                                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded  btn-info btn-lg" Width="150px" OnClick="btnNext_Click" />

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
            <asp:PostBackTrigger ControlID="btnphoto" />
            <asp:PostBackTrigger ControlID="btndpr" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
