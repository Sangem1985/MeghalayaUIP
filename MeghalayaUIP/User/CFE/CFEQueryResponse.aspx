<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEQueryResponse.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEQueryResponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <%--  <section class="comp-section">--%>
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Pre-Establishment Query Details</h4>
                            <p style="position: absolute; right: 10px; top: 6px; color: red;">
                                *All Fields Are Mandatory
                            </p>
                        </div>
                        <div class="card-body">
                            <asp:HiddenField runat="server" ID="hdnUserID" />
                            <asp:HiddenField runat="server" ID="hdnRmTypeId" />
                            <div class="tab-content">
                                <div class="tab-pane show active" id="basictab1">
                                    <div class="card-body">
                                        <%--<h4 class="card-title"></h4>--%>
                                        <div class="row">
                                            <div class="col-md-12 d-flex justify-content-center text-center">
                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="javascript:void(0);" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                    <strong>Success!</strong>
                                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </div>
                                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                    <a href="javascript:void(0);" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                    <strong>Warning!</strong>
                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Unit Name</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <spna class="dots">:</spna><asp:Label runat="server" ID="lblUnitName"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">Approval Name</label>
                                                        <div class="col-lg-8 d-flex">
                                                            <spna class="dots">:</spna><asp:Label runat="server" ID="lblApprovalName"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Query raised by</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <spna class="dots">:</spna><asp:Label runat="server" ID="lblQueryBy"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-8">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">Query raise date</label>
                                                        <div class="col-lg-8 d-flex">
                                                            <spna class="dots">:</spna><asp:Label runat="server" ID="lblQueryRaisedDate"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-2 col-form-label">Query Description</label>
                                                    <div class="col-lg-10 d-flex">
                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="lblQueryDescription"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-2 col-form-label">Query Response</label>
                                                    <div class="col-lg-10 d-flex">
                                                        <spna class="dots">:</spna><asp:TextBox runat="server" class="form-control" Style="height: 100px; width: 800px; resize: vertical;" TextMode="MultiLine" ID="txtQueryResponse" placeholder="Enter Query Response" name="QueryResponse" />
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">Response Attachment</label>

                                                    <div class="col-lg-1 d-flex">: </div>
                                                    <div class="col-lg-3 d-flex">
                                                        <asp:FileUpload runat="server" ID="fupAttachment" Width="300px" Font-Italic="true" BorderColor="Tomato" Height="45px" padding-right="10px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:Button runat="server" ID="btnUpldAttachment" Text="Upload" OnClick="btnUpldAttachment_Click" class="btn btn-dark btn-rounded" Height="40px" Width="110px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hplAttachment" runat="server" Target="_blank" ForeColor="Black"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="container">
                                                <div class="row" id="divDetails" runat="server" visible="false">
                                                    <div class="col-md-12 d-flex justify-content-center">
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">UnitID:</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label runat="server" ID="lblUnitId"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">QueryID:</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label runat="server" ID="lblQryid"></asp:Label>
                                                                    <asp:Label runat="server" ID="lblQuesID"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">ApprovalID:</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label runat="server" ID="lblApprovalID"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">DeptID:</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <asp:Label runat="server" ID="lblDeptID"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <div class="text-center">
                                                    <asp:GridView ID="gvCertificate" runat="server" AutoGenerateColumns="False"
                                                        BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                                                        CssClass="GRD" ForeColor="Black" GridLines="Both" Width="50%" BackColor="LightGoldenrodYellow">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="View"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblfilepath" runat="server" Text='<%# Bind("filepath") %>' Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="Tan" />
                                                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                            <br />
                                            <div class="container">
                                                <div class="row">
                                                    <div class="col-md-12 d-flex justify-content-center">
                                                        <div>
                                                            <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Style="width: 130px;" CssClass="btn btn-success btn-submit" Text="Submit" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--   </section>--%>
    </div>
</asp:Content>
