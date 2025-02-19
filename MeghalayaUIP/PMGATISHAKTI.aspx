<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="PMGATISHAKTI.aspx.cs" Inherits="MeghalayaUIP.PMGATISHAKTI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table#servicestable th {
            vertical-align: middle;
        }

        select#ContentPlaceHolder1_ddlPolCategory {
            display: block;
            width: 100%;
            padding: 0.475rem 0.75rem;
            font-size: 1rem;
            line-height: 1.7;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
        }

        tr th, td {
            padding: 6px 15px !important;
            text-align:left;
        }
        b, strong {
    font-weight: bolder;
    color: #38373e;
}
        a.btn.btn-primary.btn-sm {
    width: 100%;
    box-shadow: 1px 2px 4px #b5aaaa;
}
        .table-responsive {
    display: flex;
    justify-content: space-around;
}
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <section class="innerpages">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                                    <li class="breadcrumb-item">Resources </li>
                                    <li class="breadcrumb-item active" aria-current="page">PM Gati Shakti </li>
                                </ol>
                            </nav>
                            <h3 class="">PM Gati Shakti </h3>

                            <div class="">
                                <div class="">
                                    <div class="table-responsive">
                                        <table class="table table-bordered table-striped" style="width:60%">
                                            <thead style="background-color: #003399; color: white;">
                                                <tr>
                                                    <th style="width:7%">Sl. No.</th>
                                                    <th style="width:40%">Layer</th>
                                                    <th style="width:13%">Letter</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>1</td>
                                                    <td><strong>Traffic Lights</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-309 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>


                                                </tr>
                                                <tr>
                                                    <td>2</td>
                                                    <td><strong>Electric Poles</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-315 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>


                                                </tr>
                                                <tr>
                                                    <td>3</td>
                                                    <td><strong>Bus Terminals and Bus Shelters</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-321 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>


                                                </tr>
                                                <tr>
                                                    <td>4</td>
                                                    <td><strong>Petrol / Diesel Outlets</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-328 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>



                                                </tr>
                                                <tr>
                                                    <td>5</td>
                                                    <td><strong>Government Buildings</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-334 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>


                                                </tr>
                                                <tr>
                                                    <td>6</td>
                                                    <td><strong>Archaeological Survey of India (ASI) Sites</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-341 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>

                                                </tr>
                                                <tr>
                                                    <td>7</td>
                                                    <td><strong>Tourism Sites</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-348 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>


                                                </tr>
                                                <tr>
                                                    <td>8</td>
                                                    <td><strong>Roads</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-355 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>


                                                </tr>
                                                <tr>
                                                    <td>9</td>
                                                    <td><strong>Water Supply Network</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-362 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>


                                                </tr>
                                                <tr>
                                                    <td>10</td>
                                                    <td><strong>Sewer Lines</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-370 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>


                                                </tr>

                                                <tr>
                                                    <td>11</td>
                                                    <td><strong>Power Supply Network</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-378 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>


                                                </tr>
                                                <tr>
                                                    <td>12</td>
                                                    <td><strong>Village Habitation</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-389 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>

                                                </tr>
                                                <tr>

                                                    <td>13</td>
                                                    <td><strong>Mining Areas</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-395 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>

                                                </tr>
                                                <tr>
                                                    <td>14</td>
                                                    <td><strong>Economic Zones</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-401 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>

                                                </tr>
                                                <tr>
                                                    <td>15</td>
                                                    <td><strong>Industrial Parks</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-407 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>

                                                </tr>
                                                <tr>
                                                    <td>16</td>
                                                    <td><strong>Eco-Sensitive Zones</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-413 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>

                                                </tr>
                                                <tr>
                                                    <td>17</td>
                                                    <td><strong>Water Resources</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-419 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>
                                                </tr>
                                                <tr>
                                                    <td>18</td>
                                                    <td><strong>Land Records</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-425 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>
                                                </tr>
                                                <tr>
                                                    <td>19</td>
                                                    <td><strong>Forest</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-431 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>
                                                </tr>
                                                <tr>
                                                    <td>20</td>
                                                    <td><strong>Soil Type</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-437 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>
                                                </tr>
                                                <tr>
                                                    <td>21</td>
                                                    <td><strong>Embankments</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-443 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>
                                                </tr>
                                                <tr>
                                                    <td>22</td>
                                                    <td><strong>Seismic Zone</strong></td>
                                                    <td><a href="Documents/NotifiedSOP/No.PLR.33-2022-Pt-II-449 dated 21st Nov. 2024_0001.pdf" target="_blank" class="btn btn-primary btn-sm">View</a></td>

                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
