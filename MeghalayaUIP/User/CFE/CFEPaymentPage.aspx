<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEPaymentPage.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEPaymentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">

        <div class="content container-fluid">

            <div class="row">
                <div class="col-md-12">

                    <!-- Recent Orders -->
                    <div class="card card-table">
                        <div class="card-header">
                            <h4 class="card-title">Department Payments</h4>
                            <hr />
                            <h6 class="text-danger"><b>Select the approvals for which you wish to make payment now</b></h6>
                        </div>
                        <div class="col-md-12 row mt-3 d-flex">

                            <div class="col-md-6">
                                <div class="alert alert-warning" role="alert">
                                    <b>Terms and Conditions:</b>
                                    <p>1. Do not press F5 or refresh the page while the transaction is in process.</p>
                                    <p>2. Do not press back button while the transaction is in process.</p>
                                    <p>3. Only the transactions with “Successful” status message will be deemed to be received.</p>
                                    <p>4. In case the transaction is not “Successful” and the amount has been debited from your account and any other queries, please contact the Toll free number: 7306-600-600 or upload a grievance</p>
                                    <p>5. There is no refund policy for the payment. But if any excess amount is paid, it would be adjusted in the future payments.</p>
                                    <p>6. All the details regarding the payments are secure and confidential. We do not store the bank details entered by the entrepreneur.</p>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="table-responsive">
                                    <table class="table table-hover table-bordered table-center mb-0">
                                        <thead>
                                            <tr>
                                                <th>Sl.<br />
                                                    No.</th>
                                                <th>Approval Required</th>
                                                <th>Dept. Name</th>
                                                <th>Fee(&#x20b9;)</th>
                                                <th>Pay For
                                                    <br />
                                                    Dept.</th>
                                                <th class="text-right">Amount(&#x20b9;)</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1</td>
                                                <td>BUILDING
                                                    <br />
                                                    PERMIT RELEASE FEE</td>
                                                <td>PANCHAYAT<br />
                                                    RAJ</td>
                                                <td>5000
                                                </td>

                                                <td>
                                                    <div class="status-toggle">
                                                        <input type="checkbox" id="status_1" class="check" checked="">
                                                        <label for="status_1" class="checktoggle">checkbox</label>
                                                    </div>
                                                </td>
                                                <td class="text-right">5000</td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <td>CONSENT
                                                    <br />
                                                    FOR ESTABLISHMENT
                                                    <br />
                                                    FROM POLLUTUION
                                                    <br />
                                                    CONTROL BOARD</td>
                                                <td>POLLUTION<br />
                                                    CONTROL BOARD</td>
                                                <td>15000
                                                </td>

                                                <td>
                                                    <div class="status-toggle">
                                                        <input type="checkbox" id="status_2" class="check" checked="">
                                                        <label for="status_2" class="checktoggle">checkbox</label>
                                                    </div>
                                                </td>
                                                <td class="text-right">15000</td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <td>ELECTRICAL
                                                    <br />
                                                    DRAWING APPROVAL<br />
                                                    FROM ELECTRICAL<br />
                                                    INSPECTORATE</td>
                                                <td>ELECTRICAL<br />
                                                    INSPECTORATE</td>
                                                <td>1000
                                                </td>

                                                <td>
                                                    <div class="status-toggle">
                                                        <input type="checkbox" id="status_3" class="check" checked="">
                                                        <label for="status_3" class="checktoggle">checkbox</label>
                                                    </div>
                                                </td>
                                                <td class="text-right">1000</td>
                                            </tr>

                                            <tfoot>
                                                <tr>
                                                    <td colspan="5" class="text-center text-danger"><b>Total</b></td>
                                                    <td class="text-right text-danger"><b>26000</b></td>
                                                </tr>
                                            </tfoot>

                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="col-md-6">
                                &nbsp;
                            </div>
                            <div class="col-md-6 mt-3">
                                <!-- <div class="col-md-12 mt-3 d-flex" id="padding"> -->

                                <div class="form-group row">
                                    <label class="col-lg-3 col-form-label">Payment Type</label>
                                    <div class="col-lg-8 d-flex">
                                        <div class="form-check form-check-inline">
                                            <input class="form-check-input" type="radio" name="gender" id="gender_male" value="option1">
                                            <label class="form-check-label" for="gender_male">
                                                Bill desk
                                            </label>
                                        </div>
                                        <div class="form-check form-check-inline">
                                            <input class="form-check-input" type="radio" name="gender" id="gender_female" value="option2" checked="">
                                            <label class="form-check-label" for="gender_female">
                                                <b>Kotak Payment Gateway</b>
                                            </label>
                                        </div>
                                    </div>

                                    <!-- </div> -->

                                </div>
                            </div>
                            <div class="col-md-12 text-right">
                                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" BackColor="#009999" Width="150px" />

                                <asp:Button ID="btnPay" runat="server" Text="Pay" class="btn btn-rounded btn-info btn-lg" padding-right="10px" BackColor="Green" Width="150px" />




                            </div>
                        </div>
                        <div class="card-body m-3">
                        </div>
                    </div>
                    <!-- /Recent Orders -->

                </div>

            </div>

        </div>
    </div>
</asp:Content>
