<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="IntenttoInvestDashboard.aspx.cs" Inherits="MeghalayaUIP.Dept.IntenttoInvestDashboard" %>

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
                    <h4>Intent Invest Applications</h4>
                    <div class="table-responsive">
                    <asp:GridView ID="gvPreRegDtls" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD" ForeColor="#333333"
                        GridLines="None" OnRowDataBound="gvPreRegDtls_RowDataBound"
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
                            <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%><%--ItemStyle-BackColor="Wheat"--%>
                            <asp:BoundField HeaderText="ID" DataField="ID" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="false" />
                            <asp:BoundField HeaderText="CompanyName" DataField="COMPANYNAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                            <asp:BoundField HeaderText="Pan No" DataField="PANNO" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Contact Person Name" DataField="NAME" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Mobile No" DataField="MOBILE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Email Id" DataField="EMAIL" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Details submited Date" DataField="SUBMITTEDDATE" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />


                            <%-- <asp:TemplateField HeaderText="Details" ItemStyle-Width="12%">
                                <%--SortExpression="ciw_id"--%>
                            <%-- <ItemTemplate>
                                    <asp:Button ID="ciw_id" runat="server" Text='View' CommandName="VIEW" CssClass="btn btn-info" OnClick="ciw_id_Click"
                                        CommandArgument='<%# Eval("ID")+"$"+Eval("CompanyName")%>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>--%>

                            <asp:TemplateField HeaderText="Details" ItemStyle-Width="12%">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnDetails" OnClick="btnDetails_Click" Text="View" CssClass="btn btn-info" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="12%" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblID" Text='<%#Eval("ID") %>'></asp:Label>
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
    </div>
</asp:Content>
