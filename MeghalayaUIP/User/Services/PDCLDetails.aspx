<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="PDCLDetails.aspx.cs" Inherits="MeghalayaUIP.User.Services.PDCLDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a>Services</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Power Distribution Corporation Limited</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" runat="server" id="divText">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Power Distribution Corporation Limited:</h4>
                                </div>
                                <div class="card-body">
                                    <div class="col-md-12 ">
                                        <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span></button>
                                        </div>
                                    </div>
                                    <div class="col-md-12 ">
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show" align="Center">
                                            <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hdnUserID" runat="server" />
                                    <div class="row">
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        a) Status in Relation to the premises</label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:RadioButtonList ID="rblstatus" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Owner" Value="Y" />
                                                            <asp:ListItem Text="Occupier" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-8 col-form-label">
                                                        b)Location and Address of the premises including Police Sation:</label>
                                                    <div class="col-lg-4">
                                                        <asp:TextBox ID="txtPolicest" runat="server" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-8 col-form-label">c)Nature of LT Supply:*</label>
                                                    <div class="col-lg-12 d-flex">
                                                        <asp:CheckBoxList ID="chkNature" runat="server" RepeatDirection="Vertical" RepeatColumns="9" Style="padding: 40px">
                                                            <asp:ListItem Text="Commercial" Value="1" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Industrial" Value="2" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="WSLT" Value="3" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Agriculture" Value="4" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Domestic" Value="5" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="General purpose" Value="6" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="Public lighting" Value="7" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="KJ" Value="8" style="padding-right: 20px"></asp:ListItem>
                                                            <asp:ListItem Text="MeECL Employee" Value="9" style="padding-right: 20px"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">6. Attachments: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-3 col-form-label"></label>
                                                    <div class="col-lg-2 d-flex">
                                                    </div>
                                                    <div class="col-lg-4 d-flex">
                                                        <label class="col-lg-5 col-form-label">Reference No </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">1.Test Report from the electrical licensed contractor  *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtReport" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupReport" runat="server" />

                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnDisposal" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnDisposal_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypReport" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblReport" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">2.Agreement from duly filled in *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtduly" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupduly" runat="server" />

                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnduly" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnduly_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypduly" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblduly" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">3.Proof of ownership (in case the applicant is owner)  *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtownership" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupownership" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnownership" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnownership_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypownership" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblownership" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">4.Number of the nearest electic pole *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtpole" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fuppole" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnpole" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnpole_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hyppole" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblpole" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">5.No objection certificate of the owner of the premises (in case the applicant is occupier) *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtowner" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupowner" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnowner" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnowner_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypowner" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblowner" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">6.Attested copy of permission obtained from Pollution Control Board-If applicable *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtPCB" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupPCB" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnPCB" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnPCB_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypPCB" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblPCB" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">7.Building permission from the concerned authority-If applicable *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtBuilding" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupBuilding" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnBuilding" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnBuilding_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypBuilding" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblBuilding" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">8.Occupancy Certificate from MUDA for areas within shillong Municipal limits- if applicable *</label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtOccupancy" runat="server" class="form-control" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupOccupancy" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnOccupancy" class="btn btn-rounded btn-dark mb-4" Width="150px" OnClick="btnOccupancy_Click" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypOccupancy" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <asp:Label ID="lblOccupancy" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 text-right mt-2 mb-2">
                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" OnClick="btnsave_Click" />
                                            <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>            
            <asp:PostBackTrigger ControlID="btnDisposal" />
            <asp:PostBackTrigger ControlID="btnduly" />
            <asp:PostBackTrigger ControlID="btnownership" />
            <asp:PostBackTrigger ControlID="btnpole" />
            <asp:PostBackTrigger ControlID="btnowner" />
            <asp:PostBackTrigger ControlID="btnPCB" />
              <asp:PostBackTrigger ControlID="btnBuilding" />
            <asp:PostBackTrigger ControlID="btnOccupancy" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
