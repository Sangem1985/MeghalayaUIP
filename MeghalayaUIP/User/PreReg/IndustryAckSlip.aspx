<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndustryAckSlip.aspx.cs" Inherits="MeghalayaUIP.User.PreReg.IndustryAckSlip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ACKNOWLEDGEMENT SLIP</title>
    <link href="assets/admin/css/style.css" rel="stylesheet" />
    <style>
        ul.list-unstyled.mb-0.list-item li {
            list-style: none;
        }

        .invoice-container {
            background-color: #fff;
            border: 1px solid #000;
            margin: 0 auto 1.875rem;
            max-width: 900px;
            padding: 1.5rem;
            border-radius: 8px;
            box-shadow: 1px 3px 7px 1px #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-md-1 pb-2 pt-2">
            <asp:LinkButton ID="lbtnBack" runat="server" Text="Back" OnClick="lbtnBack_Click" CssClass="btn btn-sm btn-dark"><i class="fi fi-br-angle-double-small-left" style="position: absolute;margin-left: 32px;margin-top: 3px;"></i> Back&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton>
        </div>

        <div>
            <div class="page-wrapper" style="min-height: 293px;">
                <div class="content container-fluid">
                    <!-- Invoice Container -->
                    <div class="invoice-container">
                        <asp:HiddenField ID="hdnUserID" runat="server" />

                        <div class="row">
                            <div class="col-sm-12 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <img alt="Logo" class="img-fluid" src="../../assets/admin/img/acklogo.jpg" />
                            </div>

                            <div class="col-sm-6 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <div class="invoice-details text-center d-flex" style="text-align: center;">
                                    <h3 class="text-uppercase" style="margin-bottom: 0;"><u>ACKNOWLEDGEMENT SLIP</u></h3>
                                    <h3>Registration for MIIPP</h3>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 m-b-20">
                                <ul class="list-unstyled mb-0 list-item">
                                    <li>Application Date :
                                        <asp:Label runat="server" ID="lblApplDate"></asp:Label>
                                    </li>
                                    <li>
                                        <label runat="server" id="lblEnterPrise"></label>
                                        ,</li>
                                    <li>Your Industry Registration in Meghalaya has been successfully submitted to Planning, Investment Promotion and<br />
                                        Sustainable Development Department, Meghalaya.</li>
                                    <li>Your Application reference number is :
                                        <b>
                                            <asp:Label runat="server" ID="lblUIDNo"></asp:Label></b></li>
                                </ul>
                            </div>
                        </div>




                    </div>
                    <!-- /Invoice Container -->

                </div>
            </div>
        </div>
    </form>
</body>
</html>
