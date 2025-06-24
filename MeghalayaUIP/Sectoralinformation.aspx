<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="Sectoralinformation.aspx.cs" Inherits="MeghalayaUIP.Sectoralinformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table#servicestable th {
            vertical-align: middle;
        }

        select#ContentPlaceHolder1_ddlPolCategory {
            display: block;
            width: 100%;
            padding: 0.475rem 0.75rem;
            font-size: 1rem;
            line-height: 1.7;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
        }
    </style>
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
                                    <li class="breadcrumb-item">Resources / ODOP</li>
                                    <li class="breadcrumb-item active" aria-current="page">Sectoral Information</li>
                                </ol>
                            </nav>
                            <section class="innerpages">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-12">

                                            <h3>Sectoral Information</h3>
                                            <div class="card mobile">
                                                <div class="card-body justify-content-center " align="justify">
                                                    <div class="row">
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Department :</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddldept" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddldept_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Approval Name :</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlApprovals" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlApprovals_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">State/Center Level Approval : </label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlState" runat="server" class="form-control"
                                                                            AutoPostBack="true">
                                                                            <asp:ListItem Text="All" Value="%"></asp:ListItem>
                                                                            <asp:ListItem Text="State" Value="State"></asp:ListItem>
                                                                            <asp:ListItem Text="Center" Value="Center"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">

                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Sector:</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlSector" runat="server" class="form-control"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlSector_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Stage: </label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlModule" runat="server" class="form-control"
                                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                                                                            <asp:ListItem Text="All" Value="%"></asp:ListItem>
                                                                            <asp:ListItem Text="Pre Establishment" Value="CFE"></asp:ListItem>
                                                                            <asp:ListItem Text="Pre Operational" Value="CFO"></asp:ListItem>
                                                                            <asp:ListItem Text="Renewals" Value="REN"></asp:ListItem>
                                                                            <asp:ListItem Text="Others" Value="Other"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12" id="divproducts" runat="server" visible="false">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Products:</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlodop" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlodop_SelectedIndexChanged">
                                                                            <asp:ListItem Text="All" Value="%"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex justify-content-center">
                                                            <div class="col-md-4 mt-4 ml-4">
                                                                <div class="form-group">
                                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="btn btn-rounded btn-success" Width="80px" />
                                                                </div>
                                                            </div>
                                                        </div>



                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex">
                                                            <asp:GridView ID="GVSector" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                                BorderStyle="Solid" BorderWidth="1px" CssClass="table-bordered table-hover table-responsive" ForeColor="#333333"
                                                                GridLines="Both" Width="100%" EnableModelValidation="True"
                                                                ShowFooter="true">
                                                                <RowStyle />
                                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                <FooterStyle BackColor="#013161" CssClass="no-hover" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                <AlternatingRowStyle BackColor="#ccccff" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl.No." ItemStyle-Width="3%">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <%-- <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblApprovalid" runat="server" Text='<%#Eval("IW_APPROVALID") %>' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-ForeColor="WindowText" Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>

                                                                    <asp:BoundField HeaderText="Name of Approval" DataField="ApprovalName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-ForeColor="WindowText" Visible="true" />
                                                                    <asp:BoundField HeaderText="State/Center level approval" DataField="ApprovalLevel" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="Name of Department" DataField="TMD_DeptName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="Name of Sector" DataField="Sector" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="Product" DataField="PRODUCTS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" />
                                                                    <asp:BoundField HeaderText="Stage" DataField="STAGES" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:TemplateField HeaderText="Apply Online" ItemStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnOnline" runat="server" Text='Apply Online' CommandName="Apply" CssClass="btn btn-info" OnClick="btnOnline_Click" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div align="center" style="text-align: center; padding: 20px;">
                                                                        No Services Found
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
