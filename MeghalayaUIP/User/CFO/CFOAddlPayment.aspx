<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOAddlPayment.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOAddlPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../assets/admin/css/user.css" rel="stylesheet" />
    <div class="page-wrapper griddesignmulticount">
        <div class="content container-fluid">

            <div class="card">
                <div class="card-header d-flex justify-content-between">
                    <h4 class="card-title">Pre-Operational Applications 
                       
                       

                        <asp:Label ID="lblType" runat="server"></asp:Label></h4>
                    <h4 class="card-title">
                        <label id="unitname" runat="server"></label>
                    </h4>
                </div>
                <section id="dashboardcount" class="mt-2">
                    <div class="container-fluid">
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
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="col-md-12 row mt-4" runat="server" visible="false">
                                            <div class="col-md-2">1. Unit ID</div>

                                            <div class="col-md-3 fw-bold text-info">
                                                <spna class="dots">:</spna><asp:Label ID="lblUnitID" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-1">&nbsp;</div>
                                            <div class="col-md-3">3. Date of Unit Application</div>

                                            <div class="col-md-3">
                                                <spna class="dots">:</spna><asp:Label ID="lblDOA" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-12 row mt-2 mb-4" runat="server" visible="false">
                                            <div class="col-md-2">2. Unit Name</div>

                                            <div class="col-md-3 fw-bold text-info">
                                                <spna class="dots">:</spna><asp:Label ID="lblUnitNmae" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-md-1">&nbsp;</div>
                                            <div class="col-md-3">4. Category of Industry</div>

                                            <div class="col-md-3">
                                                <spna class="dots">:</spna><asp:Label ID="lblProjCategory" Text="Mega Project" runat="server"></asp:Label>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <asp:GridView ID="grdTrackerDetails" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdTrackerDetails_RowDataBound"
                                                EnableModelValidation="True" Width="100%">
                                                <HeaderStyle BackColor="#3b4474" ForeColor="White" />
                                                <AlternatingRowStyle />
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField
                                                        ItemStyle-HorizontalAlign="Center"
                                                        HeaderStyle-Width="70px">
                                                        <HeaderTemplate>
                                                            <div style="text-align: center">
                                                                Select All<br />
                                                                <asp:CheckBox ID="chkHeader" runat="server" onclick="myheadcheck(this)" />
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSel" AutoPostBack="true" OnCheckedChanged="chkSel_CheckedChanged" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField HeaderText="Name of Approval" DataField="ApprovalName" ItemStyle-Width="40%" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Name of Department" DataField="CFO_DEPTNAME" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                                    <%--<asp:BoundField HeaderText="Addl Payment Amount" DataField="CFDA_ADDITONALFEE" ItemStyle-HorizontalAlign="Center" />--%>
                                                    <asp:TemplateField HeaderText="Addl Payment Amount" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("CFODA_ADDITONALFEE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Date of Additional Raise" DataField="ADDLRAISEDATE" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30%" />

                                                    <asp:TemplateField HeaderText="Department" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblDeptId" Text='<%#Eval("CFODA_DEPTID")%>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Approval" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblApprovalId" Text='<%#Eval("CFODA_APPROVALID")%>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>



                                                    <%--<asp:BoundField DataField="" HeaderText="Date of Receival For Approval" />
                                                    <asp:BoundField DataField="DATEOFCOMPLETION" HeaderText="Date of Completion" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <%--<asp:HyperLink ID="HyperLinkSubsidy" Text='<%#Eval("Status of Approval Approved Rejected")%>'
                                                        NavigateUrl='<%#Eval("ApprovalDocNEW")%>' Target="_blank" runat="server" />--%>
                                                    <%-- <asp:HyperLink ID="lblStatus" Text='<%#Eval("STATUS")%>' NavigateUrl='<%#Eval("ApprovalDoc")%>' Target="_blank" runat="server" Visible="true"></asp:HyperLink>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                        <div class="col-md-6">
                                            &nbsp;
 
                                        </div>
                                        <div class="col-md-6 mt-3">
                                            <!-- <div class="col-md-12 mt-3 d-flex" id="padding"> -->


                                            <div class="form-group row">
                                                <label class="col-lg-3 col-form-label">Total Payment Amount</label>
                                                <div class="col-lg-8 d-flex">
                                                    <div class="form-check form-check-inline">

                                                        <label class="form-check-label" id="lblPaymentAmount" runat="server">
                                                            0
                 
                                                               
                                                        </label>
                                                    </div>
                                                </div>
                                                <label class="col-lg-3 col-form-label">Payment Type</label>
                                                <div class="col-lg-8 d-flex">
                                                    <div class="form-check form-check-inline">
                                                        <input class="form-check-input" type="radio" name="gender" id="gender_female" value="option1" checked="">
                                                        <label class="form-check-label" for="gender_female">
                                                            <b>HDFC Payment Gateway</b>
                                                        </label>
                                                    </div>
                                                </div>

                                                <!-- </div> -->

                                            </div>
                                        </div>
                                        <br />
                                        <div class="col-md-12 text-center">
                                            <asp:Button ID="btnPay" runat="server" Text="Pay" OnClick="btnPay_Click" class="btn btn-rounded btn-submit btn-lg" Width="150px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <script>

        function myheadcheck(btn) {

            var bolChecked = $(btn).is(':checked')

            MyTable = $('#<%= grdTrackerDetails.ClientID %>')
            MyCheckBoxs = MyTable.find('input:checkbox')
            MyCheckBoxs.each(function () {
                $(this).prop('checked', bolChecked)
            })
        }

  </script>
</asp:Content>
