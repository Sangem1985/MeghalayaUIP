<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEHazWasteDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEHazWasteDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">

        <div class="content container-fluid">

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">Pollution Control Details</h3>
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

                                <h4 class="card-title ml-3">Authorization Required</h4>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-8 col-form-label">Authorization required for (Please tick appropriate activity or activities *</label>
                                            <div class="col-lg-11 d-flex">
                                                <asp:CheckBoxList ID="CHKAuthorized" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Generation" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Collection" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Storage" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Transportation" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Reception" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="Reuse" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="Recycling" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="Recovery" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="Pre-processing" Value="9"></asp:ListItem>
                                                    <asp:ListItem Text="Co-processing" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="Utilization" Value="11"></asp:ListItem>
                                                    <asp:ListItem Text="Treatment" Value="12"></asp:ListItem>
                                                    <asp:ListItem Text="Disposal" Value="13"></asp:ListItem>
                                                    <asp:ListItem Text="Incineration" Value="14"></asp:ListItem>
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <h4 class="card-title ml-3">Nature and Quantity</h4>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Nature and Quantity to waste handled per annum (in Metric Tons) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMetricTons" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Nature and Quantity to waste stored at any time (in Metric Tons) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtstoredtons" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Nature and Quantity to waste handled per annum (in Kilo Litre) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtwasteannum" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Nature and Quantity to waste stored at any time (in Kilo Litre)  *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtnature" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Year of commissioning and commence of production *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtYearpro" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Whether the industry works:- *</label>
                                            <div class="col-lg-11 d-flex">
                                                <asp:CheckBoxList ID="chkindustrywork" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="01 Shift" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="02 Shifts" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Round the clock" Value="3"></asp:ListItem>
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <br />
                                </div>
                                <div class="col-md-12 text-right">
                                    <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
