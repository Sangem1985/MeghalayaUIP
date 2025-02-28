<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CDWMDetails.aspx.cs" Inherits="MeghalayaUIP.User.Services.CDWMDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        input[type=checkbox], input[type=radio] {
            box-sizing: border-box;
            padding: 6px 0px !important;
            margin: 0px 6px !important;
        }

        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
        function handleKeyUp(input) {
            if (input.value.trim() === "") {
                input.style.border = "2px solid red";
            }
            else {
                input.style.border = "1px solid #767575b5";
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a>Services</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Construction and Demolition Waste Management</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" runat="server" id="divText">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Application for obtaining authorization for Construction and Demolition Waste Management:</h4>
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
                                            <h4 class="card-title ml-3">1. Particulars of Application: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex" style="margin-top: -10px;">
                                            <div class="col-md-8">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">
                                                        Name of the local authority/Name of the agency appointed by the municipal authority :
                                                    </label>
                                                    <div class="col-lg-3">
                                                        <asp:TextBox ID="txtNameLocalAuth" Type="text" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex mt-2">
                                            <h4 class="card-title ml-3">2. Details of the competent authority or agency responsible for operation of processing or recycling or disposal facility): </h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Name of Nodal Officer*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNodalOff" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Designation of Nodal Officer *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtNodalDesgn" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        3. Authorization required for*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlAuthorization" runat="server" class="form-control" AutoPostBack="true">
                                                            <asp:ListItem Text="-- Select --" Value="" Selected="True" Disabled="True"></asp:ListItem>
                                                            <asp:ListItem Text="Setting up of processing *" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Recycling facility of construction and demolition waste" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex mt-2">
                                            <h4 class="card-title ml-3">3. Detailed proposal of construction and demolition waste processing or recycling facility to include the following: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Average quantity (in tons per day) and composition of construction and demolition waste to be handled at the specific site*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAvgQuan" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Quantity of construction and demolition waste to be processed per day *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtQuanWasteProc" runat="server" class="form-control" Type="text" onkeypress="return validateNameAndNumbers(event)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        3. Site clearance from Prescribed Authority*
                                                    </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:RadioButtonList ID="rblSiteClearance" runat="server" RepeatDirection="Horizontal" RepeatColumns="2" Style="padding: 20px">
                                                            <asp:ListItem Text="(i) Yes " Value="1" class="pr-4"></asp:ListItem>
                                                            <asp:ListItem Text="(ii) No" Value="2" class="pr-4"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex mt-4">
                                            <h4 class="card-title ml-3">4. Attachments: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex" style="margin-top: -25px;">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-3 col-form-label"></label>
                                                    <div class="col-lg-2 d-flex">
                                                    </div>
                                                    <div class="col-lg-4 d-flex">
                                                        <label class="col-lg-5 col-form-label">Reference No </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">1. Land Documents *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtLandDoc" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupLandDoc" runat="server" />

                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnDisposal" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypLandDoc" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblLandDoc" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">2. Site Plan/ Plant Layout *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtSitePlan" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupSitePlan" runat="server" />

                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="Button1" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypSitePlan" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblSitePlan" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">3. Detailed Project Report of construction and demolition waste processing or recycling facility*</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtReport" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupReport" runat="server" />

                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="Button2" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypReport" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblReport" runat="server" />
                                                </div>
                                            </div>
                                        </div>




                                        <div class="col-md-12 text-right mt-2 mb-2">
                                            <asp:Button ID="btnPrev" runat="server" Text="Previous" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
