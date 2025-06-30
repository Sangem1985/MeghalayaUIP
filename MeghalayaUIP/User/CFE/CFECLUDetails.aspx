<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFECLUDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFECLUDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="#">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="#">Pre Establishment</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Change Of Land Use (CLU)</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">Change Of Land Use (CLU) </h3>
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
                                    <asp:HiddenField ID="hdnPreRegUID" runat="server" />

                                    <div class="row">
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">Land Details: </h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">District<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDistric" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistric_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Distric" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="Select Mandal" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village/Town<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                            <asp:ListItem Text="Select Village" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12  d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Extent of Land<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtLand" runat="server" class="form-control"  onkeypress="return validateNumberAndDot(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Type of Ownership<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlownership" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Individual" Value="1" />
                                                            <asp:ListItem Text="Institutional" Value="2" />
                                                            <asp:ListItem Text="Company" Value="3" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12  d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-2 col-form-label">
                                                        Ownership Proof(upload)<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:CheckBoxList ID="CHKAuthorized" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" Style="padding: 20px" OnSelectedIndexChanged="CHKAuthorized_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="Sale Deed" Value="1" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Patta" Value="2" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Land Holding Certificate" Value="3" style="padding-right: 20px"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h4 class="card-title ml-3">Current and Proposed Land Use: </h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Current Land Use<span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:DropDownList ID="ddlCurrentLand" runat="server" class="form-control" OnSelectedIndexChanged="ddlCurrentLand_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Agricultural" Value="1" />
                                                            <asp:ListItem Text="Residential" Value="2" />
                                                            <asp:ListItem Text="Industrial" Value="3" />
                                                            <asp:ListItem Text="Others" Value="4" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Proposed Land Use<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlLandProposed" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Residential" Value="1" />
                                                            <asp:ListItem Text="Commercial" Value="2" />
                                                            <asp:ListItem Text="Industrial" Value="3" />
                                                            <asp:ListItem Text="Institutional" Value="4" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="divOther" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Others<span class="star">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtOther" runat="server" class="form-control" MaxLength="7" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <h4 class="card-title ml-3">Document to Upload</h4>

                                         <div class="col-md-12 d-flex" id="divSaleDeed" runat="server" visible="false">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Sale Deed<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupSaledeed" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnSaledeed" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypSaledeed" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblSaledeed" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex" id="divPatta" runat="server" visible="false">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Patta<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupPatta" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnPatta" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypPatta" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblPatta" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex" id="divLand" runat="server" visible="false">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Land Holding Certificate<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupLand" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnLand" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypLand" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblLand" runat="server" />
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Location Map(Showing access)<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupLocation" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnLocation" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypLocation" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblLocation" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Self-Declaration/Affidavit<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupAffidavit" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnAffidavit" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypAffidavit" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblAffidavit" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">NOCs(if near forest/water bodies)<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupNOC" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnNOC" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypNOC" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblNOC" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Longitude and Latitude of the Plot<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload ID="fupLatitude" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnLatitude" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:HyperLink ID="hypLatitude" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblLatitude" runat="server" />
                                                </div>
                                            </div>
                                        </div>



                                    </div>
                                </div>
                                <div class="col-md-12 text-right mb-2">
                                    <asp:Button Text="Previous" runat="server" ID="btnPrevious" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
