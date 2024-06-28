<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="MainDashboard.aspx.cs" Inherits="MeghalayaUIP.User.Dashboard.MainDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../assets/admin/css/user.css" rel="stylesheet" />
    
     <nav aria-label="breadcrumb">
        <ol class="breadcrumb d-flex justify-content-between">
            <%--<li class="breadcrumb-item active" aria-current="page">Dashboard</li>--%>
            <li><a href="#"><span class="badge bg-primary text-white fw-bold">Visit Guidance Site</span></a></li>
        </ol>
    </nav>
    <div class="page-wrapper griddesignmulticount">
        <div class="content container-fluid"> 
              <div class="card" id="NoApplications" runat="server" visible="false">
                <div class="card-header d-flex justify-content-between">
                    <h3 class="card-title mt-1"><b>Industries Registered with IMA/MIIPP 2024 </b></h3>
                    <h4 class="card-title mt-1">
                        <label id="Label1" runat="server"></label>

                    </h4>
                </div>
                <div class="card-body">

                    <div class="d-flex justify-content-between" style="background: #e0e4fd; padding: 10px 8px 2px; border-radius: 4px; margin-bottom: 10px;">

                        <h4 style="display: flex; align-items: center;"> <label id="lblunitname" runat="server"></label>, Interested in Starting a New Investment? Get Started</h4>
                        <h4><a href="../PreReg/IndustryRegistration.aspx"><span class="badge rounded-pill bg-dark text-sm p-2" style="font-size: 16px; color: #fff; background: #033260 !important; display: flex; align-items: center;"><i class="fi fi-tr-bullseye-arrow"></i>&nbsp; New Project</span></a></h4>

                    </div>
                    <div class="card item1" style="width: 13rem;">
                        <div class="card-body item">
                            <h5 class="card-title text-black"><a href="#" style="color: #000;">Future</a></h5>
                            <h6 class="card-subtitle mb-2 text-muted">UNIT ID :  <label id="lbunitid" runat="server"></label></h6>
                            <p class="card-subtitle mb-2 text-muted"> <label id="lbltime" runat="server"></label></p>
                            <a href="../PreReg/IndustryRegistration.aspx" class="card-link" style="color: darkblue">Draft</a>

                        </div>
                    </div>
                </div>
            </div>
            <div class="card" id="Applications" runat="server" visible="false">
                 <div class="card-header d-flex justify-content-between">
                    <h4 class="card-title mt-1"><b>Welcome to Dashboard </b></h4>
                    <h4 class="card-title mt-1">
                        <label id="unitname" runat="server"></label>
                    </h4>
                </div>
                
                <div>
                    <div class="col-md-12 d-flex">
                        <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-12 d-flex">
                        <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                            <strong>Warning!</strong>
                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            <br />
                            <asp:HyperLink  ID="hplIndReg" runat="server" Visible="false"></asp:HyperLink>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnPreRegUNITID" runat="server" />
                    <asp:HiddenField ID="hdnPreRegUID" runat="server" />
                    <asp:HiddenField ID="hdnUserID" runat="server" />
                </div>
                <section id="dashboardcount" class="mt-2">
                    <div class="container-fluid">
                        <div class="table-responsive">
                            <asp:GridView ID="gvUserDashboard" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered table-hover" ForeColor="#333333"
                                GridLines="None" Width="100%" EnableModelValidation="True" OnRowDataBound="gvUserDashboard_RowDataBound">
                                <RowStyle />
                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" Height="33px" HorizontalAlign ="Center" />
                                
                                <Columns>
                                    <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="5%">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />--%>
                                    <asp:BoundField HeaderText="Unit ID" DataField="UNITID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" Visible="true" ItemStyle-Width="10%"/>
                                    <asp:BoundField HeaderText="Unit Name" DataField="COMPANYNAME" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" ItemStyle-Width="10%"/>
                                    <asp:BoundField HeaderText="Unit Address" DataField="UNITADDRESS" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="WindowText" ItemStyle-Width="35%"/>
                                    <asp:HyperLinkField ControlStyle-Font-Underline="false" ControlStyle-ForeColor="Black"
                                        FooterStyle-CssClass="text-center" Text="Click Here" HeaderText="Status" ControlStyle-CssClass="btn btn-info btn-sm text-white" ItemStyle-Width="6%" ItemStyle-ForeColor="White" ItemStyle-CssClass="text-white">
                                        <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                        <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                    </asp:HyperLinkField>
                                    
                                </Columns>
                            </asp:GridView>
                        </div>
                 </div>
                </section>
            </div>
        
            </div>
    </div>
</asp:Content>
