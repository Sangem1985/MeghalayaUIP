<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="HelpdeskDrilldown.aspx.cs" Inherits="MeghalayaUIP.Admin.HelpdeskDrilldown" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="card-header d-flex justify-content-between">
                        <h4 class="card-title mt-1"><b>Help Desk Report:</b></h4>
                        <div class="col-md-1">
                            <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" OnClick="lbtnBack_Click" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
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

                                                    <div class="col-md-12 d-flex justify-content-center align-items-center">

                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="col-lg-6 col-form-label">From Date:</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtFormDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtFormDate"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="col-lg-6 col-form-label">To Date: </label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:TextBox runat="server" ID="txtToDate" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                                                    <i class="fi fi-rr-calendar-lines"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <asp:GridView ID="GVHelpdesk" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD;" ForeColor="#333333"
                                                        GridLines="Both" ShowFooter="true"
                                                        Width="100%" OnRowDataBound="GVHelpdesk_RowDataBound" EnableModelValidation="True">
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
                                                            <%-- <asp:BoundField DataField="int_fbid" HeaderText="Helpdesk ID" />--%>
                                                            <%-- <asp:BoundField DataField="HelpDeskID" HeaderText="Helpdesk ID" HeaderStyle-Width="10px" />--%>
                                                              <asp:TemplateField HeaderText="ID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblHelpDeskID" runat="server" Text='<%# Eval("HelpDeskID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                            <asp:BoundField DataField="HD_CREATEDBYUSERNAME" HeaderText="Reference No" />

                                                            <%--  <asp:TemplateField HeaderText="Uid NO">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lbluid" Text='<%#Eval("HD_UIDNO") %>' />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="Uid NO" HeaderStyle-Width="20px">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hypUIDNO" Target="_blank" Text='<%# Eval("HD_UIDNO") %>' runat="server"></asp:HyperLink>
                                                                   <%-- NavigateUrl='<%# Eval("TrackerUrl") %>'--%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>                                                           
                                                            <asp:BoundField DataField="HD_UNITNAME" HeaderText="Unit Name" HeaderStyle-Width="20px" />
                                                            <asp:BoundField DataField="HD_HELPDESKTYPE" HeaderText="Feedback Type" HeaderStyle-Width="20px"></asp:BoundField>
                                                            <asp:BoundField DataField="HD_HELPDESKDESCRIPTION" HeaderText="User change Request/ Comments" HeaderStyle-Width="20px">
                                                                <HeaderStyle HorizontalAlign="Left" Width="300px"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
                                                                <ControlStyle Width="450px" />
                                                            </asp:BoundField>

                                                            <asp:TemplateField HeaderText="Uploaded Document">
                                                                <ItemTemplate>
                                                                    <%--    <asp:LinkButton runat="server" ID="lblCommApproved" Text='<%#Eval("") %>' />--%>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>



                                                            <asp:BoundField DataField="HD_STATUS" HeaderText="Status" HeaderStyle-Width="20px">
                                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="HD_REDRESSEDREMARKES" HeaderText="Remarks" HeaderStyle-Width="20px"></asp:BoundField>
                                                            <asp:BoundField DataField="HD_CREATEDATE" HeaderText="HelpDesk RaiseDate " HeaderStyle-Width="20px">
                                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100px"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="HD_REDRESSEDDATE" HeaderText="Date of Closure" HeaderStyle-Width="20px" />


                                                            <asp:TemplateField HeaderText="Change Status">
                                                                <ItemTemplate>
                                                                    <table style="width: 100px" cellspacing="0" cellpadding="2" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="text-align: left" align="left">
                                                                                    <asp:DropDownList ID="ddlchStatus" runat="server" Width="152px" CssClass="DROPDOWN"
                                                                                        ValidationGroup="group">
                                                                                        <asp:ListItem>Closed</asp:ListItem>
                                                                                        <asp:ListItem>Rejected</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="Pending" runat="server">
                                                                                <td style="text-align: left" align="left">
                                                                                    <asp:TextBox ID="txtremarks" TabIndex="1" runat="server" Width="300px" CssClass="TXTBOX"
                                                                                        ValidationGroup="group" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                          <%-- <%-- <tr>
                                                                                <td style="text-align: left" align="left">
                                                                                    <asp:DropDownList ID="ddltypeprob" runat="server" Width="152px" CssClass="DROPDOWN"
                                                                                        ValidationGroup="group">
                                                                                        <asp:ListItem>Select</asp:ListItem>
                                                                                        <asp:ListItem>Application Problem</asp:ListItem>
                                                                                        <asp:ListItem>General Enquiry</asp:ListItem>
                                                                                        <asp:ListItem>Data Correction</asp:ListItem>
                                                                                        <asp:ListItem>Other</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ControlToValidate="ddltypeprob"
                                                                        ErrorMessage="Please Select Type of Problem" InitialValue="Select" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>--%>
                                                                            <tr id="Close" runat="server">
                                                                                <td style="padding-bottom: 5px; padding-top: 5px; text-align: center">&nbsp;<asp:Button ID="BtnSave" TabIndex="10" runat="server"
                                                                                    Width="122px" Text="Change Status" OnClick="BtnSave_Click" CssClass="BUTTONLONG" ValidationGroup="group"
                                                                                    ToolTip="To Save  the data" Height="30px"></asp:Button>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="300px"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="anothermailid" Visible="False" />

                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>

                                                    <asp:GridView ID="grdExport" runat="server" AutoGenerateColumns="true" ShowFooter="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                                HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="text-center" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle Wrap="true" />
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
