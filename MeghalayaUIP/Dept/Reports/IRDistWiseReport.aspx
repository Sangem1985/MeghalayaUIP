<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="IRDistWiseReport.aspx.cs" Inherits="MeghalayaUIP.Dept.Reports.IRDistWiseReport" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
   

    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
            <li class="breadcrumb-item">Department</li>
            <li class="breadcrumb-item active" aria-current="page">District Wise Reports</li>
        </ol>
    </nav>
    <style>
       
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="card-header d-flex justify-content-between">
                        <h4 class="card-title mt-1"><b>District Wise Report:</b></h4>
                        <div class="col-md-1">
                            <asp:LinkButton ID="lbtnBack" OnClick="lbtnBack_Click" runat="server" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
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
                                                    <div class="panel-heading" style="text-align: center">
                                                        <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                                            <asp:Label ID="lblHeading" runat="server" Visible="false">DistrictWiseReports</asp:Label>
                                                            <asp:ImageButton ID="btnPdf" runat="server" ImageUrl="../../assets/admin/img/pdf-icon.png" Width="30px" Height="30px" Style="float: right" alt="PDF" OnClick="btnPdf_Click" />
                                                            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="../../assets/admin/img/Excel-icon.png" Width="30px" Height="30px" Style="float: right" alt="EXCEL" OnClick="btnExcel_Click" /></h2>


                                                    </div>
                                                    <div class="col-md-12 d-flex justify-content-center align-items-center">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="col-lg-12 col-form-label">District :</label>
                                                                <div class="col-lg-12 d-flex">
                                                                    <asp:DropDownList ID="ddldistrict" runat="server" class=" form-control" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged" AutoPostBack="true">
                                                                        <asp:ListItem Value="0">--ALL--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="col-lg-12 col-form-label">Type of Enterprise : </label>
                                                                <div class="col-lg-12 d-flex">
                                                                    <asp:DropDownList ID="ddlEnterPriseType" runat="server" class=" form-control">
                                                                        <asp:ListItem Value="--Select--">--ALL--</asp:ListItem>
                                                                        <asp:ListItem Value="Micro">Micro</asp:ListItem>
                                                                        <asp:ListItem Value="Small">Small</asp:ListItem>
                                                                        <asp:ListItem Value="Medium">Medium</asp:ListItem>
                                                                        <asp:ListItem Value="Large">Large</asp:ListItem>
                                                                        <asp:ListItem Value="Mega">Mega</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex justify-content-center align-items-center">

                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="col-lg-12 col-form-label">From Date:</label>
                                                                <div class="col-lg-12 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtFormDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFormDate"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="col-lg-12 col-form-label">To Date: </label>
                                                                <div class="col-lg-12 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtToDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 float-left ">
                                                        <div class="form-group row justify-content-center" style="padding: 20px">
                                                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="Search" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                                        </div>
                                                    </div>

                                                    <asp:GridView ID="GVDistrictWise" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD;" ForeColor="#333333"
                                                        GridLines="Both" OnRowDataBound="GVDistrictWise_RowDataBound" ShowFooter="true"
                                                        Width="100%" EnableModelValidation="True">
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                        <AlternatingRowStyle BackColor="LightGray" Font-Bold="true" />
                                                        <RowStyle Height="40px" BorderColor="Blue" Font-Bold="true" />
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Districtid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDistrictid" runat="server" Text='<%#Eval("DISTRICID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="DISTRICTNAME" HeaderText="District" ItemStyle-HorizontalAlign="Left" />
                                                            <%--  <asp:TemplateField HeaderText="District">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="lblBeyonReport" Text='<%#Eval("DISTRICTNAME") %>' />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="Total Applications">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblTotal" Text='<%#Eval("TOTALAPPL") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="IMA Pending">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblPending" Text='<%#Eval("IMAPENDING") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="IMA QueryRaised">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblQueryRaised" Text='<%#Eval("IMAQUERYRAISED") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="QUERY REDRESSED TO IMA">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblQueryRedressed" Text='<%#Eval("QUERYREDRESSEDTOIMA") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Committee Pending">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblCommPending" Text='<%#Eval("COMMPENDING") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Committee Approved">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblCommApproved" Text='<%#Eval("COMMAPPROVED") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Committee Rejected">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblCommRejected" Text='<%#Eval("COMMREJECTED") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CommitteeQuery">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblCommQuery" Text='<%#Eval("COMMQUERY") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>

                                                </div>
                                                <div>
                                                    <asp:Label ID="label" runat="server"></asp:Label>
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
