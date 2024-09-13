<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="Ammendments.aspx.cs" Inherits="MeghalayaUIP.Dept.Ammendments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Dashboard/DeptDashBoard.aspx">Dashboard</a></li>
            <li class="breadcrumb-item active" aria-current="page">DEPARTMENT AMENDMENTS</li>
        </ol>
    </nav>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="card-header d-flex justify-content-between">
                <h4 class="card-title mt-1"><b>DEPARTMENT AMENDMENTS</b></h4>
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
                        <div class="row" align="center">
                            <div class="col-lg-12">
                                <div class="panel panel-primary">
                                    <div class="panel-body">
                                        <table style="vertical-align: top; text-align: center;" cellpadding="5" cellspacing="10"
                                            width="100%">

                                            <tr id="tramendentype" runat="server">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Regulation Type</td>

                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:DropDownList ID="ddlamendmenttype" runat="server" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlamendmenttype_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="Draft">Draft</asp:ListItem>
                                                        <asp:ListItem Value="Final">Final</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 10px">&nbsp;</td>

                                            </tr>

                                            <tr id="tramendenname" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">Regulation Name</td>

                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:DropDownList ID="ddlAmendment" runat="server" class="form-control txtbox" Height="33px" Width="180px" OnSelectedIndexChanged="ddlAmendment_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 10px">&nbsp;</td>

                                            </tr>

                                            <tr id="tramentext" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="lblammentname" runat="server" Text="Regulation Name"></asp:Label>
                                                </td>

                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtAmendmentName" runat="server" class="form-control txtbox" Width="180px"
                                                        Height="28px" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td align="left" style="width: 10px"></td>

                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:Label ID="lblamendentdate" runat="server" Text="Regulation Date"></asp:Label>
                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:TextBox ID="txtAmendmentDate" runat="server" class="form-control txtbox" Height="28px" Width="180px" MaxLength="40" TabIndex="1" ValidationGroup="group"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txtAmendmentDate"></cc1:CalendarExtender>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="right" style="height: 20px"></td>


                                            </tr>
                                            <tr>
                                                <td align="right" style="text-align: left">
                                                    <asp:Label ID="lblamendentupload" runat="server" Text="Regulation Upload"></asp:Label>
                                                </td>

                                                <td colspan="2" align="left" style="text-align: left">
                                                    <asp:FileUpload ID="fupRegulation" runat="server" CssClass="CS"
                                                        Height="28px" /><font
                                                            color="red"><strong>(Upload only PDF files)</strong></font>

                                                    <%-- <asp:HyperLink ID="lblFileName" runat="server" CssClass="LBLBLACK" Width="165px"
                                        Target="_blank">[lblFileName]</asp:HyperLink>--%>
                                                    <br />
                                                    <asp:Label ID="lblDraftReg" runat="server" Visible="true" Font-Bold="true" Font-Size="Large"></asp:Label>

                                                </td>
                                            </tr>
                                            <tr id="Trdeptamd" runat="server" visible="false">
                                                <td align="right" style="text-align: left">
                                                    <asp:Label ID="Label2" runat="server" Text="Department Comment Upload"></asp:Label>
                                                </td>

                                                <td colspan="2" align="left" style="text-align: left">
                                                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="CS"
                                                        Height="28px" />
                                                    <br />
                                                    <asp:Label ID="Label3" runat="server" Visible="true" Font-Bold="true" Font-Size="Large"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trusercomments" runat="server" visible="false" align="center">
                                                <td colspan="5">
                                                    <asp:GridView Width="100%" ID="gvComments" runat="server" AutoGenerateColumns="false" border="3" CellPadding="4" CellSpacing="1">
                                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle Height="50px" BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSl" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="User Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("[User Name]") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="District Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDistrict" runat="server" Text='<%# Bind("District") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mobile No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("[Mobile No]") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mail Id">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblmailid" runat="server" Text='<%# Bind("[Mail Id]") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Ammendment">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmmendment" runat="server" Text='<%# Bind("[Ammendment]") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="User Comments">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblusrcomm" runat="server" Text='<%# Bind("[User Comments]") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Department Comments">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="lbldeptcoments" runat="server" TextMode="MultiLine" Height="80px" Width="300px"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="comid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblamdid" runat="server" Text='<%# Bind("Comment_Id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="scroll_td" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="right" style="height: 25px"></td>


                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center" style="text-align: center;">


                                                    <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-success"
                                                        Height="28px" TabIndex="10" Text="Submit"
                                                        Width="116px" OnClick="BtnSave3_Click" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                            <asp:Button ID="BTNcLEAR" runat="server" CssClass="btn btn-xs btn-warning"
                                                                                Height="28px" TabIndex="10" Text="Clear"
                                                                                Width="82px" OnClick="BTNcLEAR_Click" />
                                                </td>

                                            </tr>

                                            <tr colspan="4" runat="server" id="Close">
                                                <td align="center" style="padding: 5px; vertical-align: middle; text-align: center"
                                                    valign="middle">
                                                    <asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="Red" Width="272px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center" style="padding: 5px; vertical-align: middle; height: 35px; text-align: left"
                                                    valign="middle">&nbsp; &nbsp;
                                                </td>
                                            </tr>

                                        </table>
                                        <br />
                                        <asp:ValidationSummary ID="vg" runat="server" ForeColor="Green" ShowMessageBox="True"
                                            ShowSummary="False" Style="position: static" ValidationGroup="group" />

                                        <asp:HiddenField ID="hdnDeptid" runat="server" />
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <br />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                        <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



        </div>
    </div>
</asp:Content>
