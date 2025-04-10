<%@ Page Title="" Language="C#" MasterPageFile="~/User/user.Master" AutoEventWireup="true" CodeBehind="SRVCAnnualReturns.aspx.cs" Inherits="MeghalayaUIP.User.Services.SRVCAnnualReturns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb mb-0">
            <%-- <li class="breadcrumb-item"><a href="Dashboard/MainDashboard.aspx">Home</a></li>--%>
            <li class="breadcrumb-item"><a href="#">Other Services</a></li>
            <li class="breadcrumb-item active" aria-current="page">SRVC Annual Returns</li>
        </ol>
    </nav>

    <contenttemplate>
        <div class="page-wrapper">
            <div class="content container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">ANNUAL RETURNS APPLICABLE ACT SELECTION </h4>
                            </div>

                            <div class="card m-4">
                                <div class="card-header">
                                    <h4 class="card-title">List of Labour Laws of Annual Returns
                                    </h4>
                                </div>
                                <div class="card-body">
                                    <div class="col-md-12 d-flex">

                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-md-6 col-form-label">
                                                    Select Establishment <span style="color: red;">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="ddlOptions1" CssClass="form-control" runat="server" AutoPostBack="true">
                                                        <asp:ListItem Text="Select an option" Value="" />
                                                        <asp:ListItem Text="Option 1" Value="1" />
                                                        <asp:ListItem Text="Option 2" Value="2" />
                                                        <asp:ListItem Text="Option 3" Value="3" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2"></div>
                                        <div class="col-md-4">
                                            <div class="form-group row">
                                                <label class="col-md-6 col-form-label">
                                                    Annuat Return Year <span style="color: red;">*</span></label>
                                                <div class="col-lg-6 d-flex">
                                                    <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" AutoPostBack="true">
                                                        <asp:ListItem Text="Select an option" Value="" />
                                                        <asp:ListItem Text="Option 1" Value="1" />
                                                        <asp:ListItem Text="Option 2" Value="2" />
                                                        <asp:ListItem Text="Option 3" Value="3" />
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-2"></div>
                                    </div>
                                </div>


                                <div class="card m-4">
                                    <div class="card-header">
                                        <h4 class="card-title">Select Scale of Factory Establishment
                                        </h4>
                                    </div>
                                    <div class="card-body">
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-2">
                                                <asp:RadioButton CssClass="radio" ID="rbCSharp" runat="server" Text="Samll Scale" />
                                            </div>

                                            <div class="col-md-10">
                                                Factory/Estabosment Employing not more than 19 persons are employed or were employed on any day proceeding 12 Months
                                            </div>
                                        </div>
                                        <div class="col-md-12 d-flex">

                                            <div class="col-md-2">
                                                <asp:RadioButton ID="RadioButton2" CssClass="radio" runat="server" Text="Large Scale" Checked="true" />
                                            </div>

                                            <div class="col-md-10">
                                                Factory/Establisment Employing 20 and more persons are employed or were employed on any day proceeding 12 Months
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card mr-4 ml-4 mb-4 mt-1">
                                    <div class="card-header">
                                        <h4 class="card-title">Select Acts
                                        </h4>
                                    </div>
                                    <div class="card-body">
                                        <div class="col-md-12 d-flex">
                                            <div class="col-md-10">
                                                <asp:CheckBoxList CssClass="" ID="chkActs" runat="server">
                                                    <asp:ListItem Value="1" Text="&nbsp; The Meghalaya Factories Act, 1948"></asp:ListItem> <%--done--%>
                                                    <asp:ListItem Value="2" Text="&nbsp; The Meghalaya Shop & Commercial Establishment Act, 1950"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="&nbsp; The Maternity Benifit Act, 1961"></asp:ListItem>  <%--done--%>
                                                    <asp:ListItem Value="4" Text="&nbsp; The Workmen's Compensation Act, 1923"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="&nbsp; The Minimum wages Act 1948"></asp:ListItem>  <%--done--%>
                                                    <asp:ListItem Value="6" Text="&nbsp; The Payment of Wages Act 1936"></asp:ListItem>
                                                    <asp:ListItem Value="7" Text="&nbsp; The Payment of Bonus Act, 1965"></asp:ListItem>  <%--done--%>
                                                    <asp:ListItem Value="8" Text="&nbsp; Principal Employer under The Contract Labour Act, 1970"></asp:ListItem>  <%--done--%>
                                                    <asp:ListItem Value="9" Text="&nbsp; Principal Employer under The Inter-State Migrant Worlimen Act, 1979"></asp:ListItem>
                                                    <asp:ListItem Value="10" Text="&nbsp; The Motor Transport Worker's Act, 1961"></asp:ListItem>
                                                </asp:CheckBoxList>
                                            </div>




                                        </div>




                                    </div>
                                </div>
                            </div>

                            <div class="text-center mb-3">

                                <%--<input type="submit" name="ctl00$ContentPlaceHolder1$btnsave1" value="Back" id="ContentPlaceHolder1_btnsave11" class="btn btn-rounded btn-info btn-lg" style="width: 150px;">
                                    <a href="SRVCARFactoryAct.aspx">
                                <input type="button" class="btn btn-rounded btn-success btn-lg" style="width: 250px;" value="Start Filling Annual Return" /></a>--%>
                                <asp:Button ID="btnSave" runat="server" Text="Start Filling Annual Return" class="btn btn-rounded btn-success btn-lg" Style="width: 250px;" OnClick="btnSave_Click" />

                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" id="divgrd" runat="server" visible="false">
                    </div>
                </div>

            </div>
        </div>
    </contenttemplate>

</asp:Content>
