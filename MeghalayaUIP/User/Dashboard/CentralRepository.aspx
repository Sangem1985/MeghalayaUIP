<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CentralRepository.aspx.cs" Inherits="MeghalayaUIP.User.Dashboard.CentralRepository" UnobtrusiveValidationMode="None"  EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function openPdf(filePath) {
            var url = '<%= ResolveUrl("/User/Dashboard/ServePdfFile.ashx?filePath=") %>' + encodeURIComponent(filePath);
            window.open(url, '_blank');
        }
</script>

    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="CentralRepository.aspx">Central Repository</a></li>
            <%--<li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Pre Establishment</a></li>
            --%>
            <li class="breadcrumb-item active" aria-current="page">Central Repository</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Central Repository</h4>
                        </div>
                        <div class="card-body">
                            <div class="col-md-12 justify-content-center d-flex">
                                <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                                    <strong>Success!</strong>
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 justify-content-center d-flex">
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                                    <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                            <div class="row">
                                <div class="col-md-12 d-flex">
                                    <h4 class="card-title ml-3">
                                        <asp:Label ID="LabelHeading" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                            Width="199px"></asp:Label></h4>
                                </div>
                                <div class="col-md-12 d-flex">

                                    <div class="col-md-3">
                                        <div class="form-group row">
                                            <label class="col-lg-7 col-form-label">Application Category<span style="color: red;">*</span> </label>
                                            <div class="col-lg-5 d-flex">
                                                <asp:DropDownList ID="ddlModule" runat="server" class="form-control"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group row">
                                            <label class="col-lg-7 col-form-label">Select Department <span style="color: red;">*</span></label>
                                            <div class="col-lg-5 d-flex">
                                                <asp:DropDownList ID="ddldept" runat="server" class="form-control txtbox"
                                                    TabIndex="1">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>                                               
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="form-group row">
                                            <label class="col-md-5 col-form-label">
                                                From Date<span style="color: red;">*</span></label>
                                            <div class="col-lg-7 d-flex">
                                                <asp:TextBox ID="txtFDate" runat="server" class="date form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtFDate" runat="server" ControlToValidate="txtFDate"
                                                    Display="None" ErrorMessage="Please Select module"  ForeColor="Red"
                                                    ValidationGroup="Search" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <%-- <input type="date" id="txtFDate" runat="server" class="date form-control" />
                                                <i class="fi fi-rr-calendar-lines"></i>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group row">
                                            <label class="col-md-5 col-form-label">
                                                To Date<span style="color: red;">*</span></label>
                                            <div class="col-lg-7 d-flex">
                                                <asp:TextBox ID="txtTDate" runat="server" class="date form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtTDate" runat="server" ControlToValidate="txtTDate"
                                                    Display="None" ErrorMessage="Please Select module"  ForeColor="Red"
                                                    ValidationGroup="Search" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <%-- <input type="date" id="txtTDate" runat="server" class="date form-control" />
                                                <i class="fi fi-rr-calendar-lines"></i>--%>
                                            </div>
                                        </div>
                                    </div>

                                </div>


                            </div>
                            <div class="row">
                                <div class="col-md-12 float-end">
                                    <div class="form-group row justify-content-center">
                                        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" ValidationGroup="Search" CssClass="btn btn-md btn-success" Width="150px" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" id="divgrd" runat="server" visible="false">
                <div class="col-md-12">

                    <div class="card">
                        <div class="card-body">
                            <div class="col-md-12 justify-content-center d-flex">

                                <asp:GridView ID="grdCentralRepo" runat="server" AutoGenerateColumns="false" 
                                    ShowFooter="false" OnRowCommand="grdCentralRepo_RowCommand" CssClass="table table-bordered table-striped">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No." HeaderStyle-BackColor="#650855">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DEPTNAME" HeaderStyle-BackColor="#650855" HeaderText="Department Name" />
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="View" HeaderStyle-BackColor="#650855" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpath" runat="server" Text='<%# Bind("FILEPATH") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="View" HeaderStyle-BackColor="#650855">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfilename" runat="server" Text='<%# Bind("FILENAME") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="FILEDESCRIPTION" HeaderStyle-BackColor="#650855" HeaderText="File Description" />
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="View" HeaderStyle-BackColor="#650855">
                                            <ItemTemplate>
                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="ViewFile" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-sm btn-success" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </div>


                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
