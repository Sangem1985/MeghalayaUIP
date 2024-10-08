<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="MeghalayaUIP.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="assets/admin/js/form-validation.js" type="text/javascript"></script>
    <style>
        .main-wrapper.login-body {
            width: 100%;
        }

        section.about-us-section.section-padding {
            padding: 0px 0px 0px !important;
        }

        .login-wrapper_reg {
            max-width: 950px !important;
        }

        h1 {
            font-weight: 600;
            font-family: "Poppins", sans-serif !important;
            font-size: 26px !important;
        }
    </style>
    <script src="assets/admin/js/crypto.js"></script>
     <script type="text/javascript">
         function encryptData() {
             var passwordField = document.getElementById('<%= txtPswd.ClientID %>');
             var key = CryptoJS.enc.Utf8.parse("1234567890123456");  // Use a secure key
             var iv = CryptoJS.enc.Utf8.parse("1234567890123456");  // Initialization vector (IV)
             // Encrypt the password using AES
             var encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(passwordField.value), key, {
                 keySize: 128 / 8,
                 iv: iv,
                 mode: CryptoJS.mode.CBC,
                 padding: CryptoJS.pad.Pkcs7
             });
             passwordField.value = encrypted.toString();
             // Replace the password with encrypted value
         }
     </script>
    <script type="text/javascript">
        function hashPassword() {
            var passwordField = document.getElementById('<%= txtPswd.ClientID %>');
            var hashedPassword = CryptoJS.SHA256(passwordField.value);
            passwordField.value = hashedPassword;// Replace plain password with hashed one
         <%--var passwordField2 = document.getElementById('<%= Cfpasswordbox.ClientID %>');            
            var hashedPassword2 = CryptoJS.SHA256(passwordField2.value);          
            passwordField2.value = hashedPassword2;--%>
        }
    </script>
    <link href="assets/assetsnew/css/login.css" rel="stylesheet" />

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <section class="about-us-section section-padding">
                <div class="">
                    <div class="">
                        <div class="main-wrapper login-body">
                            <div class="login-wrapper_reg">
                                <div class="container">
                                    <div class="col-md-12 mb-4">
                                        <h1>Register</h1>
                                        <p style="color: #164976;">Access to our dashboard</p>
                                    </div>
                                    <div class="row" align="Center">
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
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12" style="display: flex;">
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    PAN No.
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" class="form-control" ID="txtPAN" MaxLength="10" onkeypress="validateCharandNumberinput();" onblur="fnValidatePAN(this);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    Company Name as per PAN
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" class="form-control" ID="txtcompanyname" onkeypress="return Names(this)"></asp:TextBox>
                                                </div>
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
                                                    <asp:TextBox runat="server" class="form-control" ID="txtName" onkeypress="return Names(this)"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    Mobile No
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" ID="txtMobileNo" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10" onblur="validateIndianMobileNumber(this);"></asp:TextBox>
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
                                                    <asp:TextBox runat="server" class="form-control" ID="txtEmail" TextMode="Email" AutoCompleteType="None" AutoComplete="Off" onkeypress="return validateEmailInput(event)" Onblur="validateEmail(this);"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    Password
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" class="form-control" ID="txtPswd" TextMode="Password" MinLength="8" MaxLength="12" 
                                                        AutoComplete="off" AutoCompleteType="None" ToolTip="Password must have minimum 8 length, atleast one upper case letter, one lower case letter, one numer and one special character"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" >
                                        <div class="col-md-12" style="display: flex;">
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <label>Enter Captcha</label>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <asp:TextBox runat="server" ID="txtCaptcha" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <%--<div class="col-md-2">
                                                <div class="form-group">
                                                    <label>Captcha <span class="text-Danger">*</span></label>
                                                </div>
                                            </div>--%>
                                            <div class="col-md-4" style="display: flex; align-items: center;margin-left: -20px;">
                                                <div class="form-group" style="margin-bottom: 20px;">
                                                    <asp:Image ID="imgCaptcha" runat="server" draggable="false" />
                                                </div>
                                                <div class="form-group" style="margin-left: 10px;">
                                                    <asp:ImageButton ID="btnRefresh" runat="server" AlternateText="Refresh" OnClick="btnRefresh_Click" ImageUrl="~/assets/assetsnew/images/Refresh.jpg" Height="40px" Width="40px" />
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
                                                    <asp:Button runat="server" CssClass=" btn btn-primary" Text="Submit" ID="btnSubmit" OnClientClick="encryptData()" OnClick="btnSubmit_Click"></asp:Button>

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
