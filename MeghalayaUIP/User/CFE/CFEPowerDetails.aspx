<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEPowerDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEPowerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">

        <div class="content container-fluid">

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Power Details</h4>
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

                                <h5 class="card-title ml-4">Power*</h5>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1	Connected Load in HP*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtHP" runat="server" class="form-control"></asp:TextBox>
                                                <span class="form-text text-muted mt-2 ml-2">HP</span>
                                                <!-- <span class="mt-2">HP</span> -->
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2	Contracted Maximum Demand in KVA *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMaxDemand" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3 	Required Voltage Level*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlvtglevel" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="EXISTING" runat="server" visible="false">
                                <div class="col-md-12 d-flex">

                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4	Any Other Services Existing in the Same Premises*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlPermise" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                    </div>

                                <h5 class="card-title ml-4">Proposed Maximum Working Hours</h5>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1	Per Day*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMaxhours" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2	Per Month*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMonth" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3	Expected Month and Year of Trial Production(DD/MM/YYYY)</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txttrailProduct" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4	Probable Date of Requirement of Power Supply(DD/MM/YYYY)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPowersupply" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">5 Quantum of energy/load required (in KW) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtenergy" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">6	Proposed source of energy/load*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlloadenergy" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>



                                <div class="col-md-12 d-flex mt-2">
                                    <div class="col-md-6">
                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos1" class="btn  btn-info btn-lg" />
                                        <asp:Button Text="Clear" runat="server" ID="btnclear" class="btn  btn-info btn-lg" />
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <asp:Button ID="btnsave1" runat="server" Text="Save" class="btn btn-rounded btn-info btn-lg" padding-right="10px" BackColor="Green" OnClick="btnsave1_Click" />
                                        <asp:Button ID="btnNext1" Text="Next" runat="server" class="btn  btn-info btn-lg" />
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
