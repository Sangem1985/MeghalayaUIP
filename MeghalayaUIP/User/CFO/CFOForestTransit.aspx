<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFOForestTransit.aspx.cs" Inherits="MeghalayaUIP.User.CFO.CFOForestTransit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
        //let originalValue = "";
        function handleKeyUp(input) {
            if (input.value.trim() === "") {
                input.style.border = "2px solid red";
            }
            else {
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="page-wrapper">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">CFO Forest Transit Permit Details</h3>
                                </div>
                                <div class="card-body">
                                    <!-- <h4 class="card-title">Personal Information</h4> -->
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

                                    <div class="row" id="divText" runat="server">
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">1) Forest Permit Details: </h4>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        1. Permit NO.</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtpermitno" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">2) Details of the person / entity to whom permit is granted: </h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        1.Name:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names()" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Identity card and Number:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtIdentity" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Email:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtemail" runat="server" class="form-control"  TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        4.Address:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtowneraddress" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        5.Mobile No:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Name of Produce:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtproduce" runat="server" class="form-control" onkeypress="return Names()" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">3) Details of Species / Produce: Timber / Poles / Charcoal / Minor Forest Produce / Mineral: </h4>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Name of Specie:</label>
                                                    <div class="col-lg-6">
                                                        <asp:DropDownList ID="ddlSpeciesName" runat="server" class="form-control"
                                                            Height="30px" Width="185px">
                                                            <asp:ListItem Text="--Select Speice--" Value="-1"></asp:ListItem>
                                                            <asp:ListItem Text="Timber" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Poles" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Charcoal" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Minor Forest Produce" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Mineral" Value="5"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Log Number:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLogNumber" runat="server" class="form-control"  TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Girth(cm)</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtGirth" runat="server" class="form-control"  TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Length(cm):</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtLength" runat="server" class="form-control"  TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Volume (cum) / Weight (kg):</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtVolumeWeight" runat="server" class="form-control"  TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">

                                                    <div class="col-lg-6">
                                                        <asp:Button ID="btnAddlogs" runat="server" CssClass="btn btn-rounded btn-info btn-lg" Text="Add" OnClick="BtnAddlogs_Click"/>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <asp:GridView ID="gvLogs" runat="server" AutoGenerateColumns="False"
                                                BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                CssClass="GRD" ForeColor="#333333" GridLines="Both"
                                                Width="100%" OnRowDeleting="GvLogs_RowDeleting"
                                                DataKeyNames="SlNo" EnableModelValidation="True">

                                                <RowStyle BackColor="#ffffff" />

                                                <Columns>
                                                    <asp:BoundField DataField="SlNo" HeaderText="Sl No."
                                                        ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="SpeciesName" HeaderText="Name of Species"
                                                        ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="LogNumber" HeaderText="Log Number"
                                                        ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="Girth" HeaderText="Girth (cm)"
                                                        ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="Length" HeaderText="Length (cm)"
                                                        ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="VolumeOrWeight" HeaderText="Volume (cum) / Weight (kg)"
                                                        ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />

                                                    <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                    <asp:CommandField HeaderText="DELETE" ControlStyle-ForeColor="Red"
                                                        ControlStyle-Font-Bold="true" DeleteText="DELETE" ShowDeleteButton="True" />
                                                </Columns>

                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#013161" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>

                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">4) Route(s) by which timber of indicated species / produces will be transported : </h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Enter State:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtState" runat="server" class="form-control"
                                                            Height="28px" Width="180px"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Enter Barrier:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtBarriers" runat="server" class="form-control"  TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">

                                                    <div class="col-lg-6">
                                                        <asp:Button ID="btnAddBarrier" runat="server" CssClass="btn btn-rounded btn-info btn-lg" Text="Add" OnClick="BtnAddBarrier_Click"/>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <asp:GridView ID="gvBarriers" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD"
                                                DataKeyNames="SlNo" ForeColor="#333333" OnRowDeleting="GvBarriers_RowDeleting"
                                                GridLines="Both" Width="100%" EnableModelValidation="True">

                                                <RowStyle BackColor="#ffffff" />

                                                <Columns>
                                                    <asp:BoundField DataField="SlNo" HeaderText="Sl No."
                                                        ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="State" HeaderText="State"
                                                        ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="Barriers" HeaderText="Barriers"
                                                        ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />

                                                    <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                    <asp:CommandField HeaderText="DELETE" ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
                                                </Columns>

                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#013161" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">5) Driver & Vehicle Details:</h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <!-- Vehicle Type -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Type of Vehicle with Registration Number:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtVehicleType" runat="server" class="form-control" TabIndex="8"
                                                             onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Driver Name -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Name of the Driver:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtDriverName" runat="server" class="form-control" TabIndex="1"
                                                            onkeypress="return Names()" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Driver License Number -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Driving License No.:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtDriverLicense" runat="server" class="form-control" TabIndex="1"
                                                             onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">6) Where Obtained:</h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <!-- Compartment No. -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Compartment No.:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtCompartmentNo" runat="server" class="form-control" TabIndex="1"
                                                           onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Circle -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Circle:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtCircleWhereObtained" runat="server" class="form-control" TabIndex="6"
                                                             onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Division -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Division:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtDivisionWhereObtained" runat="server" class="form-control" TabIndex="7"
                                                             onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <!-- Range -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Range:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtRangeWhereObtained" runat="server" class="form-control" TabIndex="8"
                                                             onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Address -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Address:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtAddressWhereObtained" runat="server" class="form-control" TabIndex="9"
                                                            onkeypress="return Names()" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">7) Destination:</h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <!-- State -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        State:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtstateDestination" runat="server" class="form-control" TabIndex="5"
                                                             onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Circle -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Circle:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtdestCircle" runat="server" class="form-control" TabIndex="1"
                                                             onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Division -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Division:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtdestDivision" runat="server" class="form-control" TabIndex="2"
                                                            onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <!-- Range -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Range:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtdestRange" runat="server" class="form-control" TabIndex="3"
                                                             onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Address -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        Address:
                                                    </label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtdestAddress" runat="server" class="form-control" TabIndex="4"
                                                             onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">8) Permit Information:</h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <!-- Date of Issue -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of Issue:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtDateOfIssue" runat="server" class="form-control" MaxLength="10"
                                                            TabIndex="10"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="calDateOfIssue" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateOfIssue"></cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Date of Expiry of Permit -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Date of Expiry of Permit:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtDateOfExpiryOfPermit" runat="server" class="form-control" MaxLength="10"
                                                            TabIndex="11"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="calDateOfExpiryOfPermit" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateOfExpiryOfPermit"></cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Imprint of Transit Mark -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Imprint of Transit Mark:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtImprintOfTransitMark" runat="server" class="form-control" MaxLength="50" TabIndex="12"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <h4 class="card-title ml-3">9) Details Of Authority Issuing the Permit:</h4>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <!-- Designation of Official -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Designation of Official:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtDesignationOfOfficial" runat="server" class="form-control" MaxLength="50" TabIndex="13"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Office Address -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Office Address:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtOfficeAddress" runat="server" class="form-control" MaxLength="100" TabIndex="14"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- Official Telephone No. / Mobile No. -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Official Telephone No. / Mobile No:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtOfficialTelephoneMobile" runat="server" class="form-control" MaxLength="15" TabIndex="15"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <!-- Official Email -->
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Official Email:</label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtOfficialEmail" runat="server" class="form-control" MaxLength="50" TabIndex="16"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 text-right mb-3">

                                            <asp:Button ID="btnPrevious" runat="server" Text="Previous"  class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-success btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

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
