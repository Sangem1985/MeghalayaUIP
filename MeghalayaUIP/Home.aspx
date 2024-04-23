<%@ Page Title="" Language="C#" MasterPageFile="~/outer.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MeghalayaUIP.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Start the Body Part-->
        
        <p class="blink">Come, Invest Meghalaya</p>

        <!-- start of hero -->
        <section class="hero-slider hero-style-1">
            <div class="swiper-container">
                <div class="swiper-wrapper">
                    <div class="swiper-slide">
                        <div class="slide-inner slide-bg-image" data-background="assets/images/slider/slide-3.jpg">
                            <div class="container">
                                <div data-swiper-parallax="400" class="slide-text">
                                    <p>Welcome to Meghalaya</p>
                                </div>
                                <div data-swiper-parallax="300" class="slide-title">
                                    <h2>The Best State to do Business in India.</h2>
                                </div>

                                <div class="clearfix"></div>

                            </div>
                        </div> <!-- end slide-inner -->
                    </div> <!-- end swiper-slide -->

                    <div class="swiper-slide">
                        <div class="slide-inner slide-bg-image" data-background="assets/images/slider/slide-2.jpg">
                            <div class="container">
                                <div data-swiper-parallax="400" class="slide-text">
                                    <p>Welcome to Meghalaya</p>
                                </div>
                                <div data-swiper-parallax="300" class="slide-title">
                                    <h2>The Best Investment Destination in India.</h2>
                                </div>

                                <div class="clearfix"></div>

                            </div>
                        </div> <!-- end slide-inner -->
                    </div> <!-- end swiper-slide -->
                </div>
                <!-- end swiper-wrapper -->

                <!-- swipper controls -->
                <div class="swiper-pagination"></div>
                <div class="swiper-button-next"></div>
                <div class="swiper-button-prev"></div>
            </div>
        </section>
        <!-- end of hero slider -->

        <section class="features-section-s2">
            <div class="container-fluid" style="padding: 0px !important;">
                <div class="row">
                    <div class="col col-xs-12">
                        <div class="feature-grids clearfix">
                            <div class="grid">
                                <div class="icon">
                                    <i class="fi flaticon-star"></i>
                                </div>
                                <span class="count">01.</span>
                                <h4>Expert Members</h4>
                            </div>
                            <div class="grid">
                                <div class="icon">
                                    <i class="fi flaticon-trophy"></i>
                                </div>
                                <span class="count" style="color: #fff;">02.</span>
                                <h4>Awards &amp; Accolades</h4>
                            </div>
                            <div class="grid">
                                <div class="icon">
                                    <i class="fi flaticon-leadership"></i>
                                </div>
                                <span class="count">03.</span>
                                <h4>Thought Leadership</h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div> <!-- end container -->
        </section>
        <!-- start about-us-section -->
        <section class="about-us-section section-padding">
            <div class="container">
                <div class="row">
                    <div class="col col-md-6">
                        <div class="section-title">
                            <span>SNAPSHOT</span>
                            <h2 style="font-family: 'Montserrat', sans-serif;">Third Largest Producer of Strawberry in
                                India.</h2>
                        </div>
                        <div class="details">
                            <h4 style="font-family: system-ui;line-height: 26px;">We have a vision to take Meghalaya
                                forward and to realise our goals, we have envisioned a 10 billion US dollar economy and
                                all our interventions are linked to drive our State to the next level. </h4>
                            <p style="margin-bottom: 5px;">As part of this, we have roll out Meghalaya Industrial and
                                Investment Promotion Policy, IT & ITES Promotion Policy, Meghalaya Power Policy, etc to
                                further the growth of our State.</p>
                            <p style="margin-bottom: 5px;">The picturesque state receives the highest rainfall in the
                                country, hosts an array of
                                national parks, wildlife sanctuaries, medicinal plants, and more. Meghalaya has 2
                                national parks and 4 wildlife sanctuaries. It offers many adventure tourism
                                opportunities like mountaineering, rock climbing, water sports, hiking, and trekking,
                                among others. Mawsynram, located in East Khasi Hills, is the wettest place in the world.
                            </p>
                            <p>Meghalaya as an investment destination, we have curated different policies and
                                interventions for ease of doing business. </p>

                        </div>
                    </div>
                    <div class="col col-md-6">
                        <div class="right-col">
                            <div class="img-holder">
                                <img src="assets/images/about.png" alt="" style="
    box-shadow: 0 10px 20px rgba(0, 0, 0, 0.2);
">
                            </div>
                            <div class="video-holder">
                                <a href="#" class="hero-video-btn video-btn" data-type="iframe" tabindex="0"><i
                                        class="fi flaticon-play-button"></i>Why Invest in Meghalaya</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div> <!-- end container -->
        </section>
        <!-- end about-us-section -->

        <%--<section class="service-section section-padding" style="padding: 0px;">
            <div class="container-fluid">
                <div class="row">
                    <img src="assets/images/headerbg4.png" style="width: 100%;" />
                   
                </div>
            </div>
        </section>--%>

    <!-- Start Services Section -->
        <section id="services" class="services">
            <div class="container-fluid">
          
          
             <div class="row">
                <div class="col-lg-1"></div>
              <div class="col-lg-2">
                <div class="icon-box" title="Employer" id="one">
                    <div class="box">
                  <div class="icon"><img src="assets/images/param/icon1.png"></div>
                  <h4>6%<br/></h4>
                    <p style="color: #000;">CAGR of GSDP between
                    2025-16 and 2020-21</p>
                </div>
                </div>
              </div>
              <div class="col-lg-2">
                <div class="icon-box" title="Employer" id="one">
                    <div class="box">
                  <div class="icon"><img src="assets/images/param/icon2.png"></div>
                  <h4>$10.14 Mn<br/></h4>
                    <p style="color: #000;">Exports during Apr 2022 to Mar 2023</p>
                </div>
                </div>
              </div>
              <div class="col-lg-2">
                <div class="icon-box" title="Employer" id="one">
                    <div class="box">
                  <div class="icon"><img src="assets/images/param/icon3.png"></div>
                  <h4>76%<br/></h4>
                    <p style="color: #000;">Forest cover of the total Area</p>
                </div>
                </div>
              </div>
              <div class="col-lg-2">
                <div class="icon-box" title="Employer" id="one">
                    <div class="box">
                  <div class="icon"><img src="assets/images/param/icon4.png"></div>
                  <h4>$5 Bn<br/></h4>
                    <p style="color: #000;">GSDP <br/>(2022-23)</p>
                </div>
                </div>
              </div>
              <div class="col-lg-2">
                <div class="icon-box" title="Employer" id="one">
                    <div class="box">
                  <div class="icon"><img src="assets/images/param/icon5.png"></div>
                  <h4>3K MW<br/></h4>
                    <p style="color: #000;">Hydroelectric Power Potential</p>
                </div>
                </div>
              </div>
              <div class="col-lg-1"></div>
          
              </div>
          
            </div>
          </section>
          <!-- End Services Section -->
        <section class="service-section section-padding" style="padding: 30px;">
            <div class="container-fluid">
                <div class="row">
                    <div class="section-title-s3">
                        <span>Meghalaya</span>
                        <h2 style="color: #131e4a !important;font-family: 'Montserrat', sans-serif;">Focus Sectors</h2>

                    </div>
                    <h2></h2>
                    <img src="assets/images/headerbg_key.gif" style="width: 100%;" />
                </div>
            </div>
        </section>

        <!-- start service-section -->
        <section class="testimonials-section" style="padding: 40px 0px;">
            <div class="container">
                <div class="row">
                    <div class="col col-md-6">
                        <div class="section-title-s2" style="margin: 0px;display: flex;justify-content: center;">
                            <i class="fi flaticon-chip"></i>
                            <h2
                                style="color: #131e4a !important;font-family: 'Montserrat', sans-serif;font-weight: 500;text-align: center;margin-top: 34px;margin-left: 12px;font-size: 32px;">
                                Single Window of Clearance</h2>
                        </div>
                        <img src="assets/images/swc.png" style="width: 100%;" />
                    </div>
                    <div class="col col-md-6">
                        <div class="section-title-s2" style="margin: 0px;display: flex;justify-content: center;">
                            <i class="fi flaticon-network-1"></i>
                            <h2
                                style="color: #131e4a !important;font-family: 'Montserrat', sans-serif;font-weight: 500;text-align: center;margin-top: 34px;margin-left: 12px;font-size: 32px;">
                                Deemed Approval</h2>
                        </div>
                        <img src="assets/images/da1.png" style="width: 100%;" />
                        <br />
                        <br />
                        <br />
                    </div>
                </div>


            </div> <!-- end container -->
        </section>
        <!-- end service-section -->

        <section class="partners-section">

            <div class="container">
                <div class="row">
                    <div class="section-title-s3">
                        <span>Meghalaya</span>
                        <h2 style="color: #131e4a !important;font-family: 'Montserrat', sans-serif;">Major Investments
                        </h2>

                    </div>
                    <div class="col col-xs-12">
                        <div class="partner-grids partners-slider">
                            <div class="grid">
                                <img src="assets/images/partners/2.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/partners/3.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/partners/4.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/partners/5.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/partners/6.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/partners/7.png" alt>
                            </div>
                        </div>
                    </div>
                </div>
            </div> <!-- end container -->
        </section>



        <section class="testimonials-section1" style="padding: 0px 0px;">
            <div class="section-title-s2" style="margin: 0px;display: flex;justify-content: center;">

                <h2 style="color: #131e4a !important;font-family: 'Montserrat', sans-serif;font-weight: 540;text-align: left;margin-top: 34px;margin-left: 12px;font-size: 22px;padding: 10px;border-radius: 29px;margin-bottom: -7px;z-index: 99;    position: absolute;
    left: 2px;">The Meghalaya State Industrial Policy is rooted in certain<br /> core values, as follows:</h2>
            </div>
            <div class="container-fluid" style="padding: 0px;">
                <div class="row">
                    <div class="col col-md-6" style="padding: 0px;">

                        <img src="assets/images/fotter11.png" style="width: 100%;margin-left: 10px;" />
                    </div>
                    <div class="col col-md-6" style="padding: 0px;">

                        <img src="assets/images/fotter2.png" style="width: 100%;" />
                        <br />
                        <br />
                        <br />
                    </div>
                </div>


            </div> <!-- end container -->
        </section>
        <!-- start why-choose-section -->


        <section class="partners-section" id="destin">

            <div class="container">
                <div class="row">
                    <div class="section-title-s3">
                        <span>Meghalaya</span>
                        <h2 style="color: #131e4a !important;font-family: 'Montserrat', sans-serif;">Destination</h2>


                    </div>
                    <div class="col col-xs-12">
                        <div class="partner-grids partners-slider1">
                            <div class="grid">
                                <img src="assets/images/desti/1.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/desti/9.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/desti/2.png" alt>
                            </div>

                            <div class="grid">
                                <img src="assets/images/desti/3.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/desti/4.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/desti/10.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/desti/5.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/desti/6.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/desti/7.png" alt>
                            </div>
                            <div class="grid">
                                <img src="assets/images/desti/8.png" alt>
                            </div>
                        </div>
                    </div>
                </div>
            </div> <!-- end container -->
        </section>




        <!-- start cta-section -->
        <section class="cta-section">
            <div class="container">
                <div class="row">
                    <div class="col col-lg-6 col-md-6">
                        <div class="cta-text">
                            <h3>Lets Get in Touch!</h3>
                            <p>Should You Have Any Questions, Or Wish To Speak To Our Qualified Financial Advisors At
                                Meghalaya, Please Contact Us..</p>
                        </div>
                    </div>
                    <div class="col col-lg-5 col-lg-offset-1 col-md-6">
                        <div class="contact-info">
                            <div>
                                <i class="fi flaticon-call"></i>
                                <h4>Call us</h4>
                                <p>+654894754</p>
                            </div>
                            <div>
                                <i class="fi flaticon-contact"></i>
                                <h4>Email us</h4>
                                <p>demo@example.com</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div> <!-- end container -->
        </section>
        <!-- end cta-section -->


        <!--End of the Body Part-->
</asp:Content>
