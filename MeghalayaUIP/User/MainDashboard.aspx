<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="MainDashboard.aspx.cs" Inherits="MeghalayaUIP.User.MainDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper griddashboard">
        <div class="content container-fluid">
            <div class="card">
                <div class="card-header">
                    <h4 class="card-title">Welcome
                        <label id="unitname" runat="server"></label>
                    </h4>
                </div>
                <section id="dashboardcount">
                    <div class="container-fluid">
                        <div class="row">
                            <table class="table table-bordered">
                                <thead>
                                    <tr>
                                        <th scope="col">&nbsp;</th>
                                        <th scope="col">Total Applications</th>
                                        <th scope="col">Total Approved</th>
                                        <th scope="col">Total Rejected</th>
                                        <th scope="col">Under Process</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr style="border-bottom: 3px solid #fff !important;">
                                        <th scope="row" style="width: 25%;">Registration under  MIIPP 2024</th>
                                        <td><a class="btn btn-success" data-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample" id="RegistrationMIIPPTotal" onclick="RegistrationMIIPPTotal_Click">10</a>
                                        </td>
                                        <td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample1" role="button" aria-expanded="false" aria-controls="collapseExample">5</a>
                                        </td>
                                        <td><a class="btn btn-orange" data-toggle="collapse" href="#collapseExample2" role="button" aria-expanded="false" aria-controls="collapseExample">15</a>
                                        </td>
                                        <td><a class="btn btn-warning" data-toggle="collapse" href="#collapseExample3" role="button" aria-expanded="false" aria-controls="collapseExample">20</a>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample">
                                                <div class="card card-body">
                                                    <asp:GridView ID="gvPreRegUserDashboard" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD" ForeColor="#333333"
                                                        GridLines="None" Width="100%" EnableModelValidation="True">
                                                        <RowStyle />
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="LightGray" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                                                            <asp:BoundField HeaderText="Unit ID" DataField="UNITID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                                                            <asp:BoundField HeaderText="Invester ID" DataField="INVESTERID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" Visible="false" />
                                                            <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                            <asp:BoundField HeaderText="PAN No" DataField="COMPANYPANNO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                            <asp:BoundField HeaderText="Communication Address" DataField="APPLICANTADDRESS" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                            <asp:BoundField HeaderText="Unit Address" DataField="UNITADDRESS" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                            <asp:BoundField HeaderText="Application Filed Date" DataField="CREATEDDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                            <asp:BoundField HeaderText="Status Description" DataField="statusdescription" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample1">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample2">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample3">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>


                                    <tr style="border-bottom: 3px solid #fff !important;">
                                        <th scope="row">Pre-Establishment Approval</th>
                                        <td><a class="btn btn-success" data-toggle="collapse" href="#collapseExample4" role="button" aria-expanded="false" aria-controls="collapseExample">10</a>
                                        </td>
                                        <td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample5" role="button" aria-expanded="false" aria-controls="collapseExample">5</a>
                                        </td>
                                        <td><a class="btn btn-orange" data-toggle="collapse" href="#collapseExample6" role="button" aria-expanded="false" aria-controls="collapseExample">15</a>
                                        </td>
                                        <td><a class="btn btn-warning" data-toggle="collapse" href="#collapseExample7" role="button" aria-expanded="false" aria-controls="collapseExample">20</a>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample4">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample5">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample6">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample7">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>

                                    <tr style="border-bottom: 3px solid #fff !important;">
                                        <th scope="row">Pre-Operational Approval</th>
                                        <td><a class="btn btn-success" data-toggle="collapse" href="#collapseExample8" role="button" aria-expanded="false" aria-controls="collapseExample">10</a>
                                        </td>
                                        <td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample9" role="button" aria-expanded="false" aria-controls="collapseExample">5</a>
                                        </td>
                                        <td><a class="btn btn-orange" data-toggle="collapse" href="#collapseExample10" role="button" aria-expanded="false" aria-controls="collapseExample">15</a>
                                        </td>
                                        <td><a class="btn btn-warning" data-toggle="collapse" href="#collapseExample11" role="button" aria-expanded="false" aria-controls="collapseExample">20</a>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample8">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample9">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample10">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample11">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>

                                    <tr style="border-bottom: 3px solid #fff !important;">
                                        <th scope="row">Incentive</th>
                                        <td><a class="btn btn-success" data-toggle="collapse" href="#collapseExample12" role="button" aria-expanded="false" aria-controls="collapseExample">10</a>
                                        </td>
                                        <td><a class="btn btn-info" data-toggle="collapse" href="#collapseExample13" role="button" aria-expanded="false" aria-controls="collapseExample">5</a>
                                        </td>
                                        <td><a class="btn btn-orange" data-toggle="collapse" href="#collapseExample14" role="button" aria-expanded="false" aria-controls="collapseExample">15</a>
                                        </td>
                                        <td><a class="btn btn-warning" data-toggle="collapse" href="#collapseExample15" role="button" aria-expanded="false" aria-controls="collapseExample">20</a>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample12">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample13">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample14">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="linedisbale">
                                        <td colspan="5">
                                            <div class="collapse" id="collapseExample15">
                                                <div class="card card-body">
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
                                                </div>
                                            </div>
                                        </td>
                                    </tr>

                                </tbody>
                            </table>


                        </div>
                    </div>
                </section>



            </div>





        </div>
    </div>
    pt>
</asp:Content>
