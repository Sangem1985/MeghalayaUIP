<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="INCSubsidyOnPCM.aspx.cs" Inherits="MeghalayaUIP.User.INCENTIVE.INCSubsidyOnPCM" %>

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
                                    <h4 class="card-title">10.Subsidy on cost incurred on pollution control measure </h4>
                                </div>
                                <div class="card-body">

                                    <div class="row">
                                        <h5 class="card-title ml-3 mt-3">Subsidy on cost incurred on pollution control measure  </h5>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">10.1	A brief note on Pollution Control measure adopted *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtSubsidycost" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h5 class="card-title ml-3 mt-3">10.2	Details of Machineries/Instruments installed	  </h5>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name & specification of the Equipments for pollution control	 *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDetails" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of purchase*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDatePurchase" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of installation/commissioning  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDateComm" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name & address of supplier *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Cost (in  ) *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtCost" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex justify-content-center">
                                            <div class="col-md-4 text-center">
                                                <asp:Button ID="btnbuttons" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex justify-content-center">
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                GridLines="None"
                                                Width="100%" EnableModelValidation="True" Visible="false">
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="Name & specification of the Equipments for pollution control" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Date of purchase" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Date of installation/commissioning " DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField HeaderText="Name & address of supplier" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                     <asp:BoundField HeaderText="Cost (in  )" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
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
                                                    <label class="col-lg-6 col-form-label">10.3	Amount of subsidy claimed  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAmount" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>                                          
                                        </div>

                                        <h5 class="card-title ml-4 mt-3">Upload Document</h5>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(i)	Energy Bills & Money Receipts to be enclosed</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupBillsMoney" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnBillsMoney" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypBillsMoney" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblBillsMoney" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(ii)	Expenditure should be certified by Chartered Accountant for units other than Micro Enterprise.</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupMicroEnterprise" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnMicroEnterprise" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypMicroEnterprise" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblMicroEnterprise" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(iii) List of employees verified by Enquiry Officer and endorsed/countersigned by General Manager.</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupemployees" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnemployees" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypemployees" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblemployees" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(iv)	List of employees filed with EPF office, if applicable</label>
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
            <asp:PostBackTrigger ControlID="btnBillsMoney" />
            <asp:PostBackTrigger ControlID="btnMicroEnterprise" />
            <asp:PostBackTrigger ControlID="btnemployees" />
            <asp:PostBackTrigger ControlID="btnEmployeEPF" />           
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
