<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="DeptWiseServices.aspx.cs" Inherits="MeghalayaUIP.Dept.DeptWiseServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Dashboard/DeptDashboard.aspx">Dashboard</a></li>
            <li class="breadcrumb-item active" aria-current="page">Department Services</li>
        </ol>
    </nav>
    <style>
        .col-md-12.d-flex {
            right: -275px;
            padding: 0px 0px !important;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="card-header d-flex justify-content-between">
                        <h4 class="card-title mt-1"><b>List Of Services:</b></h4>
                        <div class="col-md-1">
                            <asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-body">
                            <div class="col-md-12 ">
                                <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
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
                            <div align="center">
                                <div class="row" align="center">
                                    <div class="panel panel-primary">
                                        <div class="panel-body">

                                            <div class="card-body justify-content-center " align="justify">
                                                <div class="panel panel-default">                                                 
                                                  
                                                  

                                                    <div>
                                                        <asp:GridView ID="gvDptpg" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CssClass="table-bordered table-hover" ForeColor="#333333"
                                                            GridLines="Both" Width="100%" EnableModelValidation="True"
                                                            ShowFooter="true" OnLoad="Page_Load">
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


                                                                <asp:BoundField HeaderText="Service Name" DataField="IW_APPROVALNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-ForeColor="WindowText" Visible="true" />
                                                                <asp:BoundField HeaderText="Department" DataField="IW_DEPTNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" ItemStyle-ForeColor="WindowText" />
                                                                <asp:BoundField HeaderText="Application Category" DataField="CATEGORY" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                                <asp:TemplateField HeaderText="Standard Operating Procedure">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink runat="server" ID="hplViewSOP" Text="View SOP" Style="color: dodgerblue;" NavigateUrl='<%#Eval("IW_SOP") %>' Target="_blank" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Rules and Regulations">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink runat="server" ID="hplRulesandReg" Text="View Document" Style="color: dodgerblue;" NavigateUrl='<%#Eval("IW_RULESANDREGL") %>' Target="_blank" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Prerequisites">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink runat="server" ID="hplPrerequisites" Text="View Enclosures" Style="color: dodgerblue;" NavigateUrl='<%#Eval("IW_PREREQUISITES") %>' Target="_blank" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Application Form Format">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink runat="server" ID="hplApplForm" Text="Download Form" Style="color: dodgerblue;" NavigateUrl='<%#Eval("IW_APPLFORMAT") %>' Target="_blank" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>

                                                    

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
