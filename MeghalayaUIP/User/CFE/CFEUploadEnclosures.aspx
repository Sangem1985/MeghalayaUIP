<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEUploadEnclosures.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEUploadEnclosures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">

        <div class="content container-fluid">

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Pre Establishment: Enclosures Details</h4>
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
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">1. Aadhar Card </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                               <asp:FileUpload runat="server" ID="fupAadhar" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px"  />
                                               <br />
                                                <asp:HyperLink ID="lblFileName" Text="Aadhar" runat="server"  Target="_blank"></asp:HyperLink>
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                             <asp:Button runat="server" ID="btnUpldAadhar" Text="Upload Aadhar" class="btn btn-info btn-lg" Height="40px"   Width="150px" />
                                            </div>
                                        </div>
                                    </div> 
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">2. EPIC Document </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                               <asp:FileUpload runat="server" ID="FileUpload1" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px"  />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                             <asp:Button runat="server" ID="Button1" Text="Upload EPIC" class="btn btn-info btn-lg" Height="40px"   Width="150px" />
                                            </div>
                                        </div>
                                    </div> 
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">3. Applicant Photograpgh </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                               <asp:FileUpload runat="server" ID="FileUpload2" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px"  />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                             <asp:Button runat="server" ID="Button2" Text="Upload Photo" class="btn btn-info btn-lg" Height="40px"   Width="150px" />
                                            </div>
                                        </div>
                                    </div> 
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">4. Land Document /Sale Deed </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                               <asp:FileUpload runat="server" ID="FileUpload3" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px"  />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                             <asp:Button runat="server" ID="Button3" Text="Upload" class="btn btn-info btn-lg" Height="40px"  Width="150px" />
                                            </div>
                                        </div>
                                    </div> 
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">5.Site plan </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                               <asp:FileUpload runat="server" ID="FileUpload4" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px"  />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                             <asp:Button runat="server" ID="Button4" Text="Upload " class="btn btn-info btn-lg" Height="40px"   Width="150px" />
                                            </div>
                                        </div>
                                    </div> 
                                </div>
                                  <div class="col-md-12 d-flex">
                                    <br />
                                  </div>
                             
                                <div class="col-md-12 text-right">

                                    <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" BackColor="#009999" Width="150px" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-info btn-lg" padding-right="10px" BackColor="Green" Width="150px" />
                                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" BackColor="#3333ff" Width="150px" />

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
</asp:Content>
