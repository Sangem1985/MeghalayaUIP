<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENShopsEstablishment.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENShopsEstablishment" %>

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

            <li class="breadcrumb-item active" aria-current="page">Shops and Establishment</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Shops and Establishment Details</h4>
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

                                    <h4 class="card-title ml-3 mt-3">Basic Establishment Details</h4>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of Establishment *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txttradeLic" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Constitution of Business *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox8" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Applicant's Name *</label>
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
                                            <label class="col-lg-6 col-form-label">E-Mail Id *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox11" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Photo of the Employer/Proprietor /Partner *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox4" runat="server" class="form-control" file="upload"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Establishments Details</h4>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of the Manager /Agent/other person acting in the general management *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox7" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Address of the Manager/Agent *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox15" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Category of Establishmnet *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox16" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">

                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Nature of Business *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox17" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Do you have your family members employed in the establishment and residing with and wholly dependent upon you? *</label>
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
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Do you have employees working in the establishment? *</label>
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



                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Number of employees *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox5" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Employee List Only .doc .docx format allowed(<a href="#">Download Sample Format</a>) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox21" runat="server" class="form-control" file="upload"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                </div>








                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Postal address and exact location of establishment</h4>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">District *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox38" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Village/Town *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox39" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Locality *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox40" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Pincode *</label>
                                            <div class="col-lg-6 d-flex">

                                                <asp:TextBox ID="TextBox14" runat="server" class="form-control" Type="text"></asp:TextBox>



                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Nearest Landmark *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox42" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Do you have any other office/godown/warehouse attached to this establishment situated in a different premises *</label>
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
                                <div class="SO">
                                    <div class="col-md-12 d-flex">

                                        <h4 class="card-title ml-3 mt-3">Situation of Office, Storeroom or workplace attached to the establishment</h4>
                                    </div>
                                    <div class="col-md-12 d-flex">

                                        <div class="col-md-4 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">District(Sh)  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox28" runat="server" class="form-control" Type="text"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Village/Town *</label>
                                                <div class="col-lg-6 d-flex">

                                                    <asp:TextBox ID="TextBox27" runat="server" class="form-control" Type="text"></asp:TextBox>



                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Locality *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox44" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">

                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Pincode  *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="TextBox45" runat="server" class="form-control" Type="text"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group row">

                                                <div class="col-lg-6 d-flex">
                                                    <asp:Button ID="btnaddmore" Text="Add More" runat="server" CssClass="btn btn-sm btn-rounded btn-green" Width="110" />

                                                </div>
                                            </div>
                                        </div>

                                    </div>


                                    <div class="col-md-12 d-flex">
                                        Grid
                                    </div>

                                </div>

                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Renewal Details</h4>
                                </div>
                                <div class="col-md-12 d-flex">

                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Registration will be renewed from date :</label>
                                            <div class="col-lg-6 d-flex">
                                                Date
                                                    
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Registration will be valid upto date:</label>
                                            <div class="col-lg-6 d-flex">
                                                Date
                                                    
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">No of years renewed :</label>
                                            <div class="col-lg-6 d-flex">
                                                5
                                                    
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Fees :</label>
                                            <div class="col-lg-6 d-flex">
                                                128696
                                                    
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Fees for change notice :</label>
                                            <div class="col-lg-6 d-flex">
                                                5
                                                    
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Fine :</label>
                                            <div class="col-lg-6 d-flex">
                                                128696
                                                    
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                 <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Penalty :</label>
                                            <div class="col-lg-6 d-flex">
                                                5
                                                    
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Total amount to be paid :</label>
                                            <div class="col-lg-6 d-flex">
                                                128696
                                                    
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
