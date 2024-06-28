<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOUploadEnclosures.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOUploadEnclosures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Pre-Operational</a></li>

            <li class="breadcrumb-item active" aria-current="page">Enclosures Details</li>
        </ol>
    </nav>
    <div class="page-wrapper">

        <div class="content container-fluid">

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">Enclosures Details</h3>
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
                                                <asp:Button runat="server" ID="btnUpldAadhar" Text="Upload" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:HyperLink ID="hplAadhar" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
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
                                                <asp:Button runat="server" ID="btnUpldEPIC" Text="Upload" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:HyperLink ID="hplEPIC" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
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
                                                <asp:Button runat="server" ID="btnUpldPhoto" Text="Upload" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:HyperLink ID="hplApplPhoto" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
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
                                                <asp:Button runat="server" ID="btnUplLandDoc" Text="Upload" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:HyperLink ID="hplLandDoc" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
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
                                                <asp:Button runat="server" ID="btnUpldSitePlan" Text="Upload" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:HyperLink ID="hplSitePlan" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
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

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
