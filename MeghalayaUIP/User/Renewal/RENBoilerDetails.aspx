<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENBoilerDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENBoilerDetails" %>
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

            <li class="breadcrumb-item active" aria-current="page">Boiler Details</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Boiler Details</h4>
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
                                      
                                        <h4 class="card-title ml-3 mt-3">Boiler Location Details</h4>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Work or Plant where Boiler situated *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txttradeLic" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Factory/Establishment Name *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox8" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Address of Factory/Establishment*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox9" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nearest Railway Station *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox10" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">District (B) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox11" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>

                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Village/Town *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox4" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>

                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Locality(B) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox5" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Police Station (B) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox6" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>

                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Pin code (B) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox12" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>


                                <div class="col-md-12 d-flex">
                                       
                                    <h4 class="card-title ml-3 mt-3">Boiler Technical Details</h4>
                                    </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of the Manufacturer *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox7" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Year of Manufacture *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox15" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Place of Manufacture *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox16" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                
                                <div class="col-md-12 d-flex">
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Boiler Maker's Number *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox17" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Intended Working Pressure*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox18" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Fuel use *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox19" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>

                                <div class="col-md-12 d-flex">
                                        
                                       
                                        </div>

                                <div class="col-md-12 d-flex">
                                     <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Super Heater Rating(kg/cm²/lbs) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox20" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Economiser Rating *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox21" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Maximum Continuous Evaporation(Tonnes/Hour) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox23" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                         
                                        
                                       
                                        </div>

                                
                                
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Re-Heater Rating *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="TextBox25" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Working Season *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox34" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Working Pressure (In Kg/cm-sq or PSI) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox35" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                              


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of the owner *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox36" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Type of Boiler *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox24" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Description of Boiler *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox26" runat="server" class="form-control" Textmode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                       
                                        </div>
                                
                                
                                
                                
                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Boiler Rating *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox32" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">In case of Boiler ownership being transfer  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox13" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Remarks (Transfers etc.)*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox37" runat="server" class="form-control" Textmode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                       
                                        </div>

                                 <div class="col-md-12 d-flex">
                                       
                                    <h4 class="card-title ml-3 mt-3">Existing Lisence Details</h4>
                                    </div>

                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Registry No *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox38" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Type of Boiler(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox39" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Boiler Rating(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox40" runat="server" class="form-control" Textmode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                       
                                        </div>
                               
                                 <div class="col-md-12 d-flex">
                                <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Work of Plant where Boiler situated(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    
                                                    <asp:TextBox ID="TextBox14" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                               
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Place of manufacture(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox42" runat="server" class="form-control" Textmode="MultiLine" ></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                     <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Year of manufacture(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    
                                                    <asp:TextBox ID="TextBox22" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                
                                                    
                                                </div>
                                            </div>
                                        </div>
                                     </div>
                                 <div class="col-md-12 d-flex">
                                
                                        <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of the owner(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox28" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                     <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Max. Cont. Evaporation (Tonnes/Hour)(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    
                                                    <asp:TextBox ID="TextBox27" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Maximum pressure(Lbs)(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox44" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                     </div>

                                 <div class="col-md-12 d-flex">
                                
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Repairs(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox45" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                     <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Hydraulically Tested ON(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox41" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                     <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Upto(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox29" runat="server" class="Date form-control" Type="Text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                     </div>
                                 <div class="col-md-12 d-flex">
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">The Loading of the(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox30" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                     <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Safety valve is not to exceed(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox31" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                     <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Period from Date(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox33" runat="server" class="Date form-control" Type="Text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                       
                                        </div>
                                
                                   <div class="col-md-12 d-flex">
                                <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label"> To Date(H) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox43" runat="server" class="Date form-control" Type="Text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-2 col-form-label">Remark *</label>
                                                <div class="col-lg-10 d-flex">
                                                    <asp:TextBox ID="TextBox46" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                </div>
                                
                                <div class="col-md-12 d-flex">
                                       
                                    <h4 class="card-title ml-3 mt-3">Fees Details</h4>
                                    </div>
                                

                             <div class="col-md-12 d-flex">
                                <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Registration Fees to be Paid (Rs):  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox47" runat="server" class="form-control" Type="Text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Total Amount to be paid (in Rs): *</label>
                                                <div class="col-lg-6 d-flex">
                                                   <asp:TextBox ID="TextBox48" runat="server" class="form-control" Type="Text"></asp:TextBox>
                                                    
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
