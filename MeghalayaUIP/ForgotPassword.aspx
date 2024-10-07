<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="MeghalayaUIP.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <link href="assets/css/login.css" rel="stylesheet" />
    <section class="about-us-section section-padding">
        <div class="container">
            <div class="row">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <div id="success" runat="server" visible="false" class="alert alert-success m-0" align="Center">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>

                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger m-0" align="Center">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>

                <div class="main-wrapper login-body">
                    <div class="login-wrapper">
                        <div class="container">
                            <div class="loginbox">
                                <div class="login-left">
                                    <h2>Welcome Back!</h2>
                                    <p>To keep connected with</p>
                                    <h5>Invest Meghalaya Authority</h5>
                                    <p>with your personal info</p>
                                </div>
                                <div class="login-right">
                                    <div class="login-right-wrap">
                                        <h1>Forgot Password?</h1>
                                        <p class="account-subtitle">Enter your email to get a password reset link</p>

                                        <!-- Form -->
                                        <form action="admin/IndustryRegistration.aspx">
                                            <div class="form-group">
                                                <%-- <input class="form-control" type="text" placeholder="Email" onkeypress="validateEmailInput(event)" onblur="validateEmail(event)">--%>
                                                <asp:TextBox runat="server" ID="txtEmail" class="form-control" placeholder="Email" AutoCompleteType="Disabled" AutoComplete="Off"></asp:TextBox>
                                            </div>
                                            <div class="col-md-12" style="display: flex;">
                                                <div class="col-md-5" style="padding-left: 10px">
                                                    <div class="form-group" style="margin-left: -25px;">
                                                        <asp:TextBox runat="server" ID="txtcaptcha" class="form-control" placeholder="Captcha"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-7" style="display: flex; align-items: center;">
                                                    <div class="form-group" style="margin-bottom: 20px;">
                                                        <asp:Image ID="imgCaptcha" runat="server" BackColor="#0066ff" ForeColor="#0099ff" draggable="false" Height="35px" Width="100px" />
                                                    </div>
                                                    <div class="form-group" style="margin-left: 10px;">
                                                        <asp:ImageButton ID="btnRefresh" runat="server" AlternateText="Refresh" OnClick="btnRefresh_Click" ImageUrl="~/assets/assetsnew/images/Refresh.jpg" Height="35px" Width="40px" />
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="form-group mb-0">
                                                <asp:Button ID="btnForget" runat="server" Text="Reset Password" class="btn btn-primary btn-block" OnClick="btnForget_Click" />
                                                <%--<button class="btn btn-primary btn-block" type="submit">Reset Password</button>--%>
                                            </div>



                                        </form>

                                        <!-- /Form -->


                                        <div class="login-or">
                                            <span class="or-line"></span>

                                        </div>



                                        <div class="text-center dont-have">Remember your password? <a href="login.aspx">Login</a></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- end container -->
    </section>
</asp:Content>
