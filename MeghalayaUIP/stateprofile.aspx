<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="stateprofile.aspx.cs" Inherits="MeghalayaUIP.stateprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel='stylesheet' href='https://cdn-uicons.flaticon.com/2.4.2/uicons-thin-rounded/css/uicons-thin-rounded.css'>
    <style>
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
                    <p>Located in India's North-Eastern Region (NER), Meghalaya, fondly referred to as the "Abode of Clouds," holds significant strategic importance that offers unique economic opportunities to drive regional growth. .</p>
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
                                <div class="text">Area<br />&nbsp;</div>
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
                                <div class="text">Youth <br />Population</div>
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
                                <div class="text">Urban<br /> Population</div>
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
                                <div class="text">Rural <br />Population</div>
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
                    <%--<ul>
                        <li><i class="fi fi-br-star-shooting"></i>Area: 22, 429 sq. km.</li>

                        <li><i class="fi fi-br-star-shooting"></i>Total Population (2011): 29.7 L.</li>
                        <li><i class="fi fi-br-star-shooting"></i>Forest Cover (2021): 76%.</li>
                        <li><i class="fi fi-br-star-shooting"></i>Air Quality: 33 (AQI of capitals).</li>
                        <li><i class="fi fi-br-star-shooting"></i>Literacy rate (2011): 75.5%.</li>
                        <li><i class="fi fi-br-star-shooting"></i>Sex Ratio (Per 1000 males): 989.0.</li>
                        <li><i class="fi fi-br-star-shooting"></i>Youth Population: 11.11 L.</li>
                        <li><i class="fi fi-br-star-shooting"></i>Urban Population: 23.7 L.</li>
                        <li><i class="fi fi-br-star-shooting"></i>Rural Population: 6 L.</li>
                        <li><i class="fi fi-br-star-shooting"></i>Mobile Connections per 100 Person: 76 (2023) .</li>
                        <li><i class="fi fi-br-star-shooting"></i>Internet subscribers per 100 population: 59 (2023).</li>
                    </ul>--%>
                    <%--<p><b>Key Demographic:</b></p>--%>
                    <%--<ul>
                        <li><i class="fi fi-br-star-shooting"></i>Export Growth: 6.8% (2017 to 2022).</li>
                        <li><i class="fi fi-br-star-shooting"></i>GSDP: $5.9Bn (2024).</li>
                        <li><i class="fi fi-br-star-shooting"></i>GSDP: Rs. 52,9773 crore or 6.6 billion US dollar (2024-2025-Projected).</li>
                        <li><i class="fi fi-br-star-shooting"></i>GSDP Growth: 11.4% (2023 to 2025).</li>

                        <li><i class="fi fi-br-star-shooting"></i>Per Capita GSDP: 1.39602 L.</li>
                        <li><i class="fi fi-br-star-shooting"></i>Labour force participation rate: 60%.</li>
                        <li><i class="fi fi-br-star-shooting"></i>Women’s participation in the workforce (Rural): 34%.</li>
                        <li><i class="fi fi-br-star-shooting"></i>Women’s participation in the workforce (Urban):24% .</li>
                    </ul>--%>


                    <section class="service-style-four service-page-3 centred p-0">
        <div class="container">
            <div class="inner-container">
                <h4 style="text-align:left;">Key Demographic</h4>
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
                    <p><b>Meghalaya Growth Path: -</b></p>

                    <img src="assets/assetsbeta/images/growrth.png" alt="Growth pic" />
                    <h3>Connectivity</h3>
                    <p>Meghalaya's connectivity is key to its development. With extensive road, rail, and air networks, the state ensures seamless transportation for growth and accessibility.</p>

                    <h4>Road Connectivity :</h4>
                    <ul>
                        <li>1.	Road Network: 13,000 km</li>
                        <li>2.	Road Density: 0.48 km/sq. km density</li>
                        <li>3.	Ongoing developments: SARDP, PMGSY, and Shillong Smart-city program</li>
                    </ul>
                    <h4>Rail Connectivity :</h4>
                    <ul>
                        <li>1.	Railhead at Mendipathar</li>
                        <li>2.	Regular service connecting Mendipathar and Guwahati</li>
                        <li>3.	Ongoing projects linking Meghalaya with Manipur, Mizoram, Nagaland, and Sikkim</li>
                    </ul>
                    <h4>Aviation Connectivity :</h4>
                    <ul>
                        <li>1.	Airport at Umroi (30 km from Shillong)</li>
                        <li>2.	Helicopter service connecting Shillong to Guwahati and Tura</li>
                        <li>3.	Guwahati airport (118 km from Shillong)</li>
                        <li>4.	Additional helipads and heliports planned across the state</li>
                    </ul>
                    <%--<h3>Meghalaya’s key/priority sectors are:</h3>
                    <p>Explore the cornerstone of Meghalaya's economic landscape through its key priority sectors. From Tourism to Power, delve into the diverse industries propelling the State's development forward.</p>
                    <ul>
                        <li>1.	Hotels & Hospitality</li>
                        <li>2.	Tourism (Homestays, Adventure, Health Tourism, Eco-Tourism & MICE)</li>
                        <li>3.	Education (Vocational & Digital/e-learning)</li>
                        <li>4.	Bio-Technology</li>

                        <li>5.	Fin-tech & Financial Services </li>
                        <li>6.	Healthcare (Secondary and Tertiary) Information </li>
                        <li>7.	IT & ITES</li>
                        <li>8.	Business process outsourcing (BPO)</li>

                        <li>9.	EV Charging Station</li>
                        <li>10.	Tech-oriented start-ups/units providing services in the field of Education, Primary Healthcare and Agriculture</li>
                        <li>11.	Food Processing </li>
                        <li>12.	Power Generation</li>

                        <li>13.	Music, Film & Entertainment</li>
                        <li>14.	Logistics</li>
                        <li>15.	Green Startups</li>
                        <li>16.	Others & any other industry notified by the Government of Meghalaya</li>
                    </ul>--%>
                    <h3>Unique Strengths and Opportunities</h3>
                    <p>Meghalaya presents abundant opportunities for growth and development across various sectors. From its natural resources to emerging industries, the state offers a fertile ground for investment and progress. </p>
                    <%--<img src="assets/assetsnew/images/uso.gif" alt="SPDP" style="margin-left: 0px;" />--%>

                    <section class="project-section case-page-3 p-0 pt-2">
        <div class="large-container">
            <div class="row">
                <div class="col-lg-3 col-md-6 col-sm-12 project-block">
                    <div class="project-block-one wow fadeInUp animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                        <div class="inner-box">
                           
                            <div class="lower-content">
                                <div class="count-number">01</div>
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
                                <div class="count-number">02</div>
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
                                <div class="count-number">03</div>
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
                                <div class="count-number">04</div>
                                <h3><a href="case-single.html">Industrial Potential</a></h3>
                                <div class="text">Mineral-based industry, horticulture and agro-based industry, electronics and IT, export-oriented units, tourism, and emerging service sectors</div>
                            </div>
                        </div>
                    </div>
                </div>
               
            </div>
        </div>
    </section>
                    <%-- <ul>
                        <li>1.	: . </li>
                        <li>2.	Agriculture and Horticulture: High-value crops like Strawberry, Ginger, Lakadong turmeric, Honey, black pepper, Potato, Jackfruit, Pineapple, Areca Nut, and exotic flowers</li>
                        <li>3.	Organic Produce: Most state produce is naturally organic</li>
                        <li>4.	Industrial Potential: Mineral-based industry, horticulture and agro-based industry, electronics and IT, export-oriented units, tourism, and emerging service sectors</li>
                    </ul>--%>
                    <p><b>The State of Meghalaya has several GI tags:</b></p>
                    <p>Khasi Lakadong Turmeric, Khasi Mandarin, Memong Narang, Garo dakmanda (Meghalaya Garo Textile), Meghalaya Lyrnai Pottery and Meghalaya Chubitchi (alcoholic beverage)</p>
                    

                    
                    <%--<ul>
                        <li>1.	Political Stability: Stable environment</li>
                        <li>2.	GSDP Growth: Strong growth in recent years</li>
                        <li>3.	Human Resources: Literate and trainable workforce</li>
                        <li>4.	Gender Development Index: High performance</li>

                        <li>5.	Tourism: Several attractions </li>
                        <li>6.	Cultural Richness: Ethnic tribal culture with unique customs </li>
                        <li>7.	Natural Reserves: Rich bamboo and forest reserves</li>
                        <li>8.	Mineral Resources: Extensive, including coal and limestone</li>

                        <li>9.	Agricultural Resources: Abundant and diverse</li>
                        <li>10.	Handloom and Weaving: Local community skills</li>
                        <li>11.	Hydro-power: High availability</li>
                        <li>12.	Climate: Ideal for electronics development</li>

                        <li>13.	Environment: Safe, clean, and pollution-free</li>
                        <li>14.	Micro Enterprises: Strong base in traditional crafts and agriculture</li>
                        
                    </ul>--%>
                    <h3>Why Invest in Meghalaya?</h3>
                    <p>Investing in Meghalaya presents a compelling choice backed by lucrative investment incentives. The state's commitment to Ease of Doing Business initiatives ensures a streamlined regulatory framework, minimizing compliance hurdles for investors. Additionally, Meghalaya offers attractive incentives such as tax exemptions, subsidies, and land lease options, fostering a conducive environment for investment across sectors like tourism, agriculture, and renewable energy.</p>


                    <br />
                    <br />
                    <img src="assets/assetsbeta/images/advantagemeg.png" />
                </div>
            </div>

        </div>
    </section>

</asp:Content>
