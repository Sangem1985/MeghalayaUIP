<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCARMinWagesAct.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCARMinWagesAct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="Dashboard/MainDashboard.aspx">Other Services</a></li>
            <li class="breadcrumb-item"><a href="#">SRVC Annual Returns</a></li>
            <li class="breadcrumb-item active" aria-current="page">SRVC Minimum Wages Act</li>
        </ol>
    </nav>

    <contenttemplate>
        <div class="page-wrapper">
            <div class="content container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">ANNUAL RETURNS UNDER VARIOUS LABOUR LAWS</h4>
                            </div>
                            <div class="card-body">
                                <div class="col-md-12">
                                    <h4 class="card-title ml-3 text-center">FORM NO. III</h4>
                                    <h4 class="card-title ml-3 text-center">[Prescribed under section 18(1) of the Minimum Wages Act, 1948 and Rule 21(4A) of the Punjab Minimum Wages Rules, 1950) (Information may be given only for those categories of workers in respect of whom minimum wages have been fixed under the Minimum Wages Act, 1948]</h4>
                                </div>


                                <div class="row">

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    1. No of days worked during the year
                                                     <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnofdayswrkddurngyear" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    2. No of mandays worked during the year (total attendance) <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnofmandayswrkddurngyear" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-12 col-form-label">
                                                    3. Average No. of persons employed daily during the year -
                                                </label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    (i). Adults
                                                            <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnofadults" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    (ii). Children <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnofchldrn" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    4. Total wages paid 
                        <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtttlwgspaid" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    5. Cash value of wages paid in kind <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtcashwagespaid" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    6. Deductions made on account of
                        <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtdedctnsmadeaccof" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    7. Balance of fine fund at the beginning of the year<span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtblncfinebgnngyear" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    8. Disbursement from the fine fund
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtdisbursmntfrmfine" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    9. Balance of fine fund at the end of the year<span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtblncfinendngyear" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 text-right mt-2 mb-2">
                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                    </div>



                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </contenttemplate>
</asp:Content>
