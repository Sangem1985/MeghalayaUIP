<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/User/user.Master" CodeBehind="SMSandMAILtesting.aspx.cs" Inherits="MeghalayaUIP.Admin.SMSandMAILtesting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="card-header d-flex justify-content-between">
                        <h4 class="card-title mt-1"><b>Sms And MailTesting</b></h4>
                        <div class="col-md-1">
                            <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                            <asp:HiddenField runat="server" ID="asp_hidden" />
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
                                                <table style="vertical-align: top; margin-left: 0;" cellpadding="5" cellspacing="10"
                                                    width="50%">

                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 180px">Name</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 180px">
                                                            <%--  <asp:TexteBox ID="txtusername" runat="server" class="form-control txtbox" Width="180px" 
                                                                Height="28px" MaxLength="200" TabIndex="1" onblur="validateEmail(event)" ></asp:TexteBox>--%>

                                                            <asp:TextBox ID="txtname" runat="server" class="form-control txtbox" Width="180px"
                                                                Height="28px" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Company Name</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtCompanyName" runat="server" class="form-control txtbox" Width="180px"
                                                                Height="28px" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Investor ID</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtInvestorID" runat="server" class="form-control txtbox" Width="180px"
                                                                Height="28px" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Unit ID</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtUnitID" runat="server" class="form-control txtbox" Width="180px"
                                                                Height="28px" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </td>
                                                    </tr>




                                                    <tr>
                                                        <td colspan="3" align="right" style="height: 25px"></td>


                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="center" style="text-align: center;">


                                                            <asp:Button ID="BtnReg" runat="server" CssClass="btn btn-xs btn-success"
                                                                Height="40px" TabIndex="10" Text="User Reg" OnClick="BtnReg_Click"
                                                                Width="120px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                            <asp:Button ID="btnPrereg" runat="server" CssClass="btn btn-xs btn-warning"
                                                                                Height="40px" Text="Industry Reg" OnClick="btnPrereg_Click"
                                                                                Width="120px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                            <asp:Button ID="btnCFE" runat="server" CssClass="btn btn-xs btn-approved "
                                                                                Height="40px" Text="CFE Reg" OnClick="btnCFE_Click"
                                                                                Width="120px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                            <asp:Button ID="btnCFO" runat="server" CssClass="btn btn-xs btn-edit"
                                                                                Height="40px" Text="CFO Reg" OnClick="btnCFO_Click"
                                                                                Width="120px" />
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="center" style="text-align: center;">
                                                            <asp:Button ID="btnIntent" runat="server" CssClass="btn btn-xs btn-success"
                                                                Height="40px" TabIndex="10" Text="Intent Invest" OnClick="btnIntent_Click"
                                                                Width="120px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                            <asp:Button ID="btnPreRegApprove" runat="server" CssClass="btn btn-xs btn-warning"
                                                                                Height="40px" Text="PreReg Approve" OnClick="btnPreRegApprove_Click"
                                                                                Width="120px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                            <asp:Button ID="btnCFEApprove" runat="server" CssClass="btn btn-xs btn-approved "
                                                                                Height="40px" Text="CFE Approve" OnClick="btnCFEApprove_Click"
                                                                                Width="120px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                            <asp:Button ID="btnCFOApprove" runat="server" CssClass="btn btn-xs btn-edit"
                                                                                Height="40px" Text="CFO Approve" OnClick="btnCFOApprove_Click"
                                                                                Width="120px" />
                                                        </td>

                                                    </tr>

                                                    <tr>
                                                        <td colspan="3" align="center" style="text-align: center;">


                                                            <%--  <asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-success"
                                                                Height="40px" TabIndex="10" Text="User Reg" OnClick="BtnReg_Click"
                                                                Width="120px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; --%>
                                                            <asp:Button ID="btnQueryID" runat="server" CssClass="btn btn-xs btn-warning"
                                                                Height="40px" Text="Industry Reg Query" OnClick="btnQueryID_Click"
                                                                Width="120px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                            <asp:Button ID="btnQueryCFE" runat="server" CssClass="btn btn-xs btn-approved "
                                                                                Height="40px" Text="CFE Reg Query" OnClick="btnQueryCFE_Click"
                                                                                Width="120px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                            <asp:Button ID="btnQueryCFO" runat="server" CssClass="btn btn-xs btn-edit"
                                                                                Height="40px" Text="CFO Reg Query" OnClick="btnQueryCFO_Click"
                                                                                Width="120px" />
                                                        </td>

                                                    </tr>

                                                </table>
                                                <br />
                                                <asp:ValidationSummary ID="vg" runat="server" ForeColor="Green" ShowMessageBox="True"
                                                    ShowSummary="False" Style="position: static" ValidationGroup="group" />

                                                <asp:HiddenField ID="hdfID" runat="server" />
                                                <br />
                                                <asp:HiddenField ID="hdfFlagID" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
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
