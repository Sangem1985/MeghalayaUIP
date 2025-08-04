<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="InvestibleProjectsTourism.aspx.cs" Inherits="MeghalayaUIP.InvestibleProjectsTourism" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        th.colorblue, td.colorblue {
            color: #316ac2;
        }

        .table th, .table td {
            padding: 0.40rem;
        }
    </style>
     <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Investment Opportunities</li>
                            <li class="breadcrumb-item active" aria-current="page">Investible Projects in Tourism</li>
                        </ol>
                    </nav>

                                      <h3>Investible Projects in Tourism :</h3>
                    <!--<h5>Projects under Public Private Partnership (PPP)</h5>
<p><b>RFP for Re-Development, Operation and Maintenance of Orchid Hotel, located at Shillong City under Design, Build, Finance, Operate and Transfer (DBFOT) Mode on Public Private Partnership (PPP)</b></p>-->
                    <p>See this link to check out updates on the projects : <a href="https://www.meghalayatourism.in/notices-and-updates/" target="_blank">meghalayatourism.in</a></p>

                    <table class="table table-bordered table-responsive">
                        <thead>
                            <tr style="text-align: left;">
                                <th scope="col" style="width: 6%;">Sl. No</th>
                                <th scope="col">Project Name</th>
                                <th scope="col">Type of project</th>
                                <th scope="col">District</th>
                                <th scope="col">Plot Area (Acres)</th>
                                <th scope="col">Coordinates</th>
                                <%--<th scope="col">Map</th>--%>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope="row">1.</th>
                                <td>Nartiang Glamping </td>
                                <td>Nartiang Glamping </td>
                                <td>West Jaintia Hills </td>
                                <td>5 </td>
                                <td>Latitude: 25° 32' 44.87" N<br />
                                    Longitude: 92° 9' 52.68" E</td>
                                <%--<td>  </td>--%>
                            </tr>
                            <tr>
                                <th scope="row">2.</th>
                                <td>Nokrek Glamping </td>
                                <td>Glamping </td>
                                <td>West Garo Hills </td>
                                <td>10 </td>
                                <td>Latitude: 25°31'19.57"N
                                    <br />
                                    Longitude: 90°20'51.53"E</td>
                                <%-- <td> </td>--%>
                            </tr>
                            <tr>
                                <th scope="row">3.</th>
                                <td>Umiam Glamping 4 Star Hotel II </td>
                                <td>Glamping </td>
                                <td>Ri-Bhoi</td>
                                <td>29.48 </td>
                                <td>Latitude: 25°40'07.33"N<br />
                                    Longitude: 91°54'09.32"E</td>
                                <!--<td>https://drive.google.<br />com/file/d/1yp5zMnfIHYwDuOZ3ej10Ia2t1mgc<br />tLSl/view?usp=sharing</td>-->
                                <%--<td colspan="3" style="width:35%;"><img src="assets/assetsnew/images/IP/Ug4star.jpg" /></td>--%>
                            </tr>
                            <tr>
                                <th scope="row">4.</th>
                                <td>Umiam 5-Star Hotel-I</td>
                                <td>5 Star Hotel</td>
                                <td>Ri-Bhoi</td>
                                <td>35</td>
                                <td>Latitude: 25°40'12"N<br />
                                    Longitude: 91°53'49.8"E</td>
                                <%--<td> </td>--%>
                            </tr>
                            <tr>
                                <th scope="row">5.</th>
                                <td>Umsawli- New Shillong City 5 Star Hotel </td>
                                <td>5 Star Hotel </td>
                                <td>East Khasi Hills </td>
                                <td>12.19 </td>
                                <td>Latitude: 25°36'48.56"N;<br />
                                    Longitude: 91°56'44.41"E</td>
                                <%--<td> </td>--%>
                            </tr>
                            <tr>
                                <th scope="row">6.</th>
                                <td>Mawkhanu - New Shillong City-5 Star Hotel II </td>
                                <td>5 Star Hotel </td>
                                <td>East Khasi Hills </td>
                                <td>Land Parcel - 1 - 13.08<br />
                                    Land Parcel - 2 - 14.4 </td>
                                <td>Latitude: 25°38'50.97"N;<br />
                                    Longitude: 92° 2'24.92"E</td>
                                <%-- <td> </td>--%>
                            </tr>
                            <tr>
                                <th scope="row">7.</th>
                                <td>Tura- Polo Orchid </td>
                                <td>5 Star Hotel </td>
                                <td>West Garo Hills </td>
                                <td>2.92 </td>
                                <td>Latitude: 25°30'51"N<br />
                                    Longitude: 90°11'34"E</td>
                                <%--<td></td>--%>
                            </tr>
                            <tr>
                                <th scope="row">8.</th>
                                <td>Umiam  -  Exhibition & Convention Center  </td>
                                <td>Exhibition & Convention Centre</td>
                                <td>Ri-Bhoi </td>
                                <td>111.83 </td>
                                <td>Latitude: 25°40'25.79"N<br />
                                    Longitude: 91°54'29.87"E</td>
                                <%-- <td></td>--%>
                            </tr>
                            <tr>
                                <th scope="row">9.</th>
                                <td>Khanapara 4 Star Business Hotel </td>
                                <td>Business hotel </td>
                                <td>Ri-Bhoi </td>
                                <td>5.23 </td>
                                <td>Latitude: 26° 6' 45.59" N,<br />
                                    Longitude: 91° 49' 25.32" E</td>
                                <%-- <td></td>--%>
                            </tr>
                            <tr>
                                <th scope="row">10.</th>
                                <td>Mawkhanu - Amusement Park and Hotel </td>
                                <td>Amusement Park and Hotel </td>
                                <td>East Khasi Hills </td>
                                <td>26.8 </td>
                                <td>Latitude: 25°38'37.55"N;
                                    <br />
                                    Longitude: 92° 2'16.19"E</td>
                                <%-- <td> </td>--%>
                            </tr>
                        </tbody>
                    </table>




                    <table class="table table-bordered table-responsive">

                        <h3>
                            <br />
                            Khanapara 4 Star Business Hotel</h3>

                        <thead>

                            <tr>

                                <th scope="col" style="width: 10%;">Name</th>
                                <th scope="col" style="color: #316ac2;">Khanapara 4 Star Business Hotel</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>

                                <td>District </td>
                                <td>Ri-Bhoi</td>

                            </tr>
                            <tr>

                                <td>Land Area</td>
                                <td>5.23 Acres</td>

                            </tr>
                            <tr>

                                <td>Location</td>
                                <td style="color: #316ac2;">Latitude: 26° 6' 45.59" N,<br />
                                    Longitude: 91° 49' 25.32" E</td>

                            </tr>
                            <tr>

                                <td>Map</td>

                                <td colspan="3">
                                    

                                    <img src="assets/assetsnew/images/IP/tourism/Khanapara.jpg" alt="img" style="width: 65%;" /> 
                                </td>

                            </tr>

                        </tbody>
                    </table>


                    <table class="table table-bordered table-responsive">

                        <h3>
                            <br />
                            Umiam Glamping 4 Star Hotel II</h3>

                        <thead>

                            <tr>

                                <th scope="col" style="width: 10%;">Name</th>
                                <th scope="col" style="color: #316ac2;">Umiam Glamping 4 Star Hotel II</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>

                                <td>District </td>
                                <td>Ri-Bhoi</td>

                            </tr>
                            <tr>

                                <td>Land Area</td>
                                <td>29.48 Acres</td>

                            </tr>
                            <tr>

                                <td>Location</td>
                                <td style="color: #316ac2;">Latitude: 25°40'07.33"N<br />
                                    Longitude: 91°54'09.32"E</td>

                            </tr>
                            <tr>

                                <td>Map</td>

                                <td colspan="3">
                                    
                                     <img src="assets/assetsnew/images/IP/tourism/Umiam.jpg" alt="img" style="width: 65%;" /> 
                                </td>

                            </tr>

                        </tbody>
                    </table>


                    <table class="table table-bordered table-responsive">

                        <h3>
                            <br />
                            Tura- Polo Orchid</h3>

                        <thead>

                            <tr>

                                <th scope="col" style="width: 10%;">Name</th>
                                <th scope="col" style="color: #316ac2;">Tura- Polo Orchid</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>

                                <td>District </td>
                                <td>West Garo Hills </td>

                            </tr>
                            <tr>

                                <td>Land Area</td>
                                <td>2.92 Acres</td>

                            </tr>
                            <tr>

                                <td>Location</td>
                                <td style="color: #316ac2;">Latitude: 25°30'51"N<br />
                                    Longitude: 90°11'34"E</td>

                            </tr>
                            <tr>

                                <td>Map</td>

                                <td colspan="3">
                                    <img src="assets/assetsnew/images/IP/tourism/Tura.jpg" alt="img" style="width: 65%;" /> </td>

                            </tr>

                        </tbody>
                    </table>


                    <table class="table table-bordered table-responsive">

                        <h3>
                            <br />
                            Umiam  -  Exhibition & Convention Center </h3>

                        <thead>

                            <tr>

                                <th scope="col" style="width: 10%;">Name</th>
                                <th scope="col" style="color: #316ac2;">Umiam  -  Exhibition & Convention Center </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>

                                <td>District </td>
                                <td>Ri-Bhoi </td>

                            </tr>
                            <tr>

                                <td>Land Area</td>
                                <td>111.83 Acres</td>

                            </tr>
                            <tr>

                                <td>Location</td>
                                <td style="color: #316ac2;">Latitude: 25°40'25.79"N<br />
                                    Longitude: 91°54'29.87"E</td>

                            </tr>
                            <tr>

                                <td>Map</td>

                                <td colspan="3">
                                    <img src="assets/assetsnew/images/IP/tourism/Umiam1.jpg" alt="img" style="width: 65%;" /></td>

                            </tr>

                        </tbody>
                    </table>


                    <table class="table table-bordered table-responsive">

                        <thead>

                            <tr>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>

                                <td>Department:	 </td>
                                <td>Tourism Department, Govt. of Meghalaya </td>

                            </tr>
                            <tr>

                                <td>Nodal Person Name</td>
                                <td>Brenda Lee Pakyntein</td>

                            </tr>
                            <tr>

                                <td>Contact Details </td>
                                <td>8794253770<br />
                                    brendapakyntein@gmail.com</td>

                            </tr>
                            <tr>

                                <td>MIPA</td>
                                <td>Meghalaya Investment Promotion Authority (MIPA),<br />
                                    Secretariat Main Building, M.G Road,<br />
                                    Shillong - 793 001, East Khasi Hills District, Meghalaya.<br />
                                    Email: meghalayaipa@gmail.com<br />
                                    Call Us: +91 7085741695</td>

                            </tr>


                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
