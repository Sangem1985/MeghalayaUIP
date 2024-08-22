<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="CentralInspectionDashboard.aspx.cs" Inherits="MeghalayaUIP.CentralInspectionDashboard" %>

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
                                    <li class="breadcrumb-item active" aria-current="page">CENTRAL INSPECTION SYSTEM</li>
                                </ol>
                            </nav>
                            <section class="innerpages">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-md-12">


                                            <h3>CENTRAL INSPECTION SYSTEM</h3>
                                            <div class="card">
                                                <div class="card-body justify-content-center " align="justify">
                                                    <div class="row">
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">YEAR :</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlYear" runat="server" class="form-control" AutoPostBack="true"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">MONTH : </label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlMonth" runat="server" class="form-control" AutoPostBack="true"></asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Inspection Date :</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:TextBox runat="server" ID="txtInspectionDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" AutoPostBack="true" />
                                                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtInspectionDate"></cc1:CalendarExtender>
                                                                        <i class="fi fi-rr-calendar-lines"></i>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="col-md-12 float-left ">
                                                            <div class="form-group row justify-content-center" style="padding: 20px">
                                                                <asp:Button ID="btnSearch" runat="server" Text="Search" ValidationGroup="SUBMIT" OnClick="btnSearch_Click" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <asp:GridView ID="GVInspection" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                                BorderStyle="Solid" BorderWidth="1px" CssClass="table-bordered table-hover" ForeColor="#333333"
                                                                GridLines="Both" Width="100%" EnableModelValidation="True" OnRowDataBound="GVInspection_RowDataBound"
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
                                                                    <asp:TemplateField HeaderText="DeptId" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDeptid" runat="server" Text='<%#Eval("TMD_DEPTID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="TMD_DEPTNAME" HeaderText="Department Name" ItemStyle-HorizontalAlign="Left" />
                                                                    <%--   <asp:TemplateField HeaderText="Department Name">
                                                                        <ItemTemplate>
                                                                           <asp:LinkButton runat="server" ID="lblDeptName" Text='<%#Eval("TMD_DEPTNAME") %>'  />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Scheduled Inspections">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lblInspection" Text='<%#Eval("INSPSCHEDULED") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Inspections Conducted">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lblConducted" Text='<%#Eval("INSPDONE") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Pending Inspections">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lblPendingInspection" Text='<%#Eval("INSPPENDING") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Uploaded Within 48Hrs">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lblReportWithin" Text='<%#Eval("INSPDONEWITHIN48HRS") %>' />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Report Uploaded Beyond 48Hrs">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" ID="lblBeyonReport" Text='<%#Eval("INSPDONEBEYOND48HRS") %>' />
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
                                                        <%--  <h2>The data in the dashboard is updated on a real time basis</h2>--%>
                                                    </div>
                                                    <div id="DivFooter" runat="server">
                                                        <div>
                                                            <div style="font-size: 16px; margin-left: 190px; font-weight: 600; color: black;">
                                                                <asp:Label ID="LBLDATETEXT" runat="server" Text="The Data in the Dashboard is updated on a real time basis. Last update:"></asp:Label><asp:Label ID="LBLDATETIME" runat="server"></asp:Label>
                                                            </div>
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
