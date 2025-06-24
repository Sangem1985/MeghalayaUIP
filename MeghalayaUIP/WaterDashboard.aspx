<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="WaterDashboard.aspx.cs" Inherits="MeghalayaUIP.WaterDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

        table#ContentPlaceHolder1_gvDetails tr th {
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

        table#ContentPlaceHolder1_gvDetails {
            width: 96.9% !important;
        }
    </style>
    <style>
        .water-grid {
            width: 100%;
            border-collapse: collapse;
        }

            .water-grid th, .water-grid td {
                border: 1px solid #005691;
                padding: 8px;
                font-size: 12px;
                text-align: center;
            }

            .water-grid th {
                background-color: #1e73be;
                color: white;
                white-space: pre-line;
            }
    </style>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                                <li class="breadcrumb-item active" aria-current="page">Report</li>
                                <li class="breadcrumb-item active" aria-current="page">Water Quality Monitoring Dashboard</li>
                            </ol>
                        </nav>


                        <h4>Water Quality Monitoring Dashboard</h4><br />
                        <div class="mobile">
                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex" style="margin-bottom: 8px;">
                            <div class="col-md-3 col-lg-3 col-sm-12 col-xs-12 " runat="server" visible="false">
                                <div class="form-group row">
                                    <label class="col-md-5 col-form-label" style="text-align: right;">
                                        From Date :</label>
                                    <div class="col-lg-7 d-flex" style="text-align: left; margin-left: -20px;">

                                        <input type="date" id="txtFDate" runat="server" class="date form-control" />

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3 col-lg-3 col-sm-12 col-xs-12 " runat="server" visible="false">
                                <div class="form-group row">
                                    <label class="col-md-5 col-form-label" style="text-align: right;">
                                        To Date :</label>
                                    <div class="col-lg-7 d-flex" style="text-align: left; margin-left: -20px;">
                                        <%--<asp:TextBox ID="txtTDate" runat="server" class="date form-control"></asp:TextBox>--%>
                                        <input type="date" id="txtTDate" runat="server" class="date form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12  d-flex">
                                <div class="col-md-6" style="margin-top: 4px;">
                                    Municipal Board:
                                </div>
                                <div class="col-md-6 ">
                                    <asp:DropDownList ID="ddlMunicipalBoard" runat="server" class=" form-control" AutoPostBack="true" OnSelectedIndexChanged="btnSearch_Click">
                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                        <asp:ListItem Value="1">Shillong Municipal Board</asp:ListItem>
                                        <asp:ListItem Value="2">Tura Municipal Board</asp:ListItem>
                                        <asp:ListItem Value="3"> Jowai Municipal Board</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group row">

                                    <div class="col-lg-6 d-flex">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="btn btn-rounded btn-success" Width="80px" />
                                    </div>
                                </div>
                            </div>
                        </div>
                            </div>
                        <div class="swpd">

                            <asp:GridView ID="gvWaterQuality" runat="server" AutoGenerateColumns="False" ShowHeader="True" CssClass="water-grid table table-responsive" 
                                EmptyDataText="No Data Found" EmptyDataRowStyle-ForeColor="Black" EmptyDataRowStyle-Font-Bold="true" BackColor="#e9ecf5"
                                BorderStyle="None" BorderWidth="1px" OnRowCreated="gvWaterQuality_RowCreated" ShowHeaderWhenEmpty="true">
                                <HeaderStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                <RowStyle CssClass="GridviewScrollC1Item" />
                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S. No." HeaderStyle-CssClass="fw-bold">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>

                                    <asp:BoundField HeaderText="Area" DataField="AREA" />
                                    <asp:BoundField HeaderText="Date of Sample Collection" DataField="DATEOFSAMPLECOLLECTION" />
                                    <asp:BoundField HeaderText="Date of Testing" DataField="DATEOFTESTING" />
                                    <asp:BoundField HeaderText="Acceptable Limit: 6.5-8.5&#10;Permissible Limit: 6.5-8.5" DataField="ACCEPTABLELIMITPERMISSIBLEPH" />
                                    <asp:BoundField HeaderText="Acceptable Limit: 500&#10;Permissible Limit: 2000" DataField="ACCEPTABLETDS" />
                                    <asp:BoundField HeaderText="Acceptable Limit: 1.0&#10;Permissible Limit: No relaxation" DataField="ACCEPTABLEIRON" />
                                    <asp:BoundField HeaderText="Acceptable Limit: 1.0&#10;Permissible Limit: 5.0" DataField="ACCEPTABLENUT" />
                                    <asp:BoundField HeaderText="Acceptable Limit: 1.0&#10;Permissible Limit: 1.5" DataField="ACCEPTABLEFLUORIDE" />
                                    <asp:BoundField HeaderText="Acceptable Limit: 250&#10;Permissible Limit: 1000" DataField="ACCEPTABLECHLORIDE" />
                                    <asp:BoundField HeaderText="Acceptable Limit: 200&#10;Permissible Limit: 600" DataField="ACCEPTABLEALKALINITY" />
                                    <asp:BoundField HeaderText="Acceptable Limit: 0.01&#10;Permissible Limit: No relaxation" DataField="ACCEPTABLEARSENIC" />
                                    <asp:BoundField HeaderText="Acceptable Limit: 0.2&#10;Permissible Limit: 1.0" DataField="ACCEPTABLERESIDUALFREECHORINE" />
                                    <asp:BoundField HeaderText="Acceptable Limit: 200&#10;Permissible Limit: 600" DataField="ACCEPTABLETOTALHARDNESS" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="text-align: center; padding: 10px;">
                                        No Water Quality Dashboard Data
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
                <div id="DivFooter" runat="server">
                    <div>
                        <div style="font-size: 16px; margin-left: 190px; font-weight: 600; color: black;">
                            <asp:Label ID="LBLDATETEXT" runat="server" Text="The Data in the Dashboard is updated on a real time basis. Last update:"></asp:Label><asp:Label ID="LBLDATETIME" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
