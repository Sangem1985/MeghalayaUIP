<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEPaymentPage.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEPaymentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Pre Establishment</a></li>

            <li class="breadcrumb-item active" aria-current="page">Payments Details</li>
        </ol>
    </nav>
    <div class="page-wrapper">

        <div class="content container-fluid">

            <div class="row">
                <div class="col-md-12 ">
                    <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">×</span></button>
                    </div>
                </div>
                <div class="col-md-12 ">
                    <div id="Failure" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show" align="Center">
                        <strong>Warning!</strong>
                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                    </div>
                </div>
                <asp:HiddenField ID="hdnUserID" runat="server" />
                <asp:HiddenField ID="hdnQuesID" runat="server" />
                <asp:HiddenField ID="hdnUIDNo" runat="server" />
                <div class="card card-table">
                    <div class="card-header">
                        <h4 class="card-title">Department Payments</h4>
                        <hr />

                    </div>
                    <div class="col-md-12 row mt-3 ml-1 d-flex">

                        <div class="col-md-5" runat="server" visible="false">
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
                        <div class="col-md-11">
                            <asp:GridView ID="grdApprovals" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                CssClass="GRD" ForeColor="#333333" Width="100%" ShowFooter="true" OnRowDataBound="grdApprovals_RowDataBound">
                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S. No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                            <asp:HiddenField ID="HdfDeptid" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ApprovalName" HeaderText="Approval Name ">
                                        <ItemStyle Width="450px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TMD_DeptName" HeaderText="Department">
                                        <ItemStyle Width="180px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CFEDA_APPROVALFEE" FooterStyle-HorizontalAlign="Right" HeaderText="Fee (Rs.)">
                                        <FooterStyle CssClass="GRDITEM2" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle CssClass="GRDITEM2" Width="150px" HorizontalAlign="Center" />
                                    </asp:BoundField>


                                    <asp:TemplateField HeaderText="Approval ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApprID" runat="server" Text='<%# Eval("CFEDA_APPROVALID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Dept ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeptID" runat="server" Text='<%# Eval("CFEDA_DEPTID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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
                            <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                            <asp:Button ID="btnPay" runat="server" Text="Pay" OnClick="btnPay_Click" class="btn btn-rounded btn-submit btn-lg" Width="150px" />




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
