<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOContractorsRegistration.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOContractorsRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
										<ol class="breadcrumb mb-0">
											<li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                                            <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Pre-Operational</a></li>
											
											<li class="breadcrumb-item active" aria-current="page">Public Work Department Details</li>
										</ol>
									</nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Public Work Department</h4>
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
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Service Specific Details</span></label>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <%-- <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Type of Application  *</label>
                                               <div class="col-lg-6">
                                                <asp:RadioButtonList ID="rblApplication" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text=" New Registration" Value="1" />
                                                    <asp:ListItem Text="Renewal" Value="2" />                                                                                               
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div> --%>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Purpose of Application  *</label>
                                            <div class="col-lg-6">
                                                <asp:RadioButtonList ID="rblPurApplication" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Roads" Value="1" />
                                                    <asp:ListItem Text="Building" Value="2" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-8 col-form-label">Choose the Class of Contractor registering for  *</label>
                                            <div class="col-lg-4">
                                                <asp:RadioButtonList ID="rblRegister" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblRegister_SelectedIndexChanged">
                                                    <asp:ListItem Text="Class I" Value="1" />
                                                    <asp:ListItem Text="Class II" Value="2" />
                                                    <asp:ListItem Text="Class III" Value="3"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <%--   <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Name of Applicant  :</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtNameApplicant" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>--%>
                                </div>
                                <%--   <div class="col-md-12 d-flex">
                                      <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Type of Applicant  *</label>
                                               <div class="col-lg-4">
                                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Individual" Value="1" />
                                                    <asp:ListItem Text="Firm" Value="2" />                                                   
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div> 
                            </div>--%>
                                <div class="col-md-12 d-flex" id="applicant" runat="server" visible="false">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Type of Applicant </span></label>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6" id="director" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Directorate  *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlDirector" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6" id="circle" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Circle *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlCircle" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            <div class="col-md-12 d-flex" id="division" runat="server" visible="false">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-lg-6">Division  *</label>
                                        <div class="col-lg-4 d-flex">
                                            <asp:DropDownList runat="server" ID="ddlDivision" class="form-control">
                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 d-flex ml-3">
                                <label><span style="font-weight: 900;">Basic Details as Contractor </span></label>
                            </div>
                            <div class="col-md-12 d-flex">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">Name of Bank   :*</label>
                                        <div class="col-lg-4 d-flex">
                                            <asp:TextBox ID="txtNameBank" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">Turn Over (in Rs. Lakhs): *</label>
                                        <div class="col-lg-4 d-flex">
                                            <asp:TextBox ID="txtTurnOver" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 d-flex">
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">Total Value of Works in last 3 financial years (in Rs. Lakhs): *</label>
                                        <div class="col-lg-4 d-flex">
                                            <asp:TextBox ID="txtFinancial" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">Date from which working as contractor * :</label>
                                        <div class="col-lg-4 d-flex">
                                            <asp:TextBox ID="txtContractor" runat="server" class="form-control" Type="Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                                </div>
                            <div class="col-md-12 text-right mt-2 mb-2">

                                <asp:Button Text="Previous" runat="server" ID="btnPreviuos" OnClick="btnPreviuos_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                <asp:Button ID="btnNext" Text="Next" runat="server" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
