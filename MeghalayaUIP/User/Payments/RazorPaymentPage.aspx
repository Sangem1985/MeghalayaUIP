<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RazorPaymentPage.aspx.cs" Inherits="MeghalayaUIP.User.Payments.RazorPaymentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Razorpay</title>

</head>
<script type="text/javascript">
    function AutoSubmit() {

        document.forms[0].submit();
    }

</script>
<body onload="AutoSubmit()">
    <form method="post" action="https://api.razorpay.com/v1/checkout/embedded">
        <input type="hidden" name="key_id" value="rzp_live_C73gDRjPW5TMvE" />
        <input type="hidden" name="order_id" value="<%=orderId%>" />
        <input type="hidden" name="name" value="Invest Meghalaya Authority" />
        <input type="hidden" name="description" value="<%=Desc%>" />
        <input type="hidden" name="image" value="https://cdn.razorpay.com/logos/BUVwvgaqVByGp2_large.png" />
        <input type="hidden" name="prefill[name]" value="<%=Name%>" />
        <input type="hidden" name="prefill[contact]" value="<%=Contact%>" />
        <input type="hidden" name="prefill[email]" value="<%=Mail%>" />
        <input type="hidden" name="notes[shipping address]" value="<%=Notes%>" />
        <input type="hidden" name="callback_url" value="<%=CallbackUrl%>" />
        <input type="hidden" name="cancel_url" value="<%=Cancelurl%>" />
        <button>Pay Now</button>
    </form>

</body>
</html>

