<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCApplStatus.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCApplStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Services/SRVCUserDashboard.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Services</li>
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
                                    <h4>Other Services</h4>
                                </div>
                                <div class="col-md-1">
                                    <asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                                </div>
                            </div>


                            <asp:GridView ID="GVApplictionStatus" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD table-hover" ForeColor="#333333"
                                GridLines="None" Width="100%" EnableModelValidation="True">
                                <RowStyle />
                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />

                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="5%">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                                    <asp:BoundField HeaderText="Acknowledgement ID" DataField="SRVCED_UIDNO" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                                    <asp:BoundField HeaderText="Invester ID" DataField="SRVCED_CREATEDBY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" Visible="false" />
                                    <asp:BoundField HeaderText="Unit Name" DataField="SRVCED_NAMEOFUNIT" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                    <asp:BoundField HeaderText="Unit Address" DataField="APPLICANTADDRESS" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                    <asp:BoundField HeaderText="Service Name" DataField="SERVICENAME" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                    <asp:BoundField HeaderText="Service Applied Date" DataField="CREATEDDATE" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />

                                    <asp:TemplateField HeaderText="Queries Count" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkQueryCount" runat="server" Text='<%#Eval("QUERYCOUNT")%>' ForeColor="Red" Font-Underline="true"></asp:LinkButton>
                                            <%--PostBackUrl='<%#Eval("INVESTERID","QueryResponse.aspx?Appid={0}")%>'--%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hplApproval" runat="server" Text='<%#Eval("STATUSDESCRIPTION") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <%--<asp:BoundField HeaderText="Status" DataField="statusdescription" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />--%>


                                    <asp:TemplateField HeaderText="View" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Button ID="btnView" runat="server" Text='View' CommandName="VIEW" CssClass="btn btn-info"
                                                CommandArgument='<%# Eval("SRVCED_UNITID")+"$"+Eval("SRVCED_CREATEDBY")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitID" Text='<%#Eval("SRVCED_UNITID")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApprovalDoc" Text='<%#Eval("APPROVALDOCUMENT")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                        </div>
                    </div>



                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
