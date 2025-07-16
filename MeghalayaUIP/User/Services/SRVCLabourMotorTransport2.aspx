<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCLabourMotorTransport2.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCLabourMotorTransport2" %>

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
                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Motor Detail</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Nature of Motor Transport Service e.g. city Service, long distance, passenger service, long distance, freight service *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtname1" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Total number of routes</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtfather" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Total route mileage *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEmail1" runat="server" class="form-control" onblur="validateEmail(event)" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Total number of motor transport vehicles of the last date of the preceding year *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)" TabIndex="1" onblur="validateIndianMobileNumber(this);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Maximum number of Motor Transport Workers employed on any day during the preceding year  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox3" runat="server" class="form-control" MaxLength="10" onkeypress="return PhoneNumberOnly(event)" TabIndex="1" onblur="validateIndianMobileNumber(this);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Transport Undertaking</span></label>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Type of Transport Undertaking *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:RadioButtonList ID="rblTransport" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                                                            <asp:ListItem Text="Proprietorship" Value="1" />
                                                            <asp:ListItem Text="Partnership Firm" Value="2" />
                                                            <asp:ListItem Text="Registered under Companies Act, 1956" Value="3" />
                                                            <asp:ListItem Text="Public Sector Undertaking" Value="4" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-left: 20px" id="divProprietorship" runat="server" visible="true">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Proprietorship</span></label>
                                            </div>
                                          <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Full Name</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox7" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="200"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Residential Address</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox8" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>



                                        
                                        <div class="row" style="padding-left: 20px" id="divContrLabr" runat="server" visible="true">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Partnership Firm</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Full Name and Residential Address of Partners </span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Full Name</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtNameAddress" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="200"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Residential Address</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLocation" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label"></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="Addbtn" Text="Add Details" class="btn btn-rounded btn-green" runat="server" Fore-Color="White" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                          
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GVPartnership" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both" Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Full Name" DataField="CFECL_CONTRACTORNAMEADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Residential Address" DataField="CFECL_WORKNAMENATURELOCATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>


                                         <div class="row" style="padding-left: 20px" id="divCompanies1956" runat="server" visible="true">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Registered under Companies Act, 1956</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Full Name and Residential Address of Directors </span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Full Name</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox5" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="200"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Residential Address</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox6" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label"></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="Button1" Text="Add Details" class="btn btn-rounded btn-green" runat="server" Fore-Color="White" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                          
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both" Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <HeaderStyle HorizontalAlign="Center" BorderColor="White" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Full Name" DataField="CFECL_CONTRACTORNAMEADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Residential Address" DataField="CFECL_WORKNAMENATURELOCATION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>



                                        <div class="row" style="padding-left: 20px" id="divUndertaking" runat="server" visible="true">
                                            <div class="col-md-12 d-flex">
                                                <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Public Sector Undertaking</span></label>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Full Name of the General Manager  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox1" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="100"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Residential Address *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="TextBox4" runat="server" class="form-control" onkeypress="return Address(event)" TabIndex="1" MaxLength="50"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Vehicle Details</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Vehicle No  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox2" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="6" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Type of Vehicle *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TXTPIN" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="6" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 text-right mb-2">
                                        <asp:Button Text="Previous" runat="server" ID="btnPrevious" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        <asp:Button ID="Btnsave" runat="server" Text="Save" class="btn btn-rounded btn-success btn-lg" padding-right="10px" Width="150px" />
                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
