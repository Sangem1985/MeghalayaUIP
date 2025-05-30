<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="LAEnclosures.aspx.cs" Inherits="MeghalayaUIP.User.LA.LAEnclosures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Land Allotment</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Enclosures Deatils</li>
                </ol>
            </nav>
            <div class="page-wrapper">

                <div class="content container-fluid">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">Land Allotment: Enclosures Details</h3>
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
                                                    <label class="col-lg-4 col-form-label">1. PAN card and Photo ID of authorized signatory </label>
                                                    <div class="col-lg-1 d-flex">: </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupPANSign" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUpldPANSign" Text="Upload" OnClick="btnUpldPANSign_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplPANSign" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-9">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">2. Board’s resolution authorizing authorized signatory to sign application on behalf of the company  </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                   
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupAuthority" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnAuthority" Text="Upload" OnClick="btnAuthority_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplAuthority" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-9">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">3. PAN Card and Photo of all partners/promoters </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                   
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupPANPhoto" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUpldPANPhoto" Text="Upload" OnClick="btnUpldPANPhoto_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplPANPhoto" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-9">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">4. Techno Economic Feasibility Report  </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                   
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupTecho" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUplTecho" Text="Upload" OnClick="btnUplTecho_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplTecho" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-9">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">
                                                        5. Plant layout indicating therein area for installation of 
                                                machinery/space for raw material & finished goods/generator shed/utility service etc.
                                                    </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                   
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupPlantlayout" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnPlantlayout" Text="Upload" OnClick="btnPlantlayout_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hpllayout" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-9">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">6.Last 3 (three) years Balance Sheet (in case of existing unit)  </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                   
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupYear" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnYear" Text="Upload" OnClick="btnYear_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplYear" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-9">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">7. Any other document that may be required by the State Government/lessor </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                   
                                                    </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupstateGov" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnStateGov" Text="Upload" OnClick="btnStateGov_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplStateGov" runat="server" Target="_blank"></asp:HyperLink>
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>
          <%--  <asp:PostBackTrigger ControlID="btnUpldAadhar" />--%>
            <asp:PostBackTrigger ControlID="btnUpldPANSign" />
            <asp:PostBackTrigger ControlID="btnAuthority" />
            <asp:PostBackTrigger ControlID="btnUpldPANPhoto" />
            <asp:PostBackTrigger ControlID="btnUplTecho" />
            <asp:PostBackTrigger ControlID="btnPlantlayout" />
            <asp:PostBackTrigger ControlID="btnYear" />
            <asp:PostBackTrigger ControlID="btnStateGov" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
