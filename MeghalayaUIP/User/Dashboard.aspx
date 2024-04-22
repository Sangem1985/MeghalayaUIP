<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MeghalayaUIP.User.Dashboard" %>

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
                                <a href="IndustryRegistration_tabs.html">
                                    <div class="card-counter info">
                                        <i class="fa fa-users"></i>
                                        <span class="count-numbers">Principle approval</span>
                                        <span class="count-name">(Lorem Ipsum is simply dummy text)</span>
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-3">
                                <div class="card-counter primary" data-toggle="modal" data-target=".bd-example-modal-xl">
                                    <img src="../assets/admin/img/prl.png" alt="logo">
                                    <span class="count-numbers">CFE</span>
                                    <span class="count-name">(Pre-Establishment Approval)</span>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="card-counter danger" data-toggle="modal" data-target=".bd-example-modal-lg" data-original-title="">

                                    <img src="../assets/admin/img/poa.png" alt="logo">
                                    <span class="count-numbers">CFO</span>
                                    <span class="count-name">(Pre-Operational Approval)</span>
                                </div>
                            </div>


                            <div class="col-md-3">
                                <div class="card-counter success">

                                    <img src="../assets/admin/img/inc.png" alt="logo">
                                    <span class="count-numbers">Incentive</span>
                                    <span class="count-name">Data</span>
                                </div>
                            </div>


                        </div>
                    </div>
                </section>

            </div>





        </div>
    </div>
</asp:Content>
