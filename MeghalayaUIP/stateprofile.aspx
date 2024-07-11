<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="stateprofile.aspx.cs" Inherits="MeghalayaUIP.stateprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel='stylesheet' href='https://cdn-uicons.flaticon.com/2.4.2/uicons-thin-rounded/css/uicons-thin-rounded.css'>
    <style>
        .team-block-two .inner-box {
    border-radius: 10px;
}
        .owl-dots {
    display: none;
}
        .owl-nav {
    display: none;
}
        .team-block-two:hover .inner-box .image-box img {
    opacity: 0.8 !important;
    transform: scale(1.05);
}
        .hero-slider .slide-inner {
            width: 100%;
            height: 70% !important;
        }

        .slide-inner.slide-bg-image:before {
            content: "";
            background: -webkit-linear-gradient(0deg, rgb(2 41 96 / 88%) 40%, rgb(255 255 255 / 0%) 100%) !important;
            position: absolute;
            bottom: 0;
            top: 0;
            left: 0;
            right: 0;
        }

        .hero-style-1 .slide-title h2 {
            font-size: 35px !important;
        }

        section.innerpages {
            margin-top: 40px !important;
            margin-bottom: 40px;
        }

        .swiper-button-next, .swiper-button-prev {
            display: none;
        }

        .carousel-caption.d-none.d-md-block h5 {
            margin-top: -260px !important;
            margin-left: 102px;
            text-align: left;
        }

        .carousel-caption.d-none.d-md-block p {
            font-size: 72px;
            font-size: 30px;
            font-weight: bold;
            color: #fff;
            margin: 0 0 0.4em;
            font-family: system-ui;
            background: #121FCF;
            background: linear-gradient(to right, #FFFFFE 20%, #fff 100%);
            -webkit-background-clip: text;
            text-align: left;
            margin-left: 100px;
            /* line-height: 44px; */
        }

        .carousel-caption.d-none.d-md-block p, h5 {
            text-align: left;
            line-height: 38px;
        }

        span.carousel-control-prev-icon, span.carousel-control-next-icon {
            display: none;
        }

        ol.carousel-indicators {
            display: none;
        }

        section.innerpages h4 {
            font-family: "Roboto", sans-serif !important;
            color: #4577c1 !important;
            padding-top: 15px;
            font-size: 1.3rem !important;
            font-weight: 500;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<section class="hero-slider hero-style-1">
        <div class="swiper-container">
            <div class="swiper-wrapper">
                <div class="swiper-slide">
                    
                    <div class="slide-inner slide-bg-image" data-background="assets/assetsbeta/images/slider/sp/slide-2.jpg">
                        <div class="container">
                            <div data-swiper-parallax="400" class="slide-text">
                                <p>Welcome to <b>Meghalaya : </b> </p>
                            </div>
                            <div data-swiper-parallax="300" class="slide-title">
                                <h2>India’s Emerging Business Ecosystem.</h2>
                            </div>

                            <div class="clearfix"></div>

                        </div>
                    </div>
                    
                </div>
               

                <div class="swiper-slide">
                    <div class="slide-inner slide-bg-image" data-background="assets/assetsbeta/images/slider/sp/slide-3.jpg">
                        <div class="container">
                            <div data-swiper-parallax="400" class="slide-text">
                                <p>Mission 10: </p>
                            </div>
                            <div data-swiper-parallax="300" class="slide-title">
                                <h2>Meghalaya’s vision of a Viksit Bharat Viksit Meghalaya is strengthened by its commitment<br />
                                    of increasing the State’s GDP to 10 billion US Dollar by 2028.</h2>
                            </div>

                            <div class="clearfix"></div>

                        </div>
                    </div>
                    
                </div>
                
            </div>
           

           
            <div class="swiper-pagination"></div>
            <div class="swiper-button-next"></div>
            <div class="swiper-button-prev"></div>
        </div>
    </section>--%>
    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img class="d-block w-100" src="assets/assetsbeta/images/slider/sp/slide-2.jpg" alt="First slide">
                <div class="carousel-caption d-none d-md-block">
                    <h5>Welcome to <b>Meghalaya : </b></h5>
                    <p>India’s Emerging Business Ecosystem.</p>
                </div>
            </div>
            <div class="carousel-item">
                <img class="d-block w-100" src="assets/assetsbeta/images/slider/sp/slide-3.jpg" alt="Second slide">
                <div class="carousel-caption d-none d-md-block">
                    <h5>Mission 10:</h5>
                    <p>Meghalaya’s vision of a Viksit Bharat Viksit Meghalaya is strengthened by its commitment of increasing the State’s GDP to 10 billion US Dollar by 2028.</p>
                </div>
            </div>

        </div>
        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Why Meghalaya</li>
                            <li class="breadcrumb-item active" aria-current="page">State Profile</li>
                        </ol>
                    </nav>

                    <h3>Meghalaya’s strengths</h3>
                    <p>Located in India's North-Eastern Region (NER), Meghalaya, fondly referred to as the "Abode of Clouds," holds significant strategic importance that offers unique economic opportunities to drive regional growth.</p>
                    <p>Bordered by Assam to the North and Northeast and Bangladesh to the South and Southwest, Meghalaya's advantageous position is further strengthened by the upcoming BBIN2 Corridor. This corridor will transform Meghalaya into a crucial connecting node for Bangladesh, Bhutan, and Nepal.</p>
                    <p>Additionally, its proximity to the Bay of Bengal underscores its potential to become a major trade hub for the NER.</p>
                    <p>Moreover, the Government of India is committed to accelerating the development and connectivity of the NER, including Meghalaya, through initiatives like the NITI Forum for regional growth, comprehensive transportation projects, and the Act East Policy. These efforts aim to enhance trade and relations with Southeast Asian countries, evident in initiatives such as establishing rail sections, air connectivity with NER and ASEAN countries, and constructing National Highway corridors linking Meghalaya with Bangladesh.</p>
                    <h3>State Demography :</h3>

                    <p>Discover the key demographic and economic indicators shaping Meghalaya's landscape. From population statistics to export growth, explore the state's dynamic profile in a glance.</p>
                    <%--<p><b></b></p>--%>

                    <section class="fact-counter about-page-2 p-0">
                        <div class="container">
                            <div class="inner-container">
                                <h4>Key Demographic:</h4>
                                <div class="row mt-3">

                                    <div class="col-lg-2 col-md-6 col-sm-12 counter-block">
                                        <div class="counter-block-two wow slideInUp" data-wow-delay="00ms" data-wow-duration="1500ms">
                                            <div class="inner-box">
                                                <div class="icon-box"><i class="fi fi-tr-land-location"></i></div>
                                                <div class="count-outer count-box">
                                                    <span class="count-text" data-speed="1500" data-stop="22429">0</span> <span>Sq. km</span>
                                                </div>
                                                <div class="text">Area<br />
                                                    &nbsp;</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 col-md-6 col-sm-12 counter-block">
                                        <div class="counter-block-two wow slideInUp" data-wow-delay="200ms" data-wow-duration="1500ms">
                                            <div class="inner-box">
                                                <div class="icon-box"><i class="fi fi-tr-land-layer-location"></i></div>
                                                <div class="count-outer count-box">
                                                    <span class="count-text" data-speed="1500" data-stop="29.7">0</span> <span>L</span>
                                                </div>
                                                <div class="text">Total Population (2011)</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 col-md-6 col-sm-12 counter-block">
                                        <div class="counter-block-two wow slideInUp" data-wow-delay="400ms" data-wow-duration="1500ms">
                                            <div class="inner-box">
                                                <div class="icon-box"><i class="fi fi-tr-trees"></i></div>
                                                <div class="count-outer count-box">
                                                    <span class="count-text" data-speed="1500" data-stop="76">0</span>  <span>%</span>
                                                </div>
                                                <div class="text">Forest Cover (2021)</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 col-md-6 col-sm-12 counter-block">
                                        <div class="counter-block-two wow slideInUp" data-wow-delay="600ms" data-wow-duration="1500ms">
                                            <div class="inner-box">
                                                <div class="icon-box"><i class="fi fi-tr-smoke"></i></div>
                                                <div class="count-outer count-box">
                                                    <span class="count-text" data-speed="1500" data-stop="33">0</span>
                                                </div>
                                                <div class="text">Air Quality (AQI of capitals)</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 col-md-6 col-sm-12 counter-block">
                                        <div class="counter-block-two wow slideInUp" data-wow-delay="600ms" data-wow-duration="1500ms">
                                            <div class="inner-box">
                                                <div class="icon-box"><i class="fi fi-tr-department"></i></div>
                                                <div class="count-outer count-box">
                                                    <span class="count-text" data-speed="1500" data-stop="75.5">0</span> <span>%</span>
                                                </div>
                                                <div class="text">Literacy rate (2011)</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 col-md-6 col-sm-12 counter-block">
                                        <div class="counter-block-two wow slideInUp" data-wow-delay="600ms" data-wow-duration="1500ms">
                                            <div class="inner-box">
                                                <div class="icon-box"><i class="fi fi-tr-venus-mars"></i></div>
                                                <div class="count-outer count-box">
                                                    <span class="count-text" data-speed="1500" data-stop="989">0</span>
                                                </div>
                                                <div class="text">Sex Ratio (Per 1000 males)</div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 col-md-6 col-sm-12 counter-block mt-4">
                                        <div class="counter-block-two wow slideInUp" data-wow-delay="600ms" data-wow-duration="1500ms">
                                            <div class="inner-box">
                                                <div class="icon-box"><i class="fi fi-tr-users"></i></div>
                                                <div class="count-outer count-box">
                                                    <span class="count-text" data-speed="1500" data-stop="11.11">0</span> <span>L</span>
                                                </div>
                                                <div class="text">Youth
                                                    <br />
                                                    Population</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 col-md-6 col-sm-12 counter-block mt-4">
                                        <div class="counter-block-two wow slideInUp" data-wow-delay="600ms" data-wow-duration="1500ms">
                                            <div class="inner-box">
                                                <div class="icon-box"><i class="fi fi-tr-house-building"></i></div>
                                                <div class="count-outer count-box">
                                                    <span class="count-text" data-speed="1500" data-stop="23.7">0</span> <span>L</span>
                                                </div>
                                                <div class="text">Urban<br />
                                                    Population</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 col-md-6 col-sm-12 counter-block mt-4">
                                        <div class="counter-block-two wow slideInUp" data-wow-delay="600ms" data-wow-duration="1500ms">
                                            <div class="inner-box">
                                                <div class="icon-box"><i class="fi fi-tr-house-chimney"></i></div>
                                                <div class="count-outer count-box">
                                                    <span class="count-text" data-speed="1500" data-stop="6">0</span> <span>L</span>
                                                </div>
                                                <div class="text">Rural
                                                    <br />
                                                    Population</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 counter-block mt-4">
                                        <div class="counter-block-two wow slideInUp" data-wow-delay="600ms" data-wow-duration="1500ms">
                                            <div class="inner-box">
                                                <div class="icon-box"><i class="fi fi-tr-web"></i></div>
                                                <div class="count-outer count-box">
                                                    <span class="count-text" data-speed="1500" data-stop="76">0</span>
                                                </div>
                                                <div class="text">Mobile Connections per 100 Person (2023)</div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 counter-block mt-4">
                                        <div class="counter-block-two wow slideInUp" data-wow-delay="600ms" data-wow-duration="1500ms">
                                            <div class="inner-box">
                                                <div class="icon-box"><i class="fi fi-tr-site"></i></div>
                                                <div class="count-outer count-box">
                                                    <span class="count-text" data-speed="1500" data-stop="59">0</span>
                                                </div>
                                                <div class="text">Internet subscribers per 100 population (2023)</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>



                    <section class="service-style-four service-page-3 centred p-0">
                        <div class="container">
                            <div class="inner-container">
                                <h4 style="text-align: left;">Economic Indicators</h4>
                                <div class="row mt-2">
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                            <div class="inner-box">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="fi fi-tr-chart-arrow-grow"></i></div>
                                                <h3><a href="service-single.html">6.8%</a></h3>
                                                <div class="text">Export Growth (2017 to 2022)</div>
                                                <%-- <div class="btn-box"><a href="service-single.html">Explore</a></div>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated" data-wow-delay="300ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 300ms; animation-name: fadeInUp;">
                                            <div class="inner-box">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="fi fi-tr-tax-alt"></i></div>
                                                <h3><a href="service-single.html">$5.9Bn</a></h3>
                                                <div class="text">GSDP (2024)</div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated" data-wow-delay="600ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 600ms; animation-name: fadeInUp;">
                                            <div class="inner-box">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="fi fi-tr-challenge-alt"></i></div>
                                                <h3><a href="service-single.html">52,9773 crore</a></h3>
                                                <div class="text">GSDP (2024-2025-Projected)</div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                            <div class="inner-box">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="fi fi-tr-career-growth"></i></div>
                                                <h3><a href="service-single.html">11.4%</a></h3>
                                                <div class="text">GSDP Growth (2023 to 2025)</div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated" data-wow-delay="300ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 300ms; animation-name: fadeInUp;">
                                            <div class="inner-box">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="flaticon-support"></i></div>
                                                <h3><a href="service-single.html">1.39602 L</a></h3>
                                                <div class="text">Per Capita GSDP</div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated" data-wow-delay="600ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 600ms; animation-name: fadeInUp;">
                                            <div class="inner-box">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="fi fi-tr-tools"></i></div>
                                                <h3><a href="service-single.html">60%</a></h3>
                                                <div class="text">Labour force participation rate</div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated" data-wow-delay="600ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 600ms; animation-name: fadeInUp;">
                                            <div class="inner-box">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="fi fi-tr-corporate-alt"></i></div>
                                                <h3><a href="service-single.html">34%</a></h3>
                                                <div class="text">Women’s participation in the workforce (Rural)</div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated" data-wow-delay="600ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 600ms; animation-name: fadeInUp;">
                                            <div class="inner-box">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="fi fi-tr-house-tree"></i></div>
                                                <h3><a href="service-single.html">24%</a></h3>
                                                <div class="text">Women’s participation in the workforce (Urban)</div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>


                    <h3>Connectivity:</h3>
                    <p>
                        Meghalaya's connectivity is key to its development. With extensive road, rail, and air networks, the state ensures
                        seamless transportation for growth and accessibility.
                    </p>
                    <h4 style="margin-bottom: -71px;">Road Connectivity
                        <br>
                        <br>
                        <br>
                        :</h4>

                    <section class="service-style-four service-page-3 centred p-0 m-0">
                        <div class="container">
                            <div class="inner-container">
                                <img src="assets/assetsnew/images/info/road.png" style="width: 40%;">
                                <p class="road1 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" 
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">Road Network:<br />
                                    13,000 km</p>
                                <p class="road2 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" 
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">Road Density:<br />
                                    0.48 km/sq. km<br />
                                    density</p>
                                <p class="road3 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" 
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">Ongoing developments:<br />
                                    SARDP, PMGSY, and Shillong<br />
                                    Smart-city programs</p>
                            </div>
                        </div>
                    </section>
                    <%--<ul>
                        <li>1.	Road Network: 13,000 km</li>
                        <li>2.	Road Density: 0.48 km/sq. km density</li>
                        <li>3.	Ongoing developments: SARDP, PMGSY, and Shillong Smart-city program</li>
                    </ul>--%>
                    <h4>Rail Connectivity :</h4>
                    <section class="service-style-four">
                        <div class="container">
                            <div class="inner-container" style="text-align: center;">
                                <img src="assets/assetsnew/images/info/train.jpg" style="width: 40%;">
                                <div class="train1">
                                <p class="road1234 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" 
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">Railhead at<br />
                                    Mendipathar</p>
                                    </div>
                                 <div class="train2">
                                <p class="road2235 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" 
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">Regular service connecting<br />
                                    Mendipathar and Guwahati<br />
                                    density</p>
                                     </div>
                                      <div class="train3">
                                <p class="road3236 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" 
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">Ongoing projects linking Meghalaya<br />
                                    with Manipur, Mizoram, Nagaland<br />
                                    , and Sikkim</p>
                                          </div>
                            </div>
                        </div>
                    </section>
                    
                    <h4>Aviation Connectivity :</h4>
                    
                    <section class="service-style-four" style="padding-top: 0px !important;">
                        <div class="container">
                            <div class="inner-container" style="text-align: center;">
                                <img src="assets/assetsnew/images/info/flight.png" style="width: 40%;">
                                <p class="road1112 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" 
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">Airport at Umroi<br />
                                    (30 km from Shillong)</p>
                                <p class="road2112 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" 
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">Helicopter service connecting<br />
                                    Shillong to Guwahati and Tura<br />
                                    density</p>
                                <p class="road3112 wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" 
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">Guwahati airport<br />
                                    (118 km from Shillong)</p>
                                <p class="road4114  wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" 
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">Additional helipads and heliports<br />
                                    planned across the state</p>
                            </div>
                        </div>
                    </section>
                    <h3>Unique Strengths and Opportunities</h3>
                    <p>Meghalaya presents abundant opportunities for growth and development across various sectors. From its natural resources to emerging industries, the state offers a fertile ground for investment and progress. </p>
                    <%--<img src="assets/assetsnew/images/uso.gif" alt="SPDP" style="margin-left: 0px;" />--%>

                    <section class="project-section case-page-3 p-0 pt-2">
                        <div class="large-container">
                            <div class="row">
                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="project-block-one wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" 
                                        style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                        <div class="inner-box">

                                            <div class="lower-content">
                                                <%--<div class="count-number">01</div>--%>
                                                <h3><a href="case-single.html">Natural Resources</a></h3>
                                                <div class="text">Abundant flora, fauna, forests, medicinal plants, minerals (coal, limestone, quartz, feldspar, granite, industrial clay, sillimanite, uranium)</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="project-block-one wow fadeInUp animated" data-wow-delay="200ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 200ms; animation-name: fadeInUp;">
                                        <div class="inner-box">

                                            <div class="lower-content">
                                                <%--<div class="count-number">02</div>--%>
                                                <h3><a href="case-single.html">Agriculture and Horticulture</a></h3>
                                                <div class="text">High-value crops like Strawberry, Ginger, Lakadong turmeric, Honey, black pepper, Potato, Jackfruit, Pineapple, Areca Nut, and exotic flowers</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="project-block-one wow fadeInUp animated" data-wow-delay="400ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 400ms; animation-name: fadeInUp;">
                                        <div class="inner-box">

                                            <div class="lower-content">
                                                <%--<div class="count-number">03</div>--%>
                                                <h3><a href="case-single.html">Organic Produce</a></h3>
                                                <div class="text">Most state produce is naturally organic</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                                    <div class="project-block-one wow fadeInUp animated" data-wow-delay="600ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 600ms; animation-name: fadeInUp;">
                                        <div class="inner-box">

                                            <div class="lower-content">
                                                <%-- <div class="count-number">04</div>--%>
                                                <h3><a href="case-single.html">Industrial Potential</a></h3>
                                                <div class="text">Mineral-based industry, horticulture and agro-based industry, electronics and IT, export-oriented units, tourism, and emerging service sectors</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </section>
                    <h3>Meghalaya Growth Path:</h3>


                    <img src="assets/assetsbeta/images/growrth.png" alt="Growth pic" />
                    <h3>The State of Meghalaya has several GI tags:</h3>
                     <section class="">
        <div class="container">
                    <div class="four-item-carousel owl-carousel owl-theme">
                <div class="team-block-two">
                    <div class="inner-box">
                        <figure class="image-box"><a href="#"><img src="assets/assetsnew/images/sp/1.png" alt=""></a></figure>
                        
                        <%--<div class="lower-content">
                            <h4><a href="#">Park bo young</a></h4>
                            <span class="designation">Senior Enginer</span>
                        </div>--%>
                    </div>
                </div>
                <div class="team-block-two">
                    <div class="inner-box">
                        <figure class="image-box"><a href="#"><img src="assets/assetsnew/images/sp/2.png" alt=""></a></figure>
                       <%-- <div class="lower-content">
                            <h4><a href="#">Chan wook</a></h4>
                            <span class="designation">Senior Factory Manager</span>
                        </div>--%>
                    </div>
                </div>
                <div class="team-block-two">
                    <div class="inner-box">
                        <figure class="image-box"><a href="#"><img src="assets/assetsnew/images/sp/3.png" alt=""></a></figure>
                        <%--<div class="lower-content">
                            <h4><a href="#">Mahfuz Riad</a></h4>
                            <span class="designation">Senior LOTT</span>
                        </div>--%>
                    </div>
                </div>
                <div class="team-block-two">
                    <div class="inner-box">
                        <figure class="image-box"><a href="#"><img src="assets/assetsnew/images/sp/4.png" alt=""></a></figure>
                        <%--<div class="lower-content">
                            <h4><a href="#">Jhon Rook</a></h4>
                            <span class="designation">Junior Enginer</span>
                        </div>--%>
                    </div>
                </div>
                        <div class="team-block-two">
                    <div class="inner-box">
                        <figure class="image-box"><a href="#"><img src="assets/assetsnew/images/sp/5.png" alt=""></a></figure>
                       <%-- <div class="lower-content">
                            <h4><a href="#">Jhon Rook</a></h4>
                            <span class="designation">Junior Enginer</span>
                        </div>--%>
                    </div>
                </div>
            </div>
            </div>
                         </section>
                    <%--<div class="col-md-12 d-flex msgi">
                        <div class="col-md-2 wow fadeInUp animated" data-wow-delay="600ms" data-wow-duration="1500ms"
                            style="visibility: visible; animation-duration: 1500ms; animation-delay: 600ms; animation-name: fadeInDown;">
                            <p>Khasi Lakadong Turmeric</p>
                        </div>
                        <div class="col-md-2 wow fadeInUp animated" data-wow-delay="600ms" data-wow-duration="1500ms"
                            style="visibility: visible; animation-duration: 1500ms; animation-delay: 600ms; animation-name: fadeInUp;">
                            <p>Khasi Mandarin</p>
                        </div>
                        <div class="col-md-2 wow fadeInUp animated" data-wow-delay="600ms" data-wow-duration="1500ms"
                            style="visibility: visible; animation-duration: 1500ms; animation-delay: 600ms; animation-name: fadeInDown;">
                            <p>Memong Narang</p>
                        </div>
                        <div class="col-md-2 wow fadeInUp animated" data-wow-delay="600ms" data-wow-duration="1500ms"
                            style="visibility: visible; animation-duration: 1500ms; animation-delay: 600ms; animation-name: fadeInUp;">
                            <p>Garo dakmanda (Meghalaya Garo Textile)</p>
                        </div>
                        <div class="col-md-4 wow fadeInUp animated" data-wow-delay="600ms" data-wow-duration="1500ms"
                            style="visibility: visible; animation-duration: 1500ms; animation-delay: 600ms; animation-name: fadeInDown;">
                            <p>Meghalaya Lyrnai Pottery and Meghalaya Chubitchi (alcoholic beverage)</p>
                        </div>
                    </div>--%>


                </div>
            </div>

        </div>
    </section>

</asp:Content>
