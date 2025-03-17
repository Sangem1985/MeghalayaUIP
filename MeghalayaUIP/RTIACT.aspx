<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="RTIACT.aspx.cs" Inherits="MeghalayaUIP.RTIACT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                            <li class="breadcrumb-item">Resources</li>
                            <li class="breadcrumb-item active" aria-current="page">Rti Act</li>
                        </ol>
                    </nav>

                    <h3>Meghalaya Investment Promotion Agency (MIPA)-RTI ACT</h3>
                    <ul>
                        <li><i class="fi fi-br-arrow-up-right-from-square"></i><a href="#" onclick="window.open('PdfFile.ashx?filePath=<%=MIIPP2024%>', '_blank'); return false;">MIIPP, 2024</a></li>
                        <li><i class="fi fi-br-arrow-up-right-from-square"></i><a href="#" onclick="window.open('PdfFile.ashx?filePath=<%=MSIPFACT2024%>', '_blank'); return false;">MSIPF Act 2024</a></li>
                        <li><i class="fi fi-br-arrow-up-right-from-square"></i><a href="#" onclick="window.open('PdfFile.ashx?filePath=<%=AppointmentShriPBakshiIASCEO%>', '_blank'); return false;">Appointment of Shri P. Bakshi, IAS Commissioner & Secretary to the Govt. of Meghalaya as the Additional Chief Executive Officer, Meghalaya Investment Promotion Agency (MIPA)</a></li>
                        <li><i class="fi fi-br-arrow-up-right-from-square"></i><a href="#" onclick="window.open('PdfFile.ashx?filePath=<%=AppointmentShriRChitturiIASCEO%>', '_blank'); return false;">Appointment of Shri R. Chitturi, IAS Joint Secretary to the Govt. of Meghalaya as the Joint Chief Executive Officer, Meghalaya Investment Promotion Agency (MIPA)</a></li>
                        <li><i class="fi fi-br-arrow-up-right-from-square"></i><a href="#" onclick="window.open('PdfFile.ashx?filePath=<%=AppointmentDrVijayKumarCEO%>', '_blank'); return false;">Appointment of Dr. Vijay Kumar D, IAS Commissioner & Secretary to the Govt. of Meghalaya as the Chief Executive Officer of Meghalaya Investment Promotion Agency (MIPA)</a></li>
                        <li><i class="fi fi-br-arrow-up-right-from-square"></i><a href="#" onclick="window.open('PdfFile.ashx?filePath=<%=AppointmentShriKHynniewtaCAO%>', '_blank'); return false;">Appointment of Shri K. Hynniewta, Officer on Special Duty & ex-officio Joint Secretary Planning, Investment Promotion & Sustainable Development Department as the Chief Administrative Officer of Meghalaya Investment Promotion Agency (MIPA)</a></li>
                        <li><i class="fi fi-br-arrow-up-right-from-square"></i><a href="#" onclick="window.open('PdfFile.ashx?filePath=<%=ConstitutionDistrictInvestmentCommittee%>', '_blank'); return false;">Constitution of the District Investment Committee for Investment Promotion and Facilitation</li>
                        <li><i class="fi fi-br-arrow-up-right-from-square"></i><a href="#" onclick="window.open('PdfFile.ashx?filePath=<%=ConstitutionGoverningCouncil%>', '_blank'); return false;">Constitution of the Governing Council for Investment Promotion and Facilitation</a></li>
                        <li><i class="fi fi-br-arrow-up-right-from-square"></i><a href="#" onclick="window.open('PdfFile.ashx?filePath=<%=ConstitutionHighPoweredCommittee%>', '_blank'); return false;">Constitution of the High-Powered Committee for Investment Promotion and Facilitation</a></li>
                        <li><i class="fi fi-br-arrow-up-right-from-square"></i><a href="#" onclick="window.open('PdfFile.ashx?filePath=<%=ConstitutionStateInvestmentCommittee%>', '_blank'); return false;">Constitution of the State Investment Committee for Investment Promotion and Facilitation</a></li>

                    </ul>

                </div>
            </div>
        </div>
    </section>
</asp:Content>
