<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENSafetySecurityDetails.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENSafetySecurityDetails" %>

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

            <li class="breadcrumb-item active" aria-current="page">Safety and Security</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Safety and Security Details</h4>
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

                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Migrant Worker Registration Number *</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="TextBox1" runat="server" class="form-control" Type="text"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">District in which Registration was Issued *</label>
                                            <div class="col-lg-6">
                                                Drop Down
                                            </div>
                                        </div>
                                    </div>

                                </div>



                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Particulars of the next of kin of the applicant in home state</h4>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of next of kin *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txttradeLic" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-2 col-form-label">Address  *</label>
                                            <div class="col-lg-10 d-flex">
                                                <asp:TextBox ID="TextBox8" runat="server" class="form-control" Type="text"></asp:TextBox>

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
                                            <label class="col-lg-6 col-form-label">Whether the applicant was convicted of any offence under any law in force in India? *</label>
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
                                            <label class="col-lg-6 col-form-label">Whether the applicant has any criminal case pending against him/her? *</label>
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
                                            <label class="col-lg-6 col-form-label">Declaration that the applicant is not of unsound mind? *</label>
                                            <div class="col-lg-6 d-flex radio">
                                                <div class="form-check form-check-inline">
                                                    <input class="form-check-input" type="radio" name="gender" id="gender_male" value="option1" checked="default">
                                                    <label class="form-check-label" for="gender_male">
                                                        Yes
														
                                                    </label>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Nature of Employment/Designation *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox2" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Date of commencement of employment or expected date of commencement  *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox6" runat="server" class="date form-control" Type="Text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Expected duration of stay *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox9" runat="server" class="form-control" Type="Text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Location and Address of the work area where the migrant worker was employed as per Previous License</h4>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Details of the work [ Mention specific skill only] *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox3" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">District of the area of work *</label>
                                            <div class="col-lg-6 d-flex">
                                                Drop Down

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Area of work [ mention communication address of the work area] *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox7" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Existing Registration Valid Up to Date *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox4" runat="server" class="date form-control" Type="Text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>

                                            </div>
                                        </div>
                                    </div>
                                </div>



                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Location and Address of the work area where the migrant worker will be employed for the Renewal</h4>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Details of the work [ Mention specific skill only] *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox10" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">District of the area of work(H) *</label>
                                            <div class="col-lg-6 d-flex">
                                                Drop Down

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Area of work [ mention communication address of the work area] *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox11" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-12 col-form-label">* Applications would be submitted to the Office of Dy. Labour Commissioner/Asst. Labour Commissioner's Office according to the District location choosen above</label>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Registration will be Renewed Upto Date *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox13" runat="server" class="date form-control" Type="Text"></asp:TextBox>
                                                <i class="fi fi-rr-calendar-lines"></i>

                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-12 d-flex">

                                    <h4 class="card-title ml-3 mt-3">Details of the Establishment/Employer</h4>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name of the Establishment/Employer *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox38" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Address of the establishment *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="TextBox39" runat="server" class="form-control" Type="text"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>


                                </div>

                                <div class="col-md-6">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label">Contact number of Establishment/Employeer *</label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="TextBox40" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

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
