<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MeghalayaUIP.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .main-wrapper.login-body {
            width: 100%;
        }

        section.about-us-section.section-padding {
            padding: 0px 0px 0px !important;
        }

        .login-body {
            min-height: 70vh;
            padding: 10px 0px;
        }

        .login-wrapper h1 {
            font-family: "Poppins", sans-serif !important;
            font-weight: 600 !important;
            font-size: 26px !important;
        }

        h1 {
            font-weight: 500 !important;
        }

        .login-wrapper .loginbox .login-left {
            padding: 60px !important;
        }
    </style>

    <link href="assets/assetsnew/css/login.css" rel="stylesheet" />
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $('input[type="password"]').on('copy paste cut', function (e) {
                e.preventDefault();
            });
        });
    </script>--%>
    <link href="assets/assetsnew/css/login.css" rel="stylesheet" />
    <script src="assets/admin/js/jquery-T.T.O.min.js"></script>
    <script src="assets/admin/js/MD5.js"></script>
    <script type="text/javascript">
        document.cookie.split(';').forEach(cookie => {
            const eqPos = cookie.indexOf('=');
            const name = eqPos > -1 ? cookie.substring(0, eqPos) : cookie;
            document.cookie = name + '=;expires=Thu, 01 Jan 1970 00:00:00 GMT';
        });

        function Generate() {
            var pass;
            var passObj = $("#<%= txtPswrd.ClientID%>").val();
            if (passObj != "") {
                var x = (Math.random() * 1973);
                $("input[id*='asp_hidden']").val(x);
                asp_hiddenVal = $("input[id*='asp_hidden']").val();
                pass = MD5(passObj + asp_hiddenVal);
                $("#<%= txtPswrd.ClientID%>").val(pass);
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <section class="about-us-section section-padding">
                <div class="">
                    <div class="">
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
                                                <h1>User Login</h1>
                                                <p class="account-subtitle">Access to our dashboard</p>

                                                <!-- Form -->
                                                <%-- <form action="admin/IndustryRegistration.aspx">--%>
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" ID="txtUsername" class="form-control" placeholder="Email" AutoCompleteType="Disabled" AutoComplete="Off"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" ID="txtPswrd" TextMode="Password" onblur="return Generate();"  class="form-control" placeholder="Password" AutoCompleteType="Disabled" AutoComplete="Off"></asp:TextBox>
                                                </div>
                                                <div class="row" style="padding-left: 10px">
                                                    <div class="col-md-12" style="display: flex;">
                                                        <div class="col-md-5">
                                                            <div class="form-group" style="margin-left: -25px;">
                                                                <asp:TextBox runat="server" ID="txtcaptcha" class="form-control" placeholder="Captcha"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6" style="display: flex; align-items: center; margin-left: -20px;">
                                                            <div class="form-group" style="margin-bottom: 20px;">
                                                                <asp:Image ID="imgCaptcha" runat="server" draggable="false" Height="38px" Width="400px" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-1" style="display: flex; align-items: center; margin-left: -20px;">
                                                            <div class="form-group" style="margin-left: 10px;">
                                                                <asp:ImageButton ID="btnRefresh" runat="server" AlternateText="Refresh" OnClick="btnRefresh_Click" ImageUrl="~/assets/assetsnew/images/Refresh.jpg" Height="35px" Width="40px" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <asp:Button runat="server" ID="btnLogint" OnClick="btnLogint_Click"  Text="Login" class="btn btn-primary btn-block" />
                                                </div>
                                                <%--</form> OnClientClick="return Generate();"--%>
                                                <!-- /Form -->

                                                <div class="text-center forgotpass"><a href="ForgotPassword.aspx">Forgot Password?</a></div>
                                                <div class="login-or">
                                                    <span class="or-line"></span>
                                                    <span class="span-or">or</span>
                                                </div>
                                                <asp:HiddenField runat="server" ID="asp_hidden" />

                                                <div class="text-center dont-have">Don’t have an account? <a href="Registration.aspx">SignUp</a></div>
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
