<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CDWMCertificate.aspx.cs" Inherits="MeghalayaUIP.User.Services.CDWMCertificate" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Construction and Demolition Waste Management Certificate</title>
    <link href="assets/admin/css/style.css" rel="stylesheet" />
    <style>
        a#lbtnBack {
            float: right;
            background: #607D8B;
            width: 59px;
            height: 24px;
            border-radius: 4px;
            transition: all 0.4s;
            text-align: center !important;
            color: #fff;
            text-transform: capitalize;
            text-decoration: none;
            padding: 6px 4px 1px;
            position: absolute;
            top: 39px;
            right: 210px;
        }

        ul.list-unstyled.mb-0.list-item li {
            list-style: none;
        }

        .invoice-container {
            background-color: #fff;
            border: 1px solid #000;
            margin: 0 auto 1.875rem;
            max-width: 900px;
            padding: 1.5rem;
            border-radius: 8px;
            box-shadow: 1px 4px 8px 2px #919191;
            margin-top: 75px;
        }

        body {
            background: url(../../assets/admin/img/bgo.jpg);
            background-size: contain;
            background-position: inherit;
        }

        .fotter {
            margin-left: 93px;
        }

            .fotter p {
                line-height: 14px;
            }
    </style>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.9.2/html2pdf.bundle.js"></script>

    <script>
        function downloadPDF() {
            var content = document.getElementById('ackcontent'); // Get the content to be converted

            // Create a new jsPDF instance
            const { jsPDF } = window.jspdf;
            const doc = new jsPDF();

            // Convert the HTML content into PDF
            doc.html(content, {
                callback: function (doc) {
                    // Save the generated PDF
                    doc.save('application_acknowledgement.pdf');
                },
                margin: [10, 10, 10, 10], // Margin for the PDF
                x: 10,
                y: 10
            });
        }
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <div class="col-md-1 pb-2 pt-2">
            <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back </asp:LinkButton>
        </div>
        <div id="swmcontent" runat="server">
            <div class="page-wrapper" style="min-height: 293px;">
                <div class="content container-fluid">
                    <div class="invoice-container">
                        <asp:HiddenField ID="hdnUserID" runat="server" />
                        <div class="row">
                            <div class="col-sm-12 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <img alt="Logo" class="img-fluid" src="../../assets/admin/img/logo.png" />
                            </div>
                            <div class="col-sm-6 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <div class="invoice-details text-center d-flex" style="text-align: center;">
                                    <h3 class="text-uppercase" style="margin-bottom: 0;"><u>Issue of Authorization to the Operator</u></h3>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 ">
                            <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                                <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">×</span></button>
                            </div>
                        </div>

                        <div class="row">
                            <p>
                                <strong>Ref :</strong> Your application number :  
                                <asp:Label ID="lblApplicationNumber" runat="server" Style="font-weight: bold;"></asp:Label>   <br />
                                <strong>Dated:</strong>
                                <asp:Label ID="lblApplicationDate" runat="server" Style="font-weight: bold;"></asp:Label>
                            </p>

                            <p>
                                The 
                                 <asp:Label ID="lblStatePolutnBoard" runat="server" Style="font-weight: bold;"></asp:Label>
                                State Pollution Control Board or Pollution Control Committee, after examining the proposal, hereby authorizes 
                                 <asp:Label ID="lblAuthorizedPerson" runat="server" Style="font-weight: bold;"></asp:Label>
                                having their administrative office at  
                                <asp:Label ID="lblOfficeAddress" runat="server" Style="font-weight: bold;"></asp:Label>
                                to set up and operate a construction and demolition waste processing facility at  
                                <asp:Label ID="lblFacilityLocation" runat="server" Style="font-weight: bold;"></asp:Label>
                                on the terms and conditions (including the standards to comply) attached to this authorisation letter.
                            </p>

                            <ol>
                                <li>The validity of this authorisation is till  
                                <asp:Label ID="lblValidityDate" runat="server" Style="font-weight: bold;"></asp:Label>.  
                                After expiry of the validity period, renewal of authorisation is to be sought.
                                </li>
                                <li>The 
                                     <asp:Label ID="lblStatePolutn2" runat="server" Style="font-weight: bold;"></asp:Label>
                                    State Pollution Control Board or Pollution Control Committee may, at any time, for justifiable reason,  
                                revoke any of the conditions applicable under the authorisation and shall communicate the same in writing.
                                </li>
                                <li>Any violation of the provision of the Construction and Demolition Waste Management Rules, 2016  
                                    shall attract the penal provision of the Environment (Protection) Act, 1986 (29 of 1986).
                                </li>
                            </ol>

                            <br />

                            <div style="display: flex; justify-content: space-between;">
                                <p><strong>Date:</strong>
                                    <asp:Label ID="lblIssueDate" runat="server" Style="font-weight: bold;"></asp:Label></p>
                                <p><strong>Place:</strong>
                                    <asp:Label ID="lblIssuePlace" runat="server" Style="font-weight: bold;"></asp:Label></p>
                            </div>

                            <br />

                            <div style="text-align: right;">
                                <p>(<strong>Member Secretary</strong>)</p>
                                <p>State Pollution Control Board / Pollution Control Committee</p>
                            </div>
                        </div>




                        <div class="col-md-12 d-flex" style="display: flex; width: 100%; flex-direction: row; flex-wrap: nowrap; justify-content: center;">
                            <div class="col-md-6" style="width: 10%;">
                                <asp:Button ID="btndownload" runat="server" Text="Download" class="btn btn-sm btn-info"></asp:Button>
                            </div>
                            <div class="col-md-6">
                                <button id="btnprint" onclick="window.print()" class="btn btn-sm btn-info">Print</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
