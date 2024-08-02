<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="IntentInvest.aspx.cs" Inherits="MeghalayaUIP.IntentInvest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <link rel="stylesheet" href="assets/admin/css/style.css">
    <style>
        
        table#ContentPlaceHolder1_rblproposal label, table#ContentPlaceHolder1_rblInvestments label {
    font-weight: 100;
}
        table#ContentPlaceHolder1_rblproposal tr td, table#ContentPlaceHolder1_rblInvestments tr td {
    padding: 0px 10px;
}
        label.col-lg-6.col-form-label {
    font-weight: 400;
}
        section.innerpages {
    margin-top: 50px;
    margin-bottom: 10px;
}
        .card-body {
    background: #fff;
}
      .widget.link-widget ul {
    width: 100% !important;
}
      section.innerpages {
    margin-top: 20px;
    margin-bottom: 10px;
}
    </style>
    <section class="innerpages IntentInvest">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                 
                    <div class="">
                        <div class="content container-fluid">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <h4 class="card-title">Intent to Invest</h4>
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
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Company Details</span></label>

                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Name of Company  *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="Names()"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">PAN*</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtPan" runat="server" class="form-control" onblur="fnValidatePAN(this);"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Registered Office Address</span></label>

                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Address Line - 1   *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtAddress" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Country*</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:DropDownList ID="ddlcountry" runat="server" class="form-control">
                                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Phone No*</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtPhone" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Pin/Zip Code    </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtPinCode" runat="server" class="form-control" onkeypress="return validatePincode(event)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Email ID</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtEmailIds" runat="server" class="form-control" onblur="validateEmail(event)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Fax No</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtFax" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Website    </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtwebsite" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Contact Details</span></label>

                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Name    </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtNames" runat="server" class="form-control" onkeypress="Names()"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Designation</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtDesignation" runat="server" class="form-control" onkeypress="Names()"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Email ID *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" onblur="validateEmail(event)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Mobile No *  </label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtMobilesNo" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Project Details</span></label>

                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-5 col-form-label">Project Proposal *</label>
                                                            <div class="col-lg-7 d-flex">
                                                                <asp:RadioButtonList ID="rblproposal" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="New" Text="New"></asp:ListItem>
                                                                    <asp:ListItem Value="Expansion" Text="Expansion"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Have you signed the MoU/Investment Intention in previous events *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:RadioButtonList ID="rblInvestments" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
                                                                    <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                      
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Project Category  * <img src="assets/assetsbeta/images/helpImage4.png" title="Micro - Investment in Plant and Machinery or Equipment does not exceed Rs 1 crore and annual turnover does not exceed Rs 5 crore. 
Small - Investment in Plant and Machinery or Equipment does not exceed Rs 10 crore and annual turnover does not exceed Rs 50 crore. 
Medium - Investment in Plant and Machinery or Equipment does not exceed Rs 50 crore and annual turnover does not exceed Rs 250 crore.
Large - Investment in Plant and Machinery or Equipment exceeds Rs 50 crores." style="width: 11%;height: 11%;"></label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:DropDownList ID="ddlPCB" runat="server" class="form-control">
                                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Sectors*</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:DropDownList ID="ddlsector" runat="server" class="form-control">
                                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                                Proposed Investment
                                                <br />
                                                                (Rs. in Crore) *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtproposedInvest" runat="server" class="form-control" onkeypress="return validateAmount(event)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Proposed Employment *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtEmployments" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Proposed Project Location</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtProjectlocation" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Expected Year of Commencement of Production *</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:TextBox ID="txtExpectedYear" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div class="col-md-12 d-flex">
                                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Expectation/Support required from the State Govt</span></label>

                                                </div>--%>
                                                <div class="col-md-12 d-flex">
                                                    <div class="col-md-8">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Expectation/Support required from the State Govt</label>
                                                            <div class="col-lg-4 d-flex">
                                                                <asp:TextBox ID="txtExpectation" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>


                                                <div class="col-md-12 d-flex mt-4" style="margin-top: 17px !important;margin-bottom: 7px;">
                                                    
                                                    <div class="col-md-12 text-center">
                                                        <asp:Button ID="BtnSave" runat="server" Text="Submit" class="btn btn-info btn-submit" padding-right="10px" Width="120px" OnClick="BtnSave_Click"  />
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
            </div>
        </div>
    </section>
</asp:Content>
