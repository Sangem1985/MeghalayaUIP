<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="Grievance.aspx.cs" Inherits="MeghalayaUIP.User.Grievance.Grievance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Grievance</h4>
                        </div>
                        <div class="card-body">
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

                                <%--<h5 class="card-title ml-4">Location and address of the proposed building*</h5>--%>
                                <div class="col-md-12 d-flex">
                                    <asp:Label ID="LabelHeading" runat="server" CssClass="LBLBLACK" Font-Bold="True"
                                        Width="199px"></asp:Label>


                                </div>
                                 <div class="col-md-12 d-flex">
                                   <div class="col-md-4"  id="trgrivenance" runat="server" visible="true">
                                       <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Register Your *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlRegisterAs" runat="server" class="form-control txtbox"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlRegisterAs_SelectedIndexChanged">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem Value="G">Grievance</asp:ListItem>
                                                        <asp:ListItem Value="F">Feedback</asp:ListItem>
                                                        <asp:ListItem Value="Q">General Query</asp:ListItem>
                                                    </asp:DropDownList>
                                                   
                                                </div>
                                            </div>
                                   </div>
                                    <div class="col-md-4"  id="trData" visible="false" runat="server">
                                        <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">Acknowledgement Number *</label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:TextBox ID="txtuidno" runat="server" class="form-control txtbox"
                                                        MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                        AutoPostBack="True" OnTextChanged="txtuidno_TextChanged"></asp:TextBox>
                                                </div>
                                            </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label" id="LabelUnitname" runat="server">Unit Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtindname" runat="server" class="form-control txtbox"
                                                             MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                            ></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="Reqfvindname" runat="server"
                                                        ControlToValidate="txtindname" ErrorMessage="Please Enter Industry Name"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                    </div>
                               </div>


                                 
                                 <div class="col-md-12 d-flex">
                                   <div class="col-md-4" id="trdepartment" runat="server">
                                       <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Department Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddldept" runat="server" class="form-control txtbox"
                                                            TabIndex="1">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ControlToValidate="ddldept" ErrorMessage="Please Select Department"
                                                        ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                   </div>
                                    <div class="col-md-4">
                                         <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">District Name *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:DropDownList ID="ddldist" runat="server" class="form-control txtbox"
                                                            TabIndex="1">
                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="ReqfvDist" runat="server"
                                                        ControlToValidate="ddldist" ErrorMessage="Please Select District"
                                                        ValidationGroup="group" InitialValue="--Select--">*</asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">E-Mail *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control txtbox"
                                                            MaxLength="40" TabIndex="1" ValidationGroup="group"
                                                            ></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="Refvemail" runat="server"
                                                        ControlToValidate="txtEmail" ErrorMessage="Please Enter Email"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                        ControlToValidate="txtEmail" ErrorMessage="Please Enter Correct Email"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        ValidationGroup="group">*</asp:RegularExpressionValidator>--%>
                                                    </div>
                                                </div>
                                    </div>
                               </div>


                                <div class="col-md-12 d-flex">
                                   <div class="col-md-4">
                                        <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Mobile Number *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtMob" runat="server" class="form-control txtbox"
                                                            MaxLength="10" onkeypress="NumberOnly()" TabIndex="1" ValidationGroup="group"
                                                            ></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="reqfvmob" runat="server"
                                                        ControlToValidate="txtMob" ErrorMessage="Please Enter Mobile Number"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                   </div>
                                    <div class="col-md-4"  runat="server" id="trSubject">
                                        <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Subject *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtSub" runat="server" class="form-control txtbox"
                                                          MaxLength="40" TabIndex="1" TextMode="MultiLine"
                                                            ValidationGroup="group" ></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RefvSub" runat="server"
                                                        ControlToValidate="txtSub" ErrorMessage="Please Enter Grievance Subject"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Description *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:TextBox ID="txtDesc" runat="server" class="form-control txtbox"
                                                            MaxLength="40" TabIndex="1" TextMode="MultiLine"
                                                            ValidationGroup="group"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RefvDesc" runat="server"
                                                        ControlToValidate="txtDesc" ErrorMessage="Please Enter Grievance Description"
                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                    </div>
                               </div>


                                <div class="col-md-12 d-flex">
                                   <div class="col-md-4">
                                       <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">Upload *</label>
                                                    <div class="col-lg-6 d-flex">
                                                        <asp:FileUpload ID="FileUpload" runat="server" class="form-control"
                                                            Height="28px" />
                                                        
                                                        
                                                       
                                                        
                                                        
                                                    </div>
                                                </div>
                                   </div>
                                    <div class="col-md-2">
                                        <div class="form-group row mt-1">
                                        <asp:HyperLink ID="lblFileName1" runat="server" Class="form-control txtbox ml-3"
                                                            Target="_blank">[lblFileName1]</asp:HyperLink>
                                            </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="col-md-6">
                                            
                                            <asp:Label ID="Label560" runat="server" Visible="False"></asp:Label></div>
                                         <div class="col-md-6"><asp:Button ID="BtnUpload" runat="server" CssClass="form-control txtbox"
                                                            TabIndex="10" Text="Upload1"
                                                            Visible="False" /></div>
                                    </div>
                                    </div>

                                  

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12 float-end">
                                            <div class="form-group row justify-content-end">
                                                
                                                    <asp:Button runat="server" Text="Save as Draft" ID="btnsave" OnClick="btnsave_Click" class="btn btn-rounded btn-info btn-lg mr-2" BackColor="Green" Width="150px" />
                                                    <asp:Button ID="btnClear" Text="Clear" Visible="true" runat="server" class="btn btn-rounded btn-info btn-lg" OnClick="btnClear_Click" BackColor="#3333ff" Width="150px" />
                                                
                                            </div>
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
