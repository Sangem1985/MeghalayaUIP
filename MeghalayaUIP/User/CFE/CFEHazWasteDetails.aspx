<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEHazWasteDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEHazWasteDetails" %>

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
                                    <h3 class="card-title">Authorization under the Hazardous and Other Waste</h3>
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

                                        <h4 class="card-title ml-3">Authorization Required</h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-8 col-form-label">Authorization required for (Please tick appropriate activity or activities *</label>
                                                    <div class="col-lg-12 d-flex">
                                                        <asp:CheckBoxList ID="CHKAuthorized" runat="server" RepeatDirection="Vertical" RepeatColumns="7" Style="padding: 20px">
                                                            <asp:ListItem Text="Generation" Value="1" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Collection" Value="2" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Storage" Value="3" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Transportation" Value="4" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Reception" Value="5" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Reuse" Value="6" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Recycling" Value="7" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Recovery" Value="8" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Pre-processing" Value="9" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Co-processing" Value="10" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Utilization" Value="11" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Treatment" Value="12" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Disposal" Value="13" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Incineration" Value="14" style="padding-right: 20px"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h4 class="card-title ml-3">Nature and Quantity</h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-8 col-form-label">Nature and Quantity to waste handled per annum (in Metric Tons) *</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtMetricTons" runat="server" class="form-control" onkeypress="validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-8 col-form-label">Nature and Quantity to waste stored at any time (in Metric Tons) *</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtstoredtons" runat="server" class="form-control" onkeypress="validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-8 col-form-label">Nature and Quantity to waste handled per annum (in Kilo Litre) *</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtwasteannum" runat="server" class="form-control" onkeypress="validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-8 col-form-label">Nature and Quantity to waste stored at any time (in Kilo Litre)  *</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtnature" runat="server" class="form-control" onkeypress="validateNumberAndDot(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-8 col-form-label">Year of commissioning and commence of production *</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtYearpro" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="4"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-5 col-form-label">Whether the industry works:- *</label>
                                                    <div class="col-lg-7 d-flex">
                                                        <asp:CheckBoxList ID="chkindustrywork" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="01 Shift" Value="1" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="02 Shifts" Value="2" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Round the clock" Value="3" style="padding-right: 20px"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
