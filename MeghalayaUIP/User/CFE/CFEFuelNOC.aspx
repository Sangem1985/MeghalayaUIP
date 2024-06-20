<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEFuelNOC.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEFuelNOC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">PETROLEUM Details</h4>
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
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Applicant Detail's</span></label>
                                </div>                              
                                  <div class="col-md-12 d-flex">                                
                                       <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Whether No Objection Certificate (NOC) is required for setting up of Petrol Pump? *</label>
                                            <div class="col-lg-4">
                                                <asp:RadioButtonList ID="rblNOC" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div> 
                                        <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">No Objection Certificate (NOC) required for (mention the purpose clearly) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtNOCreq" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                      </div>
                                  <div class="col-md-12 d-flex">
                                  
                                      </div>
                                 
                                 <h4 class="card-title ml-3 mt-3">Details of the location  </h4>
                                  <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">1.Location Address</span></label>
                                </div>                               
                                  <div class="col-md-12 d-flex">                            
                                        
                                        <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">
                                                               Distric</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
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

                                                    <div class="col-md-4">
                                                        <div class="form-group row">
                                                            <label class="col-lg-6 col-form-label">Village</label>
                                                            <div class="col-lg-6 d-flex">
                                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                                    <asp:ListItem Text="Select Village" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>   
                                        </div>
                                   <div class="col-md-12 d-flex">
                                         <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Located in which Road? *</label>
                                            <div class="col-lg-6">
                                                <asp:RadioButtonList ID="rblLocated" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="National Highway" Value="1" />
                                                    <asp:ListItem Text="State Highway" Value="2" />
                                                    <asp:ListItem Text="Any Other Road" Value="3"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div> 
                                         <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1.Name of Establishment   *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtNameEst" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                       </div>
                                  <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. Land Holding Certificate No *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLandHoldingNo" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                        <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">3.Whether land is under Lease? *</label>
                                            <div class="col-lg-4">
                                                <asp:RadioButtonList ID="rblLand" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLand_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />                                                   
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>                                       
                                      </div>
                                   <div class="col-md-12 d-flex">
                                         <div class="col-md-4" id="RegNo" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4 (i) If Yes, Please enter Lease Deed Registration No *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtRegNo" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                         <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">5 Area of Land as per Land Holding Certificate No *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtHoldingNo" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                       </div>
                                 <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">6.Description of Land with Boundaries</span></label>
                                </div>
                                
                                  <div class="col-md-12 d-flex">
                                         <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">(i) North *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtNorth" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                       <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">(ii) East *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEast" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                       <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">(iii) South *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtsouth" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                       </div>
                                  <div class="col-md-12 d-flex">
                                      <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">(iv) West *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtwest" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                      </div>
                                 <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">7.Area for construction of Retail Outlet measuring (in meters)*</span></label>
                                </div>                                
                                    <div class="col-md-12 d-flex">
                                      <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">(i) Frontage*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtFrontage" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                           <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">(ii) Depth *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtDepth" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>


                                      </div>
                                  <div class="col-md-12 text-right mt-2 mb-2">

                                    <asp:Button Text="Previous" runat="server" ID="btnPrevious" OnClick="btnPrevious_Click" class="btn btn-rounded  btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" Text="Next" runat="server" OnClick="btnNext_Click" class="btn btn-rounded  btn-info btn-lg" Width="150px" />

                                </div>


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>
</asp:Content>
