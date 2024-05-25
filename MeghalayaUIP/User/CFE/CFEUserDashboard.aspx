<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEUserDashboard.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEUserDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">


            <div class="card">
                <div class="card-body">
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
                    <h3><b>Approved Industry Registrations under MIIPP 2024</b></h3>

                    <div class="col-md-12 d-flex">
                        <asp:GridView ID="gvPreRegApproved" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD table-striped table-hover" ForeColor="#333333"
                            GridLines="None" Width="100%" EnableModelValidation="True" OnRowDataBound="gvPreRegApproved_RowDataBound" ShowFooter="true">
                            <RowStyle />
                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle />
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                                <asp:BoundField HeaderText="Application ID" DataField="PREREGUIDNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                                <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderText="PAN No" DataField="COMPANYPANNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderText="Communication Address" DataField="APPLICANTADDRESS" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderText="Unit Address" DataField="UNITADDRESS" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderText="Application Filed Date" DataField="CREATEDDATE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />


                                <%--8--%>
                                <asp:TemplateField HeaderText="Approvals Applied" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplApplied" Text='<%#Eval("APPLIEDCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Approvals Approved" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplApproved" Text='<%#Eval("APPROVEDDCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Approvals Under Process" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplundrProcess" Text='<%#Eval("UNDERPROCESSCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Approvals Rejected" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplRejected" Text='<%#Eval("REJECTEDDCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Query Raised" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplQueryRaised" Text='<%#Eval("QUERYCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apply For Pre-Establishment" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnApplyCFE" OnClick="btnApplyCFE_Click" Text="Apply" CssClass="btn btn-info" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View Approvals Required" ItemStyle-Width="12%" Visible="false">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnCombndAppl" OnClick="btnCombndAppl_Click" Text="Approvals Required" CssClass="btn btn-info" BackColor="Olive" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="View Application Status " ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnApplStatus" OnClick="btnApplStatus_Click" Text="Application Status" CssClass="btn btn-info" BackColor="Tomato" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UNITID" ItemStyle-Width="12%" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblUNITID" Text='<%#Eval("UNITID") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CFEQID" ItemStyle-Width="12%" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCFEQID" Text='<%#Eval("CFEQDID") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CFEQSTATUS" ItemStyle-Width="12%" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCFEAPPLSTATUS" Text='<%#Eval("CFEAPPLSTATUS") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    <br />
                    <%--<h3><b>Pre-Establishment Applications</b></h3>--%>

                    <div class="col-md-12 d-flex">
                        <asp:GridView ID="gvCFEApplied" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD" ForeColor="#333333"
                            GridLines="None" Width="100%" EnableModelValidation="True">
                            <RowStyle />
                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
                                <asp:BoundField HeaderText="MIIPP Application ID" DataField="CFEQD_PREREGUIDNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                                <asp:BoundField HeaderText="CFE UID No" DataField="CFEQD_CFEUIDNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                                <asp:BoundField HeaderText="Unit Name" DataField="CFEQD_COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderText="Application Status" DataField="TM_STAGENAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderText="Application Filed Date" DataField="QUESTDATE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />

                                <asp:TemplateField HeaderText="View Questionnaire" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnView" OnClick="btnView_Click" Text="View" CssClass="btn btn-info" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="UNITID" ItemStyle-Width="12%" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblUNITID" Text='<%#Eval("CFEQD_UNITID") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CFEQID" ItemStyle-Width="12%" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCFEQID" Text='<%#Eval("CFEQDID") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>

                            <EmptyDataTemplate>
                                <b>No Records Found.</b>

                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>



        </div>
    </div>
</asp:Content>
