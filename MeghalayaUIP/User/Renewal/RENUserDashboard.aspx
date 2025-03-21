<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENUserDashboard.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENUserDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item active" aria-current="page">Renewals</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12 ">
                        <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                        </div>
                    </div>
                    <div class="col-md-12 ">
                        <div id="Failure" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show" align="Center">
                            <strong>Warning!</strong>
                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnUserID" runat="server" />
                    <div class="col-md-12 d-flex">
                        <div class="col-md-11">
                            <h4 style="margin-left: -10px;">Renewals Dashboard :
                                <asp:Label runat="server" ID="lblHdng"></asp:Label></h4>
                        </div>

                        <div class="col-md-1">
                            <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" OnClick="lbtnBack_Click" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        </div>
                    </div>
                    <%--<div class="justify-content-between justify-content-around">
                        <h4 class="card-title mb-0 mt-2">
                           </h4>
                    </div>--%>

                    <div class="table-responsive CFEUSERDASHBOARD">

                        <asp:GridView ID="gvRenewals" runat="server" AutoGenerateColumns="False"  ShowHeaderWhenEmpty="true"
                            BorderStyle="Solid" BorderWidth="1px" CssClass="table-bordered table-hover" ForeColor="#333333"
                            GridLines="None" Width="100%" EnableModelValidation="True" ShowFooter="false" OnRowDataBound="gvRenewals_RowDataBound">
                            <RowStyle />
                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                            <FooterStyle BackColor="#013161" CssClass="no-hover" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle />
                            <Columns >
                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%" HeaderStyle-BorderColor="White">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                                <asp:BoundField HeaderStyle-BorderColor="White" HeaderText="Registration ID" DataField="PREREGUIDNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                                <%--                                <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />--%>
                                <%--                                <asp:BoundField HeaderText="PAN No" DataField="COMPANYPANNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />--%>
                                <asp:BoundField HeaderStyle-BorderColor="White" HeaderText="Communication Address" DataField="APPLICANTADDRESS" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderStyle-BorderColor="White" HeaderText="Unit Address" DataField="UNITADDRESS" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <asp:BoundField HeaderStyle-BorderColor="White" HeaderText="Application Filed Date" DataField="CREATEDDATE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                <%--7--%>
                                <asp:TemplateField HeaderText="Applied" HeaderStyle-BorderColor="White">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplApplied" Text='<%#Eval("APPLIEDCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Approved" HeaderStyle-BorderColor="White">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplApproved" Text='<%#Eval("APPROVEDDCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Under Process" HeaderStyle-BorderColor="White">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplundrProcess" Text='<%#Eval("UNDERPROCESSCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rejected" HeaderStyle-BorderColor="White">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplRejected" Text='<%#Eval("REJECTEDDCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Query Raised" HeaderStyle-BorderColor="White">
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="hplQueryRaised" Text='<%#Eval("QUERYCOUNT")%>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apply For Renewal" Visible="false" HeaderStyle-BorderColor="White">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnApplyRenewal" OnClick="btnApplyRenewal_Click" Text="Apply" CssClass="btn btn-info btn-rounded btn-sm" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View Application Details" ItemStyle-Width="20%" Visible="false" HeaderStyle-BorderColor="White">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnCombndAppl" Text="View" CssClass="btn btn-info btn-rounded" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="View Application Status " ItemStyle-Width="12%" HeaderStyle-BorderColor="White">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnApplStatus" OnClick="btnApplStatus_Click" Text="Application Status" CssClass="btn btn-info btn-rounded" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UNITID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblUNITID" Text='<%#Eval("UNITID") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RENQDID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblRENQDID" Text='<%#Eval("RENQDID") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RENAPPLSTATUS" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblRENAPPLSTATUS" Text='<%#Eval("RENAPPLSTATUS") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" Visible="false">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="anchortaglinkStatus" runat="server" Text="Track" Font-Bold="true"
                                            ForeColor="Green" Target="_blank" Visible="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                               <EmptyDataTemplate>
                                <div style="text-align: center; padding: 20px;">
                                    <div align="center" style="text-align: center; padding: 20px;">
                                        <b>There are no applied Renewal Services, Please  <a href="../Renewal/RENIndustryDetails.aspx" style="font-size: 20px; font-family: 'Bookman Old Style'">Click Here </a>to apply.</b>
                                    </div>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>

                    </div>
                    <div align="center" id="trApplyAgainbtn" runat="server">
                        <div align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="middle">
                            &nbsp;
                           <asp:Button ID="btnApplyAgain" runat="server" class="btn btn-rounded btn-info btn-lg"
                               TabIndex="10" Text="Apply Again" Width="150px" OnClick="btnApplyAgain_Click" />
                        </div>
                    </div>
                </div>
            </div>



        </div>
    </div>
</asp:Content>
