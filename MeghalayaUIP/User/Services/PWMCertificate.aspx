<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PWMCertificate.aspx.cs" Inherits="MeghalayaUIP.User.Services.PWMCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Plastic Waste Management Certificate</title>
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
                                    <h3 class="text-uppercase" style="margin-bottom: 0;"><u>CERTIFICATE OF REGISTRATION FOR THE MANUFACTURERES AND PRODUCERS</u></h3>
                                    <h4>(Under the Plastic Waste Management Rules, 2016)</h4>
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
                            <div style="display: flex; justify-content: space-between;">
                                <p>
                                    Certificate No. MPCB/
                                    <asp:Label ID="lblCertificateNo" runat="server" Style="font-weight: bold; text-decoration: underline;"></asp:Label>
                                </p>
                                <p>
                                    Dtd. Shillong, 
                                    <asp:Label ID="lblDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                            </div>


                            <p>To,</p>
                            <p>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblRecipientName" runat="server" Style="font-weight: bold;"></asp:Label><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblRecipientAddress1" runat="server" Style="font-weight: bold;"></asp:Label><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblRecipientAddress2" runat="server" Style="font-weight: bold;"></asp:Label><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblRecipientAddress3" runat="server" Style="font-weight: bold;"></asp:Label>
                            </p>

                            <p>
                                Ref:
                                <asp:Label ID="lblReference" runat="server" Style="font-weight: bold;"></asp:Label>
                            </p>

                            <div style="text-align: justify;">
                                <p>
                                    The Meghalaya State Pollution Control Board, after examining the application, hereby certifies that
                                    <asp:Label ID="lblCompanyName" runat="server" Style="font-weight: bold;"></asp:Label>
                                    located at
                                    <asp:Label ID="lblCompanyAddress" runat="server" Style="font-weight: bold;"></asp:Label>
                                    has been registered as a unit manufacturing
                                    <asp:Label ID="lblManufacturedProduct" runat="server" Style="font-weight: bold;"></asp:Label>.
                                </p>

                                <p>
                                    This certificate of registration shall be valid for a period of
                                    <asp:Label ID="lblValidityYears" runat="server" Style="font-weight: bold;"></asp:Label>
                                    years unless revoked or suspended. The certificate is granted subject to the following conditions:
                                </p>

                                <ol>
                                    <li>The registration is granted for manufacturing the above products from virgin plastic only.</li>
                                    <li>The manufacturing capacity should not exceed 2000MT/Annum.</li>
                                    <li>The firm should not manufacture any plastic items less than 50 microns.</li>
                                    <li>Use of pigments and colorants should be as per IS: 9833: 1981.</li>
                                    <li>The unit should possess a valid consent under the Water (Prevention & Control of Pollution) Act, 1974 & Air (Prevention & Control of Pollution) Act, 1981.</li>
                                    <li>The unit should adhere to the terms and conditions of the consent and ensure compliance with the prescribed emission and effluent standards.</li>
                                    <li>Application for renewal of registration should be made in Form-I, at least 120 (one hundred twenty) days before the expiry of the validity of the registration.</li>
                                </ol>
                            </div>

                            <br />
                            <div style="text-align: right;">
                                <p>(Member Secretary)</p>
                                <p>Meghalaya State Pollution Control Board, Shillong</p>
                            </div>
                            <br />
                            <div style="display: flex; justify-content: space-between;">
                                <p>Memo No. MPCB/TB-784(Pt-I)/2020-2021/24</p>
                               <%-- <p>Dated. Shillong, the 4th June 2020</p>--%>
                            </div>


                            <p>Copy to:</p>
                            <ol style="text-align: justify;">
                                <li>The Director, Urban Affairs Department, Meghalaya, Shillong for information.</li>
                                <li>The Director, Industries, Meghalaya.</li>
                                <li>The Deputy Commissioner, Meghalaya 
                                    <asp:Label ID="lblDeputyCommissionerDistrict" runat="server" Style="font-weight: bold;"></asp:Label>.
                                </li>
                                <li>The Under Secretary to the Govt. of Meghalaya, Forests & Environment Department.</li>
                               
                                    <asp:Label ID="lblGeneralInfo" Visible="false" runat="server" Style="font-weight: bold;"></asp:Label>.
                                
                            </ol>
                            <br />
                            <div style="text-align: right;">
                                <p>(Member Secretary)</p>
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
