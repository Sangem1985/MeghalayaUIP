<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CFEStateMigrantCertificate.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEStateMigrantCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Meghalaya State Pollution Control Board </title>
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
        <%--<div class="col-md-1 pb-2 pt-2">
            <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back </asp:LinkButton>
        </div>--%>
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
                                    <h3 class="text-uppercase" style="margin-bottom: 0;"><u>Certificate of Registration</u></h3>
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
                            <div style="display: flex; justify-content: space-between; align-items: center; width: 100%;">
                                <p>
                                    Number: 
        <asp:Label ID="lblFileNo" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                                <p>
                                    Date: 
        <asp:Label ID="lblDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                            </div>
                            <p style="text-align: center; font-weight: bold; text-decoration: underline;">
                                <span style="font-weight: bold; text-decoration: underline;">GOVERMENT MEGHALAYA</span>
                                <asp:Label ID="Label4" runat="server" Style="font-weight: bold;"></asp:Label>
                            </p>
                            <p style="text-align: center; font-weight: bold; text-decoration: underline;">
                                <span style="font-weight: bold; text-decoration: underline;">Office of the Registering Officer</span>
                                <asp:Label ID="Label5" runat="server" Style="font-weight: bold;"></asp:Label>
                            </p>


                            <div style="text-align: justify;">
                                <p>
                                    A Certificate Containing the following particulars is hereby granted under clause (a) of sub-section (2) of Section 4 of the
                                    Inter-State Migrant Workmen(Regulation  of Employment Condition of Service). Act. 1979 and the rules made thereunder to
                                      <asp:Label ID="lblstatemigrant" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>

                                <p>
                                    1.Nature of Work Carried on in the establishment :<asp:Label ID="lblNature" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>

                                <p>
                                    2.Name and addresses of the contractors:  
                                    <asp:Label runat="server" ID="lblName" Style="font-weight: bold;"></asp:Label>
                                </p>

                                <p>
                                    3.Nature of work for which migrant workmen are to be employed or a re-employed:   
                                    <asp:Label runat="server" ID="lblMigrantwork" Style="font-weight: bold;"></asp:Label>
                                </p>

                                <p>
                                    4.Maximum number of migrant workmen to be employed on any day through each contractor:
                                    <asp:Label runat="server" ID="lblContractor" Style="font-weight: bold;"></asp:Label>
                                </p>


                                <p>
                                    5.Other Particulars relevant to employment of migrant workmen :
                                    <asp:Label runat="server" ID="lblrelevantemp" Style="font-weight: bold;"></asp:Label>

                                </p>
                                <p>
                                    (i)
                                </p>

                                <p>
                                    (ii)
                                </p>


                                <br />
                                <div style="text-align: right;">
                                    <p>Signature of Registering</p>
                                    <p>Officer with Seal</p>

                                </div>
                            </div>


                        </div>

                        <%--   <div class="col-md-12 d-flex" style="display: flex; width: 100%; flex-direction: row; flex-wrap: nowrap; justify-content: center;">
                            <div class="col-md-6" style="width: 10%;">
                                <asp:Button ID="btndownload" runat="server" Text="Download" class="btn btn-sm btn-info"></asp:Button>
                            </div>
                            <div class="col-md-6">
                                <button id="btnprint" onclick="window.print()" class="btn btn-sm btn-info">Print</button>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
