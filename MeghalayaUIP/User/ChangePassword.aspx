﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="MeghalayaUIP.User.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="card-header d-flex justify-content-between">
                        <h4 class="card-title mt-1"><b>Change Password</b></h4>
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
                                                    width="50%">

                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">User Name</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtusername" runat="server" class="form-control txtbox" Width="180px"
                                                                Height="28px" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Old Password</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtoldpassword" runat="server" class="form-control txtbox" Width="180px"
                                                                Height="28px" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">New Password</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtnewpassword" runat="server" class="form-control txtbox" Width="180px"
                                                                Height="28px" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">Confirm Password</td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox ID="txtconfirmpassword" runat="server" class="form-control txtbox" Width="180px"
                                                                Height="28px" MaxLength="200" TabIndex="1"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:TextBox runat="server" ID="txtcaptcha" class="form-control" placeholder="Captcha"></asp:TextBox>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Image ID="imgCaptcha" runat="server" BackColor="#0066ff" ForeColor="#0099ff" draggable="false" Height="35px" Width="100px" />
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:ImageButton ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" AlternateText="Refresh" ImageUrl="~/assets/assetsnew/images/Refresh.jpg" Height="35px" Width="40px" />
                                                        </td>

                                                    </tr>

                                                    <tr>
                                                        <td colspan="3" align="right" style="height: 25px"></td>


                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" align="center" style="text-align: center;">


                                                            <asp:Button ID="BtnSave3" runat="server" CssClass="btn btn-xs btn-success"
                                                                Height="40px" TabIndex="10" Text="Submit" OnClick="BtnSave3_Click"
                                                                Width="116px" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                            <asp:Button ID="BTNcLEAR" runat="server" CssClass="btn btn-xs btn-warning"
                                                                                Height="40px" Text="Clear"
                                                                                Width="82px" />
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