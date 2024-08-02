<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="Hospitality.aspx.cs" Inherits="MeghalayaUIP.Hospitality" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/admin/css/PSIP.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="master-head-wappers master-head-wappers-inner d-flex align-items-center
         justify-content-center innersliderbanner" style="background-image: url(assets/assetsnew/images/Innerpageslides/hstpt.png);">
        <div class="pageheader-captionn2">
            <h1>Hotel</h1>
           
            <p>Meghalaya's Hotel sector plays a vital role in welcoming visitors to the state, offering a range 
                        of accommodation options and services to cater to diverse traveller preferences.</p>
            <div class="arrow-implation" style="visibility: hidden;">
                <div class="scroll-down-more">
                    <span class="lnr lnr-chevron-down"></span>
                    <span class="lnr lnr-chevron-down" style="top: -5px; position: relative;"></span>
                </div>
            </div>
        </div>
        <div class="master-head-featureblock" style="width: 100%;">
            <div class="container-fluid container-with-margin">
                <div class="col-md-12">
                    <div class="row d-flex justify-content-center">
                        <div class="col-md-3">
                            <div class="hexagon">
                                <div class="hexagon master">
                                    <div class="hexagon master11">
                                        <div class="col-md-12">
                                            <h4>2<sup class="down-wapx"></sup></h4>
                                        </div>
                                        <div class="col-md-12">
                                            <p>Total Luxury <br />Hotels</p>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="hexagon">
                                <div class="hexagon master">
                                    <div class="hexagon master11">
                                        <div class="col-md-12">
                                            <h4>502<sup class="down-wapx"></sup></h4>
                                        </div>
                                        <div class="col-md-12">
                                            <p>Number of <br />Hotels </p>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="hexagon">
                                <div class="hexagon master">
                                    <div class="hexagon master11">
                                        <div class="col-md-12">
                                            <h4>27,045<sup class="down-wapx"></sup></h4>
                                        </div>
                                        <div class="col-md-12">
                                            <p>Number of <br />Occupants</p>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="hexagon">
                                <div class="hexagon master">
                                    <div class="hexagon master11">
                                        <div class="col-md-12">
                                            <h4>3rd<sup class="down-wapx"></sup></h4>
                                        </div>
                                        <div class="col-md-12">
                                            <p>Highest Number of <br />Startups Globally</p>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>




    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <%--<nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>

                            <li class="breadcrumb-item active" aria-current="page">Priority Sectors</li>
                            <li class="breadcrumb-item active" aria-current="page">Hospitality</li>
                        </ol>
                    </nav>
                    <h3></h3>--%>
                    <p>
                        From luxury resorts nestled amidst picturesque landscapes to cozy homestays providing an authentic 
                        local experience, the hospitality industry contributes significantly to the state's tourism infrastructure.
                        With a focus on quality service and guest satisfaction, hospitality establishments in Meghalaya strive to
                        create memorable experiences for visitors, ensuring their comfort and enjoyment throughout their stay.</p>
                <%--<p><b>Current statuses of the Hospitality sector in Meghalaya: </b></p>  
                    <ul>
                        <li>1.	Total luxury hotels: 2 (Vivanta by Taj and Courtyard by Marriot, Shillong)</li>
                        <li>2.	No. of hotels: 502 (2022)</li>
                        <li>3.	Number of Occupants: 27,045 (2022) </li>
                    </ul>--%>
                    <p><b>Key projects</b></p>
                    <p>Here are some of the key Hospitality projects of the State of Meghalaya</p>
                    <img src="assets/assetsnew/images/Hospitality_image.png">
                    <%--<h4>In 2023, an average luxury accommodation unit in the State had observe:-</h4>
                    <div class="row mt-2">
                       
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                            <div class="inner-box" style="text-align: center;">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="fi fi-tr-chart-arrow-grow"></i></div>
                                                <h3><a href="#">9000+</a></h3>
                                                <div class="text">Average Room Rate in INR</div>
                                                
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated animated" data-wow-delay="300ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 300ms; animation-name: fadeInUp;">
                                            <div class="inner-box" style="text-align: center;">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="fi fi-tr-tax-alt"></i></div>
                                                <h3><a href="#">+ 50%</a></h3>
                                                <div class="text">Occupancy rate 2023</div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated animated" data-wow-delay="600ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 600ms; animation-name: fadeInUp;">
                                           <div class="inner-box" style="text-align: center;">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="fi fi-tr-challenge-alt"></i></div>
                                                <h3><a href="#">4,700</a></h3>
                                                <div class="text">RevPAR in INR</div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 service-block">
                                        <div class="service-block-four wow fadeInUp animated animated" data-wow-delay="00ms" data-wow-duration="1500ms" style="visibility: visible; animation-duration: 1500ms; animation-delay: 0ms; animation-name: fadeInUp;">
                                            <div class="inner-box" style="text-align: center;">
                                                <div class="left-layer"></div>
                                                <div class="right-layer"></div>
                                                <div class="icon-box"><i class="fi fi-tr-career-growth"></i></div>
                                                <h3><a href="#">~200</a></h3>
                                                <div class="text">No of Events Hosted</div>

                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>--%>
                </div>
                </div>
            </div>
        </section>
</asp:Content>
