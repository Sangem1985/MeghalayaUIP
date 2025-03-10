<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatteryWMCertificate.aspx.cs" Inherits="MeghalayaUIP.User.Services.BatteryWMCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Battery Waste Management Certificate</title>
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

                            <div style="display: flex; justify-content: space-between;">
                                <p>
                                    <strong>No. </strong>
                                    <asp:Label ID="lblNo" runat="server" Style="font-weight: bold;"></asp:Label>,
                                </p>
                                <p>
                                    <strong>Dated: </strong>
                                    <asp:Label ID="lblIssueDate" runat="server" Style="font-weight: bold;"></asp:Label>, 
                                    <asp:Label ID="lblIssuePlace" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                            </div>
                            <div class="col-sm-6 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <div class="invoice-details text-center d-flex" style="text-align: center;">
                                    <h3 class="text-uppercase" style="margin-bottom: 0;"><u>REGISTRATION OF LED ACID BATTERY DEALERS</u></h3>
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

                        <div class="row" style="text-align: justify;">
                            <p>
                                This is to Certify that 
                                <asp:Label ID="lblCompanyName" runat="server" Font-Bold="true"></asp:Label>
                                located  
                                <asp:Label ID="lblLocation" runat="server" Font-Bold="true"></asp:Label>
                                with GST No.  
                                <asp:Label ID="lblGSTNo" runat="server" Font-Bold="true"></asp:Label>
                                is hereby registered as a dealer of LEAD ACID BATTERIES under the Rules 7, Sub Rules (VII) a of the 
                                Batteries (Management and Handling) Rules, 2001, and its Amendment for a Period of 5 (five) years i.e. 
                                <asp:Label ID="lblStartDate" runat="server" Font-Bold="true"></asp:Label>
                                to  
                                <asp:Label ID="lblEndDate" runat="server" Font-Bold="true"></asp:Label>
                                under the following terms & conditions.
                            </p>

                            <ol>
                                <li>Ensure that the batteries are collected back as per the Schedule against new batteries sold.</li>
                                <li>Give appropriate discount for every used battery returned by the consumer.</li>
                                <li>Ensure that used batteries collected back are of similar type and specifications as that of the new batteries sold.</li>
                                <li>File half-yearly returns of the sale of new batteries and buy-back of old batteries to the manufacturer in Form V by 31st May and 30th November of every year.</li>
                                <li>Ensure safe transportation of collected batteries to the designated collection centers or to the registered recyclers.</li>
                                <li>Ensure that no damage is caused to the environment during storage and transportation of used batteries.</li>
                            </ol>

                            <div style="text-align: right;">
                                <p><strong>MEMBER SECRETARTY</strong></p>
                                <p>Meghalaya State pollution Control Board</p>
                                <p>Shillong</p>
                                <p>This is an electronically generated report, hence does not require signature</p>
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
