<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="Grievance.aspx.cs" Inherits="MeghalayaUIP.User.Grievance.Grievance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Grievance</h4>
                        </div>
                        <div class="card-body">
                            <div class="col-md-12 justify-content-center d-flex">
                                <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                                    <strong>Success!</strong> <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 justify-content-center d-flex">
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                                    <strong>Warning!</strong> <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                            <div class="row">
                                <div class="col-md-12 d-flex">
                                   <h4 class="card-title ml-3"> <asp:Label ID="LabelHeading" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="199px"></asp:Label></h4>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Register Your *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlRegisterAs" runat="server" class="form-control txtbox"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlRegisterAs_SelectedIndexChanged">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="G">Grievance</asp:ListItem>
                                                    <asp:ListItem Value="Q">Query</asp:ListItem>                                                    
                                                    <asp:ListItem Value="F">Feedback</asp:ListItem>
                                                    <%--<asp:ListItem Value="Q">General Query</asp:ListItem>--%>
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Application Category *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlModule" runat="server" class="form-control"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" id="trData" visible="true" runat="server">
                                        <div class="form-group row" runat="server" id="divPreReg" visible="false">
                                            <label class="col-lg-6 col-form-label">Select Unit *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlPreRegUnits" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlPreRegUnits_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row" runat="server" id="divCFE" visible="false">
                                            <label class="col-lg-6 col-form-label">Select Unit *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlCFEUnits" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlCFEUnits_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row" runat="server" id="divCFO" visible="false">
                                            <label class="col-lg-6 col-form-label">Select Unit *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlCFOUnits" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlCFOUnits_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row" runat="server" id="divIncentives" visible="false">
                                            <label class="col-lg-6 col-form-label">Select Unit *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlIncUnits" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlIncUnits_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row" runat="server" id="divRenewals" visible="false">
                                            <label class="col-lg-6 col-form-label">Select Unit *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlRENUnits" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlRENUnits_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label" >Industry Name *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtindname" runat="server" class="form-control txtbox"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row" runat="server" id="divapplname" visible="true">
                                            <label class="col-lg-6 col-form-label">Applicant Name *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtApplcantName" runat="server" class="form-control txtbox"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">E-Mail *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control txtbox" TextMode="Email"
                                                    MaxLength="40" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                   <div class="col-md-12 d-flex">
                                       <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mobile Number *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMob" runat="server" class="form-control txtbox"
                                                    MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                       <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">District Name *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddldist" runat="server" class="form-control txtbox"
                                                    TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" >
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Select Department *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddldept" runat="server" class="form-control txtbox"
                                                    TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>                                
                                </div>

                                <div class="col-md-12 d-flex">                                    
                                    <div class="col-md-4" >
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Subject *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtSub" runat="server" class="form-control txtbox"
                                                    MaxLength="40" TabIndex="1" TextMode="MultiLine"
                                                    ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label">Description *</label>
                                            <div class="col-lg-9 d-flex">
                                                <asp:TextBox ID="txtDesc" runat="server" class="form-control txtbox"
                                                   TabIndex="1" TextMode="MultiLine"
                                                    ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Upload </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:FileUpload ID="FileUpload" runat="server"
                                                    Height="28px" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group row mt-1">
                                            <asp:HyperLink ID="lblFileName1" runat="server" Target="_blank"></asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="col-md-6">
                                            <asp:Label ID="Label560" runat="server" Visible="False"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Button ID="BtnUpload" runat="server" CssClass="form-control txtbox"
                                                TabIndex="10" Text="Upload1"
                                                Visible="False" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-12 float-end">
                                        <div class="form-group row justify-content-end">
                                            <asp:Button ID="btnClear" Text="Clear" Visible="true" runat="server" class="btn btn-rounded btn-warning btn-lg" OnClick="btnClear_Click" Width="150px" />
                                            <asp:Button runat="server" Text="Submit" ID="btnsave" OnClick="btnsave_Click" class="btn btn-rounded btn-submit btn-lg mr-2" Width="150px" />
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
