﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEQueryDashBoard.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEQueryDashBoard" %>

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
                                <h4 class="card-title">Pre-Establishment Query DashBoard</h4>
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
                                            <div class="">
                                                <div class="panel-body" >
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="gvQuery" CssClass="table-borderd" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                            CellPadding="4" Height="62px" EmptyDataText="No Queries Found" ShowHeaderWhenEmpty="true" OnRowDataBound="gvQuery_RowDataBound"
                                                            PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both">
                                                            <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" HorizontalAlign="Center" />
                                                            <RowStyle CssClass="GridviewScrollC1Item" HorizontalAlign="Center" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="70px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="QueryID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblQueryID" Text='<%#Eval("CFEQID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="UnitID" Visible="true">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitID" Text='<%#Eval("CFEQ_CFEUNITID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DEPTID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDeptID" Text='<%#Eval("CFEQ_DEPTID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>  
                                                                 <asp:TemplateField HeaderText="ApprovalID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApprovalID" Text='<%#Eval("CFEQ_APPROVALID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>  
                                                                <asp:BoundField DataField="CFEQD_COMPANYNAME" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                 <asp:BoundField DataField="ApprovalName" ItemStyle-HorizontalAlign="Center" HeaderText="ApprovalName">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                 <asp:BoundField DataField="QUERYBY" ItemStyle-HorizontalAlign="Center" HeaderText="Query Raised By">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QUERYDATE" ItemStyle-HorizontalAlign="Center" HeaderText="Query RaisedDate">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CFEQ_QUERYRAISEDESC" ItemStyle-HorizontalAlign="Center" HeaderText="Query Description">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Query Respond" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkQueryCount" CssClass="btn btn-info" runat="server" Text="Respond" ></asp:LinkButton>
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