<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOUserDashboard.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOUserDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>

            <li class="breadcrumb-item active" aria-current="page">Pre-Operational</li>
        </ol>
    </nav>
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
                    <h4>Pre-Operational Approvals :
                     <asp:Label runat="server" ID="lblHdng"></asp:Label></h4>

                    <div class="table-responsive CFEUSERDASHBOARD">
                        <asp:GridView ID="gvCFOApproved" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered table-hover" ForeColor="#333333"
                            GridLines="None" Width="100%" EnableModelValidation="True" OnRowDataBound="gvCFOApproved_RowDataBound"
                            OnRowCreated="gvCFOApproved_RowCreated" ShowFooter="true">
                            <RowStyle />
                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle />
                            <EmptyDataRowStyle BorderStyle="None" BorderColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Registration ID" DataField="PREREGUIDNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                                <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderText="PAN No" DataField="COMPANYPANNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderText="Communication Address" DataField="APPLICANTADDRESS" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderText="Unit Address" DataField="UNITADDRESS" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderText="Application Filed Date" DataField="CREATEDDATE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <%--7--%>
                                <asp:TemplateField HeaderText="Applied" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplApplied" Text='<%#Eval("APPLIEDCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Approved" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplApproved" Text='<%#Eval("APPROVEDDCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Under Process" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplundrProcess" Text='<%#Eval("UNDERPROCESSCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rejected" ItemStyle-Width="12%">
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
                                <asp:TemplateField HeaderText="Apply For Pre-Operational" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnApplyCFO" OnClick="btnApplyCFO_Click" Text="Apply" CssClass="btn btn-info btn-rounded" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View Application Details" ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnCombndAppl" OnClick="btnCombndAppl_Click" Text="View" CssClass="btn btn-info btn-rounded" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="View Application Status " ItemStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnApplStatus" OnClick="btnApplStatus_Click" Text="Application Status" CssClass="btn btn-info btn-rounded" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UNITID" ItemStyle-Width="12%" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblUNITID" Text='<%#Eval("UNITID") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CFOQID" ItemStyle-Width="12%" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCFOQID" Text='<%#Eval("CFOQDID") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CFOQSTATUS" ItemStyle-Width="12%" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCFOAPPLSTATUS" Text='<%#Eval("CFOAPPLSTATUS") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div style="text-align: center; padding: 20px;">
                                    <p>
                                        No Records Found
                                    </p>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>




            </div>
        </div>
    </div>
</asp:Content>
