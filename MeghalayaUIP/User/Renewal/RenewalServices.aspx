<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RenewalServices.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RenewalServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Renewal Services</li>
                        </ol>
                    </nav>
                    <h3>Renewal Services</h3>
                </div>
                <div class="col-md-12">
                    <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">×</span></button>
                    </div>
                </div>
                <div class="col-md-12">
                    <div id="Failure" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show" align="Center">
                        <strong>Warning!</strong>
                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                </div>
                <asp:HiddenField ID="hdnUserID" runat="server" />
            </div>
            <div class="col-md-12 d-flex" id="divGrid" runat="server" visible="true" style="margin-top: 25px;">
                <div class="table-responsive">
                    <asp:GridView ID="gvRenewals" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        CssClass="table-hover" ForeColor="#333333" Width="100%" BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px"
                        EmptyDataText="No Data Available" OnRowDataBound="gvRenewals_RowDataBound">
                        <RowStyle CssClass="GRDITEM" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="GRDHEADER" Font-Bold="True" ForeColor="Black" BackColor="blanchedalmond" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="S No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkApproval" Checked='<%# Eval("IsApplied").ToString() == "1" ? true : false %>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Approval / Service Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("ApprovalName")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="90%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fee" Visible="true">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblApprovalFee" Text='<%# Eval("FEE")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="90%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Approval Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblApprovalId" runat="server" Text='<%# Eval("ApprovalId")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dept Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeptId" runat="server" Text='<%# Eval("Dept_Id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-md-12 text-center mb-2" style="margin-top: 15px;">
                <asp:Button ID="btnApply" runat="server" Text="Apply" class="btn btn-info btn-rounded btn-lg" Width="150px" OnClick="btnApply_Click" />
            </div>
        </div>
    </section>
</asp:Content>

