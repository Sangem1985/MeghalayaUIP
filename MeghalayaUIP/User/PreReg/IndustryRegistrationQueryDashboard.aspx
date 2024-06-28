<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="IndustryRegistrationQueryDashboard.aspx.cs" Inherits="MeghalayaUIP.User.PreReg.IndustryRegistrationQueryDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <section class="comp-section">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Inustry Registration: Query DashBoard</h4>
                                <p style="position: absolute; right: 10px; top: 6px; color: red;">
                                    *All Fields Are
										Mandatory
                                </p>
                            </div>
                            <div class="card-body">
                                <asp:HiddenField ID="hdnUserID" runat="server" />
                                <div class="tab-content">
                                    <div class="tab-pane show active" id="basictab1">
                                        <div class="card-body">
                                            <%--<h4 class="card-title"></h4>--%>
                                            <div class="">
                                                <div class="panel-body" id="divAttachmentQuery" runat="server">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="gvAttachmentsQuery" CssClass="table-borderd" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                            CellPadding="4" Height="62px" EmptyDataText="No Queries Found" ShowHeaderWhenEmpty="true"
                                                            PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both" OnRowDataBound="gvAttachmentsQuery_RowDataBound">
                                                            <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" HorizontalAlign="Center" />
                                                            <RowStyle CssClass="GridviewScrollC1Item" HorizontalAlign="Center" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>                                                                       
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="70px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IMAQID" Visible="true">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblirqid" Text='<%#Eval("IMAQID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="UNITID" Visible="true">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblunit" Text='<%#Eval("UNITID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="INVESTERID" Visible="true">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblinvest" Text='<%#Eval("INVESTERID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="PREREGUIDNO" ItemStyle-HorizontalAlign="Center" HeaderText="Application No">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="COMPANYNAME" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QUERYDATE" ItemStyle-HorizontalAlign="Center" HeaderText="Query RaisedDate">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QUERYBY" ItemStyle-HorizontalAlign="Center" HeaderText="Query Raised By">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>

                                                                <asp:BoundField DataField="QUERYRAISEDESC" ItemStyle-HorizontalAlign="Center" HeaderText="Query Description">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>

                                                                <%-- <asp:TemplateField HeaderText="RMTypeId" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRmTypeid" Text='<%#Eval("QUERYRESPONSEBY") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                                <%--ApplicantQueryResponse.aspx--%>
                                                                <asp:TemplateField HeaderText="Query Respond" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkQueryCount" CssClass="btn btn-info" runat="server" Text="Respond to Query" PostBackUrl='<%#Eval("UNITID","~/User/PreReg/IRQueryReason.aspx?UNITID={0}")%>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>

                                                            </Columns>
                                                            <EmptyDataTemplate>No Records Found!</EmptyDataTemplate>
                                                        </asp:GridView>
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
            </section>
        </div>
    </div>
</asp:Content>
