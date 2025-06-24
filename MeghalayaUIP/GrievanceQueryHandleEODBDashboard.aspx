<%@ Page Title="Grievance Handled Dashboard" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="GrievanceQueryHandleEODBDashboard.aspx.cs" Inherits="MeghalayaUIP.GrievanceQueryHandleEODBDashboard" %>

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
    
    <script type="text/javascript">



</script>
    <section class="innerpages mobile">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Dashboard</li>
                                    <li class="breadcrumb-item active" aria-current="page">Grievance Handled Dashboard</li>
                                </ol>
                            </nav>


                            <h3>Grievance Handled Dashboard</h3>
                            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 d-flex" style="margin-bottom: 8px;">
                                <div class="col-md-3 col-lg-3 col-sm-12 col-xs-12 " runat="server">
                                    <div class="form-group row">
                                        <label class="col-md-5 col-form-label" style="text-align: center;">
                                            From Date :</label>
                                        <div class="col-lg-7 d-flex" style="text-align: left; margin-left: -20px;">

                                            <input type="date" id="txtFDate" runat="server" class="date form-control" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 col-lg-3 col-sm-12 col-xs-12 " runat="server">
                                    <div class="form-group row">
                                        <label class="col-md-5 col-form-label" style="text-align: center;">
                                            To Date :</label>
                                        <div class="col-lg-7 d-flex" style="text-align: left; margin-left: -20px;">
                                            <%--<asp:TextBox ID="txtTDate" runat="server" class="date form-control"></asp:TextBox>--%>
                                            <input type="date" id="txtTDate" runat="server" class="date form-control" />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-2 col-lg-2 col-sm-12 col-xs-12 ">
                                    <div class="form-group row">

                                        <div class="col-lg-6 d-flex">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="btn btn-rounded btn-success" Width="80px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="swpd">

                                <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive table-bordered table-sm mb-0 table-hover"
                                    FooterStyle-HorizontalAlign="Left">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S. No." HeaderStyle-CssClass="fw-bold">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:BoundField ItemStyle-Width="1028px" DataField="Particulars" HeaderText="Particulars" HeaderStyle-CssClass="fw-bold" ItemStyle-CssClass="bg-info" />
                                        <asp:BoundField ItemStyle-Width="400px" DataField="TOTAL" HeaderText="Total" HeaderStyle-CssClass="fw-bold" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="bg-info" />
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>
                    </div>
                    <div id="DivFooter" runat="server" style="width:100%;">
                        <div>
                            <div style="font-size: 16px;font-weight: 600; color: black;text-align:center;">
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
    </section>

</asp:Content>
