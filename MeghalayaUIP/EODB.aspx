<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="EODB.aspx.cs" Inherits="MeghalayaUIP.EODB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        p.texttop111.wow.fadeInUp.animated.animated {
    width: 24%;
    position: absolute;
    top: 73px;
    color: #000;
    left: 32px;
    text-align: left;
}
        p.texttop211.wow.fadeInUp.animated.animated {
    width: 24%;
    position: absolute;
    top: 31px;
    color: #000;
    left: 31.5%;
    text-align: left;
}
        p.texttop311.wow.fadeInUp.animated.animated {
   width: 24%;
    position: absolute;
    top: -14px;
    color: #000;
    right: 17.5%;
    text-align: left;
}
        p.texttop {
            position: absolute;
    top: 10px;
    left: 90px;
    color: #fff;
        }
        h5, .h5, p {
    font-size: 18px;
}
        section.innerpages h4 {
    font-family: 'Ubuntu', sans-serif !important;
    color: #4577c1 !important;
    padding-top: 15px;
    font-size: 1.3rem !important;
    font-weight: 500;
}
        p.texttop114.wow.fadeInUp.animated.animated {
    text-align: left;
    position: absolute;
    top: 58%;
    left: 13%;
    font-size: 33px;
    color: #fff;
    font-weight: 900;
}
        
        p.texttop214.wow.fadeInUp.animated.animated {
    text-align: center;
    position: absolute;
    top: 48%;
    left: 40%;
    font-size: 33px;
    color: #fff;
    font-weight: 900;
}
        p.texttop314.wow.fadeInUp.animated.animated {
    text-align: right;
    position: absolute;
    top: 36%;
    right: 21%;
    font-size: 33px;
    color: #fff;
    font-weight: 900;
}
       p.texttop114.wow.fadeInUp.animated.animated:hover,p.texttop214.wow.fadeInUp.animated.animated:hover,p.texttop314.wow.fadeInUp.animated.animated:hover, p.texttop111.wow.fadeInUp.animated.animated:hover, p.texttop211.wow.fadeInUp.animated.animated:hover, p.texttop311.wow.fadeInUp.animated.animated:hover{
            transition: transform .6s;
    transform: scale(1.2);
    font-weight:600;

        }
    </style>
    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>

                            <li class="breadcrumb-item active" aria-current="page">Why Meghalaya</li>
                            <li class="breadcrumb-item active" aria-current="page">EODB</li>
                        </ol>
                    </nav>

                    <%--<h3>About EODB</h3>
                    
					<img src="assets/assetsbeta/images/eodb_1.jpg" width="100%" class="rounded">--%>
                    <h3>Transforming Meghalaya’s Business Landscape :</h3>
                    <p>
                        The Government of India is committed to fostering a business-friendly environment across the country to attract investments, generate employment opportunities, and drive economic growth. 
                    </p>
                    <p>Concerted efforts are taken to simplify, rationalize, and digitize Government to Business (G2B) and Government to Citizen (G2C) interfaces, creating a seamless ecosystem facilitating Ease of Doing Business for investors and Ease of Living for citizens. By streamlining processes, reducing bureaucracy, and leveraging technology, the Government aims to provide a conducive environment stimulating economic activity, employment generation, and overall development in Meghalaya and other parts of the nation.</p>
                    <h3>Key Initiatives :</h3>
                    <p>The State of Meghalaya has implemented key initiatives to enhance its business environment, focusing on minimizing regulatory compliance and decriminalizing minor offenses. </p>

                    <%--<p><b>a. Ease of Doing Business Framework (DPIIT): </b></p>
                    <ul>
                        <li>1.	Minimize regulatory compliance.</li>
                        <li>2.	Decriminalize minor offenses.</li>
                        <li>3.	State Governments implement annual reforms</li>
                    </ul>--%>
                    <h4>Ease of Doing Business Framework (DPIIT)</h4>
                    <section class="project-section case-page-3 eodb1 p-0 pt-2 mb-5">
                        <div class="large-container">
                            
                            <div class="row">

                                <div class="col-lg-4 col-md-6 col-sm-12 project-block">
                                    <div class="setup wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <p>
                                            <img src="assets/assetsnew/images/info/icon31.png" />
                                        </p>
                                        <p class="texttop11" style="color:#fff;">Minimize regulatory compliance.</p>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-sm-12 project-block">
                                    <div class="setup wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <p>
                                            <img src="assets/assetsnew/images/info/icon32.png" />
                                        </p>
                                        <p class="texttop11" style="color:#fff;">
                                            Decriminalize minor offenses.
                                        </p>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-sm-12 project-block">
                                    <div class="setup wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <p>
                                            <img src="assets/assetsnew/images/info/icon33.png" />
                                        </p>
                                        <p class="texttop11" style="color:#fff;">State Governments implement annual reforms.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                    <%--<p><b>b. Meghalaya's EoDB Performance: </b></p>
                    <ul>
                        <li>1.	Pre-2019: Among the lowest in Ease of Doing Business rankings.</li>
                        <li>2.	2020: Recognized as an “Emerging Business Ecosystem” by DPIIT.</li>
                        <li>3.	2022: 211 reforms successfully implemented by the State.</li>
                    </ul>--%>
                     <h4>Meghalaya's Transformation in BRAP</h4>
                    <%--<section class="project-section case-page-3 eodb2 p-0 pt-2 mb-5">
                        <div class="large-container">
                           
                            <div class="row">
                                <div class="col-lg-12 col-md-6 col-sm-12 project-block">
                                    <div class="setup">
                                        <h7 class="middlebiox wow fadeInUp animated" data-wow-delay="1000ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 100ms; animation-name: fadeInDown;"">
                                            Meghalaya's EoDB<br />
                                            Performance</h7>
                                        <p>
                                            <img src="assets/assetsnew/images/info/eodbp.png" />
                                        </p>
                                        <p class="texttop1 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;"">
                                            <span style="font-size: 24px;font-weight:900">Pre-2019</span><br />
                                                Among the lowest in Ease of<br />
                                                Doing Business rankings.
                                        </p>
                                        <p class="texttop2 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;"">
                                            <span style="font-size: 24px;font-weight:900">Pre-2020</span><br />Recognized as an “Emerging<br />
                                                Business Ecosystem” by DPIIT.
                                        </p>
                                        <p class="texttop3 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;"">
                                            <span style="font-size: 24px;font-weight:900">Pre-2022</span><br />211 reforms successfully
                                            <br />
                                                implemented by the State.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>--%>
                    <section class="project-section case-page-3 eodb2 p-0 pt-2 mb-5">
                        <div class="large-container">
                           
                            <div class="row">
                                <div class="col-lg-12 col-md-6 col-sm-12 project-block" style="
    text-align: center;
">
                                    <div class="setup">
                                        
                                            <img src="assets/assetsnew/images/info/steps123.png" />
                                      
                                        <p class="texttop111 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;"">
                                            
                                                Among the lowest in Ease of<br />Doing Business rankings
                                        </p>
                                        <p class="texttop211 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;"">
                                            Recognized as an “Emerging<br /> Business Ecosystem” by DPIIT
                                        </p>
                                        <p class="texttop311 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;"">
                                            211 reforms successfully <br />implemented by the State
                                        </p>
                                    </div>
                                    <div class="setup123">
                                      
                                        <p class="texttop114 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;"">
                                            
                                                2019
                                        </p>
                                        <p class="texttop214 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;"">
                                            2020
                                        </p>
                                        <p class="texttop314 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;"">
                                            2022
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>

                   <%-- <p><b>c. Proactive Steps in Meghalaya: </b></p>
                    <ul>
                        <li>1.	Digitization of records.</li>
                        <li>2.	Minimizing compliance burdens.</li>
                        <li>3.	Identified 304 compliances (280 for businesses, 24 for citizens).</li>
                        <li>4.	Reduced 167 compliances (143 for businesses, 24 for citizens).</li>
                    </ul>--%>
                    <h4>Proactive Steps in Meghalaya</h4>
                     <section class="project-section case-page-3 eodb41 p-0 pt-2 mb-5">
                        <div class="large-container">
                            
                            <div class="row">
                                <img src="assets/assetsnew/images/info/psm.png" />
                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="imgtexxt1 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; 
animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <p class="texteodb4 1">Digitization of records</p>
                                    </div>
                                    </div>
                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="imgtexxt2 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        
                                        <p class="texteodb4 2">Minimizing compliance<br />burdens</p>
                                    </div>
                                    </div>
                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="imgtexxt3 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        
                                        <p class="texteodb4 3">Identified<br />304 compliances<br />(280 Businesses, 24 Citizens)</p>
                                    </div>
                                    </div>
                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="imgtexxt4 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        
                                        <p class="texteodb4 4">Reduced 167<br />compliances<br />(143 Businesses, 24 Citizens)</p>
                                    </div>
                                    </div>

                                </div>
                            </div>
                        </section>
                   <%-- <section class="project-section case-page-3 eodb4 p-0 pt-2 mb-5">
                        <div class="large-container">
                            
                            <div class="row">

                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="imgtexxt wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <p>
                                            <img src="assets/assetsnew/images/info/icon21.png" />
                                        </p>
                                        <p class="texteodb4 1">Digitization of records</p>
                                    </div>
                                    </div>
                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="imgtexxt wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <p><img src="assets/assetsnew/images/info/icon22.png" /></p>
                                        <p class="texteodb4 2">Minimizing compliance<br />burdens</p>
                                    </div>
                                    </div>
                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="imgtexxt wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <p><img src="assets/assetsnew/images/info/icon23.png" /></p>
                                        <p class="texteodb4 3">Identified<br />304 compliances<br />(280 Businesses, 24 Citizens)</p>
                                    </div>
                                    </div>
                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="imgtexxt wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <p><img src="assets/assetsnew/images/info/icon24.png" /></p>
                                        <p class="texteodb4 4">Reduced 167<br />compliances<br />(143 Businesses, 24 Citizens)</p>
                                    </div>
                                    </div>

                                </div>
                            </div>
                        </section>--%>
                    <%--<p><b>d. Services Offered :</b></p>
                    <ul>
                        <li>1.	132 End-to-end online services.</li>
                        <li>2.	158 Services under the Meghalaya Right to Public Services Act, 2020.</li>
                        <li>3.	9 Auto-renewal services.</li>
                    </ul>--%>

                    <%--<p><b>e. Meghalaya-Centralized Inspection System Goals :</b></p>
                    <ul>
                        <li>1.	Boost investor confidence.</li>
                        <li>2.	Foster a business-friendly climate.</li>
                        <li>3.	Enhance the ease of living through timely, digitalized services.</li>
                    </ul>--%>
                    <h4>Services Offered</h4>
                    <section class="project-section case-page-3 eodb1 p-0 pt-2 mb-5">
                        <div class="large-container">
                            
                            <div class="row d-block">

                                <div class="col-lg-6 col-md-6 col-sm-12 project-block">
                                    <div class="setup wow fadeInUp animated animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <p>
                                           <img src="assets/assetsnew/images/info/icon41.png">
                                        </p>
                                        <p class="texttop" style="
    margin-top: 8px;
">132 End-to-end online services</p>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-12 project-block">
                                    <div class="setup wow fadeInUp animated animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <p>
                                            <img src="assets/assetsnew/images/info/icon42.png">
                                        </p>
                                        <p class="texttop">
                                            158 Services under the Meghalaya Right<br>
                                                to Public Services Act, 2020.
                                        </p>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-12 project-block">
                                    <div class="setup wow fadeInUp animated animated" data-wow-delay="00ms" data-wow-duration="1500ms"
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <p>
                                            <img src="assets/assetsnew/images/info/icon43.png">
                                        </p>
                                        <p class="texttop" style="
    margin-top: 9px;
">9 Auto-renewal services.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>

                    <h4>Meghalaya-Centralized Inspection System Goals</h4>

                    <section class="project-section case-page-3 eodb p-0 pt-2 mb-5">
                        <div class="large-container">
                            <div class="row">
                                <img src="assets/assetsnew/images/info/cis.jpg" />
                                <div class="cis1 1 wow fadeInUp animated animated" data-wow-delay="00ms" data-wow-duration="1500ms"
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                    Streamline the inspection<br /> procedures
                                </div>
                                <div class="cis1 2 wow fadeInUp animated animated" data-wow-delay="00ms" data-wow-duration="1500ms"
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInDown;">
                                    Ensure timely and synchronized<br /> inspections between various departments
                                </div>
                                <div class="cis1 3 wow fadeInUp animated animated" data-wow-delay="00ms" data-wow-duration="1500ms"
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                    Maintain transparency in inspections,<br /> its frequency and reduce duplications
                                </div>
                                <div class="cis1 4 wow fadeInUp animated animated" data-wow-delay="00ms" data-wow-duration="1500ms"
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInDown;">
                                    Improve cooperation and coordination<br /> between inspection authorities
                                </div>
                                <div class="cis1 5 wow fadeInUp animated animated" data-wow-delay="00ms" data-wow-duration="1500ms"
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                    Enable Unified review of information<br /> about past inspections, schedules of<br /> controls, registries of controls, and <br />compliance with Inspection Laws
                                </div>
                                <div class="cis1 6 wow fadeInUp animated animated" data-wow-delay="00ms" data-wow-duration="1500ms"
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInDown;">
                                    To eliminate the regulatory uncertainty<br /> that generates an inspection
                                </div>
                            </div>
                            </div>
                        </section>
                    <%--<section class="project-section case-page-3 eodb p-0 pt-2 mb-5">
                        <div class="large-container">
                            <div class="row">
                                
                                <div class="col-lg-1 col-md-6 col-sm-12 project-block"></div>
                                <div class="col-lg-5 col-md-6 col-sm-12 project-block" style="text-align: end;">
                                    <div class="project-block-one wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                       <div class="inner-box1">
                                            <div class="count-number1" style="margin-right: 9%;margin-top: -12px;">01</div>
                                            <div class="lower-content1" style="display: flex;flex-direction: row;flex-wrap: nowrap;align-content: space-around;justify-content: center;align-items: center;margin-right: -30px;margin-top: 4px;">

                                                <h5>Streamline the inspection procedures.</h5>

                                                <h5>
                                                    <img src="assets/assetsnew/images/info/icon1.jpg" style="width: 70%; margin-top: 5px;"></h5>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-5 col-md-6 col-sm-12 project-block">
                                    <div class="project-block-one wow fadeInUp animated animated"
                                        data-wow-delay="200ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 200ms; animation-name: fadeInUp; margin-top: 84px;">
                                        <div class="inner-box1">
                                            <div class="count-number1" style="margin-left: 10%;">02</div>
                                            <div class="lower-content1" style="display: flex; flex-wrap: nowrap; flex-direction: row; align-content: center; justify-content: center; align-items: center; margin-left: 10px;margin-top: 17px;">

                                                <h5>
                                                    <img src="assets/assetsnew/images/info/icon2.jpg" style="width: 65%;"></h5>

                                                <h5>Ensure timely and synchronized inspections between various departments</h5>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-1 col-md-6 col-sm-12 project-block"></div>
                                <div class="col-lg-12 col-md-6 col-sm-12 project-block">
                                    <div class="" data-wow-delay="400ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 400ms; animation-name: fadeInUp;">
                                        <div class="inner-box1">
                                            <div class="count-number1" style="position: absolute;right: 53.4%;bottom: -62px;margin-bottom: 0px;">
                                                03
                                            </div>
                                            <div class="lower-content1" style="text-align: center;margin-top: -44px;margin-right: 91px;">
                                                <h5>
                                                    <img src="assets/assetsnew/images/info/icon3.jpg" style="width: 13%;"></h5>
                                                <h5 style="width: 32%; margin-top: -82px; margin-left: 6%;">Maintain transparency in inspections, its frequency and reduce duplications</h5>


                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </section>--%>


                </div>
            </div>

        </div>
    </section>
</asp:Content>
