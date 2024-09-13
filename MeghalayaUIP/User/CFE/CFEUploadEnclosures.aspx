<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEUploadEnclosures.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEUploadEnclosures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Pre Establishment</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Enclosures Deatils</li>
                </ol>
            </nav>
            <div class="page-wrapper">

                <div class="content container-fluid">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">Pre Establishment: Enclosures Details</h3>
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
                                    <asp:HiddenField ID="hdnQuesid" runat="server" />
                                    <div class="row">

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-9">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">1. Aadhar Card </label>
                                                    <div class="col-lg-1 d-flex">: </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupAadhar" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUpldAadhar" Text="Upload" OnClick="btnUpldAadhar_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplAadhar" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-9">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">2. EPIC Document </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupEPIC" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUpldEPIC" Text="Upload" OnClick="btnUpldEPIC_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplEPIC" runat="server" Target="_blank" ></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-9">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">3. Applicant Photograpgh </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupApplPhoto" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUpldPhoto" Text="Upload" OnClick="btnUpldPhoto_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplApplPhoto" runat="server" Target="_blank" ></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-9">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">4. Land Document /Sale Deed </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupLandDoc" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUplLandDoc" Text="Upload" OnClick="btnUplLandDoc_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplLandDoc" runat="server" Target="_blank" ></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-9">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">5. Site plan </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupSitePlan" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUpldSitePlan" Text="Upload" OnClick="btnUpldSitePlan_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplSitePlan" runat="server" Target="_blank" ></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <br />
                                        </div>
                                        <div class="col-md-12 text-right mb-3">

                                            <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                        </div>
                                        <%-- <div class="col-md-12 d-flex mt-2">
                                    <div class="col-md-6">
                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos1" class="btn  btn-info btn-lg" />
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-info btn-lg" padding-right="10px" BackColor="Green" />
                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn  btn-info btn-lg" />

                                    </div>
                                </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpldAadhar" />
            <asp:PostBackTrigger ControlID="btnUpldEPIC" />
            <asp:PostBackTrigger ControlID="btnUpldPhoto" />
            <asp:PostBackTrigger ControlID="btnUplLandDoc" />
            <asp:PostBackTrigger ControlID="btnUpldSitePlan" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
