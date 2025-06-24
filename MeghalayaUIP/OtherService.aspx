<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="OtherService.aspx.cs" Inherits="MeghalayaUIP.OtherService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       

        table#servicestable th {
            vertical-align: middle;
        }
    </style>
    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                            <li class="breadcrumb-item">Service</li>
                            <li class="breadcrumb-item active" aria-current="page">Other Service</li>
                        </ol>
                    </nav>

                    <div>
                        <table>
                            <div class="table-responsive">
                                <div id="servicestable_wrapper" class="dataTables_wrapper dt-bootstrap5 no-footer">

                                    <div class="row dt-row">
                                        <div class="col-sm-12">
                                            <table id="servicestable" class="table table-striped table-hover dataTable no-footer table-responsive" aria-describedby="servicestable_info">
                                                <thead style="background-color: #247BA0; color: white;">
                                                    <tr>
                                                        <th class="sorting" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-label="Service Name: activate to sort column ascending" style="width: 236px;">Service Name</th>
                                                        <th class="sorting sorting_asc" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Department: activate to sort column descending" style="width: 155px;">Department</th>
                                                        <th class="sorting" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-label="Standard Operating Procedure: activate to sort column ascending" style="width: 114px;">Standard Operating Procedure</th>
                                                        <th class="sorting" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-label="Rules and Regulations: activate to sort column ascending" style="width: 111px;">Rules and Regulations</th>
                                                        <th class="sorting" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-label="Prerequisites: activate to sort column ascending" style="width: 107px;">Prerequisites</th>
                                                        <th class="sorting" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-label="Application Form Format: activate to sort column ascending" style="width: 113px;">Application Form Format</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr class="odd">
                                                        <td>Approval by Single Window Agency</td>
                                                        <td class="sorting_1">Department of Industries &amp; Commerce Online Services</td>
                                                        <td></td>
                                                        <td></td>

                                                        <td>

                                                            <a href="#">View Enclosures</a>


                                                        </td>
                                                        <td></td>

                                                    </tr>
                                                    <tr class="even">
                                                        <td>Approval for Supply under Supplementary Nutrition Programme (SNP) by SHG</td>
                                                        <td class="sorting_1">Department of Social Welfare</td>
                                                        <td></td>
                                                        <td></td>
                                                        <td><a href="assets/Prequite/EnclosuresFoodstuffSHG1.pdf" target="_blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/ApplicationformforSNPSupplybySHG.pdf" target="blank">Download Form</a></td>

                                                    </tr>
                                                    <tr class="odd">
                                                        <td>Registration of NGO as Service Providers under Section 10-1 of the Protection of Women from
                          Domestic Violence Act 2005</td>
                                                        <td class="sorting_1">Department of Social Welfare</td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td><a href="assets/Application/ApplicationformServiceProviderunder2005.pdf" target="blank">Download Form</a>
                                                        </td>
                                                    </tr>
                                                    <tr class="even">
                                                        <td>Registration/Recognition for Organization/NGO under the Juvenile Act 2006</td>
                                                        <td class="sorting_1">Department of Social Welfare</td>
                                                        <td></td>
                                                        <td></td>
                                                        <td><a href="assets/Prequite/EnclosuresJuvenileJustice.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/ApplicationFormJuvenileJustice.pdf" target="blank">Download Form</a> </td>
                                                    </tr>
                                                   <%-- <tr class="odd">
                                                        <td>Income Certificate</td>
                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                        <td><a href="assets/StandedOperation/ProcessFlowic.pdf" target="blank">View SoP</a></td>
                                                        <td></td>
                                                        <td><a href="assets/Prequite/ListofEnclosuresic.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/Application_Formic.pdf" target="blank">Download Form</a> </td>
                                                    </tr>
                                                    <tr class="even">
                                                        <td>Marriage Certificate</td>
                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                        <td><a href="assets/StandedOperation/ProcessFlowmc.pdf" target="blank">View SoP</a></td>
                                                        <td></td>
                                                        <td><a href="assets/Prequite/ListofEnclosuresmc.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/Application_Formmc.pdf" target="blank">Download Form</a> </td>
                                                    </tr>
                                                    <tr class="odd">
                                                        <td>Permanent Residential Certificate</td>
                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                        <td><a href="assets/StandedOperation/ProcessFlowprc.pdf" target="blank">View SoP</a></td>
                                                        <td></td>
                                                        <td><a href="assets/Prequite/ListofEnclosuresprc.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/Application_Formprc.pdf" target="blank">Download Form</a> </td>
                                                    </tr>
                                                    <tr class="even">
                                                        <td>Residential Certificate</td>
                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                        <td><a href="assets/StandedOperation/UpdatedProcessrc.pdf" target="blank">View SoP</a></td>
                                                        <td></td>
                                                        <td><a href="assets/Prequite/ListofEnclsosuresrc.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/Application_Formrc.pdf" target="blank">Download Form</a> </td>
                                                    </tr>
                                                    <tr class="odd">
                                                        <td>Schedule Tribe Certificate</td>
                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                        <td><a href="assets/StandedOperation/ProcessFlowst.pdf" target="blank">View SoP</a></td>
                                                        <td></td>
                                                        <td><a href="assets/Prequite/ListofEnclosuresst.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/Application_Formst.pdf" target="blank">Download Form</a> </td>
                                                    </tr>
                                                    <tr class="even">
                                                        <td>Ration Card - Claim/Correction/Deletion/Change/Tranfer</td>
                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                        <td><a href="assets/StandedOperation/sop_rationcard.pdf" target="blank">View SoP</a></td>
                                                        <td><a href="assets/Rules/rule_rationcard.pdf" target="blank">View Document</a></td>
                                                        <td><a href="assets/Prequite/enclo_rationcard.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/form_rationcard.pdf" target="blank">Download Form</a> </td>


                                                    </tr>
                                                    <tr class="odd">
                                                        <td>Birth Certificate</td>
                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                        <td><a href="assets/StandedOperation/sop_Birth Certificate.pdf" target="blank">View SoP</a></td>
                                                        <td><a href="assets/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>
                                                        <td><a href="assets/Prequite/enclo_Birth Certificate.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/Application_form.pdf" target="blank">Download Form</a> </td>
                                                    </tr>
                                                    <tr class="even">
                                                        <td>Death Certificate</td>
                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                        <td><a href="assets/StandedOperation/ProcessFlow.pdf" target="blank">View SoP</a></td>
                                                        <td><a href="assets/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>
                                                        <td><a href="assets/Prequite/ListofEnclosures.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/Application_Formdc.pdf" target="blank">Download Form</a> </td>
                                                    </tr>
                                                    <tr class="odd">
                                                        <td>Registration for Health Card</td>
                                                        <td class="sorting_1">Health &amp; Family Welfare Departmentt</td>
                                                        <td><a href="assets/StandedOperation/sop_HealthCard.pdf" target="blank">Process Flow</a></td>
                                                        <td><a href="assets/Rules/rule_HealthCard.pdf" target="blank">View Document</a></td>
                                                        <td><a href="assets/Prequite/enclo_HealthCard.pdf" target="blank">Enclosures &amp; Fees</a></td>
                                                        <td><a href="assets/Application/form_HealthCard.pdf" target="blank">Registration Form</a> </td>
                                                    </tr>--%>
                                                    <tr class="even">
                                                        <td>Printing Request from Printing &amp; Stationery Department</td>
                                                        <td class="sorting_1">Printing &amp; Stationery Department</td>
                                                        <td></td>
                                                        <td></td>
                                                        <td><a href="assets/Prequite/enclosureforPrinting.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/ApplicationFormforPrinting.pdf" target="blank">Download Form</a> </td>

                                                    </tr>
                                                    <tr class="odd">
                                                        <td>Demand Request for issue of Stationery Articles or Schedule Forms or Service Books from
                          Printing and Stationery Department</td>
                                                        <td class="sorting_1">Printing &amp; Stationery Department</td>
                                                        <td></td>
                                                        <td></td>
                                                        <td><a href="assets/Prequite/enclosure89.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/form89.pdf" target="blank">Download Form</a> </td>

                                                    </tr>
                                                    <tr class="even">
                                                        <td>Annual subscription for complete Gazette with extraordinary from Printing and Stationery
                          Department</td>
                                                        <td class="sorting_1">Printing &amp; Stationery Department</td>
                                                        <td></td>
                                                        <td></td>
                                                        <td><a href="assets/Prequite/enclosure90.pdf" target="blank">View Enclosures</a></td>
                                                        <td><a href="assets/Application/ApplicationFormforGazettesubscription.pdf" target="blank">Download Form</a>
                                                        </td>

                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>

                                    </div>
                                    <div class="row">
                                    </div>

                                </div>

                            </div>

                        </table>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
