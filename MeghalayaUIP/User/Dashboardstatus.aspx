<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="Dashboardstatus.aspx.cs" Inherits="MeghalayaUIP.User.Dashboardstatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../assets/admin/css/user.css" rel="stylesheet" />
    <div class="page-wrapper griddesignmulticount">
        <div class="content container-fluid">

            <div class="card">
                <div class="card-header d-flex justify-content-between">
                    <h4 class="card-title">Welcome to Dashboard</h4>
                    <h4 class="card-title">
                        <label id="unitname" runat="server"></label>
                    </h4>
                </div>
                <section id="dashboardcount" class="mt-2">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12 d-flex">
                                <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 d-flex">
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                                    <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="col-md-12 row mt-4">
                                            <div class="col-md-2">1. Unit ID</div>

                                            <div class="col-md-3 fw-bold text-info">
                                                <spna class="dots">:</spna><asp:Label ID="lblUnitID"  runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-2">&nbsp;</div>
                                            <div class="col-md-2">3. Date of Unit Application</div>

                                            <div class="col-md-3 fw-bold text-info">
                                                <spna class="dots">:</spna><asp:Label ID="lblDOA"  runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-2 mb-4">
                                            <div class="col-md-2">2. Unit Name</div>

                                            <div class="col-md-3 fw-bold text-info">
                                                <spna class="dots">:</spna><asp:Label ID="lblUnitNmae"  runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-2">&nbsp;</div>
                                            <div class="col-md-2">4. Category of Industry</div>

                                            <div class="col-md-3 fw-bold text-info">
                                                <spna class="dots">:</spna><asp:Label ID="lblProjCategory" Text="Mega Project"  runat="server"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="card-body table fix">
                                            <div class="table-responsive table-hover table-striped table-bordered">
                                                <table class="table table-bordered mb-0" runat="server" visible="false">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="4"></th>

                                                            <th colspan="3" style="text-align: center;">Pre-Scrutiny Status</th>
                                                            <th></th>
                                                            <th colspan="2" style="text-align: center;">Approval Stage</th>
                                                            <th></th>

                                                        </tr>
                                                        <tr>
                                                            <th rowspan="2">Sl.No.</th>
                                                            <th>Name of Approval</th>
                                                            <th>Approval Applied<br />
                                                                Date</th>
                                                            <th>Date of Payment</th>
                                                            <th>Date of Query</th>
                                                            <th>Date of Query
                                                    <br />
                                                                Response</th>
                                                            <th>Pre-Scrutiny
                                                    <br />
                                                                Completion
                                                    <br />
                                                                Date</th>
                                                            <th>Date of
                                                    <br />
                                                                Additional<br />
                                                                Payment</th>
                                                            <th>Date Recevied<br />
                                                                to Approval<br />
                                                                Stage</th>
                                                            <th>Date of
                                                    <br />
                                                                Completion</th>
                                                            <th>Status</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>1</td>
                                                            <td>Factory Licence</td>
                                                            <td>03-01-2024</td>
                                                            <td class="text-info">09-03-2024</td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>09-03-2024</td>
                                                            <td>09-03-2024</td>
                                                            <td>09-03-2024</td>
                                                            <td>09-03-2024</td>
                                                            <td class="text-info">Approved</td>
                                                        </tr>
                                                        <tr>
                                                            <td>2</td>
                                                            <td>Factory Licence</td>
                                                            <td>03-01-2024</td>
                                                            <td class="text-info">09-03-2024</td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>09-03-2024</td>
                                                            <td>09-03-2024</td>
                                                            <td>09-03-2024</td>
                                                            <td>09-03-2024</td>
                                                            <td class="text-info">Approved</td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                                <br />

                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex  ">
                                            <asp:GridView ID="grdTrackerDetails" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdTrackerDetails_RowDataBound"
                                                OnRowCreated="grdTrackerDetails_RowCreated" EnableModelValidation="True" Width="100%">
                                                <HeaderStyle BackColor="#363670" ForeColor="White" />
                                                <AlternatingRowStyle />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Name of Approval" DataField="ApprovalName"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Date of Application" DataField="DATEOFAPPLICATION" />
                                                    <asp:TemplateField HeaderText="Date of Payment">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplPayment" Text='<%#Eval("DATEOFPAYMENT")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date of Query">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplQuery" Text='<%#Eval("DATEOFQUERY")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date of Query Response">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplQueryResponse" Text='<%#Eval("DATEOFQUERYRRESPONSE")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date of Scrutiny Completion ">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="lblScrutiny" Text='<%#Eval("DATEOFSCRUTINY")%>' runat="server" Visible="true"></asp:HyperLink>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date of Additional Payment">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplAddlPmntDate" Text='<%#Eval("DATEOFADDLPAYMENT")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="" HeaderText="Date of Receival For Approval" />
                                                    <asp:BoundField DataField="DATEOFCOMPLETION" HeaderText="Date of Completion" />
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <%--<asp:HyperLink ID="HyperLinkSubsidy" Text='<%#Eval("Status of Approval Approved Rejected")%>'
                                                        NavigateUrl='<%#Eval("ApprovalDocNEW")%>' Target="_blank" runat="server" />--%>
                                                            <asp:HyperLink ID="lblStatus" Text='<%#Eval("STATUS")%>' runat="server" Visible="true"></asp:HyperLink>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>


        </div>





    </div>
</asp:Content>
