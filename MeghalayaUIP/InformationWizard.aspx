<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="InformationWizard.aspx.cs" Inherits="MeghalayaUIP.InformationWizard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table#servicestable th {
            vertical-align: middle;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <section class="innerpages">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                                    <li class="breadcrumb-item">Services</li>
                                    <li class="breadcrumb-item active" aria-current="page">Information Wizard</li>
                                </ol>
                            </nav>
                            <section class="innerpages">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <%-- <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                            <li class="breadcrumb-item">Services</li>
                            <li class="breadcrumb-item active" aria-current="page">Information Wizard</li>
                        </ol>
                    </nav>--%>

                                            <h3>Information Wizard</h3>
                                            <div class="card">
                                                <div class="card-body justify-content-center " align="justify">
                                                    <div class="row">
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Application Category :</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlModule" runat="server" class="form-control"
                                                                            AutoPostBack="true">
                                                                            <asp:ListItem Text="All" Value="%"></asp:ListItem>
                                                                            <asp:ListItem Text="Pre Establishment" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Pre Operational" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Renewals" Value="4"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Department : </label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddldept" runat="server" class="form-control" OnSelectedIndexChanged="ddldept_SelectedIndexChanged"
                                                                            AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Sector :</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlSector" runat="server" class="form-control"
                                                                            AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">

                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Location:</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlLocation" runat="server" class="form-control">
                                                                            <asp:ListItem Text="All" Value="%"></asp:ListItem>
                                                                            <asp:ListItem Text="Rural" Value="Rural"></asp:ListItem>
                                                                            <asp:ListItem Text="Urban" Value="Urban"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Nature of Activity: </label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="DropDownList2" runat="server" class="form-control"
                                                                            AutoPostBack="true">
                                                                            <asp:ListItem Text="All" Value="%"></asp:ListItem>
                                                                            <asp:ListItem Text="Manufacturing" Value="Manufacturing"></asp:ListItem>
                                                                            <asp:ListItem Text="Service" Value="Service"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Size of Firm:</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlProjectCategory" runat="server" class="form-control">
                                                                            <asp:ListItem Text="All" Value="%"></asp:ListItem>
                                                                            <asp:ListItem Text="Micro" Value="Micro"></asp:ListItem>
                                                                            <asp:ListItem Text="Small" Value="Small"></asp:ListItem>
                                                                            <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                                                                            <asp:ListItem Text="Large" Value="Large"></asp:ListItem>
                                                                            <asp:ListItem Text="Mega" Value="Mega"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Risk Category:</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlPolCategory" runat="server" class="form-control" Enabled="false"
                                                                            AutoPostBack="true">
                                                                            <asp:ListItem Text="All" Value="%"></asp:ListItem>
                                                                            <asp:ListItem Text="White" Value="W"></asp:ListItem>
                                                                            <asp:ListItem Text="Green" Value="G"></asp:ListItem>
                                                                            <asp:ListItem Text="Orange" Value="O"></asp:ListItem>
                                                                            <asp:ListItem Text="Red" Value="R"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Investor Type:</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlInvestorType" runat="server" class="form-control">
                                                                            <asp:ListItem Text="All" Value="%"></asp:ListItem>
                                                                            <asp:ListItem Text="Domestic" Value="Domestic"></asp:ListItem>
                                                                            <asp:ListItem Text="Foreign" Value="Foreign"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">No of Employee:</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlEmployee" runat="server" class="form-control">
                                                                            <asp:ListItem Text="All" Value="%"></asp:ListItem>
                                                                            <asp:ListItem Text="Below 10" Value="10"></asp:ListItem>
                                                                            <asp:ListItem Text="10 to 100" Value="100"></asp:ListItem>
                                                                            <asp:ListItem Text="Above 100" Value=">100"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 float-left ">
                                                            <div class="form-group row justify-content-center" style="padding: 20px">
                                                                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" ValidationGroup="Search" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <asp:GridView ID="gvInfoWiz" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                                BorderStyle="Solid" BorderWidth="1px" CssClass="table-bordered table-hover" ForeColor="#333333"
                                                                GridLines="Both" Width="100%" EnableModelValidation="True" OnRowDataBound="gvInfoWiz_RowDataBound"
                                                                ShowFooter="true">
                                                                <RowStyle />
                                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                <FooterStyle BackColor="#013161" CssClass="no-hover" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                <AlternatingRowStyle BackColor="#ccccff" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl.No." ItemStyle-Width="3%">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="APPROVALID" DataField="IW_APPROVALID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-ForeColor="WindowText" Visible="true" />

                                                                    <asp:BoundField HeaderText="Service Name" DataField="IW_APPROVALNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-ForeColor="WindowText" Visible="true" />
                                                                    <asp:BoundField HeaderText="Department" DataField="IW_DEPTNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:BoundField HeaderText="Application Category" DataField="CATEGORY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                                    <asp:TemplateField HeaderText="Standard Operating Procedure">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink runat="server" ID="hplViewSOP" Text="View SOP" NavigateUrl='<%#Eval("IW_SOP") %>' Target="_blank" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Rules and Regulations">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink runat="server" ID="hplRulesandReg" Text="View Document" NavigateUrl='<%#Eval("IW_RULESANDREGL") %>' Target="_blank" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Prerequisites">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink runat="server" ID="hplPrerequisites" Text="View Enclosures" NavigateUrl='<%#Eval("IW_PREREQUISITES") %>' Target="_blank" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Application Form Format">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink runat="server" ID="hplApplForm" Text="Download Form" NavigateUrl='<%#Eval("IW_APPLFORMAT") %>' Target="_blank" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <div align="center" style="text-align: center; padding: 20px;">
                                                                        No Services Found
                                                                    </div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>


                                                    <div class="row dt-row">
                                                        <div class="col-sm-12">

                                                            <table id="servicestable" class="table table-striped table-hover dataTable no-footer" style="width: 100%;" aria-describedby="servicestable_info" runat="server" visible="true">
                                                                <thead style="background-color: #247BA0; color: white;">
                                                                    <tr>
                                                                        <th style="width: 60px;">Sl. No.</th>
                                                                        <th class="sorting" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-label="Service Name: activate to sort column ascending" style="width: 125px;">Service Name</th>
                                                                        <th class="sorting sorting_asc" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-label="Department: activate to sort column descending" style="width: 98px;" aria-sort="ascending">Department</th>
                                                                        <th class="sorting" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-label="Standard Operating Procedure: activate to sort column ascending" style="width: 83px;">Standard Operating Procedure</th>
                                                                        <th class="sorting" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-label="Rules and Regulations: activate to sort column ascending" style="width: 95px;">Rules and Regulations</th>
                                                                        <th class="sorting" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-label="Prerequisites: activate to sort column ascending" style="width: 107px;">Prerequisites</th>
                                                                        <th class="sorting" tabindex="0" aria-controls="servicestable" rowspan="1" colspan="1" aria-label="Application Form Format: activate to sort column ascending" style="width: 92px;">Application Form Format</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>

                                                                    <tr class="odd">
                                                                        <td>1</td>
                                                                        <td>License to work as a Factory/Factory license</td>
                                                                        <td class="sorting_1">Chief Inspector of Boilers &amp; Factories</td>
                                                                        <td class="">
                                                                            <a href="Documents/SOP/sop_factory_license.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/rule_factory_license.pdf" target="blank">View Document</a></td>


                                                                        <td>

                                                                            <a>View Enclosures</a>
                                                                        </td>
                                                                        <td><a href="forms/ApplicationFactory.pdf" target="blank">Download Form</a></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>2</td>
                                                                        <td>Application for Permission to construct, extend or take into use any building as a factory
                                                                        </td>
                                                                        <td class="sorting_1">Chief Inspector of Boilers &amp; Factories</td>
                                                                        <td class=""><a href="Documents/SOP/sop_factory_license.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/rule_factory_license.pdf" target="blank">View Document</a></td>

                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>


                                                                        </td>
                                                                        <td><a href="forms/ApplicationFactory.pdf" target="blank">Download Form</a></td>
                                                                    </tr>

                                                                    <tr class="odd">
                                                                        <td>3</td>
                                                                        <td>Registration of Boilers under The Boilers Act, 1923</td>
                                                                        <td class="sorting_1">Chief Inspector of Boilers &amp; Factories</td>
                                                                        <td class=""><a href="Documents/SOP/sop_Registration_of_Boiler.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/rules_Registration_of_Boiler.pdf" target="blank">View Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/enclo_Registration_of_Boiler.pdf" target="blank">View Enclosures</a>
                                                                        </td>
                                                                        <td><a href="Documents/Application/form_Registration_of_Boiler.pdf" target="blank">Download Form</a></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>4</td>
                                                                        <td>Renewal of Certificate for use of Boiler, under The Boilers Act, 1923</td>
                                                                        <td class="sorting_1">Chief Inspector of Boilers &amp; Factories</td>
                                                                        <td class=""><a href="Documents/SOP/sop_Renewal_of_Certificate.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/rules_Renewal_of_Certificate.pdf" target="blank">View Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/enclo_Renewal_of_Certificate.pdf" target="blank">View Enclosures</a>
                                                                        </td>
                                                                        <td><a href="Documents/Application/form_Renewal_of_Certificate.pdf" target="blank">Download Form</a></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>5</td>
                                                                        <td>Auto Renewal Factories License</td>
                                                                        <td class="sorting_1">Chief Inspector of Boilers &amp; Factories</td>
                                                                        <td class=""><a href="Documents/SOP/sop_autorenewal.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/rule_factory_license.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/enclo_AutoRenewal_FactoriesLicense.pdf" target="blank">View
                            Enclosures</a></td>
                                                                        <td><a href="Documents/Application/form_ApplicationFactory.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>6</td>
                                                                        <td>Registration of Boiler Manufacture under The Boilers Act, 1923</td>
                                                                        <td class="sorting_1">Chief Inspector of Boilers &amp; Factories</td>
                                                                        <td class=""><a href="Documents/SOP/Process_flow_Registration_Boilers.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/Feestructure_registration_renewal_Boiler.pdf" target="blank">View
                            Document</a>
                                                                        </td>
                                                                        <td><a href="Documents/Prerequisites/Enclosures_boilerManu.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/Application_manufaturer_repairer_erector.pdf" target="blank">Download
                            Form</a> </td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>7</td>
                                                                        <td>Apply for New/Renewal/Modification License/Registration (FSSAI)</td>

                                                                        <td class="sorting_1">Commissionerate of Food Safety</td>
                                                                        <td class=""><a href="https://foscos.fssai.gov.in/user-manual" target="blank">View SOP</a></td>
                                                                        <td><a href="https://foodsafety.meghealth.gov.in/acts_rules.html" target="blank">View
                            Document</a></td>
                                                                        <td><a href="https://foscos.fssai.gov.in/assets/docs/KindofBusinessEligibilityLatest.pdf" target="blank">Fees Detail</a></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>8</td>
                                                                        <td>Udyog Aadhaar Memorandum (UAM)</td>
                                                                        <td class="sorting_1">Department of Industries &amp; Commerce Online Services</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>9</td>
                                                                        <td>Registration Under The Meghalaya Procurement Preference Policy For Micro And Small
                          Enterprises</td>
                                                                        <td class="sorting_1">Department of Industries &amp; Commerce Online Services</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td><a href="Documents/Prerequisites/Enclosures11.pdf" target="blank">View Enclosures</a></td>
                                                                        <td>
                                                                            <p><a href="Documents/Application/ApplicationFormIndustriesCommerce.pdf" target="blank">Download Form</a> </p>
                                                                            <p>&nbsp;</p>
                                                                            <p><a href="forms/Annex_D_CnI.docx" target="blank">Annexure D</a></p>
                                                                        </td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>10</td>
                                                                        <td>Registration of Institutions for Persons with Disabilities under Section 50 and 51 of the
                          Right of Persons with Disabilities Act, 2016</td>
                                                                        <td class="sorting_1">Department of Social Welfare</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td><a href="Documents/Prerequisites/enclosuresRegistrationunderDisabilityAct2016.pdf" target="blank">View
                            Enclosures</a></td>
                                                                        <td><a href="Documents/Application/ApplicationformRegistrationofInstitutionsunderDisabilitiesAct.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>11</td>
                                                                        <td>NOC required for setting up of Explosives manufacturing, storage, sale, transport</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""><a href="Documents/SOP/SoP-Explosives.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/Explosive_Act_1884.pdf" target="blank">1. View Document<br>
                                                                        </a><a href="Documents/Rules/ExplosivesRules_2008.pdf" target="blank">2. View Document</a></td>

                                                                        <td>
                                                                            <div>
                                                                                <a>View Enclosures</a>
                                                                            </div>

                                                                        </td>
                                                                        <td><a href="forms/APPL-Explosives.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>12</td>
                                                                        <td>NOC required for setting up of Petroleum, Diesel &amp; Naphtha manufacturing, storage, sale,
                          transport</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""><a href="Documents/SOP/SoP-Petroleum.pdf" target="blank">View SOP</a></td>
                                                                        <td></td>

                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>

                                                                        </td>
                                                                        <td><a href="Documents/Application/APL-Petroleum.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1174"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>13</td>
                                                                        <td>Change of Land Use</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""><a href="Documents/SOP/SoP_CLU.pdf" target="blank">View SOP</a></td>
                                                                        <td></td>

                                                                        <td><a href="Documents/Prerequisites/Enclo_LandUse.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="forms/LandUse-APL.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1179"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>14</td>
                                                                        <td>NOC required for setting up of Explosives manufacturing, storage, sale, transport</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""><a href="Documents/SOP/SoP-Explosives.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/Explosive_Act_1884.pdf" target="blank">1. View Document<br>
                                                                        </a><a href="Documents/Rules/ExplosivesRules_2008.pdf" target="blank">2. View Document</a></td>

                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>

                                                                        </td>
                                                                        <td><a href="forms/APPL-Explosives.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1175"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>15</td>
                                                                        <td>NOC required for setting up of Petroleum, Diesel &amp; Naphtha manufacturing, storage, sale,
                          transport</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""><a href="Documents/SOP/SoP-Petroleum.pdf" target="blank">View SOP</a></td>
                                                                        <td></td>

                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>


                                                                        </td>
                                                                        <td><a href="Documents/Application/APL-Petroleum.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1174"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>16</td>
                                                                        <td>Cinematograph License &amp; License for Screening a Films as applicable</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""><a href="assets/SOP/SoP-Cinema.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/Rules-Cinema.pdf" target="blank">1. View Document</a><br>
                                                                            <a href="Documents/Rules/Notification-Cinema.pdf" target="blank">2. View Document</a>
                                                                        </td>

                                                                        <td><a href="Documents/Prerequisites/encl-cinema.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/APPL-Cinema.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1185"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>17</td>
                                                                        <td>Non Encumbrance Certificate</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""><a href="Documents/SOP/Process_Flow_Non.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/rule_ngdrs.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/List_of_Enclosure_Non.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="forms/NEC-APL.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1187"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>18</td>
                                                                        <td>Registration of Societies</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""><a href="Documents/SOP/ProcessFlowros.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/rule_MoA_and_ModelByelaws.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/Enclosureros.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/Application_Formros.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>19</td>
                                                                        <td>Measurement / Demarcation of Land</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td><a href="Documents/Prerequisites/Enclo-LMD.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/LMD-APL.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1189"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>20</td>
                                                                        <td>Grant of Licence for Fair Price Shop</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td><a href="Documents/Prerequisites/Enclo-FPS.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/Appl-FPS.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1173"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>21</td>
                                                                        <td>License for Sale of Crackers</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td><a href="Documents/Prerequisites/Enclo-Crackers.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/Appl-Crackers.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1181"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>22</td>
                                                                        <td>Application for Booking an Appointment with SRO</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td></td>
                                                                        <td><a href="Documents/Application/appl_booking_sro.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1237"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>23</td>
                                                                        <td>Measurement / Demarcation of Land</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td><a href="Documents/Prerequisites/Enclo-LMD.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/LMD-APL.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1189"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>24</td>
                                                                        <td>Grant of Licence for Fair Price Shop</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td><a href="Documents/Prerequisites/Enclo-FPS.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/Appl-FPS.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1173"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>25</td>
                                                                        <td>License for Sale of Crackers</td>

                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td><a href="Documents/Prerequisites/Enclo-Crackers.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/Appl-Crackers.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1181"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>26</td>
                                                                        <td>Application for Booking an Appointment with SRO</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td></td>
                                                                        <td><a href="Documents/Application/appl_booking_sro.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1237"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>27</td>
                                                                        <td>Permission for movie shooting in the District – Issued by Deputy Commissioner</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td><a href="Documents/Prerequisites/EnclosuresMovie.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/ApplicationFormMovieshooting.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>28</td>
                                                                        <td>Application Form for Temporary License for Possession and Sale of Fire Crackers during
                          Festivals Rule No 84 of Explosives Rules 2008</td>
                                                                        <td class="sorting_1">Deputy Commissioner Office</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td><a href="Documents/Application/ApplicationFormCrackers.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>29</td>
                                                                        <td>Application For Allotment Of Land/Industrial Shed</td>
                                                                        <td class="sorting_1">Directorate of Commerce and Industries</td>
                                                                        <td class=""><a href="assets/SOP/Process_flowallot.pdf" target="blank">View SoP</a></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td><a href="Documents/Application/Application_Formallot.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>30</td>
                                                                        <td>Registration of schools under Right to Education</td>
                                                                        <td class="sorting_1">Education Department</td>
                                                                        <td class=""><a href="assets/SOP/SoP-RTE.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/RCFCE_Act_2009.pdf" target="blank">1. View Document</a><br>
                                                                            <a href="Documents/Rules/RCFCE_Rules_2009.pdf" target="blank">2. View Document</a>
                                                                        </td>

                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>


                                                                        </td>
                                                                        <td><a href="Documents/Application/Appl-RTE.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1172"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>31</td>
                                                                        <td>NOC for setting up CBSE School</td>
                                                                        <td class="sorting_1">Education Department</td>
                                                                        <td class=""><a href="Documents/SOP/SoP-CBSE.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/affiliation-Bye-Laws.pdf" target="blank">View Document</a></td>

                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>


                                                                        </td>
                                                                        <td><a href="assets/Application/APPL-CBSE.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1161"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>32</td>
                                                                        <td>Grant of Excise License for Wholesale / Retail / Distillery / Bottling Plant</td>
                                                                        <td class="sorting_1">Excise Registration Taxation Stamps Department</td>
                                                                        <td class=""><a href="Documents/SOP/SoP_Bottling_Plant.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Application/The_Meghalaya_Excise_Amendment_Rules_1973_1979_1987_1995_2008_2009_2010_2012.pdf" target="blank">View Document</a> </td>

                                                                        <td><a href="Documents/Prerequisites/Enclo_License_Excise.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/form_grant_license.pdf" target="blank">Download Form</a></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>33</td>
                                                                        <td>License for local sale, Import and export permit of Spirit and Indian-made foreign liquor
                          (IMFL)</td>
                                                                        <td class="sorting_1">Excise Registration Taxation Stamps Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_permit_spiritIMFL.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Application/The_Meghalaya_Excise_Amendment_Rules_1973_1979_1987_1995_2008_2009_2010_2012.pdf" target="blank">View Document</a> </td>

                                                                        <td><a href="Documents/Prerequisites/Enclo_License_Excise.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/form_permit_spiritIMFL.pdf" target="blank">Download Form</a></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>34</td>
                                                                        <td>Brand and Label Registration</td>
                                                                        <td class="sorting_1">Excise Registration Taxation Stamps Department</td>
                                                                        <td class=""><a href="Documents/SOP/Process_flow.pdf" target="blank">View SOP</a> </td>
                                                                        <td><a href="Documents/Rules/The_Meghalaya_Excise_Amendment_Rules_1973_1979_1987_1995_2008_2009_2010_2012.pdf" target="blank">View Document</a> </td>
                                                                        <td><a href="enclosures/enclo_FeesBrandLabel.PDF" target="blank">Fees Detail</a> </td>
                                                                        <td><a href="Documents/Application/ApplicationBrandandLabeldocs.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>35</td>
                                                                        <td>Property Registration</td>
                                                                        <td class="sorting_1">Excise Registration Taxation Stamps Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_ngdrs.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/rule_ngdrs.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/enclo_ngdrs.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/form_ngdrs.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>36</td>
                                                                        <td>State Excise Dashboard</td>
                                                                        <td class="sorting_1">Excise Registration Taxation Stamps Department</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>37</td>
                                                                        <td>Registration of societies having area of operation in more that one District or covering
                          whole of Meghalaya / North East</td>
                                                                        <td class="sorting_1">Excise Registration Taxation Stamps Department</td>
                                                                        <td class=""></td>
                                                                        <td><a href="Documents/Rules/GuidelinesSubmissionMemorandum.pdf" target="blank">View Document</a>
                                                                        </td>
                                                                        <td>
                                                                            <div class="">
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>

                                                                        </td>
                                                                        <td><a href="forms/Appl_RoS.pdf" target="blank">1. Download Application Form</a><br>
                                                                            <a href="forms/MembersGoverningBody.pdf" target="blank">2. Download GB Format</a>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>38</td>
                                                                        <td>Property Registration Dashboard</td>
                                                                        <td class="sorting_1">Excise Registration Taxation Stamps Department</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>39</td>
                                                                        <td>Grant of Fire Safety Certificate</td>
                                                                        <td class="sorting_1">Fire and Emergency Service</td>
                                                                        <td class=""><a href="assets/SOP/SoP_FireClearance.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/The_Meghalaya_Fire_and_Emergency_Services_Act.pdf" target="blank">View
                            Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/FireSafetyCertificateEnclo.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/FireEmergencyServiceForm.pdf" target="blank">Download Form</a></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>40</td>
                                                                        <td>Provisional Fire Safety Certificate</td>
                                                                        <td class="sorting_1">Fire and Emergency Service</td>
                                                                        <td class=""><a href="Documents/SOP/SoP_FireClearance.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/The_Meghalaya_Fire_and_Emergency_Services_Act.pdf" target="blank">View
                            Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/ProvFireSafetyCertificateEnclo.pdf" target="blank">View Enclosures</a>
                                                                        </td>
                                                                        <td><a href="Documents/Application/FireClearance_Form.pdf" target="blank">Download Form</a></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>41</td>
                                                                        <td>Certificate of Non-Forest land</td>
                                                                        <td class="sorting_1">Forest Department</td>
                                                                        <td class=""><a href="Documents/SOP/SoP-NFL.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/The_Meghalaya_Forest_Regulation_1973.pdf" target="blank">View Document</a>
                                                                        </td>

                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>



                                                                        </td>
                                                                        <td><a href="forms/NFL-APL.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>42</td>
                                                                        <td>Permission for felling of Isolated trees in Non-Forest areas like from Homestead/ Farm Etc,
                          as per the provisions of the Meghalaya Tree Felling (Non Forest Areas) Rules, 2006</td>
                                                                        <td class="sorting_1">Forest Department</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>



                                                                        </td>
                                                                        <td><a href="forms/Application-form-felling-trees.pdf" target="_blank" title="Pdf that opens in a new window">Download Form</a></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>43</td>
                                                                        <td>Letter of Intent For Mining Lease / Mining Lease</td>
                                                                        <td class="sorting_1">Forest Department</td>
                                                                        <td class=""></td>
                                                                        <td><a href="Documents/Rules/Meghalaya_Minor_Mineral_Concession_Rules_2016.pdf" target="blank">View
                            Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/LOIML-ENCL.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/LOI-ML-APL.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>44</td>
                                                                        <td>Letter of Intent For Quarry Permit / Quarry Permit</td>
                                                                        <td class="sorting_1">Forest Department</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td><a href="Documents/Prerequisites/LOI-QP-ENCL.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/LOIQP-APL.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>45</td>
                                                                        <td>Tree felling in forest land (Government or private)</td>
                                                                        <td class="sorting_1">Forest Department</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>46</td>
                                                                        <td>Wildlife clearance through the National Board for Wildlife </td>
                                                                        <td class="sorting_1">Forest Department</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>47</td>
                                                                        <td>NOC for field survey and investigation work for Hydro project </td>
                                                                        <td class="sorting_1">Forest Department</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>48</td>
                                                                        <td>Environmental clearance for cement plant of 1.00 million tonnes per annum production
                          capacity and above</td>
                                                                        <td class="sorting_1">Forest Department</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>49</td>
                                                                        <td>Environmental clearance for Thermal Power Plants of 500 MW or more (coal/lignite/naphta
                          &amp; gas based) and of 50 MW or more for Pet Coke Diesel and all other fuels</td>
                                                                        <td class="sorting_1">Forest Department</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>50</td>
                                                                        <td>Registration under PC&amp;PNDT Act, 1994 (Amended subsequently) (For 5 years) &amp; its Renewal</td>
                                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                                        <td class=""><a href="Documents/SOP/SoP_PCPNDT.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/PCPNDT_Rules_1996.pdf" target="blank">View Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/PCPNDT-Enclosures.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/PCPNDT-ApplForm.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>51</td>
                                                                        <td>Registration of clinical establishments under the Meghalaya Nursing Homes (Licensing and
                          Registration) Act 1993</td>
                                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                                        <td class=""><a href="Documents/SOP/SoP-NursingHomes.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/ENCL-NursingHomes.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/APPL-NursingHomes.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>52</td>
                                                                        <td>Licence for Retail and Wholesale Drug licence</td>
                                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_License_Retailer.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/enclo_License_Retailer.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/form_License_Retailer.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>53</td>
                                                                        <td>Change of Constitution of Licence for Retail and Wholesale Drug Licence</td>
                                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_License_Retailer.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/enclo_License_Retailer_const.pdf" target="blank">View Enclosures</a>
                                                                        </td>
                                                                        <td><a href="forms/form_License_Retailer.pdf" target="blank">Download Form</a> </td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>54</td>
                                                                        <td>Application For The Grant /Renewal Of License To Manufacture For Sale Or For Distribution Of
                          Large Volume Parenterals/Sera And Vaccines Excluding Those Specified In Schedule X</td>
                                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_license_parental27D.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="enclosures/enclo_FeesDrugs.pdf" target="blank">Fees Detail</a></td>
                                                                        <td><a href="Documents/Application/form_license_parental27D.pdf" target="blank">Download Form</a> </td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>55</td>
                                                                        <td>Application For The Grant /Renewal Of License To Repack For Sale Or For Distribution Of
                          Drugs Other Than That Specified In Schedule C, C(1) Excluding Those Specified In Schedule X
                                                                        </td>
                                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_Form24B.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="enclosures/enclo_FeesDrugs.pdf" target="blank">Fees Detail</a></td>
                                                                        <td><a href="Documents/Application/form_Form24B.pdf" target="blank">Download Form</a> </td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>56</td>
                                                                        <td>Application For The Grant Of Loan License To Manufacture For Sale Or For Distribution Of
                          Drugs Specified In Schedule C, C (1) Excluding Those Specified In Part Xb &amp; Schedule X</td>
                                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_license_drugs27A.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="enclosures/enclo_FeesDrugs.pdf" target="blank">Fees Detail</a></td>
                                                                        <td><a href="Documents/Application/form_license_drugs27A.pdf" target="blank">Download Form</a> </td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>57</td>
                                                                        <td>Application For The Grant /Renewal Of License To Manufacture For Sale Or For Distribution Of
                          Drugs That Are Specified In Schedule C, C (1) Excluding Those Specified In (Part Xb And)
                          Schedule X</td>
                                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_license_drugs27.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="enclosures/enclo_FeesDrugs.pdf" target="blank">Fees Detail</a></td>
                                                                        <td><a href="Documents/Application/form_license_drugs27.pdf" target="blank">Download Form</a> </td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>58</td>
                                                                        <td>Application For The Grant/Renewal Of License To Manufacture Drugs For Purpose Of
                          Examination, Test Or Analysis</td>
                                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_Form30.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="enclosures/enclo_FeesDrugs.pdf" target="blank">Fees Detail</a></td>
                                                                        <td><a href="Documents/Application/form_license_drugs30.pdf" target="blank">Download Form</a> </td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>59</td>
                                                                        <td>Application For The Grant /Renewal Of License To Manufacture For Sale Or For Distribution Of
                          Drugs Other Than That Specified In Schedule C, C1, X</td>
                                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_Form24.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="enclosures/enclo_FeesDrugs.pdf" target="blank">Fees Detail</a></td>
                                                                        <td><a href="Documents/Application/form_license_drugs24.pdf" target="blank">Download Form</a> </td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>60</td>
                                                                        <td>Auto rentention for Drugs</td>
                                                                        <td class="sorting_1">Health &amp; Family Welfare Department</td>
                                                                        <td class=""><a href="Documents/SOP/Process_Flowarod.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/drug_and_cosneti_ ruls_1.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/enclo_AutorententionforDrugs.pdf" target="blank">View Enclosures</a>
                                                                        </td>
                                                                        <td><a href="Documents/Application/DrugLicenceapplicationForm_Retail Wholesale.pdf" target="blank">Download
                            Form</a> </td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>61</td>
                                                                        <td>NOC for installation of DG set</td>
                                                                        <td class="sorting_1">Inspectorate of Electricity</td>
                                                                        <td class=""><a href="Documents/SOP/process_flowdg.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/CEA_(DG_Set)_Regulations_2010dg.pdf" target="blank">View Document</a></td>


                                                                        <td><a href="Documents/Prerequisites/List_Enclosuredg.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/ApplicationForm_DG_Set.pdf" target="blank">Download Form</a></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>62</td>
                                                                        <td>Registration of Employment Exchange</td>
                                                                        <td class="sorting_1">Labour</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>63</td>
                                                                        <td>License for Contractors under the Contract Labour Act 1970</td>
                                                                        <td class="sorting_1">Labour Department</td>

                                                                        <td class=""><a href="Documents/SOP/sop_labouract1970.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/rule_labouract1970.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/enclo_labouract1970.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/form_labouract1970.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>64</td>
                                                                        <td>Registration of Shops and Establishment - FORM - A</td>
                                                                        <td class="sorting_1">Labour Department</td>
                                                                        <td class=""><a href="Documents/SOP/Process_Flowshops.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/Meghalaya_Shops_Establishment_Rules_2004.pdf" target="blank">View
                            Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/List_Enclosureshops.pdf" target="blank">View Enclosures</a>
                                                                            <br>
                                                                            <br>
                                                                            <a href="Documents/Prerequisites/fees_detailshops.pdf" target="blank">View Enclosures</a>
                                                                        </td>
                                                                        <td><a href="Documents/Application/Application_Formshops.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>65</td>
                                                                        <td>Application for Registration of Establishments/Principal Employer Employing Contract Labour
                          Act 1970</td>
                                                                        <td class="sorting_1">Labour Department</td>

                                                                        <td class=""><a href="Documents/SOP/sop_labouract1970.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/rule_labouract1970.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/enclo_labouract1970.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/form_labouract1970.pdf" target="blank">Download Form</a> </td>


                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>66</td>
                                                                        <td>Registration of Establishments employing Building Workers under the Building and Other
                          Construction Work Act 1996</td>
                                                                        <td class="sorting_1">Labour Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_workact1996.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/rule_workact1996.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/enclo_workact1996.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/form_workact1996.pdf" target="blank">Download Form</a></td>


                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>67</td>
                                                                        <td>Registration of Establishment under the Inter State Migrant Workmen (RE&amp;CS) Act,1979</td>
                                                                        <td class="sorting_1">Labour Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_migrantworkmen1979.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/ISMW_Act_1979.pdf" target="blank">1. View Document</a><br>
                                                                            <a href="Documents/Rules/ISMW_Rules_1985.pdf" target="blank">2. View Document</a><br>
                                                                            <a href="Documents/Rules/ISMW_Amendment_Rules_2011.pdf" target="blank">3. View Document</a>
                                                                        </td>

                                                                        <td><a href="enclosures/.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/form_migrantworkmen1979.pdf" target="blank">Download Form</a> </td>


                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>68</td>
                                                                        <td>Registration of Migrant Workers Under the Meghalaya Identification, Registration(Safety &amp;
                          Security) of Migrant Workers Rules, 2020</td>
                                                                        <td class="sorting_1">Labour Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_migrant_worker_rule2020.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/ISMW_2020.pdf" target="blank">View Document</a></td>

                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>



                                                                        </td>
                                                                        <td><a href="forms/form_migrant_worker_rule2020.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>69</td>
                                                                        <td>License For Contractors Under The Interstate Migrant Workmen Act 1979</td>
                                                                        <td class="sorting_1">Labour Department</td>
                                                                        <td class=""><a href="Documents/SOP/WorkFlow_Interstate_Migrant_Workers.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/The_Inter_State_Migrant_Workmen_(RE&amp;CS)_Meghalaya_Rules_1985.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/ListofEnclosurespow.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/FORMpow.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>70</td>
                                                                        <td>Migrant Worker 2020-Renewal</td>
                                                                        <td class="sorting_1">Labour Department</td>
                                                                        <td class=""><a href="Documents/SOP/sop_renew_migrant_worker_rule2020.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/ISMW_2020.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/ListofEnclsosuresmwr.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/FORMmwr.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>71</td>
                                                                        <td>Shops and Establishment 2003 Auto Renewal</td>
                                                                        <td class="sorting_1">Labour Department</td>
                                                                        <td class=""><a href="Documents/SOP/ProcessFlowsear.pdf" target="blank">View SoP</a></td>
                                                                        <td></td>
                                                                        <td><a href="Documents/Prerequisites/ListofEnclosuressear.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/Application_Formsear.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>72</td>
                                                                        <td>Certificate of Registration to work as Motor Transport Undertaking</td>
                                                                        <td class="sorting_1">Labour Department</td>
                                                                        <td class=""></td>
                                                                        <td><a href="Documents/Rules/meghalaya_motor_transport_rules.pdf" target="blank">View Document</a></td>

                                                                        <td></td>
                                                                        <td><a href="Documents/Application/appl_motor_transport.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>73</td>
                                                                        <td>Annual Filing of single integrated return under all the labour laws</td>
                                                                        <td class="sorting_1">Labour Department</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>74</td>
                                                                        <td>Half Yearly Filing of single integrated return under all the labour laws</td>
                                                                        <td class="sorting_1">Labour Department</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>75</td>
                                                                        <td>Licence as Dealers in Weights &amp; Measures under the Legal Metrology Act, 2009</td>
                                                                        <td class="sorting_1">Legal Metrology Department</td>
                                                                        <td class=""><a href="Documents/SOP/SOP_LegMet_Licence.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/MeghalayaLegalMetrology_Enforcement_Rules_2011.pdf" target="blank">View
                            Document</a></td>


                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>


                                                                        </td>
                                                                        <td><a href="Documents/Application/LicenseDealerLegalMetrology.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>76</td>
                                                                        <td>Licence as Repairers of Weights &amp; Measures under the Legal Metrology Act, 2009</td>
                                                                        <td class="sorting_1">Legal Metrology Department</td>
                                                                        <td class=""><a href="Documents/SOP/SOP_LegMet_Licence.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/MeghalayaLegalMetrology_Enforcement_Rules_2011.pdf" target="blank">View
                            Document</a></td>


                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>


                                                                        </td>
                                                                        <td><a href="forms/LicenseRepairerLegalMetrology.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>77</td>
                                                                        <td>Licence as Manufacturer of weights &amp; measures under the Legal Metrology Act, 2009</td>
                                                                        <td class="sorting_1">Legal Metrology Department</td>
                                                                        <td class=""><a href="Documents/SOP/SOP_LegMet_Licence.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/MeghalayaLegalMetrology_Enforcement_Rules_2011.pdf" target="blank">View
                            Document</a></td>


                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>



                                                                        </td>
                                                                        <td><a href="forms/LicenseManufacturerLegalMetrology.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>78</td>
                                                                        <td>Certificate for Verification and Stamping of Weights &amp; Measures</td>
                                                                        <td class="sorting_1">Legal Metrology Department</td>
                                                                        <td class=""><a href="Documents/SOP/SoP_Verification_Weights.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/MeghalayaLegalMetrology_Enforcement_Rules_2011.pdf" target="blank">View
                            Document</a></td>

                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>



                                                                        </td>
                                                                        <td><a href="assets/Application/ApplicationVerificationWeights.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>79</td>
                                                                        <td>Licence as Dealers in Weights &amp; Measures-Auto Renewal</td>
                                                                        <td class="sorting_1">Legal Metrology Department</td>
                                                                        <td class=""><a href="Documents/SOP/Process_flow_legal_renewal_service.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/MeghalayaLegalMetrology_Enforcement_Rules_2011.pdf" target="blank">View
                            Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/ListofEnclosuresdwmar.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/ApplicationFormdwmar.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>80</td>
                                                                        <td>Licence as Manufacturer of Weights &amp; Measures-Auto Renewal</td>
                                                                        <td class="sorting_1">Legal Metrology Department</td>
                                                                        <td class=""><a href="Documents/SOP/Process_flow_legal_renewal_service.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/MeghalayaLegalMetrology_Enforcement_Rules_2011.pdf" target="blank">View
                            Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/ListofEnclosuresmwmar.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/ApplicationFormmwmar.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>81</td>
                                                                        <td>Licence as Repairers of Weights &amp; Measures-Auto Renewal</td>
                                                                        <td class="sorting_1">Legal Metrology Department</td>
                                                                        <td class=""><a href="Documents/SOP/Process_flow_legal_renewal_service.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/MeghalayaLegalMetrology_Enforcement_Rules_2011.pdf" target="blank">View
                            Document</a></td>

                                                                        <td><a href="assets/Prerequisites/ListofEnclosuresrwmar.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="assets/Application/ApplicationFormrwmar.pdf" target="blank">Download Form</a> </td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>82</td>
                                                                        <td>Consent to Establish" under the Water (Prevention &amp; Control of Pollution) Act, 1974
                          and Air (Prevention &amp; Control of Pollution) Act, 1981/"NOC"</td>
                                                                        <td class="sorting_1">Meghalaya State Pollution Control Board</td>
                                                                        <td class=""><a href="Documents/SOP/SoP_CTE.pdf" target="_blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/SoP_CTE.pdf" target="_blank">View Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/SoP_CTE.pdf" target="_blank">View Enclosures</a></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>83</td>
                                                                        <td>Consent to Operate" under the Water (Prevention &amp; Control of Pollution) Act, 1974
                          and Air (Prevention &amp; Control of Pollution) Act, 1981</td>
                                                                        <td class="sorting_1">Meghalaya State Pollution Control Board</td>
                                                                        <td class=""><a href="Documents/SOP/SoP_CTO.pdf" target="_blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/SoP_CTO.pdf" target="_blank">View Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/SoP_CTO.pdf" target="_blank">View Enclosures</a></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>84</td>
                                                                        <td>Registration / Renewal under the E-waste (Management and Handling) Rules, 2011</td>
                                                                        <td class="sorting_1">Meghalaya State Pollution Control Board</td>
                                                                        <td class=""><a href="Documents/SOP/SoP_eWaste.pdf" target="_blank">View SOP</a></td>
                                                                        <td></td>

                                                                        <td><a href="Documents/Prerequisites/SoP_eWaste.pdf" target="_blank">View Enclosures</a></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>85</td>
                                                                        <td>Registration / Renewal under Plastic Waste (Management and Handling) Rules, 2011</td>
                                                                        <td class="sorting_1">Meghalaya State Pollution Control Board</td>
                                                                        <td class=""><a href="Documents/SOP/Processflow_Plastic.pdf" target="_blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/PlasticWastemanagementRules.pdf" target="blank">View Document</a></td>

                                                                        <td><a href="Documents/Prerequisites/Enclosures_PlasticWaste.pdf" target="_blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/ApplicationForm_PlasticWasteManagement.pdf" target="_blank">Download Form</a>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>86</td>
                                                                        <td>Registration for dealers under the Batteries (Management &amp; Handling) Rules, 2001</td>
                                                                        <td class="sorting_1">Meghalaya State Pollution Control Board</td>
                                                                        <td class=""><a href="Documents/SOP/Process_flow_Batteries_waste_Mangement.pdf" target="blank">View SoP</a></td>
                                                                        <td><a href="Documents/Rules/Battery_management_handling_rules_2001.pdf" target="_blank">View Document</a>
                                                                        </td>
                                                                        <td><a href="Documents/Prerequisites/List_Enclosure_battery.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/Batteries_form_SPCB_EoDB.pdf" target="blank">Download Form</a> </td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>87</td>
                                                                        <td>Authorization under the Hazardous and Other Waste (Management and Transboundary Movement)
                          Rules 2016</td>
                                                                        <td class="sorting_1">Meghalaya State Pollution Control Board</td>
                                                                        <td class=""><a href="Documents/SOP/SoP_Hazardous.pdf" target="_blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/hazardous_and_Other_Wastes_(Management_Transboundary_Movement)_rules2016.pdf" target="_blank">View Document</a></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>88</td>
                                                                        <td>Application for obtaining authorization for Construction and Demolition Waste Management
                                                                        </td>
                                                                        <td class="sorting_1">Meghalaya State Pollution Control Board</td>
                                                                        <td class=""><a href="Documents/SOP/Processflow_Constructiondemolition.pdf" target="_blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/Construction_and_Demolition_waste_managemnet_Rules.pdf" target="_blank">View
                            Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/Enclosures_CDWaste.pdf" target="_blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/ApplicationForm_ConstructionDemolition.pdf" target="_blank">Download Form</a>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>89</td>
                                                                        <td>Application for obtaining authorization under solid waste management rules for processing or
                          recycling or treatment and disposal of solid waste</td>
                                                                        <td class="sorting_1">Meghalaya State Pollution Control Board</td>
                                                                        <td class=""><a href="Documents/SOP/Processflow_SolidwasteMangement.pdf" target="_blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/Solid_Waste_Management_Rules.pdf" target="_blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/Enclosures_SolidWaste.pdf" target="_blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/ApplicationForm_SolidWasteManagement.pdf" target="_blank">Download Form</a>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>90</td>
                                                                        <td>Authorization Under Bio-Medical Waste Management (Management &amp; Handling) Rules, 2016</td>
                                                                        <td class="sorting_1">Meghalaya State Pollution Control Board</td>
                                                                        <td class=""><a href="Documents/SOP/Process_flow_Bio_Medical_Waste_Management.pdf" target="_blank">Download
                            SOP</a></td>
                                                                        <td><a href="Documents/Rules/Bio_Medical_Waste_rules2016.pdf" target="_blank">View Document</a></td>
                                                                        <td><a href="enclosures/enclo_biomedical_waste_fees.pdf" target="_blank">Fees Detail</a></td>
                                                                        <td><a href="Documents/Application/Application_form_II_(BMW).pdf" target="_blank">Download Form</a></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>91</td>
                                                                        <td>Authorization for management and handling of e-waste</td>
                                                                        <td class="sorting_1">Meghalaya State Pollution Control Board</td>
                                                                        <td class=""></td>
                                                                        <td><a href="Documents/Rules/e_waste_Management_rules2016.pdf" target="_blank">View Document</a></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>92</td>
                                                                        <td>Meghalaya Energy Corporation Limited (MeECL) Payment of bill</td>
                                                                        <td class="sorting_1">Power</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>93</td>
                                                                        <td>Meghalaya Energy Corporation Limited (MeECL) New Connection</td>
                                                                        <td class="sorting_1">Power</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>94</td>
                                                                        <td>Certificate for non-availability of Water Supply from Water Supply Agency</td>
                                                                        <td class="sorting_1">Public Health Engineering Department</td>
                                                                        <td class=""><a href="Documents/SOP/SoP-NAWS.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/Guidelines_CGWA.pdf" target="blank">View Document</a></td>
                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>


                                                                        </td>
                                                                        <td><a href="forms/APPL-NAWS.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>95</td>
                                                                        <td>Grant of Water Connection to Non Municipal Urban Areas</td>
                                                                        <td class="sorting_1">Public Health Engineering Department</td>
                                                                        <td class=""><a href="Documents/SOP/Process_flowgwc.pdf" target="blank">View SOP</a></td>
                                                                        <td><a href="Documents/Rules/The_Meghalaya_Water_(Prevention_and_Control_of_Pollution)_Rules.pdf" target="blank">View Document</a></td>
                                                                        <td><a href="Documents/Prerequisites/Enclosuregwc.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="asDocumentssets/Application/appl_water_non_municipal.pdf" target="blank">Download Form</a></td>

                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>96</td>
                                                                        <td>Registration of Contractors for Works and Services by Public Works Department</td>

                                                                        <td class="sorting_1">Public Works Department</td>
                                                                        <td class="">View SOP</td>
                                                                        <td>View Document<br>
                                                                        </td>
                                                                        <td><a href="Documents/Prerequisites/Enclo_PWD_Contractors.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/Appl_PWD_Contractors.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1176"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>97</td>
                                                                        <td>Permission for Road Cutting</td>

                                                                        <td class="sorting_1">Public Works Department</td>
                                                                        <td class="">View SOP</td>
                                                                        <td>View Document<br>
                                                                        </td>
                                                                        <td><a href="Documents/Prerequisites/Enclo_PWD_Road Cutting.pdf" target="blank">View Enclosures</a></td>
                                                                        <td><a href="Documents/Application/Road-Cutting-APL.pdf" target="blank">Download Form</a></td>
                                                                        <%--                        <td><a href="https://investmeghalaya.gov.in/directApply.do?serviceId=1184"><img src="images/apply-icon.png" width="100" height="34"></a></td>--%>
                                                                    </tr>
                                                                    <tr class="even">
                                                                        <td>98</td>
                                                                        <td>Certificate of Incorporation </td>

                                                                        <td class="sorting_1">Registrar of Companies</td>
                                                                        <td class=""></td>
                                                                        <td></td>

                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr class="odd">
                                                                        <td>99</td>
                                                                        <td>Registration of Cooperative Society</td>
                                                                        <td class="sorting_1">Registrar of Cooperative Societies</td>
                                                                        <td class=""></td>
                                                                        <td></td>
                                                                        <td>
                                                                            <div>
                                                                                <a href="#">View Enclosures</a>
                                                                            </div>



                                                                        </td>
                                                                        <td>
                                                                            <p><a href="Documents/Application/Registration-Cooperative-Society.pdf" target="_blank" title="Pdf that opens in a new window">Download Form </a></p>
                                                                            <p><a href="Documents/Application/PromotersList_Coop.pdf" target="_blank" title="Pdf that opens in a new window">Download Promoters List</a></p>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>
                                    <div class="update">
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
