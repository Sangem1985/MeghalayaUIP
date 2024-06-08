<%@ Page Title="" Language="C#" MasterPageFile="~/outer.Master" AutoEventWireup="true" CodeBehind="ViewCertifcateDetails.aspx.cs" Inherits="MeghalayaUIP.ViewCertifcateDetails" %>

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
                            <li class="breadcrumb-item active" aria-current="page">View Certifcate Details</li>
                        </ol>
                    </nav>

                    <h3>View Certifcate Details</h3>


                    <div class="col-md-6">
                        <div class="col-md-6 text-right">Type of Application</div>
                        <div class="col-md-6">
                            <%-- <select class="form-control" runat="server" aria-label="Default select example" style="width: 100%; height: 32px;">
                                <option selected>Select Application</option>
                                <option value="1">CFE</option>
                                <option value="2">CFO</option>
                                <option value="3">Renewls</option>
                            </select>--%>
                            <asp:DropDownList ID="ddlTypeApplication" runat="server" aria-label="Default select example" Style="width: 100%; height: 32px;">
                                <asp:ListItem Value="0" Selected="True">Select Application</asp:ListItem>
                                <asp:ListItem Value="1">CFE</asp:ListItem>
                                <asp:ListItem Value="2">CFO</asp:ListItem>
                                <asp:ListItem Value="3">Renewls</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="col-md-6 text-right">Enter UID Number</div>
                        <div class="col-md-6">
                            <input type="text" id="txtUIDNo" runat="server" class="form-control" name="input" />
                        </div>
                    </div>
                    <div class="col-md-6" style="margin-top: 20px;">
                        <div class="col-md-6 text-right">Enter Name of Unit</div>
                        <div class="col-md-6">
                            <input type="text" id="txtUnitName" runat="server" class="form-control" name="input" />
                        </div>
                    </div>
                    <div class="col-md-4 text-center" style="margin-top: 20px;">
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-info btn-submit" OnClick="btnsubmit_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-12 d-flex" id="divGrid" runat="server" visible="false" style="margin-top: 25px;">
                <div class="table-responsive">
                    <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        CssClass="table-hover" ForeColor="#333333" Width="100%" BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="No Data Available">
                        <RowStyle CssClass="GRDITEM" VerticalAlign="Middle" />
                        <HeaderStyle CssClass="GRDHEADER" Font-Bold="True" ForeColor="Black" BackColor="blanchedalmond" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="NAMEOFUNIT" HeaderText="Unit Name">
                                <ItemStyle Width="350px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UIDNO" HeaderText="UID No">
                                <ItemStyle Width="350px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UNITLOCATION" HeaderText="Unit Location">
                                <ItemStyle Width="350px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UNITADDRESS" HeaderText="Unit Address">
                                <ItemStyle Width="350px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:Hyperlink Text="View" runat="server" ID="hypView" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
