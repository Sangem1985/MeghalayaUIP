<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="BusinessRegulation.aspx.cs" Inherits="MeghalayaUIP.BusinessRegulation" %>

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
            <%--   <section class="innerpages">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">--%>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                    <li class="breadcrumb-item">Resource</li>
                    <li class="breadcrumb-item active" aria-current="page">BUSINESS REGULATIONS (ACT/RULES/REGULATIONS/ORDERS)</li>
                </ol>
            </nav>
            <section class="innerpages">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <h3>BUSINESS REGULATIONS (ACT/RULES/REGULATIONS/ORDERS)</h3>
                            <div class="card">
                                <div class="card-body justify-content-center " align="justify">
                                    <div class="col-md-12 ">
                                        <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
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
                                    <div class="row">
                                        <div class="panel-body">
                                            <table cellspacing="0" cellspacing="0" border="1" style="padding: 0; margin: 0;" width="100%">

                                                <tr>
                                                    <td style="text-align: center;">
                                                        <table width="50%">
                                                            <tr>
                                                                <td>
                                                                    <table width="50%">
                                                                        <tr>
                                                                            <td>Draft Regulations</td>
                                                                            <td>Final Regulations
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Panel ID="Panel1" runat="server" BackColor="#FFFFCC" BorderStyle="Inset"
                                                                                    BorderWidth="3" Width="600px">
                                                                                    <marquee direction="up" onmouseover="this.stop()" onmouseout="this.start()"
                                                                                        scrolldelay="150" style="height: 300px;">
                                                                                        <asp:GridView ID="grdDraft" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                                            CssClass="GRD table-hover" ForeColor="#333333" Width="100%" ShowFooter="false">
                                                                                            <rowstyle cssclass="GRDITEM" horizontalalign="left" />
                                                                                            <headerstyle cssclass="GRDHEADER" font-bold="True" forecolor="White" horizontalalign="Center" />
                                                                                            <columns>
                                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="">
                                                                                                    <itemtemplate>
                                                                                                        <%# Container.DataItemIndex + 1%>
                                                                                                    </itemtemplate>
                                                                                                    <headerstyle horizontalalign="Center" />
                                                                                                    <itemstyle width="50px" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="">
                                                                                                    <itemtemplate>
                                                                                                        <asp:LinkButton runat="server" id="linkDraft" Text='<%#Eval("AMMENDMENT_NAME") %>' OnClick="linkDraft_Click"></asp:LinkButton>
                                                                                                    </itemtemplate>
                                                                                                    <itemstyle horizontalalign="left" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Amndmt ID" visible="false">
                                                                                                    <itemtemplate>
                                                                                                        <asp:Label ID="lblAmndmntID" runat="server" Text='<%#Eval("AMMENDMENT_ID") %>'></asp:Label>
                                                                                                        <itemstyle horizontalalign="Center" width="140px" />
                                                                                                    </itemtemplate>
                                                                                                    <itemstyle horizontalalign="Center" width="140px" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Amndmt ID" visible="false">
                                                                                                    <itemtemplate>
                                                                                                        <asp:Label ID="lblDraftPath" runat="server" Text='<%#Eval("LINK") %>'></asp:Label>
                                                                                                        <itemstyle horizontalalign="Center" width="140px" />
                                                                                                    </itemtemplate>
                                                                                                    <itemstyle horizontalalign="Center" width="140px" />
                                                                                                </asp:TemplateField>

                                                                                            </columns>
                                                                                        </asp:GridView>
                                                                                        <%--<asp:Literal ID="lt1" runat="server"></asp:Literal>--%>
                                                                                    </marquee>
                                                                                </asp:Panel>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Panel ID="Panel2" runat="server" BackColor="#FFFFCC" BorderStyle="Inset"
                                                                                    BorderWidth="3" Width="600px">
                                                                                    <marquee direction="up" onmouseover="this.stop()" onmouseout="this.start()"
                                                                                        scrolldelay="150" style="height: 300px;">
                                                                                        <asp:Literal ID="lt2" runat="server"></asp:Literal>
                                                                                    </marquee>
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>

                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="text-align: center; height: 20px"></td>
                                                </tr>
                                                <tr id="ddd" runat="server" visible="false">
                                                    <td style="text-align: center;" colspan="8">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnComments" runat="server" CausesValidation="False" CssClass="btn btn-warning" Height="32px" Text="USER COMMENTS" Width="177px" OnClick="btnComments_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center; height: 30px"></td>
                                                </tr>
                                                <tr runat="server" id="trComments" visible="false">
                                                    <td style="text-align: center; width: 100%" align="center">
                                                        <table cellpadding="4" cellspacing="5" align="center">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">User Name</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtUserName" runat="server" class="form-control txtbox" Height="28px"
                                                                        MaxLength="50" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName"
                                                                        ErrorMessage="Please Enter User Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">District</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px">
                                                                        <asp:ListItem>--District--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDistrict" InitialValue="--District--"
                                                                        ErrorMessage="Please select District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Mobile Number</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtMobileNo" runat="server" class="form-control txtbox" Height="28px" MaxLength="10" TabIndex="0" ToolTip="text" onkeypress="NumberOnly()" ValidationGroup="group" Width="180px"></asp:TextBox>

                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobileNo"
                                                                        ErrorMessage="Please Enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Mail Id</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtEmailId" runat="server" class="form-control txtbox" Height="28px" MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox></td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Department</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlDepartments" runat="server" AutoPostBack="True" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlDepartments_SelectedIndexChanged">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlDepartments" InitialValue="--Select--"
                                                                        ErrorMessage="Please select Department" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Amendment</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlAmendment" runat="server" class="form-control txtbox" Height="33px" Width="180px">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlAmendment" InitialValue="--Select--"
                                                                        ErrorMessage="Please select Amendment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Comments</td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                                    <asp:TextBox ID="txtComments" runat="server" class="form-control txtbox" Height="91px" MaxLength="50" TabIndex="0" TextMode="MultiLine" ValidationGroup="group" Width="500px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtComments"
                                                                        ErrorMessage="Please enter Comments" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" style="text-align: center; height: 20px">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" style="text-align: center">
                                                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-warning" Height="32px" Text="SUBMIT USER COMMENTS" ValidationGroup="group" Width="200px" OnClick="btnSave_Click" />
                                                                    &nbsp;
                                                                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-warning" Height="32px" Text="CLEAR" Width="120px" OnClick="btnClear_Click" />
                                                                </td>

                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center;" align="center">
                                                        <table style="width: 100%">
                                                            <tr id="Tr1" runat="server">
                                                                <td align="center" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle; padding-top: 5px; text-align: center"
                                                                    valign="middle">
                                                                    <asp:Label ID="lblresult" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="11px"
                                                                        ForeColor="Green" Style="position: static"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="Reject">
                                                                <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                                                    valign="middle">
                                                                    <asp:Label ID="lblerrMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="270px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="Close">
                                                                <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                                                    valign="middle">
                                                                    <asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="Red" Width="272px"></asp:Label>

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:HiddenField ID="hdfID" runat="server" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="group" />
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="child" />
                                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        </div>
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
