<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="InformationWizard.aspx.cs" Inherits="MeghalayaUIP.InformationWizard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        table#servicestable th {
            vertical-align: middle;
        }

        select#ContentPlaceHolder1_ddlPolCategory {
            display: block;
            width: 100%;
            padding: 0.475rem 0.75rem;
            font-size: 1rem;
            line-height: 1.7;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
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

                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblApprovalid" runat="server" Text='<%#Eval("IW_APPROVALID") %>' HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-ForeColor="WindowText" Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                   <%-- <asp:BoundField HeaderText="APPROVALID" DataField="IW_APPROVALID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-ForeColor="WindowText" Visible="false" />--%>

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
                                                                    <asp:TemplateField HeaderText="Apply Online" ItemStyle-Width="10%">                                                                       
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnOnline" runat="server" Text='Apply Online' CommandName="Apply" CssClass="btn btn-info" OnClick="btnOnline_Click" />                                                                                
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
