<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="IncEligibilty.aspx.cs" Inherits="MeghalayaUIP.IncEligibilty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="card">
            <div class="card-header text-left">
                <h5>View Eligible Incentives for Your Business/Industry</h5>
            </div>
            <div class="card-body">
                <div class="row">
                    <!-- Caste Field -->
                    <div class="col-md-6">
                        <asp:Label ID="Label376" runat="server" CssClass="LBLBLACK">1.Caste<font color="red">*</font></asp:Label>
                        <asp:DropDownList ID="ddlCaste" runat="server" class="form-control txtbox" TabIndex="1">
                            <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                            <asp:ListItem Value="1">General</asp:ListItem>
                            <asp:ListItem Value="2">OBC</asp:ListItem>
                            <asp:ListItem Value="3">SC</asp:ListItem>
                            <asp:ListItem Value="4">ST</asp:ListItem>
                            <asp:ListItem Value="5">Others</asp:ListItem>
                        </asp:DropDownList>

                    </div>

                    <!-- Category Field -->
                    <div class="col-md-6">
                        <asp:Label ID="Label377" runat="server" CssClass="LBLBLACK">2.Category<font color="red">*</font></asp:Label>
                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" TabIndex="2">
                            <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                            <asp:ListItem Value="1">Subsidy</asp:ListItem>
                            <asp:ListItem Value="2">Interest Subvention</asp:ListItem>
                            <asp:ListItem Value="3">Tax Reimbursement</asp:ListItem>
                            <asp:ListItem Value="4">Reimbursement</asp:ListItem>
                            <asp:ListItem Value="5">Custom</asp:ListItem>
                            <asp:ListItem Value="6">Preference</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>

                <div class="row mt-3">
                    <!-- Type of Sector Field -->
                    <div class="col-md-6">
                        <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK">3.Type of Sector<font color="red">*</font></asp:Label>
                        <asp:DropDownList ID="ddlSector" runat="server" class="form-control txtbox" TabIndex="3">
                            <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                            <asp:ListItem Value="1">Service</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">Manufacture</asp:ListItem>
                            <asp:ListItem Value="3">Textiles</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="ddlSector" InitialValue="-- SELECT --"
                            ErrorMessage="Please Select Sector" ValidationGroup="group" Display="None" />
                    </div>

                    <!-- Entrepreneur Type Field -->
                    <div class="col-md-6">
                        <asp:Label ID="Label378" runat="server" CssClass="LBLBLACK">4.Entrepreneur Type</asp:Label>
                        <asp:RadioButtonList ID="rblSelection" runat="server" Width="260px" TabIndex="4">
                            <asp:ListItem Value="1" Selected="True">New / Existing</asp:ListItem>
                            <asp:ListItem Value="2">Expansion / Diversification</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="row mt-3">
                    <!-- Physically Handicapped Field -->
                    <div class="col-md-6">
                        <asp:Label ID="Label2" runat="server" CssClass="LBLBLACK">5.Is Physically Handicapped   :       </asp:Label>
                        <asp:CheckBox ID="cbphysicalHandicapped" runat="server" Text="Yes" TabIndex="5" />
                    </div>

                    <!-- Municipal Corporation Field -->
                    <div class="col-md-6">
                        <asp:Label ID="LabelArea" runat="server" CssClass="LBLBLACK">Select Area<font color="red">*</font></asp:Label>
                        <asp:DropDownList ID="ddlSelectArea" runat="server" class="form-control txtbox" TabIndex="3">
                            <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                            <asp:ListItem Value="1">Area</asp:ListItem>
                            <asp:ListItem Value="2">All</asp:ListItem>
                            <asp:ListItem Value="3">Priority & Non-Priority Sectors</asp:ListItem>
                            <asp:ListItem Value="4">Investments above ₹100 crore & Green Technology Industries</asp:ListItem>
                            <asp:ListItem Value="5">Micro & Small Enterprises</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorArea" runat="server"
                            ControlToValidate="ddlSelectArea" InitialValue="-- SELECT --"
                            ErrorMessage="Please Select Area" ValidationGroup="group" Display="None" />
                    </div>
                </div>

                <div class="row mt-3">
                    <!-- Services Field -->
                    <div class="col-md-6">
                        <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK">7.Services</asp:Label>
                        <asp:RadioButtonList ID="rblVehicleIncetive" runat="server" TabIndex="7">
                            <asp:ListItem Value="1">Transport allied activities</asp:ListItem>
                            <asp:ListItem Value="0" Selected="True">Other Service Sector</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <!-- Submit Button -->
                <div class="row mt-4">
                    <div class="col-md-12 text-center">
                        <asp:Button CssClass="btn btn-primary" ID="showincentive" runat="server" Text="Show Eligible Incentives" />
                    </div>
                </div>

                <!-- Grid for displaying incentives -->
                <div class="row mt-4">
                    <div class="col-md-12">
                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CssClass="GRD" PageSize="15" ShowFooter="True">
                            <Columns>
                                <asp:BoundField DataField="IncentiveType" HeaderText="Incentive Type" />
                                <asp:BoundField DataField="IncentiveName" HeaderText="Eligible Incentive" />
                                <asp:TemplateField HeaderText="Documents to be filled">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lbt" runat="server" Text='<%# Eval("DocName") %>' NavigateUrl='<%# Eval("FilePath") %>' Target="_blank" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
