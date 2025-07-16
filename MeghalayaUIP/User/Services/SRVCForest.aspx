<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCForest.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCForest" %>

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
                    <li class="breadcrumb-item"><a href="SRVCUserDashboard.aspx">Other Services</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Forest Details</li>
                </ol>
            </nav>
            <div class="page-wrapper" id="divText" runat="server">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">Forest Details</h3>
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
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Forest Division<span class="text-danger">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlForest" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Type of Land<span class="text-danger">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlLandType" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Government Land" Value="Government Land" />
                                                            <asp:ListItem Text="Private Land" Value="Private Land" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="divDistanceLetter" runat="server" visible="false" class="row">
                                            <h4 class="card-title ml-3">Application Form For Letter For Distance From Forest- GPS Coordinates Details</h4>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-7 col-form-label">1. GPS Coordinates Latitude<span class="text-danger">*</span></label>
                                                        <div class="col-lg-5 d-flex">
                                                            <asp:RadioButtonList ID="RblLatitude" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="N" Value="N" />
                                                                <asp:ListItem Text="S" Value="S" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1a. Degrees(L)<span class="text-danger">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLatDegrees" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="5" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1b. Minutes(L) <span class="text-danger">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLatMinutes" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="5" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1c. Seconds(L)<span class="text-danger">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLatSeconds" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="5" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-7 col-form-label">2. GPS Coordinates Longitude<span class="text-danger">*</span></label>
                                                        <div class="col-lg-5 d-flex">
                                                            <asp:RadioButtonList ID="rblLongitude" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="E" Value="E" />
                                                                <asp:ListItem Text="W" Value="W" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2a. Degrees<span class="text-danger">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLongDegrees" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="5" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2b. Minutes<span class="text-danger">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLongMinutes" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="5" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2c. Seconds<span class="text-danger">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLongSeconds" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="6" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. GPS Coordinates (Description) <span class="text-danger">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtGPSCordinates" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Purpose of Application <span class="text-danger">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtDistncLtrPurpose" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5. Any other information <span class="text-danger">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtInformation" runat="server" class="form-control" onkeypress="return Names()" MaxLength="100" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                            </div>
                                        </div>
                                            <h4 class="card-title ml-3">Application Form For Non-Forest Land Certificate</h4>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Area of Land in Ha <span class="text-danger">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLandArea" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="50" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Purpose Non-Forest land Certificate sought <span class="text-danger">*</span></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtNFLPurpose" runat="server" class="form-control" TabIndex="1" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        <div class="row">                         
                                            <div class="col-md-12 d-flex">
                                                <br />
                                            </div>
                                            <div class="col-md-12 text-right">

                                                <asp:Button ID="btnPrevious" runat="server" Text="Previous" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                                <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                            </div>
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
