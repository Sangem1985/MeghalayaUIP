<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCARFactoryAct.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCARFactoryAct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <li class="breadcrumb-item"><a href="Dashboard/MainDashboard.aspx">Other Services</a></li>
            <li class="breadcrumb-item"><a href="#">SRVC Annual Returns</a></li>
            <li class="breadcrumb-item active" aria-current="page">SRVC Factory Act</li>
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
                                    <h4 class="card-title ml-3 text-center">FORM NO. 21</h4>
                                    <h4 class="card-title ml-3 text-center">[Prescribed under Section 110 of the Factories Act. 1948 and Rule 107(1) of the Meghalaya Factory Rules, 1952]</h4>
                                </div>


                                <div class="row">


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    1(a). Factory Registration No
                                                   
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    1(b). Factory Registration Date <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    2(a). Name of Factory
           
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    2(b). Return For the year 2015 <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    3. Name of Occupier
           
                <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    4. Name of Manager</label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    5(a). Phone No.
           
                <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    5(b). mobile No.</label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    6. Factory Address.
           
                <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    7. Pin Code/Zip Code.</label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    8. Nature of Manufacturing process (say exactily which is being manufactured).
           
                <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    9. Code No.</label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    10. Total Invstment Made.
           
                <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    10(a). Sector .</label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12">

                                        <div>
                                            <table cellspacing="0" rules="all" class="table table-succuss table-bordered" border="1" id="ContentPlaceHolder1_grdRevenueProj" style="border-collapse: collapse;">
                                                <tbody>
                                                    <tr class="GridviewScrollC1HeaderWrap" align="center" valign="middle" style="height: 40px;">
                                                        <th align="center" scope="col" rowspan="2" style="width: 25%;">&nbsp;</th>
                                                        <th align="left" scope="col" rowspan="2" style="width: 25%;">&nbsp;</th>
                                                        <th scope="col" rowspan="2" style="width: 25%;">For perennial factories</th>
                                                        <th scope="col" colspan="2" style="width: 25%;">Seassonal factories</th>

                                                    </tr>
                                                    <tr>
                                                        <th>During working season</th>
                                                        <th>During off season</th>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item">
                                                        <td rowspan="6">11. Average daily No. of workers employed</td>
                                                        <td class="text-left">ADULTS</td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item">

                                                        <td class="text-right">Men</td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item">

                                                        <td class="text-right">Women</td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item">

                                                        <td class="text-left">ADOLESCENT</td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item">

                                                        <td class="text-right">Men</td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item">

                                                        <td class="text-right">Women</td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                    </tr>




                                                    <tr class="GridviewScrollC1Item">
                                                        <td>12. No. of days worked in the year</td>
                                                        <td class="text-right">&nbsp;</td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                    </tr>





                                                    <tr class="GridviewScrollC1Item">
                                                        <td rowspan="2">13. No. of mandays worked during the year (total attendences)</td>
                                                        <td class="text-left">ADULTS
                                                            <br />
                                                            (i). Men &nbsp;&nbsp;&nbsp;&nbsp;(ii). Women</td>
                                                        <td rowspan="2">
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td rowspan="2">
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td rowspan="2">
                                                            <input type="text" class="form-control" value="" /></td>
                                                    </tr>

                                                    <tr class="GridviewScrollC1Item">

                                                        <td class="text-left">ADOLESCENT
                                                            <br />
                                                            (i). Male &nbsp;&nbsp;&nbsp;&nbsp;(ii). Female</td>

                                                    </tr>
                                                    <tr>
                                                        <td>14. Total no. of man hours worked (Including overtime)</td>
                                                        <td>(a) Men<br />
                                                            (b) Women<br />
                                                            (c) Children</td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                        <td>
                                                            <input type="text" class="form-control" value="" /></td>
                                                    </tr>



                                                    <tr>
                                                        <td rowspan="2">15. Normal hours worked per week</td>
                                                        <td>(a) Men</td>
                                                        <td colspan="3">
                                                            <input type="text" class="form-control w-25" value="" /></td>

                                                    </tr>
                                                    <tr>

                                                        <td>(a) Women</td>
                                                        <td colspan="3">
                                                            <input type="text" class="form-control w-25" value="" /></td>

                                                    </tr>

                                                </tbody>
                                            </table>
                                        </div>

                                    </div>


                                    <div class="col-md-12 d-flex mt-3">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    16(a). Does the factory carry any operation declared dangerous under section 87?
                
                 <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:RadioButtonList runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                        <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    16(b). If so, state average daily number of workers employed in such dangerous operation i.e. <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    17(a). Manufacture of a erated water and Process incidental thereto, etc (Schedule 1)
                
                 <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    17(b). Electrolytic plating or oxidation of metal article by use of an electrolytic containing chromic acid or other chromium compounds (Schedule II) <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    17(c). Manufacture and repair of accumulator (Shedule III), electric
                
                 <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    17(d). Manufacture and treatment of lead and certain compounds of lead <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    17(e). Liming and tanning of row hides and skins and process incidental thereto
                
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    17(f). Carrying of certain process of lead and lead material in printing process and type foundries <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    17(g). Chemical works
                
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    17(h). Menufacture of pottery and ceramics <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    17(i). Other dangerous
                
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                        </div>
                                    </div>



                                    <div class="col-md-12 mt-3">
                                        <h4 class="card-title ml-3 text-center">LEAVE WITH WAGES</h4>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <table cellspacing="0" rules="all" width="100%" class="table table-active table-bordered" border="1" id="ContentPlaceHolder1_grdRevenueProj11" style="border-collapse: collapse;">
                                                <tr>
                                                    <td rowspan="2">18. Total No of employed during the year</td>
                                                    <td>Men</td>
                                                    <td>
                                                        <input type="text" value="" class="form-control" /></td>
                                                </tr>
                                                <tr>

                                                    <td>Women</td>
                                                    <td>
                                                        <input type="text" value="" class="form-control" /></td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col-md-6">
                                            <table cellspacing="0" rules="all" border="1" class="table table-active table-bordered" width="100%" id="ContentPlaceHolder1_grdRevenueProj12" style="border-collapse: collapse;">
                                                <tr>
                                                    <td rowspan="2">19. No. of workers who were entitled to annual leave with wages during the year</td>
                                                    <td>Men</td>
                                                    <td>
                                                        <input type="text" value="" class="form-control" /></td>
                                                </tr>
                                                <tr>

                                                    <td>Women</td>
                                                    <td>
                                                        <input type="text" value="" class="form-control" /></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex mt-2">
                                        <div class="col-md-6">
                                            <table cellspacing="0" rules="all" width="100%" class="table table-active table-bordered" border="1" id="ContentPlaceHolder1_grdRevenueProj11" style="border-collapse: collapse;">
                                                <tr>
                                                    <td rowspan="2">20. No. of workers who were granted &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                                                        leave during the year</td>
                                                    <td>Men</td>
                                                    <td>
                                                        <input type="text" value="" class="form-control" /></td>
                                                </tr>
                                                <tr>

                                                    <td>Women</td>
                                                    <td>
                                                        <input type="text" value="" class="form-control" /></td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col-md-6 mt-2">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    21. No. of workers discharged or dismissed from the service whose service was terminated during the year
                
            <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    22. No. of such workers paid wages in lue leave
                
                <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                        </div>
                                    </div>


                                    <div class="col-md-12 mt-3">
                                        <h4 class="card-title ml-3 text-center">Canteen/Cold Drinking water
                                            <br />
                                            (Only for those factories which employing more than 250 workers)</h4>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(a). No. of canteens providing
                                   
                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(b). Cooked food and refreshment <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(c). Cooked food only
           
                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(d). Refreshment and tea only <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(e). Tea only
           
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(f). State reasons for not mantaining the canteen</label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(g). Approximate average no. of workers using daily
           
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(h). Is the canteen run/managed departmentily or through a contractor?</label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(i). Is the canteen running on NO PROFIT basis as required under the Meghalaya factory Rules, 1952?
           
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:RadioButtonList runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                        <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(j). Item of expenditure borne by the occupier stating separately. the total expenditure bourne by the occupier subsiding sale of food stuff or in otherwise selling food stuff below cost price.</label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(k). Please state if a common canteen is being shared with some other factory ?
           
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    23(l). Wheater provision for cooling drinking water has been made?.</label>
                                                <div class="col-lg-6">
                                                    <asp:RadioButtonList runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                        <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 mt-3">
                                        <h4 class="card-title ml-3 text-center">Rest Rooms/Shelters and Lunch Rooms<br />
                                            (Only for thoe factories which are employing more than 150 workers)</h4>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    24(a). No. of rest rooms/shelters provided
               
                <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    24(b). No. of lunch rooms provided <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>



                                    <div class="col-md-12 mt-3">
                                        <h4 class="card-title ml-3 text-center">CRECHE<br />
                                            (Only for thoe factories which are employing more than 30 women workers)</h4>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    25. No. of creches provided
                                   
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    26. Approximate average daily attendance of children at the creche <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    27(a). labour welfare officers (having prescribed qualification) appointed
           
                                                    <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    27(b). Wheather ambulance room is provided? <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <asp:RadioButtonList runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                        <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    27(c). State reasons for not appointing such officers not keeping ambulance room SAFETY OFFICER (Only for those factories which are employing 1000 or more workers)
           
                <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <input name="ctl00$ContentPlaceHolder1$txtPromoterName" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtPromoterName" class="form-control" tabindex="1" class="aspNetDisabled" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    28. Wheather qualified Safety Officer is appointing?</label>
                                                <div class="col-lg-6">
                                                    <asp:RadioButtonList runat="server" AutoPostBack="true" TabIndex="1" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="Yes" Text="Yes"></asp:ListItem>
                                                        <asp:ListItem Value="No" Text="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-12 mt-3">
                                        <h4 class="card-title ml-3 text-center">ACCIDENTS<br />
                                            FORM NO. 31<br />
                                            [Prescribed under rule 107(4) of the Meghalaya Factory Rules, 1952]</h4>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-6">
                                            <div class="form-group row">
                                                <label class="col-lg-6 col-form-label">
                                                    28(a). Total no. of accidents
       
                                                <span class="star">*</span></label>
                                                <div class="col-lg-6">
                                                    <div class="col-lg-6">
                                                        Fatal
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="col-lg-6">
                                                Non-Fatal
                                            </div>
                                            <div class="col-lg-6">
                                                <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <div class="col-md-12">
                                            <div class="form-group row">
                                                <label class="col-lg-12 col-form-label">
                                                    28(b). Accidents in which Workers returned to work during the year to which this return relates:-
           
                                    <span class="star">*</span></label>

                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-12 d-flex">
                                        <table class="table table-bordered table-active">
                                            <tr>
                                                <th>&nbsp;</th>
                                                <th>Number</th>
                                                <th>Mandays lost</th>
                                            </tr>
                                            <tr>
                                                <td>(i). Accidents (persons injured) occuring during the year in which workers return to work during the same year</td>
                                                <td>
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </td>
                                                <td>
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>(ii). Accidents (persond injured) occuring in the previous year in which workers return to work during the year to which this return relates
                                                </td>
                                                <td>
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </td>
                                                <td>
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>(iii). Accidents in which workers did not return to work during the year</td>
                                                <td>
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </td>
                                                <td>
                                                    <input name="ctl00$ContentPlaceHolder1$txtSoWoDo" type="text" value="" maxlength="50" id="ContentPlaceHolder1_txtSoWoDo" tabindex="1" class="form-control" onkeypress="return validateNames(event)" onkeyup="handleKeyUp(this)" autocomplete="off">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                  <div>
                                      &nbsp;
                                  </div>
                                    <div class="col-md-12 text-right mb-3">
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
    </contenttemplate>

</asp:Content>
