<%@ Page Title="" Language="C#" MasterPageFile="~/outer.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="MeghalayaUIP.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="assets/css/login.css" rel="stylesheet" />
    <section class="about-us-section section-padding">
            <div class="container">
                <div class="row">                    
                    <div class="main-wrapper login-body">
        <div class="login-wrapper_reg">
            <div class="container">
                <div class="col-md-12 mb-4">
                    <h1>Register</h1>
                    <p style="color: #164976;">Access to our dashboard</p>
                </div>
                <div class="row" align="Center">
                    <div class="col-md-12 d-flex">
                        <div id="success" runat="server" visible="false" class="alert alert-success" align="center">
                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-12 d-flex">
                        <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="center">
                            <strong>Warning!</strong>
                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">

                    <div class="col-md-12" style="display: flex;">
                        <div class="col-md-2">
                            <div class="form-group">
                                Full Name
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:TextBox runat="server" class="form-control" ID="txtName" Onkeypress="Names()"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-2">
                            <div class="form-group">
                                PAN No.
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:TextBox runat="server" class="form-control" ID="txtPAN" onblur="fnValidatePAN(this)"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12" style="display: flex;">
                        <div class="col-md-2">
                            <div class="form-group">
                                Email Id
                            </div>

                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:TextBox runat="server" class="form-control" ID="txtEmail" TextMode="Email" onblur="echeck(yhis)"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                Password
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:TextBox runat="server" class="form-control" ID="txtPswd" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12" style="display: flex;">
                        <div class="col-md-2">
                            <div class="form-group">
                                Mobile No
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtMobileNo" class="form-control" onKeypress="NumberOnly()" MaxLength="10"></asp:TextBox>
                            </div>
                        </div> 
                    </div>
                </div>
                <div class="row" visible="false" runat="server">
                    <div class="col-md-12" style="display: flex;">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Captcha <span class="text-Danger">*</span></label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <%--<img id="imgCaptcha" src="UI/TSiPASS/CaptchaHandler.ashx?query=Q4fey6" style="border-width:0px;">--%>
                                <asp:TextBox runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Enter Captha</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtCaptcha" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12" style="display: flex;">
                        <div class="col-md-5">
                        </div>
                        <div class="col-md-2">
                            <div class="form-grup">
                                <asp:Button runat="server" CssClass=" btn btn-primary" Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click"></asp:Button>

                            </div>
                        </div>


                        <div class="col-md-3">
                            <div>
                                <asp:Button runat="server" Text="Clear" ID="btnClear" CssClass="btn btn-warning" OnClick="btnClear_Click"></asp:Button>                                
                            </div>
                        </div>
                        <div class="col-md-3">
                        </div>

                    </div>

                </div> 
            </div>
        </div>
    </div>
                </div>
            </div> <!-- end container -->
        </section>
</asp:Content>
