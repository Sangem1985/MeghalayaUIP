<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="Bestpractices.aspx.cs" Inherits="MeghalayaUIP.Bestpractices" %>

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
                                    <li class="breadcrumb-item">Services</li>
                                    <li class="breadcrumb-item active" aria-current="page">Best Practices</li>
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

                                            <h3>Best Practices</h3>
                                            <div class="card">
                                                <div class="card-body justify-content-center " align="justify">
                                                    <div class="row">
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Department Name :</label>
                                                                    <select class="form-control" aria-label="Default select example">
                                                                        <option selected>select Department</option>
                                                                        <option value="1">Co-Operation</option>
                                                                        <option value="2">Department of Urban Affairs</option>
                                                                        <option value="3">Department of Forest</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Sub-Department Name : </label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <select class="form-control" aria-label="Default select example">
    <option selected>select Sub-Department</option>
    <option value="1">CIBF</option>
    <option value="2">Labour</option>
    <option value="3">Planning </option>
</select>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Sector :</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <select class="form-control" aria-label="Default select example">
    <option selected>select Sector</option>
    <option value="1">Priority Sector-Hotels & Hospitality</option>
    <option value="2">Priority Sector-Tourism (Homestays, Adventure, Health Tourism, Eco-Tourism & MICE)</option>
    <option value="3">Priority Sector-Bio-Technology</option>
</select>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <%--<div class="col-md-12 d-flex">

                                                         <div class="col-md-4">
                                                             <div class="form-group">
                                                                 <label class="col-lg-12 col-form-label">Location:</label>
                                                                 <div class="col-lg-12 d-flex">
                                                                     
                                                                 </div>
                                                             </div>
                                                         </div>
                                                         <div class="col-md-4">
                                                             <div class="form-group">
                                                                 <label class="col-lg-12 col-form-label">Nature of Activity: </label>
                                                                 <div class="col-lg-12 d-flex">
                                                                     
                                                                 </div>
                                                             </div>
                                                         </div>
                                                         <div class="col-md-4">
                                                             <div class="form-group">
                                                                 <label class="col-lg-12 col-form-label">Size of Firm:</label>
                                                                 <div class="col-lg-12 d-flex">
                                                                     
                                                                 </div>
                                                             </div>
                                                         </div>
                                                     </div>--%>

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

                                                        <div class="col-md-12 float-left ">
                                                            <div class="form-group row justify-content-center" style="padding: 20px">
                                                                <%--<asp:Button ID="btnSearch1111" runat="server" OnClick="" Text="Search" ValidationGroup="Search" class="btn btn-rounded btn-success btn-lg" Width="150px" />--%>
                                                            
                                                                <input type="submit" name="ctl00$ContentPlaceHolder1$btnSearch" text="Search" id="ContentPlaceHolder1_btnSearch" class="btn btn-rounded btn-success btn-lg" style="width:150px;">
                                                            </div>
                                                        </div>
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
