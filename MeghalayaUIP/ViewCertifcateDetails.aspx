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
                   
                        
                        <div class="col-md-6">
                            <div class="col-md-6 text-right">Type of Application</div>
                            <div class="col-md-6">
                                <select class="form-control" aria-label="Default select example" style="width:100%;height:32px;">
  <option selected>Select Application</option>
  <option value="1">Agriculture Department</option>
  <option value="2">Commissioner, Greater Chennai Corporation</option>
  <option value="3">Commissionerate of Industries and Commerce</option>
</select>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="col-md-6 text-right">Enter UID Number</div>
                            <div class="col-md-6">
                                <input type="text" class="form-control" Name="input" />
                            </div>
                        </div>
                        <div class="col-md-6" style="margin-top:20px;">
                            <div class="col-md-6 text-right">Enter Name of Unit</div>
                            <div class="col-md-6">
                                <input type="text" class="form-control" Name="input" />
                            </div>
                        </div>
                        <div class="col-md-4 text-center" style="margin-top:20px;">
                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-info btn-submit" />
                        </div>
                    </div>
                    
                    
            </div>
         </section>
</asp:Content>
