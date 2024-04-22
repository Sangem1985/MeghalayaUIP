<%@ Page Title="" Language="C#" MasterPageFile="~/outer.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MeghalayaUIP.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/login.css" rel="stylesheet" />
     <section class="about-us-section section-padding">
            <div class="container">
                <div class="row">
                    
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
                            <h1>Login</h1>
                            <p class="account-subtitle">Access to our dashboard</p>
                            
                            <!-- Form -->
                            <form action="admin/IndustryRegistration.aspx">
                                <div class="form-group">
                                    <asp:TextBox runat="server" ID="txtUsername"  class="form-control"></asp:TextBox>
                                   <%-- <input class="form-control" type="text" placeholder="Email">--%>
                                </div>
                                <div class="form-group">
                                     <asp:TextBox runat="server" ID="txtPswrd" TextMode="Password"  class="form-control"></asp:TextBox>
                                   <%-- <input class="form-control" type="text" placeholder="Password">--%>
                                </div>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnLogint" OnClick="btnLogint_Click" Text="Login" class="btn btn-primary btn-block" /> 
                                   <%-- <button class="btn btn-primary btn-block" type="submit">Login</button>--%>

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
                            </form>
                            <!-- /Form -->
                            
                            <div class="text-center forgotpass"><a href="forgot-password.aspx">Forgot Password?</a></div>
                            <div class="login-or">
                                <span class="or-line"></span>
                                <span class="span-or">or</span>
                            </div>
                              
                            
                            
                            <div class="text-center dont-have">Don’t have an account? <a href="Registration.aspx">Register</a></div>
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
