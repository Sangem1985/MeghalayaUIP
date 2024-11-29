<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="Decriminalisation.aspx.cs" Inherits="MeghalayaUIP.Decriminalisation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <section class="innerpages">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                                    <li class="breadcrumb-item">Resources</li>
                                    <li class="breadcrumb-item active" aria-current="page">Decriminalisation</li>
                                </ol>
                            </nav>
                            <section class="innerpages">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <h3>Decriminalisation</h3>
                                            <div class="card">
                                                <div class="card-body justify-content-center " align="justify">
                                                    <div class="row">
                                                        <%-- lables --%>
                                                        <div class="col-md-12 d-flex">
                                                            <%--department--%>
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Department : </label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddldept" runat="server" class="form-control"
                                                                            AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <%-- sector --%>
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Sector :</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:TextBox ID="txtSector" runat="server" class="form-control"
                                                                            AutoPostBack="true"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <%-- search --%>
                                                        <div class="col-md-12 float-left ">
                                                            <div class="form-group row justify-content-center" style="padding: 20px">
                                                                <asp:Button ID="btnSearch" runat="server" Text="Search" ValidationGroup="Search" class="btn btn-rounded btn-success btn-lg" Width="150px" OnClick="btnSearch_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%-- Grid view --%>
                                                    <div class="col-md-90 d-flex">
                                                        <asp:GridView ID="gvDecriminalisation" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CssClass="table-bordered table-hover" ForeColor="#333333"
                                                            GridLines="Both" Width="100%" EnableModelValidation="True"
                                                            ShowFooter="true">
                                                            <RowStyle />
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                            <FooterStyle BackColor="#013161" CssClass="no-hover" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                            <AlternatingRowStyle BackColor="#ccccff" />

                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No." ItemStyle-Width="2%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Department">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="3%"/>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Act / Rule Name">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="3%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblActRuleName" runat="server" Text='<%# Eval("Act_Rule_Name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Section Content">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="3%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSectionContent" runat="server" Text='<%# Eval("Section_content") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Clause / Section No" >
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center"  VerticalAlign="Top" Width="2%"/>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClauseSectionNo" runat="server" Text='<%# Eval("Clause_Section_No") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Clause Description">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="65%"/>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClauseDescription" runat="server" Text='<%# Eval("Clause_Description") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Trigger Points">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTriggerPoints" runat="server" Text='<%# Eval("Trigger_Points") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Punishment">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="45%"/>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPunishment" runat="server" Text='<%# Eval("Punishment") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Sector">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%"/>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSector" runat="server" Text='<%# Eval("Sector") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
