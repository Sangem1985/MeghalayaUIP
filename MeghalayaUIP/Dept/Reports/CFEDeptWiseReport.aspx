<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="CFEDeptWiseReport.aspx.cs" Inherits="MeghalayaUIP.Dept.Reports.CFEDeptWiseReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
            <li class="breadcrumb-item">Department</li>
            <li class="breadcrumb-item">Reports</li>
            <li class="breadcrumb-item active" aria-current="page">CFEDepartmentWiseReport</li>
        </ol>
    </nav>
    <style>
       
    </style>



    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="card-header d-flex justify-content-between">
                        <h4 class="card-title mt-1"><b>Pre Establishment Department Wise Report:</b></h4>
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
                                                            <asp:Label ID="lblHeading" runat="server" Visible="false">Department Wise Reports</asp:Label>
                                                            <asp:ImageButton ID="btnPdf" runat="server" ImageUrl="../../assets/admin/img/pdf-icon.png" Width="30px" Height="30px" Style="float: right" alt="PDF" OnClick="btnPdf_Click" />
                                                            <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="../../assets/admin/img/Excel-icon.png" Width="30px" Height="30px" Style="float: right" alt="EXCEL" OnClick="btnExcel_Click" /></h2>
                                                    </div>
                                                    <div class="col-md-12 d-flex justify-content-center align-items-center">
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label class="col-lg-6 col-form-label">Department :</label>
                                                                <div class="col-lg-8 d-flex">
                                                                    <asp:DropDownList ID="ddldepartment" runat="server" class=" form-control" AutoPostBack="true">
                                                                        <asp:ListItem Value="0">--ALL--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label class="col-lg-5 col-form-label">From Date:</label>
                                                                <div class="col-lg-7 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtFormDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFormDate"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label class="col-lg-4 col-form-label">To Date: </label>
                                                                <div class="col-lg-7 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtToDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 d-flex justify-content-center align-items-center">
                                                    </div>
                                                    <div class="col-md-12 float-left ">
                                                        <div class="form-group row justify-content-center" style="padding: 20px">
                                                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="Search" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                                        </div>
                                                    </div>

                                                    <%--CssClass="table-bordered mb-0 GRD;"--%>
                                                    <asp:GridView ID="GVDistrictWise" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="grid-view" ForeColor="#333333"
                                                        GridLines="Both" ShowFooter="true" OnRowCreated="GVDistrictWise_RowCreated" OnRowDataBound="GVDistrictWise_RowDataBound"
                                                        Width="100%" EnableModelValidation="True">
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                        <AlternatingRowStyle BackColor="LightGray" Font-Bold="true" />
                                                        <RowStyle Height="40px" BorderColor="Blue" Font-Bold="true" />
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" /> 
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="3%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="DepartmentId" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDepartmentid" runat="server" Text='<%#Eval("DEPT_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="Department" ItemStyle-HorizontalAlign="Left" />

                                                            <asp:TemplateField HeaderText="Approvals Applied">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblApprovalApplied" Text='<%#Eval("APPROVALIS_APPLIED") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Query Raised">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblQueryRaised" Text='<%#Eval("QUERY_RAISED") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Before Due Date">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblScrutinyBeforeDate" Text='<%#Eval("SCRUTINY_BEFOREDUEDATE") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="After Due Date">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblScrutinyAfterDate" Text='<%#Eval("SCRUTINY_AFTERDUEDATE") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PreScrutiny Rejected">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblPreRejected" Text='<%#Eval("PRESCRUTINY_REJECTED") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Scrutiny-Completed Additional-Payment Pending">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblPaymentPending" Text='<%#Eval("PAYMENT_PENDING") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Scrutiny-Completed">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblScrutinyCompleted" Text='<%#Eval("SCRUTINY_COMPLETED") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Before Due Date">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblApprovalBeforeDate" Text='<%#Eval("APPROVALUNDER_PROCESSBEFOREDATE") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="After Due Date">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblApprovalDate" Text='<%#Eval("APPROVALUNDER_PROCESSAFTERDATE") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Department-Approved">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblDepatApproved" Text='<%#Eval("DEPARTMENT_APPROVED") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Rejected">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblRejected" Text='<%#Eval("REJECTED") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>

                                                        </Columns>

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
