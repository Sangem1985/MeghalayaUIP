<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RazorPaymentPage.aspx.cs" Inherits="MeghalayaUIP.User.Payments.RazorPaymentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Razorpay</title>

</head>
<body>
    <%-- <form method="post" runat="server" action="https://api.razorpay.com/v1/checkout/embedded" name="razorpayForm">
        <input type="hidden" name="key_id" id="hdn_key_id" runat="server" />
        <input type="hidden" name="amount" id="hdn_amount" runat="server" />
        <input type="hidden" name="order_id" id="hdn_order_id" runat="server" />
        <input type="hidden" name="name" id="hdn_name1" runat="server" />
        <input type="hidden" name="description" id="hdn_description" runat="server" />
        <input type="hidden" name="image" value="https://cdn.razorpay.com/logos/BUVwvgaqVByGp2_large.jpg" />
        <input type="hidden" name="prefill[name]" id="hdn_name" runat="server" />
        <input type="hidden" name="prefill[contact]" id="hdn_contact" runat="server" />
        <input type="hidden" name="prefill[email]" id="hdn_email" runat="server" />
        <input type="hidden" name="notes[shipping address]" id="hdn_notes" runat="server" />
        <input type="hidden" name="callback_url" id="hdncallback_url" runat="server" />
        <input type="hidden" name="cancel_url"  id="hdncancel_url" runat="server" />
        <button>Submit</button>
    </form>--%>
    <form method="post" action="https://api.razorpay.com/v1/checkout/embedded">
        <input type="hidden" name="key_id" value="rzp_test_l9labd1MMZqwzK" id="hdn_key_id" />
        <input type="hidden" name="amount" id="hdn_amount" runat="server" />
        <input type="hidden" name="order_id" value="razorpay_order_id" />
        <input type="hidden" name="name" value="Acme Corp" />
        <input type="hidden" name="description" value="A Wild Sheep Chase" />
        <input type="hidden" name="image" value="https://cdn.razorpay.com/logos/BUVwvgaqVByGp2_large.jpg" />
        <input type="hidden" name="prefill[name]" value="Gaurav Kumar" />
        <input type="hidden" name="prefill[contact]" value="9123456780" />
        <input type="hidden" name="prefill[email]" value="gaurav.kumar@example.com" />
        <input type="hidden" name="notes[shipping address]" value="L-16, The Business Centre, 61 Wellfield Road, New Delhi - 110001" />
        <input type="hidden" name="callback_url" value="http://invest.meghalaya.gov.in/User/Payments/RazorPaymentResponse.aspx" />
        <input type="hidden" name="cancel_url" value="https://google.com" />
        <button>Submit</button>
    </form>
</body>
</html>
