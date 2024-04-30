<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MeghalayaUIP.Dept.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card">
                <section id="dashboardcount">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-3">
                                <a href="No_Dashboard.html">
                                    <div class="card-counter primarydashboard5">
                                        <i class="fi fi-rr-square-up-right"></i>
                                        <span class="count-numbers">Registration under MIIPP 2024
(Principle approval)</span>
                                        <span class="count-name">(Lorem Ipsum is simply dummy text) </span>
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-3">
                                <a href="IndustryRegistration_tabs.html">
                                    <div class="card-counter primarydashboard1">
                                        <i class="fi fi-rr-square-up-right"></i>
                                        <span class="count-numbers">CFE</span>
                                        <span class="count-name">(Pre-Establishment Approval)</span>
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-3">
                                <a href="IndustryRegistration_tabs.html">
                                    <div class="card-counter primarydashboard2">
                                        <i class="fi fi-rr-square-up-right"></i>
                                        <span class="count-numbers">CFO</span>
                                        <span class="count-name">(Pre-Operational Approval)</span>
                                    </div>
                                </a>
                            </div>
                            <div class="col-md-3">
                                <a href="IndustryRegistration_tabs.html">
                                    <div class="card-counter primarydashboard3">
                                        <i class="fi fi-rr-square-up-right"></i>
                                        <span class="count-numbers">Incentive</span>
                                        <span class="count-name">(Lorem Ipsum is simply dummy text) </span>
                                    </div>
                                </a>
                            </div>


                        </div>
                    </div>
                </section>
            </div>







        </div>
    </div>
</asp:Content>
