<%@ Page Title="" Language="C#" MasterPageFile="~/outer.Master" AutoEventWireup="true" CodeBehind="SingleWindowPortalDashboard.aspx.cs" Inherits="MeghalayaUIP.SingleWindowPortalDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .swpd thead tr th {
    vertical-align: middle;
    text-align: center;
    font-weight:400;
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
    </style>
    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Single Window Portal Dashboard</li>
                        </ol>
                    </nav>


                    <h3>Single Window Portal Dashboard</h3>
                    <div class="col-md-12" style="margin-bottom:8px;">
                        <div class="col-md-6">&nbsp;</div>
                        <div class="col-md-6">
                            <div class="col-md-6">Department/Application Name :</div>
                            <div class="col-md-6">
                                <select class="form-select" aria-label="Default select example" style="width:100%;height:32px;">
  <option selected>--Select--</option>
  <option value="1">Agriculture Department</option>
  <option value="2">Commissioner, Greater Chennai Corporation</option>
  <option value="3">Commissionerate of Industries and Commerce</option>
</select>
                            </div>
                        </div>
                    </div>
                    <div class="swpd">
                    <table class="table table-responsive table-bordered table-sm mb-0 table-hover">
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
</table>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    
</asp:Content>
