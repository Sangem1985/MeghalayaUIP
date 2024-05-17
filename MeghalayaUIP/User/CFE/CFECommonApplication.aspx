<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFECommonApplication.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFECommonApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <section class="comp-section">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-body">
                                <h3><b>Pre Establishment - Approvals Abstract:</b></h3>
                                <h5 style="color: red"><b>The following are the Approvals required for Establishment of your Unit. Please
                                                    select the Approvals for which you intend to apply for.</b></h5>
                                <asp:HiddenField ID="hdnUserID" runat="server" />
                                <asp:HiddenField ID="hdnQuestionnaireID" runat="server" />
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
                                <div class="col-md-12 d-flex">
                                    <asp:GridView ID="grdApprovals" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        CssClass="GRD" ForeColor="#333333" Width="95%" ShowFooter="true" OnRowDataBound="grdApprovals_RowDataBound">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                    <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required ">
                                                <ItemStyle Width="450px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TMD_DeptName" HeaderText="Department">
                                                <ItemStyle Width="180px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CFEQA_APPROVALFEE" FooterStyle-HorizontalAlign="Right" HeaderText="Fee (Rs.)">
                                                <FooterStyle CssClass="GRDITEM2" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle CssClass="GRDITEM2" Width="150px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Whether Approval Already Obtained">
                                                <ItemTemplate>
                                                    <asp:RadioButtonList ID="rblAlrdyObtained" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblAlrdyObtained_SelectedIndexChanged">
                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                        <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:HiddenField ID="HdfAmount" runat="server" />
                                                    <itemstyle horizontalalign="Center" width="140px" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Apply for Approval">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkApproval" runat="server" AutoPostBack="True" OnCheckedChanged="ChkApproval_CheckedChanged" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmounts" runat="server" Text="Label"></asp:Label>
                                                    <itemstyle horizontalalign="Center" width="140px" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="140px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approval ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblApprID" runat="server" Text='<%# Eval("CFEQA_APPROVALID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Dept ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDeptID" runat="server" Text='<%# Eval("CFEQA_DEPTID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </div>
                        </div>
                    </div>


                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">NOTE:</h4>
                            </div>
                            <div class="card-body">
                                <div id="flashingtext" style="font-size: 15px;">

                                    <h5><b>1. Initial Department fee has to be paid through INVEST MEGHALAYA online system.</b>
                                        <br />
                                        <br />
                                        <b>2. Any Additional payment raised by the department has to be paid through INVEST MEGHALAYA
                                            online system.</b>
                                        <br />
                                        <br />
                                        <b>3. If any payment done through the respective department will not be considered and
                                            stage of the application will not be escalated.</b></h5>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-12 text-right">
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" class="btn btn-rounded btn-info btn-lg" BackColor="#009999" Width="150px" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" class="btn btn-rounded btn-info btn-lg" padding-right="10px" BackColor="Green" Width="150px" />
                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" BackColor="#3333ff" Width="150px" />

                </div>
                <br />
                <div class="row" runat="server" visible="true">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-body">
                                <h4><b>Upload Offline Approvals which are already obtained:</b></h4>
                                <br />
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Pre Establishment Approval from Pollution Control Board </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="fupAadhar" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                <br />
                                                <asp:HyperLink ID="lblFileName"  runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpldAadhar" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Service Connection Certificate  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload1" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button1" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Electricity Connection Certificate  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload2" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button2" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Factory Plan Approval   </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload3" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button3" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">DG Set NOC   </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload4" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button4" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Provisional Fire Safety Certificate  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload5" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button5" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Licence to store RS, DS  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload6" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button6" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">NOC required for setting up of Explosives Manufacturing, Storage, Sale, Transport </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload7" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button7" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">NOC Required for Setting Up of Petroleum, Diesel & Naphtha Manufacturing, Storage, Sale, Transport  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload8" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button8" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Road Cutting Permission Letter  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload9" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button9" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Non Encumbrance Certificate </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload10" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button10" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Certificate of Registration of Professional Tax   </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload11" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button11" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Electrical Drawing Approval from Electrical Inspectorate </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload12" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button12" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Letter for distance from Forest  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload13" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button13" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Non-Forest Land Certificate  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload14" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button14" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">FTL NOC for Change of Land use (Irrigation)  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload15" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button15" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">FTL NOC for Change of Land use (Revenue)  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload16" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button16" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label"> NOC for Ground Water Abstraction for Commercial Connection  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload17" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button17" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Certificate for non-availability of water supply from water supply agency </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload18" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button18" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-10">
                                        <div class="form-group row">
                                            <label class="col-lg-5 col-form-label">Permission to Draw Water from River/Public Tanks  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:FileUpload runat="server" ID="FileUpload19" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="Button19" Text="Upload" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

        </div>
    </div>
</asp:Content>
