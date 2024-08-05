<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="SingleWindowPortalDashboard.aspx.cs" Inherits="MeghalayaUIP.SingleWindowPortalDashboard" %>

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
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>--%>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/css/bootstrap-datepicker.css" rel="stylesheet" />
    <script type="text/javascript" src="httpS://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/js/bootstrap-datepicker.js"> </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.js"> </script>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/admin/js/jquery-3.2.1.min.js"></script>
    <script src="assets/admin/js/jquery-ui.min.js"></script>
    <script src="assets/js/jquery-1.7.2.min.js"></script>

    <script type="text/javascript">


        //function pageLoad() {
        //    var date = new Date();
        //    var yrRange = "2023:" + (date.getFullYear() + 1);

        //    var currentMonth = date.getMonth();
        //    var currentDate = date.getDate();
        //    var currentYear = date.getFullYear();

        //    $("input[id$='txtFDate']").datepicker(
        //        {
        //            dateFormat: "dd-mm-yy",
        //            changeMonth: true,
        //            changeYear: true,
        //            yearRange: yrRange
        //        });
        //    $("input[id$='txtTDate']").datepicker(
        //        {
        //            dateFormat: "dd-mm-yy",
        //            changeMonth: true,
        //            changeYear: true,
        //            yearRange: yrRange
        //        });

        //}
        //$(function () {
        //    var date = new Date();
        //    var yrRange = "2023:" + (date.getFullYear() + 1);
        //    var currentMonth = date.getMonth();
        //    var currentDate = date.getDate();
        //    var currentYear = date.getFullYear();
        //    $("input[id$='txtFDate']").datepicker(
        //        {
        //            dateFormat: "dd-mm-yy",
        //            changeMonth: true,
        //            changeYear: true,
        //            yearRange: yrRange
        //        });
        //    $("input[id$='txtTDate']").datepicker(
        //        {
        //            dateFormat: "dd-mm-yy",
        //            changeMonth: true,
        //            changeYear: true,
        //            yearRange: yrRange
        //        });

        //});


        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td class='orders' colspan = '999'>" + $(this).closest("tr").find("[id*=Approvals]").html() + "</td></tr>");
            $(this).closest("tr").find("[src*=minus]").show();
            $(this).hide();
        });
        $("[src*=minus]").live("click", function () {
            $(this).closest("tr").next().remove();
            $(this).closest("tr").find("[src*=plus]").show();
            $(this).hide();
        });
    </script>
    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Services</li>
                            <li class="breadcrumb-item active" aria-current="page">Single Window Portal Dashboard</li>
                        </ol>
                    </nav>


                    <h3>Single Window Portal Dashboard</h3>
                    <div class="col-md-12 d-flex" style="margin-bottom: 8px;">
                        <div class="col-md-3">
                            <div class="form-group row">
                                <label class="col-md-5 col-form-label" style="text-align: right;">
                                    From Date :</label>
                                <div class="col-lg-7 d-flex" style="text-align: left;margin-left: -20px;">

                                    <input type="date" id="txtFDate" runat="server" class="date form-control" />
                                   
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group row">
                                <label class="col-md-5 col-form-label" style="text-align: right;">
                                    To Date :</label>
                               <div class="col-lg-7 d-flex" style="text-align: left;margin-left: -20px;">
                                    <%--<asp:TextBox ID="txtTDate" runat="server" class="date form-control"></asp:TextBox>--%>
                                    <input type="date" id="txtTDate" runat="server" class="date form-control" />
                                    
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 d-flex">
                            <div class="col-md-6" style="margin-top: 4px;">Department Name :</div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlDept" runat="server" class=" form-control" >
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group row">

                                <div class="col-lg-6 d-flex">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-rounded btn-success" Width="80px" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="swpd">
                        <%-- <table class="table table-responsive table-bordered table-sm mb-0 table-hover">
  <thead>
    <tr>
      <th scope="col" rowspan="2">S.No</th>
      <th scope="col" rowspan="2" style="width:40%;">Department/Application Name</th>
      <th scope="col" rowspan="2">Time limit prescribed *</th>
      <th scope="col" rowspan="2">Total number of applications received</th>
      <th scope="col" colspan="2">Total number of applications processed</th>
      <th scope="col" rowspan="2">Average time taken to grant approval (in Days)</th>
      <th scope="col" rowspan="2">Median time taken to grant approval (in Days)</th>
    </tr>
      <tr>
          <th>Approved</th>
          <th>Rejected</th>
      </tr>
  </thead>
  <tbody>
    <tr class="bg-info">
      <th scope="row">1</th>
          <th scope="row" colspan="7" style="text-align:left">Agriculture Department</th>
    </tr>
    <tr>
      <td  class="ti-align-right">&nbsp;1</td>
      <td style="text-align:left">Report for development of land located in non-planned areas (Dry Land)</td>
      <td>20</td>
      <td>165</td>
      <td>100</td>
      <td>53</td>
      <td>62</td>
      <td>27</td>
    </tr>
    <tr>
      <td scope="row" class="ti-align-right">&nbsp;<b>Total</b></td>
      <td>&nbsp;</td>
      <th>-</th>
      <th>165</th>
      <th>100</th>
      <th>53</th>
      <th>62</th>
      <th>27</th>
    </tr>

      <tr class="bg-info">
      <th scope="row">2</th>
          <th scope="row" colspan="7" style="text-align:left">Chennai District - Commissioner,Greater Chennai Corporation, Other Districts - Respective District Collectors</th>
    </tr>
      <tr>
      <td  class="ti-align-right">&nbsp;1</td>
      <td style="text-align:left">Permission for installation of over-ground telecom infrastructure</td>
      <td>15</td>
      <td>1</td>
      <td>0</td>
      <td>1</td>
      <td>-</td>
      <td>-</td>
    </tr>
    <tr>
      <td scope="row" class="ti-align-right">&nbsp;<b>Total</b></td>
      <th>&nbsp;</th>
      <th>-</th>
      <th>1</th>
      <th>0</th>
      <th>1</th>
      <th>-</th>
      <th>-</th>
    </tr>
       <tr class="bg-info">
      <th scope="row">3</th>
        <th scope="row" colspan="7" style="text-align:left">Commissionerate of Industries and Commerce</th>
    </tr>
       <tr>
      <td  class="ti-align-right">&nbsp;1</td>
      <td style="text-align:left">Approval for capital subsidy</td>
      <td>30</td>
      <td>14</td>
      <td>13</td>
      <td>1</td>
      <td>42</td>
      <td>1</td>
    </tr>
       <tr>
      <td  class="ti-align-right">&nbsp;2</td>
      <td style="text-align:left">Approval for Low Tension Power Tariff (LTPT) Subsidy- Claim</td>
      <td>30</td>
      <td>5</td>
      <td>5</td>
      <td>0</td>
      <td>29</td>
      <td>29</td>
    </tr>
      <tr>
      <td  class="ti-align-right">&nbsp;3</td>
      <td style="text-align:left">Approval for Low Tension Power Tariff (LTPT) Subsidy - Eligibility Certificate (EC)</td>
      <td>30</td>
      <td>4</td>
      <td>4</td>
      <td>0</td>
      <td>175</td>
      <td>172</td>
    </tr>
       <tr>
      <td  class="ti-align-right">&nbsp;4</td>
      <td style="text-align:left">Grant of Quality Certification Reimbursement of Charges</td>
      <td>45</td>
      <td>1</td>
      <td>1</td>
      <td>0</td>
      <td>0</td>
      <td>0</td>
    </tr>
    <tr>
      <th class="ti-align-right fw-bold">&nbsp;<b>Total</b></th>
      <th>&nbsp;</th>
      <th>-</th>
      <th>24</th>
      <th>23</th>
      <th>1</th>
      <th>61</th>
      <th>26</th>
    </tr>
  </tbody>
                        <tfoot>
                            <tr>
                            <th class="fw-bold"><b>Grand Total</b></th>
      <th>&nbsp;</th>
      <th>-</th>
      <th>190</th>
      <th>123</th>
      <th>55</th>
      <th>-</th>
      <th>-</th>
                                </tr>
                        </tfoot>
</table>--%>

                        <asp:GridView ID="gvDepts" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive table-bordered table-sm mb-0 table-hover"
                            DataKeyNames="TMD_DEPTID" OnRowDataBound="gvDepts_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <img alt="" style="cursor: pointer" src="assets/assetsnew/images/plus.png" />
                                        <img alt="" style="cursor: pointer; display: none" src="assets/assetsnew/images/minus.png" />
                                        <asp:Panel ID="pnlApprovals" runat="server" Style="display: none">
                                            <asp:GridView ID="gvApprovals" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid"
                                                OnRowDataBound="gvApprovals_RowDataBound" ShowFooter="true">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No." HeaderStyle-BackColor="#650855">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />

                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ApprovalName" HeaderStyle-BackColor="#650855" HeaderText="Approval Name" ItemStyle-CssClass="fw-bold" />
                                                    <asp:BoundField DataField="TIMELIMIT" HeaderStyle-BackColor="#650855" HeaderText="Time limit prescribed" />
                                                    <asp:BoundField DataField="TOTALAPPLICATIONSRCVD" HeaderStyle-BackColor="#650855" HeaderText="Total number of applications received" />
                                                   <%-- <asp:TemplateField HeaderText="Total Number of Applications Received">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTOTALAPPLICATIONSRCVD" runat="server" Text='<%# Bind("TOTALAPPLICATIONSRCVD") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotalRcvd" runat="server" Text="0" Font-Bold="true" BackColor="Black"
                                                                ForeColor="Wheat"></asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:BoundField DataField="TOTALAPPROVRED" HeaderStyle-BackColor="#650855" HeaderText="Approved" />
                                                    <asp:BoundField DataField="TOTALREJECTED" HeaderStyle-BackColor="#650855" HeaderText="Rejected" />
                                                    <asp:BoundField DataField="AVGTIMETOGRANT" HeaderStyle-BackColor="#650855" HeaderText="Average time taken to grant approval (in Days)" />
                                                    <asp:BoundField DataField="MDMTIMETOGRANT" HeaderStyle-BackColor="#650855" HeaderText="Median time taken to grant approval (in Days)" />
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S. No." HeaderStyle-CssClass="fw-bold">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="60px" />
                                </asp:TemplateField>
                                <asp:BoundField ItemStyle-Width="1028px" DataField="TMD_DeptName" HeaderText="Department Name" HeaderStyle-CssClass="fw-bold" ItemStyle-CssClass="bg-info" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
