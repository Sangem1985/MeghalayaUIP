<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEEntrepreneurDetails.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEEntrepreneurDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <script type="text/javascript">
        function validateEmail(event) {
            var email = event.target.value;
            var isValidEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);

            if (!isValidEmail) {
                event.target.value = "";
                alert("Enter a valid email address");
            }
        }

    </script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var yrRange = "2023:" + (date.getFullYear() + 1);

            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtRegDate']").datepicker(
                {
                    dateFormat: "dd-mm-yy",
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange

                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

        }
        $(function () {
            var date = new Date();
            var yrRange = "2023:" + (date.getFullYear() + 1);
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtRegDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd-mm-yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                    changeMonth: true,
                    changeYear: true,
                    yearRange: yrRange
                });

        });
    </script>

    <div class="page-wrapper">

        <div class="content container-fluid">

            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Entrepreneur Details</h4>
                        </div>
                        <div class="card-body">
                            <!-- <h4 class="card-title">Personal Information</h4> -->
                            <div class="col-md-12 d-flex">
                                <div id="success" runat="server" visible="false" class="alert alert-success" align="Center">
                                    <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12 d-flex">
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger" align="Center">
                                    <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdnUserID" runat="server" />

                            <div class="row">
                                <div class="col-md-12 d-flex">
                                    <h5 class="card-title ml-4">Organization Details: </h5>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Name of Company</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtIndustryName" runat="server" class="form-control" onkeypress="return validateNames(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                14. Type of
														Company *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlOrganization" runat="server" class="form-control">
                                                    <asp:ListItem Text="Select Organization" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Company Proposal *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:RadioButtonList ID="rblproposal" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="New" Text="New"></asp:ListItem>
                                                    <asp:ListItem Value="Expansion" Text="Expansion"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12  d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                5. Category of
														Registration*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlCategory_Reg" runat="server" class="form-control">
                                                    <asp:ListItem Text="Select Category" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">6. Registration No*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtRegistrationNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                7. Registration
														Date<br />
                                                (dd-MM-yyyy)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <%--														<asp:TextBox ID="txtRegDate" runat="server" class="form-control" onkeypress="datefunction(date_input)"></asp:TextBox>--%>

                                                <asp:TextBox ID="txtRegDate" runat="server" class="form-control txtbox" Height="28px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group" Width="125px"></asp:TextBox>


                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12  d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">8. Type of Factory*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlFactories" runat="server" class="form-control">
                                                    <asp:ListItem Text="--Select--" Value="0" />
                                                    <asp:ListItem Text="Hazardous" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Non Hazardous" Value="2"></asp:ListItem>
                                                </asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <h5 class="card-title ml-4">Authorised Representative Details: </h5>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                2. Name </label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtPromoterName" runat="server" class="form-control" onkeypress="return validateNames(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                3.
														S/o.D/o.W/o</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtSoWoDo" runat="server" class="form-control" onkeypress="return validateNames(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">13. Email</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" onblur="validateEmail(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">11. Mobile No</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtMobileno" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                12. Alternative Mobile
														No*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtAltMobile" runat="server" class="form-control" onkeypress="return PhoneNumberOnly(event)" MaxLength="10"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                15. Landline Tel No
                                               
                                            </label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLandlineno" runat="server" class="form-control" onblur="validatePhoneNumber(input_str)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4" runat="server" visible="false">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">4. State</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlState" runat="server" class="form-control" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Text="Select State" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">5. District</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlDistric" runat="server" class="form-control" OnSelectedIndexChanged="ddlDistric_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Text="Select Distric" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">6. Mandal</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlMandal" runat="server" class="form-control" OnSelectedIndexChanged="ddlMandal_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Text="Select Mandal" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">7. Village/Town</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlVillage" runat="server" class="form-control">
                                                    <asp:ListItem Text="Select Village" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">8. Street Name</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtstreet" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">9. Door No</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtDoorNo" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">10. Pincode</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtpincode" runat="server" class="form-control" onkeypress="return validatePincode(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12  d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">17. Social Status</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:DropDownList ID="ddlSocialStatus" runat="server" class="form-control">
                                                    <asp:ListItem Text="Select SocialStatus" Value="0" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">20. Minority*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:RadioButtonList ID="rblMinority" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                18. Differently
														Abled*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:RadioButtonList ID="rblAbled" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-12  d-flex">

                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                19. Women
														Entrepreneur</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:RadioButtonList ID="rblWomen" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Yes" Value="Y" />
                                                    <asp:ListItem Text="No" Value="N" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                           <%--     <h5 class="card-title ml-4">Project Details(New Investmen)</h5>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                1. Land Value(in
														Lakhs)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtLandValue" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                2. Building Value(in
														Lakhs)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtBuildingValue" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                3. Plant and Machinery
														Value(in Lakhs) *</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtPlant_Machinery" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12  d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">
                                                4. Total Value(in
														Lakhs)*</label>
                                            <div class="col-lg-6 d-flex">
                                                <asp:TextBox ID="txtTotalProjValue" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                                <h5 class="card-title ml-4">Employment Details</h5>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Direct Male</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtMale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2.Direct Female</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtFemale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">Total Employee</label>
                                            <div class="col-lg-6">
                                                <asp:Label ID="lbltotalEmp" runat="server" value="40"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 d-flex">
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">1. Indirect Male</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtIndirectMale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                            <label class="col-lg-6 col-form-label">2. Indirect Female</label>
                                            <div class="col-lg-6">
                                                <asp:TextBox ID="txtIndirectFemale" runat="server" class="form-control" onkeypress="return validateNumbersOnly(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>




                        <div class="col-md-12 d-flex mt-2">
                            <div class="col-md-6">


                                <asp:Button Text="Previous" runat="server" ID="btnPrevious" class="btn  btn-info btn-lg" OnClick="btnPrevious_Click" />
                            </div>
                            <div class="col-md-6 text-right">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" class="btn btn-rounded btn-info btn-lg" padding-right="10px" BackColor="Green" />


                                <asp:Button ID="btnNext" Text="Next" runat="server" class="btn  btn-info btn-lg" OnClick="btnNext_Click" />

                            </div>
                        </div>

                    </div>



                </div>
            </div>
        </div>
    </div>

    </div>
    </div>
</asp:Content>
