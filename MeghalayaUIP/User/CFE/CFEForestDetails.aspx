<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEForestDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEForestDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function handleKeyUp(input) {
            if (input.value.trim() === "") {
                input.style.border = "2px solid red";
            } else {
                input.style.border = "1px solid #767575b5";
            }
        }
        function validateDropdown(dropdown) {

            if (dropdown.value === "0") {
                dropdown.style.border = "2px solid red";
                dropdown.focus();
            } else {
                dropdown.style.border = "1px solid #767575b5";
            }
        }
        function validateRadioButtonList(radioGroupContainer) {
            // Find all radio buttons inside the container
            const radioButtons = radioGroupContainer.querySelectorAll('input[type="radio"]');

            // Check if any radio button is selected
            const isSelected = Array.from(radioButtons).some(radio => radio.checked);

            if (!isSelected) {
                // If none are selected, apply red border
                radioGroupContainer.style.border = "2px solid red";
                radioGroupContainer.querySelector('input[type="radio"]').focus(); // Set focus to the first radio button
            } else {
                // Reset the border if an option is selected
                var id = radioGroupContainer.id;
                document.getElementById(id).style.border = "1px solid #767575b5";
                return false;
            }
        }
    </script>
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb mb-0">
                    <li class="breadcrumb-item"><a href="../Dashboard/Dashboarddrill.aspx">Dashboard</a></li>
                    <li class="breadcrumb-item"><a href="CFEUserDashboard.aspx">Pre Establishment</a></li>

                    <li class="breadcrumb-item active" aria-current="page">Forest Details</li>
                </ol>
            </nav>
            <div class="page-wrapper" id="divText" runat="server">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">Forest Details</h3>
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
                                    <div class="row">
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1. Forest Division</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlForest" runat="server" class="form-control" onchange="validateDropdown(this)">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2. Type of Land*</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddlLandType" runat="server" class="form-control" onchange="validateRadioButtonList(radioGroupContainer)">
                                                            <asp:ListItem Text="--Select--" Value="0" />
                                                            <asp:ListItem Text="Government Land" Value="Government Land" />
                                                            <asp:ListItem Text="Private Land" Value="Private Land" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="divDistanceLetter" runat="server" visible="false" class="row">
                                            <h4 class="card-title ml-3">Application Form For Letter For Distance From Forest- GPS Coordinates Details</h4>

                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-7 col-form-label">1. GPS Coordinates Latitude*</label>
                                                        <div class="col-lg-5 d-flex">
                                                            <asp:RadioButtonList ID="RblLatitude" runat="server" RepeatDirection="Horizontal" onchange="validateRadioButtonList(radioGroupContainer)">
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
                                                        <label class="col-lg-6 col-form-label">1a. Degrees(L)*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLatDegrees" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="5" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1b. Minutes(L) *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLatMinutes" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="5" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1c. Seconds(L)*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLatSeconds" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="5" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-7 col-form-label">2. GPS Coordinates Longitude*</label>
                                                        <div class="col-lg-5 d-flex">
                                                            <asp:RadioButtonList ID="rblLongitude" runat="server" RepeatDirection="Horizontal" onchange="validateRadioButtonList(radioGroupContainer)">
                                                                <asp:ListItem Text="E" Value="E" />
                                                                <asp:ListItem Text="W" Value="W" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2a. Degrees*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLongDegrees" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="5" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2b. Minutes*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLongMinutes" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="5" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2c. Seconds*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLongSeconds" runat="server" class="form-control" onkeypress="return NumberOnly()" MaxLength="6" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. GPS Coordinates (Description) *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtGPSCordinates" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4. Purpose of Application  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtDistncLtrPurpose" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">5. Any other information *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtInformation" runat="server" class="form-control" onkeypress="return Names()" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                            </div>
                                        </div>
                                        <div id="divNonForestLand" runat="server" visible="false" class="row">
                                            <h4 class="card-title ml-3">Application Form For Non-Forest Land Certificate</h4>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Area of Land in Ha *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLandArea" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)" MaxLength="50" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2. Purpose Non-Forest land Certificate sought *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtNFLPurpose" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divTreeFelling" runat="server" visible="false" class="row">
                                            <h4 class="card-title ml-3">Application Form For Tree Felling Permission</h4>
                                            <div class="col-md-12 d-flex">

                                                <div class="col-md-6">
                                                    <div class="form-group row">
                                                        <label class="col-lg-4 col-form-label">1. Type of Permission  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:CheckBoxList ID="chkPermType" AutoPostBack="true" runat="server" OnSelectedIndexChanged="chkPermType_SelectedIndexChanged">
                                                                <asp:ListItem Text="Lopping of branches" Value="Lopping of branches" />
                                                                <asp:ListItem Text="Cutting of trees" Value="Cutting of trees" />
                                                            </asp:CheckBoxList>
                                                            <%--<asp:CheckBox ID="chkLopping" runat="server" Text="Lopping of branches" Value="Lopping of branches"></asp:CheckBox><br />
                                                            <asp:CheckBox ID="chkFelling" runat="server" Text="Cutting of trees" Value="Cutting of trees"></asp:CheckBox>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" id="divLopped" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3">Details of trees whose branches are to be Lopped</h4>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Purpose for Lopping/Cutting of Branches  *</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLoppingPurpose" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">a. Local Name*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLopLocName" runat="server" class="form-control"   TabIndex="1" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">
                                                            b.Scientific Name*
                                                        </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLopScfName" runat="server" class="form-control" TabIndex="1" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">c. Number Of trees*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtLopTreeCount" runat="server" class="form-control"   ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label"></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="btnAddLopp" Text="Add Details" class="btn btn-rounded btn-green" runat="server" OnClick="btnAddLopp_Click" Width="110px" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <div class="table-responsive mx-auto">
                                                    <asp:GridView ID="grdLopped" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="GRD mx-auto" ForeColor="#333333" Width="90%" ShowFooter="true">
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
                                                            <asp:BoundField DataField="CFELP_LOCALNAME" HeaderText="Local Name">
                                                                <ItemStyle Width="180px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CFELP_SCIENTIFICNAME" HeaderText="Scientific Name">
                                                                <ItemStyle Width="180px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CFELP_NOOFTREES" HeaderText="Number Of trees">
                                                                <ItemStyle Width="180px" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row" id="divFelled" runat="server" visible="false">
                                            <div class="col-md-12 d-flex">
                                                <h4 class="card-title ml-3">Details Of Trees to be felled</h4>
                                               
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Purpose for felling of trees * </label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtFellingPurpose" runat="server" class="form-control" TabIndex="1" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1. Local Name*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtFellLocName" runat="server" class="form-control"  TabIndex="1" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2.Scientific Name*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtFellScfName" runat="server" class="form-control"  TabIndex="1" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3. Number Of trees*</label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:TextBox ID="txtFellTreeCount" runat="server" class="form-control"  TabIndex="1" ></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex justify-content-center">
                                                <div class="col-md-4">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label"></label>
                                                        <div class="col-lg-6 d-flex">
                                                            <asp:Button ID="btnAddFell" Text="Add Details" class="btn btn-rounded btn-green" runat="server" OnClick="btnAddFell_Click" Width="110px" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="table-responsive mx-auto">
                                                    <asp:GridView ID="grdFelled" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        CssClass="GRD mx-auto" ForeColor="#333333" Width="90%" ShowFooter="true">
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
                                                            <asp:BoundField DataField="CFEFL_LOCALNAME" HeaderText="Local Name">
                                                                <ItemStyle Width="180px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CFEFL_SCIENTIFICNAME" HeaderText="Scientific Name">
                                                                <ItemStyle Width="180px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CFEFL_NOOFTREES" HeaderText="Number Of trees">
                                                                <ItemStyle Width="180px" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="row">
                                            <h4 class="card-title ml-3">Upload Documents</h4>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">1.Proof of ownership of land (Lease deed or Agreement of Sale or any related document) *</label>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="fupOwnership" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="btnownership" OnClick="btnownership_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="hypownership" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Label ID="lblownership" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">2.Rough map of the concerned land *</label>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="fupland" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="btnland" OnClick="btnland_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="hypland" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Label ID="lblland" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">3.NoC from the concerned Autonomous District Council for land use *</label>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="fupNOCLand" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="btnNOCLand" OnClick="btnNOCLand_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="hypNOCLand" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Label ID="lblnocland" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-12 d-flex">
                                                <div class="col-md-12">
                                                    <div class="form-group row">
                                                        <label class="col-lg-6 col-form-label">4.Distance from Forest Certificate from DFO (Wild-life) *</label>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:FileUpload ID="fupForestDFO" runat="server" />
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Button Text="Upload" runat="server" ID="btnforestdfo" OnClick="btnforestdfo_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                        </div>
                                                        <div class="col-lg-2 d-flex">
                                                            <asp:HyperLink ID="hypforestdfo" runat="server" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                        <div class="col-lg-1 d-flex">
                                                            <asp:Label ID="lblforestdfo" runat="server" />
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
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnownership" />
            <asp:PostBackTrigger ControlID="btnland" />
            <asp:PostBackTrigger ControlID="btnNOCLand" />
            <asp:PostBackTrigger ControlID="btnforestdfo" />
            <%--  <asp:PostBackTrigger ControlID="btnLic" />
            <asp:PostBackTrigger ControlID="btnElectrical" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
