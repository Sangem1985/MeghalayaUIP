﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="CFEApplDeptView.aspx.cs" Inherits="MeghalayaUIP.Dept.CFE.CFEApplDeptView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper" style="">
        <div class="content container-fluid">
            <div class="card">
                <div class="card-body">
                    <h4>View Pre Establishment Applications</h4>
                    <asp:GridView ID="gvCFEDtls" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD" ForeColor="#333333"
                        GridLines="None" OnRowCommand="gvCFEDtls_RowCommand"
                        Width="100%" EnableModelValidation="True">
                        <RowStyle />
                        <Columns>
                            <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                            <asp:BoundField HeaderText="Unit ID" DataField="CFEQDID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="false" />
                            <asp:BoundField HeaderText="Invester ID" DataField="INVESTERID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" Visible="false" />
                            <asp:BoundField HeaderText="ID" DataField="CFEQD_CFEUIDNO" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Communication Address" DataField="APPLICANTADDRESS" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Unit Address" DataField="UNITADDRESS" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Application Filed Date" DataField="CREATEDDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Dept ID" DataField="CFEDA_DEPTID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="false" />
                            <asp:BoundField HeaderText="Approval ID" DataField="CFEDA_APPROVALID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="false" />
                            <asp:TemplateField HeaderText="Actions" ItemStyle-Width="12%">
                                <%--SortExpression="ciw_id"--%>
                                <ItemTemplate>
                                    <asp:Button ID="ciw_id" runat="server" Text='Process' CommandName="VIEW" CssClass="btn btn-info"
                                        CommandArgument='<%# Eval("CFEQDID")+"$"+Eval("INVESTERID")%>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>
</asp:Content>