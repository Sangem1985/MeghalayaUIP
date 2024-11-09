<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCertificate.aspx.cs" Inherits="MeghalayaUIP.ViewCertificate" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Certificate View</title>
    <link href="assets/admin/css/style.css" rel="stylesheet" />
    <style>
        body {
            font-family: Verdana, sans-serif;
        }
        
        .invoice-container {
            background-color: #fff;
            border: 1px solid #dfdfdf;
            margin: 0 auto 1.875rem;
            max-width: 800px;
            padding: 2rem;
            border-radius: 8px;
            box-shadow: 1px 3px 7px 1px #ccc;
        }
        
        .text-center {
            text-align: center;
        }

        .certificate-title {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 1rem;
            text-decoration: underline;
        }

        .certificate-text {
            font-size: 18px;
            color: #333;
            word-spacing: 2px;
            letter-spacing: 0.5px;
            line-height: 1.6;
            margin: 1rem 0;
        }
        
        .note-text {
            font-size: 14px;
            font-weight: bold;
            text-align: center;
            border: 1px solid #000;
            padding: 1rem;
            margin-top: 1.5rem;
        }

        .certificate-footer {
            font-size: 16px;
            font-weight: bold;
            margin-top: 1rem;
            text-align: center;
        }

        .certificate-table {
            width: 100%;
            margin-top: 1rem;
            border-collapse: collapse;
        }

        .certificate-table td {
            padding: 8px;
            vertical-align: top;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-wrapper">
            <div class="content container-fluid">
                <div class="invoice-container">
                    
                    <!-- Logo and Title -->
                    <div class="text-center">
                        <img src="assets/admin/img/logo.png" alt="Logo" style="max-width: 150px; margin-bottom: 1rem;" />
                        <h3 class="certificate-title">View Certificate</h3>
                    </div>
                    
                    <!-- Certificate Details -->
                    <div>
                        <ul class="list-unstyled mb-0 list-item">
                           <%-- <li><strong>UID NO:</strong> <asp:Label runat="server" id="lblDate"></asp:Label></li>--%>
                        </ul>
                    </div>
                    
                   
                    <table class="certificate-table">
                        <tr>
                            <td colspan="3" class="certificate-text">
                                <asp:Label ID="lblNameOfCertifiedPerson5" runat="server" CssClass="certificate-text"
                                           Text="In view of the above, the unit is hereby accorded the Permission/Approval applied for under Invest Meghalaya Authority."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" class="certificate-text">
                                <asp:Label ID="Label1" runat="server" CssClass="certificate-text"
                                           Text="This approval is issued in accordance with the powers vested as per the Section ABCD of the Invest Meghalaya Authority Act, No. ABCD of YYYY, Government of Meghalaya."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="certificate-footer">
                                <asp:Label ID="lblNameOfCertifiedPerson2" runat="server" Width="250px"></asp:Label>
                            </td>
                            <td class="certificate-footer" style="text-align: center;">
                                <asp:Label ID="lblNameOfCertifiedPerson3" runat="server" CssClass="certificate-footer" 
                                           Text="Commissioner of Industries, Meghalaya"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    
                    <!-- Verification Note -->
                    <div class="note-text">
                        <strong>Note:</strong> This is a computer-generated certificate. Please verify it by clicking on the link 
                        <a href="https://invest.meghalaya.gov.in/UI/MiPASS/frmCFEcertificateProcess.aspx" target="_blank">https://invest.meghalaya.gov.in/UI/MiPASS/frmCFEcertificateProcess.aspx</a>
                        and entering the application number mentioned on the certificate.
                    </div>
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>

