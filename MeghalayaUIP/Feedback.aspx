<%@ Page Title="" Language="C#" MasterPageFile="~/OuterNew.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="MeghalayaUIP.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        th.colorblue, td.colorblue {
            color: #316ac2;
            font-weight: 400 !important;
        }

        .table th, .table td {
    padding: 0.40rem;
    font-weight: 400 !important;
    font-size: 18px;
    align-content: baseline;
}

        tbody tr:nth-child(odd) {
            background-color: #e9ecf5;
            color: #000;
        }

        tbody tr:nth-child(even) {
            background-color: #cfd5ed;
            color: #000;
        }

        tr.colorblue {
            background: #4574c6 !important;
            color: #fff !important;
        }

        tr.tdrow td {
            padding: 0px 0px !important;
        }


        .feedback-container {
            background: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 400px;
        }

        h2 {
            margin-bottom: 10px;
        }

        .stars {
            display: flex;
            gap: 5px;
            cursor: pointer;
        }

            .stars i {
                font-size: 25px;
                color: #ccc;
                transition: color 0.3s;
            }

                .stars i.active {
                    color: #f39c12;
                }

        textarea {
            width: 100%;
            height: 60px;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 5px;
            resize: none;
            margin-top: 10px;
        }

        button {
            margin-top: 10px;
            padding: 8px 12px;
            background: #28a745;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

            button:hover {
                background: #218838;
            }

        .message {
            margin-top: 10px;
            font-weight: bold;
        }
    </style>
    <script src="https://kit.fontawesome.com/a076d05399.js" crossorigin="anonymous"></script>

    

    <section class="innerpages">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Services</li>
                            <li class="breadcrumb-item active" aria-current="page">Feedback</li>
                        </ol>
                    </nav>

                    <h3>Invest Meghalaya Portal Feedback Survey</h3>

                    <h4>1. Feedback on Invest Meghalaya Portal Services</h4>

                    <p>Likert Scale: (1) Strongly Disagree — (2) Disagree — (3) Neutral — (4) Agree — (5) Strongly Agree</p>

                    <table class="table table-bordered">
                        <tbody>
                            <tr class="mb-2">
                                <td>1. The service I applied for was easy to find on the portal</td>

                                <td colspan="5">
                                    <div class="feedback-container" id="rating-1">
                                        <div class="stars">
                                            <i class="fas fa-star" data-value="1"></i>
                                            <i class="fas fa-star" data-value="2"></i>
                                            <i class="fas fa-star" data-value="3"></i>
                                            <i class="fas fa-star" data-value="4"></i>
                                            <i class="fas fa-star" data-value="5"></i>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>2. The information provided about the service was clear and sufficient.</td>
                                <td colspan="5">
                                    <div class="feedback-container" id="rating-2">
                                        <div class="stars">
                                            <i class="fas fa-star" data-value="1"></i>
                                            <i class="fas fa-star" data-value="2"></i>
                                            <i class="fas fa-star" data-value="3"></i>
                                            <i class="fas fa-star" data-value="4"></i>
                                            <i class="fas fa-star" data-value="5"></i>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>3. The application process was simple and user-friendly.</td>
                                <td colspan="5">
                                    <div class="feedback-container" id="rating-3">
                                        <div class="stars">
                                            <i class="fas fa-star" data-value="1"></i>
                                            <i class="fas fa-star" data-value="2"></i>
                                            <i class="fas fa-star" data-value="3"></i>
                                            <i class="fas fa-star" data-value="4"></i>
                                            <i class="fas fa-star" data-value="5"></i>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>4. The required documentation for the service was clearly outlined.</td>
                                <td colspan="5">
                                    <div class="feedback-container" id="rating-4">
                                        <div class="stars">
                                            <i class="fas fa-star" data-value="1"></i>
                                            <i class="fas fa-star" data-value="2"></i>
                                            <i class="fas fa-star" data-value="3"></i>
                                            <i class="fas fa-star" data-value="4"></i>
                                            <i class="fas fa-star" data-value="5"></i>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>5. The time taken for service approval was reasonable.</td>
                                <td colspan="5">
                                    <div class="feedback-container" id="rating-5">
                                        <div class="stars">
                                            <i class="fas fa-star" data-value="1"></i>
                                            <i class="fas fa-star" data-value="2"></i>
                                            <i class="fas fa-star" data-value="3"></i>
                                            <i class="fas fa-star" data-value="4"></i>
                                            <i class="fas fa-star" data-value="5"></i>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>6. I received timely updates on the status of my application.</td>
                                <td colspan="5">
                                    <div class="feedback-container" id="rating-6">
                                        <div class="stars">
                                            <i class="fas fa-star" data-value="1"></i>
                                            <i class="fas fa-star" data-value="2"></i>
                                            <i class="fas fa-star" data-value="3"></i>
                                            <i class="fas fa-star" data-value="4"></i>
                                            <i class="fas fa-star" data-value="5"></i>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>7. Customer support/helpdesk assistance was prompt and helpful.</td>
                                <td colspan="5">
                                    <div class="feedback-container" id="rating-7">
                                        <div class="stars">
                                            <i class="fas fa-star" data-value="1"></i>
                                            <i class="fas fa-star" data-value="2"></i>
                                            <i class="fas fa-star" data-value="3"></i>
                                            <i class="fas fa-star" data-value="4"></i>
                                            <i class="fas fa-star" data-value="5"></i>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>8. The service was processed efficiently without unnecessary delays.</td>
                                <td colspan="5">
                                    <div class="feedback-container" id="rating-8">
                                        <div class="stars">
                                            <i class="fas fa-star" data-value="1"></i>
                                            <i class="fas fa-star" data-value="2"></i>
                                            <i class="fas fa-star" data-value="3"></i>
                                            <i class="fas fa-star" data-value="4"></i>
                                            <i class="fas fa-star" data-value="5"></i>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>9. The grievance redressal mechanism was effective in resolving my concerns.</td>
                                <td colspan="5">
                                    <div class="feedback-container" id="rating-9">
                                        <div class="stars">
                                            <i class="fas fa-star" data-value="1"></i>
                                            <i class="fas fa-star" data-value="2"></i>
                                            <i class="fas fa-star" data-value="3"></i>
                                            <i class="fas fa-star" data-value="4"></i>
                                            <i class="fas fa-star" data-value="5"></i>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>10. Overall, I am satisfied with the service provided through Invest Meghalaya Portal.</td>
                                <td colspan="5">
                                    <div class="feedback-container" id="rating-10">
                                        <div class="stars">
                                            <i class="fas fa-star" data-value="1"></i>
                                            <i class="fas fa-star" data-value="2"></i>
                                            <i class="fas fa-star" data-value="3"></i>
                                            <i class="fas fa-star" data-value="4"></i>
                                            <i class="fas fa-star" data-value="5"></i>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>



                    <h4>2. Feedback on the Invest Meghalaya Portal (Overall User Experience)</h4>

                    <p>Likert Scale: (1) Strongly Disagree — (2) Disagree — (3) Neutral — (4) Agree — (5) Strongly Agree</p>

                    <table class="table table-bordered">
                        <tbody>
                            <tr class="mb-2">
                                <td>1. The Invest Meghalaya Portal is easy to navigate and use</td>
                                                                                <td colspan="5">
                        <div class="feedback-container" id="rating-11">
<div class="stars">
    <i class="fas fa-star" data-value="1"></i>
    <i class="fas fa-star" data-value="2"></i>
    <i class="fas fa-star" data-value="3"></i>
    <i class="fas fa-star" data-value="4"></i>
    <i class="fas fa-star" data-value="5"></i>
</div>
                            </div>
                    </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>2. The design and layout of the portal are visually appealing and intuitive.</td>
                                                                                <td colspan="5">
                        <div class="feedback-container" id="rating-12">
<div class="stars">
    <i class="fas fa-star" data-value="1"></i>
    <i class="fas fa-star" data-value="2"></i>
    <i class="fas fa-star" data-value="3"></i>
    <i class="fas fa-star" data-value="4"></i>
    <i class="fas fa-star" data-value="5"></i>
</div>
                            </div>
                    </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>3. The portal loads quickly and functions smoothly.</td>
                                                                                <td colspan="5">
                        <div class="feedback-container" id="rating-13">
<div class="stars">
    <i class="fas fa-star" data-value="1"></i>
    <i class="fas fa-star" data-value="2"></i>
    <i class="fas fa-star" data-value="3"></i>
    <i class="fas fa-star" data-value="4"></i>
    <i class="fas fa-star" data-value="5"></i>
</div>
                            </div>
                    </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>4. The information available on the portal is accurate and up-to-date.</td>
                                                                                <td colspan="5">
                        <div class="feedback-container" id="rating-14">
<div class="stars">
    <i class="fas fa-star" data-value="1"></i>
    <i class="fas fa-star" data-value="2"></i>
    <i class="fas fa-star" data-value="3"></i>
    <i class="fas fa-star" data-value="4"></i>
    <i class="fas fa-star" data-value="5"></i>
</div>
                            </div>
                    </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>5. The portal provides all necessary resources and guidelines for investors.</td>
                                                                                <td colspan="5">
                        <div class="feedback-container" id="rating-15">
<div class="stars">
    <i class="fas fa-star" data-value="1"></i>
    <i class="fas fa-star" data-value="2"></i>
    <i class="fas fa-star" data-value="3"></i>
    <i class="fas fa-star" data-value="4"></i>
    <i class="fas fa-star" data-value="5"></i>
</div>
                            </div>
                    </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>6. The search function helps in finding relevant information easily.</td>
                                                                                <td colspan="5">
                        <div class="feedback-container" id="rating-16">
<div class="stars">
    <i class="fas fa-star" data-value="1"></i>
    <i class="fas fa-star" data-value="2"></i>
    <i class="fas fa-star" data-value="3"></i>
    <i class="fas fa-star" data-value="4"></i>
    <i class="fas fa-star" data-value="5"></i>
</div>
                            </div>
                    </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>7. The online payment and transaction system (if applicable) is secure and reliable.</td>
                                                                                <td colspan="5">
                        <div class="feedback-container" id="rating-17">
<div class="stars">
    <i class="fas fa-star" data-value="1"></i>
    <i class="fas fa-star" data-value="2"></i>
    <i class="fas fa-star" data-value="3"></i>
    <i class="fas fa-star" data-value="4"></i>
    <i class="fas fa-star" data-value="5"></i>
</div>
                            </div>
                    </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>8. The portal is accessible on both desktop and mobile devices without issues.</td>
                                                                                <td colspan="5">
                        <div class="feedback-container" id="rating-18">
<div class="stars">
    <i class="fas fa-star" data-value="1"></i>
    <i class="fas fa-star" data-value="2"></i>
    <i class="fas fa-star" data-value="3"></i>
    <i class="fas fa-star" data-value="4"></i>
    <i class="fas fa-star" data-value="5"></i>
</div>
                            </div>
                    </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>9. I feel that the portal enhances the ease of doing business in Meghalaya.</td>
                                                                                <td colspan="5">
                        <div class="feedback-container" id="rating-19">
<div class="stars">
    <i class="fas fa-star" data-value="1" ></i>
    <i class="fas fa-star" data-value="2"></i>
    <i class="fas fa-star" data-value="3"></i>
    <i class="fas fa-star" data-value="4"></i>
    <i class="fas fa-star" data-value="5"></i>
</div>
                            </div>
                    </td>
                            </tr>
                            <tr style="background: #fff;" class="tdrow">
                                <td colspan="6">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>10. Overall, I am satisfied with my experience using the Invest Meghalaya Portal.</td>
                                                                                <td colspan="5">
                        <div class="feedback-container" id="rating-20">
<div class="stars">
    <i class="fas fa-star" data-value="1"></i>
    <i class="fas fa-star" data-value="2"></i>
    <i class="fas fa-star" data-value="3"></i>
    <i class="fas fa-star" data-value="4"></i>
    <i class="fas fa-star" data-value="5"></i>
</div>
                            </div>
                    </td>
                            </tr>
                        </tbody>
                    </table>

                    <h4>3. Additional Feedback</h4>
                    <p>1. What improvements would you suggest for the Invest Meghalaya Portal?</p>
                    <p>
                        <input type="text" style="width: 100%; height: 80px;" class="form-control" /></p>
                    <p class="align-content-center">
                        <input type="button" value="submit" text="submit" class="btn btn-sm btn-success" />
                    </p>
                    <p>2. Were there any difficulties you faced while using the portal? If yes, please specify.</p>
                    <p>
                        <input type="text" style="width: 100%; height: 80px;" class="form-control" /></p>
                    <p>
                        <input type="button" value="submit" text="submit" class="btn btn-sm btn-success" />
                    </p>
                </div>
            </div>

        </div>
    </section>
    <script>
        document.querySelectorAll('.feedback-container').forEach(container => {
            let stars = container.querySelectorAll('.stars i');
            let selectedRating = 0;

            stars.forEach(star => {
                star.addEventListener('click', function () {
                    selectedRating = this.getAttribute('data-value');
                    updateStarColors(container, selectedRating);
                    container.setAttribute('data-rating', selectedRating);
                });
            });

            function updateStarColors(container, rating) {
                stars.forEach(star => {
                    if (star.getAttribute('data-value') <= rating) {
                        star.classList.add('active');
                    } else {
                        star.classList.remove('active');
                    }
                });
            }
        });

        function submitFeedback(containerId) {
            let container = document.getElementById(containerId);
            let rating = container.getAttribute('data-rating') || 0;
            let feedbackText = container.querySelector("textarea").value;
            let message = container.querySelector(".message");

            if (rating == 0) {
                message.style.color = "red";
                message.textContent = "Please select a star rating!";
                return;
            }

            if (feedbackText.trim() === "") {
                message.style.color = "red";
                message.textContent = "Feedback cannot be empty!";
                return;
            }

            message.style.color = "green";
            message.textContent = `Thank you for your ${rating}-star rating!`;

            // Clear the form after submission
            container.querySelector("textarea").value = "";
            container.setAttribute('data-rating', 0);
            container.querySelectorAll(".stars i").forEach(star => star.classList.remove('active'));
        }
    </script>

    <!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Likert Scale Feedback</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            display: flex;
            justify-content: center;
            margin: 20px;
        }
        .feedback-container {
            background: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 500px;
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
</head>
<body>

    <div class="feedback-container">
        <h2>Customer Satisfaction Survey</h2>

        <form id="likertForm">
            <!-- Question 1 -->
            <div class="question">
                <p>1. How satisfied are you with our service?</p>
                <div class="options">
                    <label><input type="radio" name="q1" value="1"> Strongly Disagree</label>
                    <label><input type="radio" name="q1" value="2"> Disagree</label>
                    <label><input type="radio" name="q1" value="3"> Neutral</label>
                    <label><input type="radio" name="q1" value="4"> Agree</label>
                    <label><input type="radio" name="q1" value="5"> Strongly Agree</label>
                </div>
            </div>

            <!-- Question 2 -->
            <div class="question">
                <p>2. The quality of our products meets my expectations.</p>
                <div class="options">
                    <label><input type="radio" name="q2" value="1"> Strongly Disagree</label>
                    <label><input type="radio" name="q2" value="2"> Disagree</label>
                    <label><input type="radio" name="q2" value="3"> Neutral</label>
                    <label><input type="radio" name="q2" value="4"> Agree</label>
                    <label><input type="radio" name="q2" value="5"> Strongly Agree</label>
                </div>
            </div>

            <!-- Question 3 -->
            <div class="question">
                <p>3. I would recommend this company to others.</p>
                <div class="options">
                    <label><input type="radio" name="q3" value="1"> Strongly Disagree</label>
                    <label><input type="radio" name="q3" value="2"> Disagree</label>
                    <label><input type="radio" name="q3" value="3"> Neutral</label>
                    <label><input type="radio" name="q3" value="4"> Agree</label>
                    <label><input type="radio" name="q3" value="5"> Strongly Agree</label>
                </div>
            </div>

            <button type="button" onclick="submitFeedback()">Submit</button>
            <p id="responseMessage" class="message"></p>
        </form>
    </div>

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

</body>
</html>

</asp:Content>


