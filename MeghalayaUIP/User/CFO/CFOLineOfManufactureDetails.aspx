<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOLineOfManufactureDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOLineOfManufactureDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
    //let originalValue = "";
    function handleKeyUp(input)
    {
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
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" >
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">Line of Activity and RawMaterial Details</h3>
                                </div>
                                <div class="card-body">
                                    <!-- <h4 class="card-title">Personal Information</h4> -->
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
                                    <asp:HiddenField ID="hdnQuesID" runat="server" />
                                    <div class="row" id="divText" runat="server"  >
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Line of Activity*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlLineOfActivity" runat="server" class="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="divManf" runat="server" visible="true">
                                            <h4 class="card-title ml-3">Details Of Manufacture Items: </h4>

                                            <div class="col-md-12 d-flex" >
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Name of Product *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtManfItemName" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Annual Manufacturing Capacity (in Tons)</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtManfAnnualCapacity" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Approx. Value in Lakhs</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtManfValue" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex justify-content-center">
                                                <div class="col-md-4 d-flex justify-content-center">
                                                    <asp:Button ID="btnAddLOM" Text="Add Details" runat="server" OnClick="btnAddLOM_Click" class="btn btn-rounded btn-green" Width="110px" />
                                                </div>
                                            </div>
                                            <br />
                                            <div class="col-md-12 d-flex justify-content-center ml-3 mb-3">
                                                <div class="col-md-8">
                                                    <asp:GridView ID="gvManufacture" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="Both" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="gvManufacture_RowDeleting">
                                                        <RowStyle BackColor="#ffffff" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Name of Product" DataField="CFOLM_ITEMNAME" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Annual Manufacturing Capacity (in tonne)" DataField="CFOLM_ITEMANNUALCAPACITY" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Appox. value (₹)" DataField="CFOLM_ITEMVALUE" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>
                                                <div class="col-md-4"></div>
                                            </div>
                                        </div>

                                        <h4 class="card-title ml-3 mt-3">Details Of Raw Materials Used in Process:</h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Name of major raw material  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRMItemName" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Annual Manufacturing Capacity (in tonne)*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRMAnnualCapacity" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" MaxLength="7" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        3. Appox. value (₹ in lakhs) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRMValue" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="7" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4. Source(s) of supply</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRMSource" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Button ID="btnaddRM" Text="Add Details" runat="server" OnClick="btnaddRM_Click" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="col-md-12 d-flex justify-content-center ml-3 mb-3">
                                            <asp:GridView ID="gvRwaMaterial" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                GridLines="Both" OnRowDeleting="gvRwaMaterial_RowDeleting"
                                                Width="100%" EnableModelValidation="True" Visible="false">
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Name of major raw material" DataField="CFORM_ITEMNAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="CFORM_ITEMANNUALCAPACITY" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="CFORM_ITEMVALUE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Source(s) of supply" DataField="CFORM_SOURCEOFSUPPLY" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                </Columns>
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>


                                        <div class="col-md-12 text-right mb-3">

                                            <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-success btn-lg" Width="150px" />
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
