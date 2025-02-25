<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="ApplicationsView.aspx.cs" Inherits="MeghalayaUIP.Admin.ApplicationsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>


    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
            <li class="breadcrumb-item">Department</li>
            <li class="breadcrumb-item active" aria-current="page">Applications View</li>
        </ol>
    </nav>
    <style>
       
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="card-header d-flex justify-content-between">
                        <h4 class="card-title mt-1"><b>Application View:</b></h4>
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

                                    <div class="panel panel-primary">
                                        <div class="panel-body">
                                            <div class="card-body justify-content-center">

                                                <div class="panel panel-default">

                                                    <div class="col-md-12 d-flex justify-content-center align-items-center">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="col-lg-12 col-form-label">Type of Application :</label>
                                                                <div class="col-lg-12 d-flex">
                                                                    <asp:DropDownList ID="ddlTypeApplication" runat="server" aria-label="Default select example" class="form-control" Style="width: 100%; height: 32px;">
                                                                        <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="1">USERREG</asp:ListItem>
                                                                        <asp:ListItem Value="2">INDUSTRY</asp:ListItem>
                                                                        <asp:ListItem Value="3">CFE</asp:ListItem>
                                                                        <asp:ListItem Value="4">CFO</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="col-lg-12 col-form-label">Enter Invester Id: </label>
                                                                <div class="col-lg-12 d-flex">
                                                                    <input type="text" id="txtInvester" runat="server" class="form-control" name="input" onkeypress="return PhoneNumberOnly(event)" maxlength="5" tabindex="1" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="col-lg-12 col-form-label">Enter Name of Unit:</label>
                                                                <div class="col-lg-12 d-flex">
                                                                    <input type="text" id="txtUnitName" runat="server" class="form-control" name="input" maxlength="50" onkeypress="return Names()" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>

                                                    <div class="col-md-12 d-flex justify-content-center">
                                                    </div>
                                                    <div class="col-md-12 float-left ">
                                                        <div class="form-group row justify-content-center" style="padding: 20px">
                                                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-info btn-submit" Width="120px" OnClick="btnsubmit_Click" />
                                                        </div>
                                                    </div>
                                                    <div id="User" runat="server" visible="false">
                                                        <asp:GridView ID="GVUser" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD;" ForeColor="#333333"
                                                            GridLines="Both" ShowFooter="true"
                                                            Width="100%" EnableModelValidation="True">
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <AlternatingRowStyle BackColor="LightGray" Font-Bold="true" />
                                                            <RowStyle Height="40px" BorderColor="Blue" Font-Bold="true" />
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="INVESTER" HeaderText="Invester ID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="FULLNAME" HeaderText=" Name" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="EMAILID" HeaderText="Email ID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="PASSWORD" HeaderText="Password" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="MOBILENO" HeaderText="Mobile No" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="CREATEDDATE" HeaderText="Created Date" ItemStyle-HorizontalAlign="Left" />


                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>

                                                    <div id="Industry" runat="server" visible="false">
                                                        <asp:GridView ID="GVIndustry" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD;" ForeColor="#333333"
                                                            GridLines="Both" ShowFooter="true"
                                                            Width="100%" EnableModelValidation="True">
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <AlternatingRowStyle BackColor="LightGray" Font-Bold="true" />
                                                            <RowStyle Height="40px" BorderColor="Blue" Font-Bold="true" />
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="UNITID" HeaderText="Unit ID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="INVESTERID" HeaderText="Invester ID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="COMPANYNAME" HeaderText="Company Name" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="EMAILID" HeaderText="Email ID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="DATEOFENTRY" HeaderText="Date Of Entery" ItemStyle-HorizontalAlign="Left" />



                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>

                                                    <div id="CFE" runat="server" visible="false">
                                                        <asp:GridView ID="GVCFE" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD;" ForeColor="#333333"
                                                            GridLines="Both" ShowFooter="true"
                                                            Width="100%" EnableModelValidation="True">
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <AlternatingRowStyle BackColor="LightGray" Font-Bold="true" />
                                                            <RowStyle Height="40px" BorderColor="Blue" Font-Bold="true" />
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="CFEQD_UNITID" HeaderText="Unit ID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="INVESTERID" HeaderText="Invester ID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="CFEQD_COMPANYNAME" HeaderText="Company Name" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="EMAILID" HeaderText="Email ID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="DATEOFENTRY" HeaderText="Date" ItemStyle-HorizontalAlign="Left" />


                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>

                                                    <div id="CFO" runat="server" visible="false">
                                                        <asp:GridView ID="GVCFO" runat="server" AutoGenerateColumns="False" BorderColor="#003399" ShowHeaderWhenEmpty="true"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="table-bordered mb-0 GRD;" ForeColor="#333333"
                                                            GridLines="Both" ShowFooter="true"
                                                            Width="100%" EnableModelValidation="True">
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <AlternatingRowStyle BackColor="LightGray" Font-Bold="true" />
                                                            <RowStyle Height="40px" BorderColor="Blue" Font-Bold="true" />
                                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" BorderColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SI.No" ItemStyle-Width="3%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField DataField="CFOQD_UNITID" HeaderText="Unit ID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="INVESTERID" HeaderText="Invester ID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="CFOQD_COMPANYNAME" HeaderText="Company Name" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="EMAILID" HeaderText="Email ID" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="DATEOFENTRY" HeaderText="Date" ItemStyle-HorizontalAlign="Left" />


                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>


                                                </div>
                                                <div>
                                                    <asp:Label ID="label" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </section>
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
