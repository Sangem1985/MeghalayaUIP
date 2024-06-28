<%@ Page Title="" Language="C#" MasterPageFile="~/outerNew.Master" AutoEventWireup="true" CodeBehind="Faq.aspx.cs" Inherits="MeghalayaUIP.Faq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item"><a href="#">Resources</a></li>
                            <li class="breadcrumb-item active" aria-current="page">FAQs</li>
                        </ol>
                    </nav>
                    
                    <h3>FAQs</h3>
                     <div class="row">
                    <div class="col col-xs-12">
                        <div class="panel-group faq-accordion theme-accordion-s1" id="accordion">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse-1">Q1. Whether Application can be submitted from CSCs?</a>
                                </div>
                                <div id="collapse-1" class="panel-collapse collapse in">
                                    <div class="panel-body">
                                        <p>Yes, Applicant can visit any nearby CSC and with the help of CSC he can submit his
                    online application. </p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse-2">Q2. Whether Application can be submitted from Cyber Cafe?</a>
                                </div>
                                <div id="collapse-2" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <p>Yes Applicant can visit any Cyber Cafe nearby and submit online application. </p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse-3">Q3. Whether Application can be submitted from his mobile?</a>
                                </div>
                                <div id="collapse-3" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <p>Yes the web-portal can be accessed from Mobile, Tablet apart from Desk Top Computer to
                    apply, check status etc.. </p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse-4">Q4. Whether Applicant can submit all mandatory enclosures online without needing to provide physical
                    copies?</a>
                                </div>
                                <div id="collapse-4" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <p>Yes, applicant has to upload all mandatory enclosures while applying online application
                    and there is no need to physically submit any enclosures. </p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse-5">Q5. Can applications fees be paid online?</a>
                                </div>
                                <div id="collapse-5" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <p>Yes, Application fees can be paid online through Meghalaya Government Online payment
                    portal (eGRAS) and the amount gets credited to the Government Treasury Account of the respective
                    Department.</p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse-6">Q6. Whether Acknowledgement is issued on submission of online application form?</a>
                                </div>
                                <div id="collapse-6" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <p>Yes after successful submission of online application form and all the mandatory
                    enclosures and application fee (if any) an acknowledgement is generated with a unique application
                    reference number which can be printed and stored for future reference.</p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse-7"> Q7. Whether Applicant will be able to track the status of the application?</a>
                                </div>
                                <div id="collapse-7" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <p>Yes the applicant will be able to track the status of the application from the Invest
                    Meghalaya Portal from the Track Application link by providing basic details. Applicant can also
                    track the status after login to his account on the portal.</p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse-8"> Q8. Whether Applicant will receive final document ( License, Certificate, Approval etc.) online?</a>
                                </div>
                                <div id="collapse-8" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <p>Yes the final document will be delivered to the applicant online to his login account
                    and he will also be intimated through SMS and Email.</p>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse-9">Q9. What needs to be done if payment receipt is not generated after online payment?</a>
                                </div>
                                <div id="collapse-9" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <p>If payment is already deducted from Applicant’s account and payment receipt is not
                    generated, then the application will be pending in the Re-Validation Menu. In such case, the Applicant has to click Revalidation to initiate confirmation. After the confirmation is received from Bank the payment receipt will be
                    generated.</p>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>  
                    </div>
                </div>
            </div>
        </section>
</asp:Content>
