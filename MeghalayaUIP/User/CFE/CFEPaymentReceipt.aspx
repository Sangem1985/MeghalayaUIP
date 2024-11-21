<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CFEPaymentReceipt.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEPaymentReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Payment Receipt</title>
    <style type="text/css">
        /* Global styling for the body and form */
        body {
            font-family: Arial, sans-serif;
            font-size: 14px;
            margin: 0;
            padding: 0;
            color: #333;
            background-color: #f5f5f5;
        }

        .container {
            width: 650px;
            margin: 30px auto;
            padding: 20px;
            background-color: white;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        .header {
            text-align: center;
            margin-bottom: 20px;
        }

            .header img {
                width: 60px;
                height: 60px;
            }

            .header h2 {
                font-size: 22px;
                margin-top: 10px;
                font-weight: bold;
            }

        .contact-info {
            text-align: center;
            font-size: 14px;
            margin-bottom: 15px;
        }

            .contact-info span {
                display: block;
            }

        /* Section titles */
        .section-title {
            font-weight: bold;
            margin-top: 20px;
            font-size: 16px;
        }

        /* Flexbox for the receipt details */
        .receipt-details {
            display: flex;
            justify-content: space-between;
            margin-top: 10px;
        }

            .receipt-details .column {
                width: 48%;
            }

            .receipt-details div {
                margin-bottom: 10px;
            }

        /* Amount section */
        .amount-paid {
            margin-top: 20px;
            display: flex;
            justify-content: space-between;
        }

            .amount-paid div {
                font-weight: bold;
            }

        /* Note section */
        .note {
            margin-top: 20px;
            font-size: 14px;
            font-style: italic;
            text-align: center;
        }

        /* Separator */
        .separator {
            text-align: center;
            margin-top: 10px;
        }

            .separator span {
                font-size: 18px;
                font-weight: bold;
                border-top: 2px solid #000;
                padding-top: 5px;
                display: inline-block;
                width: 100%;
            }

        /* Button section */
        .button-section {
            text-align: center;
            margin-top: 20px;
        }

            .button-section input {
                padding: 8px 20px;
                margin: 0 10px;
                font-size: 14px;
                cursor: pointer;
                border-radius: 4px;
                border: 1px solid #ccc;
                background-color: #4CAF50;
                color: white;
            }

                .button-section input:hover {
                    background-color: #45a049;
                }

                .button-section input[type="button"]:last-child {
                    background-color: #008CBA;
                }

                    .button-section input[type="button"]:last-child:hover {
                        background-color: #007BB5;
                    }

        .auto-style3 {
            align-content: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header-center">
        </div>
        <div class="container">

            <a href="index.html" class="logo">
                <img src="../../assets/admin/img/logo.png" alt="Logo" /></a>
            <!-- Receipt Title Section -->
            <div class="header">
                <h2 style="text-decoration: underline;">Online Payment Receipt</h2>
            </div>
            <!-- Contact Information Section -->
            <div class="contact-info">
                <p>
                    Administrative Building, Lower Lachumiere 
                    Shillong - 793001, 
                </p>
                <p>
                    East Khasi Hills District, Meghalaya.
                        Phone:(0364) 2226253
                </p>
            </div>

            <!-- Receipt Details Section -->
            <div class="section-title" style="text-align: center;">
                <p class="auto-style3">
                    Receipt Details
                    of Pre Establishment
                </p>
            </div>

            <!-- 3x2 Table with Mild Borders -->
            <div class="receipt-details">
                <table class="receipt-table">
                    <tr>
                        <td><strong>UID No:</strong> <asp:Label ID="txtuid" runat="server"></asp:Label></td>
                        <td><strong>Transaction No:</strong> <asp:Label ID="txtrcptno" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Amount Paid (Rs):</strong> <asp:Label ID="txttotal" runat="server" Font-Bold="true"></asp:Label></td>
                        <td><strong>Mobile Number:</strong> <asp:Label ID="lblMobileNumber" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Email Id:</strong> <asp:Label ID="txtEmailId" runat="server"></asp:Label></td>
                        <td><strong>Transaction Date:</strong> <asp:Label ID="txtrcptdt" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
            <br />
            <!-- Communication Address Section (Moved outside the table) -->
            <div>
                <strong>Communication Address:</strong> 
                <asp:Label ID="txtaddress" runat="server"></asp:Label>
            </div>

            <!-- Note Section -->
            <div class="note">
                <span>Note: Print this payment receipt for further reference.</span>
            </div>

            <!-- Separator -->
            <div class="separator">
                <span>*************************************************</span>
            </div>

            <!-- Button Section -->
            <div class="button-section">
                <input type="button" value="Close" onclick="Redirect();" />
                <input type="button" value="Print" onclick="window.print()" />
            </div>
        </div>
    </form>

    <style>
        /* Style for the table */
        .receipt-table {
            width: 100%; /* Full width of the container */
            border-collapse: collapse; /* Collapse borders to avoid double borders */
            margin-top: 20px; /* Optional, for spacing */
        }

        /* Mild borders for the table cells */
        .receipt-table td {
            border: 1px solid #ccc; /* Light gray border */
            padding: 10px; /* Spacing inside the cells */
            text-align: left; /* Align text to the left */
        }

        /* Optional: Add some padding to the table headers if needed */
        .receipt-table th {
            padding: 10px;
            text-align: left;
            background-color: #f4f4f4; /* Light gray background for headers */
        }

        /* Optional: Make the table header bold or more distinct */
        .receipt-table strong {
            font-weight: bold;
        }

        /* Style for the table with no border */
        .note {
            margin-top: 10px;
            font-style: italic;
            font-size: 14px;
        }

        .separator {
            text-align: center;
            margin-top: 20px;
            font-size: 18px;
            font-family: monospace;
        }

        .button-section {
            text-align: center;
            margin-top: 20px;
        }
    </style>
</body>



</html>
