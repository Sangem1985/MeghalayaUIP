<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NHAZWMCertificate.aspx.cs" Inherits="MeghalayaUIP.User.Services.NHAZWMCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Non-Hazardous Waste Management Certificate</title>
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
                                    Certificate No. MPCB/ ATH-27/2007/2021-2022/
                                </p>
                                <p>
                                    Dated. Shillong,
        <asp:Label ID="lblDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                            </div>
                            <div class="col-sm-6 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <br />
                                <div class="col-sm-6 m-b-20 text-center" style="display: flex; justify-content: center;">
                                    <div class="invoice-details text-center d-flex" style="text-align: center;">
                                        <h3 class="text-uppercase" style="margin-bottom: 0; text-align: justify;">FORM FOR GRANT/RENEWAL OF AUTHORIZATION BY MEGHALAYA STATE POLLUTION CONTROL BOARD, SHILLONG FOR OCCUPIERS, REPROCESSORS, REUSERS AND OPERATORS OF FACILITIES FOR COLLECTION, RECEPTION, TREATMENT, STORAGE, TRANSPORT AND DISPOSAL OF HAZARDOUS WASTE UNDER THE HAZARDOUS & OTHER WASTES (MANAGEMENT & TRANSBOUNDARY MOVEMENT) RULES, 2016                                 </h3>
                                    </div>
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
                                    <asp:Label ID="lblRecipientName" runat="server" Style="font-weight: bold;"></asp:Label>of, 
                                    <asp:Label ID="lblRecipientAddress" runat="server" Style="font-weight: bold;"></asp:Label>
                                    ,Meghalaya is hereby granted / renewal of the Authorization to operate a facility for collection, storage and disposal of hazardous waste on its premises situated at 
                                    <asp:Label ID="lblCompanyName" runat="server" Style="font-weight: bold;"></asp:Label>
                                    with reference to Application 
                                    <asp:Label ID="lblApplicationNumber" runat="server" Style="font-weight: bold;"></asp:Label>
                                    Dated
                                    <asp:Label ID="lblApplicationDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                                <p>
                                    The Authorization is granted to operate a facility for Collection, Reception, Storage & Co-Processing of Non-Hazardous Waste in accordance to the hazardous waste management matrix  as specified below:-
                                </p>
                                <h4><u>WASTE MANAGEMENT MATRIX</u></h4>
                                <table border="1" style="width: 100%; text-align: center;">
                                    <tr>
                                        <th>Sl.No</th>
                                        <th>Non Hazardous Waste</th>
                                        <th>Quantity</th>
                                        <th>Collection</th>
                                        <th>Reception</th>
                                        <th>Storage</th>
                                        <th>Co-Processing</th>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>HDPE Bags</td>
                                        <td></td>
                                        <td>✓</td>
                                        <td>✓</td>
                                        <td>✓</td>
                                        <td>✓</td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>Scrap Tyre & Tube</td>
                                        <td></td>
                                        <td>✓</td>
                                        <td>✓</td>
                                        <td>✓</td>
                                        <td>✓</td>
                                    </tr>
                                </table>
                                <br />
                                <p>
                                    The Authorization is granted for a period of 5(five) years, ie. from 
                                    <asp:Label ID="lblStartDate" runat="server" Style="font-weight: bold;"></asp:Label>
                                    upto
                                    <asp:Label ID="lblEndDate" runat="server" Style="font-weight: bold;"></asp:Label>.
                                </p>
                                <p>The Authorization is subject to the conditions stated below and such conditions as may be specified in the Rules for the time being in force under the Environment (Protection) Act, 1986.</p>

                                <h4>Terms and Conditions</h4>
                                <ol>
                                    <li>The Authorization shall comply with the provisions of the Environment (Protection) Act and Rules made there under.</li>
                                    <li>The Authorization shall be produced for inspection at the request of an officer authorized by the Meghalaya State Pollution Control Board.</li>
                                    <li>Any unauthorized change in personnel, equipment and working condition as mentioned in the application by the person authorized shall constitute a breach of this Authorization.</li>
                                    <li>The person authorized shall implement Emergency Response Procedure (ERP) for which this authorization is being granted considering all site specific possible scenarios such as spillages, leakages, fire etc. and their possible impacts and also carry out mock drill in this regard at regular interval of time;</li>
                                    <li>The person authorized shall comply with the provisions outlined in the Central Pollution Control Board guidelines on “Pre-Processing & Co-Processing of Hazardous & Other Wastes in Cement Plant as per Hazardous & Other Wastes (Management & Transboundary Movement) Rules, 2016”.</li>
                                    <li>The imported hazardous and other wastes shall be fully insured for transit as well as for any accidental occurrence and its clean-up operation.</li>
                                    <li>The record of consumption and fate of the imported hazardous and other wastes shall be maintained.</li>
                                    <li>An application for the renewal of an authorization shall be made as laid down under these Rules.</li>
                                    <li>Any other conditions for compliance as per the Guidelines issued by the Ministry of Environment, Forest and Climate Change or Central Pollution Control Board from time to time.</li>
                                    <li>Annual return shall be filed by June 30th for the period ensuring 31st March of the year.</li>
                                </ol>

                                <h4>SPECIFIC CONDITIONS: </h4>
                                <ol>
                                    <li>It shall be the duty of the receiver and operator of a facility to take adequate steps while handling hazardous & Other Waste to: -  
                                    <ol type="a">
                                        <li>contain contaminants and prevent accidents and limit their consequences on humans and the environment,</li>
                                        <li>provide persons working on the site with information, training and equipment necessary to ensure their safety, and</li>
                                        <li>put up prominent hoardings indicating the nature of wastes/materials handled and precautionary measures taken, besides Do’s & Don’ts, for public in case of any mishap.</li>
                                    </ol>
                                    </li>
                                    <li>The transportation of Hazardous & Other Waste shall be in accordance with the provisions of the Hazardous & Other Wastes (Management & Transboundary Movement) Rules, 2016 and Rules made by the Central Government under Motor Vehicles (Amendment) Act, 2019.</li>
                                    <li>The receiver of waste for transportation, storage and co-processing of hazardous waste shall maintain records of such operation in Form 3.</li>
                                    <li>The receiver of waste shall submit Annual Returns to the Meghalaya State Pollution Control Board in Form 4 by the 30th June of every year for the preceding period April to March.</li>
                                    <li>The occupier shall provide the transporter with the relevant information in Form 9, regarding the hazardous nature of the wastes and measures to be taken in case of an emergency and shall label the hazardous and other wastes containers as per Form 8.</li>
                                    <li>In case of transportation of hazardous and other waste for recycling or utilisation including co-processing, the sender shall intimate both the State Pollution Control Boards before handing over the waste to the transporter.</li>
                                    <li>In case of transit of hazardous and other waste for recycling, utilisation including co-processing or disposal through a State other than the States of origin and destination, the sender shall give prior intimation to the concerned State Pollution Control Board of the States of transit before handing over the wastes to the transporter.</li>
                                    <li>The sender of the waste shall prepare seven copies of the manifest in Form 10 comprising of colour code indicated below and all seven copies shall be signed by the sender:</li>
                                </ol>
                                <table border="1">
                                    <thead>
                                        <tr>
                                            <th>Copy number with colour code</th>
                                            <th>Purpose</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>Copy 1 (White)</td>
                                            <td>To be forwarded by the sender to the State Pollution Control Board after signing all the seven copies.</td>
                                        </tr>
                                        <tr>
                                            <td>Copy 2 (Yellow)</td>
                                            <td>To be retained by the sender after taking signature on it from the transporter and the rest of the five signed copies to be carried by the transporter.</td>
                                        </tr>
                                        <tr>
                                            <td>Copy 2 (Pink)</td>
                                            <td>To be retained by the receiver (actual user or treatment storage and disposal facility operator) after receiving the waste and the remaining four copies are to be duly signed by the receiver.</td>
                                        </tr>
                                        <tr>
                                            <td>Copy 2 (Orange)</td>
                                            <td>To be handed over to the transporter by the receiver after accepting waste.</td>
                                        </tr>
                                        <tr>
                                            <td>Copy 2 (Green)</td>
                                            <td>To be sent by the receiver to the State Pollution Control Board.</td>
                                        </tr>
                                        <tr>
                                            <td>Copy 2 (Blue)</td>
                                            <td>To be sent by the receiver to the sender.</td>
                                        </tr>
                                        <tr>
                                            <td>Copy 7 (Grey)</td>
                                            <td>To be sent by the receiver to the State Pollution Control Board of the sender in case the sender is in another State.</td>
                                        </tr>
                                    </tbody>
                                </table>
                                <ol start="9">
                                    <li>The sender shall forward copy 1 (white) to the State Pollution Control Board, and in case the hazardous or other wastes is likely to be transported through any transit State, the sender shall intimate State Pollution Control Boards of transit States about the movement of the waste.</li>
                                    <li>No transporter shall accept waste from the sender for transport unless it is accompanied by signed copies 3 to 7 of the manifest.</li>
                                    <li>The transporter shall submit copies 3 to 7 of the manifest duly signed with date to the receiver along with the waste consignment.</li>
                                    <li>The receiver after acceptance of the waste shall hand over copy 4 (orange) to the transporter and send copy 5 (green) to his State Pollution Control Board and send copy 6 (blue) to the sender and the copy 3 (pink) shall be retained by the receiver.</li>
                                    <li>The copy 7 (grey) shall only be sent to the State Pollution Control Board of the sender, if the sender is in another State.</li>
                                    <li>The Unit shall report any accident in Form 11 immediately to the Meghalaya State Pollution Control Board.</li>
                                    <li>The occupier and operator of a facility may file an appeal against an Order passed by the Meghalaya State Pollution Control Board in Form 12.</li>
                                </ol>
                                <br />
                                <p>
                                    <b>Copy to:</b>
                                </p>
                                <ol>
                                    <li>The Director of Commerce and Industries, Govt. of Meghalaya, Shillong for kind information.</li>
                                    <li>The General Manager, District Commerce & Industries Centre,
                                    <asp:Label ID="lblGMInfo" runat="server" Style="font-weight: bold;"></asp:Label>
                                        for information.
                                    </li>
                                    <li>
                                        <asp:Label ID="lblDirector" runat="server" Style="font-weight: bold;"></asp:Label>, C/o, The Director, 
                                        <asp:Label ID="lblFrstPrsn" runat="server" Style="font-weight: bold;"></asp:Label>,
                                        for information and necessary action.
                                    </li>
                                </ol>





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
