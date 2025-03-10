<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThirdPartyVerificationAckSlip.aspx.cs" Inherits="MeghalayaUIP.ThirdPartyVerificationAckSlip" %>

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
            border: 1px solid #dfdfdf;
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
        <div>
            <div class="page-wrapper" style="min-height: 293px;">
                <div class="content container-fluid">

                    <!-- Invoice Container -->
                    <div class="invoice-container">

                        <div class="row">
                            <div class="col-sm-12 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <img alt="Logo" class="img-fluid" src="assets/admin/img/logo.png" />
                            </div>

                            <div class="col-sm-6 m-b-20 text-center" style="display: flex; justify-content: center;">
                                <div class="invoice-details text-center d-flex" style="text-align: center;">
                                    <h3 class="text-uppercase" style="margin-bottom: 0;"><u>Application Acknowledgement</u></h3>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 m-b-20">
                                <ul class="list-unstyled mb-0 list-item">
                                    <li>Date :
                                        <label runat="server" id="lblDate" style="font-weight: bold"></label>
                                        <br />                                       
                                    </li>
                                      <li>Application Reference Number is : <b>
                                        <label runat="server" id="lblUIDNo"></label>
                                    </b>                                        
                                    </li>
                                    <%-- <li>
                                        <label runat="server" id="lblEnterPrise"></label>
                                    </li>--%>
                                    <li>Unit Name :
                                        <label runat="server" id="lblDear" style="font-weight: bold"></label>
                                        ,<br />
                                        <br />
                                        In view of the above, the unit is hereby accorded the Permissions/Approval applied for under the Meghalaya Industrial Facilitation Act.
                                        A total of 
                                        <label runat="server" id="lblPrime" style="font-weight: bold; font-size: 18px;"></label>
                                        approvals were applied for, and the same have been granted under the applicable provisions of the Meghalaya State Government’s industrial facilitation framework.
                                       
                                    </li>

                                </ul>
                             <%--   <div class="col-sm-12 m-b-20 text-center" style="display: flex; justify-content: center;">
                                    <div class="invoice-details text-center d-flex" style="text-align: center;">
                                        <h3 class="text-uppercase" style="margin-bottom: 0;"><u>Application Summary</u></h3>
                                    </div>
                                </div>--%>
                                <ul class="list-unstyled mb-0 list-item">
                                  
                                   <%-- <li>Your application was received by Online mode.
                                        <label runat="server" id="lblDate1"></label>
                                    </li>--%>
                                </ul>
                            </div>

                        </div>
                        <div style="display: flex; justify-content: center;">
                            <input id="btnPrint" onclick="window.print()"
                                style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                                type="button" value="Print" />
                        </div>

                    </div>


                    <!-- /Invoice Container -->

                </div>
            </div>
        </div>
    </form>

</body>
</html>
