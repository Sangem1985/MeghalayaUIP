<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENContractLabourDeatils.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENContractLabourDeatils" %>
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

            <li class="breadcrumb-item active" aria-current="page">Contract Labour Deatils</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Contract Labour Deatils</h4>
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
                                        <%--<label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Existing License Details</span></label>--%>
                                    <h4 class="card-title ml-3">Existing License Details</h4>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">License No for which renewal is required *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">License Issued Date *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox2" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">License/ Renewal valid up to Date *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox3" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                     
                                    

                                    <div class="col-md-12 d-flex">
                                      
                                        <h4 class="card-title ml-3">Contractor's Details</h4>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Title *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txttradeLic" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox8" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox9" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Mobile Number *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox10" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Father's Name (in case of individuals)*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox11" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>

                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Upload Contractor's Photo(Min 20Kb and Max 250Kb) *</label>
                                                <div class="col-lg-6">
                                                    
  <input class="form-control" type="file" id="formFile"><i class="fi fi-br-circle-camera"></i>
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                <div class="col-md-12 d-flex">
                                       
                                    <h4 class="card-title ml-3">Particulars of establishment where contract
                                            labour is to be employed (Principal Employer)</h4>
                                    </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Establishment Name *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox7" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                <p class="ml-3 fw-bold">Address of the Establishment:</p>
                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">District *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox15" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Village/Town *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox16" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Locality *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox17" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>

                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nearest Landmark</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox18" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Post Office *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox19" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Police Station/Outpost *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox20" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>

                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Pincode *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox21" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Registration number *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox23" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Registration Date *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox25" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                        
                                       
                                        </div>

                                <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label">Type of Business, Trade, Industry, Manufacture or
                                                    occupation, which is carried out in the establishment  *</label>
                                                <div class="col-lg-4 d-flex">
                                                    <asp:TextBox ID="TextBox22" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                <p class="ml-3 fw-bold">Name and Address of Principal Employer:</p>
                                
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Title *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox34" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Principal Employer's Name*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox35" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                <div class="col-md-12 d-flex">
                                       
                                    <h4 class="card-title ml-3">Manager or person details responsible for the supervision and control of the establishment</h4>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Title *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox36" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Full Name *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox24" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Address *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox26" runat="server" class="form-control" Textmode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                       
                                        </div>
                                <div class="col-md-12 d-flex justify-content-end mt-2 mb-2 pr-4">
                                    <asp:Button CssClass="btn btn-sm btn-green btn-rounded" Width="110px" Text="Add More" runat="server" ID="btnaddmore" />

                                </div>
                                
                                <div class="col-md-12 d-flex">
                                       
                                    <h4 class="card-title ml-3">Particulars of Contract Labour</h4>
                                    </div>
                                <p class="fw-bold ml-3">Name & Address of Agent or Manager of Contractor at the worksite:</p>
                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox32" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Address *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox33" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name, Nature and location of work in which contract labour is employed / is to be employed in the establishment *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox37" runat="server" class="form-control" Textmode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                       
                                        </div>
                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">No of days of contract labour *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox38" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Number of contract labour approved in the existing License *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox39" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Maximum number of contract labour proposed to be employed now *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox40" runat="server" class="form-control" Textmode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                       
                                        </div>
                                <div class="col-md-12 d-flex">
                                       
                                    <h4 class="card-title ml-3">Other Details</h4>
                                    </div>
                                 <div class="col-md-12 d-flex">
                                <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-9 col-form-label">Whether the contractor is convicted of any offence within the proceeding five years *</label>
                                                <div class="col-lg-3 d-flex">
                                                    <div class="col-lg-6 d-flex">
                                                    <div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_male" value="option1" checked="">
															<label class="form-check-label" for="gender_male">
															Yes
															</label>
														</div>
														<div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_female" value="option2">
															<label class="form-check-label" for="gender_female">
															No
															</label>
														</div>
                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Details *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox42" runat="server" class="form-control" Textmode="MultiLine" ></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                     </div>
                                 <div class="col-md-12 d-flex">
                                <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-9 col-form-label">Whether there was any order against the contractor revoking or suspending license or forfeiting Security Deposit in respect of an earlier contract *</label>
                                                <div class="col-lg-3 d-flex radio">
                                                    <div class="col-lg-6 d-flex">
                                                    <div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_male" value="option1" checked="">
															<label class="form-check-label" for="gender_male">
															Yes
															</label>
														</div>
														<div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_female" value="option2">
															<label class="form-check-label" for="gender_female">
															No
															</label>
														</div>
                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Order Date *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox41" runat="server" class="Date form-control" Type="Text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                     </div>

                                 <div class="col-md-12 d-flex">
                                <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-9 col-form-label">Whether the contractor has work in any other establishment within the past five years*</label>
                                                <div class="col-lg-3 d-flex radio">
                                                    <div class="col-lg-6 d-flex">
                                                    <div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_male" value="option1" checked="">
															<label class="form-check-label" for="gender_male">
															Yes
															</label>
														</div>
														<div class="form-check form-check-inline">
															<input class="form-check-input" type="radio" name="gender" id="gender_female" value="option2">
															<label class="form-check-label" for="gender_female">
															No
															</label>
														</div>
                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        
                                     </div>
                                 <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Establishment's Details *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox44" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Principal's Employers Details *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox45" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nature of work *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox46" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
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
