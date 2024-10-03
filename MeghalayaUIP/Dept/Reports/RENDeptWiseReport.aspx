<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="RENDeptWiseReport.aspx.cs" Inherits="MeghalayaUIP.Dept.Reports.RENDeptWiseReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            padding: 0.2em 0.2em 0;
            width: 250px;
            color: Black;
            z-index: 9999 !important;
        }

        select {
            color: Black !important;
        }
    </style>
    <style>
        .col-md-12 {
            -ms-flex: 0 0 100%;
            flex: 0 0 100%;
            max-width: 100%;
            padding-right: inherit;
            padding-left: inherit;
        }
    </style>


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <section class="innerpages">
                <div class="container">

                    <div class="page-wrapper tabs">
                        <div class="content container-fluid">
                            <div class="row">
                                <div class="col-md-12">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb">
                                            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                                            <li class="breadcrumb-item">Department</li>
                                            <li class="breadcrumb-item">Reports</li>
                                            <li class="breadcrumb-item active" aria-current="page">RENEWAL Department Wise Report</li>
                                        </ol>
                                    </nav>
                                    <section class="innerpages">
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <h3>RENEWAL Department Wise Report</h3>
                                                    <div class="card">
                                                        <div class="card-body justify-content-center " align="justify">
                                                            <%--  <div class="row">--%>
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading" style="text-align: center">
                                                                    <h2 id="H1" runat="server" class="panel-title" style="font-weight: bold;">
                                                                        <asp:Label ID="lblHeading" runat="server" Visible="false"></asp:Label>
                                                                        <asp:ImageButton ID="btnPdf" runat="server" ImageUrl="../../assets/admin/img/pdf-icon.png" Width="30px" Height="30px" Style="float: right" alt="PDF" />
                                                                        <asp:ImageButton ID="btnExcel" runat="server" ImageUrl="../../assets/admin/img/Excel-icon.png" Width="30px" Height="30px" Style="float: right" alt="EXCEL" /></h2>


                                                                </div>
                                                                <div class="col-md-12 d-flex justify-content-center align-items-center">
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label class="col-lg-6 col-form-label">Department :</label>
                                                                            <div class="col-lg-8 d-flex">
                                                                                <asp:DropDownList ID="ddldepartment" runat="server" class=" form-control" AutoPostBack="true">
                                                                                    <asp:ListItem Value="0">--ALL--</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
                                                                        <div class="form-group">
                                                                            <label class="col-lg-5 col-form-label">From Date:</label>
                                                                            <div class="col-lg-7 d-flex">
                                                                                <asp:TextBox runat="server" ID="txtFormDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFormDate"></cc1:CalendarExtender>
                                                                                <i class="fi fi-rr-calendar-lines"></i>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4">
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
                                                                        <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="Submit" ValidationGroup="Search" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                                                    </div>
                                                                </div>


                                                                <div id="divPrint1" runat="server" visible="false">
                                                                    <asp:GridView ID="GVRENReport" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD;" ForeColor="#333333"
                                                                        GridLines="Both" ShowFooter="true" Font-Bold="true" OnRowDataBound="GVRENReport_RowDataBound"
                                                                        Width="100%" EnableModelValidation="True">
                                                                        <AlternatingRowStyle Font-Underline="false" CssClass="text-center" />
                                                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                                        <%--  <itemstyle font-underline="false" horizontalalign="Center" cssclass="text-center" />--%>
                                                                        <RowStyle />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="DepartmentId" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDepartmentid" runat="server" Text='<%#Eval("DEPT_ID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="Department" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50px" HeaderStyle-Width="30px" />

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
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                    </asp:GridView>
                                                                </div>


                                                                <%-- <div id="DivFooter" runat="server">
                                                        <div>
                                                            <div style="font-size: 16px; margin-left: 190px; font-weight: 600; color: black;">
                                                                <asp:Label ID="LBLDATETEXT" runat="server" Text="The Data in the Dashboard is updated on a real time basis. Last update:"></asp:Label><asp:Label ID="LBLDATETIME" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                                                <div>
                                                                    <asp:Label ID="label" runat="server"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <%--  </div>--%>
                                                        </div>
                                                        <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                            <ProgressTemplate>
                                                                <div class="update">
                                                                </div>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </div>
                                                </div>
                                            </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
