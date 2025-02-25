<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EWMManfctrRefCertificate.aspx.cs" Inherits="MeghalayaUIP.User.Services.EWMManfctrRefCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ewaste Manufacturer Refurbisher Waste Management Certificate</title>
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
                            <br />
                            <div class="col-sm-6 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <div class="invoice-details text-center d-flex" style="text-align: center;">
                                    <h3 class="text-uppercase" style="margin-bottom: 0;"><u>FORMAT FOR GRANTING AUTHORISATION FOR GENERATION OR STORAGE OR TREATMENT OR REFURBISHING OR DISPOSAL OF E-WASTE BY MANUFACTURER OR REFURBISHER</u></h3>
                                    <h4>Ref:	Your application for Grant of Authorisation</h4>
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
                                    1. (a) Authorisation No.: 
                                    <asp:Label ID="lblAuthorizationNo" runat="server" Style="font-weight: bold; text-decoration: underline;"></asp:Label>
                                </p> and
                                <p>
                                    (b) Date of Issue: 
                                    <asp:Label ID="lblIssueDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                            

                            <p>
                                2. 
                                <asp:Label ID="lblCompanyName" runat="server" Style="font-weight: bold;"></asp:Label>
                                of 
                                <asp:Label ID="lblCompanyLocation" runat="server" Style="font-weight: bold;"></asp:Label>
                                is hereby granted an authorization for generation, storage, treatment, and disposal of e-waste on the premises situated at 
                                <asp:Label ID="lblPremisesAddress" runat="server" Style="font-weight: bold;"></asp:Label>.
                            </p>

                            <p>The authorization is granted for the following:</p>
                            <ol type="a">
                                <li>Quantity of e-waste: 
                                <asp:Label ID="lblEwasteQuantity" runat="server" Style="font-weight: bold;"></asp:Label>
                                </li>
                                <li>Nature of e-waste: 
                                <asp:Label ID="lblEwasteNature" runat="server" Style="font-weight: bold;"></asp:Label>
                                </li>
                            </ol>

                            <p>
                                3. The authorization shall be valid for a period from 
                                <asp:Label ID="lblValidFrom" runat="server" Style="font-weight: bold;"></asp:Label>
                                to 
                                <asp:Label ID="lblValidTo" runat="server" Style="font-weight: bold;"></asp:Label>.
                            </p>

                            <p>
                                4. The e-waste mentioned above shall be treated/disposed of in a manner at 
                                <asp:Label ID="lblDisposalLocation" runat="server" Style="font-weight: bold;"></asp:Label>.
                            </p>

                            <p>
                                5. The authorization is subject to the conditions stated below and such conditions as may be specified in the rules for the time being in force under the Environment (Protection) Act, 1986.
                            </p>

                            <br />
                            <p style="text-align: left;">Signature:
                                <asp:Label ID="lblSingature" runat="server" Style="font-weight: bold;"></asp:Label>
                            </p>
                            <div style="display: flex; justify-content: space-between;">
                                <p>
                                    Designation: 
                                    <asp:Label ID="lblDesignation" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                                <p>
                                    Date: 
                                    <asp:Label ID="lblSignatureDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                            </div>


                            <div style="text-align: center;"><h4>Terms and conditions of authorisation</h4></div>
                            <ol>
                                <li>The authorisation shall comply with the provisions of the Environment (Protection) Act, 1986, and the rules made thereunder.</li>
                                <li>The authorisation or its renewal shall be produced for inspection at the request of an officer authorized by the concerned State Pollution Control Board.</li>
                                <li>Any unauthorised change in personnel, equipment, or working conditions as mentioned in the application by the person authorized shall constitute a breach of his authorisation.</li>
                                <li>It is the duty of the authorised person to take prior permission of the concerned State Pollution Control Board to close down the operations.</li>
                                <li>An application for the renewal of an authorisation shall be made as laid down in sub-rule (vi) of rule 13(2).</li>
                            </ol>

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
