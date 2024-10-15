<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="Deptlogin.aspx.cs" Inherits="MeghalayaUIP.Deptlogin" %>

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
    </style>
    <link href="assets/assetsnew/css/login.css" rel="stylesheet" />
    <script src="assets/admin/js/jquery-T.T.O.min.js"></script>
    <script src="assets/admin/js/MD5.js"></script>
    <script type="text/javascript">
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
        <contenttemplate>
            <section class="about-us-section section-padding">
                <div class="">
                    <div class="">
                        <div class="main-wrapper login-body">
                            <div class="login-wrapper">
                                <div class="container">
                                    <div class="loginbox">
                                        <div class="login-left">
                                            <h2>Welcome Back!</h2>
                                            <p>To keep connected with</p>
                                            <h5>Invest Meghalaya</h5>
                                            <p>with your personal info</p>
                                        </div>
                                        <div class="login-right">
                                            <div class="login-right-wrap">
                                                <h1>Department Login</h1>
                                                <p class="account-subtitle">Access to our dashboard</p>
                                                <%--<form action="admin/IndustryRegistration.aspx">--%>
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" ID="txtUsername" class="form-control" placeholder="User Name" AutoCompleteType="Disabled" AutoComplete="Off"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" ID="txtPswrd" TextMode="Password" class="form-control" placeholder="Password" AutoCompleteType="Disabled" AutoComplete="Off"></asp:TextBox>
                                                </div>
                                                <div class="col-md-12" style="display: flex;">
                                                    <div class="col-md-5" style="padding-left: 10px">
                                                        <div class="form-group" style="margin-left: -25px;">
                                                            <asp:TextBox runat="server" ID="txtcaptcha" class="form-control" placeholder="Captcha"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-7" style="display: flex; align-items: center;">
                                                        <div class="form-group" style="margin-bottom: 20px;">
                                                            <asp:Image ID="imgCaptcha" runat="server" BackColor="#0066ff" ForeColor="#0099ff" draggable="false" Height="35px" Width="250px" />
                                                        </div>
                                                        <div class="form-group" style="margin-left: 10px;">
                                                            <asp:ImageButton ID="btnRefresh" runat="server" AlternateText="Refresh" OnClick="btnRefresh_Click" ImageUrl="~/assets/assetsnew/images/Refresh.jpg" Height="35px" Width="40px" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Button runat="server" ID="btnLogint" OnClick="btnLogint_Click" OnClientClick="return Generate();" Text="Login" class="btn btn-primary btn-block" />
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
                                                </div>
                                                <asp:HiddenField ID="hdnUserID" runat="server" />
                                                <asp:HiddenField runat="server" ID="asp_hidden" />
                                                <%--</form>--%>


                                                <div class="text-center forgotpass"><a href="ForgotPassword.aspx">Forgot Password?</a></div>
                                                <div class="login-or">
                                                    <span class="or-line"></span>
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

            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <progresstemplate>
                    <div class="update">
                    </div>
                </progresstemplate>
            </asp:UpdateProgress>
        </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
