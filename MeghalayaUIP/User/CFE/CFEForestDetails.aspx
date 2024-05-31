<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEForestDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEForestDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
            <li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Pre Establishment</a></li>

            <li class="breadcrumb-item active" aria-current="page">Forest Details</li>
        </ol>
    </nav>
    <div class="page-wrapper">
        <div class="content container-fluid">

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">Forest Details</h3>
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


                                <h4 class="card-title ml-3">GPS Coordinates Details</h4>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-8">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Establishment Location Address (For which application is being Done)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtAddress" runat="server" class="form-control" onkeypress="return validateNameAndNumbersandspace(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%--<h5 class="col-lg-4 col-form-label">2 GPS Coordinates</h5>--%>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. GPS Coordinates Latitude*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:RadioButtonList ID="RblLatitude" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="N" Value="N" />
                                                    <asp:ListItem Text="S" Value="S" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">a. Degrees(L)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLatDegrees" runat="server" class="form-control" onkeypress="return NumberOnly()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">b. Minutes(L) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLatMinutes" runat="server" class="form-control" onkeypress="return NumberOnly()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">c. Seconds(L)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLatSeconds" runat="server" class="form-control" onkeypress="return NumberOnly()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">d. Longitude*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:RadioButtonList ID="rblLongitude" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="E" Value="E" />
                                                    <asp:ListItem Text="W" Value="W" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">e. Degrees*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLongDegrees" runat="server" class="form-control" onkeypress="return NumberOnly()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">f. Minutes*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLongMinutes" runat="server" class="form-control" onkeypress="return NumberOnly()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">g. Seconds*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLongSeconds" runat="server" class="form-control" onkeypress="return NumberOnly()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. GPS Coordinates (Description) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtGPSCordinates" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4. Purpose of Application  *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPurpose" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">5. Forest Division</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlForest" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">6. Any other information *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtInformation" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">A) Forest</span></label>

                                </div>

                                <%--  <h5 class="card-title ml-4">A) Forest</h5>--%>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Species*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtspecies" runat="server" class="form-control" onkeypress="return Names()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. Estimated Length Of Timber (in Meters)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtTimberlength" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. Estimated Volume Of Timber (in Meters)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtTimberVolume" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4. Girth (in Meters)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtGirth" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">5. Estimated Firewood/Rootwood/Faggot*	</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEstimated" runat="server" class="form-control" onkeypress="return validateNumberAndDot(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">6. No. of Pole's*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtpole" runat="server" class="form-control" onkeypress="return NumberOnly()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="grdApprovals" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            CssClass="GRD" ForeColor="#333333" Width="90%" ShowFooter="true">
                                            <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Dept_Name" HeaderText="Species">
                                                    <ItemStyle Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Dept_Name" HeaderText="Timber Length">
                                                    <ItemStyle Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Dept_Name" HeaderText="Timber Volume">
                                                    <ItemStyle Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Dept_Name" HeaderText="Timber Girth">
                                                    <ItemStyle Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Dept_Name" HeaderText="Estimated Firewood">
                                                    <ItemStyle Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Dept_Name" HeaderText="pole">
                                                    <ItemStyle Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ApprovalName" HeaderText="Actions ">
                                                    <ItemStyle Width="450px" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>


                                <div class="col-md-12 d-flex">
                                    <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">B) Boundary Description</span></label>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. North*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtNorth" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. East*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEast" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">3. West*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtWest" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4. South*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtSouth" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>

                                        </div>

                                    </div>

                                </div>

                                <div class="col-md-12 d-flex">
                                    <br />
                                </div>
                                <div class="col-md-12 text-right">

                                    <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
