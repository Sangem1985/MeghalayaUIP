<%@ Page Title="" Language="C#" MasterPageFile="~/outer.Master" AutoEventWireup="true" CodeBehind="ViewCertifcateDetails.aspx.cs" Inherits="MeghalayaUIP.ViewCertifcateDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">View Certifcate Details</li>
                        </ol>
                    </nav>
                    
                    <h3>View Certifcate Details</h3>
                    <div class="col-md-12" style="margin-bottom:8px;">
                        
                        <div class="col-md-6">
                            <div class="col-md-6">Clearance Name</div>
                            <div class="col-md-6">
                                <select class="form-select" aria-label="Default select example" style="width:100%;height:32px;">
  <option selected>Select Clearance</option>
  <option value="1">Agriculture Department</option>
  <option value="2">Commissioner, Greater Chennai Corporation</option>
  <option value="3">Commissionerate of Industries and Commerce</option>
</select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="col-md-6">Enter Certificate Number</div>
                            <div class="col-md-6">
                                <select class="form-select" aria-label="Default select example" style="width:100%;height:32px;">
  <option selected>Enter Certificate Number Here</option>
  <option value="1">Agriculture Department</option>
  <option value="2">Commissioner, Greater Chennai Corporation</option>
  <option value="3">Commissionerate of Industries and Commerce</option>
</select>
                            </div>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
         </section>
</asp:Content>
