<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOCombinedApplication.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOCombinedApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="CFOUserDashboard.aspx">Pre-Operational</a></li>

            <li class="breadcrumb-item active" aria-current="page">Combined Application</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <section class="comp-section">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-body">
                                <h4>Pre Operational - Approvals Abstract:</h4>
                                <h5 class="alert alert-warning alert-dismissible fade show">The following are the Pre-Operational Approvals required. Please
                                                    select the Approvals for which you intend to apply for.</h5>
                                <asp:HiddenField ID="hdnUserID" runat="server" />
                                <asp:HiddenField ID="hdnQuesid" runat="server" />
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
                                    <div class="table-responsive">
                                        <asp:GridView ID="grdApprovalsCFO" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            CssClass="table-hover" ForeColor="#333333" Width="100%" ShowFooter="true" OnRowDataBound="grdApprovalsCFO_RowDataBound">
                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle CssClass="GRDITEM" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <HeaderStyle CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />

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
                                                <asp:BoundField DataField="ApprovalName" HeaderText="Approval Required">
                                                    <ItemStyle Width="350px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TMD_DeptName" HeaderText="Department">
                                                    <ItemStyle Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CFOQA_APPROVALFEE" FooterStyle-HorizontalAlign="Right" HeaderText="Fee (Rs.)">
                                                    <FooterStyle CssClass="GRDITEM2" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle CssClass="GRDITEM2" Width="150px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Whether Approval Already Obtained">
                                                    <ItemStyle Width="250px" />
                                                    <ItemTemplate>
                                                        <asp:RadioButtonList ID="rblAlrdyObtained" runat="server" SelectedValue='<%# Eval("CFOQA_ISOFFLINE") %>' AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblAlrdyObtained_SelectedIndexChanged">
                                                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:HiddenField ID="HdfAmount" runat="server" />
                                                        <itemstyle horizontalalign="Center" width="240px" />
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
                                                        <asp:Label ID="lblAmounts" runat="server" Text='<%# Eval("CFOQA_APPROVALFEE") %>'></asp:Label>
                                                        <itemstyle horizontalalign="Center" width="140px" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="140px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Approval ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApprID" runat="server" Text='<%# Eval("CFOQA_APPROVALID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Dept ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDeptID" runat="server" Text='<%# Eval("CFOQA_DEPTID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
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
                <div class="col-md-12 text-right mt-2 mb-2">
                    <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />


                </div>

                <br />
                <div class="row" runat="server" visible="false" id="divOffline">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-body">
                                <h4><b>Upload Approval Documents which are already obtained:</b></h4>
                                <br />
                                <%-- Approvalid=32--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divMigrantReg2020">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Registration of Migrant Workers under The Meghalaya Identification, Registration of Migrant Workers Act, 2020 </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup32MigrantReg" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnMigrantReg" Text="Upload" OnClick="btnMigrantReg_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl32MigrantReg" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=33--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divManufactureReg">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Registration of Manufacturers / Repairers/Erectors of Boilers </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup33ManufactureReg" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld33ManufactureReg" Text="Upload" OnClick="btnUpld33ManufactureReg_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl33ManufactureReg" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=34--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divRenewalReg">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Registration of Contractors for Works and services and Renewal </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup34RenewalReg" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld34RenewalReg" Text="Upload" OnClick="btnUpld34RenewalReg_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl34RenewalReg" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=35--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divBoilerReg">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Registration of Boiler</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup35BoilerReg" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld35BoilerReg" Text="Upload" OnClick="btnUpld35BoilerReg_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl35BoilerReg" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=36--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLICFactory">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">License to Work as a Factory  </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup36LICFactory" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld36LICFactory" Text="Upload" OnClick="btnUpld36LICFactory_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl36LICFactory" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=37--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLICMIGRANTWORKMEN1979">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">License for Contractors under the Interstate Migrant Workmen Act 1979 </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup37LICMIGRANTWORKMEN" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld37LICMIGRANTWORKMEN" Text="Upload" OnClick="btnUpld37LICMIGRANTWORKMEN_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl37LICMIGRANTWORKMEN" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=38--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLICLabourContractor1970">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">License for Contractors under the Contract Labour Act 1970 </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup38LICLabourContractor" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld38LICLabourContractor" Text="Upload" OnClick="btnUpld38LICLabourContractor_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl38LICLabourContractor" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=39--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLicRetailDrug">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Licence for Retail and Wholesale Drug licence</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup39LicRetailDrug" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld39LicRetailDrug" Text="Upload" OnClick="btnUpld39LicRetailDrug_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl39LicRetailDrug" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=40--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLicRepairWeight">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Licence as Repairers of Weights & Measures </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup40LicRepairWeight" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld40LicRepairWeight" Text="Upload" OnClick="btnUpld40LicRepairWeight_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl40LicRepairWeight" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=41--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLicManuMeasure">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Licence as Manufacturer of Weights & Measures</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup41LicManuMeasure" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld41LicManuMeasure" Text="Upload" OnClick="btnUpld41LicManuMeasure_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl41LicManuMeasure" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=42--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="div42LicDealerWeight">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Licence as Dealers in Weights & Measures </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup42LicDealerWeight" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld42LicDealerWeight" Text="Upload" OnClick="btnUpld42LicDealerWeight_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl42LicDealerWeight" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=43--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divIVSMeasure">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Initial Verification And Stamping of Weighing and Measuring Instrument</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup43IVSMeasure" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld43IVSMeasure" Text="Upload" OnClick="btnUpld43IVSMeasure_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl43IVSMeasure" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=44--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divFireSafeCert">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Fire Safety Certificate </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup44FireSafeCert" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld44FireSafeCert" Text="Upload" OnClick="btnUpld44FireSafeCert_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl44FireSafeCert" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=45--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divExiseRetail">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Excise License for Wholesale, Retail, Bottling, Distillery Plant </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup45ExiseRetail" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld45ExiseRetail" Text="Upload" OnClick="btnUpld45ExiseRetail_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl45ExiseRetail" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=46--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLicWholeDrug">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Change of Constitution of Licence for Retail and Wholesale Drug licence </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup46LicWholeDrug" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld46LicWholeDrug" Text="Upload" OnClick="btnUpld46LicWholeDrug_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl46LicWholeDrug" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=47--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divBrandReg">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Brand and Label Registration </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup47BrandReg" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld47BrandReg" Text="Upload" OnClick="btnUpld47BrandReg_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl47BrandReg" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=48--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLicGrantRenew">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Application For The Grant/Renewal Of License To Manufacture Drugs For Purpose Of Examination, Test Or Analysis</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup48LicGrantRenew" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld48LicGrantRenew" Text="Upload" OnClick="btnUpld48LicGrantRenew_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl48LicGrantRenew" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=49--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLicManuDrug">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Application For The Grant Of Loan License To Manufacture For Sale Or For Distribution Of Drugs Specified In Schedule C, C (1) Excluding Those Specified In Part Xb & Schedule X</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup49LicManuDrug" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld49LicManuDrug" Text="Upload" OnClick="btnUpld49LicManuDrug_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl49LicManuDrug" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=50--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLicManuDrugSpecifie">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Application For The Grant Of A Loan License To Manufacture For Sale Or For Distribution Of Drugs Other Than That Specified In Schedule C, C(1), X</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup50LicManuDrugSpecifie" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld50LicManuDrugSpecifie" Text="Upload" OnClick="btnUpld50LicManuDrugSpecifie_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl50LicManuDrugSpecifie" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=51--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLicGrantRenewSch">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Application For The Grant /Renewal Of License To Repack For Sale Or For Distribution Of Drugs Other Than That Specified In Schedule C, C(1) Excluding Those Specified In Schedule X</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup51LicGrantRenewSch" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld51LicGrantRenewSch" Text="Upload" OnClick="btnUpld51LicGrantRenewSch_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl51LicGrantRenewSch" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=52--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLicManuVolumesera">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Application For The Grant /Renewal Of License To Manufacture For Sale Or For Distribution Of Large Volume Parenterals/Sera And Vaccines Excluding Those Specified In Schedule X</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup52LicManuVolumesera" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld52LicManuVolumesera" Text="Upload" OnClick="btnUpld52LicManuVolumesera_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl52LicManuVolumesera" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=53--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divProffessTax">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Application for Certificate of Enrollment of Professional Tax under the Meghalaya Professions Trades Callings and Employment Taxation Rules </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup53ProffessTax" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld53ProffessTax" Text="Upload" OnClick="btnUpld53ProffessTax_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl53ProffessTax" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=54--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divPCB">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">CFO from Pollution Contorl Board </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup54PCB" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld54PCB" Text="Upload" OnClick="btnUpld54PCB_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl54PCB" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=55--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divOccupancyCert">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Occupancy Certificate</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup55OccupancyCert" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld55OccupancyCert" Text="Upload" OnClick="btnUpld55OccupancyCert_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl55OccupancyCert" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=56--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divBoilerDept">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Boilers Steam Pipeline Erection Permission Certificate from Boilers Department</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup56BoilerDept" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld56BoilerDept" Text="Upload" OnClick="btnUpld56BoilerDept_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl56BoilerDept" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=57--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divRegPipelineSteam">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Boilers Steam Pipeline Registration Number Certificate </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup57RegPipelineSteam" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld57RegPipelineSteam" Text="Upload" OnClick="btnUpld57RegPipelineSteam_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl57RegPipelineSteam" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=58--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divRegShopEst">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Registration of Shops and Establishment - FORM - A</label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup58RegShopEst" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld58RegShopEst" Text="Upload" OnClick="btnUpld58RegShopEst_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl58RegShopEst" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=59--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLicGrantBusiness">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">Application for Grant of Business License </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup59LicGrantBusiness" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld59LicGrantBusiness" Text="Upload" OnClick="btnUpld59LicGrantBusiness_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl59LicGrantBusiness" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=60--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divLicIMFL">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">License for Local Sale, Import and Export Permit of Spirit and Indian-Made Foreign Liquor (IMFL) </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup60LicIMFL" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld60LicIMFL" Text="Upload" OnClick="btnUpld60LicIMFL_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl60LicIMFL" runat="server" Target="_blank"></asp:HyperLink>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Approvalid=61--%>
                                <div class="col-md-12 d-flex" runat="server" visible="false" id="divSatateExcise">
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label">State Excise - Excise Verification Certificate </label>
                                            <div class="col-lg-1 d-flex">
                                                :
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:FileUpload runat="server" ID="fup61SatateExcise" Width="300px" Font-Italic="true" Height="45px" />
                                            </div>
                                            <div class="col-lg-2 d-flex">
                                                <asp:Button runat="server" ID="btnUpld61SatateExcise" Text="Upload" OnClick="btnUpld61SatateExcise_Click" class="btn btn-info btn-lg" Height="40px" Width="150px" />
                                            </div>
                                            <div class="col-lg-3 d-flex">
                                                <asp:HyperLink ID="hpl61SatateExcise" runat="server" Target="_blank"></asp:HyperLink>
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
