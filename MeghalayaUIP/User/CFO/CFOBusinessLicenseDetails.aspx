﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOBusinessLicenseDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOBusinessLicenseDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">CFO POLLUTION CONTROL BOARD</h4>
                        </div>
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
                            <div class="row">
                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Establishment Details</span></label>
                                </div>
                                <div class="col-md-12 d-flex">

                                    <%--<div class="col-md-8">
												<div class="form-group row">
													<label class="col-lg-6 col-form-label">Address of the establishment, from where it is to be conducted *</label>
													<div class="col-lg-3 d-flex">
														<asp:TextBox ID="txtEstDet" runat="server" class="form-control"></asp:TextBox>
													</div>
												</div>
											</div>--%>
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Date of Establishment  *</label>
                                            <div class="col-lg-3 d-flex">
                                                <asp:TextBox ID="txtaddress" runat="server" class="form-control" Type="Date"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-4 col-form-label fw-bold"><span style="font-weight: 900;">Select Location of Stall  *</span></label>
                                            <div class="col-lg-8">
                                                <asp:RadioButtonList ID="rblBusiness" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblBusiness_SelectedIndexChanged">
                                                    <asp:ListItem Text="Private owned establishment" Value="1" />
                                                    <asp:ListItem Text="Municipal owned shop/establishment" Value="2" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex" id="stall" runat="server" visible="false">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Holding Number *</label>
                                            <div class="col-lg-3 d-flex">
                                                <asp:TextBox ID="txtHolding" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Market Name  *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlDistric" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex" id="Districmaster" runat="server" visible="false">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">District of Establishment *</label>
                                            <div class="col-lg-3 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlESTDistric" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Stall number *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtstall" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label fw-bold"><span style="font-weight: 900;">Whether the applicant is doing any business in Shillong Municipality during the previous 5 (five) years?  *</span></label>
                                            <div class="col-lg-4">
                                                <asp:RadioButtonList ID="rblmunicipality" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblmunicipality_SelectedIndexChanged">
                                                    <asp:ListItem Text="Yes" Value="1" />
                                                    <asp:ListItem Text="No" Value="2" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" id="Municipality" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Details(if Yes)  *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtDetails" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Nature of Business</span></label>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Annual Gross Turnover (Rs in Lakhs) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlAnnual" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Nature of Business (Main Category) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlNature" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Nature of Business (Sub Category) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList runat="server" ID="ddlBusiness" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Fees *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtFees" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex justify-content-center">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label"></label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:Button ID="btnAdd" Text="Add Details" class="btn  btn-info btn-lg" runat="server" OnClick="btnAdd_Click" Fore-Color="White" BackColor="YellowGreen" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex justify-content-center">
                                    <asp:GridView ID="GVPollution" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                        GridLines="None"
                                        Width="100%" EnableModelValidation="True" Visible="false">
                                        <RowStyle BackColor="#ffffff" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Nature of Business (Main Category)" DataField="CFOBN_MAINCATEGORY" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Nature of Business (Sub Category)" DataField="CFOBN_SUBCATEGORY" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                            <asp:BoundField HeaderText="Fees" DataField="CFOBN_FEE" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Total Amount *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtAmount" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex mt-2">
                                    <div class="col-md-6">

                                        <asp:Button Text="Previous" runat="server" ID="btnPreviuos" OnClick="btnPreviuos_Click" class="btn  btn-info btn-lg" />
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-rounded btn-info btn-lg" padding-right="10px" BackColor="Green" />


                                        <asp:Button ID="btnNext" Text="Next" runat="server" class="btn  btn-info btn-lg" />

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