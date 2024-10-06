<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="MeghalayaUIP.ForgotPassword" %>
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
                                            <h1>Forgot Password?</h1>
                                            <p class="account-subtitle">Enter your email to get a password reset link</p>
                                            
                                            <!-- Form -->
                                            <form action="admin/IndustryRegistration.aspx">
                                                <div class="form-group">
                                                    <input class="form-control" type="text" placeholder="Email">
                                                </div>
                                                <div class="form-group mb-0">
                                                    <button class="btn btn-primary btn-block" type="submit">Reset Password</button>
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
            </div> <!-- end container -->
        </section>
</asp:Content>
