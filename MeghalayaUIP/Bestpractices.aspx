<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="Bestpractices.aspx.cs" Inherits="MeghalayaUIP.Bestpractices" %>

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
    <style>
        .swpd thead tr th {
            vertical-align: middle;
            text-align: center;
            font-weight: 400;
            background: #054c93;
            color: #fff !important;
        }

        table.table.table-responsive.table-bordered.table-sm.mb-0.table-hover {
            font-size: 14px;
            text-align: center;
        }

            table.table.table-responsive.table-bordered.table-sm.mb-0.table-hover tbody tr th {
                text-align: center;
            }

        .swpd table.table.table-responsive.table-bordered.table-sm.mb-0.table-hover {
            border-radius: 14px !important;
            display: block;
        }

        tfoot tr th {
            text-align: center;
        }

        td.bg-info {
            text-align: left;
            font-weight: 900;
            color: #432b6b;
            padding: 10px !important;
            background: #fffcfd;
        }

        table#ContentPlaceHolder1_gvDepts tr th {
            margin: 10px !important;
            padding: 8px 8px;
            background: #3e2a6c;
            color: #fff;
        }

        td.fw-bold {
            padding: 10px;
            color: #3d2a6c;
            font-weight: 500;
        }

        input#ContentPlaceHolder1_txtFDate, input#ContentPlaceHolder1_txtTDate {
            width: 110%;
        }

        .bg-info {
            background-color: #fdfdfd00 !important;
        }

        table#ContentPlaceHolder1_gvDepts {
            width: 96.9% !important;
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
                                    <li class="breadcrumb-item">Services</li>
                                    <li class="breadcrumb-item active" aria-current="page">Best Practices</li>
                                </ol>
                            </nav>
                            <section class="innerpages">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <%-- <nav aria-label="breadcrumb">
                     <ol class="breadcrumb">
                         <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                         <li class="breadcrumb-item">Services</li>
                         <li class="breadcrumb-item active" aria-current="page">Information Wizard</li>
                     </ol>
                 </nav>--%>

                                            <h3>Best Practices</h3>
                                            <div class="card">
                                                <div class="card-body justify-content-center " align="justify">
                                                    <div class="row">
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Department Name :</label>
                                                                    <%--<select class="form-control" aria-label="Default select example">
                                                                        <option selected>select Department</option>
                                                                        <option value="1">Co-Operation</option>
                                                                        <option value="2">Department of Urban Affairs</option>
                                                                        <option value="3">Department of Forest</option>
                                                                    </select>--%>
                                                                    <asp:DropDownList runat="server" ID="ddldepartment" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddldepartment_SelectedIndexChanged">
                                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Sub-Department Name : </label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <%-- <select class="form-control" aria-label="Default select example">
                                                                            <option selected>select Sub-Department</option>
                                                                            <option value="1">CIBF</option>
                                                                            <option value="2">Labour</option>
                                                                            <option value="3">Planning </option>
                                                                        </select>--%>
                                                                        <asp:DropDownList runat="server" ID="ddlSubDepartment" class="form-control">
                                                                            <asp:ListItem Text="--Select--" Value="%"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Sector :</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <%-- <select class="form-control" aria-label="Default select example">
                                                                            <option selected>select Sector</option>
                                                                            <option value="1">Priority Sector-Hotels & Hospitality</option>
                                                                            <option value="2">Priority Sector-Tourism (Homestays, Adventure, Health Tourism, Eco-Tourism & MICE)</option>
                                                                            <option value="3">Priority Sector-Bio-Technology</option>
                                                                        </select>--%>
                                                                        <asp:DropDownList runat="server" ID="ddlsector" class="form-control">
                                                                            <asp:ListItem Text="--Select--" Value="%"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 float-left ">
                                                            <div class="form-group row justify-content-center" style="padding: 20px">
                                                                <%--<asp:Button ID="btnSearch1111" runat="server" OnClick="" Text="Search" ValidationGroup="Search" class="btn btn-rounded btn-success btn-lg" Width="150px" />--%>

                                                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="btn btn-rounded btn-success" Width="80px" />
                                                            </div>
                                                        </div>
                                                        

                                                        <div class="col-md-100 d-flex">
                                                            <asp:GridView ID="GvBestPractices" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                                BorderStyle="Solid" BorderWidth="1px" CssClass="table-bordered table-hover" ForeColor="#333333" 
                                                                GridLines="Both" Width="100%" EnableModelValidation="True"
                                                                ShowFooter="false">
                                                                <RowStyle BorderColor="Black" />
                                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                                <FooterStyle BackColor="#013161" CssClass="no-hover" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                <AlternatingRowStyle BackColor="#ccccff" BorderColor="Black" />

                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl.No." >
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Department">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"  />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDeptID" runat="server" Visible="false"  Text='<%# Eval("DEPTID") %>'></asp:Label>
                                                                            <asp:Label ID="lblDept" runat="server" Text='<%# Eval("DEPARTMENTNAME") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Sub Department Name">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"  />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSubDeptID" runat="server" Visible="false" Text='<%# Eval("SUB_DEPTID") %>'></asp:Label>
                                                                            <asp:Label ID="lblSubDept" runat="server" Text='<%# Eval("SUB_DEPARTMENTNAME") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Sector">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"  />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSector" runat="server" Text='<%# Eval("SECTOR") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Best Practice Description ">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSubBestPractice" runat="server" Text='<%# Eval("SUB_BESTPRACTICE") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                            <%--<asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                             <ProgressTemplate>
                                 <div class="update">
                                 </div>
                             </ProgressTemplate>
                         </asp:UpdateProgress>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
