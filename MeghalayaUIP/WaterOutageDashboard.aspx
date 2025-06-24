<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="WaterOutageDashboard.aspx.cs" Inherits="MeghalayaUIP.WaterOutageDashboard" %>
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
                border: 1px solid #b2e2ff;
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
                                <li class="breadcrumb-item active" aria-current="page">Other Dashboard</li>
                                <li class="breadcrumb-item active" aria-current="page">Planned outage supply dashboard</li>
                            </ol>
                        </nav>


                        <h4>Planned Outage Water Supply</h4>
                        <br />
                        <div class="mobile">
                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex" style="margin-bottom: 8px;">
                            <div class="col-md-3 col-lg-3 col-sm-12 col-xs-12" runat="server" visible="false">
                                <div class="form-group row">
                                    <label class="col-md-5 col-form-label" style="text-align: right;">
                                        From Date :</label>
                                    <div class="col-lg-7 d-flex" style="text-align: left; margin-left: -20px;">

                                        <input type="date" id="txtFDate" runat="server" class="date form-control" />

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3 col-lg-3 col-sm-12 col-xs-12" runat="server" visible="false">
                                <div class="form-group row">
                                    <label class="col-md-5 col-form-label" style="text-align: right;">
                                        To Date :</label>
                                    <div class="col-lg-7 d-flex" style="text-align: left; margin-left: -20px;">
                                        <%--<asp:TextBox ID="txtTDate" runat="server" class="date form-control"></asp:TextBox>--%>
                                        <input type="date" id="txtTDate" runat="server" class="date form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 d-flex">
                                <div class="col-md-6" style="margin-top: 4px;">
                                    Municipal Board:
                                </div>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlMunicipalBoard" runat="server" class=" form-control" AutoPostBack="true" OnSelectedIndexChanged="btnSearch_Click">
                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                        <asp:ListItem Value="1">Shillong Municipal Board</asp:ListItem>
                                        <asp:ListItem Value="2">Tura Municipal Board</asp:ListItem>
                                        <asp:ListItem Value="3"> Jowai Municipal Board</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2 col-lg-2 col-sm-12 col-xs-12">
                                <div class="form-group row">

                                    <div class="col-lg-6 d-flex">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="btn btn-rounded btn-success" Width="80px" />
                                    </div>
                                </div>
                            </div>
                        </div>  
                            </div>
                        <div class="swpd">

                            <asp:GridView ID="GVWater" runat="server" AutoGenerateColumns="False" ShowHeader="True" CssClass="water-grid table table-responsive"
                                EmptyDataText="No Data Found" EmptyDataRowStyle-ForeColor="Black" EmptyDataRowStyle-Font-Bold="true" BackColor="#e9ecf5"
                                BorderStyle="None" BorderWidth="1px" ShowHeaderWhenEmpty="true">
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
                                    <asp:BoundField HeaderText="Areas which will be affected by Water Outage" DataField="AREAWATER" />
                                    <asp:BoundField HeaderText="Period of Water Outages (from and to dates)" DataField="PERIODWATEROUTAGE" />
                                    <asp:BoundField HeaderText="Water Outage Causes" DataField="WATEROUTAGECAUSES" />
                                    <asp:BoundField HeaderText="Approved Copy Download" DataField="APPROVED" />
                                    <asp:BoundField HeaderText="Archive Data" DataField="ARCHIVEDATA" />
                                </Columns>   
                                 <EmptyDataTemplate>
                                    <div style="text-align: center; padding: 10px;">
                                        No Planned Outage Water Supply Data...!
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>

                    </div>
                </div>
                <div id="DivFooter" runat="server" style="width:100%;">
                    <div>
                        <div style="font-size: 16px;font-weight: 600; text-align:center; color: black;">
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
