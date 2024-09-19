<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="CommentsonAmmendments.aspx.cs" Inherits="MeghalayaUIP.CommentsonAmmendments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <%--<section class="innerpages">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">--%>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                    <li class="breadcrumb-item"></li>
                    <li class="breadcrumb-item active" aria-current="page"></li>
                </ol>
            </nav>
            <%--<section class="innerpages">--%>
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="auto-style1">Comments on Draft Ammendments</h4>
                            </div>
                            <div class="card-body">
                                <table style="width: 100%; padding-top: 5px">
                                    <tr>
                                        <td style="width: 250px; border: 2px solid">
                                            <asp:Panel runat="server" ID="Panel2">
                                                <table style="text-align: center; width: 100%" align="center">
                                                    <tr runat="server" id="trComments" visible="false">
                                                        <td>
                                                            <table cellpadding="4" cellspacing="5" align="center">
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Department:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                                        <asp:Label runat="server" ID="lblDepatname"></asp:Label>
                                                                        <br />
                                                                        <asp:Label runat="server" ID="lblDeptID" Visible="false"></asp:Label>
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Amendment:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                                        <asp:Label runat="server" ID="lblAmendment"></asp:Label>
                                                                        <asp:Label runat="server" ID="lblAmendmentID" Visible="false"></asp:Label>
                                                                    </td>

                                                                </tr>
                                                                <tr>

                                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 150px">User Name:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtUserName" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="50" TabIndex="1" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName"
                                                                            ErrorMessage="Please Enter User Name" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">District:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                            Height="33px" Width="180px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDistrict"
                                                                            InitialValue="0" ErrorMessage="Please select District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Mobile No.:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                        <asp:TextBox ID="txtMobileNo" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="10" TabIndex="0" ToolTip="text" onkeypress="NumberOnly()" ValidationGroup="group"
                                                                            Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobileNo"
                                                                            ErrorMessage="Please Enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Mail Id:</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEmailId" runat="server" class="form-control txtbox" Height="28px"
                                                                            MaxLength="50" TabIndex="0" ToolTip="text" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmailId"
                                                                            ErrorMessage="Please Enter Mobile Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Comments:
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="4">
                                                                        <asp:TextBox ID="txtComments" runat="server" class="form-control txtbox" Height="91px"
                                                                            TabIndex="0" TextMode="MultiLine" ValidationGroup="group" Width="500px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding: 5px; margin: 5px">
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtComments"
                                                                            ErrorMessage="Please enter Comments" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" style="text-align: center; height: 20px">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" style="text-align: center">
                                                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Height="40px"
                                                                            OnClick="btnSave_Click" Text="Submit Comments" ValidationGroup="group" Width="200px" />
                                                                        &nbsp;
                                                                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-warning" Height="40px"
                                                                                    OnClick="btnClear_Click" Text="Clear" Width="120px" />
                                                                    </td>
                                                                    <%--  <td colspan="4" style="text-align: center">&nbsp;</td>--%>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" style="text-align: center">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" style="text-align: center">
                                                                        <asp:Button ID="btnviewcomments" runat="server" CssClass="btn btn-info" Height="40px"
                                                                            OnClick="btnviewcomments_Click" Text="View Public Comments" Width="200px" />
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
                                                                        <%--<a target="_blank" style="font-family: fantasy; font-size: larger; font-weight: bold; font-style: normal; color: #8B0000; text-underline-position: auto">AAAA</a>--%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <%--</asp:Panel>--%>
                                        </td>
                                        <td style="width: 500px; border: 2px solid">
                                            <asp:Panel runat="server" ID="Panel1">
                                                <iframe runat="server" id="IframePanel" width="500px" height="700px"></iframe>
                                            </asp:Panel>
                                        </td>
                                        <%--<td>
                                                            <asp:Label runat="server" Width="50px" ID="lblwidth" Visible="false"></asp:Label>
                                                        </td>--%>
                                    </tr>
                                </table>
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grdComments" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px"  CssClass="GRD table-bordered table-striped table-sm" ForeColor="#333333"
                                                GridLines="None"  AlternatingRowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Wrap="true"
                                                Width="135%" EnableModelValidation="True" Visible="false">
                                                <HeaderStyle BackColor="#3366cc" />
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl.No." HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20px" >
                                                        <ItemTemplate >
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="User Name" DataField="USERNAME" ItemStyle-Width="100px"  ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText"  />
                                                    <asp:BoundField HeaderText="District" DataField="DistrictName" ItemStyle-Width="100px"  ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Mobile No." DataField="MOBILENO" ItemStyle-Width="60px"  ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText"  />
                                                    <asp:BoundField HeaderText="Mail Id" DataField="MAILID" ItemStyle-Width="80px"  ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Comments" DataField="COMMENTS" ItemStyle-Width="200px"  ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="White" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Comments Date" DataField="CREATEDDATE" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="80px"  ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" />
                                                
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--</section>--%>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
