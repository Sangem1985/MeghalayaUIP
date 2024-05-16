<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="IndustryRegistrationUserDashboard.aspx.cs" Inherits="MeghalayaUIP.User.PreReg.IndustryRegistrationUserDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">


            <div class="card">
                <div class="card-body">
                    <h4>View Industry Registration Applications</h4>
                    <asp:GridView ID="gvPreRegUserDashboard" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD table-striped table-hover" ForeColor="#333333"
                        GridLines="None" Width="100%" EnableModelValidation="True"  >
                        <RowStyle />
                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="5%">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                            <asp:BoundField HeaderText="Unit ID" DataField="UNITID" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                            <asp:BoundField HeaderText="Invester ID" DataField="INVESTERID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" Visible="false" />
                            <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="PAN No" DataField="COMPANYPANNO" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Communication Address" DataField="APPLICANTADDRESS" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Unit Address" DataField="UNITADDRESS" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                            <asp:BoundField HeaderText="Application Filed Date" DataField="CREATEDDATE" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />

                            <asp:TemplateField HeaderText="Queries Count" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkQueryCount" runat="server" Text='<%#Eval("QUERYCOUNT")%>'  OnClick="lnkQueryCount_Click" ForeColor="Red" Font-Underline="true"></asp:LinkButton> 
                                    <%--PostBackUrl='<%#Eval("INVESTERID","QueryResponse.aspx?Appid={0}")%>'--%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Status Description" DataField="statusdescription" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />


                            <asp:TemplateField HeaderText="Actions" ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" runat="server" Text='View' CommandName="VIEW" CssClass="btn btn-info"
                                        CommandArgument='<%# Eval("UNITID")+"$"+Eval("INVESTERID")%>' OnClick="btnView_Click" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        
                    </asp:GridView>
                </div>
            </div>



        </div>
    </div>
</asp:Content>
