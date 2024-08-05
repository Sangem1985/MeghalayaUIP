<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEWaterDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEWaterDetails" %>

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
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Water Details</h4>
                                </div>
                                <div class="card-body">
                                    <!-- <h4 class="card-title">Personal Information</h4> -->

                                    <div class="row">
                                        <h5 class="card-title ml-4 mt-3">Water Consumption</h5>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1	Drinking Water ( in KL/Day )*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtwater" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2	Water for Processing(Industrial use) ( in KL/Day )</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtIndustrial" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3	Quantity of Water Required for Consumptive Use (in KL/Day)*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtQuantwater" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4	Quantity of Water Required for Non-Consumptive Use (in KL/Day)*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtwaterReq" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="tanker" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Distance of the Water tank from the road (approx):-*</label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Overhead *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtoverhead" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Underground</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtunderground" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Choose Available Tanker Capacity[In litres]</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:DropDownList ID="ddlTanker" runat="server" class="form-control">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                                <asp:ListItem Text="1800" Value="1" />
                                                                <asp:ListItem Text="4000" Value="2" />
                                                                <asp:ListItem Text="6000" Value="3" />
                                                                <asp:ListItem Text="10000" Value="4" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-2 col-form-label fw-bold"><span style="font-weight: 900;">Type Of Water Connection *</span></label>
                                                    <div class="col-lg-10">
                                                        <asp:RadioButtonList ID="rblwatercon" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblwatercon_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text=" Permanent Water Connection" Value="1" />
                                                            <asp:ListItem Text="Change Water Connection" Value="2" />
                                                            <asp:ListItem Text="Temporary Water Connection" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Commercial Water Connection" Value="4"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex" id="holdno" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Holding No </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtholding" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="100"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Select Ward No*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlwardno" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h5 class="card-title ml-4 mt-3">Commercial Establishment</h5>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1	Sub Divisional Office for Application *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtsubdivision" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2	Number of persons working in the premise </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtpremise" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="6"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3	Water requirement per day demand *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtdemand" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="2"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4	Any other information  </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtinformation" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNames(event)" MaxLength="200"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h5 class="card-title ml-4 mt-3">Water Connection Details</h5>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">District *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddldistric" runat="server" class="form-control" OnSelectedIndexChanged="ddldistric_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlmandal" runat="server" class="form-control" OnSelectedIndexChanged="ddlmandal_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlvillage" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
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
                                                        <asp:TextBox ID="txtlocality" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nearest Landmark</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtlandmark" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Pincode</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtpincode" runat="server" class="form-control" MaxLength="6" onkeypress="return validatePincode(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Purpose for which connection is required  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtconnection" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNames(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Type of connection *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlconnection" runat="server" class="form-control" OnSelectedIndexChanged="ddlconnection_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Domestic" Value="Y"></asp:ListItem>
                                                            <asp:ListItem Text="Bulk" Value="N"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="NominalDN" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Size of pipe connection for domestic(Diameter Nominal DN (mm))* </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDiameter" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex" id="DiameterDN" runat="server" visible="false">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Size of pipe connection(Diameter Nominal DN (mm))* </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDN" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 text-right mb-3">
                                            <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
