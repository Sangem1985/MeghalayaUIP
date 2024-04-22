<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="DeptDashboard.aspx.cs" Inherits="MeghalayaUIP.Dept.DeptDashboard" %>
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
                            <div class="card-counter primarydashboard5">
                            <asp:LinkButton ID="linkPreReg" runat="server" OnClick="linkPreReg_Click">
									<i class="fi fi-rr-square-up-right"></i>
									<span class="count-numbers">Principle approval </span>
									<span class="count-name">(Industry Registration Approval)  </span>
                            </asp:LinkButton>
                                </div>
                        </div>
                        <div class="col-md-3">
                            <div class="card-counter primarydashboard1">
                                <asp:LinkButton runat="server" ID="linkCFE" OnClick="linkCFE_Click">
									<i class="fi fi-rr-square-up-right"></i>
									<span class="count-numbers">CFE</span>
									<span class="count-name">(Pre-Establishment Approval)</span>
                                </asp:LinkButton>
                            </div>

                        </div>
                        <div class="col-md-3">

                            <div class="card-counter primarydashboard2">
                                <asp:LinkButton runat="server" ID="linkCFO" OnClick="linkCFO_Click">
                                    <i class="fi fi-rr-square-up-right"></i>
                                    <span class="count-numbers">CFO</span>
                                    <span class="count-name">(Pre-Operational Approval)</span>
                                </asp:LinkButton>
                            </div>

                        </div>
                        <div class="col-md-3">


                            <div class="card-counter primarydashboard3">
                                <asp:LinkButton runat="server" ID="linkIncentive" OnClick="linkIncentive_Click">
                                    <i class="fi fi-rr-square-up-right"></i>
                                    <span class="count-numbers">Incentive</span>
                                    <span class="count-name">(Lorem Ipsum is simply dummy text) </span>
                                </asp:LinkButton>
                            </div>

                        </div>


                    </div>
                </div>
            </section>
                
            </div>
            
        </div>
    </div>
</asp:Content>
