<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOPCBWCEDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOPCBWCEDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Pre Establishment</a></li>

                    <li class="breadcrumb-item active" aria-current="page">CTE (Pollution Control Board)</li>
                </ol>
            </nav>
            <div class="page-wrapper" id="divText" runat="server">

                <div class="content container-fluid">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">CTE (Pollution Control Board)</h3>
                                </div>
                                <div class="card-body">
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
                                    <asp:HiddenField ID="hdnUserID" runat="server" />
                                    <asp:HiddenField ID="hdnQuesID" runat="server" />
                                    <div class="row">


                                        <h4 class="card-title ml-3">Water Source Details: </h4>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Source Type *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlsector" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Public Supply" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Irrigation Channel" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Ground" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="River" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Lake" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Bay" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="Estuary" Value="8"></asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Source Name</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Quantity (KLD)</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtQuantity" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4" id="lblstatus" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label"></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtManfAnnualCapacity" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="btnAddLOM" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>
                                        <br />
                                        <%--  <div class="col-md-12 center-gridview">

                                                <div class="col-md-8">
                                                    <asp:GridView ID="gvManufacture" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                        GridLines="Both" Width="100%" EnableModelValidation="True" Visible="false">
                                                        <RowStyle BackColor="#ffffff" />
                                                        <Columns>
                                                            <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Name of Product" DataField="ManfItemName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Annual Manufacturing Capacity (in tonne)" DataField="ManfItemQuantity" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField HeaderText="Appox. value (₹)" DataField="ManfItemValue" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>
                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>
                                                <div class="col-md-4"></div>
                                            </div>--%>



                                        <h4 class="card-title ml-3 mt-3">Average Daily consumption of water:</h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Purpose  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Process" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Washing" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Boiler feed/make up" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Cooling water makeup" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Scrubbers" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="DM plant/regenration" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Greenbelt" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="Domestic" Value="8"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="9"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Quantity*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtRMAnnualCapacity" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        3.Units *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlunits" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="KLD" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="btnaddRM" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>

                                        <%--  <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="gvRwaMaterial" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>


                                        <h4 class="card-title ml-3 mt-3">Waste Water Discharges Details:</h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Source  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Domestic" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Washing" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Scrubbers" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Process Low TDS" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Process High TDS" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Boiler Blow Down" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Cooling bleed off" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="DM plant/regenration/Fresh water R.O. plant rejects" Value="8"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="9"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Quantity*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        3.Units *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList3" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="KLD" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="Button1" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>

                                        <%--  <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>




                                        <h4 class="card-title ml-3 mt-3">Other specific toxic substance is discharged? </h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Source  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList4" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Domestic" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Washing" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Scrubbers" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Process Low TDS" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Process High TDS" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Boiler Blow Down" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Cooling bleed off" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="DM plant/regenration/Fresh water R.O. plant rejects" Value="8"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="9"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        2.Toxic Substance *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList5" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Inorganic" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Organics including Pesticides" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Organic Chlorine Compounds" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Phenol" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Lignin" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Mercaptans" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Heavy Metals" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="8"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4. Quantity</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="Button2" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>

                                        <%-- <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>



                                        <h4 class="card-title ml-3 mt-3">Point of Final Discharge </h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Source  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList6" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Domestic" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Washing" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Scrubbers" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Process Low TDS" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Process High TDS" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Boiler Blow Down" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Cooling bleed off" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="DM plant/regenration/Fresh water R.O. plant rejects" Value="8"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="9"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        2.Point of Discharge</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList7" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Land" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Agricultural Land" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Sewer" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="River" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Lake" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="CETP" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Zero liquid discharge system" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="Sewage Treatment Plant" Value="8"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="9"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="Button3" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>

                                        <%--  <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>

                                        <h4 class="card-title ml-3 mt-3">Physical Characteristics Details </h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Source  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList8" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Domestic" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Washing" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Scrubbers" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Process Low TDS" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Process High TDS" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Boiler Blow Down" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Cooling bleed off" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="DM plant/regenration/Fresh water R.O. plant rejects" Value="8"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="9"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Temperature(degree C):	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox4" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. PH</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox5" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4. Color:	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox6" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">5. Turbidity(JTU/NTU):	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox7" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">6. Odour:	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox8" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">7. Total Solids(mg/L):		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox9" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">8. Total Suspended Solids(mg/L):		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox10" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">9. Total Volatile Solids(mg/L):		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox11" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="Button4" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>

                                        <%-- <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>

                                        <h4 class="card-title ml-3 mt-3">Chemical Characteristics Details </h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Source  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList9" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Domestic" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Washing" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Scrubbers" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Process Low TDS" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Process High TDS" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Boiler Blow Down" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Cooling bleed off" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="DM plant/regenration/Fresh water R.O. plant rejects" Value="8"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="9"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Acidity(mg/L):		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox12" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Alkalinity(mg/L):	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox13" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4. Hardness(ppm):		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox14" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">5. B.O.D.(mg/L):		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox15" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">6. C.O.D.(mg/L):		</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox16" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">7. Oil & Greases(mg/L):			</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox17" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">8. Total Nitrogen Phosphate(mg/L):			</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox18" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">9.Sulphates(mg/L):			</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox19" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">10. Total Phosphates(mg/L):				</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox20" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">11. Total Chloride(mg/L):				</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox21" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">12.Sodium(%):			</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox22" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">13. Potassium(mg/L):					</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox23" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">14. Calcium(mg/L):					</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox24" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">15.Magnesium(mg/L):				</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox25" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>




                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4 offset-md-4 text-center">
                                                <asp:Button ID="Button5" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>

                                        <%--  <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>

                                        <h4 class="card-title ml-3 mt-3">Other Characteristics Details </h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.Source  *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList10" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Domestic" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Washing" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Scrubbers" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Process Low TDS" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Process High TDS" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Boiler Blow Down" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Cooling bleed off" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="DM plant/regenration/Fresh water R.O. plant rejects" Value="8"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="9"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        2.Item *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox28" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">3. Quantity *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="TextBox26" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4. Units</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList11" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Kg/day" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Kg/month" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Tons/day" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Tons/month" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Kl/day" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="Kl/month" Value="6"></asp:ListItem>
                                                            <asp:ListItem Text="Nos./day" Value="7"></asp:ListItem>
                                                            <asp:ListItem Text="Nos./month" Value="8"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4" id="othered" runat="server" visible="true">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label"></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtothers" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <asp:Button ID="Button6" Text="Add Details" runat="server" class="btn btn-rounded btn-green" Width="110px" />
                                            </div>
                                        </div>


                                        <%--  <div class="col-md-12 d-flex ml-3 mb-3">
                                                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                    GridLines="Both"
                                                    Width="100%" EnableModelValidation="True" Visible="false">
                                                    <RowStyle BackColor="#ffffff" />
                                                    <Columns>
                                                        <asp:CommandField HeaderText="Status" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Name of major raw material" DataField="RMName" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Annual manufacturing capacity (in tonne)" DataField="RMAnnualCapacity" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Appox. value (₹ in lakh)" DataField="RMValue" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                        <asp:BoundField HeaderText="Source(s) of supply" DataField="RMSource" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    </Columns>
                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>--%>


                                        <h4 class="card-title ml-3 mt-3">Other Characteristics Details </h4>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">How do you purpose to discharge the waste water:</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlDischarge" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Separate streams" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Combined" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mode of final discharge:	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="DropDownList12" runat="server" class="form-control">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Open Channel" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Pipeline" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Covered drain" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Others" Value="4"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Is any pretreatment necessary for use of water:	</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:RadioButtonList ID="rblwater" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex" id="ENCLOUSER" runat="server" visible="true">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-4 col-form-label">If yes, please enclose a sheet specifying the pretreatment in terms of machinery, process and chemicals used: </label>
                                                    <div class="col-lg-1 d-flex">
                                                        :
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupDetailsSolidWaste" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnDetailsSolidWaste" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypSWPRTD" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 text-right mb-3">

                                             <asp:Button ID="btnPrevious" runat="server" Text="Previous" class="btn btn-rounded btn-info btn-lg" Width="150px" OnClick="btnPrevious_Click" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" runat="server" Text="Next" class="btn btn-rounded btn-info btn-lg" Width="150px" OnClick="btnNext_Click" />

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
