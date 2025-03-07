<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CFEPcbCertificate.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEPcbCertificate" %>

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

                            <%--  <p>
                                <span style="font-weight: bold; text-decoration: underline;">Authorization No:</span>
                                <asp:Label ID="lblAuthorizationNo" runat="server" Style="font-weight: bold;"></asp:Label>
                            </p>

                            <p>To</p>

                            <p>
                                Ref: Your application number 
                                <asp:Label ID="lblApplicationNo" runat="server" Style="font-weight: bold;"></asp:Label>
                                dated 
                                <asp:Label ID="lblApplicationDate" runat="server" Style="font-weight: bold;"></asp:Label>
                            </p>--%>
                            <div style="text-align: justify;">
                                <p>
                                    <asp:Label ID="lblPollutionBoard" runat="server" Style="font-weight: bold;"></asp:Label>
                                     under Section 25/26 of the Water (Prevention & Control of Pollution) Act, 1974, as
amended and under Section 21 of the Air (Prevention & Control of Pollution) Act, 1981, as amended (to be referred as
Water Act and Air Act respectively).
                                </p>
                                <%--M/S RI KALENG LIMESTONE MINE--%>    <%--2.05 Ha.Limestone Mineat at Ri Kaleng, Lynti Dkhar, Sohbar Sirdarship, East Khasi Hills District--%>
                                <p>  <%--2,01,150  TPA--%>  <%--Rs. 22,00,000/- (Rupees Twenty Two Lakhs) only--%><%--terms and conditions--%>
                                    CONSENT is granted to
                                        <asp:Label ID="lblName" runat="server" Style="font-weight: bold;"></asp:Label>
                                    for operating a <asp:Label runat="server" ID="lbldistrict"></asp:Label>
                                     with production capacity <asp:Label ID="lblTPA" runat="server" Style="font-weight: bold;"></asp:Label> andwith a Project cost of <asp:Label runat="server" ID="lblAmount"></asp:Label> under the following <asp:Label runat="server" ID="lblTerm"></asp:Label>:
                                </p>
                                <%--M/S RI KALENGLIMESTONE MINE--%>

                                <p>
                                    1. This Consent has been accorded based on the particulars furnished by the applicant on behalf of
                                        <asp:Label runat="server" ID="lblMine" Style="font-weight: bold;"></asp:Label>
                                    and subject to addition of further or more conditions if so warranted by subsequentdevelopments. The Consent will automatically become invalid if any change or alteration or deviation is made in actualpractice;
                                </p>

                                <p>
                                    <%-- 30th September 2022--%>

                                2. The Consent to Establish is valid for a period upto 
                                         <asp:Label runat="server" ID="Date" Style="font-weight: bold;"></asp:Label>
                                   unless otherwise suspended or revoked. The validity period shall be extended if necessary till such time the industry is commissioned for commercial production;
                                </p>

                                <p>
                                    3. This Consent may be modified, suspended or revoked by the Board in whole or in part during its term for cause
including, but not limited to the following:-
Violation of any Terms and Conditions of this Consent;
(a) Obtaining the Consent by misrepresentation or failure to disclose fully all relevant facts;
(b) A change in any condition that require temporary or permanent reduction or elimination of the authorized
discharge/emission;
                                </p>


                                <p>
                                   4. This Consent does not convey any property right in either real or personal property or any exclusive privileges, nor does
it authorizes any injury to private property or any invasion of personal rights, nor any infringement of Central State or
Local Laws or Regulation;

                                </p>
                                <p>
                                   5. No air, water and soil pollution shall be created by the Industry beyond the prescribed permissible limits.
                                </p>
                                <p>
                                  6. To maintain the environment and ecology of the area, development of green belt by planting selected species of trees,
the height of which should not be less than 5 (five) metres when matured and at a spacing of 1 (One) metre should be
made around the mine;
                                </p>

                                <p>7. As per the provisions of the Water (Prevention and Control of Pollution) Act, 1974 as amended and the Air (Preventionand Control of Pollution) Act, 1981 as amended that any Officer empowered by the Board on its behalf shall havewithout interruption, the right at any time to enter the Plant/factory/for inspection, collection of sample for analysis andmay call for any information as deemed necessary. Denial this right will cause withdrawal of the Consent Order;</p>
                                <p>8. The Company shall comply with all the environment protection measures and safeguards recommended in the approvedmining plan.</p>
                                <p>9. The caves should be preserved, if encountered in the area shall have to be reported to the Board immediately.</p>
                                <%-- ML/SEIAA/MIN/EKH/P-41/2020/8/102 Dt. 22ndApril, 2021--%>
                                <p>
                                    10. The company shall comply with all the Terms & Conditions of the Environmental Clearance granted by the StateEnvironment Impact Assessment Authority, Meghalaya vide No.<asp:Label ID="lblapril" runat="server" Style="font-weight: bold;"></asp:Label>
                                    and implement the Environment protection measures and safeguards incorporated in the EIA/EMP.
                                </p>

                                <p>
                                    <span style="font-weight: bold; text-decoration: underline;">II. Specific Conditions:</span>
                                    <asp:Label ID="Label2" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                                <p>
                                    <span style="font-weight: bold; text-decoration: underline;">A. Prevention and Control of Water Pollution:</span>
                                    <asp:Label ID="Label3" runat="server" Style="font-weight: bold;"></asp:Label>
                                </p>
                                <p>The following measures should be taken up by the industry for prevention and control of water pollution:</p>
                                <p>1. Check dams/tailing dams should be provided wherever necessary to prevent the direct discharge of mine's effluent/runoff etc. into the natural water courses.</p>

                                <p>
                                    2. Dumping of overburden, mine spoils etc. should be properly made in identified and demarcated Sites. Such dumpingsites should be on impervious and stable ground to avoid percolation of contaminations into the water table and for
prevention of landslides.
                                </p>
                                <p>3. Proper planning should be made so that the dumps are to be done in steps for better stabilization and the dumpingsequence should be planned in such a way that plantation over the dumps can be done simultaneously with dumping.</p>
                                <p>4. Continuous compacting of the dumps should be done tó ensure its stability.</p>
                                <p>5. Facilities should be maintained for storing the top soil separately so that the same be utilised for afforestation/plantationover the dumps and excavated mines pits.</p>

                                <p><span style="font-weight: bold; text-decoration: underline;">B. Prevention and Control of Air & Noise Pollution:</span></p>
                                <p>
                                    1.
B. Prevention and Control of Air & Noise Pollution:
The Ambient Air Quality within the Plant premises and surrounding areas should be maintained within the NationalAmbient Air Quality Standards prescribed below:-
                                </p>
                                <div style="display: flex; justify-content: center; align-items: center;">
                                    <table border="1">
                                        <tr>
                                            <th>Sl. No.</th>
                                            <th>Pollutants</th>
                                            <th>Time Weighted Average</th>
                                            <th>Concentration in Ambient Air(Industrial, Residential, Rural Areas) µg/m³</th>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">1</td>
                                            <td rowspan="2">SO2</td>
                                            <td>Annual</td>
                                            <td>50</td>
                                        </tr>
                                        <tr>
                                            <td>Annual 24 hours</td>
                                            <td>80</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">2</td>
                                            <td rowspan="2">NO2</td>
                                            <td>Annual</td>
                                            <td>40</td>
                                        </tr>
                                        <tr>
                                            <td>Annual 24 hours</td>
                                            <td>80</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">3</td>
                                            <td rowspan="2">Particulate Matter, PM10</td>
                                            <td>Annual</td>
                                            <td>60</td>
                                        </tr>
                                        <tr>
                                            <td>Annual 24 hours</td>
                                            <td>100</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">4</td>
                                            <td rowspan="2">Particulate Matter, PM2.5</td>
                                            <td>Annual</td>
                                            <td>40</td>
                                        </tr>
                                        <tr>
                                            <td>Annual 24 hours</td>
                                            <td>60</td>
                                        </tr>
                                    </table>
                                </div>

                                <p>
                                    2. Fuel/air burning ratio of all the HEMM is to maintained at an optimum condition so as to reduce air pollution from the
exhaust emission of these machineries.
                                </p>
                                <p>
                                    3. Regular checking of the exhaust emission from HEMM should be conducted by using requisite instruments for the
purpose.
                                </p>
                                <p>
                                    4. If dry drilling is to be employed, appropriate dust collectors should be provided to control the concentration of
suspended particulate matters in the emission.
                                </p>
                                <p>
                                    5. Plantation along the haul roads to reduce dust retention in the air should be maintained.
                                </p>
                                <p>6. Proper maintenance, lubrication etc. of all moving machineries should be maintained and all engines should be providedwith high efficiency silencers.</p>
                                <p>
                                    7. Primary blasting methods should be chosen in such a way so as to have a minimum impact of noise and vibration on the
environment.
                                </p>
                                <p>
                                    8. Usage of hydraulic rock breaker for boulder breaking instead of conventional secondary blasting to minimize noise
pollution should be adopted as far as practicable.
                                </p>
                                <p>9. Adequate measures taken should be made to minimize the air blast so that the blast size is kept at the optimum for lessnoise.</p>

                                <p>10. The industry shall take adequate measures for control of noise from all sources so as to comply with the Standardsbelow:</p>

                                <div style="display: flex; justify-content: center; align-items: center;">
                                    <table border="1">
                                        <tr>
                                            <th colspan="2" style="text-align: center;">LIMIT in dB (A) LEQ</th>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center; font-weight: bold;">Day Time (6:00 AM - 9:00 PM)</td>
                                            <td style="text-align: center; font-weight: bold;">Night Time (9:00 PM - 6:00 AM)</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center;">75</td>
                                            <td style="text-align: center;">70</td>
                                        </tr>
                                    </table>
                                </div>
                                <p>A detailed Report of Compliance to all the Terms and Conditions stipulated in this Consent should be submitted alongwiththe application for grant of Consent to Operate before operation of the limestone quarry.</p>
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
                                1. The Chairman, SEIAA, Meghalaya, Silviculture Building, Forests & Environment Department, Shillong forfavour of information.
                            </p>

                            <p>
                                2. The Director of Mineral Resources, Meghalaya, Shillong for information and necessary action.
                            </p>
                            <p>3.The Divisional Forest Officer, Khasi Hills & Ri-Bhoi (T) Division, Shillong for favour of information andnecessary action.</p>
                            <%-- M/S RI KALENG LIMESTONE MINE,--%>

                            <p>
                                4.<asp:Label ID="lblshoba" runat="server" Style="font-weight: bold;"></asp:Label>
                                C/o Shri. Arbis Tangdhara, Sohbar Village, East Khasi Hills
District, Meghalaya for favour of information and necessary action.
                            </p>
                            <p>5. Guard File ONLINE-СТО-2021.</p>
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
