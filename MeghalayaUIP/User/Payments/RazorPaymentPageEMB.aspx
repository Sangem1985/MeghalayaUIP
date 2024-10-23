<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RazorPaymentPageEMB.aspx.cs" Inherits="MeghalayaUIP.User.Payments.RazorPaymentPageEMB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Razorpay</title>

</head>
    
<body>
     <form method="post" action="https://api.razorpay.com/v1/checkout/embedded">
        <input type="hidden" name="key_id" value="rzp_test_l9labd1MMZqwzK"/> 
        <input type="hidden" name="order_id" value="<%=orderId%>"/>
        <input type="hidden" name="name" value="Invest Meghalaya Authority"/>
        <input type="hidden" name="description" value="<%=Desc%>"/>
        <input type="hidden" name="image" value="https://cdn.razorpay.com/logos/BUVwvgaqVByGp2_large.png"/>
        <input type="hidden" name="prefill[name]" value="<%=Name%>"/>
        <input type="hidden" name="prefill[contact]" value="<%=Contact%>"/>
        <input type="hidden" name="prefill[email]" value="<%=Mail%>"/>
        <input type="hidden" name="notes[shipping address]" value="<%=Notes%>"/>
        <input type="hidden" name="callback_url" value="https://localhost:44379/User/Payments/RazorPaymentResponse.aspx"/>
        <input type="hidden" name="cancel_url" value="https://localhost:44379/User/CFE/CFEUserDashboard.aspx"/>
        <button>Pay Now</button>
    </form>
   
</body>
</html>
