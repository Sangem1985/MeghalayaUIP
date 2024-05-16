<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFELabourDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFELabourDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Labour Details</h4>
                        </div>
                        <div class="card-body">
                            <!-- <h4 class="card-title">Personal Information</h4> -->
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
                                    <div class="col-md-5">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label fw-bold"><span style="font-weight: 900;">1. Category of Establishment</span></label>
                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="ddlCategory" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">2. Name and address of the contractor(including his father's/ husband's name in case of individuals)</span></label>


                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of the Contractor/Firm *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtspecies" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Father's Name</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtfathername" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label ">Age</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtbirth" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mobile No.*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtmobileno" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Email Id.*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtemailid" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Door No. *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtdoorno" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Locality *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtlocal" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">District *</label>
                                            <div class="col-lg-6">
                                                <asp:DropDownList ID="ddlDistric" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistric_SelectedIndexChanged">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mandal *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlMandals" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandals_SelectedIndexChanged">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Village *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlvillages" runat="server" class="form-control">
                                                    <asp:ListItem Text="Village" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Pincode *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox6" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>



                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">3. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.</span></label>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtname1" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Father's Name *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtfather" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Age *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtage" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Designation *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtdesignation" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mobile *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtmobile" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Email *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEmail1" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Door No.*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtdoor3" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Locality *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtlocality3" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">District *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlPropLocDist" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPropLocDist_SelectedIndexChanged">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Mandal *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlPropLocTaluka" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPropLocTaluka_SelectedIndexChanged">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Village *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlPropLocVillage" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Pin Code *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TXTPIN" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>




                                <div id="divfalse" runat="server" visible="true">
                                    <div runat="server" visible="false">
                                        <div class="col-md-12">
                                            <p class="ml-2 text-info"><b>Note: If you are outside Meghalaya State, enter the address here</b></p>

                                            <div class="form-group">
                                                <label class="col-lg-6 col-form-label">Other State Address</label>
                                                <div class="col-lg-6 d-flex">
                                                    <textarea rows="3" cols="3" class="form-control" placeholder="Enter text here"></textarea>
                                                </div>

                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">7. Full name and Permanent Address of the establishment, if any</span></label>


                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Full Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtFullNAME" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Distric *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlappdistric" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlappdistric_SelectedIndexChanged">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mandal *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlappMandal" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlappMandal_SelectedIndexChanged">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Village *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList runat="server" ID="ddlappVilage" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Door No *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtdoor2" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Pin Code *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtPincode1" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>






                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">9. Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment</span></label>


                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtnames" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Father's Name</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Age *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Designation *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Mobile No.*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Email Id.*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">

                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Door No. *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtDoor1" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Locality *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtLocality1" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">District *</label>
                                                <div class="col-lg-6">
                                                    <asp:DropDownList ID="ddlDistricts" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistricts_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Mandal *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Village *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                        <asp:ListItem Text="--Village--" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Pincode *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtpincode" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                   

                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">11. Duration of the proposed contract work(give particulars of proposed date of commencing and ending)</span></label>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Commence Date *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtComencedate" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">End Date *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtenddate" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">12. Name and address of the agent or manager of the contractor at the work-site</span></label>


                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Name*</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Door No. *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtDoor" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Locality *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtLocality" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">District *</label>
                                                <div class="col-lg-6">
                                                    <asp:DropDownList ID="ddldist" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddldist_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Mandal *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlmand" runat="server" class="form-control" OnSelectedIndexChanged="ddlmand_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Text="--Selectl--" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Village *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlvilla" runat="server" class="form-control">
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Pincode *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox7" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Address *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtaddres" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label fw-bold"><span style="font-weight: 900;">13. Type of business, trade, industry, manufacture or occupation, which is carried on in the establishment</span></label>
                                                <div class="col-lg-4">
                                                    <asp:DropDownList ID="ddlbusiness" runat="server">
                                                        <asp:ListItem Text="--Select--" Value="0" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-12 mt-3 d-flex upload">
                                        <div class="col-md-10">
                                            <div class="form-group row">
                                                <label class="col-form-label col-md-8">P.E. Regitration Certificate *</label>
                                                <div class="col-md-4">
                                                    <asp:TextBox ID="txtPE" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <button type="button" class="btn btn-rounded btn-dark">Upload</button>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label fw-bold"><span style="font-weight: 900;">16. Nature of work in which contract labour is employed or is to be employed in the establishment *</span></label>
                                                <div class="col-lg-4">
                                                    <input name="ctl00$ContentPlaceHolder1$txtNatureofBusinessAct1" type="text" value="Parboiled Rice Mills" maxlength="50" id="ctl00_ContentPlaceHolder1_txtNatureofBusinessAct1" disabled="disabled" title="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label fw-bold"><span style="font-weight: 900;">17. Estimated date of commencement of building or other construction work *</span></label>
                                                <div class="col-lg-4">
                                                    <asp:TextBox ID="txtconstructionwork" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label fw-bold"><span style="font-weight: 900;">18. Maximum number of Contract Employees / building workers to be employed on any day *</span></label>
                                                <div class="col-lg-4">
                                                    <asp:TextBox ID="txtContractEmployees" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label fw-bold"><span style="font-weight: 900;">19. Estimated date of completion of building or other construction work *</span></label>
                                                <div class="col-lg-4">
                                                    <asp:TextBox ID="txtbuilding" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label fw-bold"><span style="font-weight: 900;">20. Maximum Number of migrant workmen proposed to be employed in the establishment on any date *</span></label>
                                                <div class="col-lg-4">
                                                    <asp:TextBox ID="txtMaximum" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-10 col-form-label fw-bold"><span style="font-weight: 900;">21. Whether the contractor was convicted of any offence within the preceding five years. If so give details *</span></label>
                                                <div class="col-lg-2">
                                                    <asp:RadioButtonList ID="rblconvicted" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="1" />
                                                        <asp:ListItem Text="No" Value="2" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-10 col-form-label fw-bold"><span style="font-weight: 900;">22. Whether there was any order against the contractor revoking or suspending license or forefeiting security deposits in respect of an earlier contract . If so the date of such order. *</span></label>
                                                <div class="col-lg-2">
                                                    <asp:RadioButtonList ID="rblrevoking" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="1" />
                                                        <asp:ListItem Text="No" Value="2" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-10 col-form-label fw-bold"><span style="font-weight: 900;">23. Whether the contractor has worked in any other establishment within the past five years, If so, give details of the Principal Emplyer,Establishments and nature of work *</span></label>
                                                <div class="col-lg-2">
                                                    <asp:RadioButtonList ID="rblcontractor" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="1" />
                                                        <asp:ListItem Text="No" Value="2" />
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-12 mt-3 d-flex upload">
                                        <div class="col-md-10">
                                            <div class="form-group row">
                                                <label class="col-form-label col-md-8 fw-bold">24. Whether a certificate by the Principal Employer in Form V is enclosed *</label>
                                                <div class="col-md-4">
                                                    <asp:TextBox ID="txtPrincipal" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <button type="button" class="btn btn-rounded btn-dark">Upload</button>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">25. Security Deposit Details</span></label>


                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Amount paid (Rs) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtpaidamount" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Amount payable (Rs) *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtamount" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Challan No. *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtchallanano" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Challan Date. *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtChallan" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-form-label col-md-4">Attach Challan *</label>
                                                <div class="col-md-8">
                                                    <input class="form-control" type="file">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <button type="button" class="btn btn-rounded btn-dark">Upload</button>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">26. Particulars of Contractors and migrant workmen</span></label>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="table-responsive">
                                            <table class="table table-bordered mb-0">
                                                <thead>
                                                    <tr>
                                                        <th>Sl No.</th>
                                                        <th>Name Of<br />
                                                            The Contractor</th>
                                                        <th>Address</th>
                                                        <th>Mobile No.</th>
                                                        <th>Nature Of<br />
                                                            Work</th>
                                                        <th>Maximum No. Of<br />
                                                            Migrant Workmen</th>
                                                        <th>Estimated Date
                                                            <br />
                                                            Of Commencement</th>
                                                        <th>Estimated Date
                                                            <br />
                                                            Of Completion</th>
                                                        <th>Details Of
                                                            <br />
                                                            Manufacturing Depts</th>
                                                        <th>Actions</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>1</td>
                                                        <td>
                                                            <asp:TextBox ID="txtcontract" runat="server" class="form-control"></asp:TextBox></td>

                                                        <td>
                                                            <textarea cols="2" rows="2" class="form-control"></textarea></td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox8" runat="server" class="form-control"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtaddress" runat="server" class="form-control"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtnature" runat="server" class="form-control"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtDate" runat="server" class="form-control"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtEsitimateStae" runat="server" class="form-control"></asp:TextBox></td>
                                                        <td>
                                                            <textarea cols="2" rows="2" class="form-control"></textarea></td>
                                                        <td>
                                                            <div class="actions">
                                                                <a class="btn btn-sm bg-success-light" data-toggle="modal" href="#edit_specialities_details">
                                                                    <i class="fe fe-pencil"></i>Add
                                                                </a>
                                                                <a data-toggle="modal" href="#delete_modal" class="btn btn-sm bg-danger-light">
                                                                    <i class="fe fe-trash"></i>Delete
                                                                </a>
                                                            </div>
                                                        </td>

                                                    </tr>

                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-md-12 mt-2 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-8 col-form-label fw-bold"><span style="font-weight: 900;">Total No.of Contract Employees *</span></label>
                                                <div class="col-lg-2">
                                                    <asp:TextBox ID="txtEmployees" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                            </div>
                            <div class="col-md-12 text-right">

                                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" BackColor="#009999" Width="150px" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-info btn-lg" padding-right="10px" BackColor="Green" Width="150px" />
                                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" BackColor="#3333ff" Width="150px" />

                            </div>

                        </div>



                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
