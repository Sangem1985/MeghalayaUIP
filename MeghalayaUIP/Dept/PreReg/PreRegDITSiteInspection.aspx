<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegDITSiteInspection.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegDITSiteInspection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    </script>
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
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <%--<div class="card-header">
                            <h3 class="card-title">Site Inspection Report</h3>
                        </div>--%>
                        <div class="col-md-12 d-flex ">
                            <div class="col-md-11 pb-2 pt-2 ">
                                <h4>Site Inspection Report</h4>
                            </div>
                            <div class="col-md-1 pb-2 pt-2">
                                <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" CssClass="btn btn-sm btn-dark" OnClick="lbtnBack_Click"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                            </div>
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
                            <div class="col-md-1 d-flex justify-content-right mb-1">
                            </div>

                            <h5 class="card-title ml-3">a) The Field Visit Team inspected</h5>
                            <div class="col-md-12 d-flex">
                                <div class="col-md-4">
                                    <div class="form-group d-flex">
                                        <label class="col-lg-6 col-form-label">1. Unit Name:<span style="color: red;">*</span></label>
                                        <div class="col-lg-6">
                                            <asp:TextBox ID="txtUnit" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group d-flex">
                                        <label class="col-lg-6 col-form-label">2. Place of Inspection: <span style="color: red;">*</span></label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtLocation" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group d-flex">
                                        <label class="col-lg-6 col-form-label">3. Date of Inspection:<span style="color: red;">*</span></label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtDate" runat="server" class="form-control" onkeypress="validateNumberAndHyphen(event);" MaxLength="10" onblur="validateDateFormat(this)" TabIndex="1"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDate"></cc1:CalendarExtender>
                                            <i class="fi fi-rr-calendar-lines"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <h5 class="card-title ml-3">b) Details Of Inspector Officer</h5>
                            <div class="col-md-12 d-flex">
                                <div class="col-md-4">
                                    <div class="form-group d-flex">
                                        <label class="col-lg-6 col-form-label">1. Site Inspection Team Member Name:<span style="color: red;">*</span></label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group d-flex">
                                        <label class="col-lg-6 col-form-label">2. Designation/ Department: <span style="color: red;">*</span></label>
                                        <div class="col-lg-6 d-flex">
                                            <asp:TextBox ID="txtDepartment" runat="server" class="form-control" onkeypress="return Names(this)" TabIndex="1"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">

                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label"></label>
                                        <div class="col-lg-6 d-flex" style="margin-top: -18px;">
                                            <asp:Button ID="btnSave" runat="server" Text="ADD" OnClick="btnSave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12 d-flex ">
                                <div class="col-md-8">
                                    <asp:GridView ID="gvTeamMembers" runat="server" AutoGenerateColumns="False"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="0" CssClass="GRD mx-auto" ForeColor="#333333"
                                        GridLines="Both" Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="gvTeamMembers_RowDeleting">
                                        <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#013161" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField HeaderText="Name of the Site Inspection Team Member" DataField="MEMBERNAME">
                                                <ItemStyle Width="350px" HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Designation/ Department" DataField="DESIGNATION">
                                                <ItemStyle Width="300px" HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="btn btn-rounded btn-danger text-white"/>
                                        </Columns>
                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                            </div>


                            <%--<div class="col-md-12 d-flex table">
                                <div class="col-md-2">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label"><b>Sl.No.</b></label>
                                        <div class="col-lg-6 d-flex">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label"><b>Particulars</b></label>
                                        <div class="col-lg-6 d-flex">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group row">
                                        <label class="col-lg-6 col-form-label"><b>Remarks</b></label>
                                        <div class="col-lg-6 d-flex">
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                            <h5 class="card-title ml-3 mt-5">c) Inspection Details</h5>
                            <div class="col-md-12 d-flex ml-3">
                                <table style="width: 80%">
                                    <tr>
                                        <th>Sr No</th>
                                        <th>Particulars</th>
                                        <th>Remarks</th>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Name of the Unit</td>
                                        <td>
                                            <asp:TextBox ID="txtUnitName" class="form-control" runat="server" Placeholder="Enter Name Of the unit" Width="400px" onkeypress="return Names(this)" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>Location of the Unit</td>
                                        <td>
                                            <asp:TextBox ID="txtUnitLocation" CssClass="form-control" runat="server" Placeholder="Enter the Address of the Unit" Width="400px" onkeypress="return Address(event)" TabIndex="1" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>3</td>
                                        <td>Coordinates of the Site</td>
                                        <td>
                                            <asp:TextBox ID="txtCoordinates" CssClass="form-control" runat="server" Width="400px" Placeholder="40.7128° N, 74.0060° W" TabIndex="1" MaxLength="50" onkeyup="handleKeyUp(this)"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>4</td>
                                        <td>Total area of Site</td>
                                        <td>
                                            <asp:TextBox ID="txtArea" CssClass="form-control" runat="server" Width="400px" Placeholder="In sq.ft/ acres" TabIndex="1" MaxLength="6" onkeyup="handleKeyUp(this)"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>5</td>
                                        <td>Ownership Status</td>
                                        <td>
                                            <asp:DropDownList class="form-control" ID="ddlOwnershipStatus" runat="server" Width="200px">
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
                                            <asp:RadioButtonList ID="rblPossession" runat="server" RepeatDirection="Horizontal" Width="150px">
                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>7</td>
                                        <td>Distance from the Main Road</td>
                                        <td>
                                            <asp:TextBox CssClass="form-control" ID="txtDistanceMainRoad" runat="server" Width="400px" Placeholder="Write distance in KM" onkeypress="return validateNumbersOnly(event)" TabIndex="1" MaxLength="5" onkeyup="handleKeyUp(this)"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>8</td>
                                        <td>Type of Road</td>
                                        <td>
                                            <asp:TextBox CssClass="form-control" ID="txtTypeOfRoad" runat="server" Width="400px" Placeholder="Width/ condition/ specify" TabIndex="1" onkeypress="return Names(this)" MaxLength="150" onkeyup="handleKeyUp(this)"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>9</td>
                                        <td>Project Construction commencement</td>
                                        <td>
                                            <asp:RadioButtonList ID="rblProjectConstruction" runat="server" RepeatDirection="Horizontal" Width="150px">
                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:TextBox CssClass="form-control" ID="txtConstructionRemarks" runat="server" Width="400px" Placeholder="Remarks (if any)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>10</td>
                                        <td>Any Natural Bodies</td>
                                        <td>
                                            <asp:TextBox CssClass="form-control" ID="txtNaturalBodies" runat="server" Width="400px" Placeholder="Specify type of natural body" TabIndex="1" onkeypress="return Names(this)" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>11</td>
                                        <td>Environmentally Vulnerable location</td>
                                        <td>
                                            <asp:RadioButtonList ID="rblEnvVulnerable" runat="server" RepeatDirection="Horizontal" Width="150px">
                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:TextBox CssClass="form-control" ID="txtEnvVulnerableRemarks" runat="server" Width="400px" Placeholder="If Yes, specify" TabIndex="1" onkeypress="return Names(this)" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>12</td>
                                        <td>Availability of Power</td>
                                        <td>
                                            <asp:RadioButtonList ID="rblPowerAvailability" runat="server" RepeatDirection="Horizontal" Width="150px">
                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:TextBox CssClass="form-control" ID="txtPowerDrawPoint" runat="server" Width="400px" Placeholder="If No, specify nearest drawl point" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>13</td>
                                        <td>Availability of Water</td>
                                        <td>
                                            <asp:TextBox CssClass="form-control" ID="txtWaterSource" runat="server" Width="400px" Placeholder="Specify source" TabIndex="1" onkeypress="return Names(this)" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>14</td>
                                        <td>Other observations</td>
                                        <td>
                                            <asp:TextBox CssClass="form-control" ID="txtOtherObservations" runat="server" Width="400px" Placeholder="Specify, if applicable" TabIndex="1" onkeypress="return Names(this)" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </div>
                            <div id="divText" runat="server" style="display: flex; justify-content: center;">
                            </div>
                            <br />
                            <div class="col-md-12 d-flex">
                                <h5 class="card-title ml-3" style="padding-right: 17px">d) Comments/ Remarks of Field visit team (if any):   </h5>
                                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Height="100px" Width="400px" onkeyup="handleKeyUp(this)"></asp:TextBox>
                            </div>

                            <div align="center">
                                <br />
                                <asp:Button ID="btnSubmit" class="btn btn-rounded btn-save btn-lg" Width="150px" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                                <br />
                                <br />
                                <asp:Label ID="savelbl" runat="server" Visible="False"></asp:Label>

                                <br />
                                <asp:HiddenField ID="hdnUserID" runat="server" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>


        </div>
</asp:Content>
