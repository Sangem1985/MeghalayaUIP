<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENDrugsLicenseDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENDrugsLicenseDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        div#drug, div#drugothers, div#drugcommom {
    width: 100%;
    border: 1px solid #ccc;
    margin: 4px 15px;
    border-radius: 8px;
    padding: 0px 10px;
}
    </style>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Renewal</a></li>

            <li class="breadcrumb-item active" aria-current="page">Drugs License Details</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Drugs License Details</h4>
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
                               <div class="drug" id="drug">
                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Renewal of license</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-4 col-form-label">License Number *</label>
                                                <div class="col-lg-8">
                                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Expiry date of license *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox2" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="col-md-12 d-flex">
                                         <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label">Do you hold any previous cancelled license? *</label>
                                                <div class="col-lg-4 d-flex">
														<div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_male" value="option1" checked="">
															<label class="form-check-label" for="gender_male">
															Yes
															</label>
														</div>
														<div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_female" value="option2">
															<label class="form-check-label" for="gender_female">
															No
															</label>
														</div>
													</div>
                                            </div>
                                        </div>
                                         <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Please specify license no *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    

                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Drug Details</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-4 col-form-label">Name of the Drug *</label>
                                                <div class="col-lg-8 d-flex">
                                                    <asp:TextBox ID="txttradeLic" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <div class="col-lg-12 d-flex">
                                                    
                                                    <asp:Button id="btn" runat="server" Text="Add More" CssClass="btn btn-green btn-rounded" Width="110px"/>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">Grid</div>
                                    </div>
                                    
                              
                                
                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Details of Technical Staff employed for Manufacturing and Testing</span></label>
                                </div>
                                     <div class="col-md-12 d-flex">
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name *</label>
                                                <div class="col-lg-6 d-flex">
														<asp:TextBox ID="TextBox5" runat="server" class="form-control" Type="text"></asp:TextBox>
													</div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Qualification *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox4" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Experience *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox6" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                <div class="col-md-12 d-flex justify-content-end">
                                   <asp:Button id="Button1" runat="server" Text="Add More" CssClass="btn btn-green btn-rounded mt-2 mb-4" Width="110px"/>
                                </div>

                                <div class="col-md-12 d-flex">
                                         <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label">Is the premise and plan ready for inspection? *</label>
                                                <div class="col-lg-4 d-flex">
														<div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_male" value="option1" checked="">
															<label class="form-check-label" for="gender_male">
															Yes
															</label>
														</div>
														<div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_female" value="option2">
															<label class="form-check-label" for="gender_female">
															No
															</label>
														</div>
													</div>
                                            </div>
                                        </div>
                                         <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Date for Inspection *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox7" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Fees Details</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-4 col-form-label">Total Amount to be Paid (Rs.) *</label>
                                                <div class="col-lg-8 d-flex">
                                                    <asp:TextBox ID="TextBox8" runat="server" class="form-control" Type="Text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        

                                    </div>
                                   </div>
                                <div class="drugcommon" id="drugcommom">
                                    <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Details of Technical Staff employed for Manufacturing</span></label>
                                </div>
                                     <div class="col-md-12 d-flex">
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name *</label>
                                                <div class="col-lg-6 d-flex">
														<asp:TextBox ID="TextBox9" runat="server" class="form-control" Type="text"></asp:TextBox>
													</div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Qualification *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox10" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Experience *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox11" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                <div class="col-md-12 d-flex justify-content-end">
                                   <asp:Button id="Button2" runat="server" Text="Add More" CssClass="btn btn-green btn-rounded mt-2 mb-4" Width="110px"/>
                                </div>
                                </div>

                                <div class="drug" id="drugothers">
                                    

                                    <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Additional Item</span></label>
                                </div>

                                     <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-4 col-form-label">Specify if any additional item is required *</label>
                                                <div class="col-lg-8 d-flex">
                                                    <asp:TextBox ID="TextBox12" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <div class="col-lg-12 d-flex">
                                                    
                                                    <asp:Button id="Button3" runat="server" Text="Add More" CssClass="btn btn-green btn-rounded" Width="110px"/>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">Grid</div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Additional Item Fees Details</span></label>
                                </div>
                                     <div class="col-md-12 d-flex">
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Additional Fees To be Paid (Rs.) *</label>
                                                <div class="col-lg-6 d-flex">
														<asp:TextBox ID="TextBox13" runat="server" class="form-control" Type="text"></asp:TextBox>
													</div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Late Fees *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox14" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Registration Fees to be Paid(Rs.) *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox15" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         
                                    </div>
                                    <div class="col-md-12  d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Total Amount to be Paid (Rs.)  *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox16" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    </div>
                                
                                   
                                <div runat="server" id="div_52" visible="false">
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Is the premise and plan ready for inspection? *</label>
                                                <div class="col-lg-4">
                                                    <%--<asp:RadioButtonList ID="rblinsection" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblinsection_SelectedIndexChanged">
                                                        <asp:ListItem Text="Yes" Value="1" />
                                                        <asp:ListItem Text="No" Value="2" />
                                                    </asp:RadioButtonList>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="InspectionDate" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Date for Inspection *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtInspection" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                      </div>
                                <div id="div_Staff_Manf" runat="server" visible="false">
                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Details of Technical Staff employed for Manufacturing</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Qualification *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtQualification" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Experience(Years)*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtExperience" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex justify-content-center">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-10 col-form-label"></label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button ID="btnAdd" Text="Add Details" class="btn btn-rounded btn-green" runat="server"  Width="110px" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="table-responsive">
                                                <asp:GridView ID="GVHealthy" runat="server" AutoGenerateColumns="False"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD table-hover table-striped"
                                                    GridLines="None"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Name" DataField="CFODM_EMPNAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Qualification" DataField="CFODM_EMPQLFCATION" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Experience" DataField="CFODM_EMPEXPRNC" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                  </div>
                                  <div runat="server" visible="false" id="div_Staff_Test">
                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Details Of Technical Staff Employed For Testing</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNameTest" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Qualification *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtQualifyTest" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Experience(Years)*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtExperienceTest" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex justify-content-center">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-10 col-form-label"></label>
                                                <div class="col-lg-2 d-flex">
                                                    <asp:Button ID="addbutton" Text="Add Details" class="btn btn-rounded btn-green" runat="server" Width="110px" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex justify-content-center">
                                        <asp:GridView ID="GVTESTING" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD"
                                            GridLines="None" Width="100%" EnableModelValidation="True" Visible="false">
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>

                                                <asp:BoundField HeaderText="Name" DataField="CFODT_EMPNAME" ItemStyle-Width="40%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Qualification" DataField="CFODT_EMPQLFCATION" ItemStyle-Width="30%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField HeaderText="Experience" DataField="CFODT_EMPEXPRNC" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-Width="10%" />

                                            </Columns>
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div runat="server" id="div_48" visible="false">
                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Drug Details</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of Drug  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNameDrug" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Button ID="ADDBTN" Text="Add Details" class="btn btn-rounded btn-green" runat="server" Width="110px" />
                                        </div>
                                    </div>
                                    <%-- <div class="col-md-12 d-flex justify-content-center">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-10 col-form-label"></label>
                                            <div class="col-lg-2 d-flex">
                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                                    <div class="col-md-12 d-flex justify-content-center">
                                        <asp:GridView ID="GVDrug" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                            GridLines="None"
                                            Width="100%" EnableModelValidation="True" Visible="false">
                                            <RowStyle BackColor="#ffffff" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                <asp:BoundField HeaderText="Name of Drug " DataField="CFOD_DRUGNAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                            </Columns>
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                    <%--   <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Additional Item</span></label>
                                </div> 
                                   <div class="col-md-12 d-flex">
                                         <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Specify if any additional item is required *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtItemreq" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                       </div>
                                 <div class="col-md-12 d-flex justify-content-center">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label"></label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Button ID="btnadds" Text="Add Details" class="btn  btn-info btn-lg" runat="server" Fore-Color="White" BackColor="YellowGreen" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                     <div class="col-md-12 d-flex justify-content-center">
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="None"
                                        Width="100%" EnableModelValidation="True" Visible="false">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Specify if any additional item is required" DataField="" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                          
                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>--%>
                                </div>
                                <div class="col-md-12 text-right mt-2 mb-2">

                                    <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded  btn-info btn-lg" Width="150px" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
