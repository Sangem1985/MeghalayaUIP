<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MeghalayaUIP.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        section#marquee {
            padding: 0px 0;
            position: relative;
            background: linear-gradient(to bottom, #0f7f8f 0%, #185784 100%);
            z-index: 9;
            color: #fff;
        }

            section#marquee a {
                color: #fff;
                font-weight: 600;
                font-size: 17px !important;
            }
    </style>
    <!--chatbot-->
    <style>
        /* simple styling */
        #chatWindow {
            display: none;
            position: fixed;
            bottom: 80px;
            right: 20px;
            width: 320px;
            height: 450px;
            border: 1px solid #ccc;
            background: #fff;
            overflow: auto;
            padding: 10px;
            box-shadow: 0 6px 18px rgba(0,0,0,0.12);
        }

        #chatContent button {
            width: 100%;
            text-align: left;
            margin: 6px 0;
            padding: 8px;
            border-radius: 6px;
        }

        .small-btn {
            width: auto;
            display: inline-block;
            margin: 6px 6px 0 0;
            padding: 6px 8px;
        }

        .spinner {
            text-align: center;
            padding: 18px 0;
            font-size: 14px;
            color: #666;
        }
    </style>
    <!--Banner Video-->
    <section id="marquee" runat="server" visible="false">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <marquee scrolldelay="50" scrollamount="5" behavior="alternate" direction="left" width="100%" onmouseover="this.stop();" onmouseout="this.start();" title="Scrolling the Latest News">
                        <i class="icofont-ui-next"></i><a target="_blank" href="BusinessRegulation.aspx" style="text-transform: initial !important;"><strong>Submit feedback on Draft Meghalaya Film Tourism Policy, 2025 to content.hellomeghalaya@gmail.com. Read Policy here.</strong></a>&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight: 100 !important;"></span>
                        <!-- <i class="icofont-ui-next"></i> <a target="_blank" href="#"> <strong> Implementation of AH Revised Rates</strong></a>&nbsp;&nbsp;&nbsp;&nbsp;<br> -->
                    </marquee>
                </div>
            </div>
        </div>
    </section>

    <video autoplay="" muted="" loop="" id="myVideo" style="top: -80px; opacity: 1; width: 100%; margin-top: -275px;">
        <source src="assets/assetsnew/images/main-slider/IM_bgm1.mp4" type="video/mp4" style="height: 100%;" />
    </video>
    <section class="slider-style-three centred" style="display: none;">
        <div class="main-slider-carousel-2 owl-carousel owl-theme">
            <div class="slide">
                <div class="container">
                    <div class="content-box">
                        <div class="top-text">&nbsp;</div>
                        <h1 class="head1">&nbsp;</h1>
                        <h3>&nbsp;</h3>


                    </div>
                </div>
            </div>

        </div>
    </section>

    <section class="about-us-section1">
        <div class="container">
            <div class="row">
                <div class="col col-xs-12 text-center bgview">

                    <h3 class="wow zoomOut animated" data-wow-delay="100ms"
                        data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 100ms; animation-name: fadeInRight;">Welcome to Invest Meghalaya</h3>
                    <p>
                        Empowering Investors at every stage of their journey.<br>
                        Set up your business in Meghalaya with, one of the fastest growing business destinations in North-East India.
                   
                    </p>
                </div>
            </div>

        </div>
    </section>
    <section class="about-us-section2">
        <div class="container">
            <div class="row">
                <div class="col col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center bgview1">

                    <div class="text" style="margin-top: 21px;">
                        <p class="wow zoomOut animated" data-wow-delay="100ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 100ms; animation-name: fadeInDown;">
                            <span class="colorblue">Apply for Incentives</span> for your business under <span class="colorblue">Uttar Poorva Transformative Industrialization Scheme (UNNATI), 2024 and Meghalaya Industrial and  Investment Promotion Policy (MIIPP) 2024</span> to make your business  more profitable.
                       
                        </p>

                    </div>
                </div>
            </div>

        </div>
    </section>
    <section class="counter-style-two" style="margin-top: 26px;">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-md-12 col-sm-12 content-column">
                    <div class="content-box wow fadeInLeft animated" data-wow-delay="500ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 100ms; animation-name: fadeInLeft;">
                        <div class="top-text" style="font-size: 26px; text-transform: capitalize; font-weight: 600; color: #4577c1 !important;">Empowering Businesses, Empowering you..</div>
                        <%-- <h1>UNNATI 2024</h1>
                        <h1>MIIPP 2024</h1>--%>
                        <%--<img src="assets/assetsnew/images/boult.gif" style="margin-left: -60px;">--%>
                        <div class="col-md-12" style="margin-left: -60px; margin-top: 25px;">
                            <div class="col-md-12" id="modelinghover">
                                <a data-toggle="modal" data-target=".bd-example-modal-lg">
                                    <img src="assets/assetsnew/images/MIIPP.gif" /></a>
                            </div>
                            <div class="col-md-12" id="modelinghover1">
                                <a data-toggle="modal" data-target=".exampleModalCenter">
                                    <img src="assets/assetsnew/images/UNNATI.gif" /></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-12 col-sm-12 inner-column">
                    <div class="inner-box">
                        <div class="bold-text" style="font-size: 26px; text-transform: capitalize; font-weight: 600;">Invest, Innovate and Create in Meghalaya</div>
                        <div class="counter-outer">
                            <div class="counter-block-one wow zoomIn animated" data-wow-delay="500ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 500ms; animation-name: zoomIn;">
                                <div class="text">Investments Opportunity</div>
                                <div class="count-outer count-box counted">
                                    <span class="count-text" data-speed="1500" data-stop="20">$1</span><span class="symble">bn</span>
                                </div>
                            </div>
                            <div class="counter-block-one wow zoomIn animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: zoomIn;">
                                <div class="text">Economy</div>
                                <div class="count-outer count-box counted">
                                    <span class="count-text" data-speed="1500" data-stop="10">$10</span><span class="symble">bn</span>
                                </div>
                            </div>
                            <div class="counter-block-one wow zoomIn animated" data-wow-delay="500ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 500ms; animation-name: zoomIn;">
                                <div class="text">Employment Opportunities</div>
                                <div class="count-outer count-box counted">
                                    <span class="count-text" data-speed="1500" data-stop="99">5</span><span class="symble">Lc</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="testimonial-style-five centred overall1">
        <div class="container">
            <div class="owl-carousel">



                <div class="owl-item active wow zoomIn animated" data-wow-delay="500ms" data-wow-duration="1500ms" style="width: 370px; margin-right: 30px; visibility: visible; animation-duration: 1500ms; animation-delay: 500ms; animation-name: zoomIn;">
                    <div class="testimonial-content">
                        <div class="inner-box">
                            <div class="author-info">
                                <figure class="author-thumb"><i class="fi fi-tr-box-alt"></i></figure>
                                <h5>INCENTIVE PACKAGE</h5>
                                <span class="designation">Click here to know about incentive package based on your Investment</span>
                            </div>

                            <div class="text">
                                <button class="button-box">
                                    <%-- <a href="Documents/Incentive Package Demo 027082024.pdf" target="_blank" style="color: #164976">Click Here !</a>--%>
                                    <a href="#" onclick="window.open('PdfFile.ashx?filePath=<%= IncentivePackageDemo027082024 %>', '_blank'); return false;">Click Here !
    </a>
                                </button>

                            </div>

                        </div>

                    </div>
                </div>

                <div class="owl-item active wow fadeInUp animated" data-wow-delay="500ms" data-wow-duration="1500ms" style="width: 370px; margin-right: 30px; visibility: visible; animation-duration: 1500ms; animation-delay: 1000ms; animation-name: fadeInUp;">
                    <div class="testimonial-content">
                        <div class="inner-box">
                            <div class="author-info">
                                <figure class="author-thumb"><i class="fi fi-tr-coin-up-arrow"></i></figure>
                                <h5>INTENT TO INVEST</h5>
                                <span class="designation">Want to Invest? Fill a simple
                                
                                    <b>Intent to
                                Invest Form</b> and we
                              will get in touch.</span>
                            </div>
                            <div class="text">
                                <button class="button-box"><a href="IntentInvest.aspx" style="color: #164976">Click Here !</a></button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="owl-item active wow zoomIn animated" data-wow-delay="500ms" data-wow-duration="1500ms" style="width: 370px; margin-right: 30px; visibility: visible; animation-duration: 1500ms; animation-delay: 500ms; animation-name: zoomIn;">
                    <div class="testimonial-content">
                        <div class="inner-box">
                            <div class="author-info">
                                <figure class="author-thumb"><i class="fi fi-tr-clipboard-list"></i></figure>
                                <h5>REGISTER</h5>
                                <span class="designation">Register your business to claim Incentives.<br>
                                    Fill a simple <b>Registration Form</b>.</span>
                            </div>

                            <div class="text">
                                <button class="button-box"><a href="login.aspx" style="color: #164976">Click Here !</a></button>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </section>

    <section class="about-section-two1 2 easy active">
        <div class="container">
            <div class="row">
                <p class="pftext">Easy Process to Register your Business and Claim Incentives</p>
                <div class="col-md-12 col-lg-12 col-xl-12 col-sm-12 d-flex mb-3 mt-5 text-center easyprocess wow zoomIn animated" data-wow-delay="500ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 500ms; animation-name: zoomIn;">

                    <img src="assets/assetsnew/images/easy/rightleft.jpg" alt="images" class="imgleft" />
                    <img src="assets/assetsnew/images/easy/rightleft.jpg" alt="images" class="imgright" />
                    <div class="col-md-2 col-lg-2 col-sm-12 col-xs-12 mt-3">

                        <div class="iconimage">
                            <div class="icontext">
                                <div class="arrowpng">
                                    <img src="assets/assetsnew/images/easy/arrowicon.png" alt="icon" />
                                </div>
                                <p class="numb">01</p>

                                <p class="textboxyk">
                                    <i class="fi fi-tr-chart-user"></i>
                                    <br />
                                    Have a<br />
                                    business Idea or want to expand your Business?
                               
                                </p>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-2 col-lg-2 col-sm-12 col-xs-12">
                        <div class="iconimage">
                            <div class="icontext">
                                <div class="arrowpng">
                                    <img src="assets/assetsnew/images/easy/arrowicon.png" alt="icon" />
                                </div>
                                <p class="numb">02</p>

                                <p class="textboxyk">
                                    <i class="fi fi-tr-reservation-table"></i>
                                    <br />
                                    Fill <span style="color: #b6fff8;" class="colorchangerd">
                                        <br />
                                        Intent to Invest form</span> and our team will reach out
                               
                                </p>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-2 col-lg-2 col-sm-12 col-xs-12">
                        <div class="iconimage">
                            <div class="icontext">
                                <div class="arrowpng">
                                    <img src="assets/assetsnew/images/easy/arrowicon.png" alt="icon" />
                                </div>
                                <p class="numb">03</p>

                                <p class="textboxyk">
                                    <i class="fi fi-tr-clip-file"></i>
                                    <br />
                                    Prepare your<br />
                                    Documents (Project DPR, loan sanctions, etc.) 
                               
                                </p>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-2 col-lg-2 col-sm-12 col-xs-12">
                        <div class="iconimage">
                            <div class="icontext">
                                <div class="arrowpng">
                                    <img src="assets/assetsnew/images/easy/arrowicon.png" alt="icon" />
                                </div>
                                <p class="numb">04</p>

                                <p class="textboxyk">
                                    <i class="fi fi-tr-challenge-alt"></i>
                                    <br />
                                    <span style="color: #b6fff8;" class="colorchangerd">Register on<br />
                                        UNNATI Portal</span>

                                    and <span style="color: #b6fff8;" class="colorchangerd">Invest Meghalaya</span> Portal
                            
                            
                               
                                </p>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-2 col-lg-2 col-sm-12 col-xs-12">
                        <div class="iconimage">
                            <div class="icontext">
                                <div class="arrowpng">
                                    <img src="assets/assetsnew/images/easy/arrowicon.png" alt="icon" />
                                </div>
                                <p class="numb">05</p>

                                <p class="textboxyk">
                                    <i class="fi fi-tr-trust-alt"></i>
                                    <br />
                                    Get <span style="color: #b6fff8;" class="colorchangerd">Clearance<br />
                                        for Pre-establishment & Pre-operations</span> for your business
                               
                                </p>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-2 col-lg-2 col-sm-12 col-xs-12">
                        <div class="iconimage">
                            <div class="icontext">
                                <div class="arrowpng">
                                    <img src="assets/assetsnew/images/easy/arrowicon.png" alt="icon" />
                                </div>
                                <p class="numb">06</p>

                                <p class="textboxyk">
                                    <i class="fi fi-tr-operation"></i>
                                    <br />
                                    Commence<br />
                                    your
                               
                                    <br />
                                    Commercial Operations
                               
                                </p>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-2 col-lg-2 col-sm-12 col-xs-12">
                        <div class="iconimage">
                            <div class="icontext">
                                <div class="arrowpng">
                                    <img src="assets/assetsnew/images/easy/arrowicon.png" alt="icon" />
                                </div>
                                <p class="numb">07</p>

                                <p class="textboxyk">
                                    <i class="fi fi-tr-book-user"></i>
                                    <br />
                                    <span style="color: #b6fff8;" class="colorchangerd">Eligible Unit</span><br />
                                    can avail Incentives under <span style="color: #b6fff8;" class="colorchangerd">MIIPP 2024 & UNNATI 2024</span>

                                </p>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>

    <section class="team-section" style="background: url(assets/assetsnew/images/sectors.png); background-size: auto;">
        <div class="container">
            <div class="sec-title">
                <h1 style="font-size: 30px; text-transform: capitalize;">Key Sectors</h1>
                <p>Our experienced staff, combined with our global network, allow us to provide the support you need.</p>
            </div>
            <div class="three-column-carousel owl-carousel owl-theme">
                <div class="team-block-one">
                    <div class="inner-box">
                        <figure class="image-box">
                            <a href="Hospitality.aspx">
                                <img src="assets/assetsnew/images/resource/team-1.jpg" alt=""></a>
                        </figure>
                        <div class="lower-content">
                            <h4><a href="Hospitality.aspx">Hotel</a></h4>
                            <span class="designation">Meghalaya's hospitality sector create memorable experiences for visitors...</span>
                        </div>
                    </div>
                </div>


                <div class="team-block-one">
                    <div class="inner-box">
                        <a href="Tourism.aspx">
                            <figure class="image-box">
                                <img src="assets/assetsnew/images/resource/team-4.jpg" alt="">
                            </figure>
                            <div class="lower-content">
                                <h4>Tourism</h4>
                                <span class="designation">Mawmluh Cave in Sohra, Meghalaya, was selected by the International Union of Geological Sciences – IUGS (UNESCO).</span>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="team-block-one">
                    <div class="inner-box">
                        <a href="Agri-Horti.aspx">
                            <figure class="image-box">
                                <img src="assets/assetsnew/images/resource/team-2.jpg" alt="">
                            </figure>
                            <div class="lower-content">
                                <h4>Food Processing</h4>
                                <span class="designation">Meghalaya has 76% forest land, certainly above the Indian average of only 25%, whereas the net sown area is 9%</span>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="team-block-one">
                    <div class="inner-box">
                        <a href="#">
                            <figure class="image-box">
                                <img src="assets/assetsnew/images/resource/team-8.jpg" alt="">
                            </figure>
                            <div class="lower-content">
                                <h4>Education</h4>
                                <span class="designation">Nipun Bharat Mission: 50 schools are part of the 208 schools taken up in Phase 1 for the upgradation works.</span>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="team-block-one">
                    <div class="inner-box">
                        <a href="Power.aspx">
                            <figure class="image-box">
                                <img src="assets/assetsnew/images/resource/team-9.jpg" alt="">
                            </figure>
                            <div class="lower-content">
                                <h4>Hydroelectric Power</h4>
                                <span class="designation">Meghalaya has a total installed power generation capacity of 651 MW in 2023.</span>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="team-block-one">
                    <div class="inner-box">
                        <a href="IT_ITES.aspx">
                            <figure class="image-box">
                                <img src="assets/assetsnew/images/resource/team-6.jpg" alt="">
                            </figure>
                            <div class="lower-content">
                                <h4>IT & ITes</h4>
                                <span class="designation">Meghalaya's Information Technology (IT) and Information Technology Enabled Services (ITES) sectors...</span>
                            </div>
                        </a>
                    </div>
                </div>

                <div class="team-block-one">
                    <div class="inner-box">
                        <a href="#">
                            <figure class="image-box">
                                <img src="assets/assetsnew/images/resource/team-7.jpg" alt="">
                            </figure>
                            <div class="lower-content">
                                <h4>Healthcare</h4>
                                <span class="designation">The total tele-density of Meghalaya is 74 Mn</span>
                            </div>
                        </a>
                    </div>
                </div>

                <div class="team-block-one">
                    <div class="inner-box">
                        <figure class="image-box">
                            <a href="#">
                                <img src="assets/assetsnew/images/resource/team-5.jpg" alt=""></a>
                        </figure>
                        <div class="lower-content">
                            <h4><a href="#">Other</a></h4>
                            <span class="designation">Meghalaya, with abundant deposits of coal, limestone,  kaolin, clay, granite, glass-sand and uranium</span>
                        </div>
                    </div>
                </div>



            </div>
        </div>
    </section>

    <section class="about-style-three">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-md-12 col-sm-12 content-column">
                    <div class="content-box">
                        <div class="top-content">


                            <h2 class="head2">The only interface with Investors</h2>
                            <div class="middle-content">
                                <div class="text"><i class="fi fi-sr-check-double"></i>&nbsp; End to end online and transparent systems for granting clearance.</div>
                                <div class="text mt-2"><i class="fi fi-sr-check-double"></i>&nbsp; Participating 20+ departments provide 100+ regulatory clearance.</div>
                                <div class="text mt-2"><i class="fi fi-sr-check-double"></i>&nbsp; Information repository for your business realted queires.</div>
                                <div class="text mt-2"><i class="fi fi-sr-check-double"></i>&nbsp; Address your grievances.</div>
                                <div class="text mt-2"><i class="fi fi-sr-check-double"></i>&nbsp; Easy tracking of applications status.</div>
                            </div>

                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-12 d-flex" id="bottomvibebox">
                            <div class="col-md-6 glow-on-hover" id="bottombox">
                                <a href="login.aspx" class="" style="margin-left: 82px;">

                                    <img src="assets/assetsnew/images/form.gif" style="width: 26%; margin-left: -94px; margin-right: 10px;">
                                    Apply for Clearance/
                                    approvals
                                    for your business</a>
                            </div>

                            <div class="col-md-6 glow-on-hover" id="bottombox1">
                                <a href="login.aspx" class="">
                                    <img src="assets/assetsnew/images/search.gif" style="width: 28%; margin-left: -54px;">
                                    Track Application Status</a>
                            </div>
                        </div>
                    </div>




                </div>



                <div class="col-lg-6 col-md-12 col-sm-12 inner-column">

                    <video autoplay="" muted="" loop="" id="myVideo1" style="width: 100%;">
                        <source src="assets/assetsnew/images/main-slider/wim.mp4" type="video/mp4" style="height: 60%;" />
                    </video>

                </div>
            </div>
        </div>
    </section>

    <!-- Start the model box -->

    <div class="modal fade exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h5 class="modal-title" id="exampleModalLongTitle1">
                        <img src="assets/assetsnew/images/popupcircle.gif" style="width: 10%; position: absolute; left: -95px; top: -5px; border-radius: 12px;">
                        Uttar Poorva Transformative Industrialization Scheme (UNNATI), 2024 &nbsp;&nbsp;&nbsp;&nbsp;<span
                            style="display: contents; font-size: 14px; color: #9d9e9f; font-weight: 600; font-family: system-ui;"><a href="https://unnati.dpiit.gov.in/" target="_blank">Register on UNNATI 2024 Portal here.</a> &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                           
                            <a href="#" onclick="window.open('PdfFile.ashx?filePath=<%= unnati2024 %>', '_blank'); return false;">Read the UNNATI 2024 scheme document here.</a></span>
                    </h5>
                </div>
                <div class="modal-body">
                    <p class="colorpurpule">Available Incentives</p>
                    <table class="table table-bordered modeltab1">
                        <thead>
                            <tr>
                                <th scope="col">INCENTIVES</th>
                                <th scope="col" style="background: #2F5596; color: #fff;">Where GST is applicable</th>
                                <th scope="col" style="background: #0170C1; color: #fff;">Where GST is not applicable</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope="row">01. Capital Investment Incentive<br />
                                    (For Both New & Expanding Units)​</th>
                                <td>
                                    <ul>
                                        <li><i class="fi fi-br-redo"></i>Zone A: 30%  with cap of Rs. 5 Cr.</li>
                                        <li style="height: 25px;"><i class="fi fi-br-redo"></i>Zone B:  50% with cap of Rs. 7.5 Cr.</li>
                                    </ul>
                                </td>
                                <td>
                                    <ul>
                                        <li><i class="fi fi-br-redo"></i>Zone A:  30% of with cap of Rs. 10 Cr.</li>
                                        <li style="height: 25px;"><i class="fi fi-br-redo"></i>Zone B:   50% with cap of Rs. 10 Cr.​</li>
                                    </ul>
                                </td>


                            </tr>
                            <tr>
                                <th scope="row">02. Central Capital Interest Subvention<br />
                                    (For Both New & Expanding Units)</th>
                                <td colspan="2">
                                    <ul>
                                        <li><i class="fi fi-br-redo"></i>Zone A:  3% interest subvention offered for 7 years​.</li>
                                        <li style="height: 25px;"><i class="fi fi-br-redo"></i>Zone B:  5% interest subvention offered for 7 years.</li>
                                    </ul>
                                </td>

                            </tr>
                            <tr>
                                <th scope="row">03. Manufacturing Services linked incentive<br />
                                    (MSLI) – Fo& r New Units only</th>

                                <td>
                                    <ul>
                                        <li style="height: 50px;"><i class="fi fi-br-redo"></i>Zone A: 75% of eligible value of investment in P&M.</li>
                                        <li><i class="fi fi-br-redo"></i>Zone B: 100% of eligible value of investment in P&M</li>
                                    </ul>
                                </td>

                                <td>N.A.
                                </td>


                            </tr>
                        </tbody>
                    </table>

                    <p class="colorpurpule">
                        <br />
                        Eligibility
                   
                    </p>
                    <table class="table table-striped">
                        <thead>
                            <tr style="background: #2F5596; color: #fff; text-align: center;">
                                <th scope="col" style="color: #fff;">Where GST is applicable</th>
                                <th scope="col" style="color: #fff;">Where GST is not applicable</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td><b><i class="fi fi-br-redo"></i>Capital Investment Incentive (For Both New & Expanding Units):</b>
                                    <br />
                                    <i class="fi fi-br-redo"></i>For manufacturing units, minimum investment of <b>Rs 50 Lakhs for Micro and Rs 1 Crore for others</b>
                                    <br />
                                    <i class="fi fi-br-redo"></i>For service units, minimum investment of <b>Rs 50 Lakh for Micro & others</b>
                                    <br />
                                    Unit will be considered ‘Expansion’ only if the cost of new P&M required is <b>at least 25%</b> of the total investment
                                </td>
                                <td><b><i class="fi fi-br-redo"></i>Capital Investment Incentive (For Both New & Expanding Units):</b>
                                    <br />
                                    <i class="fi fi-br-redo"></i>For manufacturing units, minimum investment of <b>Rs 50 Lakhs for Micro and Rs 1 Crore for others</b>
                                    <br />
                                    <i class="fi fi-br-redo"></i>For service units, minimum investment of <b>Rs 50 Lakh for Micro & others</b>
                                    <br />
                                    Unit will be considered ‘Expansion’ only if the cost of new P&M required is <b>at least 25%</b> of the total investment
                                </td>
                            </tr>
                            <tr style="background: #9CC5E9;">
                                <td><b><i class="fi fi-br-redo"></i>Central Capital Interest Subvention (For Both New & Expanding Units):​</b><br />
                                    <i class="fi fi-br-redo"></i>Interest on loan up to the principal amount of <b>Rs. 250</b><br />
                                    <i class="fi fi-br-redo"></i>Interest on loan amount <b>exceeding Rs. 250 crore</b> would <b>not be eligible</b><br />
                                    <b><i class="fi fi-br-redo"></i>Only amount disbursed will be eligible</b></td>
                                <td><b><i class="fi fi-br-redo"></i>Central Capital Interest Subvention (For Both New & Expanding Units):​</b><br />
                                    <i class="fi fi-br-redo"></i>Interest on loan up to the principal amount of <b>Rs. 250</b><br />
                                    <i class="fi fi-br-redo"></i>Interest on loan amount <b>exceeding Rs. 250 crore</b> would <b>not be eligible</b><br />
                                    <b><i class="fi fi-br-redo"></i>Only amount disbursed will be eligible</b></td>
                            </tr>
                            <tr>
                                <td><b><i class="fi fi-br-redo"></i>Manufacturing & Services linked incentive (MSLI)– For New Units only – </b>
                                    <br />
                                    <i class="fi fi-br-redo"></i>new registration number for GST</td>
                                <td>N.A</td>
                            </tr>


                        </tbody>
                    </table>
                    <p><i># Eligible value of investment in plant and machinery (for manufacturing sector) / construction of building & durable physical assets​ (for service sector)</i></p>
                    <p><i># P&M – Plant & Machinery</i></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                </div>
            </div>
        </div>
    </div>



    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h5 class="modal-title" id="exampleModalLongTitle">
                        <img src="assets/assetsnew/images/popupcircle.gif" style="width: 10%; position: absolute; left: -95px; top: -5px; border-radius: 12px;">
                        Meghalaya Industrial and Investment
                        Promotion Policy (MIIPP) 2024 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <span
                            style="display: contents; font-size: 14px; color: #9d9e9f; font-weight: 600; font-family: system-ui;">
                            <a href="#" onclick="window.open('PdfFile.ashx?filePath=<%= mipp2024 %>', '_blank'); return false;">Read
                            the MIIPP 2024 document here.</a></span>
                    </h5>
                    <p></p>


                </div>
                <div class="modal-body">
                    <p class="colorblue">Available Incentives</p>
                    <table class="table table-bordered modeltab">
                        <thead>
                            <tr>
                                <th scope="col">INCENTIVES</th>
                                <th scope="col" style="background: #9B57CE;">Micro<br />
                                    (< INR 1 Cr) </th>
                                <th scope="col" style="background: #9B57CE;">Small<br />
                                    (INR 1 – 10 Cr)</th>
                                <th scope="col" style="background: #9B57CE;">Medium
                                       
                                    <br />
                                    (INR 10 – 50 Cr) </th>
                                <th scope="col" style="background: #9B57CE;">Large<br />
                                    (> INR 50 Cr) </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope="row">State Capital Investment Subsidy</th>
                                <td colspan="4" class="text-black" style="background: rgba(237,237,237,1);">
                                    <ul>
                                        <li><i class="fi fi-br-redo"></i>Micro, Small and Medium Industrial Unit: Subsidy @30 % (thirty percent) on cost of Plant &amp; Machinery, subject to a ceiling of priority sector- Rs 10 crore , ceiling for non-priority sector shall be Rs 8 crore.
                                        </li>
                                        <li><i class="fi fi-br-redo"></i>Large Industrial Unit: Subsidy @30 % (thirty percent) on cost of construction of Building and Plant &amp; Machinery more than Rs 50 crore, subject to a ceiling of priority sector- Rs 15 crore, ceiling for non-priority
                                      sector shall be Rs 12 crore.&ZeroWidthSpace;</li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">Interest Subvention Subsidy</th>
                                <td colspan="4" class="text-black" style="background: rgba(237,237,237,1);">
                                    <ul>
                                        <li><i class="fi fi-br-redo"></i>For Priority Sectors, 5% interest subvention offered for 7 years.
                                        </li>
                                        <li><i class="fi fi-br-redo"></i>For Non-priority Sectors, 4% interest subvention offered for 7 years.&ZeroWidthSpace;</li>
                                    </ul>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">Net SGST Reimbursement</th>
                                <td colspan="4" class="text-black" style="background: rgba(237,237,237,1);">


                                    <ul>
                                        <li><i class="fi fi-br-redo"></i>For Priority Sectors , 100% Net SGST for a period of 15 years from the date of commercial production subject to a ceiling of 150% of FCI.
                                        </li>
                                        <li><i class="fi fi-br-redo"></i>For Non-Priority Sectors , 100% Net SGST for a period of 10 years from the date of commercial production subject to a ceiling of 100% of
                                      FCI.
                                        </li>


                                    </ul>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="headingas">
                        <h4>Additional Benefits for Investments more then INR 100 Crores :
                        </h4>
                        <p style="color: #fff;">Customized Package of Incentives available</p>
                    </div>
                    <p class="colorblue">
                        <br />
                        Additional Incentives
                   
                    </p>
                    <img src="assets/assetsbeta/images/modelimg2.jpg" alt="" />

                    <p class="colorblue">
                        <br />
                        Main Eligibility Criteria
                   
                    </p>
                    <img src="assets/assetsbeta/images/modelimg3.jpg" alt="" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>

                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content custom">
                <div class="modal-header">
                    <h6 class="modal-title" id="exampleModalLabel">
                        <ul>
                            <li><span>Email:</span>
                                <b>meghalayaipa@gmail.com</b></li>
                            <li><span>Call Us:</span>
                                <b>+91 7085741695</b>

                            </li>
                        </ul>
                    </h6>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true"><i class="fi fi-br-times-hexagon"></i></span>
                    </button>
                </div>
                <div class="modal-body" id="invstpopup">
                    <div class="col-md-12 d-flex">

                        <div class="col-md-6 p-0">
                            <a href="login.aspx">
                                <img src="assets/assetsnew/images/info/indbox.png" style="margin-left: -14px;">
                                <div class="textinvd1">
                                    <p class="smallinv">Central Inspection System</p>
                                </div>
                                <div class="invticon">
                                    <i class="fi fi-tr-operating-system-upgrade"></i>
                                </div>
                            </a>
                        </div>

                        <div class="col-md-6 p-0">
                            <button type="button" class="" data-toggle="modal" data-target="#exampleModal123">
                                <img src="assets/assetsnew/images/info/indbox.png" />
                                <div class="textinvd1">
                                    <p class="smallinv">Dashboard</p>
                                </div>
                                <div class="invticon">
                                    <i class="fi fi-tr-dashboard-panel"></i>
                                </div>
                            </button>
                        </div>
                    </div>
                    <div class="col-md-12 d-flex mt-2">
                        <div class="col-md-6 p-0 pr-0">
                            <a href="login.aspx">
                                <img src="assets/assetsnew/images/info/indbox.png" style="margin-left: -14px;">
                                <div class="textinvd1">
                                    <p class="smallinv">Know Your Approvals</p>
                                </div>
                                <div class="invticon">
                                    <i class="fi fi-tr-memo-circle-check"></i>
                                </div>
                            </a>
                        </div>
                        <div class="col-md-6 p-0">
                            <a href="login.aspx">
                                <img src="assets/assetsnew/images/info/indbox.png" />
                                <div class="textinvd1">
                                    <p class="smallinv">Know Your Incentives</p>
                                </div>
                                <div class="invticon">
                                    <i class="fi fi-tr-user-gear"></i>
                                </div>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-12 d-flex mt-2">
                        <div class="col-md-6 p-0 pr-0">
                            <a href="RegisterGrievance.aspx">
                                <img src="assets/assetsnew/images/info/indbox.png" style="margin-left: -14px;">
                                <div class="textinvd1">
                                    <p class="smallinv">Register Grievance/Query</p>
                                </div>
                                <div class="invticon">
                                    <i class="fi fi-tr-building"></i>
                                </div>
                            </a>
                        </div>
                        <div class="col-md-6 p-0">
                            <a href="login.aspx">
                                <img src="assets/assetsnew/images/info/indbox.png" />
                                <div class="textinvd1">
                                    <p class="smallinv">Track Application Status</p>
                                </div>
                                <div class="invticon">
                                    <i class="fi fi-tr-track"></i>
                                </div>
                            </a>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>
    <div class="servicedesk">
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
            <i class="fi fi-tr-admin-alt"></i>Investor Desk
       
        </button>
    </div>

    <div class="modal fade" id="exampleModal123" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel123">Services</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                </div>
                <div class="modal-body">
                    <p>Which dashboard would you like to go?</p>
                </div>
                <div class="modal-footer">
                    <a href="SingleWindowPortalDashboard.aspx" class="btn btn-secondary">Single Window Dashboard</a>
                    <a href="GrievanceMisReport.aspx" class="btn btn-primary">Grievance/Query Dashboard</a>


                </div>
            </div>
        </div>
    </div>


    <%--    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <!-- Chatbot Icon -->
    <div style="position: fixed; bottom: 20px; right: 20px;">
        <asp:ImageButton ID="btnChatbot" runat="server" ImageUrl="~/assets/assetsnew/images/info/robot.png"
            OnClientClick="toggleChat(); return false;" />
    </div>

    <!-- Chat Window -->
    <div id="chatWindow" style="display: none; position: fixed; bottom: 80px; right: 20px; width: 300px; height: 400px; border: 1px solid #ccc; background: #fff; overflow: auto; padding: 10px;">
        <div id="chatContent"></div>
    </div>

    <script>
        function toggleChat() {
            document.getElementById("chatWindow").style.display =
                document.getElementById("chatWindow").style.display === "none" ? "block" : "none";
            PageMethods.GetModules(onModulesLoaded);
        }

        function onModulesLoaded(modules) {
            var content = "";
            modules.forEach(function (m) {
                content += "<button onclick=\"loadQuestions('" + m + "')\">" + m + "</button><br/>";
            });
            document.getElementById("chatContent").innerHTML = content;
        }

        function loadQuestions(module) {
            PageMethods.GetQuestions(module, function (questions) {
                var content = "";
                questions.forEach(function (q) {
                    content += "<button onclick=\"loadAnswer(" + q.SLNO + ")\">" + q.QUESTION + "</button><br/>";
                });
                document.getElementById("chatContent").innerHTML = content;
            });
        }

        function loadAnswer(slno) {
            PageMethods.GetAnswer(slno, function (answer) {
                document.getElementById("chatContent").innerHTML = "<p>" + answer + "</p><br/><button onclick='toggleChat()'>Close</button>";
            });
        }
    </script>  --%>

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />

    <!-- Chatbot Icon -->
    <div style="position: fixed; bottom: 20px; right: 20px;">
        <asp:ImageButton ID="btnChatbot" runat="server"
            ImageUrl="~/assets/assetsnew/images/info/robot.png"
            OnClientClick="toggleChat(); return false;" />
    </div>

    <!-- Chat Window -->
    <div id="chatWindow" role="dialog" aria-hidden="true">
        <div id="chatHeader">
            <%-- <strong>Help</strong>--%>
            <button type="button" class="small-btn" onclick="closeChat()">X</button>
        </div>
        <div id="chatContent"></div>
    </div>

    <script type="text/javascript">
        var modulesCache = null;
        var questionsCache = {};
        var answersCache = {};
        var isModulesLoading = false;

        document.addEventListener('DOMContentLoaded', function () {
            try {
                var saved = localStorage.getItem('chatModules_v1');
                if (saved) modulesCache = JSON.parse(saved);
            } catch (e) { console.warn('localStorage read failed', e); }

            prefetchModules();
        });

        function prefetchModules() {
            if (modulesCache || isModulesLoading) return;
            isModulesLoading = true;
            PageMethods.GetModules(function (mods) {
                isModulesLoading = false;
                modulesCache = mods || [];
                try { localStorage.setItem('chatModules_v1', JSON.stringify(modulesCache)); } catch (e) { }
            }, function (err) {
                isModulesLoading = false;
                console.error('GetModules failed (prefetch)', err);
            });
        }

        function toggleChat() {
            var w = document.getElementById('chatWindow');

            var isOpening = (w.style.display !== 'block');

            if (isOpening) {
                w.style.display = 'block';
                w.setAttribute('aria-hidden', 'false');

                // Record the click asynchronously
                PageMethods.RecordChatbotClick(function () {
                    console.log('Chatbot click recorded');
                }, function (err) {
                    console.warn('Click record failed', err);
                });

                // Load modules
                if (modulesCache && modulesCache.length) {
                    renderModules(modulesCache);
                    return false;
                }
                showLoading('Loading...');
                PageMethods.GetModules(function (modules) {
                    hideLoading();
                    modulesCache = modules || [];
                    renderModules(modulesCache);
                });
            } else {
                w.style.display = 'none';
                w.setAttribute('aria-hidden', 'true');
            }
            return false;

            if (w.style.display === 'block') {
                w.style.display = 'none';
                w.setAttribute('aria-hidden', 'true');
                return false;
            }
            w.style.display = 'block';
            w.setAttribute('aria-hidden', 'false');

            if (modulesCache && modulesCache.length) {
                renderModules(modulesCache);
                return false;
            }

            showLoading('Loading...');
            PageMethods.GetModules(function (modules) {
                hideLoading();
                modulesCache = modules || [];
                try { localStorage.setItem('chatModules_v1', JSON.stringify(modulesCache)); } catch (e) { }
                renderModules(modulesCache);
            }, function (err) {
                hideLoading();
                document.getElementById('chatContent').innerHTML = '<div style="color:crimson">Error loading modules. Try again later.</div>';
                console.error(err);
            });
            return false;
        }

        function renderModules(mods) {
            var container = document.getElementById('chatContent');
            container.innerHTML = '';
            if (!mods || !mods.length) {
                container.innerHTML = '<div>No modules found.</div>';
                return;
            }
            mods.forEach(function (m) {
                var btn = document.createElement('button');
                btn.textContent = m;
                btn.className = 'module-btn';
                btn.onclick = function () { loadQuestions(m); };
                container.appendChild(btn);
            });
        }

        function loadQuestions(moduleName) {
            var container = document.getElementById('chatContent');
            if (questionsCache[moduleName]) {
                renderQuestions(moduleName, questionsCache[moduleName]);
                return;
            }
            showLoading('Loading questions...');
            PageMethods.GetQuestions(moduleName, function (questions) {
                hideLoading();
                questionsCache[moduleName] = questions || [];
                renderQuestions(moduleName, questionsCache[moduleName]);
            }, function (err) {
                hideLoading();
                container.innerHTML = '<div style="color:crimson">Error loading questions.</div>';
                console.error(err);
            });
        }

        function renderQuestions(moduleName, questions) {
            var container = document.getElementById('chatContent');
            container.innerHTML = '';

            var back = document.createElement('button');
            back.textContent = '← Back to modules';
            back.className = 'small-btn';
            back.onclick = function () { renderModules(modulesCache || []); };
            container.appendChild(back);

            questions.forEach(function (q) {
                var btn = document.createElement('button');
                btn.textContent = q.QUESTION;
                btn.onclick = function () { loadAnswer(q.SLNO); };
                container.appendChild(btn);
            });

            if (!questions.length) {
                var p = document.createElement('div');
                p.textContent = 'No questions available in this module.';
                container.appendChild(p);
            }
        }

        function loadAnswer(slno) {
            var container = document.getElementById('chatContent');
            if (answersCache[slno]) {
                container.innerHTML = formatAnswerHtml(answersCache[slno]);
                return;
            }
            showLoading('Loading answer...');
            PageMethods.GetAnswer(slno, function (answer) {
                hideLoading();
                answersCache[slno] = answer || 'No answer found.';
                container.innerHTML = formatAnswerHtml(answersCache[slno]);
            }, function (err) {
                hideLoading();
                container.innerHTML = '<div style="color:crimson">Error loading answer.</div>';
                console.error(err);
            });
        }

        function formatAnswerHtml(answerText) {
            return '<div>' + (answerText || '') + '</div><br/><button class="small-btn" onclick="toggleChat()">Close</button>';
        }


        function showLoading(text) {
            var container = document.getElementById('chatContent');
            container.innerHTML = '<div class="spinner">' + (text || 'Loading...') + '</div>';
        }
        function hideLoading() { /* no-op: caller replaces content */ }

        function closeChat() {
            document.getElementById('chatWindow').style.display = 'none';
        }
    </script>
</asp:Content>
