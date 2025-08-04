<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFETrackerDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFETrackerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        div#basictab1 {
    margin-top: -12px;
    margin-left: -48px;
}
        hr {
    margin-left: 15px;
}
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <%--<li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Pre Establishment</a></li>
            --%>
            <li class="breadcrumb-item active" aria-current="page">CFE Track Details</li>
        </ol>
    </nav>

             <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">CFE Track Details</h4>
                        </div>
                        <div class="card-body">
                                    <asp:HiddenField runat="server" ID="hdnUserID" />
                                    <asp:HiddenField runat="server" ID="hdnRmTypeId" />
                                    <div class="tab-content">
                                        <div class="tab-pane show active" id="basictab1">
                                            <div class="card-body">
                                                <%--<h4 class="card-title"></h4>--%>
                                                <div class="row">
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
                                                     <div class="col-md-12">
                                                    <div id="div1" runat="server" visible="true" class="mt-3">
                                                        <div class="card-head ml-3">
                                                            <h4 class="card-title">Date of Payment Details:</h4>
                                                        </div>
                                                        <hr />
                                                        <div class="col-md-12 d-flex mt-1">
                                                            <div class="col-md-5">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">1) Department Name</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="Label2"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2"></div>
                                                            <div class="col-md-5">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">2) Query Raised Date</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="Label3"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-5">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">3) Query</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="Label4"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-2"></div>
                                                            <div class="col-md-5">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">4) Query Response Date</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="Label5"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                         <div class="col-md-12 d-flex">
                                                        <div class="col-md-5">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">5) No of Days Taken</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <spna class="dots">:</spna><asp:Label runat="server" ID="Label6"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                             <div class="col-md-2"></div>
                                                        <div class="col-md-5">
                                                            <div class="form-group row">
                                                                <label class="col-lg-6 col-form-label">6) Query Response</label>
                                                                <div class="col-lg-6 d-flex">
                                                                    <spna class="dots">:</spna><asp:Label runat="server" ID="Label7"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        </div>
                                                    </div>
                                                    
                                                    <div id="divQueryDetails" runat="server" visible="true" class="mt-3">
                                                        <div class="card-header">
                                                            <h4 class="card-title">Query Details</h4>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">1) Department Name</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="lblDept"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-4 col-form-label">2) Query Raised Date</label>
                                                                    <div class="col-lg-8 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="lblQueryDate"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">3) Query</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="lblQuery"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-8">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-4 col-form-label">4) Query Response Date</label>
                                                                    <div class="col-lg-8 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="lblQueryResponseDate"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <div class="form-group row">
                                                                <label class="col-lg-2 col-form-label">5) No of Days Taken</label>
                                                                <div class="col-lg-10 d-flex">
                                                                    <spna class="dots">:</spna><asp:Label runat="server" ID="lblDaysTaken"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <div class="form-group row">
                                                                <label class="col-lg-2 col-form-label">6) Query Response</label>
                                                                <div class="col-lg-10 d-flex">
                                                                    <spna class="dots">:</spna><asp:Label runat="server" ID="lblQueryResponse"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 d-flex justify-content-center">
                                                            <div class="text-center">
                                                                <asp:GridView ID="GVQueryDet" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" OnRowDataBound="GVQueryDet_RowDataBound"
                                                                    GridLines="Both" HeaderStyle-BackColor="Red"
                                                                    Width="100%" EnableModelValidation="True">
                                                                    <RowStyle />
                                                                    <AlternatingRowStyle BackColor="LightGray" />
                                                                    <HeaderStyle BackColor="Red" />
                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="10px">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Attachment Name" DataField="CFEA_FILEDESCRIPTION" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                                        <asp:TemplateField HeaderText="View">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="linkAttachment" Text='<%#Eval("CFEA_FILENAME")%>' runat="server"></asp:HyperLink>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="View" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFilePath" Text='<%#Eval("CFEA_FILEPATH")%>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div align="center" style="text-align: center; padding: 20px;">
                                                                            <b>No Records Found</b>
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    

                                                    <div id="divReject" runat="server" visible="true" class="mt-3">
                                                        <div class="card-header">
                                                            <h4 class="card-title">Rejected Details</h4>
                                                        </div>
                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">1) Department Name</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="lblDeptNameReject"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-4 col-form-label">2) Rejected Date</label>
                                                                    <div class="col-lg-8 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="lblRejDate"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex">
                                                            <div class="col-md-4">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-6 col-form-label">3) Rejection Remarks</label>
                                                                    <div class="col-lg-6 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="lblRejRemark"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-8">
                                                                <div class="form-group row">
                                                                    <label class="col-lg-4 col-form-label">4) Appeal Remarks</label>
                                                                    <div class="col-lg-8 d-flex">
                                                                        <spna class="dots">:</spna><asp:Label runat="server" ID="lblRejAppealRemark"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <div class="form-group row">
                                                                <label class="col-lg-2 col-form-label">5) Appeal Date</label>
                                                                <div class="col-lg-10 d-flex">
                                                                    <spna class="dots">:</spna><asp:Label runat="server" ID="lblRejAppealDate"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <div class="form-group row">
                                                                <label class="col-lg-2 col-form-label">6) Query Response</label>
                                                                <div class="col-lg-10 d-flex">
                                                                    <spna class="dots">:</spna><asp:Label runat="server" ID="lblRejQueryReason"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12 d-flex justify-content-center">
                                                            <div class="text-center">
                                                                <asp:GridView ID="GVReject" runat="server" AutoGenerateColumns="False"
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
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
