<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="Sectoralinformation.aspx.cs" Inherits="MeghalayaUIP.Sectoralinformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table#servicestable th {
            vertical-align: middle;
        }

        select#ContentPlaceHolder1_ddlPolCategory {
            display: block;
            width: 100%;
            padding: 0.475rem 0.75rem;
            font-size: 1rem;
            line-height: 1.7;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <section class="innerpages">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                                    <li class="breadcrumb-item">Resources / ODOP</li>
                                    <li class="breadcrumb-item active" aria-current="page">Sectoral Information</li>
                                </ol>
                            </nav>
                            <section class="innerpages">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <%-- <nav aria-label="breadcrumb">
                     <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                         <li class="breadcrumb-item">Services</li>
                         <li class="breadcrumb-item active" aria-current="page">Information Wizard</li>
                     </ol>
                 </nav>--%>

                                            <h3>Sectoral Information</h3>
                                            <div class="card">
                                                <div class="card-body justify-content-center " align="justify">
                                                    <div class="row">
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Approval Name :</label>
                                                                    <select class="form-control" aria-label="Default select example">
                                                                        <option selected>select Approval</option>
                                                                        <option value="1">Consent For Establishment from Pollution Control Board</option>
                                                                        <option value="2">Service Connection Certificate </option>
                                                                        <option value="3">NOC DG Set</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">State/Center Level Approval : </label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <select class="form-control" aria-label="Default select example">
                                                                            <option selected>select State/Center Level Approval</option>
                                                                            <option value="1">State</option>
                                                                            <option value="2">Center</option>

                                                                        </select>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Department :</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <select class="form-control" aria-label="Default select example">
                                                                            <option selected>select Department</option>
                                                                            <option value="1">MSPCB</option>
                                                                            <option value="2">Power</option>
                                                                            <option value="3">Urban Affairs</option>
                                                                        </select>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">

                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Sector:</label>
                                                                   
                                                                        <select class="form-control" aria-label="Default select example">
                                                                            <option selected>select Sector</option>
                                                                            <option value="1">Applicable for All Sector Product</option>
                                                                            <option value="2">Priority Sector-Hotels & Hospitality</option>
                                                                            <option value="3">Priority Sector-Food Processing</option>
                                                                        </select>
                                                                  
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Stage: </label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <select class="form-control" aria-label="Default select example">
                                                                            <option selected>select Stage</option>
                                                                            <option value="1">Pre-Establishment</option>
                                                                            <option value="2">Pre-Operational</option>

                                                                        </select>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 mt-4 ml-4">
                                                                <div class="form-group">
                                                                    <input type="submit" name="ctl00$ContentPlaceHolder1$btnSearch" text="Search" id="ContentPlaceHolder1_btnSearch" class="btn btn-rounded btn-success btn-lg" style="width: 150px;">
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <%--<div class="col-md-12 d-flex">
                                                         <div class="col-md-4">
                                                             <div class="form-group">
                                                                 <label class="col-lg-12 col-form-label">Risk Category:</label>
                                                                 <div class="col-lg-12 d-flex">
                                                                     
                                                                 </div>
                                                             </div>
                                                         </div>
                                                         <div class="col-md-4">
                                                             <div class="form-group">
                                                                 <label class="col-lg-12 col-form-label">Investor Type:</label>
                                                                 <div class="col-lg-12 d-flex">
                                                                     
                                                                 </div>
                                                             </div>
                                                         </div>
                                                         <div class="col-md-4">
                                                             <div class="form-group">
                                                                 <label class="col-lg-12 col-form-label">No of Employee:</label>
                                                                 <div class="col-lg-12 d-flex">
                                                                     
                                                                 </div>
                                                             </div>
                                                         </div>
                                                     </div>--%>


                                                        <div class="col-md-12 d-flex">
                                                            <p>Table Grid</p>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                            <%--<asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                             <ProgressTemplate>
                                 <div class="update">
                                 </div>
                             </ProgressTemplate>
                         </asp:UpdateProgress>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
