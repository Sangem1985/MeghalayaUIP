<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CFETreeFelling.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFETreeFelling" %>

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
    <form id="form2" runat="server">
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
                                    <h3 class="text-uppercase" style="margin-bottom: 0;"><u>Permission to fell/burn/uproot/loop/cut tree within the Municipal area/Cantonment area under the Meghalaya Tree
(Preservation) Act, 1976</u></h3>
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
                            <div style="display: flex; justify-content: space-between; font-weight: bold; align-items: center; width: 100%;">
                                <p>
                                    Ref No: 
        <asp:Label ID="lblFileNo" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                                <p>
                                    Date: 
        <asp:Label ID="lblDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>

                            </div>
                            <div style="text-align: justify;">
                                <p>
                                    Permission Granted to :
                                     <asp:Label ID="lblGranted" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                            </div>
                            <div>
                                <p>
                                    Postal Address :
                                       <asp:Label ID="lblAddress" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                            </div>
                            <div>
                                <p>
                                    Location of the applied area :
                                     <asp:Label ID="lblArea" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                            </div>
                            <div>
                                <p>
                                    Purpose for felling of trees :
                                    <asp:Label ID="lbltree" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                            </div>

                            <div style="text-align: justify;">

                                <p>Details of Trees to be Felled:</p>
                                <div style="display: flex; justify-content: center; align-items: center;">
                                    <table border="1" style="width:70%; text-align:center;">
                                        <tr>
                                            <th style="text-align:center;">S. No.</th>
                                            <th style="text-align:center;">Species/Local Name</th>
                                            <th style="text-align:center;">No of Trees (H)</th>
                                        </tr>
                                        <tr>
                                            <td>1</td>
                                            <td>efefe</td>
                                            <td>44</td>
                                        </tr>
                                    </table>
                                </div>

                                <p>
                                    Total Number Of Trees :
                                       <asp:Label ID="lblNumber" runat="server" Style="font-weight: bold;"></asp:Label>

                                </p>

                                <p>
                                    <span style="font-weight: bold; text-decoration: underline;">Permission is granted for felling of the trees as detailed in the table mentioned above for the purpose mentioned above under the Meghalaya
Tree (Preservation) Act, 1976 subject to the following conditions:-</span>


                                </p>
                                <div style="display: flex; justify-content: center; align-items: center;">
                                    <table border="1" style="width:100%; text-align:center;">
                                        <tr>
                                            <th style="width:50px">S. No.</th>
                                            <th style="text-align:center;">Condition</th>
                                        </tr>
                                        <tr>
                                            <td>1</td>
                                            <td>Felling shall be restricted only to those identified & marked.</td>
                                        </tr>
                                        <tr>
                                            <td>2</td>
                                            <td>On receipt of any litigation / complaint, this permission is subject to cancellation.</td>
                                        </tr>
                                        <tr>
                                            <td>3</td>
                                            <td>You shall replant 10 times the number of trees felled and submit the report to this office along with photographs.</td>
                                        </tr>
                                        <tr>
                                            <td>4</td>
                                            <td>The Divisional Forest Officer or his subordinate is not responsible for any damage whatsoever caused during felling.</td>
                                        </tr>
                                        <tr>
                                            <td>5</td>
                                            <td>The timber shall be sawn only in licensed sawmills located at Industrial Estate.</td>
                                        </tr>
                                        <tr>
                                            <td>6</td>
                                            <td>Timber obtained from such felled trees will be allowed to be disposed of by sale or trade only on payment of Royalty.</td>
                                        </tr>
                                        <tr>
                                            <td>7</td>
                                            <td>You shall arrange for felling of trees.</td>
                                        </tr>
                                        <tr>
                                            <td>8</td>
                                            <td>You shall obtain a transit pass from the Range Forest Officer, I/c Bynihat, if the felled trees are required to be transported.</td>
                                        </tr>
                                        <tr>
                                            <td>9</td>
                                            <td>You shall pay full royalty ₹2345 only to this office through Treasury Challan (Head of Account 8782/103 Forest Remittance) / Cheque in favor of Divisional Forest Officer / /E-Payment by
assessing the website at www.megepayment.gov.in.</td>
                                        </tr>
                                    </table>
                                </div>
                                <br />
                                <div style="text-align: justify;">
                                    <p>
                                        Memo No:-
                                          <asp:Label ID="lblMemo" runat="server" Style="font-weight: bold;"></asp:Label>
                                    </p>

                                </div>

                                <br />
                                <p>Copy to: </p>
                                <p>
                                    1. Range Forest Officer, I/C Brnihat for favour of information and to ensure the concerned party's compliance report.
                                </p>
                                <div>
                                    <p>
                                        <span style="font-weight: bold; text-decoration: underline;">Signatory Details</span>
                                    </p>
                                    <p>
                                        Name : 
                                          <asp:Label ID="lblNames" runat="server" Style="font-weight: bold;"></asp:Label>
                                    </p>
                                    <p>
                                        Designation : 
                                         <asp:Label ID="lblDesignation" runat="server" Style="font-weight: bold;"></asp:Label>
                                    </p>
                                    <p>
                                        Issue Date:
                                        <asp:Label ID="lblIssueDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                    </p>
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
        </div>
    </form>
</body>
</html>
