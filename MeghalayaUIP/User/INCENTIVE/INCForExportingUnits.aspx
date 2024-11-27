<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="INCForExportingUnits.aspx.cs" Inherits="MeghalayaUIP.User.INCENTIVE.INCForExportingUnits" %>

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
                                    <h4 class="card-title">12.Special incentive for Export Oriented Unit   </h4>
                                </div>
                                <div class="card-body">

                                    <div class="row">
                                        <h5 class="card-title ml-3 mt-3">Special incentive for Export Oriented Unit  </h5>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12.1	Name and specification of product  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtSubsidycost" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12.2	Installed manufacturing capacity  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox1" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12.3	Production  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox2" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Items of production  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Quantity produced during   *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtCost" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Quantity produced during   *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox3" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Quantity produced during  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox4" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4 text-center">
                                                <asp:Button ID="btnAddLOM" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex justify-content-center">
                                            <asp:GridView ID="gvTeamMembers" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                GridLines="None"
                                                Width="100%" EnableModelValidation="True" Visible="false">
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Items of production" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Quantity produced during" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Quantity produced during" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Quantity produced during" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                </Columns>
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>
                                        <br />
                                        <h5 class="card-title ml-3 mt-3">12.4	Products exported  </h5>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Items of export  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox5" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Quantity exported during    *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox6" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Quantity exported during   *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox7" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Quantity exported during  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox8" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4 text-center">
                                                <asp:Button ID="Button1" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex justify-content-center">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                GridLines="None"
                                                Width="100%" EnableModelValidation="True" Visible="false">
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Items of export" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Quantity exported during" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Quantity exported during" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Quantity exported during" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                </Columns>
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>
                                        <br />
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12.5	Name of Country(s) exported  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox9" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12.6	Amount of subsidy claimed     *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox10" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <h5 class="card-title ml-4 mt-3">Upload Document</h5>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(i) IE code and registration-cum membership certificate from concerned council of Export Ltd.</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupIEReg" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnIEReg" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypIEReg" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblIEReg" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(ii)	Shipping Bill/Bill of Export/Airway/Air Consignment Note as the case may be</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupBillAir" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnBillAir" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypBillAir" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblBillAir" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(iii) Commercial Invoice certificate by Custom Department</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupInvoice" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnInvoice" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypInvoice" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblInvoice" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(iv)	Bill of loading/combined Transport document or packing list certified by Custom Department</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupDepartment" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnDepartment" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypDepartment" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblDepartment" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(v)	Sales deed contract, if any</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupSalesdeed" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnSalesdeed" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypSalesdeed" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblSalesdeed" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(vi)	Certificate of Origin</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupCertOrigin" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnCertOrigin" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypCertOrigin" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblCertOrigin" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(vii) Letter of credit (s)</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupLetterCredit" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnLetterCredit" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypLetterCredit" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblLetterCredit" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(viii) Letter to the Bank (s) for collection/negotiation of documents</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupBankDocument" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnBankDocument" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypBankDocument" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblBankDocument" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(ix)	Any other documents</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupAnyDocument" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnAnyDocument" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypAnyDocument" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblAnyDocument" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(x)	List of employees verified by Enquiry Officer and endorsed/countersigned by General Manager.</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupEmpGM" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnEmpGM" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypEmpGM" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblEmpGM" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(xi)	List of employees filed with EPF office, if applicable</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupEmployeEPF" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnEmployeEPF" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypEmployeEPF" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblEmployeEPF" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                        <div class="col-md-12 text-right mb-3">
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnIEReg" />
            <asp:PostBackTrigger ControlID="btnBillAir" />
            <asp:PostBackTrigger ControlID="btnInvoice" />
            <asp:PostBackTrigger ControlID="btnDepartment" />
            <asp:PostBackTrigger ControlID="btnSalesdeed" />
            <asp:PostBackTrigger ControlID="btnCertOrigin" />
            <asp:PostBackTrigger ControlID="btnLetterCredit" />
            <asp:PostBackTrigger ControlID="btnBankDocument" />
            <asp:PostBackTrigger ControlID="btnAnyDocument" />
            <asp:PostBackTrigger ControlID="btnEmpGM" />
            <asp:PostBackTrigger ControlID="btnEmployeEPF" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
