<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="IndustryRegistrationQueryDetails.aspx.cs" Inherits="MeghalayaUIP.User.PreReg.IndustryRegistrationQueryDetails" %>

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
                            <h4 class="card-title">Query Reasons</h4>
                            <p style="position: absolute; right: 10px; top: 6px; color: red;">
                                *All Fields Are
										Mandatory
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
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Application Number</label>
                                            <div class="col-lg-6 d-flex"><spna class="dots">:</spna><asp:Label runat="server" ID="lblRmId"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Unit Name</label>
                                            <div class="col-lg-6 d-flex"><spna class="dots">:</spna><asp:Label runat="server" ID="lblUnitName"></asp:Label></div>
                                        </div>
                                    </div>
                                    
                                     </div>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Query raised by</label>
                                            <div class="col-lg-6 d-flex"><spna class="dots">:</spna><asp:Label runat="server" ID="lblQueryRaised"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Query raise date</label>
                                            <div class="col-lg-6 d-flex"><spna class="dots">:</spna><asp:Label runat="server" ID="lblQueryRaisedDate"></asp:Label></div>
                                        </div>
                                    </div>
                                    
                                     </div>
                                            <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label">Query Description</label>
                                            <div class="col-lg-9 d-flex"><spna class="dots">:</spna><asp:Label runat="server" ID="lblQueryDescription"></asp:Label></div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group row">
                                            <label class="col-lg-3 col-form-label">Query Response</label>
                                            <div class="col-lg-9 d-flex"><spna class="dots">:</spna><asp:TextBox runat="server" class="form-control" Style="height: 100px; width: 800px; resize: vertical;" TextMode="MultiLine" ID="txtQueryResponse" placeholder="Enter Query Response" name="QueryResponse" /></div>
                                        </div>
                                    </div>
                                            
                                            <div class="col-md-12 d-flex">
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Response Attachment</label>
                                            <div class="col-lg-6 d-flex"><spna class="dots">:</spna><asp:FileUpload ID="fupResAttachment" runat="server" /></div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group row">
                                            <label class="col-lg-12 col-form-label"><asp:Button ID="btnAttach" runat="server" class="form-control" Text="Attach Files" CssClass="btn btn-green" Width="100px" OnClick="btnAttach_Click" /></label>
                                            <%--<div class="col-lg-6 d-flex"><spna class="dots">:</spna></div>--%>
                                        </div>
                                    </div>
                                    <%--<div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label"></label>
                                            <div class="col-lg-6 d-flex"><spna class="dots">:</spna></div>
                                        </div>
                                    </div>--%>
                                     </div>

                                             
                                              <div class="container">
                                                <div class="row">
                                            <div class="col-md-12 d-flex justify-content-center">
                                                
                                                <div class="col-md-4" id="ddunit" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">UNIDID:</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Label runat="server" ID="lblUnitId"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" id="ddrmid" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">Rmid:</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Label runat="server" ID="lblRid"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" id="ddinsertid" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">insert:</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Label runat="server" ID="lblinsert"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4" id="ddlDEPt" runat="server" visible="false">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">QUERYRAISEDBYDEPTID:</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Label runat="server" ID="lbldept"></asp:Label>
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
                                                    <asp:Button runat="server" ID="btnSubmit" Style="width: 130px;" CssClass="btn btn-success btn-submit" Text="Submit" OnClick="btnSubmit_Click" />
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
