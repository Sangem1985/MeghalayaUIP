<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCARBonusPaymentAct.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCARBonusPaymentAct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="Dashboard/MainDashboard.aspx">Other Services</a></li>
            <li class="breadcrumb-item"><a href="#">SRVC Annual Returns</a></li>
            <li class="breadcrumb-item active" aria-current="page">SRVC Payment Of Bonus Act</li>
        </ol>
    </nav>

    <contenttemplate>
        <div class="page-wrapper">
            <div class="content container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">ANNUAL RETURNS UNDER VARIOUS LABOUR LAWS</h4>
                            </div>
                            <div class="card-body">
                                <div class="col-md-12">
                                    <h4 class="card-title ml-3 text-center">FORM D</h4>
                                    <h4 class="card-title ml-3 text-center">[See Rule 5]</h4>
                                </div>


                                <div class="row">
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    Return for the year
                                                 <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtreturnyear" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    1. Name of the Establishment
                                                <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnameofestblshmnt" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    2. Establishment Address <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnofmandayswrkddurngyear" runat="server" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    3. Pincode
                                                 <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtpincode" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    4. District <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtdistrict" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    5. Mandal
                                            <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtmandal" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    6. Nature of Industry <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnatureofinds" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    7. Name of Employer
                                              <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnameofemplyr" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    8. Total No of Employees <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txttlemployees" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    9. Number of Employees Benifited by bonus payments
                                                  <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnofempsbnftdbybonus" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <h4 class="card-title ml-3">Bonus Log Entries</h4>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    1. Total amount payable as bonus under section 10 or 11 of the payment of Bonus Act, 1965 as the case may be
                                                     <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtamntbns1965" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    2. Settlement, if any reached under section 18(1) or 12(3) of the International disputes Act, 1947 with date<span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtsettlemnt1947" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    3. Percentage of bonus declared to be paid
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtpercentagebnstopaid" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    4. Total amount of bonus actually paid<span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtttlbnspaid" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    5. Day on which payment made<span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtpmntdate" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    6. Whether bonus has been paid to all the employees, if not, reasons for non-payment<span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtbnspaidtoall" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    7. Remarks<span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtremarks" runat="server" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <div class="col-lg-3">
                                                    <asp:Button ID="btnaddlog" runat="server" CssClass="btn btn-rounded btn-info btn-lg" Text="Add Log" OnClick="btnaddlog_Click" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-12 d-flex">

                                        <asp:GridView ID="gvLogs" runat="server" AutoGenerateColumns="False"
                                            BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                            CssClass="GRD" ForeColor="#333333" GridLines="Both" Width="100%"
                                            OnRowDeleting="GvLogs_RowDeleting"
                                            DataKeyNames="SlNo" EnableModelValidation="True">

                                            <RowStyle BackColor="#ffffff" />

                                            <Columns>
                                                <asp:BoundField DataField="SlNo" HeaderText="Sl No." ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="TotalAmountBonus" HeaderText="Total Bonus Payable" />
                                                <asp:BoundField DataField="SettlementDetails" HeaderText="Settlement Details" />
                                                <asp:BoundField DataField="BonusPercentage" HeaderText="Bonus Percentage" />
                                                <asp:BoundField DataField="TotalBonusPaid" HeaderText="Total Bonus Paid" />
                                                <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" />
                                                <asp:BoundField DataField="BonusPaidToAll" HeaderText="Bonus Paid to All" />
                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ControlStyle-ForeColor="Red" />
                                            </Columns>

                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#013161" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                    <div class="col-md-12 text-right mt-2 mb-2">
                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                    </div>

                                </div>


                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </contenttemplate>
</asp:Content>
