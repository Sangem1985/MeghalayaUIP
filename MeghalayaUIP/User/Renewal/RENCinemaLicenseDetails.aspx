<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENCinemaLicenseDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENCinemaLicenseDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <style>
      
        i.fi.fi-br-circle-camera {
    font-size: 32px;
    margin-right: -21px;
    padding-left: 6px;
}
    </style>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Renewal</a></li>

            <li class="breadcrumb-item active" aria-current="page">Cinema License Details</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Cinema License Details</h4>
                        </div>
                        <div class="card-body">
                            <div class="col-md-12 d-flex">
                                <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 d-flex">
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                                    <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                            <div class="row">
                             
                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Existing License Details</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Old Registration Number  *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Registration Date *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox2" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>
                                     
                                    

                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Service Specific Details</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of the Establishment Cinema *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txttradeLic" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">NOC issued no. with Issue Date *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox8" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Number of seats *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox9" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Details of the cinematography equipment's  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox10" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        
                                        
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                               <label class="col-lg-6 col-form-label">Type of Business *</label>
                                                <div class="col-lg-6 d-block">
                                                    <div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_male" value="option1" checked="">
															<label class="form-check-label" for="gender_male">
															Firm/Company
															</label>
														</div>
														<div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_female" value="option2">
															<label class="form-check-label" for="gender_female">
															Individual
															</label>
														</div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of the Proprietor/ Managing Partner/ Kartha/ Managing Director *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox11" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">GSTIN number of the Business/ Establishment  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox12" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                               <label class="col-lg-6 col-form-label">Ownership of Premises *</label>
                                                <div class="col-lg-6 d-block">
                                                    <div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_male" value="option1" checked="">
															<label class="form-check-label" for="gender_male">
															Owned
															</label>
														</div>
														<div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_female" value="option2">
															<label class="form-check-label" for="gender_female">
															Rented
															</label>
														</div>
                                                    <div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_female" value="option2">
															<label class="form-check-label" for="gender_female">
															Leased
															</label>
														</div>
                                                    <div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_female" value="option2">
															<label class="form-check-label" for="gender_female">
															Rent Free
															</label>
														</div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Photograph of the Proprietor/ Managing Partner/ Kartha/ Managing Director *</label>
                                                <div class="col-lg-6">
                                                    
  <input class="form-control" type="file" id="formFile"><i class="fi fi-br-circle-camera"></i>
                                                </div>
                                            </div>
                                        </div>
                                        </div>

                                <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Location of The Cinema Establishment</span></label>
                                    </div>

                                
                                    <div class="col-md-12 d-flex">

                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">District *</label>
                                                <div class="col-lg-6 d-flex">
														<asp:TextBox ID="TextBox5" runat="server" class="form-control" Type="text"></asp:TextBox>
													</div>
                                            </div>
                                        </div>
                                    
                                         
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">City/Town/Village *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox4" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Locality *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox6" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                 <div class="col-md-12 d-flex">
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Landmark *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox13" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Pincode *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox14" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         
                                    </div>

                                
                                    
                                    
                                   
                                
                                
                                
                                <div class="col-md-12 text-right mt-2 mb-2">

                                    <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded  btn-info btn-lg" Width="150px" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
