<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegDITSiteInspection.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegDITSiteInspection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        table, th, td {
            border: 1px solid #ddd;
            padding: 8px;
        }

        th {
            background-color: #333;
            color: #fff;
        }

        h2, h3, h4 {
            color: #333;
            margin-top: 20px;
        }

        label {
            margin-right: 10px;
        }

        .table-heading {
            font-weight: bold;
            font-size: 18px; /* Adjust font size as needed */
            text-transform: uppercase;
        }

        .right-align {
            text-align: right;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
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
        <div class="col-md-1 d-flex justify-content-right mb-1">
            <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" CssClass="btn btn-sm btn-dark" OnClick="lbtnBack_Click"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
        </div>

        <h2>The Field Visit Team inspected,</h2>
        <table>
            <tr>
                <td>Unit Name:</td>
                <td>
                    <asp:TextBox ID="txtUnit" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox></td>
                <td>Place of Inspection:</td>
                <td>
                    <asp:TextBox ID="txtLocation" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox></td>
                <td>Date of Inspection:</td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDate"></cc1:CalendarExtender>
                    <i class="fi fi-rr-calendar-lines"></i></td>
            </tr>
        </table>
        <div class="col-md-12 d-flex justify-content-left mb-3">
            <asp:Label ID="lblInspectorOfficer" runat="server" Text="Details Of Inspector Officer" CssClass="table-heading"></asp:Label>
        </div>
        <table>
            <tr>
                <td>Name of the Site Inspection Team Member :</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox></td>
                <td>Designation/ Departmen :</td>
                <td>
                    <asp:TextBox ID="txtDepartment" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <div class="col-md-12 d-flex justify-content-center mb-3">
            <asp:Button ID="btnSave" runat="server" Text="ADD" OnClick="btnSave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
        </div>



        <div class="col-md-12 d-flex justify-content-center">
            <asp:GridView ID="gvTeamMembers" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                GridLines="None" OnRowDeleting="gvTeamMembers_RowDeleting"
                Width="100%" EnableModelValidation="True" Visible="false">
                <RowStyle BackColor="#ffffff" />
                <Columns>
                    <asp:BoundField HeaderText="Name of the Site Inspection Team Member" DataField="MemberName" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="Designation/ Department" DataField="Designation" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" ItemStyle-HorizontalAlign="Center" />
                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                </Columns>
                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>


        <h3>Site Verification Report</h3>

        <div style="display: flex; justify-content: center;">
            <table border="1" style="width: 80%">
                <tr>
                    <th>Sr No</th>
                    <th>Particulars</th>
                    <th>Remarks</th>
                </tr>
                <tr>
                    <td>1</td>
                    <td>Name of the Unit</td>
                    <td>
                        <asp:TextBox ID="txtUnitName" runat="server" Placeholder="Enter Name Of the unit" Width="400px" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>Location of the Unit</td>
                    <td>
                        <asp:TextBox ID="txtUnitLocation" runat="server" Placeholder="Enter the Address of the Unit" Width="400px" onkeypress="return Address(event)" TabIndex="1" MaxLength="50"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>3</td>
                    <td>Coordinates of the Site</td>
                    <td>
                        <asp:TextBox ID="txtCoordinates" runat="server" Width="400px" Placeholder="40.7128° N, 74.0060° W" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="9"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>4</td>
                    <td>Total area of Site</td>
                    <td>
                        <asp:TextBox ID="txtArea" runat="server" Width="200px" Placeholder="In sq.ft/ acres" onkeypress="return validateNumberAndDot(event)" TabIndex="1" MaxLength="6"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>5</td>
                    <td>Ownership Status</td>
                    <td>
                        <asp:DropDownList ID="ddlOwnershipStatus" runat="server">
                            <asp:ListItem Text="--Select--"></asp:ListItem>
                            <asp:ListItem Text="Owned" Value="Owned"></asp:ListItem>
                            <asp:ListItem Text="Leased" Value="Leased"></asp:ListItem>
                            <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>6</td>
                    <td>Land under Possession of unit</td>
                    <td>
                        <asp:RadioButtonList ID="rblPossession" runat="server">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>7</td>
                    <td>Distance from the Main Road</td>
                    <td>
                        <asp:TextBox ID="txtDistanceMainRoad" runat="server" Width="200px" Placeholder="Write distance in KM" onkeypress="return validateNumbersOnly(event)" TabIndex="1" MaxLength="5"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>8</td>
                    <td>Type of Road</td>
                    <td>
                        <asp:TextBox ID="txtTypeOfRoad" runat="server" Width="400px" Placeholder="Width/ condition/ specify" TabIndex="1" onkeypress="return Names(this)" MaxLength="150"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>9</td>
                    <td>Project Construction commencement</td>
                    <td>
                        <asp:RadioButtonList ID="rblProjectConstruction" runat="server">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:TextBox ID="txtConstructionRemarks" runat="server" Width="300px" Placeholder="Remarks (if any)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>10</td>
                    <td>Any Natural Bodies</td>
                    <td>
                        <asp:TextBox ID="txtNaturalBodies" runat="server" Width="400px" Placeholder="Specify type of natural body" TabIndex="1" onkeypress="return Names(this)" MaxLength="200"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>11</td>
                    <td>Environmentally Vulnerable location</td>
                    <td>
                        <asp:RadioButtonList ID="rblEnvVulnerable" runat="server">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:TextBox ID="txtEnvVulnerableRemarks" runat="server" Width="300px" Placeholder="If Yes, specify" TabIndex="1" onkeypress="return Names(this)" MaxLength="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>12</td>
                    <td>Availability of Power</td>
                    <td>
                        <asp:RadioButtonList ID="rblPowerAvailability" runat="server">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:TextBox ID="txtPowerDrawPoint" runat="server" Width="300px" Placeholder="If No, specify nearest drawl point"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>13</td>
                    <td>Availability of Water</td>
                    <td>
                        <asp:TextBox ID="txtWaterSource" runat="server" Width="400px" Placeholder="Specify source" TabIndex="1" onkeypress="return Names(this)" MaxLength="200"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>14</td>
                    <td>Other observations</td>
                    <td>
                        <asp:TextBox ID="txtOtherObservations" runat="server" Width="400px" Placeholder="Specify, if applicable" TabIndex="1" onkeypress="return Names(this)" MaxLength="200"></asp:TextBox></td>
                </tr>
            </table>
        </div>
        <br />
        <div style="display: flex; justify-content: center;">
            <h4>Comments/ Remarks of Field visit team (if any):</h4>
            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="5" Width="600px"></asp:TextBox>
        </div>

        <div align="center">
            <br />
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            <br />
            <br />
            <asp:Label ID="savelbl" runat="server" Visible="False"></asp:Label>

            <br />
            <asp:HiddenField ID="hdnUserID" runat="server" />

        </div>



    </div>
</asp:Content>
