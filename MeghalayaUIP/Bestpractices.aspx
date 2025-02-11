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
                                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
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
                                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
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
                                                        <div class="col-md-12 d-flex" id="bestpractice" runat="server" visible="false">
                                                            <asp:GridView ID="GvBest" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive table-bordered table-sm mb-0 table-hover"
                                                                DataKeyNames="TMD_DEPTID" OnRowDataBound="GvBest_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <img alt="" style="cursor: pointer" src="assets/assetsnew/images/plus.png" />
                                                                            <img alt="" style="cursor: pointer; display: none" src="assets/assetsnew/images/minus.png" />
                                                                            <asp:Panel ID="pnlApprovals" runat="server" Style="display: none">
                                                                                <asp:GridView ID="gvApprovals" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid"
                                                                                    ShowFooter="true">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No." HeaderStyle-BackColor="#650855">
                                                                                            <ItemTemplate>
                                                                                                <%# Container.DataItemIndex + 1%>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />

                                                                                            <ItemStyle Width="40px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="ApprovalName" HeaderStyle-BackColor="#650855" HeaderText="Approval Name" ItemStyle-CssClass="fw-bold" />
                                                                                        <asp:BoundField DataField="TIMELIMIT" HeaderStyle-BackColor="#650855" HeaderText="Time limit prescribed" />
                                                                                        <asp:BoundField DataField="TOTALAPPLICATIONSRCVD" HeaderStyle-BackColor="#650855" HeaderText="Total number of applications received" />
                                                                                        <asp:BoundField DataField="TOTALAPPROVRED" HeaderStyle-BackColor="#650855" HeaderText="Approved" />
                                                                                        <asp:BoundField DataField="TOTALREJECTED" HeaderStyle-BackColor="#650855" HeaderText="Rejected" />
                                                                                        <asp:BoundField DataField="AVGTIMETOGRANT" HeaderStyle-BackColor="#650855" HeaderText="Average time taken to grant approval (in Days)" />
                                                                                        <asp:BoundField DataField="MDMTIMETOGRANT" HeaderStyle-BackColor="#650855" HeaderText="Median time taken to grant approval (in Days)" />
                                                                                        <asp:BoundField DataField="AVERAGEFEE" HeaderStyle-BackColor="#650855" HeaderText="Average Fee for Application" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </asp:Panel>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="4%" />
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S. No." HeaderStyle-CssClass="fw-bold">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="5%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Deptid" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDeptid" runat="server" Text='<%#Eval("TMD_DEPTID")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField ItemStyle-Width="1028px" DataField="TMD_DeptName" HeaderText="Department Name" HeaderStyle-CssClass="fw-bold" ItemStyle-CssClass="bg-info" />
                                                                    <asp:TemplateField HeaderText="Total Applications Received">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lblApplProcess" Text='<%#Eval("TOTALAPPLICATIONSRCVD")%>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Applications Processed">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lblAlprocess" Text='<%#Eval("TOTALPROCESSED")%>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>

                                                        <div class="col-md-100 d-flex">
                                                        <asp:GridView ID="GvBestPractices" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
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
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="3%" />
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

                                                                <asp:TemplateField HeaderText="Clause / Section No">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClauseSectionNo" runat="server" Text='<%# Eval("Clause_Section_No") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Clause Description">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="75%" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="80%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblClauseDescription" runat="server" Text='<%# Eval("Clause_Description") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Trigger Points">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTriggerPoints" runat="server" Text='<%# Eval("Trigger_Points") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Punishment">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="45%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPunishment" runat="server" Text='<%# Eval("Punishment") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Sector">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" />
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
