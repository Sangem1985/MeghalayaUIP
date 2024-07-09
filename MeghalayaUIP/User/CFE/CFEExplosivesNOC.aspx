<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEExplosivesNOC.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEExplosivesNOC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Explosives NOC Appilication Details</h4>
                        </div>
                        <div class="card-body">
                            <div class="col-md-12 d-flex">
                                <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 d-flex">
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                                    <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                            <div class="row">
                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Quantity of Explosives proposed to be manufactured/possessed for the purpose stated at serial No. 1 above :</span></label>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Name and Description *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Class *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtClass" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Division if any *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtDivision" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Quantity(at any one time) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtQuantityTime" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Quantity(at any one month) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtQuantityMonth" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="btnAdd" Text="Add Details" OnClick="btnAdd_Click" class="btn btn-rounded btn-green" runat="server" Width="110px" />
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex justify-content-center">
                                    <asp:GridView ID="GVEXPLOSIVE" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="None"
                                        Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVEXPLOSIVE_RowDeleting">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Name and Description" DataField="CFEME_NAME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Class" DataField="CFEME_CLASS" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Division if any" DataField="CFEME_DIVISION" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Quantity(at any one time)" DataField="CFEME_QUANTITYTIME" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Quantity(at any one month)" DataField="CFEME_QUANTITYMONTH" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <br />
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-11">
                                        <div class="form-group row">
                                            <label class="col-lg-9 col-form-label">Details of site where explosives will be used and distance of site of use from the storage premises (in case of licence for use)  *</label>
                                            <div class="col-lg-2 d-flex">
                                                <asp:TextBox ID="txtExplosive" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-11">
                                        <div class="form-group row">
                                            <label class="col-lg-9 col-form-label">Details of explosives road van which will be used for transportation of explosives (in case of no objection certificate for road van)</label>
                                            <div class="col-lg-2 d-flex">
                                                <asp:TextBox ID="txtRoadVan" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Additional information:</span></label>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-9 col-form-label">(i) I or We have not been convicted under any offence or ordered to execute bond under Chapter VIII of Code of Criminal Procedure, 1973, during the last 10 years ( If yes, please give details).*</label>
                                            <div class="col-lg-3">
                                                <asp:RadioButtonList ID="rblcriminal1973" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblcriminal1973_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6" id="Details" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Enter Details  *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtDetails" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-9 col-form-label">(ii) Particulars of other licenses: I / We possess under Explosives Act, 1884 (Note: Please write the licence no(s), if any) *</label>
                                            <div class="col-lg-3">
                                                <asp:RadioButtonList ID="rblLIC1884" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLIC1884_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6" id="LicDetails" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Enter Details  *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtDet" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-9 col-form-label">(iii) I/We have obtained approval as required under rule 101 from the competent authority: (Note: Please enclose the approval letter, approved drawing(s), other enclosures, if any) *</label>
                                            <div class="col-lg-3">
                                                <asp:RadioButtonList ID="rblApproval101" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblApproval101_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6" id="approvaldet" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Enter Details  *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtDetail" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">(iv) Any other relevant information: *</label>
                                            <div class="col-lg-4 d-flex">
                                                <asp:TextBox ID="txtinformation" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 text-right">

                                    <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
