<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="IRDistWiseReport.aspx.cs" Inherits="MeghalayaUIP.Dept.Reports.IRDistWiseReport" %>

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
                                    <li class="breadcrumb-item">Department</li>
                                    <li class="breadcrumb-item active" aria-current="page">DistrictWiseReports</li>
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

                                            <h3>District Wise Reports</h3>
                                            <div class="card">
                                                <div class="card-body justify-content-center " align="justify">
                                                    <div class="row">
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">District :</label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddldistrict" runat="server" class=" form-control" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged" AutoPostBack="true">
                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 col-form-label">Type of Enterprise : </label>
                                                                    <div class="col-lg-12 d-flex">
                                                                        <asp:DropDownList ID="ddlEnterPriseType" runat="server" class=" form-control">
                                                                            <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
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

                                                        <div class="col-md-12 d-flex">

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
                                                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" ValidationGroup="Search" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                                            </div>
                                                        </div>

                                                        <asp:GridView ID="GVDistrictWise" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD" ForeColor="#333333"
                                                            GridLines="None" OnRowDataBound="GVDistrictWise_RowDataBound" ShowFooter="true"
                                                            Width="100%" EnableModelValidation="True">
                                                            <RowStyle />
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
                                                   <%-- <div id="DivFooter" runat="server">
                                                        <div>
                                                            <div style="font-size: 16px; margin-left: 190px; font-weight: 600; color: black;">
                                                                <asp:Label ID="LBLDATETEXT" runat="server" Text="The Data in the Dashboard is updated on a real time basis. Last update:"></asp:Label><asp:Label ID="LBLDATETIME" runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                                </div>
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
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
