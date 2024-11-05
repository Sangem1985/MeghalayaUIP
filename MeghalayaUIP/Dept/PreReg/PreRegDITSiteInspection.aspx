<%@ Page Title="" Language="C#" MasterPageFile="~/Dept/dept.Master" AutoEventWireup="true" CodeBehind="PreRegDITSiteInspection.aspx.cs" Inherits="MeghalayaUIP.Dept.PreReg.PreRegDITSiteInspection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    </style>


    <div>

        <h2>The Field Visit Team inspected,</h2>
        <div>
            <label>Unit:</label>
            <asp:TextBox ID="txtUnit" runat="server" Width="300px"></asp:TextBox>
            <label>&nbsp;&nbsp; on: </label>
            <asp:TextBox ID="txtLocation" runat="server" Width="300px"></asp:TextBox>
            <label>&nbsp;&nbsp; at: </label>
            <asp:TextBox ID="txtDate" runat="server" Width="200px"></asp:TextBox>
        </div>

        <asp:GridView ID="gvTeamMembers" runat="server" AutoGenerateColumns="False" OnRowCommand="gvTeamMembers_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Sr No">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name of the Site Inspection Team Member">
                    <ItemTemplate>

                        <asp:TextBox ID="txtMemberName" runat="server" Text='<%# Bind("MemberName") %>' Width="300px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Designation/ Department">
                    <ItemTemplate>

                        <asp:TextBox ID="txtDesignation" runat="server" Text='<%# Bind("Designation") %>' Width="300px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CommandName="AddNew" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


        <h3>Site Verification Report</h3>

        <table border="1">
            <tr>
                <th>Sr No</th>
                <th>Particulars</th>
                <th>Remarks</th>
            </tr>
            <tr>
                <td>1</td>
                <td>Name of the Unit</td>
                <td>
                    <asp:TextBox ID="txtUnitName" runat="server" Placeholder="Enter Name Of the unit" Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>2</td>
                <td>Location of the Unit</td>
                <td>
                    <asp:TextBox ID="txtUnitLocation" runat="server" Placeholder="Enter the Address of the Unit" Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>3</td>
                <td>Coordinates of the Site</td>
                <td>
                    <asp:TextBox ID="txtCoordinates" runat="server" Width="400px" Placeholder="40.7128° N, 74.0060° W"></asp:TextBox></td>
            </tr>
            <tr>
                <td>4</td>
                <td>Total area of Site</td>
                <td>
                    <asp:TextBox ID="txtArea" runat="server" Width="200px" Placeholder="In sq.ft/ acres"></asp:TextBox></td>
            </tr>
            <tr>
                <td>5</td>
                <td>Ownership Status</td>
                <td>
                    <asp:DropDownList ID="ddlOwnershipStatus" runat="server">
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
                    <asp:TextBox ID="txtDistanceMainRoad" runat="server" Width="200px" Placeholder="Write distance in KM"></asp:TextBox></td>
            </tr>
            <tr>
                <td>8</td>
                <td>Type of Road</td>
                <td>
                    <asp:TextBox ID="txtTypeOfRoad" runat="server" Width="400px" Placeholder="Width/ condition/ specify"></asp:TextBox></td>
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
                    <asp:TextBox ID="txtNaturalBodies" runat="server" Width="400px" Placeholder="Specify type of natural body"></asp:TextBox></td>
            </tr>
            <tr>
                <td>11</td>
                <td>Environmentally Vulnerable location</td>
                <td>
                    <asp:RadioButtonList ID="rblEnvVulnerable" runat="server">
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:TextBox ID="txtEnvVulnerableRemarks" runat="server" Width="300px" Placeholder="If Yes, specify"></asp:TextBox>
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
                    <asp:TextBox ID="txtWaterSource" runat="server" Width="400px" Placeholder="Specify source"></asp:TextBox></td>
            </tr>
            <tr>
                <td>14</td>
                <td>Other observations</td>
                <td>
                    <asp:TextBox ID="txtOtherObservations" runat="server" Width="400px" Placeholder="Specify, if applicable"></asp:TextBox></td>
            </tr>
        </table>

        <h4>Comments/ Remarks of Field visit team (if any):</h4>
        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="5" Width="600px"></asp:TextBox>

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
