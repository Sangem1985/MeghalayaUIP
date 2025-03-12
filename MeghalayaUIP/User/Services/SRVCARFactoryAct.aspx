<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCARFactoryAct.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCARFactoryAct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <nav aria-label="breadcrumb">
    <ol class="breadcrumb mb-0">
         <li class="breadcrumb-item"><a href="Dashboard/MainDashboard.aspx">Other Services</a></li>
        <li class="breadcrumb-item"><a href="#">SRVC Annual Returns</a></li>
        <li class="breadcrumb-item active" aria-current="page">SRVC Factory Act</li>
    </ol>
</nav>

<contenttemplate>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">ANNUAL RETURNS UNDER VARIOUS LABOUR LAWS</h4>
                        </div>
                        <div class="card-body">
                            <div class="col-md-12">
    <h4 class="card-title ml-3 text-center">FORM NO. 21</h4>
                                <h4 class="card-title ml-3 text-center">[Prescribed under Section 110 of the Factories Act. 1948 and Rule 107(1) of the Punjab Factory Rules, 1952]</h4>
</div>
                            

                            <div class="row">
                                        
                                        
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        1(a) Factory Registration No
                                                    <span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" disabled="disabled" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        1(b) Factory Registration Date <span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="FATHER" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                    </div>
                                                </div>
                                            </div>
                                           
                                        </div>
                                        

                                        

                                        

                                        

                                       <%-- <h4 class="card-title ml-3">Other Details: </h4>--%>
                                        

                                        
                                       
                                        
                                        
                                        

                                        
                                    </div>
                        </div>
                        

                        
                    </div>
                </div>
                <div class="col-md-12" id="divgrd" runat="server" visible="false">
                </div>
            </div>

        </div>
    </div>
</contenttemplate>

</asp:Content>
