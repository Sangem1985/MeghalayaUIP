﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="GrievanceDeptProcess.aspx.cs" Inherits="MeghalayaUIP.Dept.Grievance.GrievanceDeptProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper" style="">
        <div class="content container-fluid">
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12 d-flex">
                        <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-12 d-flex">
                        <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                            <strong>Warning!</strong>
                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnUserID" runat="server" />
                    <asp:HiddenField ID="hdnGrvID" runat="server" />

                    <h4>Grievence Department Process</h4>
                    <div class="row">
                        <div class="col-md-12 d-flex">
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label class="col-lg-6 col-form-label">
                                        Industry Name:</label>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblindustry" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label class="col-lg-6 col-form-label">
                                        UID No:</label>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblUID" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 d-flex">
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label class="col-lg-6 col-form-label">
                                        Name:</label>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label class="col-lg-6 col-form-label">
                                        Email:</label>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-12 d-flex">
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label class="col-lg-6 col-form-label">
                                        Mobile Number:</label>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblNumber" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label class="col-lg-6 col-form-label">
                                        Date:</label>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 d-flex">
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label class="col-lg-6 col-form-label">
                                        District Name:</label>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblDistric" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label class="col-lg-6 col-form-label">
                                        Subject:</label>
                                    <div class="col-lg-6">
                                        <asp:Label ID="lblSubject" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 d-flex">
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label class="col-lg-6 col-form-label">
                                        Attachment:</label>
                                    <div class="col-lg-6">
                                        <asp:HyperLink ID="hplAttach" runat="server" Target="_blank"></asp:HyperLink>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-12 d-flex">
                            <div class="col-md-8">
                                <div class="form-group row">
                                    <label class="col-lg-3 col-form-label">
                                        Description:</label>
                                    <div class="col-lg-9">
                                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="col-md-12 d-flex">
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label class="col-lg-6 col-form-label">Process:*</label>
                                    <div class="col-lg-6 d-flex">
                                        <asp:DropDownList ID="ddlProcess" runat="server" class="form-control">
                                            <asp:ListItem Text="--Select--" Value="0" />
                                            <asp:ListItem Text="Redressed" Value="C"></asp:ListItem>
                                            <asp:ListItem Text="Reject" Value="R"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group row">
                                    <label class="col-lg-6 col-form-label">
                                        Reply File (if any):</label>
                                    <div class="col-lg-6">
                                        <asp:FileUpload ID="fupReplyFile" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 d-flex">
                            <div class="col-md-8">
                                <div class="form-group row">
                                    <label class="col-lg-3 col-form-label">Remarks:* </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtRemarks" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                        </div>
                        <div class="col-md-12 d-flex mt-2" id="padding">

                            <div class="col-md-8 text-center">
                                <asp:Button runat="server" Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click" class="btn btn-rounded btn-info btn-lg" BackColor="Green" Width="150px" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>