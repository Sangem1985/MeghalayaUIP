<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="CFEExplosivesNOC.aspx.cs" Inherits="MeghalayaUIP.User.CFE.CFEExplosivesNOC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function handleKeyUp(input) {
            if (input.value.trim() === "") {
                input.style.border = "2px solid red";
            } else {
                input.style.border = "1px solid #767575b5";
            }
        }
        function validateRadioButtonList(radioGroupContainer) {
            // Find all radio buttons inside the container
            const radioButtons = radioGroupContainer.querySelectorAll('input[type="radio"]');

            // Check if any radio button is selected
            const isSelected = Array.from(radioButtons).some(radio => radio.checked);

            if (!isSelected) {
                // If none are selected, apply red border
                radioGroupContainer.style.border = "2px solid red";
                radioGroupContainer.querySelector('input[type="radio"]').focus(); // Set focus to the first radio button
            } else {
                // Reset the border if an option is selected
                var id = radioGroupContainer.id;
                document.getElementById(id).style.border = "1px solid #767575b5";
                return false;
            }
        }
    </script>
    <script src="../../assets/admin/js/form-validation.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="page-wrapper" id="divText" runat="server">
                <div class="content container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Explosives NOC Appilication Details</h4>
                                </div>
                                <div class="card-body">
                                    <div class="col-md-12 ">
                                        <div id="success" runat="server" visible="false" class="alert alert-success alert-dismissible fade show" align="Center">
                                            <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span></button>
                                        </div>
                                    </div>
                                    <div class="col-md-12 ">
                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show" align="Center">
                                            <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="hdnUserID" runat="server" />
                                    <div class="row">
                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Quantity of Explosives proposed to be manufactured/possessed for the purpose stated at serial No. 1 above :</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Name and Description <span class="text-danger">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" onkeypress="return Names()" MaxLength="200" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Class <span class="text-danger">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtClass" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="200" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Division if any <span class="text-danger">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDivision" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="200" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Quantity(at any one time)<span class="text-danger">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtQuantityTime" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Quantity(at any one month) <span class="text-danger">*</span></label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtQuantityMonth" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="100" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:Button ID="btnAdd" Text="Add Details" OnClick="btnAdd_Click" class="btn btn-rounded btn-green" runat="server" Width="110px" />
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex justify-content-left">
                                            <asp:GridView ID="GVEXPLOSIVE" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                GridLines="None"
                                                Width="100%" EnableModelValidation="True" Visible="false" OnRowDeleting="GVEXPLOSIVE_RowDeleting">
                                                <HeaderStyle HorizontalAlign="Center"  />
                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Name and Description" DataField="CFEME_NAME"   ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Class" DataField="CFEME_CLASS"   ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Division if any" DataField="CFEME_DIVISION" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Quantity(at any one time)" DataField="CFEME_QUANTITYTIME"   ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />
                                                    <asp:BoundField HeaderText="Quantity(at any one month)" DataField="CFEME_QUANTITYMONTH"   ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="Wheat" ItemStyle-ForeColor="WindowText" />

                                                </Columns>
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <br />
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-11">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">Details of site where explosives will be used and distance of site of use from the storage premises (in case of licence for use)  <span class="text-danger">*</span></label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtExplosive" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="200" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-11">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">Details of explosives road van which will be used for transportation of explosives (in case of no objection certificate for road van)<span class="text-danger">*</span></label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:TextBox ID="txtRoadVan" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="200" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <label class="col-lg-12 col-form-label fw-bold"><span style="font-weight: 900;">Additional information:</span></label>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">(i) I or We have not been convicted under any offence or ordered to execute bond under Chapter VIII of Code of Criminal Procedure, 1973, during the last 10 years ( If yes, please give details).<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3">
                                                        <asp:RadioButtonList ID="rblcriminal1973" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblcriminal1973_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6" id="Details" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Enter Details  <span class="text-danger">*</span></label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtDetails" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="200" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">(ii) Particulars of other licenses: I / We possess under Explosives Act, 1884 (Note: Please write the licence no(s), if any) <span class="text-danger">*</span></label>
                                                    <div class="col-lg-3">
                                                        <asp:RadioButtonList ID="rblLIC1884" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblLIC1884_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6" id="LicDetails" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Enter Details  <span class="text-danger">*</span></label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtDet" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="50" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-9 col-form-label">(iii) I/We have obtained approval as required under rule 101 from the competent authority: (Note: Please enclose the approval letter, approved drawing(s), other enclosures, if any)<span class="text-danger">*</span></label>
                                                    <div class="col-lg-3">
                                                        <asp:RadioButtonList ID="rblApproval101" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblApproval101_SelectedIndexChanged">
                                                            <asp:ListItem Text="Yes" Value="Y" />
                                                            <asp:ListItem Text="No" Value="N" />
                                                        </asp:RadioButtonList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6" id="approvaldet" runat="server" visible="false">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Enter Details  <span class="text-danger">*</span></label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtDetail" runat="server" class="form-control" onkeypress="return validateNameAndNumbers(event)" MaxLength="200" TabIndex="1" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">(iv) Any other relevant information: <span class="text-danger">*</span></label>
                                                    <div class="col-lg-4 d-flex">
                                                        <asp:TextBox ID="txtinformation" runat="server" class="form-control" TextMode="MultiLine" onkeypress="return validateNameAndNumbers(event)" MaxLength="200" onkeyup="handleKeyUp(this)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <h4 class="card-title">Upload Document</h4>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">1.NOC from Headman for proposed site for rural areas and NOC from Local Authority for urban areas <span class="text-danger">*</span></label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupNocHeadman" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnNocHeadMan" OnClick="btnNocHeadMan_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypNocHeadman" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblNocHeadman" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">2.Clearance certificate from Fire Department <span class="text-danger">*</span></label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupFireDepartment" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnFireDepartment" OnClick="btnFireDepartment_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypfireDepartment" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblFireDepartment" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        3.Details of site where explosives will be used and distance of site of use from the storage premises (Site layout) <span class="text-danger">*</span></label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupsite" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnsite" OnClick="btnsite_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypsite" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblsite" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-12">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">4.Clearance from Deputy Controller of Explosives <span class="text-danger">*</span></label>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:FileUpload ID="fupExplosives" runat="server" />
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Button Text="Upload" runat="server" ID="btnExplosives" OnClick="btnExplosives_Click" class="btn btn-rounded btn-dark mb-4" Width="150px" />
                                                    </div>
                                                    <div class="col-lg-2 d-flex">
                                                        <asp:HyperLink ID="hypExplosives" runat="server" Target="_blank"></asp:HyperLink>
                                                    </div>
                                                    <div class="col-lg-1 d-flex">
                                                        <asp:Label ID="lblExplosives" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 text-right">

                                            <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" class="btn btn-rounded btn-info btn-lg" Width="150px" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnNocHeadMan" />
            <asp:PostBackTrigger ControlID="btnFireDepartment" />
            <asp:PostBackTrigger ControlID="btnsite" />
            <asp:PostBackTrigger ControlID="btnExplosives" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
