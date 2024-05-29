<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="MeghalayaUIP.User.UserDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">

        <div class="content container-fluid">



            <div class="card">
                <div class="card-header">
                    <h4 class="card-title">Welcome to Dashboard</h4>
                </div>

                <section id="dashboardcount">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:LinkButton ID="linkPreReg" runat="server" OnClick="linkPreReg_Click">
                                   
                                    <div class="card-counter info">
                                         <i class="fa fa-users"></i>
                                        <span class="count-numbers">Registration under <br /> MIIPP 2024</span>
                                        <span class="count-name">(Principle approval)</span>
                                    </div><%--<a href="CFE/CFEDashboard.aspx">CFE/CFEDashboard.aspx</a>--%>
                                </asp:LinkButton>
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="linkCFE" runat="server" OnClick="linkCFE_Click" >
                                <div class="card-counter primary" data-toggle="modal" data-target=".bd-example-modal-xl">
                                    <img src="../assets/admin/img/prl.png" alt="logo">
                                    <span class="count-numbers">Pre-Establishment<br /> Approval</span>
                                    <span class="count-name"></span>
                                </div>
                                </asp:LinkButton>
                            </div>

                            <div class="col-md-3">
                                <div class="card-counter danger" data-toggle="modal" data-target=".bd-example-modal-lg" data-original-title="">

                                    <img src="../assets/admin/img/poa.png" alt="logo">
                                    <span class="count-numbers">Pre-Operational<br /> Approval</span>
                                    <span class="count-name"></span>
                                </div>
                            </div>


                            <div class="col-md-3">
                                <div class="card-counter success">

                                    <img src="../assets/admin/img/inc.png" alt="logo">
                                    <span class="count-numbers">Incentive</span>
                                    <span class="count-name"></span>
                                </div>
                            </div>


                        </div>
                    </div>
                </section>

            </div>





        </div>
    </div>
</asp:Content>
