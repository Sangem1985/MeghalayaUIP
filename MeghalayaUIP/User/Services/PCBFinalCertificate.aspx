<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="PCBFinalCertificate.aspx.cs" Inherits="MeghalayaUIP.User.Services.PCBFinalCertificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a>Services</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Pollution Control Board Final Certificate</li>
                </ol>
            </nav>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row" runat="server" id="divText">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Certificate for Issue Of Authorization:</h4>
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
                                    <div>
                                        <p>
                                            Authorization No
                                        <asp:Label ID="lblAuthNum" runat="server" Style="font-weight: bold;">___________________________</asp:Label>
                                        </p>
                                        <p>
                                            To<br />
                                            </p><p style="text-align: justify;">
                                            <br />
                                            Ref: Your application number 
                                            <asp:Label ID="lblAppNumber" runat="server" Style="font-weight: bold;">___________________________</asp:Label>
                                            dt 
                                            <asp:Label ID="lblDate" runat="server" Style="font-weight: bold;">___________________________</asp:Label>
                                            <br />
                                            <br />
                                        </p>
                                        <p style="text-align: justify;">
                                            The 
                                            <asp:Label ID="lblSPCBC" runat="server" Style="font-weight: bold;">___________________________</asp:Label>
                                            State Pollution Control Board/Pollution Control Committee after examining the proposal hereby authorizes 
                                            <br />
                                            <br />
                                            <asp:Label ID="lblAuthorityName" runat="server" Style="font-weight: bold;">______________________________</asp:Label>

                                            having administrative office at
                                            <asp:Label ID="lblOfficeAddress" runat="server" Style="font-weight: bold;">______________________________</asp:Label>
                                            to set up and operate waste processing/
                                        </p>
                                        <br />
                                        <p >
                                            recycling/treatment/disposal facility at 
                                            <asp:Label ID="lblFacilityAddress" runat="server" Style="font-weight: bold;">___________________________</asp:Label>.
                                            <br />
                                        </p>
                                        <p>
                                            <br />
                                            The authorization is hereby granted to operate the facility for processing, recycling, treatment, and disposal of solid waste.
                                            <br />
                                        </p>
                                        <p style="text-align: justify;">
                                            <br />
                                            The authorization is subject to the terms and conditions stated below and such conditions as may be otherwise specified in these rules and the standards laid down in Schedules I and II under these rules.
                                            <br />
                                        </p>
                                        <p style="text-align: justify;">
                                            <br />
                                            The 
                                            <asp:Label ID="lblSPCBCRepeat" runat="server" Style="font-weight: bold;">____________________________</asp:Label>
                                            State Pollution Control Board/Pollution Control Committee of the UT may, at any time, revoke any of the conditions applicable under the authorization and shall communicate the same in writing.
                                            <br />
                                        </p>
                                        <p style="text-align: justify;">
                                            <br />
                                            Any violation of the provision of the Solid Waste Management Rules, 2016  will attract the penal provisions of the Environment  ( Protection )   Act , 1986 ( 29 of 1986 ).
                                            <br />
                                        </p>
                                        <br />
                                        <br />
                                        <p style="text-align: right;">
                                            (  Member Secretary  )   
                                        </p>
                                        <p style="text-align: right;">
                                            State Pollution Control Board/ Pollution Control Committee of the UT
                                        </p>
                                         <p>This is an electronically generated report, hence does not require signature</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
