<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeBeta.aspx.cs" Inherits="MeghalayaUIP.HomeBeta" %>

<!DOCTYPE html>
<html lang="en">


<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="author" content="irstheme">

    <title>Invest Meghalaya</title>

    <link href="assets/assetsbeta/css/themify-icons.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/flaticon.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/bootstrap.min.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/animate.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/owl.carousel.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/owl.theme.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/slick.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/slick-theme.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/swiper.min.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/odometer-theme-default.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/owl.transitions.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/jquery.fancybox.css" rel="stylesheet">
    <link href="assets/assetsbeta/css/style.css" rel="stylesheet">
    <link href="assets/assetsbeta/swiper/swiper-bundle.min.css" rel="stylesheet">
    <link rel="stylesheet"
        href="https://cdn-uicons.flaticon.com/2.2.0/uicons-bold-rounded/css/uicons-bold-rounded.css" />
    <link rel='stylesheet' href='https://cdn-uicons.flaticon.com/2.2.0/uicons-brands/css/uicons-brands.css'>


    <style>
        .navbar-nav {
            float: right;
        }

        .topbar {
            background: #131e4a;
            background-color: #4158D0;
            background-image: radial-gradient(circle 975px at 2.6% 48.3%, rgba(0, 8, 120, 1) 0%, rgba(95, 184, 224, 1) 99.7%);
        }

        .contact-info ul {
            float: right;
            color: #fff;
            font-size: 15px;
            font-size: 0.9375rem;
            display: flex;
            padding: 4px 0px 18px;
        }

            .contact-info ul li {
                padding: 0px 10px;
            }

        .topbar p {
            color: #ccc;
            margin: 4px 0px;
        }

        /* .slide-inner.slide-bg-image:before {
     content: "";
     background: -webkit-linear-gradient(0deg, rgb(2 32 74) 40%, rgba(255, 255, 255, 0.6) 100%);
     position: absolute;
     bottom: 0;
     top: 0;
     left: 0;
     right: 0;
 } */

        .navbar > .container .navbar-brand,
        .navbar > .container-fluid .navbar-brand {
            margin-left: 10px;
        }

        /* .blink {
     animation: blinker 1.2s linear infinite;
     color: #23aeae;
     font-family: system-ui;
     font-weight: 600;
     font-size: 25px;
     z-index: 9999;
     position: absolute;
     top: 8.8%;
     left: 8%;
 }

 @keyframes blinker {
     20% {
  opacity: 1;
  color: brown;
     }

     60% {
  opacity: 1;
  color: blueviolet;
     }

     90% {
  opacity: 1;
  color: blue;
     }
 } */

        i.fi.fi-br-chevron-double-down {
            font-size: 11px;
        }

        nav.navigation.navbar.navbar-default.sticky-header.sticky-on li a {
            color: #fff !important;
        }

        p.px-4.btn.btn-primary.btn-custom.login-homepage {
            position: absolute;
            right: 48px;
            top: 3.5px;
            z-index: 9999;
        }

            p.px-4.btn.btn-primary.btn-custom.login-homepage a {
                color: #fff;
                text-decoration: none;
            }
    </style>
    <style>
        .keralaMap {
            padding: 125px 0 40px;
            background-position: center bottom;
            background-repeat: no-repeat;
            background-size: cover;
        }

            .keralaMap .keralaMapArea {
                display: grid;
                grid-template-columns: 330px 1fr;
            }

                .keralaMap .keralaMapArea .map .mapSvg {
                    position: absolute;
                    left: 20px;
                    top: 0;
                    bottom: 0;
                    right: 0;
                    z-index: 2;
                }

                    .keralaMap .keralaMapArea .map .mapSvg .districts {
                        cursor: pointer;
                    }

                .keralaMap .keralaMapArea .map .circle {
                    width: 324px;
                    height: 324px;
                    border-radius: 50%;
                    position: absolute;
                    left: 37px;
                    top: 13%;
                    bottom: 0;
                    right: 0;
                    z-index: 0;
                    background-color: #F6F6F6;
                }

                .keralaMap .keralaMapArea .map .mapPng {
                    z-index: 1;
                    position: relative;
                }

                .keralaMap .keralaMapArea .textarea {
                    padding-left: 110px;
                }

                    .keralaMap .keralaMapArea .textarea .details {
                        display: block;
                    }

        .d-none {
            display: none !important;
        }

        .keralaMap .keralaMapArea .textarea .details .content .title {
            font-size: 35px;
            font-weight: 600;
            line-height: 35px;
            color: var(--c2d);
            border-bottom: 2px solid var(--theme-colour1);
            padding-bottom: 11px;
            display: inline-block;
            margin-bottom: 17px;
            max-width: 586px;
        }

        .keralaMap .keralaMapArea .textarea .details .content .subtitle {
            font-size: 24px;
            font-weight: 500;
            line-height: 35px;
            color: var(--c16);
            margin-bottom: 15px;
            max-width: 586px;
            width: 100%;
        }

        .keralaMap .keralaMapArea .textarea .details .content p {
            margin: 0 0 17px;
            max-width: 586px;
            width: 100%;
        }

        .keralaMap .keralaMapArea .textarea .labelSec {
            display: block;
        }

            .keralaMap .keralaMapArea .textarea .labelSec ul {
                margin: 24px 0 0;
                padding: 0;
                display: flex;
                align-items: center;
                flex-wrap: wrap;
                max-width: 770px;
            }

                .keralaMap .keralaMapArea .textarea .labelSec ul li {
                    font-size: 12px;
                    font-weight: 500;
                    line-height: 14px;
                    color: var(--c39);
                    list-style: none;
                    width: 105px;
                    height: 40px;
                    border-radius: 8px;
                    display: flex;
                    align-items: center;
                    justify-content: center;
                    border: 1px solid var(--c16);
                    background-color: var(--white);
                    margin-right: 4px;
                    margin-bottom: 11px;
                    transition: ease-in-out .4s;
                    cursor: pointer;
                }

                    .keralaMap .keralaMapArea .textarea .labelSec ul li.active {
                        color: var(--white);
                        background-color: var(--theme-colour1-dark);
                        border: 1px solid var(--theme-colour1-dark);
                    }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <!-- start page-wrapper -->
        <div class="page-wrapper">

            <!-- start preloader -->
            <div class="preloader">
                <div class="loader">
                    <div class="gear two">
                        <svg viewbox="0 0 100 100" fill="#131e4a">
                            <path
                                d="M97.6,55.7V44.3l-13.6-2.9c-0.8-3.3-2.1-6.4-3.9-9.3l7.6-11.7l-8-8L67.9,20c-2.9-1.7-6-3.1-9.3-3.9L55.7,2.4H44.3l-2.9,13.6      c-3.3,0.8-6.4,2.1-9.3,3.9l-11.7-7.6l-8,8L20,32.1c-1.7,2.9-3.1,6-3.9,9.3L2.4,44.3v11.4l13.6,2.9c0.8,3.3,2.1,6.4,3.9,9.3      l-7.6,11.7l8,8L32.1,80c2.9,1.7,6,3.1,9.3,3.9l2.9,13.6h11.4l2.9-13.6c3.3-0.8,6.4-2.1,9.3-3.9l11.7,7.6l8-8L80,67.9      c1.7-2.9,3.1-6,3.9-9.3L97.6,55.7z M50,65.6c-8.7,0-15.6-7-15.6-15.6s7-15.6,15.6-15.6s15.6,7,15.6,15.6S58.7,65.6,50,65.6z">
                            </path>
                        </svg>
                    </div>
                    <div class="gear three">
                        <svg viewbox="0 0 100 100" fill="#fd5f17">
                            <path
                                d="M97.6,55.7V44.3l-13.6-2.9c-0.8-3.3-2.1-6.4-3.9-9.3l7.6-11.7l-8-8L67.9,20c-2.9-1.7-6-3.1-9.3-3.9L55.7,2.4H44.3l-2.9,13.6      c-3.3,0.8-6.4,2.1-9.3,3.9l-11.7-7.6l-8,8L20,32.1c-1.7,2.9-3.1,6-3.9,9.3L2.4,44.3v11.4l13.6,2.9c0.8,3.3,2.1,6.4,3.9,9.3      l-7.6,11.7l8,8L32.1,80c2.9,1.7,6,3.1,9.3,3.9l2.9,13.6h11.4l2.9-13.6c3.3-0.8,6.4-2.1,9.3-3.9l11.7,7.6l8-8L80,67.9      c1.7-2.9,3.1-6,3.9-9.3L97.6,55.7z M50,65.6c-8.7,0-15.6-7-15.6-15.6s7-15.6,15.6-15.6s15.6,7,15.6,15.6S58.7,65.6,50,65.6z">
                            </path>
                        </svg>
                    </div>
                </div>
            </div>
            <!-- end preloader -->



            <!-- Start header -->
            <header id="header" class="site-header header-style-1">
                <!-- <div class="topbar">
  <div class="container">
      <div class="row">
   <div class="col col-sm-6" style="display: flex;">
       <p>Government of Meghalaya</p>
       <div class="contact-info">
    <ul>

        <li style="padding-top: 2px;"><i class="fi fi-brands-facebook"></i></li>
        <li style="padding-top: 2px;"><i class="fi fi-brands-youtube"></i></li>
        <li style="padding-top: 2px;"><i class="fi fi-brands-twitter-alt-circle"></i></li>
        <li style="padding-top: 2px;"><i class="fi fi-brands-linkedin"></i></li>
    </ul>
       </div>
   </div>
   <div class="col col-sm-6">
       <div class="contact-info">
    <ul>
        <li>About Meghalaya</li>
        <li>&nbsp;</li>

    </ul>
       </div>
   </div>
      </div>
  </div>
     </div> -->
                <nav class="navigation navbar navbar-default">
                    <div class="container-fluid">
                        <div class="navbar-header">
                            <button type="button" class="open-btn">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <a class="navbar-brand" href="homebeta.aspx">
                                <img src="assets/assetsbeta/images/Logo_dark.png" alt=""
                                    style="margin-top: 6px;"></a>
                        </div>
                        <div id="navbar" class="navbar-collapse collapse navigation-holder">
                            <button class="close-navbar"><i class="ti-close"></i></button>
                            <ul class="nav navbar-nav">
                                <li class="menu-item-has-children">
                                    <a href="Homebeta.aspx">Home</a>
                                </li>

                                <li class="menu-item-has-children">
                                    <a href="#">Why Meghalaya <i class="fi fi-br-chevron-double-down"></i></a>
                                    <ul class="sub-menu">
                                        <li><a href="stateprofile.aspx">State Profile</a></li>
                                        <li><a href="EODB.aspx">Ease of Doing Business</a></li>
                                    </ul>
                                </li>
                                <li class="menu-item-has-children">
                                    <a href="#">Investment opportunities <i class="fi fi-br-chevron-double-down"></i></a>
                                    <ul class="sub-menu">
                                        <li><a href="Documents/Meghalaya%20Next%20Vision%202028.pdf">Meghalaya Next Vision
                                            2028</a></li>
                                    </ul>
                                </li>
                                <li class="menu-item-has-children">
                                    <a href="#">Policy Framework <i class="fi fi-br-chevron-double-down"></i></a>
                                    <ul class="sub-menu">
                                        <li><a href="Documents/MIIPP%202024.pdf" class="text-black">MIIPP, 2024</a></li>
                                        <li><a href="Documents/Meghalaya Tourism.pdf" class="text-black"
                                            target="_blank">Meghalaya Tourism Policy</a></li>

                                        <li><a href="Documents/IT Policy 2024.pdf" class="text-black"
                                            target="_blank">IT/ITES Policy 2024</a></li>
                                        <li><a href="Documents/Meghalaya Power Policy.pdf" class="text-black">Meghalaya
                                            Power Policy, 2024</a></li>
                                        <li class="menu-item-has-children">
                                            <a href="#">Others</a>
                                            <ul class="sub-menu">
                                                <li><a href="Documents/Procure MSME.pdf" class="text-black">Meghalaya
                                                    Procurement Preference Policy for Micro and small Enterprises,
                                                    2020</a></li>
                                                <li><a href="Documents/Meghalaya Startup Policy.pdf" class="text-black"
                                                    target="_blank">Meghalaya Start up Policy,2018</a></li>
                                                <li><a href="Documents/Mines and Minerals Policy.pdf" class="text-black"
                                                    target="_blank">Meghalaya Mines and Minerals Policy, 2012</a></li>
                                                <li><a href="Documents/Education Policy.pdf" class="text-black"
                                                    target="_blank">Meghalaya State Education Policy, 2018</a></li>
                                                <li><a href="Documents/Health Policy.pdf" class="text-black"
                                                    target="_blank">Meghalaya Health Policy, 2021</a></li>
                                                <li><a href="Documents/Telecom infrastructure Policy.pdf" class="text-black"
                                                    target="_blank">Meghalaya Telecom Infrastructure Policy, 2018</a>
                                                </li>
                                                <li><a href="Documents/Organic Farming policy.pdf" class="text-black"
                                                    target="_blank">Meghalaya State Organic Farming Policy,2023</a></li>
                                                <li><a href="Documents/Sports Policy.pdf" class="text-black"
                                                    target="_blank">Meghalaya State Sports Policy, 2019</a></li>
                                                <li><a href="Documents/PPP Policy.pdf" class="text-black"
                                                    target="_blank">Meghalaya Public Private Partnership Policy (PPP),
                                                    2021</a></li>
                                                <li><a href="Documents/EV Policy.pdf" class="text-black"
                                                    target="_blank">Meghalaya Electronic Vehicle Policy, 2021</a></li>
                                                <li><a href="Documents/" class="text-black" target="_blank">Industrial and
                                                    Investment Promotion Policy,2024</a></li>
                                            </ul>
                                        </li>

                                    </ul>
                                </li>

                                <li class="menu-item-has-children">
                                    <a href="#">Services <i class="fi fi-br-chevron-double-down"></i></a>
                                    <ul class="sub-menu">
                                        <li><a href="IntentInvest.aspx">Intent to Invest</a></li>
                                        <li><a href="login.aspx">Registration Under MIIPP 2024</a></li>
                                        <li><a href="InformationWizard.aspx">Information Wizard</a></li>
                                        <li><a href="RenewalServices.aspx">Auto Renewal</a></li>
                                        <li><a href="OtherService.aspx">Other Services</a></li>
                                    </ul>
                                </li>
                                <li class="menu-item-has-children">
                                    <a href="#">Resources <i class="fi fi-br-chevron-double-down"></i></a>
                                    <ul class="sub-menu">
                                        <li><a href="https://mspsdc.meghalaya.gov.in/dashboard1.htm" target="_blank">Dashboard</a></li>
                                        <li><a href="Notifications.aspx">Notifications</a></li>
                                        <li><a href="Faq.aspx">FAQs</a></li>
                                        <li><a href="Contact.aspx">Contact</a></li>
                                    </ul>
                                </li>
                                <li class="menu-item-has-children">
                                    <a href="#">Login <i class="fi fi-br-chevron-double-down"></i></a>
                                    <ul class="sub-menu">
                                        <li><a href="login.aspx">User Login</a></li>
                                        <li><a href="Deptlogin.aspx">Dept. Login</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>


                    </div>
                </nav>
            </header>



            <!-- end of header -->

            <!--Start the Body Part-->


            <!-- start of hero -->
            <section class="hero-slider hero-style-1">
                <div class="swiper-container">
                    <div class="swiper-wrapper">
                        <div class="swiper-slide">
                            <div class="slide-inner slide-bg-image" data-background="assets/assetsbeta/images/slider/slide-7_1.jpg">
                            </div>
                            <!-- end slide-inner -->
                        </div>
                        <!-- end swiper-slide -->

                        <div class="swiper-slide">
                            <div class="slide-inner slide-bg-image" data-background="assets/assetsbeta/images/slider/slide-5.jpg">
                            </div>
                            <!-- end slide-inner -->
                        </div>
                        <!-- end swiper-slide -->
                        <div class="swiper-slide">
                            <div class="slide-inner slide-bg-image" data-background="assets/assetsbeta/images/slider/slide-8.jpg">
                            </div>
                            <!-- end slide-inner -->
                        </div>
                        <!-- end swiper-slide -->
                    </div>
                    <!-- end swiper-wrapper -->

                    <!-- swipper controls -->
                    <div class="swiper-pagination"></div>
                    <div class="swiper-button-next"></div>
                    <div class="swiper-button-prev"></div>
                </div>
            </section>
            <!-- end of hero slider -->
            <section class="about-us-section1">
                <div class="container">
                    <div class="row">
                        <div class="col col-xs-12 text-center bgview">

                            <h3>Welcome to Invest Meghalaya</h3>
                            <p>
                                Empowering Investor at every stage of their journey.<br />
                                Set up your business in Meghalaya with ease- now one of the fastest growing business
                            destination in North- East India.
                            </p>
                        </div>
                    </div>

                </div>
            </section>

            <section class="service-section section-padding" style="padding: 30px 0px 0px;">
                <div class="container-fluid">
                    <div class="row">

                        <div class="col col-md-12 text-center">
                            <p style="font-size: 20px; font-family: sans-serif;">
                                <b>
                                    <span class="colorblue">Apply for Incentives</span> for your business under <span
                                        class="colorblue">Uttar Poorva Transformative Industrialization Scheme (UNNATI), 2024
                                and Meghalaya Industrial and<br />
                                        Investment Promotion Policy (MIIPP) 2024</span> to make
                            your business more profitable.</b>
                            </p>
                            <p style="font-size: 20px; font-family: sans-serif; font-weight: 600;text-align:center;color:#070799;">
                                <%--<i class="fi fi-ts-rocket-lunch"></i>--%>
                                <%--<img src="assets/assetsbeta/images/new.gif" style="width: 35px; height: 22px;" />--%>
                                *Registration open till <span class="colorblue">31st March 2026</span></p>

                        </div>

                    </div>
                </div>
            </section>

            <section class="about-us-section2">
                <div class="container">
                    <div class="row">
                        <p style="margin-top: 20px; text-align: center" class="head1">Empowering Businesses, Empowering you..</p>
                        <div class="col col-xs-12 text-center">

                            <div class="col-md-5 bgcirle1 text-center" type="button" class="btn btn-primary" data-toggle="modal"
                                data-target=".exampleModalCenter">
                                <div class="col-md-4 text-center">
                                    <img src="assets/assetsbeta/images/circle1.png">
                                </div>
                                <div class="col-md-8 text-center">
                                    <h3>UNNATI 2024</h3>
                                    <p>
                                        Attractive Incentives available.<br />
                                        Click here to know more.
                                    </p>
                                </div>
                            </div>
                            <div class="col-md-1">&nbsp;</div>
                            <div class="col-md-1">&nbsp;</div>

                            <div class="col-md-5 bgcirle2" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg">
                                <div class="col-md-4">
                                    <img src="assets/assetsbeta/images/circle2.png">
                                </div>
                                <div class="col-md-8 text-center">
                                    <h3>MIIPP 2024</h3>
                                    <p>
                                        Attractive Incentives available.<br />
                                        Click here to know more.
                                    </p>
                                </div>
                            </div>
                            <p style="color: #a71818; font-weight: 500; font-family: inherit; text-decoration: none; position: relative; z-index: -1;"
                                class="blinker">
                                <i class="fi fi-tr-bullseye-pointer"></i>Click here to know about incentive package based
                            on your Investment
                            </p>
                        </div>
                    </div>
                </div>
            </section>

            <section class="about-us-section3">
                <div class="container">
                    <div class="row">
                        <div class="col col-xs-12 text-center">

                            <div class="col-md-5">

                                <div class="col-md-12">
                                    <h3>INTENT TO INVEST</h3>
                                    <p>
                                        Want to Invest? Fill a simple <a href="IntentInvest.aspx" target="_blank"><span class="colorblue">Intent to Invest<br />
                                            Form</span></a> and we will get in touch. Click here.
                                    </p>
                                </div>
                            </div>
                            <div class="col-md-1 sidebar">&nbsp;</div>
                            <div class="col-md-1">&nbsp;</div>
                            <div class="col-md-5">

                                <div class="col-md-12">
                                    <h3>REGISTER</h3>
                                    <p>
                                        Register your business to claim Incentives.
                                        <br />
                                        Fill a simple <a href="Registration.aspx" target="_blank"><span class="colorblue">Registration Form</span></a>. Click here.
                                    </p>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </section>


            <section class="service-section section-padding" style="padding: 0px;">
                <div class="container-fluid">
                    <div class="row">
                        <p class="text-center head1">Easy Process to Register your Business and Claim Incentives</p>
                        <img src="assets/assetsbeta/images/flowprocess4.png" style="width: 100%;" />

                    </div>
                </div>
            </section>



            <section class="service-section5" style="padding: 0px;">
                <div class="container-fluid">
                    <div class="row">
                        <p class="text-center head1">Priority Sectors</p>
                        <div class="col col-md-12">
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-rr-bed"></i>
                                    
                                </div>
                                <p>
                                    Hotels & Hospitality
                                </p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-rr-train-journey"></i></div>
                                <p>Tourism</p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-tr-bio-leaves"></i></div>
                                <p>Bio-Technology</p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-ts-user-graduate"></i></div>
                                <p>Education</p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-tr-user-md"></i></div>
                                <p>Healthcare</p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-ts-laptop-code"></i></div>
                                <p>IT & ITeS</p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-ts-salad"></i></div>
                                <p>
                                    Food Processing
                                </p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-tr-air-pollution"></i></div>
                                <p>
                                    Power Generation
                                </p>
                            </div>

                        </div>
                        <div class="col col-md-12">
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-tr-charging-station"></i></div>
                                <p>
                                    EV Charging Station
                                </p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-ts-keynote"></i></div>
                                <p>
                                    Fin-tech & Financial Services
                                </p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-tr-user-robot"></i></div>
                                <p>
                                    Tech-oriented start-ups
                                </p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-tr-comment-alt-music"></i></div>
                                <p>
                                    Music, Films and Entertainment
                                </p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-ts-dolly-flatbed"></i></div>
                                <p>Logistics</p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-ts-customer-service"></i></div>
                                <p>BPO</p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-ts-lightbulb-dollar"></i></div>
                                <p>
                                    Green-Start-ups
                                </p>
                            </div>
                            <div class="col col-md-1">
                                <div class="box"><i class="fi fi-tr-circle-ellipsis"></i></div>
                                <p>
                                    Others as Notified

                                </p>
                            </div>

                        </div>

                    </div>
                </div>
            </section>


            <section class="about-us-section3 1" style="margin-top: 40px; margin-bottom: 45px;">
                <div class="container">
                    <div class="row">
                        <div class="col col-xs-12 text-center"
                            style="display: flex; flex-wrap: wrap; align-content: center; align-items: center;">

                            <div class="col-md-5">

                                <div class="col-md-12">
                                    <a href="login.aspx" target="_blank">
                                        <h3><i class="fi fi-br-form"></i>Apply for Clearance/ approvals for your business</h3>
                                    </a>


                                </div>
                            </div>
                            <div class="col-md-1 sidebar">&nbsp;</div>
                            <div class="col-md-1">&nbsp;</div>
                            <div class="col-md-5">

                                <div class="col-md-12">
                                    <a href="login.aspx" target="_blank">
                                        <h3><i class="fi fi-br-track"></i>Track Application Status</h3>
                                    </a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </section>

            <!-- start about-us-section -->



            <!-- trail with map Start -->

            <!-- trail with map End -->



            <!-- start cta-section -->
            <section class="cta-section">
                <div class="container">
                    <div class="row">
                        <div class="col col-lg-6 col-md-6">
                            <div class="cta-text">
                                <br />
                                <h3>For any queries, reach out to us</h3>
                            </div>
                        </div>
                        <div class="col col-lg-6 col-md-6">
                            <div class="contact-info">
                                <div>
                                    <i class="fi flaticon-call"></i>
                                    <h4>Call us</h4>
                                    <p>03564 123456</p>
                                </div>
                                <div>
                                    <i class="fi flaticon-contact"></i>
                                    <h4>Email us</h4>
                                    <p>investmeghalayaauthority@gmail.com</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end container -->
            </section>
            <!-- end cta-section -->




            <!--End of the Body Part-->

            <!-- start site-footer -->
            <footer class="site-footer">
                <div class="upper-footer">
                    <div class="container">
                        <div class="row">
                            <div class="col col-lg-6 col-md-6 col-sm-12">
                                <div class="widget contact-widget service-link-widget">
                                    <div class="widget-title">
                                        <h3>Address</h3>
                                    </div>
                                    <ul>
                                        <li>Invest Meghalaya Authority,<br />
                                            Secretariat Main Building, M.G Road,<br />
                                            Shillong - 793 001, East Khasi Hills District,<br />
                                            Meghalaya.<br />
                                        </li>

                                        <li><i class="fi fi-br-envelope"></i> <span>Email:</span>
                                            investmeghalayaauthority@gmail.com</li>

                                    </ul>
                                </div>
                            </div>
                            <div class="col col-lg-6 col-md-6 col-sm-12">
                                <div class="widget link-widget">
                                    <div class="widget-title">
                                        <h3>Quick Links</h3>
                                    </div>
                                    <ul>
                                        <li><a href="stateprofile.aspx"><i class="fi fi-br-thumbtack"></i> Why invest in Meghalaya</a></li>
                                        <li><a href="EODB.aspx"><i class="fi fi-br-thumbtack"></i> About EODB</a></li>
                                        <li><a href="#"><i class="fi fi-br-thumbtack"></i> Information Wizard</a></li>
                                        <li><a href="#"><i class="fi fi-br-thumbtack"></i> Site Map</a></li>
                                    </ul>
                                </div>
                            </div>


                        </div>
                    </div>
                    <!-- end container -->
                </div>
                <div class="lower-footer">
                    <div class="container">
                        <div class="row">
                            <div class="separator"></div>
                            <div class="col col-xs-12">
                                <p class="copyright">
                                    © 2024 Copyright Invest Meghalaya Authority. All Rights Reserved |
                                Design and Developed By CMS Computers India Pvt Ltd
                                </p>
                                <!-- <div class="extra-link">
    <ul>
        <li><a href="#">Privace & Policy</a></li>
        <li><a href="#">Terms</a></li>
        <li><a href="#">About us</a></li>
        <li><a href="#">FAQ</a></li>
    </ul>
       </div> -->
                                <div class="contact-info">
                                    <ul>

                                        <li><i class="fi fi-brands-facebook"></i></li>
                                        <li><i class="fi fi-brands-youtube"></i></li>
                                        <li><i class="fi fi-brands-twitter-alt-circle"></i></li>
                                        <li><i class="fi fi-brands-linkedin"></i></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </footer>
            <!-- end site-footer -->


        </div>
        <!-- end of page-wrapper -->


        <!-- Button trigger modal -->


        <!-- Modal -->




        <div class="modal fade exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel"
            aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h5 class="modal-title" id="exampleModalLongTitle1">
                            <img src="assets/assetsbeta/images/circle1.png" style="width: 10%; position: absolute; left: 25px; top: 7px;">
                            Uttar Poorva Transformative Industrialization Scheme (UNNATI), 2024 &nbsp;&nbsp;&nbsp;&nbsp;<span
                                style="display: contents; font-size: 14px; color: #9d9e9f; font-weight: 600; font-family: system-ui;"><a href="https://unnati.dpiit.gov.in/" target="_blank">Register on UNNATI 2024 Portal here.</a> &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<a href="Documents/unnati2024.pdf" target="_blank">Read the UNNATI 2024 scheme document here.</a></span>
                        </h5>



                    </div>
                    <div class="modal-body">
                        <p class="colorpurpule">Available Incentives</p>
                        <table class="table table-bordered modeltab1">
                            <thead>
                                <tr>
                                    <th scope="col">INCENTIVES</th>
                                    <th scope="col" style="background: #2F5596;">Where GST is applicable</th>
                                    <th scope="col" style="background: #0170C1;">Where GST is not applicable</th>


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
                                    <th scope="col">Where GST is applicable</th>
                                    <th scope="col">Where GST is not applicable</th>
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


        <!-- second model box -->
        <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel"
            aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h5 class="modal-title" id="exampleModalLongTitle">
                            <img src="assets/assetsbeta/images/circle2.png" style="width: 10%; position: absolute; left: 25px; top: 7px;" />
                            Meghalaya Industrial and Investment
                        Promotion Policy (MIIPP) 2024 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <span
                            style="display: contents; font-size: 14px; color: #9d9e9f; font-weight: 600; font-family: system-ui;"><a href="Documents/mipp2024.pdf" target="_blank">Read
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
                                    <td>
                                        <ul>
                                            <li><i class="fi fi-br-redo"></i>35 % (thirty five percent) subject to a ceiling of Rs 15 lakhs</li>
                                            <li style="height: 90px;"><i class="fi fi-br-redo"></i>Priority Sector – Ceiling of Rs 20 lakhs.</li>
                                        </ul>
                                    </td>
                                    <td>
                                        <ul>
                                            <li><i class="fi fi-br-redo"></i>30 % (thirty percent) subject to a ceiling of Rs 1 crore
                                            </li>
                                            <li style="height: 90px;"><i class="fi fi-br-redo"></i>Priority Sector – Ceiling of Rs 1.25 crores
                                            </li>
                                        </ul>
                                    </td>
                                    <td>
                                        <ul>
                                            <li><i class="fi fi-br-redo"></i>30 % (thirty percent) subject to a ceiling of Rs 3 crore
                                            </li>
                                            <li style="height: 90px;"><i class="fi fi-br-redo"></i>Priority Sector – Ceiling of Rs 5 crores
                                            </li>
                                        </ul>
                                    </td>
                                    <td>
                                        <ul>
                                            <li><i class="fi fi-br-redo"></i>25 % (twenty five percen) subject to a ceiling of Rs 6 crore
                                            </li>
                                            <li style="height: 90px;"><i class="fi fi-br-redo"></i>Priority Sector – Ceiling of Rs 10 crores
                                            </li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">Interest Subvention Subsidy</th>
                                    <td>
                                        <ul>
                                            <li><i class="fi fi-br-redo"></i>7.5% subsidy on term loans interest subject to a maximum ceiling of ₹5 lakhs
                                            for a period of 3 years from the date of disbursement of loans.</li>
                                            <li style="height: 50px;"><i class="fi fi-br-redo"></i>Priority Sector – Ceiling of 5 years</li>
                                        </ul>
                                    </td>

                                    <td>
                                        <ul>
                                            <li><i class="fi fi-br-redo"></i>6% subsidy on term loans interest subject to a maximum ceiling of ₹7 lakhs
                                            for a period of 3 years from the date of disbursement of loans.</li>
                                            <li style="height: 50px;"><i class="fi fi-br-redo"></i>Priority Sector – Ceiling of 5 years</li>
                                        </ul>
                                    </td>

                                    <td colspan="2">
                                        <ul>
                                            <li><i class="fi fi-br-redo"></i>5% subsidy on term loans interest subject to a maximum ceiling of ₹25 lakhs
                                            for a period of 3 years from the date of disbursement of loans.</li>
                                            <li style="height: 50px;"><i class="fi fi-br-redo"></i>Priority Sector – Ceiling of 5 years</li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">Net SGST Reimbursement</th>
                                    <td>
                                        <ul>
                                            <li style="height: 110px;"><i class="fi fi-br-redo"></i>100% Net SGST for a period of 15 years from the date of commercial
                                            production subject to a ceiling of 200% of FCI.
                                            </li>

                                        </ul>
                                    </td>

                                    <td>
                                        <ul>
                                            <li style="height: 110px;"><i class="fi fi-br-redo"></i>100% Net SGST for a period of 15 years from the date of commercial
                                            production subject to a ceiling of 180% of FCI.
                                            </li>
                                        </ul>
                                    </td>

                                    <td colspan="2">
                                        <ul>
                                            <li style="height: 110px;"><i class="fi fi-br-redo"></i>100% Net SGST for a period of 15 years from the date of commercial
                                            production subject to a ceiling of 150% of FCI.
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
        <!-- All JavaScript files
    ================================================== -->
        <script src="assets/assetsbeta/js/jquery.min.js"></script>
        <script src="assets/assetsbeta/js/bootstrap.min.js"></script>

        <!-- Plugins for this template -->
        <script src="assets/assetsbeta/js/jquery-plugin-collection.js"></script>

        <!-- Custom script for this template -->
        <script src="assets/assetsbeta/js/script.js"></script>

        <script src="assets/assetsbeta/swiper/swiper-bundle.min.js"></script>
    </form>
</body>



</html>
