﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENContractorMigrantWork.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.ContractorMigrantWork" %>
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

            <li class="breadcrumb-item active" aria-current="page">Contractor Migrant Work</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Contractor Migrant Work Deatils</h4>
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
                                                    <asp:TextBox ID="txtRenLicNo" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">License Issued Date *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtRenLicIssued" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">License/ Renewal valid up to Date *</label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtRenValid" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                     
                                    

                                    <div class="col-md-12 d-flex">
                                      
                                        <h4 class="card-title ml-3 mt-3">Contractor's Details</h4>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Title *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtTitlesdt" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNAMES" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">E-Mail ID*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Mobile Number *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Father's Name (in case of individuals)*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtFather" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
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
                                       
                                    <h4 class="card-title ml-3 mt-3">Address of the Contractor</h4>
                                    </div>
                               
                                <div class="col-md-12 d-flex">
                                       <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                State
                                            </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlStatedt" runat="server" class="form-control" AutoPostBack="true">
                                                    <asp:ListItem Text="Select State" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                      <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                District
                                            </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlDistricdt" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistricdt_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select District" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                        <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mandal</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlMandaldt" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandaldt_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select Mandal" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                        </div>

                                <div class="col-md-12 d-flex">
                                      <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">7. Village</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlVillagesdt" runat="server" class="form-control">
                                                    <asp:ListItem Text="Select Village" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Locality </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtLocalition" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nearest Landmark *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNearLandMark" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>                                      
                                        </div>

                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Pincode  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtpinS" runat="server" class="form-control" Type="text"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>                                        
                                       
                                        </div>

                                <div class="col-md-12 d-flex">
                                       
                                    <h4 class="card-title ml-3 mt-3">Contractor's Birth Details</h4>
                                    </div>
                                <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-7 col-form-label">Date of Birth or age (in case of individuals) *</label>
                                                 <div class="col-lg-2 d-flex">
                                                    <div class="col-lg-6 d-flex">
                                                     <asp:RadioButtonList ID="rblDateofBirth" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblDateofBirth_SelectedIndexChanged">
                                                    <asp:ListItem Text="DOB" Value="D" />
                                                    <asp:ListItem Text="Age" Value="A" />
                                                </asp:RadioButtonList>
                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4" id="DateBirth" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Date *</label>
                                                <div class="col-lg-6">
                                                     <asp:TextBox ID="txtDateBirth" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                     <div class="col-md-4" id="Age" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Age  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtAges" runat="server" class="form-control" Type="text"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>   
                                    </div>
                                <p class="fw-bold ml-3">Place of Birth:</p>
                                <div class="col-md-12 d-flex">
                                         <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                State
                                            </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlSates" runat="server" class="form-control" AutoPostBack="true">
                                                    <asp:ListItem Text="Select State" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                      <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                District
                                            </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlDistric" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistric_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select District" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                        <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mandal</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select Mandal" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                        </div>

                                <div class="col-md-12 d-flex">
                                      <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">7. Village</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                    <asp:ListItem Text="Select Village" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Locality </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtLocal" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nearest Landmark *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNearMark" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>                                      
                                        </div>

                                <div class="col-md-12 d-flex">                                       
                                          <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Pincode  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtPin" runat="server" class="form-control" Type="text"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        
                                       
                                        </div>

                                



                                <div class="col-md-12 d-flex">
                                       
                                    <h4 class="card-title ml-3 mt-3">Other Details Of The Contractor</h4>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-7 col-form-label">Whether the applicant is a citizen of India: within the meaning of Article 5 of the Constitution of India. *</label>
                                                 <div class="col-lg-2 d-flex">
                                                    <div class="col-lg-6 d-flex">
                                                     <asp:RadioButtonList ID="rblArtical5" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>

                                <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-7 col-form-label">Whether any Criminal Case is pending at the time of making application *</label>
                                                 <div class="col-lg-2 d-flex">
                                                    <div class="col-lg-6 d-flex">
                                                    <asp:RadioButtonList ID="rblMakeApplicationCrime" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-7 col-form-label">Whether convicted in connection with a Criminal-Case at any time during the period of five years immediately preceding the date of application *</label>
                                                 <div class="col-lg-2 d-flex">
                                                    <div class="col-lg-6 d-flex">
                                                     <asp:RadioButtonList ID="rblCriminalCase" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-7 col-form-label">Whether the applicant holds a trading/business license granted by District Council *</label>
                                                 <div class="col-lg-2 d-flex">
                                                    <div class="col-lg-6 d-flex">
                                                    <asp:RadioButtonList ID="rblDistricCouncil" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblDistricCouncil_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                <div class="col-md-12 d-flex" id="Licdetails" runat="server" visible="false">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">license  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList runat="server" ID="ddlLic" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="GHADC" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="JHADC" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="KHADC" Value="3"></asp:ListItem>                                                      
                                                </asp:DropDownList>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">License No *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtLicNo" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Date of the License *</label>
                                                <div class="col-lg-6 d-flex">
                                                 <%--  <input name="ctl00$ContentPlaceHolder1$TextBox2" id="ContentPlaceHolder1_TextBox2" class="date form-control" type="text">--%>
                                                       <asp:TextBox ID="txtDateLic" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                       
                                        </div>
                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4" id="Validdate" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Valid till date *</label>
                                                <div class="col-lg-6 d-flex">
                                                  <%--  <input name="ctl00$ContentPlaceHolder1$TextBox2" id="ContentPlaceHolder1_TextBox2" class="date form-control" type="text">--%>
                                                     <asp:TextBox ID="txtValidDate" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                      <div class="col-md-12" id="Tribal" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-7 col-form-label">Tribal *</label>
                                                 <div class="col-lg-2 d-flex">
                                                    <div class="col-lg-6 d-flex">
                                                    <asp:RadioButtonList ID="rblTribal" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                      <div class="col-md-4" id="Reasons" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Reasons *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtReasons" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                         
                                
                                <div class="col-md-12 d-flex">
                                       
                                    <h4 class="card-title ml-3 mt-3">Particulars of establishment where migrant workmen-are to be employed</h4>
                                    </div>
                                
                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of the establishment*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNameofEstablish" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                <p class="fw-bold ml-3">Address of the establishment</p>
                                  <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">State *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlstate" runat="server" class="form-control">
                                                    <asp:ListItem Text="Select State" Value="0" />
                                                </asp:DropDownList>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                District
                                            </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddldist" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddldist_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select District" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mandal</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlmand" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlmand_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select Mandal" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                        </div>

                                <div class="col-md-12 d-flex">
                                       <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">7. Village</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlvilla" runat="server" class="form-control">
                                                    <asp:ListItem Text="Select Village" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Locality </label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtLocality" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nearest Landmark *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtLandmark" runat="server" class="form-control" Type="text"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>
                                     
                                        </div>

                                <div class="col-md-12 d-flex">                                        
                                           <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Pincode  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtPincode" runat="server" class="form-control" Type="text"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>                                        
                                       
                                        </div>

                                <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label">Type of business, trade, industry, manufacture or occupation, which is carried on in the establishment *</label>
                                                <div class="col-lg-4 d-flex">
                                                    <asp:TextBox ID="txtbusiness" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                <div class="col-md-12 d-flex">
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Registration Number of the establishment under the Act *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtRegNoEst" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Date of certificate of registration *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtDateRegCert" runat="server" class="date form-control" Type="text"></asp:TextBox>
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                       
                                        </div>

                                <p class="fw-bold ml-3">Principal Employer Details</p>

                                <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Title *</label>
                                                <div class="col-lg-6 d-flex">
                                                  <asp:DropDownList runat="server" ID="ddlTitles" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Shri" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Smt" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Kumari" Value="3"></asp:ListItem>   
                                                          <asp:ListItem Text="Dr" Value="4"></asp:ListItem>   
                                                </asp:DropDownList>    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of the Principal Employer *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNameEmp" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                 <p class="fw-bold ml-3">Particulars of migrant workmen</p>
                                  <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name, Location and Nature of work in which migrant workmen are employed or are to be employed in the establishment *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNameMigrantEmp" runat="server" class="form-control" Type="text"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>
                                       <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Duration of the proposed contract work in day(Min 1 and Max 179) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtContractorMin" runat="server" class="form-control" Type="text"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Commencing Date *</label>
                                                <div class="col-lg-6 d-flex">                                                   
                                                      <asp:TextBox ID="txtCommencingDate" runat="server" class="date form-control" Type="text"></asp:TextBox>          
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                      </div>
                                   <div class="col-md-12 d-flex">
                                        <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Ending Date *</label>
                                                <div class="col-lg-6 d-flex">                                                 
                                                      <asp:TextBox ID="txtEnding" runat="server" class="date form-control" Type="text"></asp:TextBox>          
                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name of the agent or manager of the contractor at the work site *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtSiteManager" runat="server" class="form-control" Type="text"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Maximum number of migrant workmen proposed to be employed in the establishment on any date *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtMaxEstEmp" runat="server" class="form-control" Type="text"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>
                                       </div>
                                 <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Directors/Partners</span></label>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                          <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Title  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList runat="server" ID="ddlTitle" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Shri" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Smt" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Kumari" Value="3"></asp:ListItem>   
                                                          <asp:ListItem Text="Dr" Value="4"></asp:ListItem>   
                                                </asp:DropDownList>                                                    
                                                </div>
                                            </div>
                                        </div>
                                          <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtName" runat="server" class="form-control" Type="text"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>                                                  
                                          <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Address</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtAddress" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>            
                                    </div>
                                  <div class="col-md-12 d-flex">
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <div class="col-lg-12 d-flex">                                                    
                                                    <asp:Button id="btnMigrant" runat="server" Text="Add More" OnClick="btnMigrant_Click" CssClass="btn btn-green btn-rounded" Width="110px"/>
                                                </div>
                                            </div>
                                        </div>    
                                      </div>
                                    <div class="col-md-12 d-flex justify-content-center">
                                    <asp:GridView ID="GVMigrant" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="None"
                                        Width="100%" EnableModelValidation="True" Visible="false">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Title" DataField="RENMW_TITLE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Name" DataField="RENMW_NAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Address" DataField="RENMW_ADDRESS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>

                                
                                <div class="col-md-12 d-flex">                                       
                                    <h4 class="card-title ml-3">Other Details</h4>
                                    </div>
                                 <div class="col-md-12 d-flex">
                                         <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name and address of the Agent through whom the migrant workmen were recruited  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtMigrantWorkmen" runat="server" class="form-control" Type="text"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>
                                     </div>
                                 <div class="col-md-12 d-flex">
                                <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-9 col-form-label">Whether the contractor is convicted of any offence within the proceeding five years *</label>
                                                <div class="col-lg-3 d-flex">
                                                    <div class="col-lg-6 d-flex">
                                                  <asp:RadioButtonList ID="rblContractor" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblContractor_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                                    
                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mt-2" id="Details" runat="server" visible="false">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Details *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtDetail" runat="server" class="form-control" Textmode="MultiLine" ></asp:TextBox>
                                                    
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
                                                     <asp:RadioButtonList ID="rblLicSuspending" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLicSuspending_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                      </div>
                                 <div class="col-md-12 d-flex" id="Order" runat="server" visible="false">
                                       <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Order No *</label>
                                                <div class="col-lg-6 d-flex">                                                     
                                                    <asp:TextBox ID="txtOrderNo" class="form-control" runat="server"></asp:TextBox>                                                  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Order Date *</label>
                                                <div class="col-lg-6 d-flex">
                                                      <asp:TextBox ID="txtOrderDate" runat="server" class="date form-control" Type="text"></asp:TextBox>                                                   
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
                                                    <asp:RadioButtonList ID="rblfiveyears" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblfiveyears_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        
                                     </div>
                                 <div class="col-md-12 d-flex" id="EstablishDetails" runat="server" visible="false">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Establishment's Details *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtEstablishDetails" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Principal's Employers Details *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtEmpDetails" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Nature of work *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtNature" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                    
                                                </div>
                                            </div>
                                        </div>                                       
                                        </div>
                                 <div class="col-md-12 d-flex">
                                       <div class="col-md-8">
                                            <div class="form-group row">
                                                <label class="col-lg-9 col-form-label">Whether a certificate by the principal employer is enclosed*</label>
                                                <div class="col-lg-3 d-flex radio">
                                                    <div class="col-lg-6 d-flex">
                                                    <asp:RadioButtonList ID="rblEmpClosed" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y" />                                                  
                                                </asp:RadioButtonList>
                                                    
                                                </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                     </div>
                                    
                                <div class="col-md-12 text-right mt-2 mb-2">

                                    <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
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