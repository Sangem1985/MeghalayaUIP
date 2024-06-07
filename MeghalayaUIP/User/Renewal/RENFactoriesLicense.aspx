<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENFactoriesLicense.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENFactoriesLicense" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style>
        .SO {
            width: 100%;
        }

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

            <li class="breadcrumb-item active" aria-current="page">Factories License</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Factories License Details</h4>
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
                                    <h4 class="card-title ml-3">Applicant's Details</h4>
                                </div>
                                <div class="col-md-12 d-flex">

                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Full name of the factory *</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="TextBox1" runat="server" class="form-control" Type="text"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Factory license Number *</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="TextBox16" runat="server" class="form-control" Type="text"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">License Issued Date *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox5" runat="server" class="date form-control" Type="Text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">

                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Latest Renewal No *</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="TextBox12" runat="server" class="form-control" Type="text"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Latest Renewal Date *</label>
                                            <div class="col-lg-6">
                                               <asp:TextBox ID="TextBox14" runat="server" class="date form-control" Type="Text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Lisence Valid Upto Year *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox15" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                
                                
                                


                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Nature of the Manufacturing</h4>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Carried on in the factory during the last 12 months (in the case of all factories already in existence) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txttradeLic" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">To be carried on the factory during the next 12 months (in the case of all factories)  *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox8" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Names of the principal products manufactured during the last 12 months  *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox17" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label"> Values of the principal products manufactured during the last 12 months *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox18" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                                
                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Service Specific Details</h4>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Maximum numbers of workers proposed to be employed on any one day during the year. *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox19" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Maximum number of workers employed on any one day during the last 12 months *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox20" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Number of workers to be ordinarily employed in the factory  *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox21" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Whether the Unit is an Electricity/Power Generating Station? *[Visual Radio buttons]</label>
                                            <div class="col-lg-6 d-flex radio">
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

                                 <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Total installed capacity of Generating Station- KW *</label>
                                            <div class="col-lg-6 d-flex">
                                                Drop Down

                                            </div>
                                        </div>
                                    </div>
                                     </div>
                                 <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Total installed capacity of DG Set/Standby Power- KW *</label>
                                            <div class="col-lg-6 d-flex">
                                                Drop Down

                                            </div>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Maximum amount of power(K.W. installed or proposed to be installed) *</label>
                                            <div class="col-lg-6 d-flex">
                                                 Drop Down

                                            </div>
                                        </div>
                                    </div>
                                     </div>

                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Other Factory Details</h4>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Full name of the person who shall be the manager of the factory for the purpose of the Act *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox22" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Residential address of the person who shall be the manager of the factory for the purpose of the Act *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox23" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Full name of the owner of the premises of the building (including the precincts thereof) refer to section 93 *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox24" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Residential address of the owner of the premises of the building (including the precincts thereof) refer to section 93 *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox25" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    
                                    </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Full name of the occupier *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox26" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Residential address of the occupier *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox27" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    </div>


                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Whether the factory is a private firm proprietor concern?[Visual Radio buttons] *</label>
                                            <div class="col-lg-6 d-flex radio">
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
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Whether the factory is a public firm proprietor concern?[Visual Radio buttons] *</label>
                                            <div class="col-lg-6 d-flex radio">
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


                                
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of proprietor *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox2" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of Directors *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox3" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                     <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Whether factory is Government or Local Fund Factory?[Visual Radio buttons] *</label>
                                            <div class="col-lg-6 d-flex radio">
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
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Whether Managing Agent has been appointed?[Visual Radio buttons] *</label>
                                            <div class="col-lg-6 d-flex radio">
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

                                 <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of Chief Administrative Head *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox4" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of Managing Agents *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox6" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                    
                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Construct of factory after commencement of the Rules</h4>
                                </div>


                                    
                                    
                                    
                                    

                                

                                <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">In the case of factory constructed or extended after the date of the commencement of the Rules *</label>
                                            <div class="col-lg-6 d-flex radio">
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


                               
                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Fees to be payed on calculation</h4>
                                </div>


                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Final Fees *</label>
                                            <div class="col-lg-6 d-flex radio">
                                                73373837.00
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Penalty *</label>
                                            <div class="col-lg-6 d-flex radio">
                                                1000.00
                                            </div>
                                        </div>
                                    </div>


                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">License Valid Upto *</label>
                                            <div class="col-lg-6 d-flex radio">
                                                07-Jun-2024
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Total Amount to be Paid *</label>
                                            <div class="col-lg-6 d-flex radio">
                                                10000000.00
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
