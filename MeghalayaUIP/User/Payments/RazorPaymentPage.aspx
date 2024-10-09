<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RazorPaymentPage.aspx.cs" Inherits="MeghalayaUIP.User.Payments.RazorPaymentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Razorpay</title>

</head>
<body>
    <form id="form1" runat="server" method="post" name="razorpayForm">
        <div>
            <input id="razorpay_payment_id" type="hidden" name="razorpay_payment_id" runat="server" />
            <input id="razorpay_order_id" type="hidden" name="razorpay_order_id" runat="server" />
            <input id="razorpay_signature" type="hidden" name="razorpay_signature" runat="server" />
            <input type="hidden" name="key_id" id="hdn_key_id" runat="server" />
            <input type="hidden" name="order_id" id="hdn_order_id" runat="server" />
            <input type="hidden" name="amount" id="hdn_amount" runat="server" />
            <input type="hidden" name="name" id="hdn_name" runat="server" />
            <input type="hidden" name="description" id="hdn_description" runat="server" />
            <input type="hidden" name="email" id="hdn_email" runat="server" />
            <input type="hidden" name="contact" id="hdn_contact" runat="server" />
            <input type="hidden" name="notes" id="hdn_notes" runat="server" />
            <input type="hidden" name="callback_url" id="hdncallback_url" runat="server" />

            <asp:Button runat="server" ID="btnPay" Text="Pay Now"  />
        </div>
    </form>
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <script>

        function OpenWindow() {
            notes = "";
            var orderId = "<%=orderId%>"
            var options = {
                "key": document.getElementById('hdn_key_id').value,
                "amount": document.getElementById('hdn_amount').value,
                "currency": "INR",
                "name": "Invest Meghalaya Authority",
                "description": document.getElementById('hdn_description').value,
                "order_id": orderId,
                "image": "",
                /*"callback_url": "http://invest.meghalaya.gov.in/User/Payments/RazorPaymentResponse.aspx",*/
                "handler": function (response) {
                    window.location.href = "RazorPaymentResponse.aspx?paymentid=" + response.razorpay_payment_id + "&orderid=" + response.razorpay_order_id + "&signature=" + response.razorpay_signature;
                },
                "prefill": {
                    "name": document.getElementById('hdn_name').value,
                    "email": document.getElementById('hdn_email').value,
                    "contact": document.getElementById('hdn_contact').value,
                },
                "notes": notes,
                "theme": {
                    "color": ""
                }
            };
            var rzp1 = new Razorpay(options);
            rzp1.open();
            rzp1.on('payment.failed', function (response) {
                alert(response.error.code);
               /* window.location.href = "RazorPaymentResponse.aspx?paymentid=" + response.razorpay_payment_id + "&orderid=" + response.razorpay_order_id + "&signature=" + response.razorpay_signature + "&error=" + response.error.code + "&errordesc=" + response.error.description + "&errorsource=" + response.error.source
                    + "&errorstep=" + response.error.step + "&errorreason=" + response.error.reason;
                return false;*/
            });
        }
        document.getElementById('btnPay').onclick = function (e) {
            OpenWindow();
            e.preventDefault();
        }
    </script>
</body>
</html>
