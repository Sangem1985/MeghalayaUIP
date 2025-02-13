<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="IncEligibilty.aspx.cs" Inherits="MeghalayaUIP.IncEligibilty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        /* Blue header styling */
        .blue-header {
            background-color: #0047AB !important; /* Rich blue header */
            color: white !important;
            font-weight: bold;
            text-align: center;
        }

        /* Alternating row colors */
        .table-bordered tr:nth-child(even) {
            background-color: #E6F2FF; /* Light blue alternate row */
        }

        .table-bordered tr:nth-child(odd) {
            background-color: white; /* White row */
        }

        /* Add padding for a clean look */
        .table-bordered td, .table-bordered th {
            padding: 12px;
            vertical-align: middle;
        }
    </style>



    <div class="container">
        <div class="card">
            <div class="card-header text-left">
                <h5>View Eligible Incentives for Your Business/Industry</h5>
            </div>
            <div class="card-body">
                <div class="row">
                    <%--<!-- Caste Field -->
                    <div class="col-md-6">
                        <asp:Label ID="Label376" runat="server" CssClass="LBLBLACK">1. Caste<font color="red">*</font></asp:Label>
                        <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" TabIndex="1">
                            <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                            <asp:ListItem Value="1" Text="General">General</asp:ListItem>
                            <asp:ListItem Value="2" Text="OBC">OBC</asp:ListItem>
                            <asp:ListItem Value="3" Text="SC">SC</asp:ListItem>
                            <asp:ListItem Value="4" Text="ST">ST</asp:ListItem>
                            <asp:ListItem Value="5" Text="Others">Others</asp:ListItem>
                        </asp:DropDownList>

                    </div>--%>


                    <!-- Category Field -->
                    <div class="col-md-6">
                        <asp:Label ID="Label377" runat="server" CssClass="LBLBLACK">1. Category<font color="red">*</font></asp:Label>
                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" TabIndex="2">
                            <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                            <asp:ListItem Value="1" Text="Subsidy">Subsidy</asp:ListItem>
                            <asp:ListItem Value="2" Text="Interest Subvention">Interest Subvention</asp:ListItem>
                            <asp:ListItem Value="3" Text="Tax Reimbursement">Tax Reimbursement</asp:ListItem>
                            <asp:ListItem Value="4" Text="Reimbursement">Reimbursement</asp:ListItem>
                            <asp:ListItem Value="5" Text="Custom">Custom</asp:ListItem>
                            <asp:ListItem Value="6" Text="Preference">Preference</asp:ListItem>
                        </asp:DropDownList>

                    </div>

                    <!-- Municipal Corporation Field -->
                    <div class="col-md-6">
                        <asp:Label ID="LabelArea" runat="server" CssClass="LBLBLACK">2. Select Area<font color="red">*</font></asp:Label>
                        <asp:DropDownList ID="ddlSelectArea" runat="server" class="form-control txtbox" TabIndex="3">
                            <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                            <asp:ListItem Value="1" Text="Area">Area</asp:ListItem>
                            <asp:ListItem Value="2" Text="All">All</asp:ListItem>
                            <asp:ListItem Value="3" Text="Priority & Non-Priority Sectors">Priority & Non-Priority Sectors</asp:ListItem>
                            <asp:ListItem Value="4" Text="Investments above ₹100 crore & Green Technology Industries">Investments above ₹100 crore & Green Technology Industries</asp:ListItem>
                            <asp:ListItem Value="5" Text="Micro & Small Enterprises">Micro & Small Enterprises</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorArea" runat="server"
                            ControlToValidate="ddlSelectArea" InitialValue="-- SELECT --"
                            ErrorMessage="Please Select Area" ValidationGroup="group" Display="None" />
                    </div>



                </div>

                <div class="row mt-3">
                    <!-- Type of Sector Field -->
                    <div class="col-md-6">
                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">3. Type of Sector<font color="red">*</font></asp:Label>
                        <asp:DropDownList ID="ddlSector" runat="server" class="form-control txtbox" TabIndex="3">
                            <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                            <asp:ListItem Value="1" Text="Service">Service</asp:ListItem>
                            <asp:ListItem Value="2" Text="Manufacture" Selected="True">Manufacture</asp:ListItem>
                            <asp:ListItem Value="3" Text="Both">Both</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="ddlSector" InitialValue="-- SELECT --"
                            ErrorMessage="Please Select Sector" ValidationGroup="group" Display="None" />
                    </div>

                    <!-- Entrepreneur Type Field -->
                    <div class="col-md-6">
                        <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK">4. Entrepreneur Type</asp:Label>
                        <asp:RadioButtonList ID="rblenterprenrtype" runat="server" Width="260px" TabIndex="4">
                            <asp:ListItem Value="1" Text="New & Existing" Selected="True">New & Existing</asp:ListItem>
                            <asp:ListItem Value="2" Text="Expansion & Diversification">Expansion & Diversification</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="row mt-3">
                    <!-- Physically Handicapped Field -->
                    <div class="col-md-6">
                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK">5. Is Physically Handicapped   : </asp:Label>
                        <asp:CheckBox ID="cbphysicalHandicapped" runat="server" Text="Yes" TabIndex="5" />
                    </div>


                </div>


                <!-- Submit Button -->
                <div class="row mt-4">
                    <div class="col-md-12 text-center">
                        <asp:Button CssClass="btn btn-primary" ID="showincentive" OnClick="showincentive_Click" runat="server" Text="Show Eligible Incentives" />
                    </div>
                </div>

                <!-- Grid for displaying incentives -->
                <div class="row mt-4">
                    <div class="col-md-12">
                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-bordered"
                            ForeColor="#333333" Width="100%" ShowFooter="True">

                            <Columns>
                                <asp:BoundField DataField="IncentiveType" HeaderText="Eligible Incentive" />
                                <asp:BoundField DataField="Category" HeaderText="Incentive Type" />
                                <asp:TemplateField Visible="false" HeaderText="Know More">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lbt" runat="server"
                                            Text='<%# Eval("DocName") %>'
                                            NavigateUrl='<%# Eval("FilePath") %>'
                                            Target="_blank" CssClass="btn btn-light btn-sm border-info text-info" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                            <HeaderStyle CssClass="blue-header" />
                        </asp:GridView>




                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
