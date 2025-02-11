<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="HelpdeskReport.aspx.cs" Inherits="MeghalayaUIP.Admin.HelpdeskReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
            <li class="breadcrumb-item">Department</li>
            <li class="breadcrumb-item">Help Desk Report</li>
            <li class="breadcrumb-item active" aria-current="page">Help Desk Reports</li>
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
                        <h4 class="card-title mt-1"><b>Help Desk Reports:</b></h4>
                        <div class="col-md-1">
                            <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
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
                                <div class="" align="center">

                                    <div class="panel panel-primary">
                                        <div class="panel-body">
                                            <div class="card-body justify-content-center " align="justify">

                                                <div class="panel panel-default">


                                                    <div class="col-md-12 d-flex">
                                                        <div class="col-md-4">
                                                            <div class="form-group d-flex">
                                                                <label class="col-lg-4 col-form-label">From Date:</label>
                                                                <div class="col-lg-6 ">
                                                                    <asp:TextBox runat="server" ID="txtFormDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFormDate"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group d-flex">
                                                                <label class="col-lg-4 col-form-label">To Date: </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtToDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row justify-content-center" style="padding: 0px">
                                                            <asp:Button ID="btnsubmit" runat="server" Text="Get Data" ValidationGroup="Search" class="btn btn-rounded btn-success btn-lg" Width="150px" OnClick="btnsubmit_Click" />
                                                        </div>
                                                        </div>
                                                    </div>
                                                   

                                                    <div align="center" style="padding: 5px; margin: 5px; width: 60%" id="divPrint" runat="server">
                                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            Width="90%" OnRowDataBound="grdDetails_RowDataBound"
                                                            ShowFooter="false">
                                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex +1 %>
                                                                        <asp:Label ID="lbluid" runat="server" Text='<%# Eval("HD_UIDNO") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="HD_HELPDESKTYPE" HeaderText="Query Type">
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>                                                             

                                                                 <asp:TemplateField HeaderText="Pending">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblPending" Text='<%#Eval("SCOUNT") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                            </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>

                                                    <div align="center" style="padding: 5px; margin: 5px; width: 50%" id="divPrintnew" runat="server" valign="top">
                                                        <asp:GridView ID="grdDetails1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            Width="90%"
                                                            ShowFooter="True">
                                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex +1 %>
                                                                      <%--  <asp:Label ID="lblSOLVED_BY" runat="server" Text='<%# Eval("SOLVED_BY") %>' Visible="false"></asp:Label>--%>

                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                             <%--   <asp:BoundField DataField="User_name" HeaderText="Name">
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>--%>
                                                              
                                                                 <asp:TemplateField HeaderText="Solved">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblSolved" Text='<%#Eval("SOLVEDCOUNT") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>

                                                    <div style="height: 30px">
                                                        <div colspan="2"></div>
                                                    </div>

                                                    <div align="center" style="padding: 5px; margin: 5px" id="Td1" runat="server" colspan="2">
                                                        <asp:GridView ID="grdDetails2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            Width="60%" ShowFooter="True">
                                                            <HeaderStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                            <RowStyle Height="40px" CssClass="GridviewScrollC1Item" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle ForeColor="#FFFFFF" BackColor="#009688" Height="40px" CssClass="GridviewScrollC1Footer" />
                                                            <AlternatingRowStyle Height="40px" CssClass="GridviewScrollC1Item2" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex +1 %>
                                                                        <asp:Label ID="lblintfb_idnew" runat="server" Text='<%# Eval("HD_UIDNO") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="HD_HELPDESKTYPE" HeaderText="Query Type">
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>

                                                                 <asp:TemplateField HeaderText="Total Posted">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblposte" Text='<%#Eval("POSTEDCNT") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Solved">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblSolved" Text='<%#Eval("SOLVEDCOUNT") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Pending">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lblpending" Text='<%#Eval("PENDING") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
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
