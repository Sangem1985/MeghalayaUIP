<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BMWCertificate.aspx.cs" Inherits="MeghalayaUIP.User.Services.BMWCertificate" %>

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
                                    <h3 class="text-uppercase" style="margin-bottom: 0;"><u>Meghalaya State Pollution Control Board</u></h3>
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




                            <div style="text-align: justify;">

                                <p style="text-align: center;">
                                    <span style="font-weight: bold; text-decoration: underline;">AUTHORISATION UNDER THE BIO-MEDICAL MANAGEMENT RULES, 2016
                                    </span>
                                </p>


                                <p>
                                    <%-- Bataw Primary Health Centre, East Jaintia Hills District,10 (Thirty)beds,31" January, 2026--%>  
                                    
                                    Authorisation under Rule 10 of the Bio-Medical Waste Management Rules, 2016, is hereby
granted to 
                                    <asp:Label ID="lblPollutionBoard" runat="server" Style="font-weight: bold;"></asp:Label>
                                    with a capacity of 
                         <asp:Label ID="lblBMW" runat="server" Style="font-weight: bold;"></asp:Label>
                                    for generating, collecting, receiving, storing, transporting, treatment or processing or conversion,
recycling, disposing or destruction, use, offering for sale, transfer and/or handling bio-medical waste
in any manner and which expires on 31st January, 2021 is hereby renewed for a period of five years
i.e., up to
                                    <asp:Label ID="lblwaste" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                                <p>
                                    This Authorisation shall be produced for inspection at the request of the officer authorised by
the Prescribed Authority, i.e. Meghalaya State Pollution Control Board and is subject to the conditions
stated below and to such other conditions as may be specified in the Rules, for the time being, in force
under the Environment (Protection) Act, 1986.
                                </p>

                                <p>
                                    <span style="font-weight: bold; text-decoration: underline;">TERMS AND CONDITIONS OF AUTHORISATION</span>
                                    <asp:Label ID="Label4" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>



                                <p>
                                    1. The Authorised person/institution shall comply with the provision of the Environment
(Protection) Act, 1986 and the relevant Rules made there under.

                                </p>

                                <p>
                                    <%-- 30th September 2022--%>

                               2. The Authorised person/institution shall not rent, lend, sell, transfer or otherwise transport the biomedical wastes without obtaining the prior permission of the Prescribed Authority, i.e. Meghalaya
State Pollution Control Board.
                                </p>

                                <p>
                                    3. Any unauthorised change in the mode of handling, treatment or disposal as mentioned in the
application by the Authorised person / institution shall constitute a breach of this Authorisation.
                                </p>


                                <p>
                                    4. It is the duty of the authorised person to take prior permission of the prescribed authority to close
down the facility and such other terms and conditions may be stipulated by the prescribed
authority.


                                </p>
                                <p>
                                    5. Bio-medical waste shall be segregated into containers/bags at the point of generation in
accordance with Schedule-I. The containers/bags shall be labelled according to Schedule-IV PartA.
                                </p>
                                <p>
                                    6. Containers transported from the premises where bio-medical waste is generated to the waste
treatment facility shall, apart from the label prescribed in Schedule-IV Part-A, also carry
information prescribed in Schedule-IV Part-В.
                                </p>

                                <p>
                                    7. The bio-medical waste shall be transported in covered vehicles which shall be labelled according
to Schedule-IV Part-A.
                                </p>
                                <p>8. No untreated bio-medical waste shall be kept / stored beyond a period of 48 hours.</p>
                                <p>
                                    9. Electric needle-destroyers shall have to be provided at all points of generation, preferably at every
Nurses' Duty Room. Needles are to be destroyed immediately after use. Plastic syringe bodies
shall be stored in a chemical disinfectant, in puncture proof containers, at the point of generation
till their collection and transport for final treatment.
                                </p>

                                <p>
                                    10. Bio-medical waste shall be treated and disposed off in accordance with Schedule I and in
compliance with the Standards prescribed in Schedule II.


                                </p>

                                <p>
                                    11. Chemically disinfected waste sharps shall be disposed of in a specially constructed sharps pit
within the hospital premises.
                                </p>

                                <p>12. A waste autoclave shall have to be provided to disinfect all contaminated solid and soiled biomedical waste, which cannot be incinerated, including the plastic syringe bodies.</p>

                                <p>13. Lignd and chemical waste shall be neutralized and disinfected before discharge into public *SHrains</p>

                                <p>
                                    14. Protective clothing like gloves, masks, overalls and rubber boots shall be provided to staff
handling bio-medical waste.
                                </p>

                                <p>
                                    15.
                                    <asp:Label ID="lblAutheration" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>


                                <p>
                                    16.<asp:Label ID="lblrenewal" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                                <p>
                                    17.<asp:Label ID="lblPCB" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                                <p>
                                    18. Appropriate Effluent Treatment Plant should be installed to ensure the effluent is within the
prescribed standards as per Scheduled II.
                                </p>

                                <div style="display: flex; justify-content: center; align-items: center;">
                                    <table border="1">
                                        <tr>
                                            <th>PARAMETERS</th>
                                            <th>PERMISSIBLE LIMITS</th>
                                        </tr>
                                        <tr>
                                            <td>pH</td>
                                            <td>6.5-9.0</td>
                                        </tr>
                                        <tr>
                                            <td>Suspended solids</td>
                                            <td>100 mg/l</td>
                                        </tr>
                                        <tr>
                                            <td>Oil and grease</td>
                                            <td>10 mg/l</td>
                                        </tr>
                                        <tr>
                                            <td>BOD</td>
                                            <td>30 mg/l</td>
                                        </tr>
                                        <tr>
                                            <td>COD</td>
                                            <td>250 mg/l</td>
                                        </tr>
                                        <tr>
                                            <td>Bio-assay test</td>
                                            <td>90% survival of fish after 96 hours in 100% effluent</td>
                                        </tr>
                                    </table>

                                </div>

                            </div>
                            <br />
                            <br />
                            <div style="text-align: right; font-weight: bold;">
                                <p>MEMBER SECRETARY</p>
                                <p>Meghalaya State Pollution Control Board, Shillong</p>
                            </div>


                            <br />
                            <p>Copy to: </p>
                            <p>
                                1. The Director of Health Services (MI), Meghalaya, Shillong.
                            </p>

                            <p>
                                2. The District Medical & Health Officer, East Jaintia Hills, Khliehriat.
                            </p>
                            <p>3. The Medical & Health Officer, Dr Easter Lyngdoh, I/C., P.H.C., Bataw, East Jaintia Hills District.</p>


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
