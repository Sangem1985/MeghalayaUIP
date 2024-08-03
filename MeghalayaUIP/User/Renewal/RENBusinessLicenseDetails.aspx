<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENBusinessLicenseDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENBusinessLicenseDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
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
                    <li class="breadcrumb-item active" aria-current="page">Business License Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Business License Details</h4>
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
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Existing License Details</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Previous License Number*</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLicNo" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License Issue Date *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLicIssue" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">License Valid Upto *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLicValid" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Basic Details</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of the Shop/Business Establishment *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNameBusiness" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                            <%--  <div class="col-md-4">
                                            <div class="form-group row">
                                               <label class="col-lg-6 col-form-label"> *</label>
                                                <div class="col-lg-6 d-block">
                                                    <div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_male" value="option1" checked="">
															<label class="form-check-label" for="gender_male">
															
															</label>
														</div>
														<div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_female" value="option2">
															<label class="form-check-label" for="gender_female">
															
															</label>
														</div>
                                                    
                                                </div>
                                            </div>
                                        </div>--%>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Whether Establishment is owned by *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblOwned" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Firm/Company" Value="Y" />
                                                            <asp:ListItem Text="Individual" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name of the Individual/authorized representative *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtIndividualName" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mobile Number *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">E-Mail Id *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtEmailId" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Passport Size Photograph of Individual/Authorized Representative *</label>
                                                    <div class="col-lg-6">
                                                        <asp:FileUpload ID="fupDPR" runat="server" />
                                                        <asp:HyperLink ID="hypdpr" runat="server" Target="_blank"></asp:HyperLink>
                                                        <asp:Label ID="lbldpr" runat="server" />
                                                        <asp:Button Text="Upload DPR" runat="server" ID="btndpr" OnClick="btndpr_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        <input class="form-control" type="file" id="formFile"><i class="fi fi-br-circle-camera"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Establishment Address</span></label>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Address of the establishment *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtAddress" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nature of Business  *</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtNatureBusiness" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Type of Establishment  *</label>
                                                    <div class="col-lg-6">
                                                        <asp:RadioButtonList ID="rblApplication" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Private owned establishment" Value="Y" />
                                                            <asp:ListItem Text="Municipal owned shop/establishment" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 text-right mt-2 mb-2">

                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
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
         <Triggers>
            <asp:PostBackTrigger ControlID="btndpr" />           
            
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
