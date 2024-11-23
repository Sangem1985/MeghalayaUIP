<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="INCInterestSubsidy.aspx.cs" Inherits="MeghalayaUIP.User.INCENTIVE.INCInterestSubsidy" %>

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
                                    <h4 class="card-title">Interest Subsidy </h4>
                                </div>
                                <div class="card-body">

                                    <div class="row">
                                        <h5 class="card-title ml-4 mt-3">4.Interest Subsidy </h5>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.1 Name and address of the Financial Institution/Bank which extended Term Loan to the unit *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.2	Amount of Term Loan Sanction with No. and date of sanction letter. *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtSanctionDate" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.3	Amount & date of  </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtAmounts" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(i)	First disbursement	 *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtFirstdisbursement" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(ii)	Total disbursement as on ............ *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtTotalOn" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.4 Rate of interest charged  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRateCharge" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.5 Amount of subsidy claimed </label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txttotalInvest" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <h5 class="card-title ml-4 mt-3">Upload Document</h5>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(i)	Enclose copy(s) of sanction by Bank & FI</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupsanctionFI" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnsanctionFI" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypsanctionFI" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblsanctionFI" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(ii)	Enclose Certificate cum Recommendation issued by Bank/FI as per Format in Annexure-D</label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupBank" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnBank" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypBank" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblBank" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(iii) Copy of list of employees verified by Enquiry Officer and endorsed/countersigned by General Manager.</label>
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
            <asp:PostBackTrigger ControlID="btnsanctionFI" />
            <asp:PostBackTrigger ControlID="btnBank" />
            <asp:PostBackTrigger ControlID="btnemployees" />
            <asp:PostBackTrigger ControlID="btnEmployeEPF" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
