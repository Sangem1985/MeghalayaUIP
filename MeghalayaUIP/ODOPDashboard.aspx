<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="ODOPDashboard.aspx.cs" Inherits="MeghalayaUIP.ODOPDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        th.colorblue, td.colorblue {
            color: #316ac2;
            font-weight: 400 !important;
        }

        .table th, .table td {
            padding: 0.40rem;
            font-weight: 400 !important;
        }

        tbody tr:nth-child(odd) {
            background-color: #e9ecf5;
            color: #000;
        }

        tbody tr:nth-child(even) {
            background-color: #cfd5ed;
            color: #000;
        }

        tr.colorblue {
            background: #4574c6 !important;
            color: #fff !important;
        }
    </style>
    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Dashboard</li>
                            <li class="breadcrumb-item active" aria-current="page">ODOP Dashboard</li>
                        </ol>
                    </nav>

                    <h3>ODOP Approval Dashboard :</h3>


                    <table class="table table-bordered table-responsive">
                        
                        <tbody>
                            <tr class="colorblue">
                                <th scope="col">Approval Name</th>
                                <th scope="col">Time Limit prescribed as per PSDG Act/MRPS Act</th>
                                <th scope="col">Total No. of Applications Received</th>
                                <th scope="col">Total Applications approved</th>
                                <th scope="col">Average time taken to obtain registration/renewal</th>
                                <th scope="col">Median time taken to obtain registration/renewal</th>
                                <th scope="col">Minimum time taken to obtain registration/renewal</th>
                                <th scope="col">Maximum time taken to obtain registration/renewal</th>
                                <th scope="col">*“Average fee” taken by the Department for completion of entire process of obtaining approval/ certificate</th>

                            </tr>

                            <tr>
                                <th scope="col">ODOP - PMFME</th>
                                <td>NA</td>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>

                            </tr>
                            <%--<tr>
                                <th scope="col">ODOP Registration</th>
                                <td>NA</td>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>

                            </tr>--%>

                        </tbody>
                    </table>
                    <p>
                        Dashboard is updated in regular intervals (daily, weekly, or monthly), with the date and time of the most recent update prominently displayed for transparency. 
                    </p>

                    <br />


                    <h3>ODOP Registered Business Dashboard :</h3>


                    <table class="table table-bordered table-responsive">
                        <thead>
                            <tr>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="colorblue">
                                <th scope="col">Business Registered under ODOP Initiatives</th>
                                <th scope="col">Type of Product</th>
                                <th scope="col">Location</th>
                                <th scope="col">Services  Utilized</th>

                            </tr>

                            <tr>
                                <th>Rynsan Creation Pvt.Ltd</th>
                                <td>Pineapple</td>
                                <td>Ri Bhoi</td>
                                <td>ODOP-PMFME</td>
                            </tr>
                            <tr>
                                <th>Western Ri boi Farmer Producer Co-operative Society 
                                </th>
                                <td>Pineapple</td>
                                <td>Ri Bhoi</td>
                                <td>ODOP-PMFME</td>
                            </tr>
                            <tr>
                                <th>M/s Mewan food Processing
                                </th>
                                <td>Khasi Mandarin
                                </td>
                                <td>Ri Bhoi</td>
                                <td>ODOP-PMFME</td>
                            </tr>
                            <tr>
                                <th>DaFriael (Discover The Difference)
                                </th>
                                <td>Khasi Mandarin
                                </td>
                                <td>East Khasi Hills
                                </td>
                                <td>ODOP-PMFME</td>
                            </tr>
                        </tbody>
                    </table>
                   

                    
                    <br />


                    <h3>ODOP Event Dashboard :</h3>


                    <table class="table table-bordered table-responsive">
                        <thead>
                            <tr>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="colorblue">
                                <th scope="col">Event/Fairs/Exhibition (Tentative)</th>
                                <th scope="col">Location</th>
                                <th scope="col">Register</th>

                            </tr>

                            <tr>
                                <th>5-day pickle processing training program</th>
                                <td>Shillong</td>
                                <td><a target="_blank" href="https://dofpmeghalaya.org/the-directorate-of-food-processing-partnered-the-fma-outreach-for-underprivileged-women-children-ouwc-between-december-4-8-at-fma-ouwc-lumshyiap-shillong-by-offering-a-5-day-training-programme/">Register Here</a></td>
                            </tr>
                            <tr>
                                <th>World Food India 2025 </th>
                                <td>New Delhi</td>
                                <td><a target="_blank" href="https://dofpmeghalaya.org/contact-us/">Register Here</a></td>
                                
                            </tr>
                            
                        </tbody>
                    </table>

                </div>
            </div>

        </div>
    </section>
</asp:Content>
