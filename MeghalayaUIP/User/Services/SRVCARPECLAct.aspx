<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCARPECLAct.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCARPECLAct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="Dashboard/MainDashboard.aspx">Other Services</a></li>
            <li class="breadcrumb-item"><a href="#">SRVC Annual Returns</a></li>
            <li class="breadcrumb-item active" aria-current="page">SPrincipal Employer Under Contract Lbour Act</li>
        </ol>
    </nav>

    <contenttemplate>
        <div class="page-wrapper">
            <div class="content container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">ANNUAL RETURNS UNDER VARIOUS LABOUR LAWS</h4>
                            </div>
                            <div class="card-body">
                                <div class="col-md-12">
                                    <h4 class="card-title ml-3 text-center">FORM XXV</h4>
                                    <h4 class="card-title ml-3 text-center">[See Rule 82(2)]</h4>
                                    <h4 class="card-title ml-3 text-center">[ANNUAL RETURN OF ESTABLISHMENT EMPOYING UNDER CONTRACT LABOUR TO BE SENT TO THE REGISTERING OFFICER]</h4>
                                </div>


                                <div class="row">

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    1.1 Full name of Principal Employer
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnameprncplemplyr" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    1.2  Father's Name (in case of individuals) <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtfathersname" runat="server" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    1.3 Mobile No.
                                                 <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtmblno" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    1.4   Email ID <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtemailid" runat="server" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    1.5 Address of Principal Employer
                                                   <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtpeaddrss" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    2.1 Name of Establishment<span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtnameofestblsmnt" runat="server" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    2.2 Location of Establishment
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtlocestblshmnt" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    2.3 Postal Address of Establishment"<span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="pstladdrsestblsmnt" runat="server" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    3.1 Name of Manager
                                                  <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtmngrname" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    3.2 Manager Mobile No.<span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:TextBox ID="txtmgnrmbno" runat="server" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        3.3 Email ID
                                                    <span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtmngremailid" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        3.4 Address of Manager<span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtmngraddrs" runat="server" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        4. Nature of work carried on in the establishment
                                                        <span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtntrwrkcrdestblmnt" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        5. No. of contractors who worked in the establishments dusring the year<span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtcntrswrkdinestblshmnt" runat="server" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        6. Total number of days during the year on which contract labour was employed
                                                        <span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txttldysyrcontactemplyd" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        7. Total number of man-days worked by contract labour during the year<span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txttlmandysyrcntrtlbremplyd" runat="server" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        8. Maximum number of workmen employed directly on any day during the year
                                                        <span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtmxmnofwrkmn" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        9. Total number of days during the year on which direct labour was employed<span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtnofdysdrctemplyed" runat="server" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        10. Total number of man-days worked by directly-employed workmen
                                                        <span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txttlmandysyrbydrtemplyd" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <h4 class="card-title ml-3">Particulars of Contractors and Contract Labour</h4>
                                            <h6 class="card-title ml-3">Log Entry</h6>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        (a). Name of Contractor
                                                        <span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtnameofcntrtr" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        (b). Address of Contractor<span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtaddrsscntrtr" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        (c). Period of Contractor from
                                                        <span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtcntrtprdfrm" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        (d). Period of Contractor to<span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtcntrtprdto" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        (e). Nature of Work
                                                        <span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtntrofwrk" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        (f). Maximum number of workers employed by each contractor<span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtmxmwrkrsemplydbyechctnrtr" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        (g). Number of days worked
                                                    <span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtnofdyswrkd" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <label class="col-lg-6 col-form-label">
                                                        (h). Number of mandays worked<span class="star">*</span></label>
                                                    <div class="col-lg-6">
                                                        <asp:TextBox ID="txtnofmandyswrkd" runat="server" type="text" TabIndex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-6">
                                                <div class="form-group row">
                                                    <div class="col-lg-3">
                                                        <asp:Button ID="btnaddlog" runat="server" CssClass="btn btn-rounded btn-info btn-lg" Text="Add Log" OnClick="btnaddlog_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-12 d-flex">
                                            <asp:GridView ID="gvContractorLogs" runat="server" AutoGenerateColumns="False"
                                                BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                CssClass="GRD" ForeColor="#333333" GridLines="Both" Width="100%"
                                                OnRowDeleting="gvContractorLogs_RowDeleting"
                                                DataKeyNames="SlNo" EnableModelValidation="True">

                                                <RowStyle BackColor="#ffffff" />
                                                <Columns>
                                                    <asp:BoundField DataField="SlNo" HeaderText="Sl No." ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="NameOfContractor" HeaderText="Name of Contractor" />
                                                    <asp:BoundField DataField="AddressOfContractor" HeaderText="Address of Contractor" />
                                                    <asp:BoundField DataField="ContractPeriodFrom" HeaderText="Period From" />
                                                    <asp:BoundField DataField="ContractPeriodTo" HeaderText="Period To" />
                                                    <asp:BoundField DataField="NatureOfWork" HeaderText="Nature of Work" />
                                                    <asp:BoundField DataField="MaxWorkersEmployed" HeaderText="Max Workers Employed" />
                                                    <asp:BoundField DataField="NumberOfDaysWorked" HeaderText="Number of Days Worked" />
                                                    <asp:BoundField DataField="NumberOfMandaysWorked" HeaderText="Number of Mandays Worked" />
                                                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ControlStyle-ForeColor="Red" />
                                                </Columns>

                                                <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#013161" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>

                                        </div>

                                        <div class="col-md-12 text-right mt-2 mb-2">
                                            <asp:Button Text="Previous" runat="server" ID="btnPreviuos" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                            <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-rounded btn-save btn-lg" Width="150px" />
                                            <asp:Button ID="btnNext" Text="Next" runat="server" class="btn btn-rounded btn-info btn-lg" Width="150px" />
                                        </div>



                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </contenttemplate>
</asp:Content>
