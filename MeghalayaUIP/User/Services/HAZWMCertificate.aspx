<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HAZWMCertificate.aspx.cs" Inherits="MeghalayaUIP.User.Services.HAZWMCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hazardous Waste Management Certificate</title>
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
                                    Certificate No. MPCB/ ATH-27/2025/2024-2025/1001
                                </p>
                                <p>
                                    Dated. Shillong,
                                    <asp:Label ID="lblDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                            </div>
                            <div class="col-sm-6 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <div class="invoice-details text-center d-flex" style="text-align: center;">
                                    <h3 class="text-uppercase" style="margin-bottom: 0; text-align: justify;">
                                        FORM FOR GRANT/RENEWAL OF AUTHORIZATION BY MEGHALAYA STATE POLLUTION CONTROL BOARD, SHILLONG FOR OCCUPIERS, REPROCESSORS, REUSERS AND OPERATORS OF FACILITIES FOR COLLECTION, RECEPTION, TREATMENT, STORAGE, TRANSPORT AND DISPOSAL OF HAZARDOUS WASTE UNDER THE HAZARDOUS & OTHER WASTES (MANAGEMENT & TRANSBOUNDARY MOVEMENT) RULES, 2016
                                    </h3>
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
                            <div style="text-align: justify;">
                                <p>
                                    <asp:Label ID="lblRecipientName" runat="server" Style="font-weight: bold;"></asp:Label> of, 
                                    <asp:Label ID="lblRecipientAddress" runat="server" Style="font-weight: bold;"></asp:Label>   
                                    ,Meghalaya is hereby granted / renewal of the Authorization to operate a facility for collection, storage and disposal of hazardous waste on its premises situated at 
                                    <asp:Label ID="lblCompanyName" runat="server" Style="font-weight: bold;"></asp:Label>
                                    with reference to Application 
                                    <asp:Label ID="lblApplicationNumber" runat="server" Style="font-weight: bold;"></asp:Label>
                                    Dated
                                    <asp:Label ID="lblApplicationDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                                <p>
                                    The Authorization is granted / renewed to operate a facility for collection, storage and disposal of hazardous waste is in accordance to the hazardous waste management matrix  as specified below:-
                                </p>
                            </div>

                            <h4>Hazardous Waste Management Matrix</h4>
                            <table border="1" style="width: 100%; text-align: center;">
                                <tr>
                                    <th>Hazardous Waste</th>
                                    <th>Collection</th>
                                    <th>Reception</th>
                                    <th>Treatment</th>
                                    <th>Transport</th>
                                    <th>Storage</th>
                                    <th>Disposal</th>
                                </tr>
                                <tr>
                                    <td>Used/Spent Oil</td>
                                    <td>✓</td>
                                    <td>X</td>
                                    <td>X</td>
                                    <td>X</td>
                                    <td>✓ Leak proof containers</td>
                                    <td>Recycling within the plant premises Sale/auction to registered recycler/refiner</td>
                                </tr>
                                <tr>
                                    <td>Oil Sludge</td>
                                    <td>✓</td>
                                    <td>X</td>
                                    <td>X</td>
                                    <td>X</td>
                                    <td>✓ Leak proof containers</td>
                                    <td>Recycling within the plant premises Sale/auction to registered recycler/refiner</td>
                                </tr>
                            </table>

                            <p>
                                The Authorization is granted for a period of
                                <asp:Label ID="lblValidityYears" runat="server" Style="font-weight: bold;"></asp:Label>
                                years from
                                <asp:Label ID="lblStartDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                to
                                <asp:Label ID="lblEndDate" runat="server" Style="font-weight: bold;"></asp:Label>.
                            </p>

                            <p>
                                The Authorization is subject to the conditions stated below and such conditions as may be specified in the Rules for the time being in force under the Environment (Protection) Act, 1986.
                            </p>

                            <h4>Terms and Conditions</h4>
                            <ol>
                                <li>The Authorization shall comply with the provisions of the Environment (Protection) Act and Rules made there under.</li>
                                <li>The Authorization shall be produced for inspection at the request of an officer authorized by the Meghalaya State Pollution Control Board.</li>
                                <li>The person authorized shall not rent, lend, sell, transfer or otherwise transport the hazardous waste without obtaining prior permission of the Meghalaya State Pollution Control Board</li>
                                <li>Any unauthorized change in personnel, equipment and working condition as mentioned in the application by the person authorized shall constitute a breach of this Authorization.</li>
                                <li>The person authorized shall implement Emergency Response Procedure (ERP) for which this authorization is being granted considering all site specific possible scenarios such as spillages, leakages, fire etc. and their possible impacts and also carry out mock drill in this regard at regular interval of time</li>
                                <li>The person authorized shall comply with the provisions outlined in the Central Pollution Control Board guidelines on “Implementing Liabilities for Environmental Damages due to Handling and Disposal of Hazardous Waste and Penalty</li>
                                <li>It is the duty of the authorized person to take prior permission of the State Pollution Control Board to close down the facility.</li>
                                <li>The imported hazardous and other wastes shall be fully insured for transit as well as for any accidental occurrence and its clean-up operation. </li>
                                <li>The record of consumption and fate of the imported hazardous and other wastes shall be maintained. </li>
                                <li>The hazardous and other waste which gets generated during recycling or reuse or recovery or pre-processing or utilization of imported hazardous or other wastes shall be treated and disposed of as per specific conditions of authorization.</li>
                                <li>The importer or exporter shall bear the cost of import or export and mitigation of damages if any</li>
                                <li>An application for the renewal of an authorization shall be made as laid down under these Rules</li>
                                <li>Any other conditions for compliance as per the Guidelines issued by the Ministry of Environment, Forest and Climate Change or Central Pollution Control Board from time to time</li>
                                <li>Annual return shall be filed by June 30th for the period ensuring 31st March of the year. </li>
                            </ol>
                            <br />
                            <div style="text-align: right;">
                                <p style="text-transform: uppercase; font-weight: bold;">Member Secretary</p>
                                <p>Meghalaya State Pollution Control Board, Shillong</p>
                            </div>
                        </div>
                        <br />
                        <p>
                            <b>Copy to:</b> 
                        </p>
                        <ol>
                            <li>The Director of Commerce and Industries, Govt. of Meghalaya, Shillong for kind information.</li>
                            <li>The General Manager, District Commerce & Industries Centre,
                                 <asp:Label ID="lblGMInfo" runat="server" Style="font-weight: bold;"></asp:Label> for information.
                            </li>
                            <%--<li>
                                 <asp:Label ID="lblDirector" runat="server" Style="font-weight: bold;"></asp:Label>, C/o, The Director, 
                                 <asp:Label ID="lblFrstPrsn" runat="server" Style="font-weight: bold;"></asp:Label>,
                                 <asp:Label ID="lblScndPrsn" runat="server" Style="font-weight: bold;"></asp:Label>
                                for information and necessary action.
                            </li>--%>
                        </ol>


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
