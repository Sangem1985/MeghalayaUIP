<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCLabour7.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCLabour7" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <style>
        .SO {
            width: 100%;
        }

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
                    <li class="breadcrumb-item"><a href="SRVCUserDashboard.aspx">Other Services</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Labour Details</li>
                </ol>
            </nav>
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

                                        <p class="fw-bold ml-3">Name and Permanent Address of the Establishment (Principal Employer):</p>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Full name of the Establishment<span style="color: red">*</span> </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtFullNameEst" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Permanent address of the Establishment<span style="color: red">*</span> </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAddressEst" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        State<span style="color: red">*</span>

                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlSates" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSates_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select State" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

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
                                                    <label class="col-lg-6 col-form-label">Post Office</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPostEst" runat="server" class="form-control" TabIndex="1" MaxLength="6" onkeypress="return NumberOnly()"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Pincode<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPincodeEst" runat="server" class="form-control" TabIndex="1" MaxLength="6" onkeypress="return NumberOnly()"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <p class="fw-bold ml-3">Manager or Person Responsible for the Supervision and Control of the Establishment:</p>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name <span style="color: red">*</span> </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNameManager" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Address <span style="color: red">*</span> </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAddressManager" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        District<span style="color: red">*</span>

                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDistrictManager" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrictManager_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select District" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlMandalManager" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandalManager_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlVillageManager" runat="server" class="form-control">
                                                            <asp:ListItem Text="Select Village" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Police Station</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPoliceManager" runat="server" class="form-control" TabIndex="1" MaxLength="6" onkeypress="return NumberOnly()"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Post Office</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPostOfficeManager" runat="server" class="form-control" TabIndex="1" MaxLength="6" onkeypress="return NumberOnly()"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Pincode<span style="color: red">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtPincodeManager" runat="server" class="form-control" TabIndex="1" MaxLength="6" onkeypress="return NumberOnly()"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <p class="fw-bold ml-3">Details of the Building or Other Construction work to be carried on in the Establishment:</p>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nature of Building or Other Construction Work <span style="color: red">*</span> </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNatureConWork" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Maximum number of workers to be employed on any day <span style="color: red">*</span> </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtWorkEmpDay" runat="server" class="form-control" Type="text" onkeypress="return Address(event)" TabIndex="1"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Estimated date of commencement of construction work<span style="color: red">*</span>

                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtEmpDatework" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEmpDatework"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Estimated date of completion of the construction work<span style="color: red">*</span>
                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox runat="server" ID="txtEstConDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MM-yyyy" TargetControlID="txtEstConDate"></cc1:CalendarExtender>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 text-right mt-2 mb-2">

                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" OnClick="btnsave_Click" />
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
