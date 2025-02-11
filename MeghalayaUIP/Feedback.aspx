<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="MeghalayaUIP.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .feedback-container {
            background: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        .question {
            margin-bottom: 15px;
        }

        .options {
            display: flex;
            justify-content: space-between;
            margin-top: 5px;
        }

        label {
            display: flex;
            flex-direction: column;
            align-items: center;
            font-size: 14px;
        }

        input[type="radio"] {
            margin-bottom: 5px;
        }

        button {
            margin-top: 20px;
            padding: 10px;
            background: #28a745;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            width: 100%;
        }

            button:hover {
                background: #218838;
            }

        .message {
            text-align: center;
            font-weight: bold;
            margin-top: 15px;
            color: green;
        }
    </style>



    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                            <li class="breadcrumb-item">Resources / ODOP</li>
                            <li class="breadcrumb-item active" aria-current="page">Sectoral Information</li>
                        </ol>
                    </nav>
                    <section class="innerpages">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="feedback-container">
                                        <table class="table">
                                            <thead>
                                                <tr class="colorblue">
                                                    <th colspan="2">Feedback on Invest Meghalaya Portal Services</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptFeedback1" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Container.ItemIndex + 1 %>. <%# Eval("Question") %></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rblFeedback1" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="1"> Strongly Disagree </asp:ListItem>
                                                                    <asp:ListItem Value="2"> Disagree </asp:ListItem>
                                                                    <asp:ListItem Value="3"> Neutral </asp:ListItem>
                                                                    <asp:ListItem Value="4"> Agree </asp:ListItem>
                                                                    <asp:ListItem Value="5"> Strongly Agree </asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>

                                        <br />

                                        <!-- Table 2: Feedback on the Invest Meghalaya Portal (Overall User Experience) -->
                                        <table class="table">
                                            <thead>
                                                <tr class="colorblue">
                                                    <th colspan="2">Feedback on the Invest Meghalaya Portal (Overall User Experience)</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptFeedback2" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Container.ItemIndex + 1 %>. <%# Eval("Question") %></td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rblFeedback2" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="1"> Strongly Disagree </asp:ListItem>
                                                                    <asp:ListItem Value="2"> Disagree </asp:ListItem>
                                                                    <asp:ListItem Value="3"> Neutral </asp:ListItem>
                                                                    <asp:ListItem Value="4"> Agree </asp:ListItem>
                                                                    <asp:ListItem Value="5"> Strongly Agree </asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>

                                        <br />
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click1" CssClass="btn btn-success"/>
                                    </div>
                                </div>
                            
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </section>

    <script>
        function submitFeedback() {
            let form = document.getElementById("likertForm");
            let responseMessage = document.getElementById("responseMessage");
            let allAnswered = true;

            
            let questions = ["q1", "q2", "q3"];
            let responses = {};

            questions.forEach(question => {
                let selectedOption = document.querySelector(`input[name="${question}"]:checked`);
                if (!selectedOption) {
                    allAnswered = false;
                } else {
                    responses[question] = selectedOption.value;
                }
            });

            if (!allAnswered) {
                responseMessage.style.color = "red";
                responseMessage.textContent = "Please answer all questions!";
                return;
            }

            responseMessage.style.color = "green";
            responseMessage.textContent = "Thank you for your feedback!";

            console.log("Survey Responses:", responses); 
        }
    </script>



</asp:Content>


