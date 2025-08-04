<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEEstimationReport.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEEstimationReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Main Table Styling */
        table {
            width: 80%;
            border-collapse: collapse;
            margin: 20px auto;
            font-family: Arial, sans-serif;
            font-size: 14px;
        }

        th, td {
            border: 1px solid black;
            padding: 8px 12px;
        }

        thead th {
            border: 2px solid black;
            background-color: #f9f9f9;
            text-align: center;
        }

        tbody td {
            border-left: 1px solid black;
            border-right: 1px solid black;
        }

        tbody tr td:nth-child(2) {
            border-bottom: 1px dotted #555;
        }

        .amount {
            text-align: right;
        }

        /* Bank Info Box */
        .bank-info {
            width: 80%;
            margin: 20px auto;
            border: 2px solid red;
            padding: 10px;
            font-size: 14px;
        }

            .bank-info p {
                margin: 5px 0;
            }

        /* Heading Styles */
        .heading {
            text-align: center;
            font-weight: bold;
            font-size: 16px;
            margin-top: 20px;
        }

        .card {
            margin: 20px 100px;
            box-shadow: 1px 2px 3px #495057;
        }

        .mainmenu, .header {
            display: none;
        }

        .powerdept {
            .header123

        {
            display: flex;
            align-items: center;
            padding: 10px 20px;
            border-bottom: 2px solid #000;
        }

        .logo {
            margin-right: 20px;
        }

            .logo img {
                height: 70px;
            }

        .title-section {
            text-align: center;
            flex-grow: 1;
        }

            .title-section h1 {
                margin: 0;
                font-size: 20px;
                font-weight: bold;
            }

        .subtitle {
            font-size: 14px;
            margin-top: 2px;
        }
        input#ContentPlaceHolder1_btnDownload {
    width: 11% !important;
}
        #ContentPlaceHolder1_btnDownload {
    width: 10% !important;
}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="powerdept">
                                <div class="header123">
                                    <div class="logo">
                                        <img src="../../assets/admin/img/power.png" alt="Power Dept Logo" style="width: 100% !important;" />
                                        <!-- Replace logo.png with the actual logo image path -->
                                    </div>
                                    <div class="title-section">
                                        <h1>MEGHALAYA POWER DISTRIBUTION CORPORATION LIMITED</h1>
                                        <div class="subtitle">SOUTH GARO HILLS DIVISION &nbsp;&nbsp;&nbsp;&nbsp; BAGHMARA SUBDIVISION</div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12  row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                <div class="col-md-12 " style="text-align: center">

                                    <b>ESTIMATE FOR NEW SERVICE CONNECTION
</b>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                <div class="col-md-6" style="text-align: left">
                                    <label>
                                        Application No: <b>
                                            <asp:Label ID="lblApplicationNo" runat="server"></asp:Label></b></label>
                                </div>
                                <div class="col-md-6" style="text-align: right">
                                    <label>
                                        Application Date: <b>
                                            <asp:Label ID="lblaplicationdate" runat="server"></asp:Label></b></label>
                                </div>

                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                <div class="col-md-6" style="text-align: left">

                                    <label>To,</label>
                                </div>
                                <div class="col-md-6" style="text-align: right">
                                    <label>
                                        Load KW: <b>
                                            <asp:Label ID="lblLoad" runat="server"></asp:Label></b></label>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                <div class="col-md-6" style="text-align: left">
                                    <label></label>
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-6" style="text-align: right">
                                    <label>
                                        Category: <b>
                                            <asp:Label ID="lblCategory" runat="server"></asp:Label></b></label>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                <div class="col-md-6" style="text-align: left">
                                    <label>
                                        phone No: <b>
                                            <asp:Label ID="lblPhoneNo" runat="server"></asp:Label></b></label>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                <div class="col-md-6" style="text-align: left">
                                    <label>
                                        Address: <b>
                                            <asp:Label ID="lblAddress" runat="server"></asp:Label></b></label>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                <div class="col-md-12" style="text-align: left">
                                    <b>
                                        <label>Sub:Estimate for Providing New Service Connection/Line Extension/Sub Station/Metering. </label>
                                    </b>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                <div class="col-md-12" style="text-align: left">
                                    <label>Dear Esteemed Consumer,</label>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                <div class="col-md-12" style="text-align: left">
                                    <label>
                                        With refernce to your Connection Id:  <b>
                                            <asp:Label ID="lblconnid" runat="server"></asp:Label><b> and Van Number</b>
                                            <asp:Label ID="lblVan" runat="server"></asp:Label></b> dated: <b>
                                                <asp:Label ID="lbldate" runat="server"></asp:Label></b> for the subject cited above, you are requested to deposit the following estimate amount <b>
                                                    <asp:Label ID="lblRupees" runat="server"></asp:Label></b>
                                        at the Cash Collection Counters within the Sub Division or into the Bank Account as detailed below: <b></b>
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">

                                <div class="col-md-12" style="text-align: left">
                                    <label>BankAccountName:<b><asp:Label ID="lblBankname" runat="server"></asp:Label></b></label>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">

                                <div class="col-md-12" style="text-align: left">
                                    <label>Account No:<b><asp:Label ID="lblAccountNo" runat="server"></asp:Label></b></label>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">

                                <div class="col-md-12" style="text-align: left">
                                    <label>IFSC Code:<b><asp:Label ID="lblCode" runat="server"></asp:Label></b></label>
                                </div>
                            </div>
                            <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                <div class="col-md-12" style="text-align: left">
                                    <label>Please find attached here with break-up of the total quoted estimate amount.</label>
                                </div>
                                <div class="col-md-12 row mt-1" style="padding: 0px 0px 0px 20px; text-align: center">
                                    <div class="table-responsive">
                                        <asp:GridView ID="grdcomponents" runat="server" AutoGenerateColumns="false" BorderColor="#003399"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333"
                                            GridLines="Both" HeaderStyle-BackColor="Red"
                                            Width="100%" EnableModelValidation="True">
                                            <RowStyle />
                                            <AlternatingRowStyle BackColor="LightGray" />
                                            <HeaderStyle BackColor="Red" />
                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="10px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Order" DataField="ORDERID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                <asp:BoundField HeaderText="component" DataField="COMPONENT" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                                <asp:BoundField HeaderText="amount" DataField="AMOUNT" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left" />
                                            </Columns>

                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>

                           

                        </div>
                    </div>
                    <div class="col-md-12 d-flex mb-4"
                        style="display: flex !important; justify-content: center; align-items: center;" id="print" runat="server" visible="false">

                        <asp:Button ID="btnDownload" class="btn btn-approved btn-sm mr-5" OnClick="btnDownload_Click1" runat="server" Text="Download"></asp:Button>

                        <div class="btn btn-edit btn-sm ml-5" style="width: 5%;" id="lb" runat="server" visible="false">Print</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

