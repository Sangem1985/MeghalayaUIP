<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENDrugsLicenseDetails5.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENDrugsLicenseDetails5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <style>
        div#drug, div#drugothers, div#drugcommom {
            width: 100%;
            border: 1px solid #ccc;
            margin: 4px 15px;
            border-radius: 8px;
            padding: 0px 10px;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="RENUserDashboard.aspx">Renewal</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Drugs License Details</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" id="divText" runat="server">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Drugs License Details</h4>
                                </div>
                                <div class="card-body">
                                    <div class="col-md-12">
                                        <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span></button>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
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
                                        <div class="drug" id="drug">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Clinical establishment registration number</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Valid clinical establishment registration number    *</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtClinical" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-md-12 d-flex">
                                                <%--Renewal of license--%>
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Genetic Counselling Centre/Genetic Laboratory/Genetic Clinic/Ultrasound Clinic/Imaging Centre Details</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-8">
                                                    <div class="form-group row">
                                                        <label class="col-lg-8 col-form-label">Type of facility to be registered (Please specify whether the application is for registration of a Genetic Counselling Centre/ Genetic Laboratory/Genetic Clinic /Ultrasound Clinic/ Imaging Centre or any combination of these)  *</label>
                                                        <div class="col-lg-12 d-flex">
                                                            <asp:CheckBoxList ID="CHKRegistered" runat="server" RepeatDirection="Vertical" RepeatColumns="7" Style="padding: 20px">
                                                                <asp:ListItem Text="Genetic Counselling Centre" Value="1" style="padding-right: 20px"></asp:ListItem>
                                                                <asp:ListItem Text="Genetic Laboratory" Value="2" style="padding-right: 20px"></asp:ListItem>
                                                                <asp:ListItem Text="Genetic Clinic" Value="3" style="padding-right: 20px"></asp:ListItem>
                                                                <asp:ListItem Text="Ultrasound Clinic" Value="4" style="padding-right: 20px"></asp:ListItem>
                                                                <asp:ListItem Text="Imaging Centre" Value="5" style="padding-right: 20px"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Type of facility to be registered(Description) *</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtFacility" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Type of ownership of Organization  *</label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="rblLicense" runat="server" class="form-control" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLicense_SelectedIndexChanged">
                                                                <asp:ListItem Text="--Select--" Value="-1" />
                                                                <asp:ListItem Text="Individual ownership" Value="1" />
                                                                <asp:ListItem Text="Partnership" Value="2" />
                                                                <asp:ListItem Text="Company" Value="3" />
                                                                <asp:ListItem Text="Co-operative" Value="4" />
                                                                <asp:ListItem Text="State Government" Value="5" />
                                                                <asp:ListItem Text="Central Government" Value="6" />
                                                                <asp:ListItem Text="Any other to be specified" Value="7" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Type of Institution   *</label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="ddlType" runat="server" class="form-control" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                                <asp:ListItem Text="--Select--" Value="-1" />
                                                                <asp:ListItem Text="Private Clinic" Value="1" />
                                                                <asp:ListItem Text="Private laboratory" Value="2" />
                                                                <asp:ListItem Text="Govt. Hospital" Value="3" />
                                                                <asp:ListItem Text="Municipal Hospital" Value="4" />
                                                                <asp:ListItem Text="Private Hospital" Value="5" />
                                                                <asp:ListItem Text="Private Nursing Home" Value="6" />
                                                                <asp:ListItem Text="Any other to be stated" Value="7" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Decription *</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtDescription" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Specific pre-natal diagnostic procedures/tests for which approval is sought *</label>
                                                        <div class="col-lg-6">
                                                            <asp:DropDownList ID="ddlprenatal" runat="server" class="form-control" RepeatDirection="Horizontal" AutoPostBack="true">
                                                                <asp:ListItem Text="--Select--" Value="0" />
                                                                <asp:ListItem Text="(a) Invasive (i) amniocentesis/ chorionic villi aspiration /chromosomal /biochemical /molecular studies" Value="1" />
                                                                <asp:ListItem Text="(b) Non-Invasive Ultrasonography" Value="2" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4" id="otherownership" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Any other type of ownership to be stated*</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtOwnership" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" id="Starttype" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Any other type of institution to be stated *</label>
                                                        <div class="col-lg-6">
                                                            <asp:TextBox ID="txtanyinstitute" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Whether equipments already available   *</label>
                                                        <div class="col-lg-6">
                                                            <asp:RadioButtonList ID="rblequipments" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblequipments_SelectedIndexChanged">
                                                                <asp:ListItem Text="Yes" Value="Y" />
                                                                <asp:ListItem Text="No" Value="N" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>



                                            <div id="divequipment" runat="server" visible="false">
                                                <div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Equipment available with the make and model of each equipment</span></label>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Serial number of equipment *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtEquipmentmake" runat="server" class="form-control" onkeypress="return Names(this)" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Make and Model of equipment *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtMakeEquipment" runat="server" class="form-control" onkeypress="return Names(this)" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <div class="col-lg-12 d-flex">

                                                                <asp:Button ID="btnEquipment" runat="server" Text="Add More" OnClick="btnEquipment_Click" CssClass="btn btn-green btn-rounded" Width="110px" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 d-flex justify-content-center ml-3">
                                                    <asp:GridView ID="GVEquipment" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="None" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVEquipment_RowDeleting">
                                                        <RowStyle BackColor="#ffffff" BorderWidth="1px" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                            <asp:BoundField HeaderText="Serial number of equipment " DataField="SERIALEQUIPMENT" ItemStyle-Width="330px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                            <asp:BoundField HeaderText="Make and Model of equipment " DataField="MAKEEQUIPMENT" ItemStyle-Width="330px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                            <br />

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">(a).Facilities available in the Counselling Centre    *</label>
                                                        <div class="col-lg-4">
                                                            <asp:TextBox ID="txtFciliites" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Name of Radiologists/Sonologists</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Name of radiologist / sonologist  *</label>
                                                        <div class="col-lg-4 d-flex">
                                                            <asp:TextBox ID="txtRadiologist" runat="server" class="form-control" onkeypress="return Names(this)" onkeyup="handleKeyUp(this)"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <div class="col-lg-12 d-flex">

                                                            <asp:Button ID="btnradiologist" runat="server" Text="Add More" OnClick="btnradiologist_Click" CssClass="btn btn-green btn-rounded" Width="110px" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 d-flex justify-content-center ml-3">
                                                <asp:GridView ID="GVRADIO" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="None" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVRADIO_RowDeleting">
                                                    <RowStyle BackColor="#ffffff" BorderWidth="1px" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name of radiologist / sonologist" DataField="RENR_RADIONAME" ItemStyle-Width="330px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
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
