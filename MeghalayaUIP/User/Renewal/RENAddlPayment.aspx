<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="RENAddlPayment.aspx.cs" Inherits="MeghalayaUIP.User.Renewal.RENAddlPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="../Renewal/RENUserDashboard.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item active" aria-current="page">Renewal</li>
                </ol>
            </nav>
            <div class="page-wrapper griddesignmulticount">
                <div class="content container-fluid">

                    <div class="card">
                        <div class="card-header d-flex justify-content-between">
                            <h4 class="card-title">Renewal Status
                       
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
                                    <div class="col-md-12">
                                        <div class="card">
                                            <div class="card-body">
                                                <div class="col-md-12 row mt-4 d-flex justify-content-center" id="divApplication" runat="server" visible="false">
                                                    <div class="col-md-2">1. UID NO</div>

                                                    <div class="col-md-3 fw-bold text-info">
                                                        <spna class="dots">:</spna><asp:Label ID="lblUnitID" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-1">&nbsp;</div>

                                                    <div class="col-md-2">2. Unit Name</div>

                                                    <div class="col-md-3 fw-bold text-info">
                                                        <spna class="dots">:</spna><asp:Label ID="lblUnitNmae" runat="server"></asp:Label>
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
                                                                    <asp:CheckBox ID="chkSel" AutoPostBack="true" runat="server" OnCheckedChanged="chkSel_CheckedChanged" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:BoundField HeaderText="Name of Approval" DataField="ApprovalName" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                                            <asp:BoundField HeaderText="Name of Department" DataField="TMD_DeptName" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center"></asp:BoundField>


                                                            <asp:TemplateField HeaderText="Additional Payment Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("RENDA_ADDITONALFEE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Date of Additional Raise" DataField="ADDLRAISEDATE" ItemStyle-HorizontalAlign="Center" />

                                                            <asp:TemplateField HeaderText="Department" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblDeptId" Text='<%#Eval("RENDA_DEPTID")%>' Visible="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Approval" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" ID="lblApprID" Text='<%#Eval("RENDA_APPROVALID")%>' Visible="false"></asp:Label>
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
