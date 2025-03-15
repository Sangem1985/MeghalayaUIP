<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCARMBAct.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCARMBAct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="Dashboard/MainDashboard.aspx">Other Services</a></li>
            <li class="breadcrumb-item"><a href="#">SRVC Annual Returns</a></li>
            <li class="breadcrumb-item active" aria-current="page">SRVC Maternity Benefit Act</li>
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
                                    <h4 class="card-title ml-3 text-center">FORM L.M.N.O</h4>
                                    <h4 class="card-title ml-3 text-center">[Prescribed under section 28(2)(K) of the Maternity Benifit Act. 1961 and rule Punjab Maternity Benint Rules, 1967]</h4>
                                </div>


                                <div class="row">


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    1. No. of women who claimed maternity benifit for actual birth
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnofwmenclmdbnfts" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>


                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-12 col-form-label">
                                                    2. No. of claims accepted and paid either fully and partially 
                                                </label>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    (a)Total <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txttlnofclaimspaid" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    (b)From the current year <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtfrmcrntyr" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    3. Total Medical amount maternity benifit paid (including medical bonus)
                                                            <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtmdclamntbnftpaid" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    4. Amount of medical bonus paid <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtamntofmdclbnonuspaid" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    3. Total Medical amount maternity benifit paid (including medical bonus)
                                                                 <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox1" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    4. Amount of medical bonus paid <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox2" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <h4 class="card-title ml-3 text-center">SUGGESTION SCHEME</h4>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    5. A(a) Is the Suggestion Scheme in operation in the  factory?
                                                        <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:RadioButtonList ID="rblMedical" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Y" />
                                                        <asp:ListItem Text="No" Value="N" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-12 col-form-label">
                                                    (b)If so, the number of suggestion -
                                                </label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    (i).Received during the year
                                                        <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtrcvddurngyear" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    (ii).Accepted in the year <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtacptdintheyear" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-12 col-form-label">
                                                    B. Amount awarded in cash prizes during the year -
                                                </label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    (i).Total amount awarded Rs
                                                     <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtttlamntwrded" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    (ii).Value of maximum cash prize, awarded Rs<span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtmxmcshprzawrded" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    (iii).Value of minimum cash prize, awarded Rs
                                                <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtminmumcshprzawrded" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 text-right mb-3">
                                        <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                        <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                    </div>


                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-12" id="divgrd" runat="server" visible="false">
                    </div>
                </div>

            </div>
        </div>
    </contenttemplate>
</asp:Content>
