<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="Decriminalisation.aspx.cs" Inherits="MeghalayaUIP.Decriminalisation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table#ContentPlaceHolder1_gvDecriminalisation tr td {
            padding: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <section class="innerpages">
                <div class="container-fluid">
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
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <h3>Decriminalisation</h3>
                                            <div class="card">
                                                <div class="card-body justify-content-center" align="justify">
                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">
                                                                    Department :
           
                                                                </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddldept" runat="server" class="form-control">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">Sector :</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:DropDownList ID="ddlSector" runat="server" class="form-control">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <div class="col-lg-4 d-flex">
                                                                    <asp:Button ID="btnSearch" runat="server" Text="GET" ValidationGroup="Search" class="btn btn-rounded btn-success" Width="150px" OnClick="btnSearch_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group row">
                                                                <label class="col-lg-5 col-form-label">Search :</label>
                                                                <div class="col-lg-7 d-flex">
                                                                    <asp:TextBox ID="txtSearch" onkeyup="filterGridView(this.value)" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-100 d-flex">
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
                            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function filterGridView(searchText) {

            searchText = searchText.toLowerCase();

            // Get the GridView element
            var gridView = document.getElementById('<%= gvDecriminalisation.ClientID %>');

            // Get all rows of the GridView, excluding the header row
            var rows = gridView.getElementsByTagName("tr");

            for (var i = 1; i < rows.length; i++) { // Start from 1 to skip header row
                var row = rows[i];
                var cells = row.getElementsByTagName("td");

                var matchFound = false;
                for (var j = 0; j < cells.length; j++) {
                    var cellText = cells[j].innerText.toLowerCase();
                    if (cellText.indexOf(searchText) !== -1) {
                        matchFound = true;
                        break;
                    }
                }

                // Show or hide the row based on whether the match is found
                row.style.display = matchFound ? "" : "none";
            }
        }


    </script>
</asp:Content>
